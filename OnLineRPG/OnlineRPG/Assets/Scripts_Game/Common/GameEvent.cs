public enum GameEvent
{
    //重启游戏
    AppRestart,

    //内购打点事件
    AnalysisIapEvent,

    //购买金币和道具事件
    CurrencyIapEvent,

    CustomIapEvent,

    FacebookIapEvent,
    AppsflyerIapEvent,
    AdjustIapEvent,
    FabricIapEvent,
    FirebaseIapEvent,
    FlurryIapEvent,
    FTDIapEvent,

    //内购校验
    ValidateReceipt,

    //礼包是否弹出事件
    SalePopup,
    
    //飞金币
    RubyFly,

    //隔天重置的
    ResetPerDay,
    
    //
    LocalNotification,


    //开始AB test
    ABTesting,


    //注册接口
    Login,
}