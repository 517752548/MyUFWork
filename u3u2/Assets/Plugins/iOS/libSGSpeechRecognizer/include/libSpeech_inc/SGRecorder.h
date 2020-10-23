//
//  SGRecorder.h
//  SpeechRecognizer_inc
//
//  Created by Sogou on 14-1-6.
//  Copyright (c) 2014年 Sogou. All rights reserved.
//




#import <Foundation/Foundation.h>
#import <AudioToolbox/AudioToolbox.h>
#import "SGConfig.h"

//录音协议：需要实现一个按照音频规定格式提供数据的消息方法。
@protocol SGRecorderDelegate <NSObject>
//传出frame大小的音频流
-(void)postOriginalVoiceData:(NSData*)originalVoiceData isLast:(BOOL)isLast;

//控制录音停止：为了统一在Recognizer中控制管理识别，当录音达到最大长度的时候要调到recognizer中停止Recorder。
-(void)postStopMessage;
@end



@interface SGRecorder : NSObject
{
    AudioStreamBasicDescription  mRecordFormat;                 // 声音格式设置
    AudioQueueRef                mQueue;                        // 每一块的音频流
    AudioQueueBufferRef          mBuffers[kNumberBuffers];      // 内存分块
    AudioFileID                  mRecordFile;                    // 写入的文件ID
    SInt64                       mCurrentPacket;                // 当前读取包索引
    bool                         mIsRunning;
    BOOL                         isSaveWav;
    
    BOOL                         mIsSetAudioSession;
    
    OSStatus errorStatus;
}

@property(assign)AudioStreamBasicDescription recordFormat;
@property(assign)BOOL isSaveWav;
@property(assign)id<SGRecorderDelegate> recordDelegate;
@property(assign)float max_audio_time;

-(BOOL) prepareRecord;

-(BOOL) startRecord;

//停止录音，会发出一个此是最后一段的消息
-(void) stopRecord;
//取消录音，不会向下一级发送最后一段的信息。（可加变量合并）
-(void) cancelRecord;

-(float) CurrentLevelMeter;
@end


//计算实时的分贝以产生依据声音大小变化数值
@interface MeterTable : NSObject
{
    float	mMinDecibels;
	float	mDecibelResolution;
	float	mScaleFactor;
	float	*mTable;
}

-(id)init;
-(id)initWithData:(float)inMinDecibels size:(size_t)inTableSize root:(float)inRoot;
-(float)valueAt:(float)inDecibels;
-(double)dbToAmp:(double)inDb;

@end

