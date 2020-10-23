#import "SGSpeechRecognizer.h"

@interface SougouVoice : NSObject<SGSpeechRecognizerDelegate>
+(instancetype)instance;
-(void)initialize;
-(void)startRec;
-(void)stopRec;
-(void)cancelRec;
-(void)uploadSound:(NSData*)data;
-(void)playSound:(NSString*)fileName;
-(void)setRecUploadURL:(NSString*)url;
@end