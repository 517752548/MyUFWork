#import <AVFoundation/AVFoundation.h>
#import "SougouVoice.h"
#import "SGSpeechRecognizer.h"
#import "SGRecognizerPingBack.h"
#import "SGSpeexDecoder.h"
#import "UnityInterface.h"

@interface SougouVoice ()
{
    BOOL isStarted;
    NSInteger parseState;
    NSMutableArray* unityMsgData;
    AVAudioPlayer* audioPlayer;
    NSString* uploadUrl;
}
@end

@implementation SougouVoice

#pragma mark Singleton Methods

+ (id)instance {
    static SougouVoice* ins = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        ins = [[self alloc] init];
        [ins initialize];
        
    });
    return ins;
}

-(void)initialize
{
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] setRecognizeDelegate:self];
    /*
     type_no包含6个字段，由22位的无符号2进制数据组成（以十进制数据呈现）。从高位到低位分别定义如下：
     (1)reserved：预留字段，5位，默认为00000。
     (2)press：压缩标志位，3位。000表示不压缩，001为speex压缩，010为adpcm压缩，011为amr压缩，默认为001。
     (3)application：应用类型，5位，最多可以表示32种不同类型的应用，
     前2位表示操作系统类型（00为Android，01为iOS，10为Symbian，11为其他），
     后3位表示具体应用（000为输入法，001为地图，010为中文siri，011为搜狐广告，100为搜狐评论，101为搜狐生活，110搜狗号码通，111为搜索）
     (4)frequency：采样频率和采样位数标志位，4位。
     最多可以表示16种，0000表示8KHz，16bit，单声道；0001表示16KHz，16bit，单声道；0010表示8KHz，16bit，双声道；0011表示16KHz，16bit，双声道。
     2G网络中使用第0000种，3G网络中使用第0001种。默认为0001 (服务器现不支持8kHz采样)。
     (5)gender：性别，2位（供用户自选，00未知，01男，10女，默认暂定为00）。
     (6)age：年龄段，3位（供用户自选，000未知，001幼儿，010少年，011青年，100中年，101老年，默认暂定为000）。
     */
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] setTypeNo:0 press:1 application:0b01101 frequency:0b0001 gender:0 age:0b000];
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] setOldVersion:5900];
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] setNewVersion:5950];//连续语音识别暂未上线，但此参数必须设置。
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] setArea:0];//默认为0
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] setVadHeadInterval:3000 withTailInterval:900];//之前的默认设置
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] setMaxRecordInterval:30];//设置最长能录音多久，默认值为30秒
    //如果要发送pingback信息此函数需设置YES
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] setPingBackEnable:YES];
    //如果需要手动选择发送pingback信息的时机，需设置为NO,如果设置为YES会缺失一部分信息，例如：会使chosen字段和error中某些情况获取不到。
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] setAutoSendPingback:NO];
    
    //设置自定义参数（此处可设置为空，只做中转使用）。
    //[[SGSpeechRecognizer shareSpeechRecognizerInstance]setOtherParams:@{@"test":@"testStr"}];
    
    [[SGSpeechRecognizer shareSpeechRecognizerInstance]saveHighSpeexEncode:NO];
    // Do any additional setup after loading the view, typically from a nib.
    unityMsgData = [NSMutableArray arrayWithObjects:@"", @"", @"", nil];
    [[AVAudioSession sharedInstance] setCategory:AVAudioSessionCategoryPlayback error:nil];
    /*
    AudioSessionSetActive(false);
    
    AudioSessionInitialize(NULL, NULL, NULL, NULL);
    
    //设置kAudioSessionProperty_AudioCategory
    UInt32 sessionCategory = kAudioSessionCategory_MediaPlayback;
    AudioSessionSetProperty(kAudioSessionProperty_AudioCategory, sizeof(sessionCategory), &sessionCategory);
    UInt32 bAllowMix = 1;
    //跟其他音乐混合播放
    AudioSessionSetProperty(kAudioSessionProperty_OverrideCategoryMixWithOthers, sizeof(bAllowMix), &bAllowMix);
    
    //其他音乐音量降低；
    UInt32 bShouldDuck = 1;
    AudioSessionSetProperty(kAudioSessionProperty_OtherMixableAudioShouldDuck, sizeof(bShouldDuck), &bShouldDuck);
    
    //设置使用扬声器播放
    UInt32 audioRouteOverride = kAudioSessionOverrideAudioRoute_Speaker;
    AudioSessionSetProperty(kAudioSessionProperty_OverrideAudioRoute, sizeof(audioRouteOverride), &audioRouteOverride);
     */
    uploadUrl = @"http://www.wingloong.com/tapfaster/uploadfile";
}

-(void)startRec
{
    NSLog(@"------开始录音识别------");
    parseState = 0;
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] startAndSave:NO isContinuous:NO isVadStop:YES];
}

-(void)stopRec
{
    NSLog(@"------停止录音识别------");
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] stop];
    [SGRecognizerPingBack setClickValue:2];
    [[AVAudioSession sharedInstance] setCategory:AVAudioSessionCategoryPlayback error:nil];
}

-(void)cancelRec
{
    NSLog(@"------取消录音识别------");
    [[SGSpeechRecognizer shareSpeechRecognizerInstance] cancel];
    if (isStarted) {
        [SGRecognizerPingBack setClickValue:1];
        [SGRecognizerPingBack onEndWithText:nil error:0];
    }
    [[AVAudioSession sharedInstance] setCategory:AVAudioSessionCategoryPlayback error:nil];
}

-(void)uploadSound:(NSData*)data
{
    //NSString* uploadUrl = @"http://www.wingloong.com/tapfaster/uploadfile";
    NSData* soundData = data;
    NSLog(@"try upload sound length:%lu", (unsigned long)[soundData length]);
    NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:[NSURL URLWithString:uploadUrl] cachePolicy:0 timeoutInterval:10.0f];
    request.HTTPMethod = @"POST";
    request.HTTPBody = soundData;
    [NSURLConnection sendAsynchronousRequest:request queue:[[NSOperationQueue alloc] init]
                           completionHandler:^(NSURLResponse* response, NSData* data, NSError* connectionError) {
                               NSError *error;
                               NSDictionary* jsonData = [NSJSONSerialization JSONObjectWithData:data options:kNilOptions error:&error];
                               if (jsonData != nil)
                               {
                                   NSString* soundUrl = [jsonData valueForKey:@"url"];
                                   [unityMsgData replaceObjectAtIndex:0 withObject:[soundUrl stringByAppendingString:@"|"]];
                                   [self updateParseState];
                               }
                           }];
}

-(void)playSound:(NSString*)fileName
{
    NSLog(@"download sound:%@", fileName);
    NSURL *url = [NSURL URLWithString:fileName];
    NSURLRequest *request = [NSURLRequest requestWithURL:url];
    NSURLSession *session = [NSURLSession sharedSession];
    NSURLSessionDataTask *dataTask = [session dataTaskWithRequest:request
                                                completionHandler:
                                      ^(NSData *data, NSURLResponse *response, NSError *error) {
                                          NSLog(@"downloaded sound length:%lu", (unsigned long)[data length]);
                                          NSData *PCMData =  [SGSpeexDecoder DecodeSpeexToWAVE_C:data];
                                          @autoreleasepool {
                                              NSError *soundDecodeError;
                                              audioPlayer = [[AVAudioPlayer alloc] initWithData:PCMData error:&soundDecodeError];
                                              if (error) {
                                                  NSLog(@"soundDecodeError: %@", soundDecodeError);
                                              }
                                              else
                                              {
                                                  NSLog(@"start play sound");
                                                  //audioPlayer.delegate = self; // 设置代理
                                                  audioPlayer.numberOfLoops = 0;// 不循环播放
                                                  [audioPlayer prepareToPlay];// 准备播放
                                                  [audioPlayer play];// 开始播放
                                              }
                                          }
                                      }];
    // 使用resume方法启动任务
    [dataTask resume];
}

-(void)onResults:(NSArray *)results withConfidence:(NSArray*)confidences isLastPart:(BOOL)isLastPart amount:(int)num
{
    NSString *currentBuffer = @"";
    for (int i=0; i<[results count]; i++) {
        currentBuffer = [currentBuffer stringByAppendingString:[ [results objectAtIndex:i] objectAtIndex:0]];
    }
    NSString* result = [NSString stringWithFormat:@"此次结果有%d个：%@ \n",num,currentBuffer];
    NSLog(@"%@", result);
    [unityMsgData replaceObjectAtIndex:1 withObject:[currentBuffer stringByAppendingString:@"|"]];
    [self updateParseState];
    [SGRecognizerPingBack setChosen:0];//设置pingback的chosen值。
}

-(void)onError:(NSError *)error
{
    [SGRecognizerPingBack onEndWithText:nil error:(int)[error code]];
}


-(void)onRecordStop
{
    
}

-(void)onUpdateVolumn:(int)volumn
{
}

-(void)didEncodeData:(NSData *)encodeData
{
    NSUInteger dataLength = [encodeData length];
    NSLog(@"has received encode data ,the length is %lu",(unsigned long)dataLength);
    float time = [encodeData length] / 3600.0f * 3.0f;
    [unityMsgData replaceObjectAtIndex:2 withObject:[NSString stringWithFormat:@"%.2f", time]];
    [self updateParseState];
    [self uploadSound:encodeData];
}

-(void)updateParseState
{
    parseState++;
    if (parseState == 3)
    {
        NSString* msgData = @"";
        for (int i = 0; i < parseState; i++) {
            msgData = [msgData stringByAppendingString:[unityMsgData objectAtIndex:i]];
        }
        
        UnitySendMessage("ScriptsRoot", "onChat", [msgData UTF8String]);
    }
}

-(void)setRecUploadURL:(NSString*)url
{
    uploadUrl = url;
}

@end