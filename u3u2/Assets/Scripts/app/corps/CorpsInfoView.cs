using System.Collections.Generic;
using app.net;
using app.chat;
using UnityEngine;
using UnityEngine.UI;
using app.db;
using app.zone;
using app.corp;

/// <summary>
/// 我的帮派 信息 页签
/// </summary>
public class CorpsInfoView:BaseUI
{
    public BangPaiXinXiUI UI;

    public CorpModel corpModel;

    public InputField zongzhiInputText;

    private List<CorpListItemScript> onLineList;
    
    private ChatModel mChatModel = null;

    private CorpsOfMineView corpsOfmineView;

    public CorpsInfoView(BangPaiXinXiUI ui,CorpsOfMineView corpsOfmineView)
    {
        UI = ui;
        base.ui = ui.gameObject;
        corpModel = CorpModel.Ins;
        corpModel.addChangeEvent(CorpModel.UPDATE_CORP_MEMBER_LIST, updateOnLineList);
        UI.xiugaizongzhiBtn.SetClickCallBack(xiugaiZongzhi);
        UI.listTBG.ReSelected = true;
        UI.listTBG.TabChangeHandler = selectOneMember;
        UI.huidaoBtn.SetClickCallBack(OnClickHuidaobangpai);
        closeOperateList();
        this.corpsOfmineView = corpsOfmineView;
    }

    public void updateInfo()
    {
        DetailCorpsInfo corpInfo = corpModel.MyCorpInfo.getDetailCorpsInfo();
        UI.mingcheng.text = corpInfo.name;
        UI.bangzhu.text = corpInfo.presidentName;
        UI.dengji.text = "Lv."+corpInfo.level;
        CorpsUpgradeTemplate template = CorpsUpgradeTemplateDB.Instance.getTemplate(corpInfo.level);
        UI.renshu.text = corpInfo.currMemNum+"/" + template.maxMemberNum;
        UI.jingyan.text = corpInfo.currExp.ToString();
        UI.shengjijingyan.text = template.upgradeExp.ToString();
        UI.zijin.text = corpInfo.currFund.ToString();
        UI.meiriweihu.text = template.coprsMaintenanceCost.ToString();
        UI.zongzhiShowText.text = corpInfo.notice;
        updateOnLineList();
    }

    private void xiugaiZongzhi()
    {
        if (zongzhiInputText==null)
        {
            zongzhiInputText = CreateInputField(Color.black, 20, UI.zongzhiBg,true);
            zongzhiInputText.onEndEdit.AddListener(doSubmit);
            zongzhiInputText.characterLimit = 36;
        }
        zongzhiInputText.gameObject.SetActive(true);
        UI.zongzhiShowText.gameObject.SetActive(false);
        zongzhiInputText.ActivateInputField();
        updateOnLineList();
    }

    private void doSubmit(string str)
    {
        CorpsCGHandler.sendCGCorpsNoticeUpdate("",str);
        zongzhiInputText.gameObject.SetActive(false);
        UI.zongzhiShowText.gameObject.SetActive(true);
    }

    public void updateOnLineList(RMetaEvent e=null)
    {
        if (onLineList==null)
        {
            onLineList = new List<CorpListItemScript>();
        }
        UI.defaultItemUI.gameObject.SetActive(false);
        if (corpModel.MemberList==null)
        {
            return;
        }
        List<CorpsMemberInfo> totalMember = corpModel.MemberList;
        int totalNum = totalMember.Count;
        int onlineNum = 0;
        UI.listTBG.ClearToggleList();
        for (int i = 0; i < totalNum; i++)
        {
            if (totalMember[i].onlineDesc==LangConstant.ZAIXIAN)
            {
                if (onlineNum>=onLineList.Count)
                {
                    BangPaiListItemUI item = GameObject.Instantiate(UI.defaultItemUI);
                    item.gameObject.SetActive(true);
                    item.transform.SetParent(UI.grid.transform);
                    item.transform.localScale = Vector3.one;
                    CorpListItemScript script = new CorpListItemScript(item);
                    onLineList.Add(script);
                }
                onLineList[onlineNum].UI.gameObject.SetActive(true);
                onLineList[onlineNum].UI.SetIndex(onlineNum);
                UI.listTBG.AddToggle(onLineList[onlineNum].UI.toggle);
                onLineList[onlineNum].setInfoMemberInfo(totalMember[i]);
                onlineNum++;
            }
        }
        UI.zaixianrenshu.text = LangConstant.ZAIXIAN_RENSHU + "：" + onlineNum;
        for (int i=onlineNum;i<onLineList.Count;i++)
        {
            onLineList[i].UI.gameObject.SetActive(false);
        }
    }

    public void OnClickHuidaobangpai()
    {
        List<MapTemplate> maps = MapTemplateDB.Instance.GetMapListByMapType(app.zone.MapType.CORPS_MAIN);
        if (maps != null && maps.Count > 0)
        {
            ZoneModel.ins.sendCGMapPlayerEnter(maps[0].Id);
            corpsOfmineView.hide();
        }
    }

    #region 操作列表 逻辑

    private void closeOperateList(GameObject go=null)
    {
        UI.OperateListGo.SetActive(false);
        EventTriggerListener.Get(UI.gameObject).onClick = null;
    }

    private bool hasAddOperateListener = false;
    private void selectOneMember(int tab)
    {
        if (!hasAddOperateListener)
        {
            hasAddOperateListener = true;
            UI.liaotianBtn.SetClickCallBack(clickliaotian);
            UI.addFriendBtn.SetClickCallBack(clickAddFriend);
            //InputManager.Ins.AddListener(InputManager.CLICK_EVENT_TYPE, UI.gameObject, closeOperateList);
        }
        GCCorpsMemberInfo mymemberinfo = corpModel.MyCorpMemberInfo;
        if (mymemberinfo.getCorpsMemInfo().name == onLineList[tab].MemberData.name)
        {
            closeOperateList();
            //同一个人 不处理
            return;
        }
        UI.OperateListGo.SetActive(true);
        EventTriggerListener.Get(UI.gameObject).onClick = closeOperateList;
    }

    private void clickliaotian()
    {
        closeOperateList();
        int tab = UI.listTBG.index;
        if (tab>=0&&tab<onLineList.Count)
        {
            CorpsMemberInfo memberInfo = onLineList[tab].MemberData;
            if (mChatModel == null)
            {
                //mChatModel = (Singleton.getObj(typeof (ChatModel)) as ChatModel);
                mChatModel = ChatModel.Ins;
            }
            //mChatModel.SaveZuiJinLianXiRen(memberInfo.memId.ToString(), memberInfo.name, memberInfo.level.ToString(), memberInfo.tplId.ToString());
            //RelationView relationView = (RelationView)WndManager.open(GlobalConstDefine.RelationView_Name, "ChatWithCorpsMember");
            mChatModel.OpenRelationViewAndChat(memberInfo.memId.ToString(), memberInfo.name, memberInfo.level.ToString(), memberInfo.tplId.ToString());
        }
    }

    private void clickAddFriend()
    {
        int tab = UI.listTBG.index;
        if (tab>=0&&tab<onLineList.Count)
        {
            CorpsCGHandler.sendCGClickCorpsMemberFunction(onLineList[tab].MemberData.memId,CorpFuncIdDef.ADD_FRIEND);
        }
        closeOperateList();
    }

    #endregion
    
    public override void Destroy()
    {
        corpModel.removeChangeEvent(CorpModel.UPDATE_CORP_MEMBER_LIST, updateOnLineList);

        zongzhiInputText=null;
        for (int i=0;i<onLineList.Count;i++)
        {
            onLineList[i].Destroy();
            onLineList[i] = null;
        }
        onLineList.Clear();
        onLineList=null;
    
        base.Destroy();
        UI = null;
    }

}
