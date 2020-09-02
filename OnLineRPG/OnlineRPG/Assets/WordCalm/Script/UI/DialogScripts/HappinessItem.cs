using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;

public class HappinessItem : MonoBehaviour
{
    public GameObject locked;
    public GameObject unlocked;
    public GameObject grayStars;
    public GameObject yellowStars;
    public GameObject yelloBG;
    public GameObject grayBG;
    public GameObject passedRight;
    public TextMeshProUGUI idText;
    public GameObject[] grayStar;
    public GameObject[] redStar;
    public HappinessSelectDialog _SelectDialog;
    EliteWorld config;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetDialog(HappinessSelectDialog _SelectDialog, int index, EliteWorld config)
    {
        this._SelectDialog = _SelectDialog;
        this.index = index;
        this.config = config;
        RefreshUI();
    }

    private void RefreshUI()
    {
        idText.text = (index + 1).ToString();
        string levelstatus = AppEngine.SyncManager.Data.Elitedata.Value.GetElitePref(config.id).levelStatus;
        int stars = CommUtil.GetLevelStar(config.stars[index]);
        if (levelstatus[index] == '0')
        {
            Locked(stars);
        }
        else
        {
            if (levelstatus[index] == '1')
            {
                UnLocked(stars,false);
            }
            else
            {
                UnLocked(stars,true);
            }
            
        }

        
        
    }

    private void Locked(int star)
    {
        locked.SetActive(true);
        unlocked.SetActive(false);
        grayStars.SetActive(true);
        yellowStars.SetActive(false);
        SetStar(star);
    }

    private void UnLocked(int star,bool finish)
    {
        locked.SetActive(false);
        unlocked.SetActive(true);
        grayStars.SetActive(!finish);
        yellowStars.SetActive(finish);
        SetStar(star);
    }

    private void SetStar(int star)
    {
        for (int i = 0; i < grayStar.Length; i++)
        {
            if (i >= star)
            {
                grayStar[i].SetActive(false);
            }
        }

        for (int i = 0; i < redStar.Length; i++)
        {
            if (i >= star)
            {
                redStar[i].SetActive(false);
            }
        }
    }

    public void Click()
    {
        AppEngine.SSystemManager.GetSystem<EliteSystem>().currentLevelID = index + 1;
        char status = AppEngine.SyncManager.Data.Elitedata.Value
            .GetElitePref(AppEngine.SSystemManager.GetSystem<EliteSystem>().currentWordID).levelStatus[index];
        if (status == '0')
        {
            Action<bool> callback = CallBack;
            UIManager.OpenUIAsync(ViewConst.prefab_EliteLevelUnlockDialog, null, callback);
        }
        else
        {
            _SelectDialog.Close();
            TimersManager.SetTimer(0.1f, () => { EnterEliteLevel(); });
        }
    }

    private void CallBack(bool select)
    {
        if (select)
        {
            _SelectDialog.Close();
            TimersManager.SetTimer(0.1f, () => { EnterEliteLevel(); });
        }
    }

    public void EnterEliteLevel()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, OpenType.Replace, (ui, para) =>
        {
            DataManager.ProcessData._GameMode = GameMode.Elite;
            AppEngine.SSystemManager.GetSystem<EliteSystem>().LoadEliteLevel(ok =>
            {
                if (ok)
                {
                    MainSceneDirector.Instance.SwitchUi(GameUI.Game, ok2 =>
                    {
                        UIManager.CloseUIWindow(
                            UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
                    });
                }
                else
                {
                    UIManager.CloseUIWindow(
                        UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
                    TimersManager.SetTimer(0.5f, () =>
                    {
                        UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, null);
                        ;
                    });
                }
            });
        });
    }
}