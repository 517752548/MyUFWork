#import <StoreKit/StoreKit.h>

@interface IAPManager : NSObject<SKProductsRequestDelegate, SKPaymentTransactionObserver>
{
    int _payQueueCount;
}

-(void)attachObserver;
-(BOOL)canMakePayment;
-(void)buyProduct:(NSString *)productIdentifier;

@end