using UnityEngine;
using System.Collections;

namespace app.tips
{
    public class PopInfoScrollWnd : BaseWnd
    {
        private ConfirmUI UI;
        private string _title;
        private string _info;
        private float _secondsLeftForHide = 0;

        private static PopInfoScrollWnd _ins;

        public PopInfoScrollWnd()
        {
            uiName = "popInfoScrollUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<ConfirmUI>();
            UI.Init1();

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

        public static PopInfoScrollWnd Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = Singleton.GetObj(typeof(PopInfoScrollWnd)) as PopInfoScrollWnd;
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

            UI.surBtnLabel.text = LangConstant.BTN_LABEL_QUEDING;
            UI.cancelBtnLabel.text = LangConstant.BTN_LABEL_QUXIAO;
        }

        public PopInfoScrollWnd ShowInfo(string info, string title = LangConstant.TISHI)
        {
            _title = title;
            _info = info;
            _secondsLeftForHide = 0;
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
