// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the Excel Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using BetaFramework;

public class ShopDataConfig : TableSOBaseData<string>
{
    //分层名称
    public string BusinessKey;

    //内购索引
    public int ID;

    //内购框弹出顺序
    public string IapPopupOrder;

    //面板每天弹出次数,3次
    public int SpecialOfferPopupMaxTime;

    //第一次弹出的关卡数
    public int SpecialOfferPopupBeginLevel;

    //每天完成两关，点击next看完广告，新进入第3关时
    public int SpecialOfferPopupDailyLevel;

    //每过10关（记录存档）
    public int SpecialOfferPopupCompleteLevel;

    //每第3天进游戏时
    public int SpecialOfferPopupGapDay;

    //连续猜错30次（错误的次数记录存档，如果对一次则存档清0）
    public int SpecialOfferPopupWrongTime;

    //弹5次没有发生购买
    public int SpecialOfferChangeAfterDays;

    //限时礼包存在时间：48
    public int LimitedOfferExistTime;

    //两个限时礼包最短间隔时间：72小时
    public int LimitedOfferGapTime;

    //默认显示促销id
    public string DefaultLimitedOffer;
}