//
//  SGSpeexHelper.h
//  speechSDK
//
//  Created by Sogou on 14-1-15.
//  Copyright (c) 2014年 sogou. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Speex.framework/Headers/speex.h"

#define FRAME_SIZE 320   //音频8khz*20ms/16khz*20ms -> 8000*0.02=160/16000*0.02=320
#define MAX_NB_BYTES 200 //被写入已编码的帧的指针的可被写入的最大字节数 200
#define QUALITY 7  //压缩质量 4/7

@interface SGSpeexHelper : NSObject
{
    short speech[FRAME_SIZE]; //数据缓存
    short encodeShort[FRAME_SIZE];  //指向每个speex帧开始的short型指针
    char speexFrame[MAX_NB_BYTES];//即将被写入已被编码的帧的char型指针
    void * encode_state;
    SpeexBits bits;
    
    
}
@property(nonatomic,retain)NSMutableData* speexData;

@property(nonatomic,retain)NSMutableData * vadData;

//返回值是一个retain持有的NSMutableData
-(NSMutableData*)encode:(NSData *)rawData isLast:(BOOL)isLast;

- (id)initWithQuality:(int)quality;

@end

