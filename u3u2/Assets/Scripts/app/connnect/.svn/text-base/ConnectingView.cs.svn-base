using UnityEngine;
using UnityEngine.UI;

public class ConnectingView : BaseUI
{
    protected static ConnectingView _ins;
    public static ConnectingView Instance
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(ConnectingView)) as ConnectingView;
                //_ins = new ConnectingView();
            }
            return _ins;
        }
    }

    private static int DotMaxNum = 3;
    private static int TimerInterval = 500;
    private static string DotStr = ".";

    //[Inject(ui = "connectUI")]
    //public GameObject ui;

    private int dotNum;

    private RTimer timer;
    /*
    public override void initUILayer(WndType uilayer = WndType.FirstWND)
    {
 	     base.initUILayer(WndType.PopWND);
    }
    */
    
    public ConnectingView()
    {
        uiName = "connectUI";
    }
    
    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        if (timer == null)
        {
            timer = TimerManager.Ins.createTimer(TimerInterval,-1, updateLabel, null);
            timer.start();
        }
    }

    public override void hide(RMetaEvent e = null)
    {
        if (timer != null)
        {
            timer.stop();
            timer = null;
        }

        base.hide(e);
    }

    private void updateLabel(RTimer timer)
    {
        Text label = ui.transform.Find("tipLabel").gameObject.GetComponent<Text>();
        if (label==null)
        {
            label = ui.transform.Find("tipLabel").gameObject.AddComponent<Text>();
        }
        
        if (label!=null)
        {
            dotNum = (dotNum + 1)%DotMaxNum;
            string str = "";
            for (int i=0;i<dotNum;i++)
            {
                str +=DotStr;
            }
            label.text = "正与服务器连接，请等待" + str;
        }
    }

    public override void Destroy()
    {
        if (timer != null)
        {
            timer.stop();
            timer = null;
        }
        base.Destroy();
    }
}


