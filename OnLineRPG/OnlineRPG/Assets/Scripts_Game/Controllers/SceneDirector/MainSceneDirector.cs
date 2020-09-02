using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using EventUtil;
using UnityEngine;


public class MainSceneDirector : MonoBehaviour
{
    public static MainSceneDirector Instance
    {
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
        GameAnalyze.LogLoading("15", Time.realtimeSinceStartup.ToString());
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
            SwitchUi(GameUI.Home, null);
        }

        if (Record.GetInt("AFBack", 0) == 0)
        {
            EventDispatcher.AddEventListener(GlobalEvents.AFBack,CheckAOE);
        }
        CheckAOE();
    }

    private void CheckAOE()
    {
        if (DataManager.ProcessData.IsAOE)
        {
            Debug.Log("安装时间:" + AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerInstallHours());
            //新用户
            if (AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerInstallHours() < 24)
            {
                StartCoroutine(AOEPlayerReport());
            }
        }
    }

    private IEnumerator AOEPlayerReport()
    {
        int minutes = Record.GetInt("AOEMin", 0);
        while (minutes < 1440)
        {
            minutes++;
            Record.SetInt("AOEMin", minutes);
            AOEReport.ReportOnLine(minutes);
            yield return new WaitForSeconds(60);
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
    public void SwitchUi(GameUI UiToSwitch, Action<bool> callback)
    {
        Debug.Log(UiToSwitch);
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
    /// <summary>
    /// 在home场景
    /// </summary>
    /// <returns></returns>
    public bool IsInHome() {
        return _currentUi == GameUI.Home;
    }
    /// <summary>
    /// 在game场景
    /// </summary>
    /// <returns></returns>
    public bool IsInGame() {
        return _currentUi == GameUI.Game;
    }
}

public enum GameUI
{
    Home,
    Game
}