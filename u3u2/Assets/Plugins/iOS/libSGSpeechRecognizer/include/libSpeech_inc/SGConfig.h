//
//  Header.h
//  SpeechRecognizer_inc
//
//  Created by Sogou on 14-2-21.
//  Copyright (c) 2014年 Sogou. All rights reserved.
//

#ifndef SpeechRecognizer_inc_SGConfig_h
#define SpeechRecognizer_inc_SGConfig_h

//used by SGSpeechRecognizer
#define SGRecognizeTimeOut 38

//used by SGRecorder
#define kNumberBuffers           3
#define kSampleRate              16000
#define kBITS_PER_SAMPLE         16
#define kChannel                 1
#define kBufferDurationSeconds   0.3

#define kMinDBvalue -80.0

//used by SGRecognzerHttpRequest
#define SGRecognizeHttpRequest_MaxRetryTime  2
#define SGRecognizeHttpRequest_TimeoutInterval  10

//该参数暂时不起作用。
#define RESULT_AMOUNT 4

//定义debug控制台输出
//#define DEBUG_MARX
#ifdef DEBUG_MARX
# define DLog(fmt, ...) NSLog((fmt), ##__VA_ARGS__);
#else
# define DLog(...);
#endif


#endif

