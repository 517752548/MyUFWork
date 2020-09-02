using BetaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ValidateReceiptCommand : ICommand
{
    public object Data { get; set; }

    private ReqReceiptData m_ReqReceiptData;
    private HandleReceiptMsg m_HandleReceiptMsg;

    public void Initilize()
    {
        m_ReqReceiptData = new ReqReceiptData
        {
            DeviceId = DataManager.DeviceData.DeviceId,
            Version = GameSetting.BuildVersion,
#if UNITY_ANDROID
            Platform = "android",
#elif UNITY_IOS
            Platform = "ios"
#endif
        };

#if UNITY_EDITOR
        m_ReqReceiptData.DeviceId = "TestFBUser003";
#endif

        m_HandleReceiptMsg = new HandleReceiptMsg()
        {
            OpCode = (short)OpCodes.ValidateReceipt
        };
        AppEngine.SNetworkManager.SetHandler(m_HandleReceiptMsg);
    }

    public void Execute()
    {
        try
        {
            var data = Data as IapProductConfig_Data;
            if (data == null)
                return;

            var iapType = (IapType)data.IapType;
            switch (iapType)
            {
                case IapType.Normal:
                    m_ReqReceiptData.GiftId = 0;
                    m_ReqReceiptData.IapType = (int)IapType.Normal;
                    break;

                case IapType.NoviceGift:
                    //此次购买是新手礼包
                    m_ReqReceiptData.GiftId = 0;
                    m_ReqReceiptData.IapType = (int)IapType.NoviceGift;
//                    DataManager.CacheGiftData.GiftId = 0;
//                    DataManager.CacheGiftData.Time = data.RemainTime;

                    break;

                case IapType.SaleGift:
                    //此次购买是限时礼包
                    m_ReqReceiptData.GiftId = data.GiftId;
                    m_ReqReceiptData.IapType = (int)IapType.SaleGift;
//                    DataManager.CacheGiftData.GiftId = data.GiftId;
//                    DataManager.CacheGiftData.Time = data.RemainTime;

                    break;

                case IapType.NormalGift:
                    m_ReqReceiptData.GiftId = 0;
                    m_ReqReceiptData.IapType = (int)IapType.NormalGift;

                    break;
            }

            m_ReqReceiptData.PurchaseId = data.ProductID;
            m_ReqReceiptData.Cost = float.Parse(data.ProductDollarPrice);

            var unifiedReceipt = JsonUtility.FromJson<UnifiedReceipt>(data.Receipt);
            if (unifiedReceipt != null && !string.IsNullOrEmpty(unifiedReceipt.Payload))
            {
#if UNITY_ANDROID
                var purchaseReceipt = JsonUtility.FromJson<UnityChannelPurchaseReceipt>(unifiedReceipt.Payload);
                m_ReqReceiptData.Receipt = purchaseReceipt.json;
                m_ReqReceiptData.OrderId = purchaseReceipt.transactionId;
                m_ReqReceiptData.Signature = purchaseReceipt.signature;
#elif UNITY_IOS
                m_ReqReceiptData.Receipt = unifiedReceipt.Payload;
                m_ReqReceiptData.OrderId = unifiedReceipt.TransactionID;
                m_ReqReceiptData.Signature = "";
#endif
            }

            AppEngine.SNetworkManager.SetUrl(URLSetting.SERVER_VALIDATERECEIPT_URL);
            AppEngine.SNetworkManager.SendMessage((short)OpCodes.ValidateReceipt, m_ReqReceiptData);
        }
        catch (Exception ex)
        {
            LoggerHelper.Exception(ex);
        }
    }

    public void Release()
    {
        AppEngine.SNetworkManager.RemoveHandler(m_HandleReceiptMsg);
    }
}