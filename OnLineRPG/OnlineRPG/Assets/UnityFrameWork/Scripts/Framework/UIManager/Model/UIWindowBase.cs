using BetaFramework;
using System;
using System.Collections;
using UnityEngine;

public class UIWindowBase : UIBase
{
    public string uiName;
    public Animator anim;
    public object[] objs; //传参

    public bool canClose = true;

    /// <summary>
    /// Dialog消失动画
    /// </summary>
    public AnimationClip hidingAnimation;

    [HideInInspector] public string cameraKey;

    public UIType m_UIType;

    //是否缓存UI下次继续使用
    public bool ReUse = false;

    [SerializeField]
    private WindowStatus m_windowStatus;

    public WindowStatus windowStatus
    {
        get { return m_windowStatus; }
        set
        {
            m_windowStatus = value;
        }
    }

    [HideInInspector] public GameObject m_bgMask;

    [HideInInspector] public GameObject m_uiRoot;

    //open的毁掉
    private UICallBack m_UICallBack;

    //关闭的毁掉
    private UICallBack m_ExitcallBack;

    //close 回调
    public UISimpleCallBack m_CloseCallback = null;

    #region 重载方法

    public void Open()
    {
        
        OnOpen();
    }

    /// <summary>
    /// 每次打开界面都调用（新创建和复用的）
    /// </summary>
    public virtual void OnOpen()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_panel_show);
        KeyEventManager.Instance.AddBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
    }

    /// <summary>
    /// 每次关闭界面都调用（新创建和复用的）
    /// </summary>
    public virtual void OnClose()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_panel_close);
        KeyEventManager.Instance.RemoveBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
        EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.CloseUI, UIName);
        m_CloseCallback?.Invoke(this);
    }

    public void Hide()
    {
        OnHide();
        windowStatus = WindowStatus.Hide;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        windowStatus = WindowStatus.Opening;
        gameObject.SetActive(true);
        OnShow();
    }

    public virtual void OnLostTop()
    {
        
    }
    
    public virtual void OnRecoveryTop()
    {
        
    }

    /// <summary>
    /// 需要主动调用
    /// </summary>
    public virtual void OnRefresh()
    {
    }

    protected virtual bool onBackPressed()
    {
        if (canClose && windowStatus == WindowStatus.Opened)
        {
            CloseByBackPress();
            return true;
        }

        if (windowStatus == WindowStatus.Opening || windowStatus == WindowStatus.Closing)
        {
            return true;
        }

        return false;
    }

    protected virtual void CloseByBackPress()
    {
        Close();
    }

    public void StartAnim(UICallBack callBack, params object[] objs)
    {
        m_UICallBack = callBack;
        StartCoroutine(EnterAnim(objs));
    }

    public void ReStartAnim()
    {
        StartCoroutine(EnterAnim(objs));
    }

    public virtual IEnumerator EnterAnim(params object[] objs)
    {
        if (anim != null && hidingAnimation != null)
        {
            anim.SetTrigger("show");
        }

        yield return new WaitForSeconds(0.5f);

        OpenSuccess();
    }

    public void OpenSuccess()
    {
        windowStatus = WindowStatus.Opened;
        OnCompleteEnterAnim();

        try
        {
            if (m_UICallBack != null)
            {
                m_UICallBack(this, objs);
            }
        }
        catch (Exception e)
        {
            LoggerHelper.Exception(e);
        }
    }

    /// <summary>
    /// 进入动画播放完成
    /// </summary>
    public virtual void OnCompleteEnterAnim()
    {
    }

    public void StartExitAnim(UICallBack callBack, params object[] objs)
    {
        this.m_ExitcallBack = callBack;
        StartCoroutine(ExitAnim(callBack, objs));
    }

    public virtual IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        if (anim != null && hidingAnimation != null)
        {
            anim.SetTrigger("hide");
            yield return new WaitForSeconds(hidingAnimation.length);
        }
        else
            yield return new WaitForSeconds(0.2f);

        //默认无动画
        ExitSuccess();

        yield break;
    }

    public void ExitSuccess()
    {
        OnCompleteExitAnim();
        windowStatus = UIWindowBase.WindowStatus.Closed;

        try
        {
            if (m_ExitcallBack != null)
            {
                m_ExitcallBack(this, objs);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    /// <summary>
    /// 退出动画播放完成
    /// </summary>
    public virtual void OnCompleteExitAnim()
    {
        if (!ReUse)
        {
            UIManager.DestroyUI(this);
        }
    }

    protected virtual void OnShow()
    {
    }

    /// <summary>
    /// 当栈顶被关闭这个ui被打开的时候调用，主要用来显示一次打开动画
    /// </summary>
    protected virtual void ShowAnimation()
    {
        if (anim != null && hidingAnimation != null)
        {
            anim.SetTrigger("show");
        }
    }

    protected virtual void OnHide()
    {
    }

    #endregion 重载方法

    #region 继承方法

    //刷新是主动调用
    public void Refresh(params object[] args)
    {
        OnRefresh();
    }

    /// <summary>
    /// 主动关闭面板
    /// </summary>
    public virtual void Close()
    {
        if (!ResponseClick) return;
        UIManager.CloseUIWindow(this);
    }

    #endregion 继承方法

    public enum WindowStatus
    {
        Create,
        Opening,
        Opened,
        Closing,
        Closed,
        Hide,
    }

    /// <summary>
    /// 是否可以响应面板的点击事件
    /// </summary>
    protected virtual bool ResponseClick
    {
        get
        {
            if (WindowStatus.Opened == windowStatus)
                return true;
            return false;
        }
    }

    public virtual bool HaveDataChange(object[] objs)
    {
        return true;
    }
}