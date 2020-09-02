using BetaFramework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

[RequireComponent(typeof(UIStackManager))]
[RequireComponent(typeof(UILayerManager))]
public class UIManager : IModule
{
    private static GameObject s_UIManagerGo;
    private static UILayerManager s_UILayerManager; //UI层级管理器
    private static UIStackManager s_UIStackManager; //UI栈管理器

    private static readonly Dictionary<string, GameObject> s_AnsyGameObjects = new Dictionary<string, GameObject>();

    //public static Camera s_UIcamera;               //UICamera

    public static Dictionary<string, List<UIWindowBase>> s_UIs = new Dictionary<string, List<UIWindowBase>>(); //打开的UI

    public static Dictionary<string, List<UIWindowBase>>
        s_hideUIs = new Dictionary<string, List<UIWindowBase>>(); //隐藏的UI

    private static int LoadingCount = 0;
    private static GameObject LoadingGameObject;


    //toast面板队列
    private static Queue<ToastInfo> ToastQueue = new Queue<ToastInfo>();

    #region 初始化

    private static bool isInit;

    private static void CreatUiManager()
    {
        GameObject instance = null;
        instance = GameObject.Find("UIManager");
        if (instance != null)
        {
            UIManagerGo = instance;
            s_UILayerManager = instance.GetComponent<UILayerManager>();
            s_UIStackManager = instance.GetComponent<UIStackManager>();
            isInit = true;
            LoadingGameObject = GameObject.Find("UIManager/DefaultUI/TopBar/Loading");
        }

        // if (!isInit)
        // {
        //     m_ResourceManager.LoadAssetAsync<GameObject>(ViewConst.prefab_UIManager, false,
        //         (id, o) =>
        //         {
        //             instance = Object.Instantiate(o);
        //             instance.name = "UIManager";
        //             UIManagerGo = instance;
        //             s_UILayerManager = instance.GetComponent<UILayerManager>();
        //             s_UIStackManager = instance.GetComponent<UIStackManager>();
        //             isInit = true;
        //             LoadingGameObject = GameObject.Find("UIManager/DefaultUI/TopBar/Loading");
        //             //m_ResourceManager.UnloadAssetBundle(ViewConst.prefab_UIManager);
        //         });
        // }
    }

    public override void Init()
    {
        CreatUiManager();
    }

    public static UILayerManager UILayerManager
    {
        get
        {
            if (s_UILayerManager == null)
            {
                CreatUiManager();
            }

            return s_UILayerManager;
        }

        set { s_UILayerManager = value; }
    }

    public static UIStackManager UIStackManager
    {
        get
        {
            if (s_UIStackManager == null)
            {
                CreatUiManager();
            }

            return s_UIStackManager;
        }

        set { s_UIStackManager = value; }
    }

    public static GameObject UIManagerGo
    {
        get
        {
            if (s_UIManagerGo == null)
            {
                CreatUiManager();
            }

            return s_UIManagerGo;
        }

        set { s_UIManagerGo = value; }
    }

    #endregion 初始化


    #region UICamera

    public static string[] GetCameraNames()
    {
        string[] list = new string[UILayerManager.UICameraList.Count];

        for (int i = 0; i < UILayerManager.UICameraList.Count; i++)
        {
            list[i] = UILayerManager.UICameraList[i].m_key;
        }

        return list;
    }

    public static Camera GetCamera(string CameraKey = null)
    {
        var data = UILayerManager.GetUICameraDataByKey(CameraKey);
        return data.m_camera;
    }

    /// <summary>
    /// 将一个UI移动到另一个UICamera下
    /// </summary>
    /// <param name="ui"></param>
    /// <param name="cameraKey"></param>
    public static void ChangeUICamera(UIWindowBase ui, string cameraKey)
    {
        UILayerManager.SetLayer(ui, cameraKey);
    }

    /// <summary>
    /// 将一个UI重新放回它原本的UICamera下
    /// </summary>
    /// <param name="ui"></param>
    /// <param name="cameraKey"></param>
    public static void ResetUICamera(UIWindowBase ui)
    {
        UILayerManager.SetLayer(ui, ui.cameraKey);
    }

    #endregion UICamera

    #region UI的打开与关闭方法

    private static UIWindowBase CreateUIWindow(string UIName)
    {
        Transform UItmp = Object.Instantiate(s_AnsyGameObjects[UIName]).transform;
        UItmp.name = UIName;
        UIWindowBase UIbase = UItmp.GetComponent<UIWindowBase>();

        UIbase.windowStatus = UIWindowBase.WindowStatus.Create;

        UIbase.Init(GetUIID(UIName));

        UILayerManager.SetLayer(UIbase); //设置层级

        return UIbase;
    }

    /// <summary>
    /// 打开UI
    /// </summary>
    /// <param name="UIName">UI名</param>
    /// <param name="callback">动画播放完毕回调</param>
    /// <param name="objs">回调传参</param>`
    /// <returns>返回打开的UI</returns>
    public static UIWindowBase OpenUIWindow(string UIName, UICallBack displayCallback = null,
        UISimpleCallBack closeCallback = null, UISimpleCallBack openCallback = null,
        OpenType openType = OpenType.Stack, params object[] objs)
    {
        UIWindowBase UIbaseTop = GetUI(UIName);
        if (UIbaseTop != null && !UIbaseTop.HaveDataChange(objs))
        {
            return UIbaseTop;
        }

        UIWindowBase UIbase = GetHideUI(UIName);

        if (UIbase == null)
        {
            UIbase = CreateUIWindow(UIName);
        }
        else
        {
            RemoveHideUI(UIbase);
        }
        openCallback?.Invoke(UIbase);
        EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.OpenUI, UIName);

        UIbase.objs = objs;
        UIbase.m_CloseCallback = closeCallback;
        AddUI(UIbase);

        UIStackManager.OnUIOpen(UIbase, openType);
        UILayerManager.SetLayer(UIbase); //设置层级
        UIbase.uiName = UIName;
        if (openType != OpenType.Queue || GetNormalUICount() == 1)
        {
            try
            {
                UIbase.Open();
                UIbase.Show();
            }
            catch (Exception e)
            {
                Debug.LogError(UIName + " OnOpen Exception: " + e.ToString());
            }

            //播放进入动画
            UIbase.StartAnim(displayCallback, objs);
            //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_panel_show);
        }

        return UIbase;
    }

    /// <summary>
    /// 关闭UI
    /// </summary>
    /// <param name="UI">目标UI</param>
    /// <param name="isPlayAnim">是否播放关闭动画</param>
    /// <param name="callback">动画播放完毕回调</param>
    /// <param name="objs">回调传参</param>
    public static void CloseUIWindow(UIWindowBase UI, bool isPlayAnim = true, UICallBack callback = null,
        params object[] objs)
    {
        if (UI.windowStatus != UIWindowBase.WindowStatus.Opened)
            return;

        if (isPlayAnim)
        {
            //动画播放完毕删除UI
            if (callback != null)
            {
                callback += CloseUIWindowCallBack;
            }
            else
            {
                callback = CloseUIWindowCallBack;
            }

            UI.windowStatus = UIWindowBase.WindowStatus.Closing;
            UI.StartExitAnim(callback, objs);
        }
        else
        {
            UI.OnCompleteExitAnim();
            CloseUIWindowCallBack(UI, objs);
        }
    }

    private static void CloseUIWindowCallBack(UIWindowBase UI, params object[] objs)
    {
        UI.windowStatus = UIWindowBase.WindowStatus.Closed;
        try
        {
            UI.Hide();
            UI.OnClose();
        }
        catch (Exception e)
        {
            LoggerHelper.Error(UI.UIName + " OnClose Exception: " + e.ToString());
        }

        UIStackManager.OnUIClose(UI);
        if (GetIsExits(UI))
        {
            RemoveUI(UI);
        }

        if (UI.ReUse)
        {
            AddHideUI(UI);
        }
    }

    public static void CloseAll()
    {
        foreach (var list in s_UIs.Values)
        {
            list.ForEach(w =>
            {
                s_UIStackManager.OnUIClose(w, false);
                try
                {
                    w.DestroyUi();
                }
                catch (Exception e)
                {
                    Debug.LogError("CloseAll OnDestroy :" + e.ToString());
                }

                Object.Destroy(w.gameObject);
            });
        }
        s_UIs.Clear();
    }

    #endregion UI的打开与关闭方法

    #region UI的打开与关闭 异步方法

    public static void OpenUIAsync(string UIName, UICallBack callback = null, params object[] objs)
    {
        Debug.Log("OpenUIAsync " + UIName);
        ResourceManager.LoadAsync<GameObject>(UIName, (obj) =>
        {
            if (obj == null)
            {
                LoggerHelper.Error(string.Format("找不到:{0}", UIName));
            }
            else
            {
                s_AnsyGameObjects[UIName] = obj;
                OpenUIWindow(UIName, callback, null, null, OpenType.Stack, objs);
            }
        });
    }

    public static void OpenUIAsync(string UIName, OpenType type, UICallBack callback = null, params object[] objs)
    {
        Debug.Log("OpenUIAsync " + UIName);
        ResourceManager.LoadAsync<GameObject>(UIName,
            (obj) =>
            {
                if (obj == null)
                {
                    LoggerHelper.Error(string.Format("找不到:{0}", UIName));
                }
                else
                {
                    s_AnsyGameObjects[UIName] = obj;
                    OpenUIWindow(UIName, callback, null, null, type, objs);
                }
            });
    }

    public static void OpenUIAsync(string UIName, OpenType type, UISimpleCallBack closeCallback, UISimpleCallBack openCallback = null, UICallBack displayCallback = null, params object[] objs)
    {
        Debug.Log("OpenUIAsync " + UIName);
        ResourceManager.LoadAsync<GameObject>(UIName,
            (obj) =>
            {
                if (obj == null)
                {
                    LoggerHelper.Error(string.Format("找不到:{0}", UIName));
                }
                else
                {
                    s_AnsyGameObjects[UIName] = obj;
                    OpenUIWindow(UIName, displayCallback, closeCallback, openCallback, type, objs);
                }
            });
    }

    public static T GetWindow<T>(string UIName) where T : UIWindowBase
    {
        if (s_UIs.ContainsKey(UIName) && s_UIs[UIName].Count > 0)
        {
            return s_UIs[UIName][s_UIs[UIName].Count - 1] as T;
        }

        return null;
    }


    public static void ShowMessage(string message, float time = 1.2f,
        ToastPositionEnum positionEnum = ToastPositionEnum.middle)
    {
        ToastInfo toastInfo = new ToastInfo();
        toastInfo.message = message;
        toastInfo.positionEnum = positionEnum;
        toastInfo.time = time;
        if (!ToastWindow.isMessageShowing)
        {
            ToastWindow.isMessageShowing = true;
            OpenUIAsync(ViewConst.prefab_ToastWindow, null, toastInfo);
        }
        else
        {
            ToastQueue.Enqueue(toastInfo);
        }
    }

    public static void CloseMessage()
    {
        ToastWindow.isMessageShowing = false;
        if (ToastQueue.Count > 0)
        {
            ToastInfo toastInfo = ToastQueue.Dequeue();
            ToastWindow.isMessageShowing = true;
            OpenUIAsync(ViewConst.prefab_ToastWindow, null, toastInfo);
        }
    }

    #endregion UI的打开与关闭 异步方法

    #region UI内存管理

    public static void DestroyUI(UIWindowBase UI)
    {
        Debug.Log("UIManager DestroyUI " + UI.name);

        if (GetIsExitsHide(UI))
        {
            RemoveHideUI(UI);
        }
        else if (GetIsExits(UI))
        {
            RemoveUI(UI);
        }

        try
        {
            UI.DestroyUi();
        }
        catch (Exception e)
        {
            Debug.LogError("OnDestroy :" + e.ToString());
        }

        Object.Destroy(UI.gameObject);
    }

    public static void PreloadUI(string UIName)
    {
        ResourceManager.LoadAsync<GameObject>(UIName,
            (obj) =>
            {
                if (obj == null)
                {
                    LoggerHelper.Error(string.Format("找不到:{0}", UIName));
                }
                else
                {
                    s_AnsyGameObjects[UIName] = obj;
                }
            });
    }

    #endregion UI内存管理

    #region 打开UI列表的管理

    public static UIWindowBase GetUI(string UIname)
    {
        if (!s_UIs.ContainsKey(UIname))
        {
            return null;
        }
        else
        {
            if (s_UIs[UIname].Count == 0)
            {
                return null;
            }
            else
            {
                //默认返回最后创建的那一个
                return s_UIs[UIname][s_UIs[UIname].Count - 1];
            }
        }
    }

    /// <summary>
    /// 这个ui是否打开了
    /// </summary>
    /// <param name="UI"></param>
    /// <returns></returns>
    public static bool GetIsExits(UIWindowBase UI)
    {
        if (!s_UIs.ContainsKey(UI.name))
        {
            return false;
        }
        else
        {
            return s_UIs[UI.name].Contains(UI);
        }
    }

    private static void AddUI(UIWindowBase UI)
    {
        if (!s_UIs.ContainsKey(UI.name))
        {
            s_UIs.Add(UI.name, new List<UIWindowBase>());
        }

        s_UIs[UI.name].Add(UI);
    }

    public static void RemoveUI(UIWindowBase UI)
    {
        if (UI == null)
        {
            throw new Exception("UIManager: RemoveUI error l_UI is null: !");
        }

        if (!s_UIs.ContainsKey(UI.name))
        {
            throw new Exception("UIManager: RemoveUI error dont find UI name: ->" + UI.name + "<-  " + UI);
        }

        if (!s_UIs[UI.name].Contains(UI))
        {
            throw new Exception("UIManager: RemoveUI error dont find UI: ->" + UI.name + "<-  " + UI);
        }
        else
        {
            s_UIs[UI.name].Remove(UI);
        }
    }

    private static int GetUIID(string UIname)
    {
        if (!s_UIs.ContainsKey(UIname))
        {
            return 0;
        }
        else
        {
            int id = s_UIs[UIname].Count;

            for (int i = 0; i < s_UIs[UIname].Count; i++)
            {
                if (s_UIs[UIname][i].UIID == id)
                {
                    id++;
                    i = 0;
                }
            }

            return id;
        }
    }

    public static int GetNormalUICount()
    {
        return UIStackManager.ListNormalWindow.Count;
    }

    #endregion 打开UI列表的管理

    #region 隐藏UI列表的管理

    /// <summary>
    /// 获取一个隐藏的UI,如果有多个同名UI，则返回最后创建的那一个
    /// </summary>
    /// <param name="UIname">UI名</param>
    /// <returns></returns>
    public static UIWindowBase GetHideUI(string UIname)
    {
        if (!s_hideUIs.ContainsKey(UIname))
        {
            return null;
        }
        else
        {
            if (s_hideUIs[UIname].Count == 0)
            {
                return null;
            }
            else
            {
                UIWindowBase ui = s_hideUIs[UIname][s_hideUIs[UIname].Count - 1];
                //默认返回最后创建的那一个
                return ui;
            }
        }
    }

    private static bool GetIsExitsHide(UIWindowBase UI)
    {
        if (!s_hideUIs.ContainsKey(UI.name))
        {
            return false;
        }
        else
        {
            return s_hideUIs[UI.name].Contains(UI);
        }
    }

    public static void AddHideUI(UIWindowBase UI)
    {
        if (!s_hideUIs.ContainsKey(UI.name))
        {
            s_hideUIs.Add(UI.name, new List<UIWindowBase>());
        }

        s_hideUIs[UI.name].Add(UI);

        UI.Hide();
    }

    private static void RemoveHideUI(UIWindowBase UI)
    {
        if (UI == null)
        {
            throw new Exception("UIManager: RemoveUI error l_UI is null: !");
        }

        if (!s_hideUIs.ContainsKey(UI.name))
        {
            throw new Exception("UIManager: RemoveUI error dont find: " + UI.name + "  " + UI);
        }

        if (!s_hideUIs[UI.name].Contains(UI))
        {
            throw new Exception("UIManager: RemoveUI error dont find: " + UI.name + "  " + UI);
        }
        else
        {
            s_hideUIs[UI.name].Remove(UI);
        }
    }

    #endregion 隐藏UI列表的管理


    #region Loading

    public static void ShowLoading()
    {
        LoadingCount++;
        if (LoadingGameObject)
            LoadingGameObject.SetActive(true);
    }

    public static void CloseLoading()
    {
        LoadingCount--;
        if (LoadingCount <= 0)
        {
            LoadingCount = 0;
            if (LoadingGameObject)
                LoadingGameObject.SetActive(false);
        }
    }

    #endregion

    #region GuideUi

    /// <summary>
    /// 展示新手引导
    /// </summary>
    /// <param name="guideUIRes"></param>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    public static void ShowGuideUI<T>(string guideUIRes, params object[] obj) where T : BaseGuideUi
    {
        OpenUIAsync(guideUIRes, ((ui, objs) =>
        {
            BaseGuideUi guide = ui as BaseGuideUi;
            guide.SetGuideElement(obj);
        }));
    }

    #endregion
}

#region UI事件 代理 枚举

/// <summary>
/// UI回调
/// </summary>
/// <param name="objs"></param>
public delegate void UICallBack(UIWindowBase UI, params object[] objs);

public delegate void UISimpleCallBack(UIWindowBase UI);


public enum UIType
{
    GameUI,
    Fixed,
    Normal,
    TopBar,
    PopUp,
    Guide
}

public enum OpenType
{
    Replace,
    Stack,
    Over,
    Queue
}

#endregion UI事件 代理 枚举