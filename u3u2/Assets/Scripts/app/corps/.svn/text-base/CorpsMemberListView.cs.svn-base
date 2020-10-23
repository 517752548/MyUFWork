using System.Collections.Generic;
using System.Linq;
using app.human;
using app.net;
using app.role;
using app.zone;
using app.chat;
using UnityEngine;
using UnityEngine.UI;
using app.confirm;

/// <summary>
/// 我的 帮派成员 页签
/// </summary>

public class CorpsMemberListView : BaseUI
{

    private static Vector3 sOperateListOffset = new Vector3(4, -1.3f, 0);
    public BangPaiMemberListUI memberUI;
    public BangPaiShenQingListUI shenqingUI;
    public BangPaiShiJianListUI shijianUI;
    public TabButtonGroup chengyuanTBG;
    public GameObject chengyuanGo;


    private List<CorpListItemScript> memberList;
    private List<CorpListItemScript> shenqingList;
    private List<CorpListItemScript> shijianList;

    private ChatModel mChatModel = null;

    public CorpsMemberListView(TabButtonGroup chengyuanTBGv,
        BangPaiMemberListUI memberUIv,
        BangPaiShenQingListUI shenqingUIv,
        BangPaiShiJianListUI shijianUIv,
        GameObject chengyuanGov)
    {
        chengyuanTBG = chengyuanTBGv;
        memberUI = memberUIv;
        shenqingUI = shenqingUIv;
        shijianUI = shijianUIv;
        chengyuanGo = chengyuanGov;
        
        CorpModel.Ins.addChangeEvent(CorpModel.UPDATE_CORP_MEMBER_LIST, UpdateMemberList);
        CorpModel.Ins.addChangeEvent(CorpModel.UPDATE_MY_CORP_INFO, updateMyCorpInfo);
        CorpModel.Ins.addChangeEvent(CorpModel.UPDATE_MY_CORP_MEMBER_INFO, updateBtns);

        chengyuanTBG.TabChangeHandler = changeTab;
        chengyuanTBG.SetIndexWithCallBack(0);

        memberUI.xianshiOnLine.SetValueChangedCallBack(selectOnline);
        memberUI.listTBG.ReSelected = true;
        memberUI.listTBG.TabChangeHandler = selectOneMember;

        shenqingUI.shuaxinBtn.SetClickCallBack(refreshShenQingList);
        shenqingUI.qingkongBtn.SetClickCallBack(clearShenQingList);

        CloseOperateList();
        EventTriggerListener.Get(memberUI.tfopreateListBg.gameObject).onClick = CloseOperateList;
        initSortBtns();
    }

    private void refreshShenQingList()
    {
        CorpsCGHandler.sendCGOpenCorpsPanel();
    }

    private void clearShenQingList()
    {
        long corpId = Human.Instance.PropertyManager.getLongProp(RoleBaseStrProperties.MY_CORP_ID);
        if (corpId > 0)
        {
            CorpsCGHandler.sendCGClickCorpsFunction(corpId, CorpFuncIdDef.HULUE_ALL_SHENQING);
        }
    }

    public void updateMyCorpInfo(RMetaEvent e = null)
    {
        updateJieSan();
        updateShenQingList();
    }

    #region 权限操作列表

    private void CloseOperateList(GameObject go = null)
    {
        memberUI.OperateListGo.SetActive(false);
        EventTriggerListener.Get(chengyuanGo).onClick = null;
    }

    private bool hasAddOperateListener = false;
    private void selectOneMember(int tab)
    {
        if (!hasAddOperateListener)
        {
            hasAddOperateListener = true;
            memberUI.LiaoTianBtn.SetClickCallBack(clickliaotian);
            memberUI.RMJingYingBtn.SetClickCallBack(RMJingying);
            memberUI.RMFuBangZhuBtn.SetClickCallBack(RMFuBangZhu);
            memberUI.ZHRBangZhuBtn.SetClickCallBack(ZHRBangZhu);
            memberUI.JWBangZhongBtn.SetClickCallBack(JWBangZhong);
            memberUI.QLBangPai.SetClickCallBack(QLBangPai);
            //InputManager.Ins.AddListener(InputManager.CLICK_EVENT_TYPE, chengyuanGo.gameObject, closeOperateList);
        }
        //选择的人的职位
        int memzhiwei = memberList[tab].MemberData.memJob;
        //我的职位
        GCCorpsMemberInfo mymemberinfo = CorpModel.Ins.MyCorpMemberInfo;
        if (mymemberinfo.getCorpsMemInfo().name == memberList[tab].MemberData.name)
        {
            CloseOperateList();
            //同一个人 不处理
            return;
        }
        memberUI.OperateListGo.SetActive(true);
      memberUI.OperateListGo.transform.position = memberList[tab].UI.transform.position + sOperateListOffset;
        
        EventTriggerListener.Get(chengyuanGo).onClick = CloseOperateList;
        switch (mymemberinfo.getCorpsMemInfo().memJob)
        {
            case (int)CorpTitleDef.CorpTitleType.BANGZHU:
                switch (memzhiwei)
                {
                    case (int)CorpTitleDef.CorpTitleType.BANGZHU:
                        break;
                    case (int)CorpTitleDef.CorpTitleType.FUBANGZHU:
                        memberUI.RMJingYingBtn.gameObject.SetActive(true);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(false);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(true);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(true);
                        memberUI.QLBangPai.gameObject.SetActive(true);
                        break;
                    case (int)CorpTitleDef.CorpTitleType.JINGYING:
                        memberUI.RMJingYingBtn.gameObject.SetActive(false);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(true);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(true);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(true);
                        memberUI.QLBangPai.gameObject.SetActive(true);
                        break;
                    case (int)CorpTitleDef.CorpTitleType.BANGZHONG:
                        memberUI.RMJingYingBtn.gameObject.SetActive(true);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(true);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(true);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(false);
                        memberUI.QLBangPai.gameObject.SetActive(true);
                        break;
                }
                break;
            case (int)CorpTitleDef.CorpTitleType.FUBANGZHU:
                switch (memzhiwei)
                {
                    case (int)CorpTitleDef.CorpTitleType.BANGZHU:
                        memberUI.RMJingYingBtn.gameObject.SetActive(false);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(false);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(false);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(false);
                        memberUI.QLBangPai.gameObject.SetActive(false);
                        break;
                    case (int)CorpTitleDef.CorpTitleType.FUBANGZHU:
                        memberUI.RMJingYingBtn.gameObject.SetActive(false);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(false);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(false);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(false);
                        memberUI.QLBangPai.gameObject.SetActive(false);
                        break;
                    case (int)CorpTitleDef.CorpTitleType.JINGYING:
                        memberUI.RMJingYingBtn.gameObject.SetActive(false);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(false);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(false);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(true);
                        memberUI.QLBangPai.gameObject.SetActive(true);
                        break;
                    case (int)CorpTitleDef.CorpTitleType.BANGZHONG:
                        memberUI.RMJingYingBtn.gameObject.SetActive(true);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(false);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(false);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(false);
                        memberUI.QLBangPai.gameObject.SetActive(true);
                        break;
                }
                break;
            case (int)CorpTitleDef.CorpTitleType.JINGYING:
            case (int)CorpTitleDef.CorpTitleType.BANGZHONG:
            case (int)CorpTitleDef.CorpTitleType.NONE:
                switch (memzhiwei)
                {
                    case (int)CorpTitleDef.CorpTitleType.BANGZHU:
                        memberUI.RMJingYingBtn.gameObject.SetActive(false);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(false);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(false);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(false);
                        memberUI.QLBangPai.gameObject.SetActive(false);
                        break;
                    case (int)CorpTitleDef.CorpTitleType.FUBANGZHU:
                        memberUI.RMJingYingBtn.gameObject.SetActive(false);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(false);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(false);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(false);
                        memberUI.QLBangPai.gameObject.SetActive(false);
                        break;
                    case (int)CorpTitleDef.CorpTitleType.JINGYING:
                        memberUI.RMJingYingBtn.gameObject.SetActive(false);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(false);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(false);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(false);
                        memberUI.QLBangPai.gameObject.SetActive(false);
                        break;
                    case (int)CorpTitleDef.CorpTitleType.BANGZHONG:
                        memberUI.RMJingYingBtn.gameObject.SetActive(false);
                        memberUI.RMFuBangZhuBtn.gameObject.SetActive(false);
                        memberUI.ZHRBangZhuBtn.gameObject.SetActive(false);
                        memberUI.JWBangZhongBtn.gameObject.SetActive(false);
                        memberUI.QLBangPai.gameObject.SetActive(false);
                        break;
                }
                break;
        }
    }

    private void clickliaotian()
    {
        CloseOperateList();
        int tab = memberUI.listTBG.index;
        if (tab >= 0 && tab < memberList.Count)
        {
            CorpsMemberInfo memberInfo = memberList[tab].MemberData;
            if (mChatModel == null)
            {
                // mChatModel = (Singleton.getObj(typeof(ChatModel)) as ChatModel);
                mChatModel = ChatModel.Ins;
            }
            //mChatModel.SaveZuiJinLianXiRen(memberInfo.memId.ToString(), memberInfo.name, memberInfo.level.ToString(), memberInfo.tplId.ToString());
            //RelationView relationView = (RelationView)WndManager.open(GlobalConstDefine.RelationView_Name, "ChatWithCorpsMember");
            mChatModel.OpenRelationViewAndChat(memberInfo.memId.ToString(), memberInfo.name, memberInfo.level.ToString(), memberInfo.tplId.ToString());
        }
    }
    private void RMJingying()
    {
        CloseOperateList();
        int tab = memberUI.listTBG.index;
        if (tab >= 0 && tab < memberList.Count)
        {
            CorpsCGHandler.sendCGClickCorpsMemberFunction(memberList[tab].MemberData.memId, CorpFuncIdDef.RENMING_JINGYING);
        }
    }
    private void RMFuBangZhu()
    {
        CloseOperateList();
        int tab = memberUI.listTBG.index;
        if (tab >= 0 && tab < memberList.Count)
        {
            CorpsCGHandler.sendCGClickCorpsMemberFunction(memberList[tab].MemberData.memId, CorpFuncIdDef.RENMING_FUBANGZHU);
        }
    }

    private void querenZHRBangZhu(RMetaEvent e)
    {
        int tab = memberUI.listTBG.index;
        if (tab >= 0 && tab < memberList.Count)
        {
            CorpsCGHandler.sendCGClickCorpsMemberFunction(memberList[tab].MemberData.memId, CorpFuncIdDef.ZHUANRANG_BANGZHU);
        }
    }

    private void ZHRBangZhu()
    {
        int tab = memberUI.listTBG.index;
        if (tab >= 0 && tab < memberList.Count)
        {
            CloseOperateList();
            ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, LangConstant.ZHUANRANG_BANGZHU + memberList[tab].MemberData.name, querenZHRBangZhu, null);
        }
    }

    private void JWBangZhong()
    {
        CloseOperateList();
        int tab = memberUI.listTBG.index;
        if (tab >= 0 && tab < memberList.Count)
        {
            CorpsCGHandler.sendCGClickCorpsMemberFunction(memberList[tab].MemberData.memId, CorpFuncIdDef.RENMING_BANGZHONG);
        }
    }

    private void QLBangPai()
    {
        CloseOperateList();
        int tab = memberUI.listTBG.index;
        if (tab >= 0 && tab < memberList.Count)
        {
            CorpsCGHandler.sendCGClickCorpsMemberFunction(memberList[tab].MemberData.memId, CorpFuncIdDef.KAICHU_MEMBER);
        }
    }
    #endregion

    #region 按钮列排序

    private SortButton currentSelectedSortButton = null;
    private int currentSortType = 0;

    private SortButton mingcheng;
    private SortButton dengji;
    private SortButton zhiye;
    private SortButton zhiwu;
    private SortButton banggong;
    private SortButton lishibanggong;
    private SortButton zuihouzaixian;
    private bool hasInitSortBtns = false;
    private List<SortButton> sortBtnList;
    private void initSortBtns()
    {
        if (!hasInitSortBtns)
        {
            mingcheng = new SortButton(memberUI.mingchengBtn, mingchengSort);
            dengji = new SortButton(memberUI.dengjiBtn, dengjiSort);
            zhiye = new SortButton(memberUI.zhiyeBtn, zhiyeSort);
            zhiwu = new SortButton(memberUI.zhiwuBtn, zhiwuSort);
            banggong = new SortButton(memberUI.banggongBtn, banggongSort);
            lishibanggong = new SortButton(memberUI.lishiBanggongBtn, lishibanggongSort);
            zuihouzaixian = new SortButton(memberUI.zuihouzaixianBtn, zuihouzaixianSort);
            sortBtnList = new List<SortButton>();
            sortBtnList.Add(mingcheng);
            sortBtnList.Add(dengji);
            sortBtnList.Add(zhiye);
            sortBtnList.Add(zhiwu);
            sortBtnList.Add(banggong);
            sortBtnList.Add(lishibanggong);
            sortBtnList.Add(zuihouzaixian);
            hasInitSortBtns = true;
        }
    }

    private void mingchengSort(int type)
    {
        currentSelectedSortButton = mingcheng;
        currentSortType = type;
        List<CorpsMemberInfo> list = CorpModel.Ins.MemberList;
        if (type < 0)
        {
            list.Sort((a, b) => (a.name.CompareTo(b.name)));
        }
        else
        {
            list.Sort((a, b) => (b.name.CompareTo(a.name)));
        }
        for (int i = 0; i < sortBtnList.Count; i++)
        {
            if (sortBtnList[i] != mingcheng)
            {
                sortBtnList[i].setToNormal();
            }
        }
        updateMemberList(true);
    }

    private void dengjiSort(int type)
    {
        currentSelectedSortButton = dengji;
        currentSortType = type;
        List<CorpsMemberInfo> list = CorpModel.Ins.MemberList;
        if (type < 0)
        {
            list.Sort((a, b) => (a.level.CompareTo(b.level)));
        }
        else
        {
            list.Sort((a, b) => (b.level.CompareTo(a.level)));
        }
        for (int i = 0; i < sortBtnList.Count; i++)
        {
            if (sortBtnList[i] != dengji)
            {
                sortBtnList[i].setToNormal();
            }
        }
        updateMemberList(true);
    }

    private void zhiyeSort(int type)
    {
        currentSelectedSortButton = zhiye;
        currentSortType = type;
        List<CorpsMemberInfo> list = CorpModel.Ins.MemberList;
        if (type < 0)
        {
            list.Sort((a, b) => (a.petJob.CompareTo(b.petJob)));
        }
        else
        {
            list.Sort((a, b) => (b.petJob.CompareTo(a.petJob)));
        }
        for (int i = 0; i < sortBtnList.Count; i++)
        {
            if (sortBtnList[i] != zhiye)
            {
                sortBtnList[i].setToNormal();
            }
        }
        updateMemberList(true);
    }

    private void zhiwuSort(int type)
    {
        currentSelectedSortButton = zhiwu;
        currentSortType = type;
        List<CorpsMemberInfo> list = CorpModel.Ins.MemberList;
        if (type < 0)
        {
            list.Sort((a, b) => (a.memJob.CompareTo(b.memJob)));
        }
        else
        {
            list.Sort((a, b) => (b.memJob.CompareTo(a.memJob)));
        }
        for (int i = 0; i < sortBtnList.Count; i++)
        {
            if (sortBtnList[i] != zhiwu)
            {
                sortBtnList[i].setToNormal();
            }
        }
        updateMemberList(true);
    }

    private void banggongSort(int type)
    {
        currentSelectedSortButton = banggong;
        currentSortType = type;
        List<CorpsMemberInfo> list = CorpModel.Ins.MemberList;
        if (type < 0)
        {
            list.Sort((a, b) => (a.weekContribution.CompareTo(b.weekContribution)));
        }
        else
        {
            list.Sort((a, b) => (b.weekContribution.CompareTo(a.weekContribution)));
        }
        for (int i = 0; i < sortBtnList.Count; i++)
        {
            if (sortBtnList[i] != banggong)
            {
                sortBtnList[i].setToNormal();
            }
        }
        updateMemberList(true);
    }

    private void lishibanggongSort(int type)
    {
        currentSelectedSortButton = lishibanggong;
        currentSortType = type;
        List<CorpsMemberInfo> list = CorpModel.Ins.MemberList;
        if (type < 0)
        {
            list.Sort((a, b) => (a.totalContribution.CompareTo(b.totalContribution)));
        }
        else
        {
            list.Sort((a, b) => (b.totalContribution.CompareTo(a.totalContribution)));
        }
        for (int i = 0; i < sortBtnList.Count; i++)
        {
            if (sortBtnList[i] != lishibanggong)
            {
                sortBtnList[i].setToNormal();
            }
        }
        updateMemberList(true);
    }

    private void zuihouzaixianSort(int type)
    {
        currentSelectedSortButton = zuihouzaixian;
        currentSortType = type;
        List<CorpsMemberInfo> list = CorpModel.Ins.MemberList;
        list.Sort(new SortlastOfflineTime(type));
        //if (type < 0)
        //{
        //    list.Sort((a, b) => (a.lastOfflineTime.CompareTo(b.lastOfflineTime)));
        //}
        //else
        //{
        //    list.Sort((a, b) => (b.lastOfflineTime.CompareTo(a.lastOfflineTime)));
        //}
        for (int i = 0; i < sortBtnList.Count; i++)
        {
            if (sortBtnList[i] != zuihouzaixian)
            {
                sortBtnList[i].setToNormal();
            }
        }
        updateMemberList(true);
    }

    #endregion

    #region 不同职位的权限功能按钮 逻辑

    private bool hasAddBtnListener = false;

    public void updateBtns(RMetaEvent e = null)
    {
        GCCorpsMemberInfo mymemberinfo = CorpModel.Ins.MyCorpMemberInfo;
        if (mymemberinfo != null && mymemberinfo.getCorpsMemInfo() != null)
        {
            switch (mymemberinfo.getCorpsMemInfo().memJob)
            {
                case (int)CorpTitleDef.CorpTitleType.BANGZHU:
                    memberUI.bangzhuBtnsGo.SetActive(true);
                    memberUI.fubangzhuBtnsGo.SetActive(false);
                    memberUI.bangzhongBtnsGo.SetActive(false);
                    memberUI.bangzhuBtns[0].gameObject.SetActive(true);
                    memberUI.bangzhuBtns[1].gameObject.SetActive(false);
                    memberUI.bangzhuBtns[2].gameObject.SetActive(false);
                    memberUI.bangzhuBtns[3].gameObject.SetActive(true);
                    memberUI.bangzhuBtns[4].gameObject.SetActive(false);
                    memberUI.bangzhuBtns[5].gameObject.SetActive(false);
                    //申请列表按钮
                    chengyuanTBG.toggleList[1].gameObject.SetActive(true);
                    break;
                case (int)CorpTitleDef.CorpTitleType.FUBANGZHU:
                    memberUI.bangzhuBtnsGo.SetActive(false);
                    memberUI.fubangzhuBtnsGo.SetActive(true);
                    memberUI.bangzhongBtnsGo.SetActive(false);
                    memberUI.fubangzhuBtns[1].gameObject.SetActive(true);
                    memberUI.fubangzhuBtns[2].gameObject.SetActive(false);
                    memberUI.fubangzhuBtns[3].gameObject.SetActive(false);
                    //申请列表按钮
                    chengyuanTBG.toggleList[1].gameObject.SetActive(true);
                    break;
                case (int)CorpTitleDef.CorpTitleType.JINGYING:
                case (int)CorpTitleDef.CorpTitleType.BANGZHONG:
                case (int)CorpTitleDef.CorpTitleType.NONE:
                    memberUI.bangzhuBtnsGo.SetActive(false);
                    memberUI.fubangzhuBtnsGo.SetActive(false);
                    memberUI.bangzhongBtnsGo.SetActive(true);
                    //申请列表按钮
                    chengyuanTBG.toggleList[1].gameObject.SetActive(false);
                    break;
            }
        }

        if (!hasAddBtnListener)
        {
            List<GameUUButton> bangzhuBtns = memberUI.bangzhuBtns;
            List<GameUUButton> fubangzhuBtns = memberUI.fubangzhuBtns;
            List<GameUUButton> bangzhongBtns = memberUI.bangzhongBtns;
            if (bangzhuBtns != null)
            {
                for (int i = 0; i < bangzhuBtns.Count; i++)
                {
                    //EventTriggerListener.Get(bangzhuBtns[i].gameObject).onClick = clickBangZhuFuncBtns;
                    bangzhuBtns[i].SetClickCallBack(clickBangZhuFuncBtns);
                }
            }

            if (fubangzhuBtns != null)
            {
                for (int i = 0; i < fubangzhuBtns.Count; i++)
                {
                    //EventTriggerListener.Get(fubangzhuBtns[i].gameObject).onClick = clickFuBangZhuFuncBtns;
                    fubangzhuBtns[i].SetClickCallBack(clickFuBangZhuFuncBtns);
                }
            }

            if (bangzhongBtns != null)
            {
                for (int i = 0; i < bangzhongBtns.Count; i++)
                {
                    //EventTriggerListener.Get(bangzhongBtns[i].gameObject).onClick = clickBangZhongBtns;
                    bangzhongBtns[i].SetClickCallBack(clickBangZhongBtns);
                }
            }
            hasAddBtnListener = true;
        }
    }

    private void clickBangZhuFuncBtns(GameObject go)
    {
        int index = -1;
        for (int i = 0; i < memberUI.bangzhuBtns.Count; i++)
        {
            if (memberUI.bangzhuBtns[i].gameObject == go)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            switch (index)
            {
                case 0:
                    clickJieSan();
                    break;
                case 1:
                    querenJieSan();
                    break;
                case 2:
                    quxiaoJieSan();
                    break;
                case 3:
                    tichuChengyuan();
                    break;
                case 4:
                    querenTichu();
                    break;
                case 5:
                    quxiaoTichu();
                    break;
                case 6:
                    bangpaiLiebiao();
                    break;
                case 7:
                    Qunfaxiaoxi();
                    break;
            }
        }
    }

    private void clickFuBangZhuFuncBtns(GameObject go)
    {
        int index = -1;
        for (int i = 0; i < memberUI.fubangzhuBtns.Count; i++)
        {
            if (memberUI.fubangzhuBtns[i].gameObject == go)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            switch (index)
            {
                case 0:
                    tuolibangpai();
                    break;
                case 1:
                    tichuChengyuan();
                    break;
                case 2:
                    querenTichu();
                    break;
                case 3:
                    quxiaoTichu();
                    break;
                case 4:
                    bangpaiLiebiao();
                    break;
                case 5:
                    Qunfaxiaoxi();
                    break;
            }
        }
    }

    private void clickBangZhongBtns(GameObject go)
    {
        int index = -1;
        for (int i = 0; i < memberUI.bangzhongBtns.Count; i++)
        {
            if (memberUI.bangzhongBtns[i].gameObject == go)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            switch (index)
            {
                case 0:
                    tuolibangpai();
                    break;
                case 1:
                    bangpaiLiebiao();
                    break;
            }
        }
    }

    private void tuolibangpai()
    {
        ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, LangConstant.SURE_TUILI_BANGPAI, sureTuolibangpai, null);
    }

    private void sureTuolibangpai(RMetaEvent e)
    {
        long corpId = Human.Instance.PropertyManager.getLongProp(RoleBaseStrProperties.MY_CORP_ID);
        if (corpId > 0)
        {
            CorpsCGHandler.sendCGClickCorpsFunction(corpId, CorpFuncIdDef.EXIT_CORP);
        }
    }

    private void bangpaiLiebiao()
    {
        CorpsCGHandler.sendCGClickCorpsPanel();
    }

    #endregion

    #region 群发邮件 逻辑

    private bool hasInitMail = false;

    private void Qunfaxiaoxi()
    {
        if (!hasInitMail)
        {
            //标题
            memberUI.sendMailGo.zhutiInput = CreateInputField(Color.black, 20, memberUI.sendMailGo.zhutiBg,false,InputField.InputType.Standard,10,-10);
            memberUI.sendMailGo.zhutiInput.textComponent.alignment = TextAnchor.UpperLeft;
            //内容
            memberUI.sendMailGo.neirongInput = CreateInputField(Color.black, 20, memberUI.sendMailGo.neirongBg,true,InputField.InputType.Standard,10,-10);
            memberUI.sendMailGo.neirongInput.textComponent.alignment = TextAnchor.UpperLeft;

            memberUI.sendMailGo.closeBtn.SetClickCallBack(closeSendMail);
            memberUI.sendMailGo.fasongBtn.SetClickCallBack(sendMail);

            hasInitMail = true;
        }
        memberUI.sendMailGo.gameObject.SetActive(true);
    }

    private void closeSendMail()
    {
        memberUI.sendMailGo.gameObject.SetActive(false);
    }

    private void sendMail()
    {
        string biaoti = memberUI.sendMailGo.zhutiInput.text;
        string neirong = memberUI.sendMailGo.neirongInput.text;
        MailCGHandler.sendCGSendGuildMail(biaoti, neirong);
        closeSendMail();
    }

    #endregion

    #region 剔除逻辑

    private void tichuChengyuan()
    {
        GCCorpsMemberInfo mymemberinfo = CorpModel.Ins.MyCorpMemberInfo;
        if (mymemberinfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.BANGZHU)
        {
            //我是帮主，我能剔除除自己外的所有人
            bool cantichu = false;
            for (int i = 0; i < memberList.Count; i++)
            {
                if (!(memberList[i].MemberData.memJob == (int)CorpTitleDef.CorpTitleType.BANGZHU))
                {
                    memberList[i].changeSelectToggleVisi(true);
                    cantichu = true;
                }
                else
                {
                    memberList[i].changeSelectToggleVisi(false);
                }
            }
            if (cantichu)
            {
                memberUI.bangzhuBtns[3].gameObject.SetActive(false);
                memberUI.bangzhuBtns[4].gameObject.SetActive(true);
                memberUI.bangzhuBtns[5].gameObject.SetActive(true);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.NO_TICHU_MEMBER);
            }
        }
        else if (mymemberinfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.FUBANGZHU)
        {
            //我是副帮主，我能剔除 除帮主和副帮主外的所有人
            bool cantichu = false;
            for (int i = 0; i < memberList.Count; i++)
            {
                if (!(memberList[i].MemberData.memJob == (int)CorpTitleDef.CorpTitleType.BANGZHU)
                    && !(memberList[i].MemberData.memJob == (int)CorpTitleDef.CorpTitleType.FUBANGZHU))
                {
                    memberList[i].changeSelectToggleVisi(true);
                    cantichu = true;
                }
                else
                {
                    memberList[i].changeSelectToggleVisi(false);
                }
            }
            if (cantichu)
            {
                memberUI.fubangzhuBtns[1].gameObject.SetActive(false);
                memberUI.fubangzhuBtns[2].gameObject.SetActive(true);
                memberUI.fubangzhuBtns[3].gameObject.SetActive(true);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.NO_TICHU_MEMBER);
            }
        }
    }

    private void quxiaoTichu()
    {
        GCCorpsMemberInfo mymemberinfo = CorpModel.Ins.MyCorpMemberInfo;
        if (mymemberinfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.BANGZHU)
        {
            memberUI.bangzhuBtns[3].gameObject.SetActive(true);
            memberUI.bangzhuBtns[4].gameObject.SetActive(false);
            memberUI.bangzhuBtns[5].gameObject.SetActive(false);
        }
        else if (mymemberinfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.FUBANGZHU)
        {
            memberUI.fubangzhuBtns[1].gameObject.SetActive(true);
            memberUI.fubangzhuBtns[2].gameObject.SetActive(false);
            memberUI.fubangzhuBtns[3].gameObject.SetActive(false);
        }
        for (int i = 0; i < memberList.Count; i++)
        {
            memberList[i].changeSelectToggleVisi(false);
        }
    }

    private void querenTichu()
    {
        GCCorpsMemberInfo mymemberinfo = CorpModel.Ins.MyCorpMemberInfo;
        if (mymemberinfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.BANGZHU)
        {
            memberUI.bangzhuBtns[3].gameObject.SetActive(true);
            memberUI.bangzhuBtns[4].gameObject.SetActive(false);
            memberUI.bangzhuBtns[5].gameObject.SetActive(false);
        }
        else if (mymemberinfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.FUBANGZHU)
        {
            memberUI.fubangzhuBtns[1].gameObject.SetActive(true);
            memberUI.fubangzhuBtns[2].gameObject.SetActive(false);
            memberUI.fubangzhuBtns[3].gameObject.SetActive(false);
        }
        List<long> targetIds = new List<long>();
        for (int i = 0; i < memberList.Count; i++)
        {
            if (memberList[i].IsToggleSelected())
            {
                targetIds.Add(memberList[i].MemberData.memId);
            }
        }
        for (int i = 0; i < memberList.Count; i++)
        {
            memberList[i].changeSelectToggleVisi(false);
        }
        if (targetIds.Count > 0)
        {
            CorpsCGHandler.sendCGCorpsBatchFireMember(targetIds.ToArray());
        }
    }

    #endregion

    #region 解散逻辑

    private RTimer jiesanTimer;
    /// <summary>
    /// 根据帮派解散倒计时 显示
    /// </summary>
    private void updateJieSan()
    {
        long jiesanshijian = CorpModel.Ins.MyCorpInfo.getDetailCorpsInfo().disbandConfirmDate;
        if (jiesanshijian > 0)
        {
            memberUI.jiesanDaojishiGo.SetActive(true);
            if (jiesanTimer != null)
            {
                jiesanTimer.stop();
            }
            //结束时间
            //DateTime jieshuDate = new DateTime(1970, 1, 1);
            //jieshuDate = jieshuDate.AddMilliseconds(jiesanshijian);
            //DateTime now = DateTime.Now;
            //long elapsedTicks = jieshuDate.Ticks - now.Ticks;
            //TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            jiesanTimer = TimerManager.Ins.createTimer(1000, (int)jiesanshijian, onTimer, timerEnd);
            jiesanTimer.start();

            memberUI.bangzhuBtns[0].gameObject.SetActive(false);
            memberUI.bangzhuBtns[1].gameObject.SetActive(false);
            memberUI.bangzhuBtns[2].gameObject.SetActive(true);
        }
        else
        {
            memberUI.jiesanDaojishiGo.SetActive(false);
            memberUI.bangzhuBtns[0].gameObject.SetActive(true);
            memberUI.bangzhuBtns[1].gameObject.SetActive(false);
            memberUI.bangzhuBtns[2].gameObject.SetActive(false);
        }
    }

    private void onTimer(RTimer rtimer)
    {
        memberUI.daojishiText.text = TimeString.getTimeFormat(rtimer.getLeftTime() / 1000);
    }

    private void timerEnd(RTimer rtimer)
    {
        rtimer.stop();
        memberUI.jiesanDaojishiGo.SetActive(false);
        //解散
        memberUI.bangzhuBtns[0].gameObject.SetActive(false);
        //确认解散
        memberUI.bangzhuBtns[1].gameObject.SetActive(true);
        //取消解散
        memberUI.bangzhuBtns[2].gameObject.SetActive(true);
    }

    private void clickJieSan()
    {
        ConfirmWnd.Ins.ShowConfirm(LangConstant.SURE_JIESAN_BANGPAI, LangConstant.JIESAN_BANGPAI_TISHI, surejiesan, null);
    }

    private void surejiesan(RMetaEvent e)
    {
        memberUI.jiesanDaojishiGo.gameObject.SetActive(true);
        //解散
        memberUI.bangzhuBtns[0].gameObject.SetActive(false);
        //确认解散
        memberUI.bangzhuBtns[1].gameObject.SetActive(false);
        //取消解散
        memberUI.bangzhuBtns[2].gameObject.SetActive(true);
        long corpId = Human.Instance.PropertyManager.getLongProp(RoleBaseStrProperties.MY_CORP_ID);
        if (corpId > 0)
        {
            CorpsCGHandler.sendCGClickCorpsFunction(corpId, CorpFuncIdDef.JIESAN_BANGPAI);
            return;
        }
        ClientLog.LogError("没有帮派 你解散个啥");
    }

    private void quxiaoJieSan()
    {
        memberUI.jiesanDaojishiGo.gameObject.SetActive(false);
        memberUI.bangzhuBtns[0].gameObject.SetActive(true);
        memberUI.bangzhuBtns[1].gameObject.SetActive(false);
        memberUI.bangzhuBtns[2].gameObject.SetActive(false);
        long corpId = Human.Instance.PropertyManager.getLongProp(RoleBaseStrProperties.MY_CORP_ID);
        if (corpId > 0)
        {
            CorpsCGHandler.sendCGClickCorpsFunction(corpId, CorpFuncIdDef.CANCEL_JIESAN_BANGPAI);
            return;
        }
        ClientLog.Log("没有帮派 你取消个啥");
    }

    private void querenJieSan()
    {
        hide();
        long corpId = Human.Instance.PropertyManager.getLongProp(RoleBaseStrProperties.MY_CORP_ID);
        if (corpId > 0)
        {
            CorpsCGHandler.sendCGClickCorpsFunction(corpId, CorpFuncIdDef.SURE_JIESAN_BANGPAI);
            return;
        }
        ClientLog.Log("没有帮派 你确认个啥");
    }

    #endregion 

    private void selectOnline(bool onlyonline)
    {
        UpdateMemberList();
    }

    private void changeTab(int tab)
    {
        switch (tab)
        {
            case 0:
                memberUI.gameObject.SetActive(true);
                shenqingUI.gameObject.SetActive(false);
                shijianUI.gameObject.SetActive(false);
                CorpsCGHandler.sendCGOpenCorpsMemberList();
                //updateMemberList();
                break;
            case 1:
                memberUI.gameObject.SetActive(false);
                shenqingUI.gameObject.SetActive(true);
                shijianUI.gameObject.SetActive(false);
                updateShenQingList();
                break;
            case 2:
                memberUI.gameObject.SetActive(false);
                shenqingUI.gameObject.SetActive(false);
                shijianUI.gameObject.SetActive(true);
                updateShiJianList();
                break;
        }
    }

    public void UpdateMemberList(RMetaEvent e = null)
    {
        if (currentSelectedSortButton != null)
        {
            if (currentSelectedSortButton == mingcheng)
            {
                mingchengSort(currentSortType);
            }
            else if (currentSelectedSortButton == dengji)
            {
                dengjiSort(currentSortType);
            }
            else if (currentSelectedSortButton == zhiye)
            {
                zhiyeSort(currentSortType);
            }
            else if (currentSelectedSortButton == zhiwu)
            {
                zhiwuSort(currentSortType);
            }
            else if (currentSelectedSortButton == banggong)
            {
                banggongSort(currentSortType);
            }
            else if (currentSelectedSortButton == lishibanggong)
            {
                lishibanggongSort(currentSortType);
            }
            else if (currentSelectedSortButton == zuihouzaixian)
            {
                zuihouzaixianSort(currentSortType);
            }
        }
        else
        {
            updateMemberList();
        }
    }

    /// <summary>
    /// 刷新成员列表  flat为true 第一次进入  进行界面默认排序
    /// </summary>
    /// <param name="e"></param>
    private void updateMemberList(bool flat = false)
    {
        if (memberList == null)
        {
            memberList = new List<CorpListItemScript>();
        }

        memberUI.defaultMemberItemUI.gameObject.SetActive(false);
        List<CorpsMemberInfo> totalMember = CorpModel.Ins.MemberList;
        if (!flat)
        {
            totalMember.Sort(SortDefault);
        }
        int totalNum = totalMember.Count;
        int onlineNum = 0;
        bool onlyOnline = memberUI.xianshiOnLine.isOn;
        memberUI.listTBG.ClearToggleList();
        for (int i = 0; i < totalNum; i++)
        {
            if ((onlyOnline && totalMember[i].onlineDesc == LangConstant.ZAIXIAN) || !onlyOnline)
            {
                if (onlineNum >= memberList.Count)
                {
                    BangPaiListItemUI item = GameObject.Instantiate(memberUI.defaultMemberItemUI);
                    item.gameObject.SetActive(true);
                    item.transform.SetParent(memberUI.listGrid.transform);
                    item.transform.localScale = Vector3.one;
                  
                    CorpListItemScript script = new CorpListItemScript(item);
                    memberList.Add(script);

                   
                }
                memberUI.listTBG.AddToggle(memberList[onlineNum].UI.toggle);
                memberList[onlineNum].UI.SetIndex(onlineNum);
                memberList[onlineNum].UI.gameObject.SetActive(true);
                memberList[onlineNum].setListMemberInfo(totalMember[i], onlineNum);
                onlineNum++;
            }
        }
        for (int i = onlineNum; i < memberList.Count; i++)
        {
            memberList[i].UI.gameObject.SetActive(false);
        }



    }

    /// <summary>
    /// 帮派申请列表
    /// </summary>
    /// <param name="e"></param>
    public void updateShenQingList(RMetaEvent e = null)
    {
        GCCorpsMemberInfo mymemberinfo = CorpModel.Ins.MyCorpMemberInfo;
        if (mymemberinfo == null || mymemberinfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.JINGYING
            || mymemberinfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.BANGZHONG)
        {
            return;
        }
        if (shenqingList == null)
        {
            shenqingList = new List<CorpListItemScript>();
        }
        if (shenqingUI == null)
        {
            ClientLog.LogError("shenqingUI is null");
            return;
        }
        shenqingUI.defaultListItemUI.gameObject.SetActive(false);

        if (CorpModel.Ins.MyCorpInfo == null)
        {
            ClientLog.LogError("myCorpInfo is null");
            return;
        }

        List<MemberApplyInfo> totalMember = CorpModel.Ins.MyCorpInfo.getMemberApplyInfoList().ToList();
        int totalNum = totalMember.Count;
        for (int i = 0; i < totalNum; i++)
        {
            if (i >= shenqingList.Count)
            {
                BangPaiListItemUI item = GameObject.Instantiate(shenqingUI.defaultListItemUI);
                item.gameObject.SetActive(true);
                item.transform.SetParent(shenqingUI.listGrid.transform);
                item.transform.localScale = Vector3.one;
                CorpListItemScript script = new CorpListItemScript(item);
                shenqingList.Add(script);
            }
            shenqingList[i].UI.SetIndex(i);
            shenqingList[i].UI.gameObject.SetActive(true);
            shenqingList[i].setShenQingData(totalMember[i], i + 1);
        }
        for (int i = totalNum; i < shenqingList.Count; i++)
        {
            shenqingList[i].UI.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 帮派事件列表
    /// </summary>
    /// <param name="e"></param>
    public void updateShiJianList(RMetaEvent e = null)
    {
        if (shijianList == null)
        {
            shijianList = new List<CorpListItemScript>();
        }
        shijianUI.defaultItemUI.gameObject.SetActive(false);
        List<CorpsEventInfo> totalMember = CorpModel.Ins.MyCorpInfo.getCorpsEventInfoList().ToList();
        int totalNum = totalMember.Count;
        for (int i = 0; i < totalNum; i++)
        {
            if (i >= shijianList.Count)
            {
                BangPaiListItemUI item = GameObject.Instantiate(shijianUI.defaultItemUI);
                item.gameObject.SetActive(true);
                item.transform.SetParent(shijianUI.listGrid.transform);
                item.transform.localScale = Vector3.one;
                CorpListItemScript script = new CorpListItemScript(item);
                shijianList.Add(script);
            }
            shijianList[i].UI.SetIndex(i);
            shijianList[i].UI.gameObject.SetActive(true);
            shijianList[i].setShiJian(totalMember[i]);
        }
        for (int i = totalNum; i < shijianList.Count; i++)
        {
            shijianList[i].UI.gameObject.SetActive(false);
        }
    }

    public int SortDefault(CorpsMemberInfo x, CorpsMemberInfo y)
    {

        if (x.memJob == 4 || y.memJob == 4)
        {
            ////玩家和帮主比较玩家在前
            //if (x.memId == Human.Instance.Id && y.memJob == 4) return -1;
            //if (y.memId == Human.Instance.Id && x.memJob == 4) return 1;
            ////玩家和其他比较 玩家在前
            //if (x.memId == Human.Instance.Id) return -1;
            //if (y.memId == Human.Instance.Id) return 1;
            //帮主和其他比较 帮主在前

        }
        if (x.memJob == 4 && y.memJob != 4) return -1;
        if (y.memJob == 4 && x.memJob != 4) return 1;

        if (x.onlineDesc == LangConstant.ZAIXIAN && y.onlineDesc == LangConstant.ZAIXIAN)
        {
            if (x.memJob > y.memJob) return -1;
            if (x.memJob < y.memJob) return 1;
            if (x.memJob == y.memJob)
            {
                if (x.weekContribution > y.weekContribution) return -1;
                if (x.weekContribution < y.weekContribution) return 1;
                if (x.weekContribution == y.weekContribution)
                {
                    if (x.memId > y.memId) return -1;
                    if (x.memId < y.memId) return 1;
                }
            }
        }
        if (x.onlineDesc == LangConstant.ZAIXIAN && y.onlineDesc != LangConstant.ZAIXIAN)
            return -1;
        if (x.onlineDesc != LangConstant.ZAIXIAN && y.onlineDesc == LangConstant.ZAIXIAN)
            return 1;
        if (x.onlineDesc != LangConstant.ZAIXIAN && y.onlineDesc != LangConstant.ZAIXIAN)
        {
            if (x.memJob > y.memJob) return -1;
            if (x.memJob < y.memJob) return 1;
            if (x.memJob == y.memJob)
            {
                if (x.weekContribution > y.weekContribution) return -1;
                if (x.weekContribution < y.weekContribution) return 1;
                if (x.weekContribution == y.weekContribution)
                {
                    if (x.memId > y.memId) return -1;
                    if (x.memId < y.memId) return 1;
                }
            }
        }

        return 0;
    }
    
    public override void Destroy()
    {
        CorpModel.Ins.removeChangeEvent(CorpModel.UPDATE_CORP_MEMBER_LIST, UpdateMemberList);
        CorpModel.Ins.removeChangeEvent(CorpModel.UPDATE_MY_CORP_INFO, updateMyCorpInfo);
        CorpModel.Ins.removeChangeEvent(CorpModel.UPDATE_MY_CORP_MEMBER_INFO, updateBtns);

        if (memberUI.gameObject)
        {
            GameObject.DestroyImmediate(memberUI.gameObject, true);
        }
        if (shenqingUI.gameObject)
        {
            GameObject.DestroyImmediate(shenqingUI.gameObject, true);
        }
        if (shijianUI.gameObject)
        {
            GameObject.DestroyImmediate(shijianUI.gameObject, true);
        }
        if (chengyuanGo)
        {
            GameObject.DestroyImmediate(chengyuanGo.gameObject, true);
        }
        
        memberUI=null;
        shenqingUI=null;
        shijianUI=null;
        chengyuanTBG=null;
        chengyuanGo=null;

        for (int i = 0; memberList!=null&&i < memberList.Count; i++)
        {
            memberList[i].Destroy();
            memberList[i] = null;
        }
        if (memberList != null)
        {
            memberList.Clear();
            memberList = null;
        }
        for (int i = 0; shenqingList!=null&&i < shenqingList.Count; i++)
        {
            shenqingList[i].Destroy();
            shenqingList[i] = null;
        }
        if (shenqingList != null)
        {
            shenqingList.Clear();
            shenqingList = null;
        }
        for (int i = 0; shijianList!=null&&i < shijianList.Count; i++)
        {
            shijianList[i].Destroy();
            shijianList[i] = null;
        }
        if (shijianList != null)
        {
            shijianList.Clear();
            shijianList = null;
        }
        
        if (jiesanTimer != null)
        {
            jiesanTimer.stop();
            jiesanTimer = null;
        }
        base.Destroy();
    }
}

public class SortlastOfflineTime : IComparer<CorpsMemberInfo>
{

    int mType = 1;

    public SortlastOfflineTime(int type)
    {
        mType = type;
    }


    public int Compare(CorpsMemberInfo x, CorpsMemberInfo y)
    {
        if (x.onlineDesc == LangConstant.ZAIXIAN && y.onlineDesc == LangConstant.ZAIXIAN)
            return 0;
        if (x.onlineDesc == LangConstant.ZAIXIAN && y.onlineDesc != LangConstant.ZAIXIAN)
            return 1 * mType;
        if (x.onlineDesc != LangConstant.ZAIXIAN && y.onlineDesc == LangConstant.ZAIXIAN)
            return -1 * mType;
        if (x.onlineDesc != LangConstant.ZAIXIAN && y.onlineDesc != LangConstant.ZAIXIAN)
        {
            if (x.lastOfflineTime > y.lastOfflineTime)
            {
                return 1 * mType;
            }
            if (x.lastOfflineTime < y.lastOfflineTime)
            {
                return -1 * mType;
            }
            if (x.lastOfflineTime == y.lastOfflineTime)
            {
                return 0;
            }
        }

        return 0;
    }


}