using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class UIStackManager : MonoBehaviour
{
    [SerializeField] private List<UIWindowBase> m_NormalStack = new List<UIWindowBase>();

    [SerializeField] private List<UIWindowBase> m_FixedStack = new List<UIWindowBase>();

    [SerializeField] private List<UIWindowBase> m_PopupStack = new List<UIWindowBase>();

    [SerializeField] private List<UIWindowBase> m_TopBarStack = new List<UIWindowBase>();

    [SerializeField] private List<UIWindowBase> m_GuideStack = new List<UIWindowBase>();

    public List<UIWindowBase> ListNormalWindow
    {
        get { return m_NormalStack; }
    }

    public List<UIWindowBase> ListFixedWindow
    {
        get { return m_FixedStack; }
    }

    public List<UIWindowBase> ListPopupWindow
    {
        get { return m_PopupStack; }
    }

    public List<UIWindowBase> ListTopBarWindow
    {
        get { return m_TopBarStack; }
    }

    public List<UIWindowBase> ListGuideUiWindow
    {
        get { return m_GuideStack; }
    }

    private void Awake()
    {
        AppEngine.AddDontGameObject(gameObject);
    }

    public void OnUIOpen(UIWindowBase ui, OpenType type = OpenType.Stack)
    {
        switch (ui.m_UIType)
        {
            case UIType.Fixed:
                HandleUi(m_FixedStack, ui, type);
                break;

            case UIType.Normal:
                HandleUi(m_NormalStack, ui, type);
                break;

            case UIType.PopUp:
                HandleUi(m_PopupStack, ui, type);
                break;

            case UIType.TopBar:
                HandleUi(m_TopBarStack, ui, type);
                break;
            case UIType.Guide:
                HandleUi(m_GuideStack, ui, type);
                break;
        }
    }

    private void HandleUi(List<UIWindowBase> uiStack, UIWindowBase ui, OpenType type = OpenType.Stack)
    {
        UIWindowBase lastUI = null;
        if (uiStack.Count > 0)
        {
            lastUI = uiStack[uiStack.Count - 1];
        }

        switch (type)
        {
            case OpenType.Stack:
                if (lastUI != null)
                {
                    if (lastUI.windowStatus == UIWindowBase.WindowStatus.Opening)
                    {
                        lastUI.StopAllCoroutines();
                        lastUI.OpenSuccess();
                    }

                    if (lastUI.windowStatus == UIWindowBase.WindowStatus.Closing)
                    {
                        lastUI.StopAllCoroutines();
                        lastUI.ExitSuccess();
                    }

                    lastUI.Hide();
                }

                uiStack.Add(ui);
                break;

            case OpenType.Replace:
                if (lastUI != null)
                {
                    //无论上一个面板是什么状态，立即关闭，而且不恢复其之前的面板
                    lastUI.OnCompleteExitAnim();
                    try
                    {
                        lastUI.Hide();
                        lastUI.OnClose();
                    }
                    catch (System.Exception e)
                    {
                        LoggerHelper.Error(lastUI.UIName + " OnClose Exception: " + e.ToString());
                    }

                    OnUIClose(lastUI, false);
                    if (UIManager.GetIsExits(lastUI))
                    {
                        UIManager.RemoveUI(lastUI);
                    }

                    if (lastUI.ReUse)
                    {
                        UIManager.AddHideUI(lastUI);
                    }

                    //lastUI.Close();
                }

                uiStack.Add(ui);
                break;

            case OpenType.Over:
                lastUI?.OnLostTop();
                uiStack.Add(ui);
                break;
            case OpenType.Queue:
                uiStack.Insert(0,ui);
                break;
        }
    }

    public void OnUIClose(UIWindowBase ui, bool recoveryLast = true)
    {
        switch (ui.m_UIType)
        {
            case UIType.Fixed:
                HandleCloseUI(m_FixedStack, ui, recoveryLast);
                break;

            case UIType.Normal:
                HandleCloseUI(m_NormalStack, ui, recoveryLast);
                break;

            case UIType.PopUp:
                HandleCloseUI(m_PopupStack, ui, recoveryLast);
                break;

            case UIType.TopBar:
                HandleCloseUI(m_TopBarStack, ui, recoveryLast);
                break;
            case UIType.Guide:
                HandleCloseUI(m_GuideStack, ui, recoveryLast);
                break;
        }
    }

    private void HandleCloseUI(List<UIWindowBase> uiStack, UIWindowBase ui, bool recoveryLast)
    {
        uiStack.Remove(ui);
        if (recoveryLast && uiStack.Count > 0)
        {
            UIWindowBase lastUI = uiStack[uiStack.Count - 1];
            switch (lastUI.windowStatus)
            {
                case UIWindowBase.WindowStatus.Closed:
                case UIWindowBase.WindowStatus.Create:
                    lastUI.Open();
                    lastUI.Show();
                    //播放进入动画
                    lastUI.StartAnim(null, null);
                    break;
                case UIWindowBase.WindowStatus.Hide:
                    lastUI.Show();
                    lastUI.ReStartAnim();
                    break;
                case UIWindowBase.WindowStatus.Opened:
                    lastUI.OnRecoveryTop();
                    break;
                default:
                    break;
            }
            // if (uiStack.Count > 0 && uiStack[uiStack.Count - 1].windowStatus != UIWindowBase.WindowStatus.Opened)
            // {
            //     UIWindowBase lastUI = uiStack[uiStack.Count - 1];
            //     if (!lastUI.gameObject.activeSelf)
            //     {
            //         lastUI.Show();
            //         lastUI.ReStartAnim();
            //     }
            // }
            // else if (uiStack.Count > 0 && uiStack[uiStack.Count - 1].windowStatus != UIWindowBase.WindowStatus.Create)
            // {
            //     UIWindowBase lastUI = uiStack[uiStack.Count - 1];
            //     lastUI.Open();
            //     lastUI.Show();
            //     //播放进入动画
            //     lastUI.StartAnim(null, null);
            //     //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_panel_show);
            // }
        }
    }

    public UIWindowBase GetLastUI(UIType uiType)
    {
        switch (uiType)
        {
            case UIType.Fixed:
                if (m_FixedStack.Count > 0)
                    return m_FixedStack[m_FixedStack.Count - 1];
                else
                    return null;

            case UIType.Normal:
                if (m_NormalStack.Count > 0)
                    return m_NormalStack[m_NormalStack.Count - 1];
                else
                    return null;

            case UIType.PopUp:
                if (m_PopupStack.Count > 0)
                    return m_PopupStack[m_PopupStack.Count - 1];
                else
                    return null;

            case UIType.TopBar:
                if (m_TopBarStack.Count > 0)
                    return m_TopBarStack[m_TopBarStack.Count - 1];
                else
                    return null;
            case UIType.Guide:
                if (m_GuideStack.Count > 0)
                    return m_GuideStack[m_GuideStack.Count - 1];
                else
                    return null;
        }

        throw new System.Exception("CloseLastUIWindow does not support GameUI");
    }
}