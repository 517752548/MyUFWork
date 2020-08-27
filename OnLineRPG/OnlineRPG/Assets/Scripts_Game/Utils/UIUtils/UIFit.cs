using EventUtil;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIFit : MonoBehaviour
{
    [Header("pad")]
    public ScreenFit pad;

    [Header("全面屏的手机")]
    public ScreenFit fullscreen;

    [Header("某些iOS手机")]
    public ScreenFit someiOSDevice;

    [Header("普通手机Banner")]
    public ScreenFit normalBanner;

    [Header("padBanner")]
    public ScreenFit padBanner;

    [Header("全面屏的手机Banner")]
    public ScreenFit fullscreenBanner;

    [Header("某些iOS手机Banner")]
    public ScreenFit someiOSDeviceBanner;

    private Transform m_originTransform;
    private Vector3 m_originLocalPosition;
    private Vector3 m_originLocalScale;

    public bool m_HasBannerConfig = false;

    private bool m_hasBanner = false;

    private bool HasBanner
    {
        get
        {
            return m_hasBanner;
        }

        set
        {
            if (m_hasBanner != value)
            {
                m_hasBanner = value;
                if (m_HasBannerConfig)
                {
                    FitScreen();
                }
            }
        }
    }

    // Use this for initialization
    private void Start()
    {
        m_originTransform = transform;
        m_originLocalPosition = transform.localPosition;
        m_originLocalScale = transform.localScale;
        string sceneName = SceneManager.GetActiveScene().name;
        bool bannerAvalible = false;
        m_hasBanner = bannerAvalible;
        FitScreen();//确保执行一次该方法.
        EventDispatcher.AddEventListener(GlobalEvents.BannerAppeared, BannerAppeared);
        EventDispatcher.AddEventListener(GlobalEvents.BannerDisaAppeared, BannerDisappeared);
    }

    private void OnDestroy()
    {
        EventDispatcher.RemoveEventListener(GlobalEvents.BannerAppeared, BannerAppeared);
        EventDispatcher.RemoveEventListener(GlobalEvents.BannerDisaAppeared, BannerDisappeared);
    }

    private void BannerAppeared()
    {
        HasBanner = true;
    }

    private void BannerDisappeared()
    {
        HasBanner = false;
    }

    private void FitScreen()
    {
        ScreenType currenType = GetScreenType();
        if (currenType == ScreenType.Normal)
        {
            if (m_hasBanner && m_HasBannerConfig)
            {
                normalBanner.Fit(m_originTransform, m_originLocalPosition);
            }
        }
        else if (currenType == ScreenType.Pad)
        {
            if (m_hasBanner && m_HasBannerConfig)
            {
                padBanner.Fit(m_originTransform, m_originLocalPosition);
            }
            else
            {
                pad.Fit(m_originTransform, m_originLocalPosition);
            }
        }
        else if (currenType == ScreenType.FullScree)
        {
            if (m_hasBanner && m_HasBannerConfig)
            {
                fullscreenBanner.Fit(m_originTransform, m_originLocalPosition);
            }
            else
            {
                fullscreen.Fit(m_originTransform, m_originLocalPosition);
            }
        }
        else if (currenType == ScreenType.SomeiOSDevice)
        {
            if (m_hasBanner && m_HasBannerConfig)
            {
                someiOSDeviceBanner.Fit(m_originTransform, m_originLocalPosition);
            }
            else
            {
                someiOSDevice.Fit(m_originTransform, m_originLocalPosition);
            }
        }
    }

    private ScreenType GetScreenType()
    {
        if (SystemInfo.deviceModel == "iPhone10,3"
            || SystemInfo.deviceModel == "iPhone10,6"
            || SystemInfo.deviceModel == "iPhone11,8"
            || SystemInfo.deviceModel == "iPhone11,2"
            || SystemInfo.deviceModel == "iPhone11,6"
            || SystemInfo.deviceModel == "iPhone12,1"
            || SystemInfo.deviceModel == "iPhone11,4" || (Screen.width == 1125 && Screen.height == 2436) || (Screen.width == 1242 && Screen.height == 2688)
            || (Screen.width == 828 && Screen.height == 1792))
        {
            return ScreenType.SomeiOSDevice;
        }

        float screenrate = (float)Screen.height / Screen.width;
        if (screenrate <= 1.6f)
        {
            return ScreenType.Pad;
        }
        else if (screenrate <= 1.85f)
        {
            return ScreenType.Normal;
        }
        else
        {
            return ScreenType.FullScree;
        }
    }
}

[Serializable]
public class ScreenFit
{
    public CanvasScalerFit canvasScaler = CanvasScalerFit.ignore;
    public ScreenFitChild[] screenFitChilds;

    public void Fit(Transform selftransform, Vector3 alocalPosition)
    {
        if (canvasScaler != CanvasScalerFit.ignore)
        {
            CanvasScaler currentCanvasScaler = selftransform.GetComponent<CanvasScaler>();
            if (currentCanvasScaler)
            {
                if (canvasScaler == CanvasScalerFit.one)
                {
                    currentCanvasScaler.matchWidthOrHeight = 1;
                }
                else if (canvasScaler == CanvasScalerFit.zero_point_five)
                {
                    currentCanvasScaler.matchWidthOrHeight = 0.5f;
                }
                else if (canvasScaler == CanvasScalerFit.zero)
                {
                    currentCanvasScaler.matchWidthOrHeight = 0;
                }
            }
        }

        for (int i = 0; i < screenFitChilds.Length; i++)
        {
            if (screenFitChilds[i].screenfitvalue == ScreenFitValue.localposition)
            {
                selftransform.localPosition = alocalPosition + screenFitChilds[i].targetvalue;
            }
            else if (screenFitChilds[i].screenfitvalue == ScreenFitValue.scale)
            {
                selftransform.localScale = screenFitChilds[i].targetvalue;
            }else if (screenFitChilds[i].screenfitvalue == ScreenFitValue.Top)
            {
                selftransform.GetComponent<RectTransform>().offsetMax += new Vector2(screenFitChilds[i].targetvalue.x,screenFitChilds[i].targetvalue.y);
            }else if (screenFitChilds[i].screenfitvalue == ScreenFitValue.Bottom)
            {
                selftransform.GetComponent<RectTransform>().offsetMin += new Vector2(screenFitChilds[i].targetvalue.x,screenFitChilds[i].targetvalue.y);
            }
        }
    }
}

[Serializable]
public class ScreenFitChild
{
    public ScreenFitValue screenfitvalue = ScreenFitValue.none;
    public Vector3 targetvalue;
}

public enum CanvasScalerFit
{
    ignore,
    zero,
    zero_point_five,
    one
}

public enum ScreenType
{
    None,
    Pad,
    Normal,
    FullScree,
    SomeiOSDevice
}

public enum ScreenFitValue
{
    none,
    localposition,
    scale,
    Top,
    Bottom
}