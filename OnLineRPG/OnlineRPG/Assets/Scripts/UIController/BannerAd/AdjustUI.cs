using EventUtil;
using UnityEngine;

public class AdjustUI : MonoBehaviour
{
    private bool canShowAd;
    private bool m_UIAdjusted;
    private float bannerHeight;
    public float bannerNap;

    private bool hiddenBannerForCurrentUI;
    public bool hasRectTransform;

    // Use this for initialization
    private void Start()
    {
        if (hasRectTransform)
        {
            float rectHeight = this.GetComponent<RectTransform>().rect.height;
            float screenHeight = Screen.height;
            BetaFramework.LoggerHelper.Log("rectHeight " + rectHeight + " " + Screen.height);

        }
        else
        {
        }
        if (ResetBannerHeight())
        {
            bannerHeight = 0;
        }
        BetaFramework.LoggerHelper.Log(">>>>bannerHeight " + bannerHeight);
        bannerNap = 0;
        m_UIAdjusted = false;
        hiddenBannerForCurrentUI = false;

        EventDispatcher.AddEventListener(GlobalEvents.RemoveAd, ARemoveAdEvent);
        EventDispatcher.AddEventListener(GlobalEvents.BusinessConfigDataLocalInit, OnConfigDataGot);
        EventDispatcher.AddEventListener(GlobalEvents.BusinessConfigDataRequestSuccess, OnConfigDataGot);
        EventDispatcher.AddEventListener(GlobalEvents.BusinessConfigDataRequestFail, OnConfigDataGot);
        EventDispatcher.AddEventListener(GlobalEvents.ShowBanner, ShowBanner);
        EventDispatcher.AddEventListener(GlobalEvents.HideBanner, HideBanner);
        OnConfigDataGot();
    }

    protected virtual bool ResetBannerHeight()
    {
        return false;
    }

    private void OnDestroy()
    {
        EventDispatcher.RemoveEventListener(GlobalEvents.RemoveAd, ARemoveAdEvent);
        EventDispatcher.RemoveEventListener(GlobalEvents.BusinessConfigDataLocalInit, OnConfigDataGot);
        EventDispatcher.RemoveEventListener(GlobalEvents.BusinessConfigDataRequestSuccess, OnConfigDataGot);
        EventDispatcher.RemoveEventListener(GlobalEvents.BusinessConfigDataRequestFail, OnConfigDataGot);

        EventDispatcher.RemoveEventListener(GlobalEvents.ShowBanner, ShowBanner);
        EventDispatcher.RemoveEventListener(GlobalEvents.HideBanner, HideBanner);

    }



    virtual protected bool CanShowBannerForSelfReason()
    {
        return true;
    }

#if UNITY_EDITOR

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            m_UIAdjusted = true;
            TrigAppfacadeShowBannerMethod();
        }
    }

#endif

    private void ShowBanner()
    {
        if (!CanShowBannerForSelfReason())
        {
            HideBanner();
            BetaFramework.LoggerHelper.Log("selfreason 不显示banner");
            return;
        }
        hiddenBannerForCurrentUI = false;
        if (m_UIAdjusted)
        {
            TrigAppfacadeShowBannerMethod();
        }
        else
        {
            OnConfigDataGot();
        }
    }

    private static void TrigAppfacadeShowBannerMethod()
    {
        BetaFramework.LoggerHelper.Log("ShowBanner>>>>");
        EventDispatcher.TriggerEvent(GlobalEvents.BannerAppeared);
    }

    private static void TrigAppfacedHideBannerMethod()
    {
        BetaFramework.LoggerHelper.Log("HideBanner>>>>");
    }

    private void HideBanner()
    {
        hiddenBannerForCurrentUI = true;

        TrigAppfacedHideBannerMethod();
    }

    virtual protected bool IsBannerAvailable()
    {
         return false;
    }

    private void ARemoveAdEvent()
    {
        OnConfigDataGot();
    }

    private void OnConfigDataGot()
    {
		if (!CanShowBannerForSelfReason())
		{
			HideBanner();
			BetaFramework.LoggerHelper.Log("selfreason banner not show");
			return;
		}
        
        bool bannerConfigShow = IsBannerAvailable();
        canShowAd = bannerConfigShow && !hiddenBannerForCurrentUI;
        BetaFramework.LoggerHelper.Log("OnConfigDataGot adjustUI >>>>" + canShowAd + " " + this);
        if (canShowAd)
        {
            if (!m_UIAdjusted)
            {
                TrigAppfacadeShowBannerMethod();
                m_UIAdjusted = true;
            }
        }
        else
        {
            m_UIAdjusted = false;
            TrigAppfacedHideBannerMethod();
        }
    }
    
    public void adjustItemHeight(GameObject obj, bool reduce)
    {
        if (reduce)
        {
            obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y + (bannerNap + bannerHeight), obj.transform.localPosition.z);
        }
        else
        {
            obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y - (bannerNap + bannerHeight), obj.transform.localPosition.z);
        }
    }

    public void adjustTransform(Transform obj, bool reduce)
    {
        if (reduce)
        {
            obj.localPosition = new Vector3(obj.localPosition.x, -1 * (bannerNap + bannerHeight) / Screen.height * 20 - 1.5f, obj.localPosition.z);
        }
        else
        {
            obj.localPosition = new Vector3(obj.localPosition.x, -1, obj.localPosition.z);
        }
    }

    //public void adjustBottom
    protected bool canShowBanner()
    {
        return canShowAd;
    }
}