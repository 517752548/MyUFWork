#import "IAPManager.h"
#include "UnityAppController.h"

@implementation IAPManager

-(void) attachObserver
{
    [[SKPaymentQueue defaultQueue] addTransactionObserver:self];
}

-(BOOL) canMakePayment
{
    return [SKPaymentQueue canMakePayments];
}

-(void) buyProduct:(NSString *)productIdentifier
{
    NSLog(@"buyProduct: %@, queueCount:%d", productIdentifier, _payQueueCount);
    if (_payQueueCount == 0)
    {
        [GetAppController() showActivityIndicator];
    }
    NSArray *idArray = [productIdentifier componentsSeparatedByString:@","];
    NSSet *idSet = [NSSet setWithArray:idArray];
    [self sendRequest:idSet];
    _payQueueCount = _payQueueCount + 1;
}

-(void)sendRequest:(NSSet *)idSet
{
    NSLog(@"sendRequest");
    SKProductsRequest *request = [[SKProductsRequest alloc] initWithProductIdentifiers:idSet];
    request.delegate = self;
    [request start];
}

-(void)productsRequest:(SKProductsRequest *)request didReceiveResponse:(SKProductsResponse *)response
{
    NSLog(@"productsRequest");
    //[GetAppController() showActivityIndicator];
    NSArray *products = response.products;
    if ([products count] > 0)
    {
        for (SKProduct *p in products)
        {
            [self buyRequest:p];
        }
    }
    else
    {
        _payQueueCount = _payQueueCount - 1;
        if (_payQueueCount == 0)
        {
            [GetAppController() hideActivityIndicator];
        }
    }
    
    if ([response.invalidProductIdentifiers count] > 0)
    {
        for(NSString *invalidProductId in response.invalidProductIdentifiers){
            NSLog(@"Invalid product id:%@",invalidProductId);
        }
        
        NSString* errorMsg = @"商品不存在\n";
        errorMsg = [errorMsg stringByAppendingString:[response.invalidProductIdentifiers componentsJoinedByString:@","]];
        
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"错误" message:errorMsg delegate:nil cancelButtonTitle:@"确定" otherButtonTitles:nil, nil];
        [alert show];
    }
}

-(void)buyRequest:(SKProduct *)product{
    NSLog(@"buyRequest");
    SKPayment *payment = [SKPayment paymentWithProduct:product];
    [[SKPaymentQueue defaultQueue] addPayment:payment];
}

-(NSString *)transactionInfo:(SKPaymentTransaction *)transaction{
    NSLog(@"transactionInfo");
    return [self encode:(uint8_t *)transaction.transactionReceipt.bytes length:transaction.transactionReceipt.length];
}

-(NSString *)encode:(const uint8_t *)input length:(NSInteger) length{
    NSLog(@"encode");
    static char table[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
    
    NSMutableData *data = [NSMutableData dataWithLength:((length+2)/3)*4];
    uint8_t *output = (uint8_t *)data.mutableBytes;
    
    for(NSInteger i=0; i<length; i+=3){
        NSInteger value = 0;
        for (NSInteger j= i; j<(i+3); j++) {
            value<<=8;
            
            if(j<length){
                value |=(0xff & input[j]);
            }
        }
        
        NSInteger index = (i/3)*4;
        output[index + 0] = table[(value>>18) & 0x3f];
        output[index + 1] = table[(value>>12) & 0x3f];
        output[index + 2] = (i+1)<length ? table[(value>>6) & 0x3f] : '=';
        output[index + 3] = (i+2)<length ? table[(value>>0) & 0x3f] : '=';
    }
    
    return [[NSString alloc] initWithData:data encoding:NSASCIIStringEncoding];
}

-(void) provideContent:(SKPaymentTransaction *)transaction{
    NSLog(@"provideContent");
    NSString *receipt = [self transactionInfo:transaction];
    UnitySendMessage("ScriptsRoot", "ReceivedIAPReceipt", [receipt UTF8String]);
}

-(void)paymentQueue:(SKPaymentQueue *)queue updatedTransactions:(NSArray *)transactions{
    for (SKPaymentTransaction *transaction in transactions) {
        NSLog(@"paymentQueue : id:%@, state:%d",transaction.transactionIdentifier, (int)transaction.transactionState);
        switch (transaction.transactionState) {
            case SKPaymentTransactionStatePurchased:
                [self completeTransaction:transaction];
                break;
            case SKPaymentTransactionStateFailed:
                [self failedTransaction:transaction];
                break;
            case SKPaymentTransactionStateRestored:
                [self restoreTransaction:transaction];
                break;
            default:
                break;
        }
    }
}

-(void) completeTransaction:(SKPaymentTransaction *)transaction{
    NSLog(@"Comblete transaction : %@",transaction.transactionIdentifier);
    [self provideContent:transaction];
    [[SKPaymentQueue defaultQueue] finishTransaction:transaction];
    _payQueueCount = _payQueueCount - 1;
    if (_payQueueCount == 0)
    {
        [GetAppController() hideActivityIndicator];
    }
}

-(void) failedTransaction:(SKPaymentTransaction *)transaction{
    NSLog(@"Failed transaction : %@",transaction.transactionIdentifier);
    [[SKPaymentQueue defaultQueue] finishTransaction:transaction];
    _payQueueCount = _payQueueCount - 1;
    if (_payQueueCount == 0)
    {
        [GetAppController() hideActivityIndicator];
    }
}

-(void) restoreTransaction:(SKPaymentTransaction *)transaction{
    NSLog(@"Restore transaction : %@",transaction.transactionIdentifier);
    [[SKPaymentQueue defaultQueue] finishTransaction:transaction];
    _payQueueCount = _payQueueCount - 1;
    if (_payQueueCount == 0)
    {
        [GetAppController() hideActivityIndicator];
    }
}

@end