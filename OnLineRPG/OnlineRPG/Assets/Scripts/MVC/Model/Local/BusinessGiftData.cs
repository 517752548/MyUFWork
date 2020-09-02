using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

public class BusinessGiftData
{
    public RecordExtra.IntPrefData id;
    public List<int> buyitem;
    private int wordWrongtime = 0;
    private int coinleft = 0;
    private int currentWrongnumber = 0;
    private int todaymax = 0;
    private int currentlevelpass = 99;
    private int levelInter = 999;
    private RecordExtra.IntPrefData todayshowTimes;
    public int startLevel = 999;
    public bool inited = false;
    public DateTime cutdownTime;
    public BusShopItem[] shopItem = new BusShopItem[] { };
    public int flashTime = 9999999;

    /// <summary>
    /// 局外弹,0代表不弹，1代表需要弹，2代表弹了
    /// </summary>
    public int needshowpanel = 0;

    /// <summary>
    /// 局内弹
    /// </summary>
    public int needshowshoppanel = 0;


    public void Initilize()
    {
        id = new RecordExtra.IntPrefData("businessid", -1);
        string buyitemstr = Record.GetString("businessgiftbuyitem", "");
        buyitem = JsonConvert.DeserializeObject<List<int>>(buyitemstr);
        todayshowTimes = new RecordExtra.IntPrefData("todayshowTimes", 0);
        if (buyitem == null)
        {
            buyitem = new List<int>();
        }

        if (Record.GetInt("todayofyear", -1) != DateTime.Now.DayOfYear)
        {
            todayshowTimes.Value = 0;
            Record.SetInt("todayofyear", DateTime.Now.DayOfYear);
        }
    }

    public bool AllGiftBuyed()
    {
        for (int i = 0; i < shopItem.Length; i++)
        {
            if (!buyitem.Contains(shopItem[i].giftId))
            {
                return false;
            }
        }

        Debug.Log("全部购买了");
        return true;
    }

    /// <summary>
    /// 玩家购买了礼包
    /// </summary>
    /// <param name="buyit"></param>
    public void BuyItem(int buyit)
    {
        buyitem.Add(buyit);
        if (AllGiftBuyed())
        {
            inited = false;
            //DataManager.businessGiftData.cutdownTime = AppEngine.STimeHeart.RealTime;
        }

        Record.SetString("businessgiftbuyitem", JsonConvert.SerializeObject(buyitem));
    }

    public bool LevelEnough()
    {
        if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value < startLevel)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 玩家划错词
    /// </summary>
    public void WordWrongOrRight(bool wrong)
    {
        if (!inited)
        {
            return;
        }

        if (DataManager.businessGiftData.cutdownTime.Subtract(AppEngine.STimeHeart.RealTime).TotalSeconds < 0)
        {
            return;
        }

        if (wordWrongtime == 0)
        {
            return;
        }

        if (todayshowTimes.Value > todaymax)
        {
            Debug.LogError(todayshowTimes.Value + "礼包 达到最大次数" + todaymax);
            return;
        }

        if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value < startLevel)
        {
            return;
        }

        if (currentlevelpass < levelInter)
        {
            return;
        }

        if (!wrong)
        {
            currentWrongnumber = 0;
        }
        else
        {
            currentWrongnumber++;
            if (currentWrongnumber >= wordWrongtime && AppEngine.SyncManager.Data.Coin.Value <= coinleft)
            {
                TimersManager.SetTimer(1.5f, () => { ShowPanel(); });
                todayshowTimes.Value++;
                currentWrongnumber = 0;
                currentlevelpass = 0;
            }
        }
    }

    private void ShowPanel()
    {
        if (DataManager.businessGiftData.shopItem.Length == 1)
        {
            UIManager.OpenUIAsync(ViewConst.prefab_ShopLimitBagOneDialog);
        }
        else
        {
            UIManager.OpenUIAsync(ViewConst.prefab_ShopLimitBagTwoDialog);
        }
    }


    /// <summary>
    /// 是否需要弹出面板
    /// </summary>
    public bool LevelStart()
    {
        //这里局内开局需求里不需要直接弹
        return false;
        if (!inited)
        {
            Debug.LogError("礼包 未初始化");
            return false;
        }

        if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value < startLevel)
        {
            return false;
        }

        if (DataManager.businessGiftData.cutdownTime.Subtract(AppEngine.STimeHeart.RealTime).TotalSeconds < 0)
        {
            return false;
        }

        if (todayshowTimes.Value > todaymax)
        {
            Debug.LogError(todayshowTimes.Value + "礼包 达到最大次数" + todaymax);
            return false;
        }

        if (currentlevelpass < levelInter)
        {
            Debug.LogError(currentlevelpass + "礼包 间隔不租" + levelInter);
            return false;
        }

        currentlevelpass = 0;
        todayshowTimes.Value++;
        return true;
    }

    /// <summary>
    /// 玩家使用道具时候导致金币不足
    /// </summary>
    public void MoneyNotEnough()
    {
        bool showPanel = true;
        if (!inited)
        {
            Debug.LogError("礼包 未初始化");
            showPanel = false;
        }

        if (DataManager.businessGiftData.cutdownTime.Subtract(AppEngine.STimeHeart.RealTime).TotalSeconds < 0)
        {
            showPanel = false;
        }

        if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value < startLevel)
        {
            showPanel = false;
        }

        if (needshowshoppanel != 1)
        {
            showPanel = false;
        }

        if (todayshowTimes.Value > todaymax)
        {
            Debug.LogError(todayshowTimes.Value + "礼包 达到最大次数" + todaymax);
            showPanel = false;
        }

        if (currentlevelpass < levelInter)
        {
            Debug.LogError(currentlevelpass + "礼包 间隔不租" + levelInter);
            showPanel = false;
        }

        if (showPanel)
        {
            currentlevelpass = 0;
            todayshowTimes.Value++;
            currentWrongnumber = 0;
            Debug.LogError("展示面板");
            ShowPanel();
        }
        else
        {
            UIManager.OpenUIAsync(ViewConst.prefab_StoreDialog);
        }
    }

    /// <summary>
    /// 过关了
    /// </summary>
    public void LevelPass()
    {
        currentlevelpass++;
    }

    public void SetServerData(RepData m_data)
    {
        if (m_data == null)
        {
            inited = false;
            return;
        }

        if (m_data.data == null)
        {
            inited = false;
            return;
        }

        if (m_data.data.id == 0)
        {
            inited = false;
            return;
        }

        if (this.id.Value != m_data.data.id)
        {
            this.id.Value = m_data.data.id;
            buyitem.Clear();
            Record.SetString("businessgiftbuyitem", "");
            todayshowTimes.Value = 0;
            Record.SetInt("todayofyear", DateTime.Now.DayOfYear);
        }

        this.flashTime = m_data.data.flashing;
        this.startLevel = m_data.data.level;
        cutdownTime = AppEngine.STimeHeart.RealTime.AddSeconds(m_data.data.countdown);
        shopItem = m_data.data.giftList;
        if (shopItem == null)
        {
            shopItem = new BusShopItem[] { };
        }

        if (needshowpanel != 2)
        {
            needshowpanel = m_data.data.panel;
        }

        needshowshoppanel = m_data.data.panelShop;

        if (!m_data.data.panelWord.Contains(","))
        {
            wordWrongtime = 0;
        }
        else
        {
            string[] numbers = m_data.data.panelWord.Split(',');
            int wrong = 0;
            if (int.TryParse(numbers[0], out wrong))
            {
                wordWrongtime = wrong;
            }
            else
            {
                wordWrongtime = 0;
            }

            int coin = 0;
            if (int.TryParse(numbers[1], out coin))
            {
                coinleft = coin;
            }
        }

        if (!m_data.data.panelFre.Contains(","))
        {
            todaymax = 0;
        }
        else
        {
            string[] numbers = m_data.data.panelFre.Split(',');
            int level = 0;
            if (int.TryParse(numbers[0], out level))
            {
                levelInter = level;
            }
            else
            {
                levelInter = 999;
            }

            int maxt = 0;
            if (int.TryParse(numbers[1], out maxt))
            {
                todaymax = maxt;
            }
            else
            {
                todaymax = 0;
            }
        }

        inited = true;
        if (AllGiftBuyed())
        {
            inited = false;
        }
    }
}