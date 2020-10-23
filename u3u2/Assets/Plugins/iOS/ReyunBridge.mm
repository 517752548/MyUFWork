#import "NewGame.h"

@interface ReyunBridge : NSObject

@end

@implementation ReyunBridge

extern "C"
{
    // 开启数据统计
    void reyunInitWithAppId(const char* appId, const char* channelID)
    {
        [NewGame initWithAppId:[NSString stringWithUTF8String:appId] channelID:[NSString stringWithUTF8String:channelID]];
    }
    
    //注册成功后调用
    void reyunSetRegisterWithAccountID(const char* account, int igender, const char* age, const char* serverId, const char* accountType)
    {
        [NewGame setRegisterWithAccountID:[NSString stringWithUTF8String:account] andGender:(gender)igender andage:[NSString stringWithUTF8String:age] andServerId:[NSString stringWithUTF8String:serverId] andAccountType:[NSString stringWithUTF8String:accountType]];
    }
    
    //登陆成功后调用
    void reyunSetLoginWithAccountID(const char* accountId, int igender, const char* age, const char* serverId, int level)
    {
        [NewGame setLoginWithAccountID:[NSString stringWithUTF8String:accountId] andGender:(gender)igender andage:[NSString stringWithUTF8String:age] andServerId:[NSString stringWithUTF8String:serverId] andlevel:level];
    }
    
    //付费分析,记录玩家充值的金额
    void reyunSetPayment(const char* transactionId, const char* paymentType, const char* currencyType, float currencyAmount, float virtualCoinAmount, const char* iapName, int iapAmount, int level)
    {
        [NewGame setPayment:[NSString stringWithUTF8String:transactionId] paymentType:[NSString stringWithUTF8String:paymentType] currentType:[NSString stringWithUTF8String:currencyType] currencyAmount:currencyAmount virtualCoinAmount:virtualCoinAmount iapName:[NSString stringWithUTF8String:iapName] iapAmount:iapAmount andlevel:level];
    }
    
    //经济系统，虚拟交易发生之后调用
    void reyunSetEconomy(const char* itemName, int itemAmount, float itemTotalPrice, int level)
    {
        [NewGame setEconomy:[NSString stringWithUTF8String:itemName] andEconomyNumber:itemAmount andEconomyTotalPrice:itemTotalPrice andlevel:level];
    }
    
    //任务分析，用户接受任务或完成任务时调用
    void reyunSetQuest(const char* questId, int iquestStatus, const char* questType)
    {
        [NewGame setQuest:[NSString stringWithUTF8String:questId] andTaskState:(questStatus)iquestStatus andTaskType:[NSString stringWithUTF8String:questType]];
    }
    
    //自定义事件分析
    void reyunSetEvent(const char* eventName, const char* skey, const char* svalue)
    {
        NSDictionary* dict = [NSDictionary dictionaryWithObject:[NSString stringWithUTF8String:svalue] forKey:[NSString stringWithUTF8String:skey]];
        [NewGame setEvent:[NSString stringWithUTF8String:eventName] andExtra:dict];
    }
    
    //版本信息与平台信息
    void reyunSetSdkNameAndVer(const char* sdkName, const char* sdkVer)
    {
        [NewGame setSdkNameAndVer:[NSString stringWithUTF8String:sdkName] sdkVer:[NSString stringWithUTF8String:sdkVer]];
    }
    
    void reyunGetDeviceId(const char** deviceId)
    {
        *deviceId = [[NewGame getDeviceId] UTF8String];
    }
}
@end