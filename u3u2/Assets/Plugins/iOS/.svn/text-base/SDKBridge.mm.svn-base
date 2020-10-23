#import "SDKManager.h"
#import "UnityAppController.h"
#import "GameDoSDK/GameDoSDK.h"
#import "TalkingDataAppCpa.h"


@interface SDKBridge : NSObject

@end

@implementation SDKBridge

extern "C"
{
    static SDKManager* sdkManager = nil;
    
    UINavigationController * t_navigationController = NULL;
    UIWindow * t_window = NULL;
    UIViewController * unity_controller = NULL;
    
    void showLoginView()
    {
        UnityAppController * app = (UnityAppController*)[UIApplication sharedApplication].delegate;
        SDKManager * viewcontroller = [[SDKManager alloc]init];
        t_navigationController = [[UINavigationController alloc] initWithRootViewController:viewcontroller];
        [t_navigationController setNavigationBarHidden:true];

        t_window = app.window;
        if(unity_controller == NULL)
            unity_controller = t_window.rootViewController;
        t_window.rootViewController = t_navigationController;
    }
    
    void getAppID(const char** appId)
    {
        NSString *identifier = [[NSBundle mainBundle] bundleIdentifier];
        *appId = [identifier UTF8String];
    }
    
    void gobackUnityView()
    {
        t_window.rootViewController = unity_controller;
        if(t_navigationController != NULL)
        {
            t_navigationController = NULL;
        }
    }
  void TalkDataLogin(const char* account){
        [TalkingDataAppCpa onLogin:[NSString stringWithUTF8String:account]];
        
    }
    void TalkDataRegister(const char* account){
        [TalkingDataAppCpa onCreateRole:[NSString stringWithUTF8String:account]];
    }
}

@end
