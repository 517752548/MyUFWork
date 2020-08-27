using System;
using UnityEngine;
using System.Collections;
using BetaFramework;
using UnityEngine.UI;

public class GameLoadingWindow : UIWindowBase
{
    public Animator animator;

    public Text loadingText;

    //UI的初始化请放在这里
    public override void OnOpen()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_loadingFly);
        if (AppEngine.SSystemManager != null && AppEngine.SSystemManager.GetSystem<EmailSystem>() != null)
            AppEngine.SSystemManager.GetSystem<EmailSystem>().RequestEmailInfo();

        StartCoroutine(LoadingAnim());
    }

    IEnumerator LoadingAnim()
    {
        var loading = new WaitForSeconds(0.5f);
        while (true)
        {
            yield return loading;
            loadingText.text = "LOADING.";
            yield return loading;
            loadingText.text = "LOADING..";
            yield return loading;
            loadingText.text = "LOADING...";
        }
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        yield return new WaitForSeconds(0.8f);

        OpenSuccess();
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        animator.SetTrigger("disappear");
        yield return new WaitForSeconds(1.5f);
        //默认无动画
        ExitSuccess();
    }

    public override void OnClose()
    {
        KeyEventManager.Instance.RemoveBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
        EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.CloseUI, UIName);
        m_CloseCallback?.Invoke(this);
    }

    //请在这里写UI的更新逻辑，当该UI监听的事件触发时，该函数会被调用
    public override void OnRefresh()
    {
    }
}