using EventUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour {
    public Button btn;
	
	void Start () {
//        KeyEventManager.Instance.AddBackPressListener(KeyEventManager.Priority.normal, onBackPressed);
        if (btn == null)
        {
            btn = transform.GetChild(0).gameObject.GetComponent<Button>();
            if (btn == null)
            {
                btn = transform.GetChild(0).gameObject.AddComponent<Button>();
            }
        }
        btn.onClick.AddListener(OnClick);
	}

    private void OnDestroy()
    {
        KeyEventManager.Instance.RemoveBackPressListener(KeyEventManager.Priority.normal, onBackPressed);
    }

    private bool onBackPressed()
    {
        OnClick();
        return true;
    }

    public void OnClick()
    {
        ButtonCD.DoButtonCD(btn, 1.5f);

        //if (LevelMaster.instance != null)
        //{
        //LevelMaster.instance.gamePtr.UpLoadNotLevelPassEvent();
        //}
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
//            case WordScene.MainScene:
//            case WordScene.WeekRankPlayScene:
//                if (DataManager.LevelData.gameMode == LevelData.GameMode.Pve)
//                {
//                    DataManager.ProcessData.ToPage = HomeSceneCtrl.Page_Event;
//                    DataManager.ProcessData.AutoShowPveTournamey = true;
//                }
////                AppFacade.Instance.GetSceneLoadManager().LoadSceneAsync(WordScene.MainScene, LoadSceneMode.Single, UIPrefabName.LoadingPrefab);
//                break;

//            case WordScene.DailyGameScene:
//                DataManager.ProcessData.IntoMapShowDailyPanel = true;
//                AppFacade.Instance.GetSceneLoadManager().LoadSceneAsync(WordScene.LoginScene, LoadSceneMode.Single, UIPrefabName.LoadingPrefab);
//                break;
//        }
//        CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_entergame);
            //ReportDataManager.ClickSettingBottom(type);
            //EventDispatcher.TriggerEvent(GlobalEvents.SettingPanelBottomButtonClick);
        }
    }
}
