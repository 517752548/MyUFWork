//
//  SGUserInfo.h
//  SpeechRecoginzer_inc
//
//  Created by Sogou on 14-3-6.
//  Copyright (c) 2014年 Sogou. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface SGUserInfo : NSObject
@property(nonatomic, copy)NSString* serverUrl;
@property(nonatomic, retain)NSDictionary* otherParams;

+ (int)networkTypeFromStatusBar ;
+ (NSString *)imei;

+ (NSString *)getBundleDisplayName;
+(SGUserInfo*)shareUserInfoInstance;

//与SGSpeechRecognizer提供的方法功能一致，调用其中一个即可。
+ (void)setServerUrl:(NSString*) serverUrl;

+ (void)setOtherParams:(NSDictionary*) paramsDic;
@end
