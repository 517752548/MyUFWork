using BetaFramework;
using Newtonsoft.Json;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class DataManager
{
    public static void Init()
    {
        if (ReferenceEquals(m_PlayerData, null)) {
			m_PlayerData = new PlayerData();
			m_PlayerData.Initilize();
		}
	}

	public static void Clear()
    {
		m_PlayerData = null;
        m_DeviceData = null;
        m_RepAdsData = null;
        m_RepGiftData = null;
        m_UserGenAdData = null;
    }

	/// <summary>
	/// 用户信息类
	/// </summary>
	private static PlayerData m_PlayerData;

	public static PlayerData PlayerData {
		get {
			if (ReferenceEquals(m_PlayerData, null)) {
				m_PlayerData = new PlayerData();
				m_PlayerData.Initilize();
			}
			return m_PlayerData;
		}
	}
    
    
    

    private static AdvertisementData m_UserGenAdData;

    public static AdvertisementData UserGenAdData
    {
        get
        {
            if (ReferenceEquals(m_UserGenAdData, null))
            {
                m_UserGenAdData = new AdvertisementData();
                m_UserGenAdData.Initilize();
            }
            return m_UserGenAdData;
        }
    }

    private static FastRaceData m_FastRaceData;

    public static FastRaceData FastRaceData
    {
        get
        {
            if (ReferenceEquals(m_FastRaceData, null))
            {
                m_FastRaceData = new FastRaceData();
                m_FastRaceData.Initilize();
            }
            return m_FastRaceData;
        }
    }

    /// <summary>
    /// 游戏过程中产生的数据
    /// </summary>
    private static ProcessData m_processdata;

    public static ProcessData ProcessData
    {
        get
        {
            if (ReferenceEquals(m_processdata, null))
            {
                m_processdata = new ProcessData();
                m_processdata.Initilize();
            }
            return m_processdata;
        }
    }


    private static void OnApplicationFocus(bool focus)
    {
        Record.SaveCacheKey();
    }

    private static void OnApplicationQuit()
    {
        Record.SaveCacheKey();
    }
    
    

    private static DeviceData m_DeviceData;

    public static DeviceData DeviceData
    {
        get
        {
            if (m_DeviceData == null)
            {
                m_DeviceData = new DeviceData();
                m_DeviceData.Initilize();
            }
            return m_DeviceData;
        }
    }

    private static RepAdsData m_RepAdsData;

    public static RepAdsData AdsData
    {
        get
        {
            if (m_RepAdsData == null)
            {
                m_RepAdsData = new RepAdsData();
                var group = AppEngine.SSystemManager.GetSystem<TestABSystem>().GetUserTestLib();
                AdsConfig config = AppEngine.SSystemManager.GetSystem<TestABSystem>().GetADConfig();
                var data = config.dataList[0];
                m_RepAdsData.ConvertToThis(data);
            }
            if (!PlatformUtil.GetAppIsRelease())
            {
                m_RepAdsData.RV_CD = 30;
            }
            return m_RepAdsData;
        }
        set
        {
            m_RepAdsData = value;
        }
    }

    public static bool HasAdsData;

    private static RepGiftData m_RepGiftData;

    public static RepGiftData GiftData
    {
        get
        {
            return m_RepGiftData;
        }
        set
        {
            m_RepGiftData = value;
        }
    }
    


    private static RepDailySignGiftData m_RepDailySignGiftData;

    public static RepDailySignGiftData DailySignGiftData
    {
        get
        {
            return m_RepDailySignGiftData;
        }
        set
        {
            m_RepDailySignGiftData = value;
        }
    }

}