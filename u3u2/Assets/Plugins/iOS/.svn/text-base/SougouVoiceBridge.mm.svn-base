#import "SougouVoice.h"

@interface SougouVoiceBridge : NSObject

@end

@implementation SougouVoiceBridge

extern "C"
{
    //开始录音并识别
    void startRec()
    {
        [[SougouVoice instance] startRec];
    }
    
    //停止本次录音，但不影响本次识别
    void stopRec()
    {
        [[SougouVoice instance] stopRec];
    }
    
    //取消本次录音和识别
    void cancelRec()
    {
        [[SougouVoice instance] cancelRec];
    }
    
    //播放录音
    void playSound(const char* fileName)
    {
        [[SougouVoice instance] playSound:[NSString stringWithUTF8String:fileName]];
    }
    
    //设置录音上传地址
    void setRecUploadURL(const char* url)
    {
        [[SougouVoice instance] setRecUploadURL:[NSString stringWithUTF8String:url]];
    }
}

@end