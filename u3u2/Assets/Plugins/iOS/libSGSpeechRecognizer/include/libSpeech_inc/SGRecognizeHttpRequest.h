//
//  SGHttpRequest.h
//  SpeechRecognizer_inc
//
//  Created by Sogou on 14-1-13.
//  Copyright (c) 2014年 Sogou. All rights reserved.
//


#import <Foundation/Foundation.h>

@interface SGRecognizeHttpRequest : NSOperation

//输入
@property (nonatomic, retain) NSString *startTime;
@property int recordType;
@property (nonatomic, retain) NSData *voiceData;
@property int sequenceNo;
@property int version;
@property int typeNo;
@property int area;
@property BOOL isContinue;

//输出
@property (nonatomic, retain) NSString *responseStr;
@property (nonatomic, retain) NSError *responseError;
@property (nonatomic, retain) NSString *responseMsg;
@property (nonatomic, retain) NSString *responseContent;
@property int  responseStatus;
@property BOOL isMany;
@property (nonatomic, retain) NSDictionary *jsonDic;
@property (nonatomic, retain) NSMutableArray *recognizeResults;
@property (nonatomic, retain) NSMutableArray *confidenceResults;

- (id)initWithStartTime:(NSString *)time voiceData:(NSData *)data sequenceNo:(int)no isContinue:(BOOL)isContinue version:(int)version typeNo:(int)typeNo area:(int)area;

+ (NSURLRequest *)genRequestWithUrlStr:(NSString *)url startTime:(NSString *)startTime sequenceNo:(int)no voiceData:(NSData *)data requestTime:(int)rt version:(int)verison typeNo:(int)typeNo isContinue:(BOOL)isContinue area:(int)area;

-(void)setParam:(NSDictionary*)paramDic;

@end
