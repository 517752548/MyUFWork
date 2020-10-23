using UnityEngine;

public class BaseTips:BaseWnd
{
    public BaseTips()
    {
        useTween = false;
    }
    /// <summary>
    /// 设置tips数据
    /// </summary>
    /// <param name="data"></param>
    public void setTipData(Object data) { }
    /*
    public override void initUILayer(WndType uilayer = WndType.FirstWND)
    {
        base.initUILayer(WndType.POPTIPS);
    }
    */
}
