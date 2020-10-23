#import "IAPManager.h"

@interface IAPBridge : NSObject

@end

@implementation IAPBridge

extern "C"
{
    IAPManager* iapManager = nil;
    
    void InitIAPManager()
    {
        if (iapManager == nil)
        {
            iapManager = [[IAPManager alloc] init];
            [iapManager attachObserver];
        }
    }
    
    bool IsIAPAvailable()
    {
        bool res = [iapManager canMakePayment];
        if (res)
        {
            NSLog(@"can pay");
        }
        else
        {
            NSLog(@"can not pay");
        }
        return res;
    }
    
    void IAPBuyProduct(const char *p)
    {
        [iapManager buyProduct:[NSString stringWithUTF8String:p]];
    }
}

@end