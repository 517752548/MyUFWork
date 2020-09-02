using System;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : UIWindowBase
{
    public Image bottomButtonFatherImage;
    public GameObject picDeleteGameobject;
    public Text playerName;

    public Text VersionText, LoginID;
    private GameObject EmailGift;

    public GameObject rateButton, mailButton;
    public Transform tittle, button_team, bottom_Button, buttonlist;

//    public FBSettingUserImage m_settingUserImage;
    public GameObject m_blockEvent;
    public GameObject fbBG;

    public GameObject hlBtn;
    public CommonToggleButton Sound, Music, Notification, SkipFilled, EraWrongWord, SelectFristSolt,HighLightFree;

    public Button facebookButton;

    public GameObject debugBtn;

    private void Start()
    {
        InitToggleButton();
    }

    private void OnEnable()
    {
        InitToggleButton();
        GameAnalyze.SettingReport("Home");
    }

    public override void OnOpen()
    {
        base.OnOpen();
        hlBtn.SetActive(AppEngine.SSystemManager.GetSystem<CellTipABSystem>().CellTipEnable);
        //m_settingUserImage = FbLogin.GetComponent<FBSettingUserImage>();
        m_blockEvent = transform.Find("Content/BlockEvent").gameObject;
        EventDispatcher.AddEventListener(GlobalEvents.HeadChanged, UpdateFacebookBtn);
        //EventDispatcher.AddEventListener(GlobalEvents.FaceBookLoginedSuccessful, UpdateFacebookBtn);
        //EventDispatcher.AddEventListener(GlobalEvents.FaceBookInitOver, UpdateFacebookBtn);
        if (PlatformUtil.GetNotificationState() != 1)
        {
            AppEngine.SGameSettingManager.Notification.Value = false;
        }
        // else
        // {
        //     AppEngine.SGameSettingManager.Notification.Value = true;
        // }

        InitSettingPanel();

        UpdateFacebookBtn();

        if (!PlatformUtil.GetAppIsRelease())
        {
            debugBtn.SetActive(true);
        }
    }

    private void InitView()
    {
        if (XUtils.IsIphoneX())
        {
            tittle.DOBlendableLocalMoveBy(new Vector3(0, 0, 0), 0);
            button_team.DOBlendableLocalMoveBy(new Vector3(0, 0, 0), 0);
            bottom_Button.DOBlendableLocalMoveBy(new Vector3(0, 0, 0), 0);
            buttonlist.DOBlendableLocalMoveBy(new Vector3(0, 0, 0), 0);
        }
    }

    private void InitToggleButton()
    {
        Sound.SetBoolData(AppEngine.SGameSettingManager.Sound);
        Music.SetBoolData(AppEngine.SGameSettingManager.Music);
        Notification.SetBoolData(AppEngine.SGameSettingManager.Notification);
        SkipFilled.SetBoolData(AppEngine.SGameSettingManager.SkipFilledSquares);
        EraWrongWord.SetBoolData(AppEngine.SGameSettingManager.EraseWrongWord);
        SelectFristSolt.SetBoolData(AppEngine.SGameSettingManager.SelectFirstSolt);
        HighLightFree.SetBoolData(AppEngine.SGameSettingManager.MarkFlyCell);
    }

    public void OnMusicClick()
    {
    }

    public void ClickNotification()
    {
        if (PlatformUtil.GetNotificationState() == 1)
        {
            //AppEngine.SGameSettingManager.Notification.Value = true;
            if (!AppEngine.SGameSettingManager.Notification.Value)
            {
                AppEngine.SSystemManager.GetSystem<NotificationSystem>().SendNotification();
            }
            TimersManager.SetTimer(2, () =>
            {
                GameAnalyze.SettingReport("Home","Noti",AppEngine.SGameSettingManager.Notification.Value.ToString());
            });
        }
        else
        {
            Close();
            AppEngine.SGameSettingManager.Notification.Value = false;
            TimersManager.SetTimer(0.3f, () => { UIManager.OpenUIAsync(ViewConst.prefab_PushContinueDialog); });
        }
        
    }

    private void InitSettingPanel()
    {
        InitView();
        SetVersion();
        SetPannelStatus();
    }


    private void SetVersion()
    {
        VersionText.text = string.Format("version {0}", PlatformUtil.GetVersionName());
        LoginID.text = $"ID:{AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value}";
    }


    private void UpdateFacebookBtn()
    {
        Sprite pic = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerFBPic();
        if (pic != null)
        {
            bottomButtonFatherImage.color = Color.white;
            bottomButtonFatherImage.sprite = pic;
            picDeleteGameobject.SetActive(false);
            playerName.text = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value;
            fbBG.SetActive(false);
            facebookButton.image.raycastTarget = false;
        }

//        m_settingUserImage.LoadFbUserPicture();
    }

    private void SetPannelStatus()
    {
        mailButton.SetActive(true);
        RateConfig
            config = PreLoadManager.GetPreLoadConfig<RateConfig>(ViewConst
                .asset_RateConfig_RateConfig); //(RateConfig)commandChannel.PostCommand(ExcelCommandConst.GET_EXCEL_DATA, ViewConst.asset_RateConfig_RateConfig);

        if (config != null && config.dataList[0].IsShown == false)
        {
            rateButton.SetActive(false);
        }
        else
        {
            rateButton.SetActive(true);
        }
    }


    public void ClickSelectHowToPlay()
    {
        if (!ResponseClick) return;
        BlockEvent();
        UIManager.OpenUIAsync(ViewConst.prefab_HowToPlayDialog, OpenType.Stack);
        GameAnalyze.SettingReport("Home","How","1");
//        ReportDataManager.pressHowToPlay();
    }

    public void ClickCommondButton()
    {
        if (!ResponseClick) return;
        SRDebug.Init();
        SRDebug.Instance.ShowDebugPanel();
        Close();
    }

    public void CloseSetting()
    {
        Close();
    }

    public override void OnClose()
    {
        base.OnClose();
        EventDispatcher.RemoveEventListener(GlobalEvents.HeadChanged, UpdateFacebookBtn);
    }

    protected override void OnHide()
    {
        base.OnHide();
        m_blockEvent.SetActive(false);
        m_isBlocking = false;
    }

    public void OnClickShop()
    {
        if (!ResponseClick) return;
        UIManager.OpenUIAsync(ViewConst.prefab_StoreDialog);
        GameAnalyze.SettingReport("Home","Shop","1");
    }

    public void OnClickEmail()
    {
        if (!ResponseClick) return;
        BlockEvent();
        XUtils.SendEmail();
        CloseSetting();
        GameAnalyze.SettingReport("Home","Email","1");
    }

    public void OnClickFAQ()
    {
        if (!ResponseClick) return;
        //buttonlist.GetComponent<HelpShiftController>().ShowHelpShift();
        CloseSetting();
        GameAnalyze.SettingReport("Home","FAQ","1");
    }

    public void OnClickFaceBook()
    {
        if (!ResponseClick) return;
        if (AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value.Length > 0)
        {
            return;
        }

        Close();
        UIManager.OpenUIAsync(ViewConst.prefab_FBSignInDialog);
        GameAnalyze.SettingReport("Home","FB","1");
    }

    public void ClickFanPage()
    {
        Application.OpenURL(Const.FanPage_URL);
        GameAnalyze.SettingReport("Home","FAP","1");
    }

    public void OnClickRestore()
    {
        if (!ResponseClick) return;
        BlockEvent();
        AppEngine.SPurchaserManager.RestorePurchases();
        GameAnalyze.SettingReport("Home","Restore","1");
    }

    public void OnClickGameEmail() {
        if (!ResponseClick) return;
        BlockEvent();
        UIManager.OpenUIAsync(ViewConst.prefab_EmaliSliderDialog);
    }

    public void OnClickRate()
    {
        if (!ResponseClick) return;
        BlockEvent();

        //CommandChannel commandChannel = CommandChannel.GetInstance();
        RateConfig
            config = PreLoadManager.GetPreLoadConfig<RateConfig>(ViewConst
                .asset_RateConfig_RateConfig); //(RateConfig)commandChannel.PostCommand(ExcelCommandConst.GET_EXCEL_DATA, ViewConst.asset_RateConfig_RateConfig);

        if (config != null && config.dataList[0].IsFilterComment)
        {
            //UIManager.OpenUIAsync(UIKeys.RateDialog);
        }
        else
        {
            UIManager.OpenUIAsync(ViewConst.prefab_OldRateDialog, OpenType.Stack);
        }
        GameAnalyze.SettingReport("Home","Rate","1");
    }

    public void RestoreButtonClick()
    {
        if (!ResponseClick) return;
        Close();
        AppEngine.SPurchaserManager.RestorePurchases();
    }


    public void PrivacyPolicyClick()
    {
        if (!ResponseClick) return;
        BlockEvent();
        UIManager.OpenUIAsync(ViewConst.prefab_PrivacyPolicyDialog, OpenType.Stack);
        GameAnalyze.SettingReport("Home","Policy","1");
    }

    public void ClickTestAdBtn()
    {
        if (!ResponseClick) return;
    }

    private bool canOpenMap = true;


    private bool m_isBlocking = false;

    private void BlockEvent()
    {
        if (m_isBlocking) return;
        m_isBlocking = true;
        m_blockEvent.SetActive(true);
        Timer.Schedule(this, 0.5f, () =>
        {
            m_blockEvent.SetActive(false);
            m_isBlocking = false;
        });
    }


    public void ClickCopy()
    {
#if UNITY_IOS
        PlatformIOS.CopyIDToClipBoard(AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value);
#elif UNITY_ANDROID
        PlatformAndroid.CopyTextToClipboard(AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value);
#endif
        UIManager.ShowMessage("Copied Successfully");
        GameAnalyze.SettingReport("Home","Copy","1");
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        //m_settingUserImage.LoadFbUserPicture();
        return base.EnterAnim(objs);
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        return base.ExitAnim(l_callBack, objs);
    }
}