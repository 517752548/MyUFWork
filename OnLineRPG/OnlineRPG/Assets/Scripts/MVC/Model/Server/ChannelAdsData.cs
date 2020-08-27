using System;
using System.Collections.Generic;

public class ChannelAdsList
{
    public string IapCampaign;//内购广告组标识，若这个标识包含任何分组标识信息，则这个分组既是广告分组
    public string DefaultCampaign;//默认广告分组，所有失败的情况走此广告分组
    public string NonOrganicName;//非自然量标识
    public string OrganicName;//自然量标识
    public string OrganicGroupArray;//自然量默认广告分组id数组，格式：{XXX, YYY, ZZZ}

    public List<ChannelAdsData> listChannelAdsData = new List<ChannelAdsData>();

    public ChannelAdsData GetChannelAdsByChannelId(string campaign)
    {
        ChannelAdsData adsData = listChannelAdsData.Find(x => campaign.ToLower().Contains(x.channelKey.ToLower()));
        if (ReferenceEquals(adsData, null))
        {
            adsData = listChannelAdsData.Find(x => DefaultCampaign.ToLower().Contains(x.channelKey.ToLower()));
        }

        return adsData;
    }

    public List<string> GetAllChannelKey()
    {
        List<string> resultList = new List<string>();
        for (int i = 0; i < listChannelAdsData.Count; i++)
        {
            resultList.Add(listChannelAdsData[i].channelKey);
        }
        return resultList;
    }

    public ChannelAdsData GetChannelAdsById(int id)
    {
        return listChannelAdsData.Find(x => id == Convert.ToInt32(x.id));
    }

    public ChannelAdsData GetChannelDefaultAds()
    {
        return listChannelAdsData.Find(x => DefaultCampaign.ToLower().Contains(x.channelKey.ToLower()));
    }
}

public class ChannelAdsData
{
    public string id;
    public string channelKey;
    public string BannerBeginLevel;
    public string GameVideoOpenOrClose;
    public ChannelInterstitialData interstitialData;
    public ChannelRewardVideoData rewardVideoData;
}

public class ChannelInterstitialData
{
    public string ShopOpenTimes;
    public string BeginLevel;
    public string ShowTimes;
    public string CompelteWaitTime;
}

public class ChannelRewardVideoData
{
    public string BeginLevel;
    public string GameVideoBeginLevel;
    public string CycleHours;
    public string MaxCounts;
    public string GameRewardVideoWaitTime;
    public string WinRewardVideoWaitTime;
    public string ExtraRewardVideoWaitTime;
    public string ShopRewardVideoWaitTime;
}