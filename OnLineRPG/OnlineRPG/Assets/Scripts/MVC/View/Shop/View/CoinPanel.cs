using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using BetaFramework;
using Scripts.MVC.View.Shop.View;

public class CoinPanel : MonoBehaviour
{
    public Transform ContentTrans;
    public Transform ChildContentTrans;
    public Button MoreOfferButton;
    private List<ShopBaseItem> m_AllTransforms;
    private int m_SiblingIndex = 0;
    public GameObject loadingObj;
    public Transform sealsContent;
    public Transform limitContent;
    public Transform giftsContent;
    public Transform beeContent;
    public Transform removeContent;

    //服务器派发的礼包个数
    private int m_SaleCount = 0;

    //去广告内购个数
    private int m_NoAdsCount = 0;

    private int m_ShowCount = 999;
    private bool normalLoaded = false;
    private int currentfinish = 0;
    private bool inited;
    public void OnAwake()
    {
        ContentTrans = transform.Find("Viewport/Content");
        if (ContentTrans == null)
        {
            ContentTrans = transform.Find("Scroll View/Viewport/Content");
        }

        ChildContentTrans = ContentTrans.Find("Shop_Deals_Item");
        inited = false;
    }


    public void Init()
    {
        if (!inited)
        {
            inited = true;
            m_AllTransforms = new List<ShopBaseItem>();
            Build();
        }
    }

    public void Build()
    {
        ShowSaleItem();
        ShowGiftItems();
        ShowNormalItems();
        ShowNoAdsItems();
        ShowBeeGiftItems();
        ShowLimitItem();
    }

    private void ShowMoreOffers()
    {
        for (int i = 0; i < ContentTrans.childCount; i++)
        {
            ContentTrans.GetChild(i).gameObject.SetActive(true);
        }

        ChildContentTrans.gameObject.SetActive(true);
        MoreOfferButton.gameObject.SetActive(false);
    }

    private void ShowLimitItem()
    {
        if (!DataManager.businessGiftData.inited)
        {
            return;
        }

        if (DataManager.businessGiftData.shopItem.Length == 0)
        {
            return;
        }

        if (DataManager.businessGiftData.AllGiftBuyed())
        {
            return;
        }

        if (!DataManager.businessGiftData.LevelEnough())
        {
            return;
        }

        if (AppEngine.SSystemManager.GetSystem<BusinessSystem>().timeOut)
        {
            return;
        }

        if (DataManager.businessGiftData.shopItem.Length == 1)
        {
            var config = DataManager.IapData.GetIapProductConfig(true);
            var configdata = config.Find(x => x.ItemID == DataManager.businessGiftData.shopItem[0].giftId);
            int removeAD = configdata.removeAd;
            if (AppEngine.SyncManager.Data.IsRemoveAd.Value)
                removeAD = 0;
            if (configdata.ProductHint1 + configdata.ProductHint2 + configdata.ProductHint3 + configdata.ProductHint4 +
                configdata.ProductHint5 + removeAD == 0 && configdata.ProductCoins > 0)
            {
                ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop_Super_Limit_Two_Item,
                    OnLoadLimitItemsSuccess);
            }
            else if (configdata.ProductHint1 + configdata.ProductHint2 + configdata.ProductHint3 +
               configdata.ProductHint4 +
               configdata.ProductCoins + removeAD == 0 && configdata.ProductHint5 > 0)
            {
                ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop_Super_Limit_Five_Item,
                    OnLoadLimitItemsSuccess);
            }
            else
            {
                ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop_Super_Limit_One_Item,
                    OnLoadLimitItemsSuccess);
            }
        }
        else if (DataManager.businessGiftData.shopItem.Length == 2)
        {
            var config = DataManager.IapData.GetIapProductConfig(true);
            var configdata = config.Find(x => x.ItemID == DataManager.businessGiftData.shopItem[0].giftId);
            if (configdata.ProductHint1 + configdata.ProductHint2 + configdata.ProductHint3 + configdata.ProductHint4 +
                configdata.ProductHint5 == 0)
            {
                ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop_Super_Limit_Four_Item,
                    OnLoadLimitItemsSuccess);
            }
            else if (configdata.ProductHint1 + configdata.ProductHint2 + configdata.ProductHint3 + configdata.ProductHint4 +
               configdata.ProductCoins == 0)
            {
                ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop_Super_Limit_Four_Item,
                    OnLoadLimitItemsSuccess);
            }
            else
            {
                ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop_Super_Limit_Three_Item,
                    OnLoadLimitItemsSuccess);
            }
        }
    }

    private void ShowSaleItem()
    {
        var data = DataManager.IapData;
        var productData = data.GetNoviceProductData();
        if (productData != null && !DataManager.ShopData.IsItemPurchased(productData.ProductID))
        {
            ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop500_Limited_Time_Item,
                OnLoadSaleItemsSuccess);
        }
    }

    //去广告内购项
    private void ShowNoAdsItems()
    {
        if (AppEngine.SyncManager.Data.IsRemoveAd.Value)
            return;
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop_Remove_Ads_Item,
            OnLoadNoAdsItemsSuccess);
    }

    //常驻礼包
    private void ShowGiftItems()
    {
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop_Super_Started_Item,
            OnLoadGiftItemsSuccess);
    }

    private void ShowBeeGiftItems()
    {
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Shop_Super_Bee_Item,
            OnLoadBeeGiftItemsSuccess);
    }

    //常规内购项
    private void ShowNormalItems()
    {
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_Deals_Item,
            OnLoadNormalItemsSuccess);
    }

    private void OnLoadLimitItemsSuccess(GameObject go)
    {
        var obj = Instantiate(go, ContentTrans, false);
        obj.transform.SetSiblingIndex(1);
    }

    private void OnLoadSaleItemsSuccess(GameObject go)
    {
        var data = DataManager.IapData;
        IapProductConfig_Data productData = data.GetNoviceProductData();
        string prefabName = ViewConst.prefab_Shop500_Limited_Time_Item;
        if (productData != null)
        {
            Transform prefab = AppEngine.SObjectPoolManager.Spawn<Transform>(prefabName, go.transform, Vector3.zero,
                Quaternion.identity, sealsContent);
            prefab.SetAsFirstSibling();
            SetRecttransform(prefab);
            var item = prefab.GetComponentInChildren<ShopBaseItem>();
            item.IapItem = productData;
            item.Initialize();
            m_SaleCount++;
        }
    }
    private void OnLoadBeeGiftItemsSuccess(GameObject go)
    {
        var data = DataManager.IapData;
        var products = data.GetProductsByType(IapType.NormalBeeGift);
        for (int i = 0; i < products.Count; i++)
        {
            Transform prefab = AppEngine.SObjectPoolManager.Spawn<Transform>(ViewConst.prefab_Shop_Super_Bee_Item,
                go.transform, Vector3.zero, Quaternion.identity, beeContent);
            prefab.SetSiblingIndex(m_SaleCount + i);
            SetRecttransform(prefab);

            var item = prefab.GetComponentInChildren<ShopBaseItem>();
            item.IapItem = products[i];
            //item.Dialog = this;
            item.Initialize();
        }
    }
    private void OnLoadGiftItemsSuccess(GameObject go)
    {
        var data = DataManager.IapData;
        var products = data.GetProductsByType(IapType.NormalGift);
        for (int i = 0; i < products.Count; i++)
        {
            //Transform prefab = Object.Instantiate(go.transform, Vector3.zero, Quaternion.identity, ContentTrans);
            Transform prefab = AppEngine.SObjectPoolManager.Spawn<Transform>(ViewConst.prefab_Shop_Super_Started_Item,
                go.transform, Vector3.zero, Quaternion.identity, giftsContent);
            prefab.SetSiblingIndex(m_SaleCount + i);
            SetRecttransform(prefab);

            var item = prefab.GetComponentInChildren<ShopBaseItem>();
            item.IapItem = products[i];
            //item.Dialog = this;
            item.Initialize();
        }
    }

    private void OnLoadNoAdsItemsSuccess(GameObject go)
    {
        //Debug.LogError("normal loaded " + normalLoaded);
        var data = DataManager.IapData;
        var product = data.GetNoAdsProduct();
        if (product != null)
        {
            Transform prefab = AppEngine.SObjectPoolManager.Spawn<Transform>(ViewConst.prefab_ShopNoAdsItem, go.transform,
                Vector3.zero, Quaternion.identity, removeContent);
            SetRecttransform(prefab);
            var item = prefab.GetComponentInChildren<ShopBaseItem>();
            item.IapItem = product;
            //item.Dialog = this;
            item.Initialize();
            m_NoAdsCount++;
        }
    }

    private void OnLoadNormalItemsSuccess(GameObject go)
    {
        normalLoaded = true;
        var data = DataManager.IapData;
        var products = data.GetNormalProducts();

        for (int i = 0; i < products.Count; i++)
        {
            //Transform prefab = Object.Instantiate(go.transform, Vector3.zero, Quaternion.identity, ChildContentTrans);
            Transform prefab = AppEngine.SObjectPoolManager.Spawn<Transform>(ViewConst.prefab_Deals_Item, go.transform,
                Vector3.zero, Quaternion.identity, ChildContentTrans);
            var item = prefab.GetComponentInChildren<ShopBaseItem>();
            item.IapItem = products[i];
            //item.Dialog = this;
            item.Initialize();
            item.ChangeColor(i % 2 == 0);

            SetRecttransform(prefab);

            prefab.SetSiblingIndex(i + 1);
        }

    }

    private void SetRecttransform(Transform atransform)
    {
        RectTransform rectTransform = atransform as RectTransform;
        rectTransform.localPosition = Vector3.zero;
        rectTransform.localRotation = Quaternion.identity;
        rectTransform.localScale = Vector3.one;

        m_AllTransforms.Add(atransform.GetComponent<ShopBaseItem>());
    }

    protected void OnPurchaseInitSucceed()
    {
        StopLoading();
    }

    protected void OnPurchaseInitFailed()
    {
        StopLoading();
    }

    protected void OnPurchaserFailed()
    {
        StopLoading();
    }

    protected void OnPurchaseSucceed(IapProductConfig_Data item)
    {
        StopLoading();
    }

    public void StartLoading()
    {
        if (loadingObj != null)
        {
            loadingObj.SetActive(true);
        }
    }

    public void StopLoading()
    {
        if (loadingObj != null)
        {
            loadingObj.SetActive(false);
        }
    }
    public void PauseEffect()
    {
        foreach (var item in m_AllTransforms)
        {
            if (item is IEffectable)
            {
                (item as IEffectable).PauseEffect();
            }
        }
    }
    public void ResumeEffect()
    {
        foreach (var item in m_AllTransforms)
        {
            if (item is IEffectable)
            {
                (item as IEffectable).ResumeEffect();
            }
        }
    }
}