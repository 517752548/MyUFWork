//
//  SGSpxDecoder.h
//  SpeechRecoginzer_inc
//
//  Created by Sogou on 14-11-20.
//  Copyright (c) 2014年 Sogou. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface SGSpeexDecoder : NSObject

//+(NSData *)DecodeSpeexToWAVE:(NSData *)data;
+(NSData*)DecodeSpeexToWAVE_C:(NSData *)data;

@end
