using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.net;
using app.zone;
using UnityEngine;
using UnityEngine.UI;

namespace app.duihuan
{
    public class DuiHuanJiangLiView:BaseWnd
    {
        private InputField inputField;
        private Image inputbg;
        private GameUUButton duihuanBtn;
        private GameUUButton closeBtn;
        public DuiHuanJiangLiView()
        {
            uiName = "duihuanJiangLiUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            inputbg = ui.transform.Find("fayanGo/inputBg").GetComponent<Image>();
            duihuanBtn = ui.transform.Find("fayanGo/fasong").GetComponent<GameUUButton>();
            closeBtn = ui.transform.Find("closeBtn").GetComponent<GameUUButton>();
            inputField = CreateInputField(Color.black, 30, inputbg);
            inputField.characterLimit = 50;

            duihuanBtn.SetClickCallBack(clickDuiHuan);
            closeBtn.SetClickCallBack(clickClose);
        }

        private void clickClose()
        {
            hide();
        }

        private void clickDuiHuan()
        {
            string str =inputField.text;
            if (!string.IsNullOrEmpty(str))
            {
                HumanCGHandler.sendCGChannelExchange(str);
                inputField.text = "";
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.INPUT_DUIHUANMA);
            }
        }

        public override void Destroy()
        {
            base.Destroy();
            duihuanBtn.ClearClickCallBack();
            closeBtn.ClearClickCallBack();
            inputField = null;
        }
    }
}
