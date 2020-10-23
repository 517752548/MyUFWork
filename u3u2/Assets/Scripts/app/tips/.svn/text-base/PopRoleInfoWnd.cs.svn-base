using UnityEngine;
using System.Collections;
using app.net;
using app.db;
using app.pet;
using app.relation;
using app.chat;
using app.human;
using app.team;
using minijson;

public class PopRoleInfoWnd : BaseWnd
{

    public const string RoleBaseInfo_RESULT = "RoleBaseInfo_RESULT";
    public const string RoleLeaderInfo_RESULT = "RoleLeaderInfo_RESULT";
    public const string PetInfo_RESULT = "PetInfo_RESULT";

    //[Inject(ui = "popRoleInfoUI")]
    //public GameObject ui;

    private PopRoleInfoUI UI;

    private static PopRoleInfoWnd _ins;
    /// <summary>
    /// 是否正在发消息
    /// </summary>
    private bool isSendMsg = false;
    private CRankInfo mRankinfo = new CRankInfo();
    private GCOfflineUserBaseInfo mBaseinfo;
    private IDictionary mBaseinfoDic;

    public enum EStatue {
        Normal,
        NoQiecuo,  //无切磋按钮
        CheckPet, //直接打开宠物面板
    }

    public EStatue mCurStatue = EStatue.Normal;
    
    public PopRoleInfoWnd()
    {
        uiName = "popRoleInfoUI";
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
        UI = ui.AddComponent<PopRoleInfoUI>();
        UI.Init();
        UI.chakanchongwuBtn.SetClickCallBack(ChakanchongwuBtnOnClick);
        UI.chekanzhuangbeiBtn.SetClickCallBack(ChekanzhuangbeiBtnOnClick);
        UI.fasongxinxiBtn.SetClickCallBack(FasongxinxiBtnOnClick);
        UI.jiaweihaoyouBtn.SetClickCallBack(JiaweihaoyouBtn);
        UI.qiecuoBtn.SetClickCallBack(QiecuoBtnOnClick);
        UI.yaoqingrubangBtn.SetClickCallBack(YaoqingrubangBtnOnClick);

        //EventCore.addRMetaEventListener(RoleBaseInfo_RESULT, RoleBaseInfoResult);
        //EventCore.addRMetaEventListener(RoleLeaderInfo_RESULT, RoleLeaderInfoResult);
        //EventCore.addRMetaEventListener(PetInfo_RESULT, RolePetInfoResult);
    }

    public static PopRoleInfoWnd Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(PopRoleInfoWnd)) as PopRoleInfoWnd;
            }
            return _ins;
        }
    }

    public override void show(RMetaEvent e = null)
    {
        if (mRankinfo==null||!mRankinfo.isUpdate) return;
        base.show(e);
        if(UI.rolename!=null) UI.rolename.text = mRankinfo.humanName;

        //LoadRoleHeadIcon(mRankinfo.humanHead);
        PathUtil.Ins.SetHeadIcon(UI.icon, mRankinfo.humanHead);
        

        UI.xiakeobj.SetActive(mRankinfo.humanJob == PetJobType.XIAKE);
        UI.cikeobj.SetActive(mRankinfo.humanJob == PetJobType.CIKE);
        UI.shushiobj.SetActive(mRankinfo.humanJob == PetJobType.SHUSHI);
        UI.xiuzhenobj.SetActive(mRankinfo.humanJob == PetJobType.XIUZHEN);

        if (UI.menpai != null) UI.menpai.text = PetJobType.GetJobName(mRankinfo.humanJob);
        UI.id.gameObject.SetActive(false);
        UI.zhuansheng.gameObject.SetActive(false);
        //if (UI.id != null) UI.id.text = JsonHelper.GetStringData(ItemDefine.RoleInfoPropKey., mBaseinfoDic);
        string bangpai = mRankinfo.corpsName;
        if (string.IsNullOrEmpty(bangpai)) {
            bangpai = "无";
        }
        if (UI.bangpai != null) UI.bangpai.text = "帮派："+ bangpai;
        switch (mCurStatue)
        {
            
            case EStatue.NoQiecuo:
                UI.qiecuoBtn.gameObject.SetActive(false);
                break;
            case EStatue.CheckPet:
            case EStatue.Normal:
                UI.qiecuoBtn.gameObject.SetActive(true);
                break;
        }
        UI.yaoqingrubangBtn.gameObject.SetActive(false);
    }

    public void ShowInfo(long uuid, EStatue statue = EStatue.NoQiecuo) {
        mRankinfo.humanId = uuid;
        mCurStatue = statue;
        ShowInfo();
    }

    public void ShowInfo(RankInfo rankinfo)
    {
        mRankinfo = GetCRankInfo(rankinfo,mRankinfo);
        ShowInfo();
    }

    private void ShowInfo() {
        isSendMsg = true;
        if (mRankinfo != null)
        {
            mRankinfo.isUpdate = false;
            CommonCGHandler.sendCGOfflineUserBaseInfo(mRankinfo.humanId);
        }
    }

    private void ShowInfo(long humanId)
    {
        mRankinfo = new CRankInfo();
        mRankinfo.humanId = humanId;
        ShowInfo();
    }

    private string mRoleHeadIconPath;
    
    /*
    private void LoadRoleHeadIcon(string path)
    {
        if (path != mRoleHeadIconPath)
        {
            mRoleHeadIconPath = path;
            SourceLoader.Ins.load(path, OnRoleHeadIconLoaded);
        }
    }
    
    private void OnRoleHeadIconLoaded(RMetaEvent e)
    {
        if (e.type == SourceLoader.LOAD_COMPLETE)
        {
            Texture2D t = SourceManager.Ins.GetAsset<Texture2D>(mRoleHeadIconPath);
            UI.icon.texture = t;
        }
    }
    */

    public CRankInfo GetCRankInfo(RankInfo rankinfo,CRankInfo info) {
        if (info==null||rankinfo==null)
        {
            return null;
        }
        info.rank = rankinfo.rank;
        info.humanName = rankinfo.humanName;
        info.petName = rankinfo.petName;
        info.corpsName = rankinfo.corpsName;
        info.level = rankinfo.level;
        info.humanJob = rankinfo.humanJob;
        info.fightPower = rankinfo.fightPower;
        info.score = rankinfo.score;
        info.humanId = rankinfo.humanId;
        info.petId = rankinfo.petId;
        return info;
    }


    #region 按钮监听

    private void ChakanchongwuBtnOnClick(GameObject go)
    {
        if (mRankinfo != null && mRankinfo.isUpdate && mRankinfo.petId != 0)
            PopPetInfoWnd.Ins.ShowInfo(mRankinfo);
    }

    private void ChekanzhuangbeiBtnOnClick(GameObject go)
    {
        if (mRankinfo != null && mRankinfo.isUpdate)
            PopRoleDetailInfoWnd.Ins.ShowInfo(mRankinfo);
    }

    private void FasongxinxiBtnOnClick(GameObject go)
    {
        hide();
        ChatModel.Ins.OpenRelationViewAndChat(mRankinfo.humanId.ToString(), mRankinfo.humanName, mRankinfo.level.ToString(), mRankinfo.humantplID.ToString());
    }

    private void JiaweihaoyouBtn(GameObject go)
    {
        RelationCGHandler.sendCGAddRelationById(RelationType.HAOYOU, mRankinfo.humanId);
    }

    private void QiecuoBtnOnClick(GameObject go)
    {
        hide();
        //if (TeamModel.ins.hasTeam())
        //{
        //    BattleCGHandler.sendCGBattleStartTeampvp(mRankinfo.humanId);
        //}
        //else
        //{
            BattleCGHandler.sendCGBattleStartPvp(mRankinfo.humanId);
        //}
    }

    private void YaoqingrubangBtnOnClick(GameObject go)
    {

    }



    #endregion

    #region 消息返回

    public void RoleBaseInfoResult(GCOfflineUserBaseInfo _baseinfo)
    {
        if (isSendMsg) {
            isSendMsg = false;
            mRankinfo.isUpdate = true;
            IDictionary BaseinfoDic = (IDictionary)(Json.Deserialize(_baseinfo.getRoleBaseInfoJson()));
            mRankinfo.humanName = JsonHelper.GetStringData(ItemDefine.RoleInfoPropKey.roleName, BaseinfoDic);
            mRankinfo.humantplID = JsonHelper.GetIntData(ItemDefine.RoleInfoPropKey.roleTplId, BaseinfoDic);
            mRankinfo.level = JsonHelper.GetIntData(ItemDefine.RoleInfoPropKey.roleLevel, BaseinfoDic);
            PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(mRankinfo.humantplID);
            //string headPath = PathUtil.Ins.GetUITexturePath(petTpl.modelId, PathUtil.TEXTUER_HEAD);
            mRankinfo.humanJob = petTpl.jobId;
            mRankinfo.humanHead = petTpl.modelId;
            
            mRankinfo.fightPower = JsonHelper.GetIntData(ItemDefine.RoleInfoPropKey.roleFightPower, BaseinfoDic);
            mRankinfo.corpsName = JsonHelper.GetStringData(ItemDefine.RoleInfoPropKey.roleCorpsName, BaseinfoDic);

            
            switch (mCurStatue)
            {
                case EStatue.Normal:
                case EStatue.NoQiecuo:
                    //由于查看的宠物不一定是出战的宠物 可能petid返回为空 这种情况 用排行榜种的petid
                    mRankinfo.petId = JsonHelper.GetLongData(ItemDefine.RoleInfoPropKey.roleFightPetId, BaseinfoDic);
                    preLoadUI();
                    break;
                case EStatue.CheckPet:
                    PopPetInfoWnd.Ins.ShowInfo(mRankinfo);
                    break;
            }
        }
    }

    #endregion




}
