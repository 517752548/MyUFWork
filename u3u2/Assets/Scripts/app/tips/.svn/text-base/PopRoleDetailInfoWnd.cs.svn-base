using app.chat;
using app.relation;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.net;
using app.item;
using app.pet;
using app.db;
using minijson;

public class PopRoleDetailInfoWnd : BaseWnd
{

    //[Inject(ui = "RoleInfoViewerUI")]
    //public GameObject ui;

    private RoleInfoViewerUI UI;

    private static PopRoleDetailInfoWnd _ins;
    /// <summary>
    /// 是否正在发消息
    /// </summary>
    private bool isSendMsg = false;
    private CRankInfo mRankinfo;

    private GCOfflineUserLeaderInfo mleaderinfo;
    private List<ItemDetailData> mListDetail = new List<ItemDetailData>();
    private List<int> mStarDetail = new List<int>();
    private List<CommonItemScript> mListAllUI = new List<CommonItemScript>();


    public PopRoleDetailInfoWnd()
    {
        uiName = "RoleInfoViewerUI";
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
        UI = ui.AddComponent<RoleInfoViewerUI>();
        UI.Init();
        UI.closeBtn.SetClickCallBack(CloseBtnOnClick);
        UI.jiaweihaoyou.SetClickCallBack(JiaweihaoyouBtn);
        UI.fasongxiaoxi.SetClickCallBack(FasongxinxiBtnOnClick);
        UI.yaoqingrubang.SetClickCallBack(FasongxinxiBtnOnClick);
        for (int i =0;i< UI.allEquipList.Count;i++) {
            CommonItemScript script = new CommonItemScript(UI.allEquipList[i], ClickItemHandler);
            script.setClickFor(CommonItemClickFor.ShowTipsOnlyView);
            mListAllUI.Add(script);
        }
    }

    public static PopRoleDetailInfoWnd Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(PopRoleDetailInfoWnd)) as PopRoleDetailInfoWnd;
            }
            return _ins;
        }
    }

    public override void show(RMetaEvent e = null)
    {
        if (mleaderinfo == null) return;
        base.show(e);
        IDictionary mLeaderinfoDic = (IDictionary)(Json.Deserialize(mleaderinfo.getRoleInfoJson()));
        IDictionary equipDic = JsonHelper.GetDictData(ItemDefine.RoleInfoPropKey.equip, mLeaderinfoDic);
        IDictionary starDic = JsonHelper.GetDictData(ItemDefine.RoleInfoPropKey.start, mLeaderinfoDic);
        
        mListDetail.Clear();
        mStarDetail.Clear();
        if (equipDic.Count>0) {
            SetEquipData(ItemDefine.ItemPositionDefine.WEAPON.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.WEAPON.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.HEAD.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.HEAD.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.SHOULDER.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.SHOULDER.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.CLOAK.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.CLOAK.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.BREAST.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.BREAST.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.WRISTER.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.WRISTER.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.RING.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.RING.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.NECKLACE.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.NECKLACE.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.BELT.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.BELT.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.PANTS.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.PANTS.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.BOOT.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.BOOT.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.WING.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.WING.ToString(), starDic);
            SetEquipData(ItemDefine.ItemPositionDefine.FASHION.ToString(), equipDic);
            SetStarData(ItemDefine.ItemPositionDefine.FASHION.ToString(), starDic);
        }

        for (int i =0;i< mListAllUI.Count;i++) {
            if (i >= mListDetail.Count)
            {
                //如果装备位为空 设置空数据
                mListAllUI[i].setEmpty();
                //数据为空 不弹tips
                mListAllUI[i].setClickFor(CommonItemClickFor.OnlyCallBack);
            }
            else {
                mListAllUI[i].setData(mListDetail[i]);
                mListAllUI[i].setEquipGridXing(mStarDetail[i]);
                mListAllUI[i].setClickFor(CommonItemClickFor.ShowTipsOnlyView);
                mListAllUI[i].UI.icon.enabled = mListDetail[i]!=null;
            }
        }

        if (UI.roleName != null) UI.roleName.text = mRankinfo.isUpdate?mRankinfo.humanName:"";
        if (UI.roleLevel != null) UI.roleLevel.text =mRankinfo.isUpdate ? "等级：" + mRankinfo.level.ToString() : "等级：";
        if (UI.roleJob != null) UI.roleJob.text = mRankinfo.isUpdate ? "职业：" + PetJobType.GetJobName(mRankinfo.humanJob) : "职业：" ;
        if (UI.roleZhanli != null) UI.roleZhanli.text = mRankinfo.isUpdate ? mRankinfo.fightPower.ToString() : "";
        string bangpai = mRankinfo.corpsName;
        if (string.IsNullOrEmpty(bangpai))
        {
            bangpai = "无";
        }
        if (UI.bangpai != null) UI.bangpai.text = mRankinfo.isUpdate ? "帮派：" + bangpai : "";
        PetTemplate temp = PetTemplateDB.Instance.getTemplate(mRankinfo.humantplID);
        AddRoleModelToUI(new Vector3(0, 0, 0), new Vector3(1, 1, 1), temp, UI.modelContainer, GetWeapon(equipDic));

    }


    public void ShowInfo(CRankInfo rankinfo)
    {
        mRankinfo = rankinfo;
        isSendMsg = true;
        CommonCGHandler.sendCGOfflineUserLeaderInfo(mRankinfo.humanId);
    }

    

    public void RoleLeaderInfoResult(GCOfflineUserLeaderInfo leaderinfo)
    {
        if (isSendMsg)
        {
            isSendMsg = false;
            mleaderinfo = leaderinfo;
            preLoadUI();
        }
    }

    private void ClickItemHandler(ItemDetailData itemData) {

    }

    private EquipItemTemplate GetWeapon(IDictionary _equipDic)
    {
        IDictionary equipInfo = JsonHelper.GetDictData(ItemDefine.ItemPositionDefine.WEAPON.ToString(), _equipDic);
        if (equipInfo == null || equipInfo.Count <= 0)
        {
            return null;
        }
        int tmpID = JsonHelper.GetIntData(ItemDefine.ItemPropKey.TemplateID, equipInfo);
        IDictionary ftinfo = JsonHelper.GetDictData(ItemDefine.ItemPropKey.Feature, equipInfo);

        CommonItemData commonData = new CommonItemData();
        commonData.props = Json.Serialize(ftinfo); ;
        commonData.tplId = tmpID;

        ItemDetailData detaildata = new ItemDetailData();
        detaildata.setData(commonData);
        return detaildata.equipItemTemplate;
    }

    /// <summary>
    /// 设置一个装备的数据
    /// </summary>
    /// <param name="position"></param>
    private ItemDetailData SetEquipData(string position,IDictionary _equipDic) {
        
        IDictionary equipInfo = JsonHelper.GetDictData(position, _equipDic);
        if (equipInfo == null || equipInfo.Count <= 0)
        {
            mListDetail.Add(null);
            return null;
        }
        int tmpID = JsonHelper.GetIntData(ItemDefine.ItemPropKey.TemplateID, equipInfo);
        IDictionary ftinfo = JsonHelper.GetDictData(ItemDefine.ItemPropKey.Feature, equipInfo);

        CommonItemData commonData = new CommonItemData();
        commonData.props = Json.Serialize(ftinfo); ;
        commonData.tplId = tmpID;

        ItemDetailData detaildata = new ItemDetailData();
        detaildata.setData(commonData);
        mListDetail.Add(detaildata);
        return detaildata;
    }
    
    private void SetStarData(string position, IDictionary starData)
    {
        int star = 0;
        int.TryParse(starData[position].ToString(), out star);
        mStarDetail.Add(star);
    }

    #region 按钮响应

    private void FasongxinxiBtnOnClick(GameObject go)
    {
        hide();
        ChatModel.Ins.OpenRelationViewAndChat(mRankinfo.humanId.ToString(), mRankinfo.humanName, mRankinfo.level.ToString(), mRankinfo.humantplID.ToString());
    }

    private void JiaweihaoyouBtn(GameObject go)
    {
        RelationCGHandler.sendCGAddRelationById(RelationType.HAOYOU, mRankinfo.humanId);
    }

    private void YaoqingrubangBtnOnClick(GameObject go)
    {

    }

    private void CloseBtnOnClick(GameObject go)
    {
        hide();
    }

    #endregion

}

public class CRankInfo : RankInfo
{

    public bool isUpdate = false;

    public string humanHead;

    public int humantplID;

}
