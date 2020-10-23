//
//  Log.mm
//  Unity-iPhone
//
//  Created by 张哲 on 15/12/30.
//
//

@interface Log : NSObject

@end

@implementation Log

extern "C"
{
    void printLog(const char* str)
    {
        NSLog(@"Unity->%s\n", str);
    }
    
    void printLogWarning(const char* str)
    {
        NSLog(@"Unity Warning->%s\n", str);
    }
    
    void printLogError(const char* str)
    {
        NSLog(@"Unity Error->%s\n", str);
    }
}

@end