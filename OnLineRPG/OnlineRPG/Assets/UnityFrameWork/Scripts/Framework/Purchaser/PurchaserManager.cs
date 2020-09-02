using EventUtil;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Bag;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;

namespace BetaFramework
{
    public class PurchaserManager : IModule, IStoreListener
    {
        private static IStoreController m_StoreController;
        private static IExtensionProvider m_StoreExtensionProvider;
        private static IAppleExtensions m_AppleExtensions;

        private CrossPlatformValidator m_Validator;

        private List<IapProductConfig_Data> m_ListProduct;
        MyPayVerifyCallback payVerifyCallback = new MyPayVerifyCallback();
        private bool purchInited = false;

        public override void Init()
        {
            payVerifyCallback = new MyPayVerifyCallback();
            //没有校验的订单需要再次校验
            List<IapProductConfig_Data> listP = DataManager.ShopData.PendingReceiptList;

            for (int i = 0; i < listP.Count; i++)
            {
                IapProductConfig_Data data = listP[i];
                CommandBinder.DispatchBinding(GameEvent.ValidateReceipt, data);
            }

            if (m_StoreController == null)
            {
                InitializePurchasing();
            }
            FTDSdk.getInstance().setPayVerifyCallback(payVerifyCallback);
        }

        private void InitializePurchasing()
        {
            if (IsInitialized())
            {
                return;
            }

            //CommandChannel commandChannel = CommandChannel.GetInstance();
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
#if UNITY_ANDROID
            builder.Configure<IGooglePlayConfiguration>().SetPublicKey(GameSetting.GooglePublicKey);
#endif
            m_ListProduct = DataManager.IapData.GetIapProductConfig(true);
            
            Dictionary<string,ProductType> typedic = new Dictionary<string, ProductType>();
            foreach (var product in m_ListProduct)
            {
                typedic[product.ProductID] = (ProductType) product.ProductType;
            }

            foreach (string typeKey in typedic.Keys)
            {
                builder.AddProduct(typeKey, typedic[typeKey]);
            }

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            m_Validator =
 new CrossPlatformValidator(GooglePlayTangle.Data(), AppleTangle.Data(), Application.identifier);
#endif
            UnityPurchasing.Initialize(this, builder);
        }

        public bool IsInitialized()
        {
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }

        public bool IsInited()
        {
            return IsInitialized() && purchInited;
        }
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            m_StoreController = controller;
            m_StoreExtensionProvider = extensions;

            foreach (var product in m_ListProduct)
            {
                var p = m_StoreController.products.WithID(product.ProductID);

                if (p != null)
                {
                    product.ProductLocalizedPrice = p.metadata.localizedPriceString;
                    product.ProductLocalizedPriceValue = p.metadata.localizedPrice;
                    product.LocalizedTitle = p.metadata.localizedTitle;
                    product.IsoCurrencyCode = p.metadata.isoCurrencyCode;

                    LoggerHelper.LogFormat("{0} localizedPrice: {1}", product.ProductID,
                        p.metadata.localizedPriceString);
                }
            }
#if UNITY_EDITOR
            
            
#endif

            purchInited = true;
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
//            ReportDataManager.IapFailInit();
            GameAnalyze.LogLoading("PFail",error.ToString());
            EventDispatcher.TriggerEvent(GlobalEvents.PurchaseInitFailer);
            LoggerHelper.ErrorFormat("Purchase initialize failed, failureReason: {0}", error.ToString());
        }

        public override void Pause(bool pause)
        {
            //if (pause)
            //{
            //    //窗口没打开时
            //    if (UIManager.GetUI(UIKeys.PromotionNoviceDialog) == null
            //        && UIManager.GetUI(UIKeys.PromotionNormalDialog) == null
            //        && UIManager.GetUI(UIKeys.StoreDialog) == null)
            //    {
            //        DataManager.GiftData = null;
            //        CommandBinder.DispatchBinding(GameEvent.ReqestGift);
            //    }
            //}
        }

        public override void Shut()
        {
            m_StoreController = null;
            m_StoreExtensionProvider = null;
            m_AppleExtensions = null;
            m_Validator = null;
        }

        public void BuyProductId(IapProductConfig_Data productData)
        {
            if (IsInitialized())
            {
                Product product = m_StoreController.products.WithID(productData.ProductID);

                if (product != null && product.availableToPurchase)
                {
                    DataManager.ShopData.AddPendingProduct(productData);
                    m_StoreController.InitiatePurchase(product);
                    LoggerHelper.Log(string.Format("Purchasing product asynchronously: '{0}'", product.definition.id));
                }
                else
                {
                    EventDispatcher.TriggerEvent(GlobalEvents.PurchaseFailed);
                    UIManager.ShowMessage(LanguageManager.Get("Purchase_Failed_Des7"), 3);
                    LoggerHelper.Error(
                        "BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                EventDispatcher.TriggerEvent(GlobalEvents.PurchaseFailed);
#if UNITY_ANDROID
                UIManager.ShowMessage(LanguageManager.Get("Purchase_Failed_Des1"));
#elif UNITY_IOS
                UIManager.ShowMessage(LanguageManager.Get("Purchase_Failed_Ios_Des"), 3);
#endif
                LoggerHelper.Error("BuyProductID: FAIL. Not initialized.");
            }
        }

        public void RestorePurchases()
        {
            if (!IsInitialized())
            {
                LoggerHelper.Error("RestorePurchases FAIL. Not initialized.");
                return;
            }

            if (Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.OSXPlayer)
            {
                LoggerHelper.Log("RestorePurchases started ...");
                DataManager.ShopData.RemoveAllPendingProduct();
                var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
                apple.RestoreTransactions((result) =>
                {
                    LoggerHelper.Log("RestorePurchases continuing: " + result +
                                     ". If no further messages, no purchases available to restore.");
                });
            }
            else
            {
                LoggerHelper.Log("RestorePurchases FAIL. Not supported on this platform. Current = " +
                                 Application.platform);
            }
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            var productDefinition = args.purchasedProduct.definition;
            LoggerHelper.Log("ProcessPurchase ." + productDefinition.id);

            var data = DataManager.ShopData.GetPendingProduct(productDefinition.id);
            if (data == null)
            {
                data = m_ListProduct.Find(x => x.ProductID == productDefinition.id);
            }

            LoggerHelper.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", productDefinition.id));

            data.Receipt = args.purchasedProduct.receipt;
            data.TransactionID = args.purchasedProduct.transactionID;

            DataManager.ShopData.AddPendingReceiptProduct(data);

#if UNITY_EDITOR
            CommandBinder.DispatchBinding(GameEvent.AnalysisIapEvent, data.ProductID);
#endif
            try {
                int coin = AppEngine.SyncManager.Data.Coin.Value;
                int currenthint1 = AppEngine.SyncManager.Data.Hint1.Value;
                int currenthint2 = AppEngine.SyncManager.Data.Hint2.Value;
                int currenthint3 = AppEngine.SyncManager.Data.Hint3.Value;
                int currenthint4 = AppEngine.SyncManager.Data.Hint4.Value;
                int currenthint5 = AppEngine.SyncManager.Data.Bee.Value;
                ReportUserBuyData _data = new ReportUserBuyData();
                _data.money = XUtils.ParseCent(data.ProductLocalizedPriceValue.ToString());
                _data.currency = data.IsoCurrencyCode.ToString();
                _data.itemName = data.LocalizedTitle;
                _data.p_userTypeBefore = "NULL";
                _data.p_userTypeAfter = "NULL";
                _data.p_buyItemId = data.ProductID;
                _data.dollermoney = data.ProductDollarPrice;
                _data.p_moneyCost = XUtils.GetDollerCent(data.ProductDollarPrice);
                _data.coinreward = data.ProductCoins;
                _data.beforecoin = coin;
                _data.beforehint1 = currenthint1;
                _data.beforehint2 = currenthint2;
                _data.beforehint3 = currenthint3;
                _data.beforehint4 = currenthint4;
                _data.beforehint5 = currenthint5;
                _data.afterhint1 = currenthint1 + data.ProductHint1;
                _data.afterhint2 = currenthint2 + data.ProductHint2;
                _data.afterhint3 = currenthint3 + data.ProductHint3;
                _data.afterhint4 = currenthint4 + data.ProductHint4;
                _data.afterhint5 = currenthint5 + data.ProductHint5;
                _data.ProductHint1 = data.ProductHint1;
                _data.ProductHint2 = data.ProductHint2;
                _data.ProductHint3 = data.ProductHint3;
                _data.ProductHint4 = data.ProductHint4;
                _data.ProductHint5 = data.ProductHint5;
                _data.IapType = data.IapType;
                _data.productType = (ProductType)data.ProductType;
                _data.p_orderId = productDefinition.storeSpecificId;
                payVerifyCallback.reportData = _data;
                data._customData = _data;
                AppEngine.SSystemManager.GetSystem<BusinessSystem>().PlayerBuyItem(data);
            } catch (Exception e) {
                Debug.LogError(e.StackTrace);
                Debug.LogError("something wrong");
            }

            //发奖励
            CommandBinder.DispatchBinding(GameEvent.CurrencyIapEvent, data);
            CommandBinder.DispatchBinding(GameEvent.ValidateReceipt, data);
            
            try
            {
                AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>()
                    .PlayBuy(productDefinition.id, XUtils.ParseCent(data.ProductDollarPrice));
#if UNITY_IOS
                FTDSdk.getInstance().IosValidateAndTrackInAppPurchase(
                    args.purchasedProduct.receipt,
                    data.ProductLocalizedPriceValue.ToString(), args.purchasedProduct.metadata.isoCurrencyCode,
                    args.purchasedProduct.transactionID, productDefinition.id,
                    data.TitleName, XUtils.ParseCent(data.ProductDollarPrice).ToString(), null);
#elif UNITY_ANDROID
                var unifiedReceipt = JsonUtility.FromJson<UnifiedReceipt>(data.Receipt);
                if (unifiedReceipt != null && !string.IsNullOrEmpty(unifiedReceipt.Payload))
                {
                    var purchaseReceipt = JsonUtility.FromJson<UnityChannelPurchaseReceipt>(unifiedReceipt.Payload);
                    //FTDSdk.getInstance().AndroidValidateAndTrackInAppPurchase("sdfsdfdsfds", "sdhfsiduhgisd", "fjsidjgi", "3.00", "USD", testCustomParams);
                    FTDSdk.getInstance().AndroidValidateAndTrackInAppPurchase(
                        Const.GooglePublicKey,
                        purchaseReceipt.signature, purchaseReceipt.json,
                        data.ProductLocalizedPriceValue.ToString(), args.purchasedProduct.metadata.isoCurrencyCode,null); 
                }

#else
#endif
            }
            catch (Exception e)
            {
                Debug.Log("something Wrong");
                Debug.LogError(e.StackTrace);
            }
            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
        {
            switch (reason)
            {
                case PurchaseFailureReason.UserCancelled:
                    UIManager.ShowMessage(LanguageManager.Get("Purchase_Failed_Des5"), 3);
                    break;

                case PurchaseFailureReason.DuplicateTransaction:
                    m_StoreController.ConfirmPendingPurchase(product);
                    UIManager.ShowMessage(LanguageManager.Get("Purchase_Failed_Des6"), 3);
                    break;

                case PurchaseFailureReason.PurchasingUnavailable:
                case PurchaseFailureReason.ExistingPurchasePending:
                case PurchaseFailureReason.ProductUnavailable:
                case PurchaseFailureReason.SignatureInvalid:
                case PurchaseFailureReason.PaymentDeclined:
                case PurchaseFailureReason.Unknown:
                    UIManager.ShowMessage(LanguageManager.Get("Purchase_Failed_Des7"), 3);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("failureReason", reason, null);
            }
            GameAnalyze.LogLoading("buyFail",reason.ToString());
            DataManager.ShopData.RemovePendingProduct(product.definition.id);
            EventDispatcher.TriggerEvent(GlobalEvents.PurchaseFailed);
//            ReportDataManager.ShopFailed(product, reason);
            LoggerHelper.ErrorFormat("{0} purchase failed, failureReason: {1}", product.definition.id,
                reason.ToString());
        }
    }
}

/// <summary>
/// 真假单验证的逻辑
/// </summary>
class MyPayVerifyCallback : FtPayVerifyCallback
{
    public ReportUserBuyData reportData;
    public void onSuccess()
    {
        Debug.Log("假单验证成功");
        //这里进行游戏逻辑
        GameAnalyze.LogusersBuy(reportData.money,
            reportData.currency,
            reportData.itemName, reportData.p_userTypeBefore, reportData.p_userTypeAfter, reportData.p_buyItemId, reportData.p_moneyCost,
            reportData.coinreward, reportData.beforecoin,reportData.beforehint1,reportData.beforehint2,reportData.beforehint3,reportData.beforehint4,reportData.beforehint5,reportData.afterhint1,reportData.afterhint2,reportData.afterhint3,reportData.afterhint4,reportData.afterhint5,reportData.p_orderId,true);
        AOEReport.PlayerBuy(reportData.money,reportData.dollermoney,reportData.currency,reportData.itemName,reportData.p_buyItemId);
    }
 
    public void onValidateInAppFailure(string error)
    {
        //这里进行游戏逻辑
        Debug.Log("假单验证失败");
        GameAnalyze.LogusersBuy(reportData.money,
            reportData.currency,
            reportData.itemName, reportData.p_userTypeBefore, reportData.p_userTypeAfter, reportData.p_buyItemId, reportData.p_moneyCost,
            reportData.coinreward, reportData.beforecoin,reportData.beforehint1,reportData.beforehint2,reportData.beforehint3,reportData.beforehint4,reportData.beforehint5,reportData.afterhint1,reportData.afterhint2,reportData.afterhint3,reportData.afterhint4,reportData.afterhint5,reportData.p_orderId,false);
    }
}

public class ReportUserBuyData
{
    public int money;
    public string currency;
    public string itemName;
    public string p_userTypeBefore;
    public string p_userTypeAfter;
    public string p_buyItemId;
    public string dollermoney;
    public int p_moneyCost;
    public int coinreward;
    public int beforecoin;
    public int beforehint1;
    public int beforehint2;
    public int beforehint3;
    public int beforehint4;
    public int beforehint5;
    public int afterhint1;
    public int afterhint2;
    public int afterhint3;
    public int afterhint4;
    public int afterhint5;

    public int ProductHint1;
    public int ProductHint2;
    public int ProductHint3;
    public int ProductHint4;
    public int ProductHint5;
    public ProductType productType;
    public int IapType;
    public string p_orderId;
}
