using EventUtil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;

public class BusinessData
{
    public void Initilize()
    {
        playTag = Record.GetString(PrefKeys.Player_PlayerTag, Const.DefaultTag);
        m_FirstTag = Record.GetString(PrefKeys.PlayerFirstTag, Const.DefaultTag);

        if (Record.HasKey(PrefKeys.PlayerTheLastPayTime))
        {
            m_PreviousPayMoneyTime = XUtils.ConvertTime(Record.GetString(PrefKeys.PlayerTheLastPayTime), DateTime.Now);
        }
        else
        {
            PreviousPayMoneyTime = DateTime.Now;
        }

        playerDistanceInTwoPay = Record.GetInt(PrefKeys.PlayerDistanceInTwoPay, 0);
    }

    private int playerClickItemTimes;

    private string playTag = "campaign";

    public string PlayerTag
    {
        get
        {
            return playTag;
        }
        set
        {
            playTag = value;
            Record.SetString(PrefKeys.Player_PlayerTag, playTag.ToString());
            Record.SaveCacheKey();
            if (!System.Object.ReferenceEquals(_PlayerTagChanged, null))
            {
                _PlayerTagChanged(playTag);
            }
        }
    }

    private string m_FirstTag;

    public string FirstTag
    {
        get { return m_FirstTag; }
        set
        {
            m_FirstTag = value;
            Record.SetString(PrefKeys.PlayerFirstTag, value);
        }
    }

    private static event Action<string> _PlayerTagChanged;

    public static event Action<string> PlayerTagChangedEvent
    {
        add
        {
            if (System.Object.ReferenceEquals(_PlayerTagChanged, null) || !_PlayerTagChanged.GetInvocationList().Contains(value))
            {
                _PlayerTagChanged += value;
            }
        }

        remove
        {
            if (!System.Object.ReferenceEquals(_PlayerTagChanged, null) && _PlayerTagChanged.GetInvocationList().Contains(value))
            {
                _PlayerTagChanged -= value;
            }
        }
    }

    private float PlayerCostMoney
    {
        get
        {
            float num = Record.GetFloat("PlayerCostMoney");

            float count = 0;
            foreach (var key in DataManager.ShopData.PurchasedItems.Keys)
            {
                count += GetPrice(key) * DataManager.ShopData.PurchasedItems[key];
            }

            if (num - count > 0.1f)
            {
                BetaFramework.LoggerHelper.Log("PlayerCostMoneyErrorReport" + num + "_" + count);
            }
            else
            {
                if (num < count)
                    Record.SetFloat("PlayerCostMoney", count);
            }

            return count;
        }
        set
        {
            Record.SetFloat("PlayerCostMoney", value);
        }
    }

    //玩家花钱总数
    public float PlayerCostAllMoneyNums
    {
        get
        {
            return PlayerCostMoney;
        }
    }

    #region

    public float GetPrice(string id)
    {
        float price = 0;
        var listProduct = DataManager.ShopData.GetIapProduct(id);

        if (System.Object.ReferenceEquals(listProduct, null))
        {
            BetaFramework.LoggerHelper.Error("GetPrice IapItems NUll");
            return 0;
        }

        bool ok = float.TryParse(listProduct.ProductDollarPrice, out price);
        if (!ok)
        {
            BetaFramework.LoggerHelper.Error("GetPrice IapItems productPrice Not Right");
        }
        return price;
    }

    public string GetStringPrice(string id)
    {
        float price = 0;
        var listProduct = DataManager.ShopData.GetIapProduct(id);

        if (System.Object.ReferenceEquals(listProduct, null))
        {
            BetaFramework.LoggerHelper.Error("GetPrice IapItems NUll");
            return "0";
        }

        bool ok = float.TryParse(listProduct.ProductDollarPrice, out price);
        if (!ok)
        {
            return "0";
        }
        return listProduct.ProductDollarPrice;
    }

    #endregion

    //上一次的付费时间
    private DateTime m_PreviousPayMoneyTime;

    public DateTime PreviousPayMoneyTime
    {
        get
        {
            return m_PreviousPayMoneyTime;
        }
        set
        {
            m_PreviousPayMoneyTime = value;
            Record.SetString(PrefKeys.PlayerTheLastPayTime, m_PreviousPayMoneyTime.ToString());
        }
    }

    //用户的两次付费间隔
    private int playerDistanceInTwoPay;

    public int PlayerDistanceInTwoPay
    {
        get
        {
            return playerDistanceInTwoPay;
        }
        set
        {
            playerDistanceInTwoPay = value;
            Record.SetInt(PrefKeys.PlayerDistanceInTwoPay, playerDistanceInTwoPay);
        }
    }

    public void SubPlayerPayDistance()
    {
        PlayerDistanceInTwoPay = (DateTime.Now - PreviousPayMoneyTime).Days;
        PreviousPayMoneyTime = DateTime.Now;
    }

    public string HintRatio
    {
        get { return "1"; }
    }
}

public enum PlayerTagEnum
{
    user_free,//免费用户
    campaign,//其他用户
    highiap,//高可能付费用户
    superhighiap,//超高可能付费用户
    lowcampaign,//低可能付费用户
}