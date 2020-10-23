
using app.bag;
using app.item;

using UnityEngine;

public class XiDianScript:BaseWnd
{
    public const string ACTION_CONFIRM = "confirm";
    public const string ACTION_CANCEL = "cancel";
    public object data { get; set; }

    //[Inject(ui = "XiDianUI")]
    //public GameObject ui;
    
    public BagModel bagModel;
    private XiDianUI UI;

    private RMetaEventHandler _confrimHandler;
    private RMetaEventHandler _cancelHandler;
    private CommonItemScript itemScript;
    private static XiDianScript _ins;

    public XiDianScript()
    {
        uiName = "XiDianUI";
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
        
        bagModel = BagModel.Ins;
        
        UI = ui.AddComponent<XiDianUI>();
        UI.Init();
        UI.sureBtn.SetClickCallBack(clickBtn);
        UI.cancelBtn.SetClickCallBack(clickBtn);

        itemScript = new CommonItemScript(UI.itemui);
        itemScript.setClickFor(CommonItemClickFor.ShowTips);
    }

    private void clickBtn(GameObject go)
    {
        if (go==UI.sureBtn.gameObject)
        {
            DispatchConfirmEvent();
            hide();
        }
        else
        {
            DispatchCancelEvent();
            hide();
        }
    }

    private void DispatchConfirmEvent()
    {
        if (_confrimHandler != null)
        {
            _confrimHandler(new RMetaEvent(ACTION_CONFIRM,data));
        }
        hide();
    }

    private void DispatchCancelEvent()
    {
        if (_cancelHandler != null)
        {
            _cancelHandler(new RMetaEvent(ACTION_CANCEL,data));
        }
        hide();
    }

    public static XiDianScript Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(XiDianScript)) as XiDianScript;
            }
            return _ins;
        }
    }

    public override void show(RMetaEvent e = null)
    {
        base.show(e);

        //显示面板的背景底
        //showBgImage();

        int itemTplId = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.RESET_POINT_ITEMID);
        itemScript.setTemplate(itemTplId);
        itemScript.setNumText(bagModel.getHasNum(itemTplId), 1);
    }

    public XiDianScript ShowConfirm(RMetaEventHandler confirmHandler, RMetaEventHandler cancelHandler=null)
    {
        _confrimHandler = confirmHandler;
        _cancelHandler = cancelHandler;
        preLoadUI();
        return this;
    }

    protected override void clickSpaceArea(GameObject go)
    {
        DispatchCancelEvent();
        base.clickSpaceArea(go);
    }

}
