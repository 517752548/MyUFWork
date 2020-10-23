using System;
using System.Collections.Generic;
using app.tips;

public enum WndType
{
    /// <summary>
    /// 主界面，最底层的界面
    /// </summary>
    MAINUI,
    /// <summary>
    /// 一级面板 普通模块窗口，无遮罩
    /// </summary>
    FirstWND,
    /// <summary>
    /// 二级面板 弹出式 信息窗口，无遮罩
    /// </summary>
    SecondWND,
    /// <summary>
    /// 三级面板 弹出框、信息确认窗口（确认信息，确定，取消） 有遮罩
    /// </summary>
    PopWND,
    /// <summary>
    /// tips之类的提示信息
    /// </summary>
    POPTIPS,
    /// <summary>
    /// 冒泡之类的提示信息
    /// </summary>
    BUBBLES,
    /// <summary>
    /// 新手引导
    /// </summary>
    GUIDE,
    /// <summary>
    /// 不可见
    /// </summary>
    INVISIBLE

}

public class WndManager : AbsMonoBehaviour
{
    private static WndManager _ins;
    /// <summary>
    /// 当前显示的窗口
    /// </summary>
    public Dictionary<int, BaseWnd> currentShowWnd;
    
    private Array wndTypes = null;
    
    private List<BaseWnd> mCanDestroyWnds = new List<BaseWnd>();
    
    private List<string> mIgnoreDestroyList = new List<string>();

    public static WndManager Ins
    {
        get
        {
            if (_ins == null)
            {
                //_ins = Singleton.getObj(typeof(WndManager)) as WndManager;
                _ins = new WndManager();
            }
            return _ins;
        }
    }

    public WndManager()
    {
        wndTypes = Enum.GetValues(typeof(WndType));
        mIgnoreDestroyList.Add(GlobalConstDefine.RoleInfoView_Name);
        mIgnoreDestroyList.Add(GlobalConstDefine.PetInfoView_Name);
        mIgnoreDestroyList.Add(GlobalConstDefine.BagView_Name);
        mIgnoreDestroyList.Add(GlobalConstDefine.NpcChatView_Name);
        mIgnoreDestroyList.Add(GlobalConstDefine.PreLoadingView_Name);
    }

    public void initWnd()
    {
    }

    public BaseWnd GetCurrentShowWndByType(WndType wndType)
    {
        if (currentShowWnd!=null&&currentShowWnd.ContainsKey((int)wndType))
        {
            BaseWnd bw;
            currentShowWnd.TryGetValue((int)wndType, out bw);
            return bw;
        }
        return null;
    }

    public void SetCurrentShowWndByType(WndType wndType,BaseWnd basewnd)
    {
        if (currentShowWnd == null )
        {
            currentShowWnd = new Dictionary<int, BaseWnd>();

        }
        currentShowWnd.Remove((int)wndType);
        currentShowWnd.Add((int)wndType,basewnd);
    }

    public void RemoveCurrentShowWndByType(WndType wndType)
    {
        if (currentShowWnd != null)
        {
            currentShowWnd.Remove((int)wndType);
        }
    }

    public bool IsWndShowing(BaseWnd bw)
    {
        if (GetCurrentShowWndByType(bw.UILayer) == bw)
        {
            return true;
        }
        return false;
    }

    public bool IsWndShowing(Type wndClassType)
    {
        if (!Singleton.HasObj(wndClassType))
        {
            return false;
        }
        return IsWndShowing(Singleton.GetObj(wndClassType) as BaseWnd);
    }

    public bool IsWndShowing(string windowName)
    {
        return IsWndShowing(Type.GetType(windowName));
    }

    public static BaseWnd open(String windowName,object data=null)
    {
        if (!GuideManager.Ins.IsWndCanShow(windowName))
        {
            //当前正在显示新手引导
            return null;
        }
        var wnd = Singleton.GetObj(Type.GetType(windowName)) as BaseWnd;
        if (wnd != null)
        {
            wnd.preLoadUI(new RMetaEvent("openWnd",data));
            WndManager.Ins.OnWndOpened(wnd, windowName);
            return wnd;
        }
        return null;
    }

    public BaseWnd close(String windowName, RMetaEvent e = null)
    {
        if (!IsWndShowing(windowName))
        {
            return null;
        }
        var wnd = Singleton.GetObj(Type.GetType(windowName)) as BaseWnd;
        if (wnd != null)
        {
            wnd.hide(e);
            return wnd;
        }
        return null;
    }

    public bool hasWndShowing()
    {
        if (currentShowWnd == null || (currentShowWnd != null && currentShowWnd.Count == 0))
        {
            return false;
        }
        //过滤掉 使用PopUseWnd
        if (currentShowWnd.Count == 1 && currentShowWnd.ContainsKey((int)(WndType.PopWND))
            && currentShowWnd[(int)(WndType.PopWND)]==PopUseWnd.Ins)
        {
            return false;
        }
        return true;
    }

    public override void DoUpdate(float deltaTime)
    {
        if (currentShowWnd == null) return;
        /*
        foreach (KeyValuePair<WndType, BaseWnd> pair in currentShowWnd)
        {
            pair.Value.Update();
        }
        */
        int len = wndTypes.Length;
        for (int i = 0; i < len; i++)
        {
            int wndType = (int)wndTypes.GetValue(i);
            if (currentShowWnd.ContainsKey(wndType))
            {
                currentShowWnd[wndType].DoUpdate(deltaTime);
            }
        }
    }

    public override void Update()
    {
        if (currentShowWnd == null) return;
        /*
        foreach (KeyValuePair<WndType, BaseWnd> pair in currentShowWnd)
        {
            pair.Value.Update();
        }
        */
        int len = wndTypes.Length;
        for (int i = 0; i < len; i++)
        {
            int wndType = (int)wndTypes.GetValue(i);
            if (currentShowWnd.ContainsKey(wndType))
            {
                currentShowWnd[wndType].Update();
            }
        }
    }

    public override void LateUpdate()
    {
        if (currentShowWnd == null) return;
        /*
        foreach (KeyValuePair<WndType, BaseWnd> pair in currentShowWnd)
        {
            pair.Value.LateUpdate();
        }
        */
        int len = wndTypes.Length;
        for (int i = 0; i < len; i++)
        {
            int wndType = (int)wndTypes.GetValue(i);
            if (currentShowWnd.ContainsKey(wndType))
            {
                currentShowWnd[wndType].LateUpdate();
            }
        }
    }

    public override void FixedUpdate()
    {
        if (currentShowWnd == null) return;
        /*
        foreach (KeyValuePair<WndType, BaseWnd> pair in currentShowWnd)
        {
            pair.Value.FixedUpdate();
        }
        */
        int len = wndTypes.Length;
        for (int i = 0; i < len; i++)
        {
            int wndType = (int)wndTypes.GetValue(i);
            if (currentShowWnd.ContainsKey(wndType))
            {
                currentShowWnd[wndType].FixedUpdate();
            }
        }
    }

    /// <summary>
    /// 关闭所有当前显示的面板
    /// </summary>
    public void HideAllCurrentShowWnd()
    {
        if (currentShowWnd!=null)
        {
            List<int> keyList = new List<int>();
            foreach (KeyValuePair<int, BaseWnd> pair in currentShowWnd)
            {
                keyList.Add(pair.Key);
            }
            for (int i=0;i<keyList.Count;i++)
            {
                BaseWnd basewnd;
                currentShowWnd.TryGetValue(keyList[i], out basewnd);
                if (basewnd!=null &&!(basewnd is PopUseWnd))
                {
                    basewnd.hide();
                }
            }
        }
    }

    /// <summary>
    /// 关闭所有当前显示的面板，除了给出列表里的
    /// </summary>
    public void HideAllCurrentShowWndExcept(List<string> wndName)
    {
        if (currentShowWnd != null)
        {
            List<BaseWnd> wndList=new List<BaseWnd>();
            for (int i=0;i<wndName.Count;i++)
            {
                if (Singleton.HasObj(Type.GetType(wndName[i])))
                {
                    BaseWnd wnd = Singleton.GetObj(Type.GetType(wndName[i])) as BaseWnd;
                    if (wnd != null)
                    {
                        wndList.Add(wnd);
                    }
                }
            }
            List<BaseWnd> showWndList = new List<BaseWnd>();
            foreach (KeyValuePair<int, BaseWnd> pair in currentShowWnd)
            {
                showWndList.Add(pair.Value);
            }
            for (int i = 0; i < showWndList.Count; i++)
            {
                if (!wndList.Contains(showWndList[i]))
                {
                    showWndList[i].hide();
                }
            }
        }
    }

    public void OnWndOpened(BaseWnd wnd, string windowName)
    {
        if (!mIgnoreDestroyList.Contains(windowName))
        {
            if (wnd != null && !mCanDestroyWnds.Contains(wnd))
            {
                mCanDestroyWnds.Add(wnd);
            }
        }
    }

    public void AddIgnoreDestroyWnd(string wndname)
    {
        if (!mIgnoreDestroyList.Contains(wndname))
        {
            mIgnoreDestroyList.Add(wndname);
        }
    }

    public void RemoveIgnoreDestroyWnd(string wndname)
    {
        if (mIgnoreDestroyList.Contains(wndname))
        {
            mIgnoreDestroyList.Remove(wndname);
        }
    }

    public void DestroyUnusedWnds()
    {
        int len = mCanDestroyWnds.Count;
        for (int i = 0; i < len; i++)
        {
            BaseWnd wnd = mCanDestroyWnds[i];
            if (wnd.isHidden)
            {
                wnd.Destroy();
                mCanDestroyWnds[i] = null;
                mCanDestroyWnds.RemoveAt(i);
                i--;
                len--;
            }
        }
    }
}