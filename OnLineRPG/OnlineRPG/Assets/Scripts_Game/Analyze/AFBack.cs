using BetaFramework;
using EventUtil;
using Newtonsoft.Json;
using UnityEngine;

public class AFBack : FtOnattributeChangedListener
{
    public void onAttributionChanged(string jsonAttr)
    {
        AFConfig afConfig = JsonConvert.DeserializeObject<AFConfig>(jsonAttr);
        Debug.Log("AF回调:" + jsonAttr);
        if (afConfig != null && afConfig.attribution != null)
        {
            
            Record.SetString("AFInfo", jsonAttr);
            int level = Record.GetInt(PrefKeys.ClassicGameLevelIndex, 1);
            if (level <= 2)
            {
                if (afConfig.attribution.campaign.Contains("pch")  || afConfig.attribution.campaign.Contains("PCH"))
                {
                    Record.SetInt("AFBack", 1);
                }
                else
                {
                    Record.SetInt("AFBack", 2);
                }
            }
            else
            {
                Record.SetInt("AFBack", 2);
            }
            EventDispatcher.TriggerEvent(GlobalEvents.AFBack);
            GameAnalyze.LogAFBackInfo(afConfig.channel,afConfig.attribution.campaign,afConfig.attribution.campaign_id,afConfig.attribution.adgroup,afConfig.attribution.adgroup_id,afConfig.attribution.media_source,afConfig.attribution.af_channel);
        }
    }
}

public class AFConfig
{
    public string channel;
    public string deviceid;
    public AFAttri attribution;

    public AFConfig()
    {
        channel = "";
        deviceid = "";
        attribution = new AFAttri();
    }
}

public class AFAttri
{
    public string af_status;
    public string af_message;
    public bool is_first_launch;
    public bool is_fb;
    public string media_source;
    public string agency;
    public string campaign;
    public string campaign_id;
    public string adgroup;
    public string adgroup_id;
    public string adset;
    public string adset_id;
    public string ad_id;
    public string af_channel;
    public string af_siteid;
    public string af_sub5;
    public string af_sub4;
    public string af_sub1;
    public string af_sub3;
    public string af_sub2;
    public string install_time;
    public string click_time;

    public AFAttri()
    {
        campaign = "";
        media_source = "";
        campaign_id = "";
        adgroup = "";
        adgroup_id = "";
        af_channel = "";
    }
}