
using app.net;
using System.Collections.Generic;
public class TiShengModel : AbsModel 
{
    public const string PROMOTE_UPDATE = "PROMOTE_UPDATE";
    public const string ONCLICK_PROMOTE = "ONCLICK_PROMOTE";
    public const string TISHENG_OPEN_LINK = "TISHENG_OPEN_LINK";

    public List<int> removeList = new List<int>();

    private static TiShengModel mTiShengModel;

    public static TiShengModel instance
    {
        get
        {
            if (mTiShengModel == null)
            {
                mTiShengModel = new TiShengModel();
            }
            return mTiShengModel;
        }
    }

    public void SendCGHandler()
    {
        PromoteCGHandler.sendCGPromotePanel();
    }
    
    private GCPromotePanel mGCPromotePanel;

    public GCPromotePanel GCPromotePanel
    {
        get
        {
            return mGCPromotePanel;
        }
        set
        {
            mGCPromotePanel = value;
            dispatchChangeEvent(PROMOTE_UPDATE,value);
        }
    }


    public void OnClick()
    {
        dispatchChangeEvent(ONCLICK_PROMOTE,null);
    }

    public void TiShengLink()
    {
        dispatchChangeEvent(TISHENG_OPEN_LINK, null);
    }

    public override void Destroy()
    {
        mTiShengModel = null;
        if (removeList != null)
        {
            removeList.Clear();
            removeList = null;
        }
        mGCPromotePanel = null;
    }
}
