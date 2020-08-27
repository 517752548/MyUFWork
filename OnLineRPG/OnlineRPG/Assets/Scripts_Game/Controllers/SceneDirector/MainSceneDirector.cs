using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;


public class MainSceneDirector : MonoBehaviour
{
    public static MainSceneDirector Instance {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<MainSceneDirector>();
            }

            return _Instance;
        }
}
    public BaseRoot[] roots;

    private GameUI _currentUi;

    private GameObject Loading;
    private static MainSceneDirector _Instance = null;
    private void Start()
    {
        InitRoots();
        if (DataManager.ProcessData.firstGoToGameScene)
        {
            if (DataManager.ProcessData.cancelFirstGoToGameScene)
            {
                SwitchUi(GameUI.Home, null); 
                DataManager.ProcessData.firstGoToGameScene = false;
                DataManager.ProcessData.cancelFirstGoToGameScene = false;
                UIManager.CloseUIWindow(
                    UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow)); 
                return;
            }
            SwitchUi(GameUI.Game, ok =>
            {
                DataManager.ProcessData.firstGoToGameScene = false;
                UIManager.CloseUIWindow(
                    UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
            });

        }
        else
        {
            SwitchUi(GameUI.Home,null); 
        }
        
    }

    private void InitRoots()
    {
        for (int i = 0; i < roots.Length; i++)
        {
            roots[i].Init();
        }
    }
    /// <summary>
    /// 切换UI
    /// </summary>
    public void SwitchUi(GameUI UiToSwitch,Action<bool> callback)
    {
        ShowLoading();
        GetUIRoot(_currentUi)?.Hidden();
        GetUIRoot(UiToSwitch)?.Show(callback);
        _currentUi = UiToSwitch;
        AppEngine.SwitchUI(UiToSwitch);
        HiddenLoading();
    }

    /// <summary>
    /// 显示loading
    /// </summary>
    private void ShowLoading()
    {
        // GameObject loadingGameObject =
        //     PreLoadManager.GetPreLoad<GameObject>(PreLoadConst.preload_Prefab, ViewConst.prefab_ChristmasmapLoading);
        //Loading = Instantiate(loadingGameObject);
    }

    /// <summary>
    /// 隐藏loading
    /// </summary>
    private void HiddenLoading()
    {
        if (Loading != null)
        {
            Destroy(Loading);
        }
    }

    /// <summary>
    /// 获取某个root
    /// </summary>
    /// <param name="UiRoot"></param>
    /// <returns></returns>
    public BaseRoot GetUIRoot(GameUI UiRoot)
    {
        for (int i = 0; i < roots.Length; i++)
        {
            if (roots[i]._UiType == UiRoot)
            {
                return roots[i];
            }
        }
        return null;
    }

    public BaseRoot GetVisibleRoot()
    {
        for (int i = 0; i < roots.Length; i++)
        {
            if (roots[i].IsVisible())
            {
                return roots[i];
            }
        }
        return null;
    }
}

public enum GameUI
{
    Home,
    Game
}