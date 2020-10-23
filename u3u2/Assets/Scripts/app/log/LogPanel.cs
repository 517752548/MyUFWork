using app.net;
using UnityEngine;

public enum LogPanelType
{
    Error,
    Warning,
    Log
}

class LogPanel : BaseUI
{
    //[Inject(ui = "DebugPanel")]
    //public GameObject ui;

    private bool stopUpdateContent=false;
    private Vector3 UnVisiblePos;
    private Vector3 visiblePos;
    private DebugPanelUI UI;

    private static LogPanel _ins;

    public static LogPanel Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new LogPanel();
            }
            return _ins;
        }
    }
    /*
    public override void initUILayer(WndType uilayer = WndType.FirstWND)
    {
        base.initUILayer(WndType.POPTIPS);
    }
    */
    
    public LogPanel()
    {
        uiName = "DebugPanel";
        SourceManager.Ins.ignoreDispose(PathUtil.Ins.GetUIPath("DebugPanel"));
    }
    
    public override void initUI()
    {
        base.initUI(); 
        UnVisiblePos = new Vector3(-500, 0, 0);
        visiblePos = new Vector3(0, 0, 0);
        UI = ui.AddComponent<DebugPanelUI>();
        UI.Init();
        //EventTriggerListener.Get(UI.sendBtn.gameObject).onClick = clickSend;
        //EventTriggerListener.Get(UI.clearBtn.gameObject).onClick = clickClear;
        //EventTriggerListener.Get(UI.stopBtn.gameObject).onClick = clickStop;
        UI.sendBtn.SetClickCallBack(clickSend);
        UI.clearBtn.SetClickCallBack(clickClear);
        UI.stopBtn.SetClickCallBack(clickStop);
        UI.sb.ClickCallBack = clickSwitch;
    }

    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        //手动创建输入框
        UI.inputText = CreateInputField(Color.black,20,UI.inputbg);
        UI.inputText.onEndEdit.AddListener(doSubmit);
        UI.sb.IsSelected = true;
        clickSwitch();
    }

    private void doSubmit(string str)
    {
        clickSend(null);
    }

    private void clickClear(GameObject go)
    {
        UI.contentText.text = "";
    }

    private void clickStop(GameObject go)
    {
        stopUpdateContent = true;
    }

    private void clickSend(GameObject go)
    {
        string str = UI.inputText.text;
        UI.inputText.text = "";
        ClientLog.Log("输入的文本：" + str);
        if (string.IsNullOrEmpty(str))
        {
            //PopTipsView.Instance.popTips("invalid input!");
        }
        else
        {
            ChatCGHandler.sendCGChatMsg(0, "", "", str, 0);
        }
    }

    private void clickSwitch(UGUISwitchButton sb = null)
    {
        if (UI.sb.IsSelected)
        {
            ui.GetComponent<RectTransform>().localPosition = UnVisiblePos;
            UI.clearBtn.gameObject.SetActive(false);
            UI.stopBtn.gameObject.SetActive(false);
            UI.sendBtn.gameObject.SetActive(false);
            UI.bg.gameObject.SetActive(false);
            UI.inputbg.gameObject.SetActive(false);
            UI.inputText.gameObject.SetActive(false);
        }
        else
        {
            UI.bg.gameObject.SetActive(true);
            UI.inputbg.gameObject.SetActive(true);
            UI.inputText.gameObject.SetActive(true);
            ui.GetComponent<RectTransform>().localPosition = visiblePos;
            UI.clearBtn.gameObject.SetActive(true);
            UI.sendBtn.gameObject.SetActive(true);
            UI.stopBtn.gameObject.SetActive(true);
        }
    }

    public void AddLog(LogPanelType lt, string msg)
    {
        if (UI == null || stopUpdateContent)
        {
            return;
        }
        if (UI.contentText.text.Length > 10000)
        {
            clickClear(null);
        }
        if (UI.contentText != null)
        {
            UI.contentText.text = msg + "\n" + UI.contentText.text;
        }
    }

    public void changeSibling()
    {
        setAsLastSibling(ui.gameObject);
    }

}

