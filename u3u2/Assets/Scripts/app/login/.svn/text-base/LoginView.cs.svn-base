using System.Collections.Generic;
using app.utils;
using app.zone;
using UnityEngine;
using app.model;
using app.state;
using app.battle;
using UnityEngine.UI;
using app.main;
using app.config;
using app.report;

namespace app.login
{
    internal class LoginView : BaseWnd
    {
        //[Inject(ui = "loginpanel")]
        //public GameObject ui;

        public LoginModel model;
        public PlayerModel playerModel;

        public InputField zhanghaoInputText;
        public InputField mimaInputText;

        public LoginUI UI;
        private RTimer cdTimer;
        
        public LoginView()
        {
            useTween = false;
            isShowBgMask = false;
            uiName = "loginpanel";
        }

        public override void initWnd()
        {
            base.initWnd();
            model = LoginModel.Ins;
            playerModel = PlayerModel.Ins;
            //playerModel.addChangeEvent(PlayerModel.ENTER_SCENE, enterScene);

            EventCore.addRMetaEventListener(GlobalConstDefine.PRINT_LOGIN_LOG, SetLogText);
            //UI = ui.GetComponent<LoginUI>();
            UI = ui.AddComponent<LoginUI>();
            UI.Init();

            //UI.bg.sprite = GameObject.Find("InitCanvas/InitView/uiContainer/Image").GetComponent<Image>().sprite;
            UI.buttonText.text = "";
            UI.logText.text = "";
            //EventTriggerListener.Get(UI.loginBtn.gameObject).onClick = changeserver;
            UI.loginBtn.SetClickCallBack(loginGame);
            zhanghaoInputText = CreateInputField(Color.white, 20, UI.zhanghaoBg);
            //zhanghaoInputText.text = initZhangHao();
            mimaInputText = CreateInputField(Color.white, 20, UI.mimaBg, false, InputField.InputType.Password);
            //mimaInputText.text = initMiMa();
            InitZhangHaoMiMa();

        }

        public override void show(RMetaEvent e = null)
        {
            base.show();
            //移除游戏默认图片
            //UGUIConfig.RemoveGameDefaultImage();

            ClientLog.Log("LoginView show!");

            //SourceManager.Ins.ignoreDispose(PathUtil.Ins.GetUIEffectPath("guangquan"));
            //SourceLoader.Ins.load(PathUtil.Ins.GetUIEffectPath("guangquan"));

            //UI.logText.text = "屏幕分辨率：" + UGUIConfig.ScreenWidth + " * " + UGUIConfig.ScreenHeight;
            //UI.logText.gameObject.SetActive(false);

            DataReport.Instance.Game_SetEventBeforeLogin("c_shown", "view", "login");

            AudioManager.Ins.PlayAudio(ClientConstantDef.LOGIN_BG_MUSIC_NAME, AudioEnumType.BackGround);

            if (!string.IsNullOrEmpty(GameClient.ins.shortcut))
            {
                loginGame(UI.loginBtn.gameObject);
            }
            
        }

        private void InitZhangHaoMiMa()
        {
            PlayerData accountData = PlayerDataManager.Ins.GetPlayerData(PlayerDataKeyDef.ACCOUNT_DATA);
            string uname = accountData.getData(PlayerDataKeyDef.ACCOUNT_DATA_NAME);
            string upwd = accountData.getData(PlayerDataKeyDef.ACCOUNT_DATA_PWD);
            if (string.IsNullOrEmpty(uname))
            {
                if (ClientConfig.Ins.debug)
                {
                    int i = Random.Range(1, 1000);
                    uname = "test" + i;
                }
                else
                {
                    uname = "";
                }
            }
            //本地测试用的登录名
            /*
            if (!string.IsNullOrEmpty(ClientConfig.Ins.LoginName))
            {
                uname = ClientConfig.Ins.LoginName;
            }
            */
            if (string.IsNullOrEmpty(upwd))
            {
                upwd = "";
            }

            zhanghaoInputText.text = uname;
            mimaInputText.text = upwd;
        }

        private bool checkInput()
        {
            string str = zhanghaoInputText.text;
            string upwd = mimaInputText.text;
            if (string.IsNullOrEmpty(str))
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请输入用户名!");
                return false;
            }
            if (string.IsNullOrEmpty(upwd))
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请输入密码!");
                return false;
            }
            return true;
        }

        public void loginGame(GameObject go)
        {
            string uname = zhanghaoInputText.text;
            string upwd = mimaInputText.text;
            if (checkInput())
            {
                if (cdTimer == null)
                {
                    cdTimer = TimerManager.Ins.createTimer(1000, 30000, OnCdTimer, cdEnd);
                    cdTimer.start();
                    if (UI.loginBtn.IsInteractable())
                    {
                        UI.loginBtn.interactable = false;
                        ColorUtil.Gray(UI.loginBtn);
                    }
                }
                else
                {
                    return;
                }
                /*
                PlayerPrefs.SetString(PlayerDataKeyDef.ACCOUNT_DATA_NAME, uname);
                PlayerPrefs.SetString(PlayerDataKeyDef.ACCOUNT_DATA_PWD, upwd);
                */
                //int screenW = Screen.width;
                //int screenH = Screen.height;

                int screenW = UGUIConfig.ZoneViewportWidth;
                int screenH = UGUIConfig.ZoneViewportHeight;
                string source = "{\"deviceID\":\"" + ReYun.Instance.Game_GetDeviceID() +
                                "\",\"channelName\":\"renren\",\"fromServerId\":\"" + ServerConfig.instance.serverId + "\",\"clientVersion\":\"local\",\"source\":\"" + ReYun.Instance.Game_GetDeviceType() + "\",\"clientLanguage\":\"CN\",\"otherPlatformLogin\":\"\",\"deviceVersion\":\"-1\",\"screenWidth\":\"" +
                                screenW + "\",\"screenHeight\":\"" + screenH + "\"}";
                model.doLogin(uname, upwd, source);
            }
        }

        private void OnCdTimer(RTimer r)
        {
            if (UI != null && UI.buttonText != null) UI.buttonText.text = (r.getLeftTime() / 1000).ToString();
        }

        private void cdEnd(RTimer r)
        {
            cdTimer = null;
            if (UI != null && UI.loginBtn != null)
            {
                if (!UI.loginBtn.IsInteractable())
                {
                    ColorUtil.DeGray(UI.loginBtn);
                    UI.loginBtn.interactable = true;
                }
            }
            if (UI != null && UI.buttonText != null) UI.buttonText.text = "";
        }

        public void enterScene(RMetaEvent e = null)
        {
            //hide();
        }

        public void SetLogText(RMetaEvent e)
        {
            string logtext = e.data as string;
            if (UI != null && UI.logText != null)
            {
                UI.logText.text = logtext;
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            Destroy();
        }

        public override void Destroy()
        {
            //playerModel.removeChangeEvent(PlayerModel.ENTER_SCENE, enterScene);
            EventCore.removeRMetaEventListener(GlobalConstDefine.PRINT_LOGIN_LOG, SetLogText);
            if (cdTimer != null)
            {
                cdTimer.stop();
                cdTimer = null;
            }
            base.Destroy();
            UI = null;
        }
    }
}
