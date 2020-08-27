using System;

/// <summary>
/// 用户Gener 数据
/// </summary>
public class AdvertisementData : IData
{
    public RecordExtra.DatePrefData dailyWatchINDate;
    public RecordExtra.DatePrefData flashWatchINDate;
    public RecordExtra.DatePrefData mainlineWatchINDate;

    //每天的第一关
    public RecordExtra.IntPrefData mainlineFirstLevelofDay;
    
    public RecordExtra.DatePrefData DayDataStartDate { get; private set; }
    public RecordExtra.IntPrefData VideoTotalShowTimes { get; private set; }
    //public RecordExtra.IntPrefData VideoShowTimesOfDay { get; private set; }
    public RecordExtra.IntPrefData VideoTotalShowFailTimes { get; private set; }
    public RecordExtra.IntPrefData InterstitialTotalShowTimes { get; private set; }
    public RecordExtra.IntPrefData InterstitialShowTimesOfDay { get; private set; }
    
    public void Initilize()
    {

        dailyWatchINDate = new RecordExtra.DatePrefData(PrefKeys.dailyInStamp, DateTime.MinValue);
        flashWatchINDate = new RecordExtra.DatePrefData(PrefKeys.flashInStamp, DateTime.MinValue);
        mainlineWatchINDate = new RecordExtra.DatePrefData(PrefKeys.mainlineInStamp, DateTime.MinValue);

        mainlineFirstLevelofDay = new RecordExtra.IntPrefData(PrefKeys.mainlineFirstLineOfDay, -1);
        
        DayDataStartDate = new RecordExtra.DatePrefData(PrefKeys.DayAdDataStartDate, DateTime.MinValue);
        InterstitialTotalShowTimes = new RecordExtra.IntPrefData(PrefKeys.Interstitial_TotalDisplayTimes, 0);
        InterstitialShowTimesOfDay = new RecordExtra.IntPrefData(PrefKeys.Interstitial_DayDisplayTimes, 0);
        VideoTotalShowTimes = new RecordExtra.IntPrefData(PrefKeys.RewardVideo_TotalShowTimes, 0);
        //VideoShowTimesOfDay = new RecordExtra.IntPrefData(PrefKeys.RewardVideo_ShowTimes, 0);
        VideoTotalShowFailTimes = new RecordExtra.IntPrefData(PrefKeys.RewardVideo_ShowFailTimes, 0);
    }
}