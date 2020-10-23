//
//  SGSpeechRecognizer.h
//  SpeechRecognizer_inc
//
//  Created by Sogou on 14-1-6.
//  Copyright (c) 2014年 Sogou. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SGRecorder.h"
#import "SGVad.h"


/******************************************
 定义搜狗语音识别错误代码。
 ******************************************/
typedef enum SG_ERROR {
    ERROR_RECORDER_TIMEOUT =1, //=========识别结果在语音结束后(SGRecognizeTimeOut)秒没有返回结果。
    ERROR_NETWORK_STATUS_CODE = 2, //-----网络异常且超重试次数
    ERROR_AUDIO = 3,//====================录音任务错误
    ERROR_SERVER = 4,//-------------------后端服务器错误
    ERROR_CLIENT = 5,//===================客户端错误
    ERROR_SPEECH_TIMEOUT = 6,//-----------未检测到有效语音
    ERROR_NO_MATCH = 7,//=================无解码结果
    ERROR_RECOGNIZER_BUSY = 8,//----------服务器繁忙
    ERROR_INSUFFICIENT_PERMISSIONS=9,//===禁止操作
    ERROR_PREPROCESS = 10,//--------------预处理任务错误
    ERROR_NETWORK_UNAVAILABLE = 11,//=====网络不可达
    ERROR_NETWORK_PROTOCOL = 12,//--------网络协议错误
    ERROR_NETWORK_IO = 13,//==============网络IO错误
    
    ERROR_UNKNOWN = 100
}SGSPEECH_RECOGNIZE_ERROR;

/******************************************
 设置委托对象：
 ******************************************/
@protocol SGSpeechRecognizerDelegate<NSObject>

/*
    返回结果时回调
    @param results
        记录识别结果的NSArray，一个由NSString* 构成的二维数组NSArray。
    @param confidences
        记录识别结果置信度的NSArray，一个由NSString* 构成的二维数组NSArray。
    @param isLastPart
        标识是否是服务器返回的最后一个结果。
    @param num
        标识二维数组中一共有多少组短句。
 */
- (void)onResults:(NSArray*)results withConfidence:(NSArray*)confidences isLastPart:(BOOL)isLastPart amount:(int)num;

//返回错误时回调
- (void)onError:(NSError*)error;

// 录音结束后回调
- (void)onRecordStop;

/*
    音量回调，取值[0,100]
    默认以屏幕刷新率进行回调
 */
- (void)onUpdateVolumn:(int)volumn;

@optional

-(void) didEncodeData:(NSData*)encodeData;
@end




/******************************************
 搜狗语音识别类
 ******************************************/
@interface SGSpeechRecognizer : NSObject<SGRecorderDelegate>

+(SGSpeechRecognizer*)shareSpeechRecognizerInstance;

//  保存所有已经收到的识别结果。
@property (nonatomic,retain)NSMutableArray* resultsArr;

//  保存所有已经收到的识别结果对应的置信度（没有在回调函数中体现）。
@property (nonatomic,retain)NSMutableArray* confidencesArr;

//  响应回调函数的委托类
@property (assign) id<SGSpeechRecognizerDelegate> recognizeDelegate;

//  网络请求中的v字段。连续语音识别使用newVersion,非连续语音识别使用oldVersion。
@property (assign) int newVersion;
@property (assign) int oldVersion;


//  设置语音类型
-(void)setArea:(int)area;

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
-(void)setTypeNo:(int)reserved press:(int)pre application:(int)app frequency:(int)freq gender:(int)sex age:(int)age;

/*
    开始录音并识别。
        @param isSaveWav：   是否保存录音文件。
        @param isContinuous：是否连续语音识别。
        @param isVadStop：   是否自动检测语音停止。
 */
-(void)startAndSave:(BOOL)isSaveWav isContinuous:(BOOL)isContinuous isVadStop:(BOOL)isVadStop;

//  停止录音，已录的继续识别。不打断识别。
-(void)stop;

//  停止录音，取消识别。
-(void)cancel;

//  是否开启发送pingBack信息的开关
-(void)setPingBackEnable:(BOOL)isPingBack;

//  是否自动发送pingback请求（自动发送pingback信息会使得pingback不全面比如：chosen字段和退出主界面的信息没法获取）。
//  当isAutoSend设置为NO，需要手动添加pingback发送函数，进行手动添加。
-(void)setAutoSendPingback:(BOOL)isAutoSend;

//  设置vad头部和尾部的判断时间长度（单位：毫秒。默认为3000ms头部，900ms尾部）
-(void)setVadHeadInterval:(int)head withTailInterval:(int)tail;

//  设置录音最多能够录多少秒。
-(void)setMaxRecordInterval:(float)interval;

//  设置保存语音压缩后数据的保存路径，文件名不可设置，文件名以时间命名。
-(void)setSaveSpxPath:(NSString*)spxPathStr;

//当传入yes时，保存spx数据；当传入NO时，将回调-(void) didEncodeData:(NSData*)encodeData;将压缩后的数据传出。
-(void)saveHighSpeexEncode:(BOOL)isSave;

//  设置http请求的url前缀（语音识别服务器地址）
-(void)setUrl:(NSString*)urlStr;

//  设置其他自定义参数，可设置为空，做中转或扩展用
-(void)setOtherParams:(NSDictionary*)paramsDic;


@end
