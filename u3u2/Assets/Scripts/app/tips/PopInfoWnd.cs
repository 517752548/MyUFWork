using UnityEngine;

namespace app.tips
{
    public class PopInfoWnd : BaseWnd
    {
        public const string ACTION_CONFIRM = "confirm";
        public const string ACTION_CANCEL = "cancel";

        public object data { get; set; }
    
        //[Inject(ui = "popInfoUI")]
        //public GameObject ui;

        private ConfirmUI UI;

        private RMetaEventHandler _confrimHandler;
        private RMetaEventHandler _cancelHandler;
        private string _title;
        private string _info;
        private TextAnchor _anchor;
        private Vector2 _rect;
        //private RectTransform mInfoRect;

        private float _secondsLeftForHide = 0;

        private static PopInfoWnd _ins;

        public PopInfoWnd()
        {
            uiName = "popInfoUI";
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
            UI.sureBtn.SetClickCallBack(clickBtn);
            if (UI.cancelBtn)
            {
                UI.cancelBtn.SetClickCallBack(clickBtn);
            }
        }

        private void clickBtn(GameObject go)
        {
            hide();
        }

        public static PopInfoWnd Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = Singleton.GetObj(typeof(PopInfoWnd)) as PopInfoWnd;
                }
                return _ins;
            }
        }


        public override void show(RMetaEvent e = null)
        {
            base.show(e);

            //显示面板的背景底
            //showBgImage();
            if (string.IsNullOrEmpty(_title))
            {
                UI.title.gameObject.SetActive(false);
            }
            else
            {
                UI.title.gameObject.SetActive(true);
            }
            UI.title.text = _title;
            UI.infoText.text = _info;
            UI.infoText.gameObject.SetActive(true);
            UI.infoText.alignment = _anchor;
            //if (mInfoRect == null) mInfoRect = UI.gameObject.GetComponent<RectTransform>();
            //mInfoRect.sizeDelta = _rect;
            UI.layout.sizeDelta = _rect;

            UI.surBtnLabel.text = LangConstant.BTN_LABEL_QUEDING;
            UI.cancelBtnLabel.text = LangConstant.BTN_LABEL_QUXIAO;
        }

        public PopInfoWnd ShowInfo(string info, string title=LangConstant.TISHI,TextAnchor anchor = TextAnchor.MiddleLeft, int width = 420, int heigh = 210)
        {
            _title = title;
            _info = info;
            _secondsLeftForHide = 0;
            _anchor = anchor;
            _rect = new Vector2(width, heigh);
            preLoadUI();
            return this;
        }

        protected override void clickSpaceArea(GameObject go)
        {
            base.clickSpaceArea(go);
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
                        clickBtn(UI.cancelBtn.gameObject);
                    }
                    else
                    {
                        UI.cancelBtnLabel.text = LangConstant.BTN_LABEL_QUXIAO_WITH_CD + "(" + Mathf.CeilToInt(_secondsLeftForHide) + ")";
                    }
                }
            }
        }
    }
}
