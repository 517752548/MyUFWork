#import "SDKBridge.h"
#import "SDKManager.h"
#include "UnityAppController.h"

@implementation SDKManager

- (void)viewDidLoad {
    [super viewDidLoad];

    [[UIApplication sharedApplication] setStatusBarHidden:YES];
    
    UILoginViewController *_UserLoginViewController =[[UILoginViewController alloc]init];
    _UserLoginViewController.GameDoLoadingDelegate = self;
    [self.navigationController pushViewController:_UserLoginViewController animated:YES];
}

-(void)showLoginView
{
//    if (_UserLoginViewController == nil)
//    {
//        _UserLoginViewController =[[UILoginViewController alloc]init];
//        _UserLoginViewController.GameDoLoadingDelegate = self;
//    }
//    
//    [self.navigationController pushViewController:_UserLoginViewController animated:YES];
//    
//    [GetAppController().rootViewController presentViewController:_UserLoginViewController animated:YES completion:nil];

    return;
}

-(void)gameLoading:(NSString*)accountId
{
    [self.navigationController popViewControllerAnimated:YES];

    gobackUnityView();
    
    UnitySendMessage("ScriptsRoot", "GotIOSAccountId", [accountId UTF8String]);
    
    return;
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (BOOL)prefersStatusBarHidden
{
    return YES;
}

@end