//
//  SDKBridge.h
//  Unity-iPhone
//
//  Created by sofoso on 16/06/09.
//
//

@interface SDKBridge : NSObject

extern "C" {
    extern void showLoginView();
    
    void gobackUnityView();
}
@end