using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using BetaFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerInfoSystem : ISystem
{
    /// <summary>
    /// 第一次登陆的时间
    /// </summary>
    public RecordExtra.StringPrefData FirstLoginTime;
    /// <summary>
    /// 最后一次登陆的时间
    /// </summary>
    public RecordExtra.StringPrefData LastLoginTime;
    
    /// <summary>
    /// 用户最后一次付费时间
    /// </summary>
    public RecordExtra.StringPrefData LastPayTime;
    /// <summary>
    /// 用户支付的美分数
    /// </summary>
    public RecordExtra.IntPrefData PlayerPay;
    /// <summary>
    /// 用户付费各种计费点的次数
    /// </summary>
    public RecordExtra.StringPrefData PlayerPayInfo;
    public Dictionary<string,int> playerPayDict = new Dictionary<string, int>();

    /// <summary>
    /// 用户的fb名字
    /// </summary>
    public RecordExtra.StringPrefData PlsyerFBName;

    /// <summary>
    /// 用户的fb email
    /// </summary>
    public RecordExtra.StringPrefData PlsyerFBEmail;
    /// <summary>
    /// 用户的fb ID
    /// </summary>
    public RecordExtra.StringPrefData PlsyerFBID;
    
    public RecordExtra.StringPrefData PlsyerFBImageUrl;

    public RecordExtra.BoolPrefData FBLogined;

    
    
    
    private string WordNewPlayer = "WordNewPlayer";
    private string LastDayLogin = "PlayerLastLogin";
    private byte[] bytes;
    private RecordExtra.IntPrefData headImageIndex;
    private RecordExtra.StringPrefData randomName;
    public override void InitSystem()
    {
        FirstLoginTime = new RecordExtra.StringPrefData("FirstLoginTime",DateTime.Now.ToString());
        LastLoginTime = new RecordExtra.StringPrefData("LastLoginTime",DateTime.Now.ToString());
        PlayerPayInfo = new RecordExtra.StringPrefData("PlayerPayInfo","");
        PlsyerFBImageUrl = new RecordExtra.StringPrefData("PlsyerFBImageUrl","");
        PlsyerFBName = new RecordExtra.StringPrefData("PlsyerFBName","Annventurer");
        PlsyerFBEmail = new RecordExtra.StringPrefData("PlsyerFBEmail","");
        PlsyerFBID = new RecordExtra.StringPrefData("PlsyerFBID","");
        PlayerPay = new RecordExtra.IntPrefData("PlayerPay",0);
        FBLogined = new RecordExtra.BoolPrefData("FBLogined",false);
        LastPayTime = new RecordExtra.StringPrefData("LastPayTime",DateTime.Now.ToString());
        LastPayTime = new RecordExtra.StringPrefData("LastPayTime",DateTime.Now.ToString());
        headImageIndex = new RecordExtra.IntPrefData("headImageIndex",-1);
        randomName = new RecordExtra.StringPrefData("randomName","");
        if (playerPayDict == null)
        {
            playerPayDict = new Dictionary<string, int>();
        }
        CheckPlayerLogin();
        CheckNewPlayer();
        CheckPlayerName();
        base.InitSystem();
        if (string.IsNullOrEmpty(randomName.Value))
        {
            AppEngine.SResourceManager.LoadAssetAsync<NameConfig>(
                ViewConst.asset_NameConfig_girls,
                ok =>
                {
                    randomName.Value = ok.GetRandomName();
                });
        }
        else
        {
            
        }
         // JObject rss =
         //     new JObject(
         //     );
         // NameConfig config = PreLoadManager.GetPreLoadConfig<NameConfig>(ViewConst.asset_NameConfig_boys);
         // for (int i = 0; i < config.dataList.Count; i++)
         // {
         //     rss.Add(i.ToString(),config.dataList[i].Name);
         // }
         // Debug.LogError(rss.ToString());
    }

    private void CheckPlayerName()
    {
        if (headImageIndex.Value == -1)
        {
            headImageIndex.Value = Random.Range(1, 21);
        }
    }

    /// <summary>
    /// 获取用户的头像url   优先使用fb的
    /// </summary>
    /// <returns></returns>
    public string GetPlayerName()
    {
        if (PlsyerFBName.Value == "Annventurer")
        {
            return randomName.Value;
        }

        return PlsyerFBName.Value.ToString();
    }
    
    

    /// <summary>
    /// 获取用户名字，优先使用fb的
    /// </summary>
    /// <returns></returns>
    public string GetPlayerHeadUrl()
    {
        if (!string.IsNullOrEmpty(PlsyerFBImageUrl.Value))
        {
            return PlsyerFBImageUrl.Value;
        }

        return "head_" + headImageIndex.Value;
    }
    /// <summary>
    /// 用户购买成功了
    /// </summary>
    public void PlayBuy(string itemid,int cent)
    {
        if (playerPayDict.ContainsKey(itemid))
        {
            playerPayDict[itemid]++;
        }
        else
        {
            playerPayDict.Add(itemid,1);
        }

        LastPayTime.Value = DateTime.Now.ToString();
        PlayerPay.Value += cent;
        PlayerPayInfo.Value = JsonConvert.SerializeObject(playerPayDict);
    }

    /// <summary>
    /// 获取用户的fb头像
    /// </summary>
    /// <returns></returns>
    public Sprite GetPlayerFBPic()
    {
        byte[] bytesCache = Record.LoadFileByBytes(PrefKeys.FaceBookImageCache);
        if (bytes != null)
        {
            bytesCache = bytes;
        }
        if (bytesCache != null && bytesCache.Length > 0) {
            Texture2D d = new Texture2D(120, 120);
            d.LoadImage(bytesCache);
            if (d != null) {
                Sprite fbsprite = Sprite.Create(d, new Rect(0, 0, d.width, d.height),
                    new Vector2(0.5f, 0.5f));
                return fbsprite;
            }
        }

        return null;
    }

    public void LoginOutFB()
    {
        bytes = null;
        PlsyerFBName.Value = "Annventurer";
        PlsyerFBID.Value = "";
    }
    
    public void ChangeFBPic(byte[] bytes)
    {
        this.bytes = bytes;
        Record.SaveStringInFileAnsy(bytes, PrefKeys.FaceBookImageCache);
    }
    private void CheckNewPlayer()
    {
        if (Record.GetBool(WordNewPlayer,true))
        {
            Record.SetBool(WordNewPlayer,false);
            NewPlayer();
        }
    }

    private void NewPlayer()
    {
        FirstLoginTime.Value = AppEngine.STimeHeart.RealTime.ToString();
    }
    
    private void CheckPlayerLogin()
    {
        string lastLogin = Record.GetString(LastDayLogin, "-1");
        if (lastLogin != AppEngine.STimeHeart.RealTime.ToString())
        {
            Record.SetString(LastDayLogin, AppEngine.STimeHeart.RealTime.ToString());
            ResetNewDay();
        }
    }

    /// <summary>
    /// 新的一天开始
    /// </summary>
    private void ResetNewDay()
    {
        LastLoginTime.Value = AppEngine.STimeHeart.RealTime.ToString();
    }

    public int GetPlayerInstallDays()
    {
       return DateTime.Now.Subtract(DateTime.Parse(FirstLoginTime.Value)).Days;
    }

    public int GetPayDays()
    {
        return DateTime.Now.Subtract(DateTime.Parse(LastPayTime.Value)).Days;
    }

    public int GetTotalPayTimes()
    {
        int times = 0;
        foreach (string key in playerPayDict.Keys)
        {
            times += playerPayDict[key];
        }

        return times;
    }

}
