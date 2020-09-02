using BetaFramework;
using EventUtil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

internal class CustomIapCommand : ICommand
{
    public object Data { get; set; }

    public void Execute()
    {
        IapProductConfig_Data productData = (IapProductConfig_Data)Data;

        try
        {
            int hint1 = productData.ProductHint1;
            int hint2 = productData.ProductHint2;
            int hint3 = productData.ProductHint3;
            int productCoins = productData.ProductCoins;
            string productDollarPrice = productData.ProductDollarPrice;
            string productId = productData.ProductID;
            string iapType = productData.PayType.ToString();
            string receipt = productData.Receipt;
            string transactionID = productData.TransactionID;

            Dictionary<string, string> orderInformation = new Dictionary<string, string>();
            var unifiedReceipt = JsonUtility.FromJson<UnifiedReceipt>(receipt);
            if (unifiedReceipt != null && !string.IsNullOrEmpty(unifiedReceipt.Payload))
            {
#if UNITY_ANDROID
                var purchaseReceipt = JsonUtility.FromJson<UnityChannelPurchaseReceipt>(unifiedReceipt.Payload);
                orderInformation.Add("receipt", purchaseReceipt.json);
                orderInformation.Add("signature", purchaseReceipt.signature);
#elif UNITY_IOS
                receipt = unifiedReceipt.Payload;
                orderInformation.Add("receipt", receipt);
#endif
            }

            DataManager.BusinessData.SubPlayerPayDistance();//计算两次付费间隔

//            DataManager.PropStatisticsData.AddReward(PropStatisticsData.RewardLocation.buy, hint1, hint2, hint3, productCoins, false, 0, 0, productId, productDollarPrice, iapType);

            //BI和BQ数据点
//            BQAnalyReport.PostUserBuyNew(productData, productId, productCoins, iapType, transactionID, JsonConvert.SerializeObject(orderInformation));
//            BQAnalyse.PostPurchaseData(productId, DataManager.LevelData.CurrentAbsUnlockLevel.ToString());
        }
        catch (Exception ex)
        {
            LoggerHelper.Exception(ex);
        }
    }

    public void Initilize()
    {
    }

    public void Release()
    {
    }
}