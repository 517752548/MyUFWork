using UnityEngine;

namespace app.confirm
{
    public class ConfirmWnd : BaseWnd
    {
        public const string ACTION_CONFIRM = "confirm";
        public const string ACTION_CANCEL = "cancel";

        public object data { get; set; }

        //[Inject(ui = "confirmUI")]
        //public GameObject ui;

        private ConfirmUI UI;

        private ConfirmWndType _wndType;

        private RMetaEventHandler _confrimHandler;
        private RMetaEventHandler _cancelHandler;
        private string _title;
        private string _info;
        private string _toggleinfo;

        private float _secondsLeftForHide = 0;
        private ConfirmWndCancleEnum hideHandlerFlag = ConfirmWndCancleEnum.NONE;
        private static ConfirmWnd _ins;
        /// <summary>
        /// 一个按钮的提示框
        /// </summary>
        private bool isSingleBtn = false;
        /// <summary>
        /// 当前今日不再提示的key
        /// </summary>
        private string mcurKey = "";

        /// <summary>
        /// 确认框类型
        /// </summary>
        public enum ConfirmWndType
        {
            Input,
            Confirm,
            Toggle,
        }

        public ConfirmWnd()
        {
            uiName = "confirmUI";
        }
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.PopWND);
        }
        */

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<ConfirmUI>();
            UI.Init();
            //EventTriggerListener.Get(UI.sureBtn.gameObject).onClick=clickBtn;
            //EventTriggerListener.Get(UI.cancelBtn.gameObject).onClick = clickBtn;
            UI.sureBtn.SetClickCallBack(clickBtn);
            UI.cancelBtn.SetClickCallBack(clickBtn);
            UI.middleBtn.SetClickCallBack(clickBtn);
        }

        private void clickBtn(GameObject go)
        {
            if (go == UI.sureBtn.gameObject || go == UI.middleBtn.gameObject)
            {
                hide();
                DispatchConfirmEvent();
            }
            else
            {
                hide();
                DispatchCancelEvent();
            }
            if (GuideIdDef.RingTask == GuideManager.Ins.CurrentGuideId)
            {
                GuideManager.Ins.RemoveGuide(GuideIdDef.RingTask);
            }
        }

        private void DispatchConfirmEvent()
        {
            if (_confrimHandler != null)
            {
                _confrimHandler(new RMetaEvent(ACTION_CONFIRM, _wndType == ConfirmWndType.Input ? UI.inputText.text : data));
            }
            UpdateToggleData();
        }

        private void DispatchCancelEvent()
        {
            if (_cancelHandler != null)
            {
                _cancelHandler(new RMetaEvent(ACTION_CANCEL, _wndType == ConfirmWndType.Input ? UI.inputText.text : data));
            }
        }

        public static ConfirmWnd Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = Singleton.GetObj(typeof(ConfirmWnd)) as ConfirmWnd;
                    //_ins = new ConfirmWnd();
                }
                return _ins;
            }
        }


        public override void show(RMetaEvent e = null)
        {
            base.show(e);

            //显示面板的背景底
            //showBgImage();
            if (isSingleBtn)
            {
                UI.sureBtn.gameObject.SetActive(false);
                UI.cancelBtn.gameObject.SetActive(false);
                UI.middleBtn.gameObject.SetActive(true);
            }
            else
            {
                UI.sureBtn.gameObject.SetActive(true);
                UI.cancelBtn.gameObject.SetActive(true);
                UI.middleBtn.gameObject.SetActive(false);
            }
            UI.title.text = _title;
            if (_wndType == ConfirmWndType.Confirm)
            {
                UI.inputText.gameObject.SetActive(false);
                UI.infoText.text = _info;
                UI.infoText.gameObject.SetActive(true);
                UI.toggle.gameObject.SetActive(false);
            }
            else if (_wndType == ConfirmWndType.Toggle)
            {
                UI.inputText.gameObject.SetActive(false);
                UI.toggle.gameObject.SetActive(true);
                UI.infoText.text = _info;
                UI.toggolText.text = _toggleinfo;
            }
            else
            {
                UI.inputText.gameObject.SetActive(true);
                UI.toggle.gameObject.SetActive(false);
                UI.infoText.text = "";
                UI.infoText.gameObject.SetActive(false);
            }

            UI.surBtnLabel.text = LangConstant.BTN_LABEL_QUEDING;
            UI.cancelBtnLabel.text = LangConstant.BTN_LABEL_QUXIAO;


            GuideManager.Ins.ShowGuide(GuideIdDef.RingTask, 3, UI.sureBtn.gameObject, false, 0);

        }

        public ConfirmWnd ShowInput(string title, RMetaEventHandler confirmHandler, RMetaEventHandler cancelHandler = null, bool _isSingleBtn = false)
        {
            isSingleBtn = _isSingleBtn;
            _wndType = ConfirmWndType.Input;
            _confrimHandler = confirmHandler;
            _cancelHandler = cancelHandler;
            _title = title;
            _secondsLeftForHide = 0;
            preLoadUI();
            return this;
        }

        public ConfirmWnd ShowConfirm(string title, string info, RMetaEventHandler confirmHandler, RMetaEventHandler cancelHandler = null, bool _isSingleBtn = false)
        {
            isSingleBtn = _isSingleBtn;
            _wndType = ConfirmWndType.Confirm;
            _confrimHandler = confirmHandler;
            _cancelHandler = cancelHandler;
            _title = title;
            _info = info;
            _secondsLeftForHide = 0;
            preLoadUI();
            return this;
        }

        public ConfirmWnd ShowConfirmByParam(ConfirmWndParam param)
        {
            isSingleBtn = param._isSingleBtn;
            _wndType = ConfirmWndType.Confirm;
            _confrimHandler = param.confirmHandler;
            _cancelHandler = param.cancelHandler;
            _title = param.title;
            _info = param.info;
            _secondsLeftForHide = param._secondsLeftForHide;
            hideHandlerFlag = param.hideHandlerFlag;
            preLoadUI();
            return this;
        }

        protected override void clickSpaceArea(GameObject go)
        {
            return;
            //DispatchCancelEvent();
            //base.clickSpaceArea(go);
        }

        public void CancelAfterSeconds(float seconds)
        {
            _secondsLeftForHide = seconds;
        }

        public override void Update()
        {
            base.Update();
            if (isShown)
            {
                if (_secondsLeftForHide > 0)
                {
                    _secondsLeftForHide -= Time.unscaledDeltaTime;
                    if (_secondsLeftForHide <= 0)
                    {
                        if (hideHandlerFlag == ConfirmWndCancleEnum.CONFIRM)
                        {
                            clickBtn(UI.sureBtn.gameObject);
                        }
                        else if (hideHandlerFlag == ConfirmWndCancleEnum.CANCEL)
                        {
                            clickBtn(UI.cancelBtn.gameObject);
                        }
                        else
                        {
                            hide();
                        }
                    }
                    else
                    {
                        if (hideHandlerFlag == ConfirmWndCancleEnum.CONFIRM)
                        {
                            UI.surBtnLabel.text = LangConstant.BTN_LABEL_SURE_WITH_CD + "(" + Mathf.CeilToInt(_secondsLeftForHide) + ")";
                        }
                        else
                        {
                            UI.cancelBtnLabel.text = LangConstant.BTN_LABEL_QUXIAO_WITH_CD + "(" + Mathf.CeilToInt(_secondsLeftForHide) + ")";
                        }
                    }
                }
            }
        }

        #region 今日不再提示

        /// <summary>
        /// 洗练今日不在提示
        /// </summary>
        /// <param name="title"></param>
        /// <param name="confirmHandler"></param>
        /// <param name="cancelHandler"></param>
        /// <returns></returns>
        public ConfirmWnd ShowJinribuzaitishiXilian(string title, string info, RMetaEventHandler confirmHandler, RMetaEventHandler cancelHandler = null, string toggleInfo = "今日不再提示")
        {
            return ShowJinribuzaitishi(title, info, PlayerDataKeyDef.CUSTOM_DATA_Jinritishi_xilian, confirmHandler, cancelHandler, toggleInfo);
        }

        /// <summary>
        /// 打造今日不在提示
        /// </summary>
        /// <param name="title"></param>
        /// <param name="confirmHandler"></param>
        /// <param name="cancelHandler"></param>
        /// <returns></returns>
        public ConfirmWnd ShowJinribuzaitishiDaZao(string title, string info, RMetaEventHandler confirmHandler, RMetaEventHandler cancelHandler = null, string toggleInfo = "今日不再提示")
        {
            return ShowJinribuzaitishi(title, info, PlayerDataKeyDef.CUSTOM_DATA_Jinritishi_dazao, confirmHandler, cancelHandler, toggleInfo);
        }

        /// <summary>
        /// 上架今日不在提示
        /// </summary>
        /// <param name="title"></param>
        /// <param name="confirmHandler"></param>
        /// <param name="cancelHandler"></param>
        /// <returns></returns>
        public ConfirmWnd ShowJinribuzaitishiShangjia(string title, string info, RMetaEventHandler confirmHandler, RMetaEventHandler cancelHandler = null, string toggleInfo = "今日不再提示")
        {
            bool flat = true;
            return ShowJinribuzaitishi(title, info, PlayerDataKeyDef.CUSTOM_DATA_Jinritishi_shangjia, confirmHandler, cancelHandler, toggleInfo, flat);
        }

        private ConfirmWnd ShowJinribuzaitishi(string title, string info, string type, RMetaEventHandler confirmHandler, RMetaEventHandler cancelHandler = null, string toggleInfo = "今日不再提示", bool _isSingleBtn = false)
        {
            mcurKey = type;
            PlayerData customData = PlayerDataManager.Ins.GetPlayerData(PlayerDataKeyDef.CUSTOM_DATA);
            int today = 0;
            if (customData.getData(type) != null)
                today = int.Parse(customData.getData(type));
            if (today == System.DateTime.Now.Day)
            {
                if (confirmHandler != null)
                {
                    confirmHandler(null);
                }
                //今日不在提示
                return null;
            }
            return ShowToggle(title, info, toggleInfo, confirmHandler, cancelHandler, _isSingleBtn);
        }

        private ConfirmWnd ShowToggle(string title, string info, string toggleInfo, RMetaEventHandler confirmHandler, RMetaEventHandler cancelHandler = null, bool _isSingleBtn = false)
        {
            isSingleBtn = _isSingleBtn;
            _wndType = ConfirmWndType.Toggle;
            _confrimHandler = confirmHandler;
            _cancelHandler = cancelHandler;
            _title = title;
            _info = info;
            _toggleinfo = toggleInfo;
            _secondsLeftForHide = 0;
            preLoadUI();
            return this;
        }

        private void UpdateToggleData()
        {
            if (_wndType == ConfirmWndType.Toggle)
            {
                PlayerData customData = PlayerDataManager.Ins.GetPlayerData(PlayerDataKeyDef.CUSTOM_DATA);
                string value = "";
                int today = System.DateTime.Now.Day;
                if (UI.toggle.isOn)
                {
                    value = today.ToString();
                }
                else
                {
                    value = "0";
                }
                if (mcurKey.Trim() != "")
                    customData.addData(mcurKey, value);
                PlayerDataManager.Ins.SaveData(PlayerDataKeyDef.CUSTOM_DATA, customData);
            }
        }

        #endregion

        public override void Destroy()
        {
            data = null;
            _confrimHandler = null;
            _cancelHandler = null;

            base.Destroy();
            UI = null;
        }
    }
}
