using UnityEngine;
using app.net;
using app.pet;


public class PopPetInfoWnd : BaseWnd
{

    //[Inject(ui = "PetUI")]
    //public GameObject ui;

    //private PetUI UI;

    private static PopPetInfoWnd _ins;

    /// <summary>
    /// 是否正在发消息
    /// </summary>
    private bool isSendMsg = false;

    //private CPetInfo petInfo = new CPetInfo();

    public PopPetInfoWnd()
    {
        uiName = "PetUI";
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
        //UI = ui.AddComponent<PetUI>();
        //UI.Init();
    }

    public static PopPetInfoWnd Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(PopPetInfoWnd)) as PopPetInfoWnd;
            }
            return _ins;
        }
    }

    public override void show(RMetaEvent e = null)
    {
        base.show(e);

    }

    public void ShowInfo(CRankInfo mRankinfo)
    {
        if (!isSendMsg)
        {
            isSendMsg = true;
            CommonCGHandler.sendCGOfflineUserPetInfo(mRankinfo.humanId, mRankinfo.petId);
        }
    }

    public void ShowInfo(long roleId,long petId)
    {
        if (!isSendMsg)
        {
            isSendMsg = true;
            CommonCGHandler.sendCGOfflineUserPetInfo(roleId, petId);
        }
    }

    #region 消息返回

    public void PetInfoResult(GCOfflineUserPetInfo _petinfo)
    {
        if (isSendMsg)
        {
            isSendMsg = false;
            //petInfo.isUpdate = true;
            PetInfoViewerView.Ins.setViewInfo(_petinfo.getPetInfoJson());
            WndManager.open(GlobalConstDefine.PetInfoViewer_Name);
        }
    }

    #endregion


}
