using BetaFramework;
using EventUtil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// 内购相关数据类
/// </summary>
public class PurchaseData : IData
{
    /// <summary>
    /// 数据加载到内存
    /// </summary>
    public void Initilize()
    {
        m_PromotePopupTimesPerDay = Record.GetInt(PrefKeys.PromotionPopupTimesPerDay, 0);
        m_ShowNoAdsSale = Record.GetBool(PrefKeys.ShowNoAdsSale, false);

        if (Record.HasKey(PrefKeys.ShopPendingList))
        {
            m_PendingProductList = JsonConvert.DeserializeObject<List<IapProductConfig_Data>>(Record.GetString(PrefKeys.ShopPendingList));
        }

        if (Record.HasKey(PrefKeys.ShopPendingReceiptList))
        {
            m_PendingReceiptList = JsonConvert.DeserializeObject<List<IapProductConfig_Data>>(
                    Record.GetString(PrefKeys.ShopPendingReceiptList));
        }

        try
        {
            string purchasedItems = "";
            if (Record.HasKey(PrefKeys.PurchasedItem))
            {
                purchasedItems = Record.GetString(PrefKeys.PurchasedItem);
                m_PurchasedItems = JsonConvert.DeserializeObject<Dictionary<string, int>>(purchasedItems);
            }
        }
        catch (Exception ex)
        {
            LoggerHelper.Log(ex);
        }
    }

    /// <summary>
    /// 每天弹出总次数
    /// </summary>
    private int m_PromotePopupTimesPerDay;

    public int PromotePopupTimesPerDay
    {
        get { return m_PromotePopupTimesPerDay; }
        set
        {
            m_PromotePopupTimesPerDay = value;
            Record.SetInt(PrefKeys.PromotionPopupTimesPerDay, value);
        }
    }

    private Dictionary<string, int> m_PurchasedItems;

    public Dictionary<string, int> PurchasedItems
    {
        get
        {
            if (System.Object.ReferenceEquals(m_PurchasedItems, null))
            {
                m_PurchasedItems = new Dictionary<string, int>();
            }

            return m_PurchasedItems;
        }
        set { m_PurchasedItems = value; }
    }

    /// <summary>
    /// 玩家内购成功
    /// </summary>
    public void PurchaserSucceed(string productId)
    {
        if (PurchasedItems.ContainsKey(productId))
        {
            int times = PurchasedItems[productId];
            PurchasedItems[productId] = times + 1;
        }
        else
        {
            PurchasedItems.Add(productId, 1);
        }

        Record.SetString(PrefKeys.PurchasedItem, JsonConvert.SerializeObject(PurchasedItems));
    }

	internal bool IsItemPurchased(string productID)
	{
		if (string.IsNullOrEmpty(productID)) return false;
		if (PurchasedItems.ContainsKey(productID)) {
			return PurchasedItems[productID] >= 1;
		}
		return false;
	}

	/// <summary>
	/// 是否显示sale
	/// </summary>
	private bool m_ShowNoAdsSale;

    public bool ShowNoAdsSale
    {
        get { return m_ShowNoAdsSale; }
        set
        {
            m_ShowNoAdsSale = value;
            Record.SetBool(PrefKeys.ShowNoAdsSale, m_ShowNoAdsSale);
        }
    }

    public IapProductConfig_Data GetIapProduct(string id)
    {
        //CommandChannel commandChannel = CommandChannel.GetInstance();

#if UNITY_ANDROID
        IapProductConfig config = PreLoadManager.GetPreLoadConfig<IapProductConfig>(ViewConst.asset_IapProductConfig_AndroidA);//(IapProductConfig)commandChannel.PostCommand(ExcelCommandConst.GET_EXCEL_DATA, ViewConst.asset_IapProductConfig_IosB);

#else
        IapProductConfig config = PreLoadManager.GetPreLoadConfig<IapProductConfig>(ViewConst.asset_IapProductConfig_IosA);//(IapProductConfig)commandChannel.PostCommand(ExcelCommandConst.GET_EXCEL_DATA, ViewConst.asset_IapProductConfig_IosB);
#endif

        return config.dataList.Find(x => id == x.ProductID);
    }

    private List<IapProductConfig_Data> m_PendingProductList = new List<IapProductConfig_Data>();

    public void AddPendingProduct(IapProductConfig_Data product)
    {
        int index = m_PendingProductList.FindIndex(x => x.ProductID == product.ProductID);
        if (index == -1)
        {
            m_PendingProductList.Add(product);
            Record.SetString(PrefKeys.ShopPendingList, JsonConvert.SerializeObject(m_PendingProductList));
        }
    }

    public bool ContainInPendingProduct(IapProductConfig_Data product) {
        int index = m_PendingProductList.FindIndex(x => x.ProductID == product.ProductID);
        if (index == -1) {
            return false;
        }
        return true;
    }

    public bool RemovePendingProduct(string productId)
    {
        int index = m_PendingProductList.FindIndex(x => x.ProductID == productId);
        if (index == -1)
        {
            return false;
        }

        m_PendingProductList.RemoveAt(index);
        Record.SetString(PrefKeys.ShopPendingList, JsonConvert.SerializeObject(m_PendingProductList));

        return true;
    }
    
    public bool RemoveAllPendingProduct()
    {
        m_PendingProductList.Clear();
        Record.SetString(PrefKeys.ShopPendingList, JsonConvert.SerializeObject(m_PendingProductList));
        return true;
    }

    public IapProductConfig_Data GetPendingProduct(string productId)
    {
        return m_PendingProductList.Find(x => x.ProductID == productId);
    }

    private List<IapProductConfig_Data> m_PendingReceiptList = new List<IapProductConfig_Data>();

    public List<IapProductConfig_Data> PendingReceiptList
    {
        get { return m_PendingReceiptList; }
    }

    public void AddPendingReceiptProduct(IapProductConfig_Data product)
    {
        int index = m_PendingReceiptList.FindIndex(x => x.ProductID == product.ProductID);
        if (index == -1)
        {
            m_PendingReceiptList.Add(product);
            Record.SetString(PrefKeys.ShopPendingReceiptList, JsonConvert.SerializeObject(m_PendingReceiptList));
        }
    }

    public bool RemovePendingReceiptProduct(string productId)
    {
        int index = m_PendingReceiptList.FindIndex(x => x.ProductID == productId);
        if (index == -1)
        {
            return false;
        }

        m_PendingReceiptList.RemoveAt(index);
        Record.SetString(PrefKeys.ShopPendingReceiptList, JsonConvert.SerializeObject(m_PendingReceiptList));

        return true;
    }

    public IapProductConfig_Data GetPendingReceiptProduct(string productId)
    {
        return m_PendingReceiptList.Find(x => x.ProductID == productId);
    }
}