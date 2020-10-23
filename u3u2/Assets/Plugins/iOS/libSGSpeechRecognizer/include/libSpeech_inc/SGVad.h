//
//  SGVad.h
//  SpeechRecognizer_inc
//
//  Created by Sogou on 14-1-9.
//  Copyright (c) 2014年 Sogou. All rights reserved.
//


#import <Foundation/Foundation.h>
#import <AudioToolbox/AudioToolbox.h>



@interface SGVad : NSObject

@property (assign)BOOL isVoiced;

- (id)initWithFormat:(AudioStreamBasicDescription)recordFormat withHeadInterval:(int)headInterval withTailInterval:(int)tailInterval withMaxWavInterval:(int)interval;

//@param result:vad处理后的状态：0表示无处理；1表示检测到语音结束；2表示未检测到有效声音
//返回值是一个持有(retain)NSData*
- (NSData *)appendVadData:(NSData *)voiceData result:(int *)result isAutoStop:(BOOL)isAutoStop;
@end