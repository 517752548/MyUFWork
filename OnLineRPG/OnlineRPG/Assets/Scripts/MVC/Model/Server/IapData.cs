using System.Collections.Generic;
using System.Text.RegularExpressions;
using BetaFramework;
using UnityEngine.Purchasing;

public enum IapType
{
    /// <summary>
    /// 普通内购项
    /// </summary>
    Normal = 0,

    /// <summary>
    /// 新手礼包
    /// </summary>
    NoviceGift = 1,

    /// <summary>   促销礼包. </summary>
    SaleGift = 2,

    /// <summary>   常驻礼包. </summary>
    NormalGift = 3,
    NormalBeeGift = 4
}

public class PayType
{
    public const string NormalType = "normal";
    public const string ResidentType = "resident";
    public const string RemoveadsType = "removeads";
    public const string ShopgreenhandType = "shopgreenhand";
    public const string ShopLimitsaleType = "shoplimitsale";
    public const string DialogGreenhandType = "dialoggreenhand";
    public const string DialoglimitsaleType = "dialoglimitsale";
    public const string RestoreType = "restore";
}

public class IapData
{
    public IapProductConfig_Data GetNoviceProductData()
    {
        var listProduct = GetIapProductConfig();
        foreach (var data in listProduct)
        {
            if ((IapType)(data.IapType) == IapType.NoviceGift)
            {
                return data;
            }
        }

        return null;
    }

    public IapProductConfig_Data GetProductDataById(string productId)
    {
        var listProduct = GetIapProductConfig(true);
        return listProduct.Find(x => x.ProductID == productId);
    }

    public string GetOriginPrice(IapProductConfig_Data data)
    {
        string result = null;
        string productP = data.ProductLocalizedPrice;
        if (string.IsNullOrEmpty(productP))
        {
            productP = data.ProductDollarPrice;
        }
        string priceCurrency = Regex.Replace(productP, "\\d+\\.?\\d*", "");

        Match match = Regex.Match(productP, "\\d+\\.?\\d*");
        if (match.Success && !ReferenceEquals(data.PercentMore, null))
        {
            float percent = float.Parse(data.PercentMore);
            result = priceCurrency + string.Format("{0:N1}9", float.Parse(match.ToString()) * (1 + percent * 0.01f));
        }
        return result;
    }

    public List<IapProductConfig_Data> GetProductsByType(IapType iapType)
    {
        var data = new List<IapProductConfig_Data>();
        var listProduct = GetIapProductConfig();
        foreach (var product in listProduct)
        {
            if ((IapType)product.IapType == iapType)
                data.Add(product);
        }

        return data;
    }

    public IapProductConfig_Data GetNoAdsProduct()
    {
        var listProduct = GetIapProductConfig();
        foreach (var product in listProduct)
        {
            if ((IapType)product.IapType == IapType.Normal
                && (ProductType)product.ProductType == ProductType.NonConsumable)
                return product;
        }

        return null;
    }

    public List<IapProductConfig_Data> GetNormalProducts()
    {
        var data = new List<IapProductConfig_Data>();
        var listProduct = GetIapProductConfig();
        foreach (var product in listProduct)
        {
            if ((IapType)product.IapType == IapType.Normal
                && (ProductType)product.ProductType == ProductType.Consumable)
                data.Add(product);
        }

        return data;
    }

    public float GetLocalizedPrice(string localizedPrice)
    {
        Match match = Regex.Match(localizedPrice, "\\d+\\.?\\d*");
        return float.Parse(match.ToString());
    }

    public List<IapProductConfig_Data> GetIapProductConfig(bool all = false)
    {
        //CommandChannel commandChannel = CommandChannel.GetInstance();
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
#if UNITY_ANDROID
        IapProductConfig config = PreLoadManager.GetPreLoad<IapProductConfig>(PreLoadConst.preload_Asset, ViewConst.asset_IapProductConfig_AndroidA);

#else
		IapProductConfig config = PreLoadManager.GetPreLoad<IapProductConfig>(PreLoadConst.preload_Asset, ViewConst.asset_IapProductConfig_IosA);
#endif
        if (all)
        {
            return config.dataList;
        }
        return config.GetIapConfig();
    }

}