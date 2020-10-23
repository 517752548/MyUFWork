using System;
using UnityEngine;
using UnityEngine.UI;

public class ConnectFailView : BaseWnd
{
    protected static ConnectFailView _ins;
    public static ConnectFailView Instance
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(ConnectFailView)) as ConnectFailView;
                //_ins = new ConnectFailView();
                //_ins.UILayer = WndType.PopWND;
            }
            return _ins;
        }
    }

    //[Inject(ui = "connectFailedUI")]
    //public GameObject ui;
    
    private Text tipLabel;

    private GameUUButton mOkBtn;
    private GameUUButton mCancelBtn;
    
    private Text mOkBtnLabel;
    private Text mCancelBtnLabel;
    
    /*
    public override void initUILayer(WndType uilayer = WndType.FirstWND)
    {
        base.initUILayer(WndType.PopWND);
    }
    */
    
    public ConnectFailView()
    {
        uiName = "connectFailedUI";
    }

    public override void initWnd()
    {
        base.initWnd();
        
        mOkBtn = ui.transform.Find("okBtn").GetComponent<GameUUButton>();
        if (ui.transform.Find("cancelBtn") != null)
        {
            mCancelBtn = ui.transform.Find("cancelBtn").GetComponent<GameUUButton>();
            if (mCancelBtn!=null)
            {
                mCancelBtn.SetClickCallBack(ClickCancel);
            }
        }
        mOkBtn.SetClickCallBack(ClickOK);
        tipLabel = ui.transform.Find("tipLabel").GetComponent<Text>();
        mOkBtnLabel = ui.transform.Find("okBtn/Text").GetComponent<Text>();
        mCancelBtnLabel = ui.transform.Find("cancelBtn/Text").GetComponent<Text>();
    }

    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        makeUIForward();
        ShowPop();
    }

    protected override void clickSpaceArea(GameObject go)
    {
        //base.clickSpaceArea(go);
        return;
    }

    public override void hide(RMetaEvent e = null)
    {
        base.hide(e);
    }

    public void makeUIForward()
    {
        setAsLastSibling(ui.gameObject);        
    }

    /// <summary>
    /// 显示连接失败的view，不调用show，调用此方法
    /// </summary>
    /// <param name="onClickRetry">点击按钮后的处理</param>
    /// <param name="tips">显示的提示文字，没有的话默认是"网络异常请稍后重试……"</param>
    /// <param name="btnStr">按钮显示的文字，没有的话默认是"重试"</param>
    public void PopView()
    {
        preLoadUI();
    }

    private void ShowPop()
    {
        
    }

    private void ClickOK(GameObject go)
    {
        try
        {
            GameConnection.Instance.onClickRetry();
        }
        catch (Exception e)
        {
            ClientLog.LogError("重连失败："+e.ToString());
        }
        hide();
    }

    private void ClickCancel(GameObject go)
    {
        hide();
    }

    public override void Destroy()
    {
        tipLabel=null;
        mOkBtn = null;
        mCancelBtn = null;
        mOkBtnLabel = null;
        mCancelBtnLabel = null;

        base.Destroy();
    }
}


