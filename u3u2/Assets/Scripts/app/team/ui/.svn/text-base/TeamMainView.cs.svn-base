using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.net;
using app.human;
using app.db;
using app.utils;
using app.zone;
using app.model;
using app.chat;

namespace app.team
{
    public class TeamMainView : BaseWnd
    {
        //[Inject(ui = "TeamMainUI")]
        //public GameObject ui;
        public const string BIANJIEZUDUI_FUNC = "BIANJIEZUDUI_FUNC";


        public TeamMainUI UI;

        public FunctionModel functionModel;

        private TeamMemberListItem[] mTeamMemberList = null;

        private List<TeamMemberListItem> mApplyMemberList = new List<TeamMemberListItem>();

        private bool mNeedHideInviteOperList = false;
        private bool mNeedHideMyTeamListItemOperList = false;
        private bool mNeedEndChangePosOperate = false;
        private TeamMemberListItemUI mTeamMemberOperListHost = null;
        private long mChangePosTargetUUID = 0;
        
        private Coroutine mCreateApplyListCoroutine = null;

        public TeamMainView()
        {
            uiName = "TeamMainUI";
            TeamModel.ins.teamMainView = this;
        }

        public override void initWnd()
        {
            base.initWnd();

            functionModel = FunctionModel.Ins;
            functionModel.addChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.addChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);

            UI = ui.AddComponent<TeamMainUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(ClickClose);
            UI.myAndApplyBtnGroup.TabChangeHandler = OnMyAndApplyBtnGroupIdxChanged;
            UI.myAndApplyBtnGroup.SetIndexWithCallBack(0);
            UI.formBtnLabel.text = LangConstant.NO_FORM;
            UI.teamPurposeTxt.text = "";
            UI.teamLvLimitTxt.text = "";
            EventTriggerListener.Get(UI.teamPurposeHotArea).onClick = ShowTeamPurposeEditor;
            UI.teamPurposeEditBtn.SetClickCallBack(ShowTeamPurposeEditor);
            UI.applyTeamBtn.SetClickCallBack(ShowTeamApplyView);
            UI.autoMatchBtn.SetClickCallBack(OnAutoMatchBtnClicked);
            UI.cancelAutoMatchBtn.SetClickCallBack(OnCancelAutoMatchBtnClicked);
            UI.inviteBtn.SetClickCallBack(ShowInviteOperList);
            UI.inviteFriendBtn.SetClickCallBack(OnInviteFriendBtnClicked);
            UI.inviteGroupPartnerBtn.SetClickCallBack(OnInviteGroupPartnerBtnClicked);
            UI.createTeamBtn.SetClickCallBack(CreateTeam);
            UI.exitTeamBtn.SetClickCallBack(OnExitTeamBtnClicked);
            UI.leaveTeamBtn.SetClickCallBack(OnLeaveTeamBtnClicked);
            UI.backToTeamBtn.SetClickCallBack(OnBackToTeamBtnClicked);
            UI.myPartnerBtn.SetClickCallBack(OnMyPartnerBtnClicked);
            UI.sendNoticeBtn.SetClickCallBack(OnSendNoticeBtnClicked);
            UI.clearApplyListBtn.SetClickCallBack(OnClearApplyListBtnClicked);

            //弹出菜单按钮
            UI.sendMsgBtn.SetClickCallBack(OnSendMsgBtnClicked);
            UI.makeFriendBtn.SetClickCallBack(OnMakeFriendBtnCkicked);
            UI.makeTeamLeaderBtn.SetClickCallBack(OnMakeTeamLeaderBtnClicked);
            UI.changePosBtn.SetClickCallBack(OnChangePosBtnClicked);
            UI.kickOutBtn.SetClickCallBack(OnKickOutBtnClicked);
            UI.callBackBtn.SetClickCallBack(OnCallBackBtnClicked);

            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, HideInviteOperList);
            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, HideMyTeamMemberItemOperList);
            //UpdateTeamPurposeInfo(TeamModel.ins.teamPurposeInfo);

            if (mTeamMemberList == null)
            {
                CreateTeamMemberList();
            }
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UpdateTeamPurposeInfo(TeamModel.ins.teamPurposeInfo);
            UpdateTeamMemberList(TeamModel.ins.myTeamMemberList);

            int len = mApplyMemberList.Count;
            for (int i = 0; i < len; i++)
            {
                mApplyMemberList[i].ShowAvatarModel();
            }

            if (UI.myAndApplyBtnGroup.index == 1)
            {
                ShowApplyList();
            }
            

            OnFuncInfoChanged(null);
            app.main.GameClient.ins.OnBigWndShown();    
        }

        public override void Update()
        {
            base.Update();
            if (mTeamMemberList != null)
            {
                int len = mTeamMemberList.Length;
                for (int i = 0; i < len; i++)
                {
                    if (mTeamMemberList[i].GetData() != null)
                    {
                        mTeamMemberList[i].Update();
                    }
                }
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            int len = mTeamMemberList != null ? mTeamMemberList.Length : 0;
            for (int i = 0; i < len; i++)
            {
                if (mTeamMemberList[i] != null) mTeamMemberList[i].SetData(null);
            }

            len = mApplyMemberList.Count;
            for (int i = 0; i < len; i++)
            {
                mApplyMemberList[i].HideAvatarModel();
            }

            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
        }

        private void CreateTeamMemberList()
        {
            int len = UI.myTeamListItems.Count;
            mTeamMemberList = new TeamMemberListItem[len];
            for (int i = 0; i < len; i++)
            {
                UI.myTeamListItems[i].index = i;
                mTeamMemberList[i] = new TeamMemberListItem(UI.myTeamListItems[i]);
                EventTriggerListener.Get(UI.myTeamListItems[i].gameObject).onClick = OnMyTeamMemberItemClicked;
                mTeamMemberList[i].Hide();
            }
        }

        private void OnMyTeamMemberItemClicked(GameObject go)
        {
            if (mTeamMemberOperListHost == null || go != mTeamMemberOperListHost.gameObject)
            {
                TeamMemberListItemUI itemUI = go.GetComponent<TeamMemberListItemUI>();

                if (!itemUI.zhuzhan.activeSelf && itemUI.uuid != Human.Instance.Id)
                {
                    if (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id)
                    {
                        //自己是队长。
                        UI.sendMsgBtn.gameObject.SetActive(true);
                        UI.makeFriendBtn.gameObject.SetActive(true);
                        TeamMemberInfo teammemberInfo = TeamModel.ins.GetTeamMemberInfo(itemUI.uuid);
                        if (teammemberInfo.status != 2)
                        {
                            //暂离状态的队员不显示 升为队长
                            UI.makeTeamLeaderBtn.gameObject.SetActive(true);
                        }
                        else
                        {
                            UI.makeTeamLeaderBtn.gameObject.SetActive(false);
                        }
                        UI.changePosBtn.gameObject.SetActive(true);
                        UI.kickOutBtn.gameObject.SetActive(true);
                        UI.callBackBtn.gameObject.SetActive(true);
                    }
                    else
                    {
                        UI.sendMsgBtn.gameObject.SetActive(true);
                        UI.makeFriendBtn.gameObject.SetActive(true);
                        UI.makeTeamLeaderBtn.gameObject.SetActive(false);
                        UI.changePosBtn.gameObject.SetActive(false);
                        UI.kickOutBtn.gameObject.SetActive(false);
                        UI.callBackBtn.gameObject.SetActive(false);
                    }

                    Vector3 pos = go.transform.TransformPoint(Vector3.zero);
                    pos = UI.myTeamListItemOperList.transform.parent.InverseTransformPoint(pos);
                    Vector2 itemSize = go.GetComponent<RectTransform>().sizeDelta;
                    Vector2 operListSize = UI.myTeamListItemOperList.GetComponent<RectTransform>().sizeDelta;
                    if (itemUI.index == 4)
                    {
                        pos.x -= operListSize.x;
                    }
                    else
                    {
                        pos.x += itemSize.x;
                    }

                    pos.y = (itemSize.y - operListSize.y) / 2.0f;
                    pos.z = UI.myTeamListItemOperList.transform.localPosition.z;

                    UI.myTeamListItemOperList.transform.localPosition = pos;
                    UI.myTeamListItemOperList.SetActive(true);
                    mTeamMemberOperListHost = itemUI;
                    mNeedHideMyTeamListItemOperList = false;
                }
            }
        }

        private void HideMyTeamMemberItemOperList(RMetaEvent e)
        {
            if (mNeedHideMyTeamListItemOperList)
            {
                UI.myTeamListItemOperList.SetActive(false);
                mTeamMemberOperListHost = null;
            }

            mNeedHideMyTeamListItemOperList = !mNeedHideMyTeamListItemOperList;
        }

        public void UpdateTeamMemberList(TeamMemberInfo[] datas)
        {
            if (mTeamMemberList == null) return;
            int friendArrayIdx = Human.Instance.PetModel.curPetFriendArrayIdx;
            PetFriendArrayInfo friendArrayInfo = null;
            if (friendArrayIdx >= 0)
            {
                friendArrayInfo = Human.Instance.PetModel.petFriendArrayInfoList[friendArrayIdx];
            }
            int itemsCount = mTeamMemberList.Length;
            if (datas == null)
            {
                for (int i = 0; i < itemsCount; i++)
                {
                    mTeamMemberList[i].Hide();
                    mTeamMemberList[i].SetData(null);
                }
            }
            else
            {
                int len = Mathf.Min(datas.Length, itemsCount);
                for (int i = 0; i < len; i++)
                {
                    mTeamMemberList[i].Show();
                    mTeamMemberList[i].SetData(datas[i]);
                }

                for (int i = len; i < itemsCount; i++)
                {
                    if (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id && friendArrayInfo != null && (i - 1) < friendArrayInfo.tplIdList.Length && PropertyUtil.IsLegalID(friendArrayInfo.tplIdList[i - 1]))
                    {
                        //自己是队长并且当前位置有一个伙伴。
                        TeamMemberInfo info = new TeamMemberInfo();
                        PetTemplate tpl = PetTemplateDB.Instance.getTemplate(friendArrayInfo.tplIdList[i - 1]);
                        info.isFriend = 1;
                        info.isLeader = 0;
                        info.jobTypeId = tpl.jobId;
                        info.level = Human.Instance.getLevel();
                        info.name = tpl.name;
                        info.position = i + 1;
                        info.status = 1;
                        info.tplId = tpl.Id;
                        info.uuid = 0;
                        mTeamMemberList[i].Show();
                        mTeamMemberList[i].SetData(info);
                    }
                    else
                    {
                        mTeamMemberList[i].Hide();
                        mTeamMemberList[i].SetData(null);
                    }
                }
            }

            if (UI.myAndApplyBtnGroup.index == 0)
            {
                UpdateMyTeamBtns();
            }
        }

        public void ShowTeam()
        {
            UI.myAndApplyBtnGroup.SetIndexWithCallBack(0);
        }

        private void OnMyAndApplyBtnGroupIdxChanged(int curIndex)
        {
            if (curIndex == 0)
            {
                ShowMyTeam();
            }
            else
            {
                ShowApplyList();
            }
        }

        private void ShowMyTeam()
        {
            UI.myTeamList.SetActive(true);
            UI.myTeamListBg.SetActive(true);
            UI.teamApplyListScroll.SetActive(false);
            UI.teamApplyListBg.SetActive(false);
            UI.noApplyTips.SetActive(false);

            UpdateMyTeamBtns();

        }

        private void UpdateMyTeamBtns()
        {
            if (TeamModel.ins.myTeamMemberList == null)
            {
                ShowMyTeamNoTeamBtns();
            }
            else
            {
                bool isLeader = (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id);

                if (isLeader)
                {
                    ShowLeaderMyTeamHasTeamBtns();
                }
                else
                {
                    ShowNotLeaderMyTeamHasTeamBtns();
                }
            }
        }

        private void ShowApplyList()
        {
            UI.myTeamList.SetActive(false);
            UI.myTeamListBg.SetActive(false);
            UI.teamApplyListScroll.SetActive(true);
            UI.teamApplyListBg.SetActive(true);
            /*
            if (TeamModel.ins.teamApplyMemberList != null && TeamModel.ins.teamApplyMemberList.Length > 0)
            {
                UI.noApplyTips.SetActive(false);
            }
            else
            {
                UI.noApplyTips.SetActive(true);
            }
            */
            ShowApplyListBtns();

            TeamCGHandler.sendCGTeamApplyList();
        }

        public void UpdateApplyList(TeamMemberInfo[] data)
        {
            int len = mApplyMemberList.Count;
            for (int i = 0; i < len; i++)
            {
                mApplyMemberList[i].Destroy();
            }

            mApplyMemberList.Clear();

            if (data != null)
            {
                if (mCreateApplyListCoroutine != null)
                {
                    UI.StopCoroutine(mCreateApplyListCoroutine);
                    mCreateApplyListCoroutine = null;
                }
                mCreateApplyListCoroutine = UI.StartCoroutine(CreateApplyList(data));
            }

            if (UI.myAndApplyBtnGroup.index == 1)
            {
                if (data != null && data.Length > 0)
                {
                    UI.noApplyTips.SetActive(false);
                }
                else
                {
                    UI.noApplyTips.SetActive(true);
                }

                //ShowApplyListBtns();
            }
        }

        private IEnumerator CreateApplyList(TeamMemberInfo[] data)
        {
            int len = data.Length;

            for (int i = 0; i < len; i++)
            {
                GameObject itemGo = (GameObject)GameObject.Instantiate(UI.teamApplyListItemUI.gameObject);
                itemGo.transform.SetParent(UI.teamApplyListItemUI.transform.parent);
                itemGo.transform.localScale = UI.teamApplyListItemUI.transform.localScale;
                itemGo.SetActive(true);
                TeamMemberListItem item = new TeamMemberListItem(itemGo.GetComponent<TeamMemberListItemUI>());
                mApplyMemberList.Add(item);
                item.SetData(data[i]);
                yield return 0;
            }
            mCreateApplyListCoroutine = null;
        }

        /// <summary>
        /// 显示“我的队伍”面板无队伍时的按钮。
        /// </summary>
        public void ShowMyTeamNoTeamBtns()
        {
            UI.myAndApplyBtnGroup.gameObject.SetActive(false);
            UI.noTeamCreatedTips.SetActive(true);
            UI.formBtn.gameObject.SetActive(true);
            UI.teamPurposeHotArea.SetActive(false);
            UI.teamPurposeTxt.gameObject.SetActive(false);
            UI.teamLvLimitTxt.gameObject.SetActive(false);
            UI.teamPurposeEditBtn.gameObject.SetActive(false);
            UI.autoMatchBtn.gameObject.SetActive(false);
            UI.cancelAutoMatchBtn.gameObject.SetActive(false);
            UI.inviteBtn.gameObject.SetActive(false);
            UI.createTeamBtn.gameObject.SetActive(true);
            UI.exitTeamBtn.gameObject.SetActive(false);
            UI.myPartnerBtn.gameObject.SetActive(false);
            UI.applyTeamBtn.gameObject.SetActive(true);
            UI.leaveTeamBtn.gameObject.SetActive(false);
            UI.backToTeamBtn.gameObject.SetActive(false);
            UI.sendNoticeBtn.gameObject.SetActive(false);
            UI.clearApplyListBtn.gameObject.SetActive(false);
        }

        /// <summary>
        /// 显示“我的队伍”面板有队伍且自己是队长时的按钮。
        /// </summary>
        public void ShowLeaderMyTeamHasTeamBtns()
        {
            UI.myAndApplyBtnGroup.gameObject.SetActive(true);
            UI.myAndApplyBtnGroup.toggleList[0].gameObject.SetActive(true);
            UI.myAndApplyBtnGroup.toggleList[1].gameObject.SetActive(true);
            UI.noTeamCreatedTips.SetActive(false);
            UI.formBtn.gameObject.SetActive(true);
            UI.teamPurposeHotArea.SetActive(true);
            UI.teamPurposeTxt.gameObject.SetActive(true);
            UI.teamLvLimitTxt.gameObject.SetActive(true);
            UI.teamPurposeEditBtn.gameObject.SetActive(true);
            if (TeamModel.ins.teamPurposeInfo != null)
            {
                UI.autoMatchBtn.gameObject.SetActive(TeamModel.ins.teamPurposeInfo.getIsAutoMatch() == 0);
                UI.cancelAutoMatchBtn.gameObject.SetActive(TeamModel.ins.teamPurposeInfo.getIsAutoMatch() != 0);
            }
            else
            {
                UI.autoMatchBtn.gameObject.SetActive(false);
                UI.cancelAutoMatchBtn.gameObject.SetActive(false);
            }

            UI.inviteBtn.gameObject.SetActive(true);
            UI.createTeamBtn.gameObject.SetActive(false);
            UI.exitTeamBtn.gameObject.SetActive(true);
            UI.myPartnerBtn.gameObject.SetActive(false);
            UI.applyTeamBtn.gameObject.SetActive(false);
            UI.leaveTeamBtn.gameObject.SetActive(false);
            UI.backToTeamBtn.gameObject.SetActive(false);
            UI.sendNoticeBtn.gameObject.SetActive(true);
            UI.clearApplyListBtn.gameObject.SetActive(false);
        }

        /// <summary>
        /// 显示“我的队伍”面板有队伍且自己不是队长时的按钮。
        /// </summary>
        public void ShowNotLeaderMyTeamHasTeamBtns()
        {
            UI.myAndApplyBtnGroup.gameObject.SetActive(true);
            UI.myAndApplyBtnGroup.toggleList[0].gameObject.SetActive(true);
            UI.myAndApplyBtnGroup.toggleList[1].gameObject.SetActive(false);
            UI.noTeamCreatedTips.SetActive(false);
            UI.formBtn.gameObject.SetActive(true);
            UI.teamPurposeHotArea.SetActive(true);
            UI.teamPurposeTxt.gameObject.SetActive(true);
            UI.teamLvLimitTxt.gameObject.SetActive(true);
            UI.teamPurposeEditBtn.gameObject.SetActive(true);
            if (TeamModel.ins.teamPurposeInfo != null)
            {
                UI.autoMatchBtn.gameObject.SetActive(TeamModel.ins.teamPurposeInfo.getIsAutoMatch() == 0);
                UI.cancelAutoMatchBtn.gameObject.SetActive(TeamModel.ins.teamPurposeInfo.getIsAutoMatch() != 0);
            }
            else
            {
                UI.autoMatchBtn.gameObject.SetActive(false);
                UI.cancelAutoMatchBtn.gameObject.SetActive(false);
            }

            UI.inviteBtn.gameObject.SetActive(true);
            UI.createTeamBtn.gameObject.SetActive(false);
            UI.exitTeamBtn.gameObject.SetActive(true);
            UI.myPartnerBtn.gameObject.SetActive(false);
            UI.applyTeamBtn.gameObject.SetActive(false);

            int myStatus = TeamModel.ins.GetTeamMemberInfo(Human.Instance.Id).status;
            UI.leaveTeamBtn.gameObject.SetActive(myStatus == 1);
            UI.backToTeamBtn.gameObject.SetActive(myStatus == 2);

            UI.sendNoticeBtn.gameObject.SetActive(false);
            UI.clearApplyListBtn.gameObject.SetActive(false);
        }

        public void ShowApplyListBtns()
        {
            UI.myAndApplyBtnGroup.gameObject.SetActive(true);
            UI.myAndApplyBtnGroup.toggleList[0].gameObject.SetActive(true);
            UI.myAndApplyBtnGroup.toggleList[1].gameObject.SetActive(true);
            UI.formBtn.gameObject.SetActive(false);
            UI.teamPurposeHotArea.SetActive(false);
            UI.teamPurposeTxt.gameObject.SetActive(false);
            UI.teamLvLimitTxt.gameObject.SetActive(false);
            UI.teamPurposeEditBtn.gameObject.SetActive(false);
            UI.autoMatchBtn.gameObject.SetActive(false);
            UI.cancelAutoMatchBtn.gameObject.SetActive(false);
            UI.inviteBtn.gameObject.SetActive(false);
            UI.createTeamBtn.gameObject.SetActive(TeamModel.ins.myTeamMemberList == null);
            UI.exitTeamBtn.gameObject.SetActive(TeamModel.ins.myTeamMemberList != null);
            UI.myPartnerBtn.gameObject.SetActive(false);
            UI.applyTeamBtn.gameObject.SetActive(false);
            UI.leaveTeamBtn.gameObject.SetActive(false);
            UI.sendNoticeBtn.gameObject.SetActive(false);
            UI.clearApplyListBtn.gameObject.SetActive(true);
        }

        private void ShowTeamPurposeEditor(GameObject go)
        {
            if (TeamModel.ins.myTeamMemberList != null)
            {
                int len = TeamModel.ins.myTeamMemberList.Length;
                for (int i = 0; i < len; i++)
                {
                    TeamMemberInfo info = TeamModel.ins.myTeamMemberList[i];
                    if (info.isLeader != 0 && info.uuid == Human.Instance.Id)
                    {
                        WndManager.open(GlobalConstDefine.TeamPurposeEditorView_Name);
                        return;
                    }
                }

                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.ONLY_TEAM_LEADER_CAN_DO_IT);
            }
        }

        private void CreateTeam()
        {
            TeamCGHandler.sendCGTeamCreate();
        }

        private void ShowTeamApplyView()
        {
            WndManager.open(GlobalConstDefine.TeamApplyView_Name);
        }

        private void ShowInviteOperList()
        {
            UI.inviteOperList.SetActive(!UI.inviteOperList.activeSelf);
            mNeedHideInviteOperList = false;
        }

        private void OnInviteFriendBtnClicked()
        {
            TeamCGHandler.sendCGTeamInviteList(1);
        }

        private void OnInviteGroupPartnerBtnClicked()
        {
            TeamCGHandler.sendCGTeamInviteList(2);
        }

        private void HideInviteOperList(RMetaEvent e)
        {
            if (mNeedHideInviteOperList)
            {
                UI.inviteOperList.SetActive(false);
            }

            mNeedHideInviteOperList = !mNeedHideInviteOperList;
        }

        public void UpdateTeamPurposeInfo(GCTeamMyTeamInfo data)
        {
            if (data == null || !PropertyUtil.IsLegalID(data.getTargetId()))
            {
                UI.teamPurposeTxt.text = LangConstant.TARGET + LangConstant.NONE;
                UI.teamLvLimitTxt.text = "(" +
                    StringUtil.Assemble(LangConstant.LEVEL, new string[] { "1" }) +
                    "-" +
                    StringUtil.Assemble(LangConstant.LEVEL, new string[] { ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PLAYER_MAX_LEVEL).ToString() }) +
                    ")";

                if (TeamModel.ins.myTeamMemberList != null)
                {
                    UI.autoMatchBtn.gameObject.SetActive(true);
                    UI.cancelAutoMatchBtn.gameObject.SetActive(false);
                }
                else
                {
                    UI.autoMatchBtn.gameObject.SetActive(false);
                    UI.cancelAutoMatchBtn.gameObject.SetActive(false);
                }
            }
            else
            {
                TeamTargetTemplate tpl = TeamTargetTemplateDB.Instance.getTemplate(data.getTargetId());
                if (tpl != null)
                {
                    UI.teamPurposeTxt.text = LangConstant.TARGET + tpl.name;
                }
                else
                {
                    UI.teamPurposeTxt.text = LangConstant.TARGET + LangConstant.NONE;
                }

                UI.teamLvLimitTxt.text = "(" +
                    StringUtil.Assemble(LangConstant.LEVEL, new string[] { data.getLevelMin().ToString() }) +
                    "-" +
                    StringUtil.Assemble(LangConstant.LEVEL, new string[] { data.getLevelMax().ToString() }) +
                    ")";

                UI.autoMatchBtn.gameObject.SetActive(data.getIsAutoMatch() == 0);
                UI.cancelAutoMatchBtn.gameObject.SetActive(data.getIsAutoMatch() == 1);
            }
        }

        private void OnFormBtnClicked()
        {

        }

        private void OnAutoMatchBtnClicked()
        {
            if (TeamModel.ins.teamPurposeInfo != null && PropertyUtil.IsLegalID(TeamModel.ins.teamPurposeInfo.getTargetId()))
            {
                TeamCGHandler.sendCGTeamAutoMatch(1);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.PLEASE_SET_TEAM_TARGET_FIRST);
            }
        }

        private void OnCancelAutoMatchBtnClicked()
        {
            TeamCGHandler.sendCGTeamAutoMatch(0);
        }

        private void OnExitTeamBtnClicked()
        {
            TeamModel.ins.doTeamQuit();
        }

        private void OnLeaveTeamBtnClicked()
        {
            TeamModel.ins.doTeamAway();
        }

        private void OnBackToTeamBtnClicked()
        {
            TeamCGHandler.sendCGTeamBack();
        }

        private void OnMyPartnerBtnClicked()
        {
            WndManager.open(GlobalConstDefine.PartnerFormationView_Name);
        }

        private void OnSendNoticeBtnClicked()
        {
            TeamCGHandler.sendCGTeamChatSpeak();
        }

        private void OnClearApplyListBtnClicked()
        {
            TeamCGHandler.sendCGTeamApplyListClean();
        }

        private void OnSendMsgBtnClicked()
        {
            ChatModel.Ins.OpenRelationViewAndChat(mTeamMemberOperListHost.uuid.ToString(), mTeamMemberOperListHost.nameTxt.text, mTeamMemberOperListHost.level.ToString(), mTeamMemberOperListHost.tplId.ToString());
        }

        private void OnMakeFriendBtnCkicked()
        {
            RelationCGHandler.sendCGAddRelationById(1, mTeamMemberOperListHost.GetComponent<TeamMemberListItemUI>().uuid);
        }

        private void OnMakeTeamLeaderBtnClicked()
        {
            TeamCGHandler.sendCGTeamChangeLeader(mTeamMemberOperListHost.GetComponent<TeamMemberListItemUI>().uuid);
        }

        private void OnChangePosBtnClicked()
        {
            if (TeamModel.ins.GetTeamMemberInfo(Human.Instance.Id).isLeader == 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.ONLY_TEAM_LEADER_CAN_DO_IT);
            }
            else
            {
                if (!mTeamMemberOperListHost.duizhang.activeSelf && !mTeamMemberOperListHost.zhuzhan.activeSelf)
                {
                    int len = UI.myTeamListItems.Count;
                    for (int i = 0; i < len; i++)
                    {
                        TeamMemberListItemUI itemUI = UI.myTeamListItems[i];
                        if (itemUI.uuid != 0 && !itemUI.duizhang.activeSelf && !itemUI.zhuzhan.activeSelf && itemUI != mTeamMemberOperListHost)
                        {
                            mChangePosTargetUUID = mTeamMemberOperListHost.uuid;
                            itemUI.changePosMask.SetActive(true);
                            EventTriggerListener.Get(itemUI.gameObject).onClick = OnChangePosClicked;
                        }
                    }
                }

                mNeedEndChangePosOperate = false;

                InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, FinishChangePosOperate);
            }
        }

        private void OnChangePosClicked(GameObject go)
        {
            if (go != null)
            {
                TeamMemberListItemUI clickedItemUI = go.GetComponent<TeamMemberListItemUI>();
                TeamCGHandler.sendCGTeamChangePosition(mChangePosTargetUUID, clickedItemUI.index + 1);
                //FinishChangePosOperate();
            }
        }

        private void FinishChangePosOperate(RMetaEvent e = null)
        {
            if (mNeedEndChangePosOperate)
            {
                int len = UI.myTeamListItems.Count;
                for (int i = 0; i < len; i++)
                {
                    TeamMemberListItemUI itemUI = UI.myTeamListItems[i];
                    if (itemUI.changePosMask.activeSelf)
                    {
                        itemUI.changePosMask.SetActive(false);
                        EventTriggerListener.Get(itemUI.gameObject).onClick = OnMyTeamMemberItemClicked;
                    }
                }
                InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, FinishChangePosOperate);
            }

            mNeedEndChangePosOperate = !mNeedEndChangePosOperate;

        }

        private void OnKickOutBtnClicked()
        {
            TeamCGHandler.sendCGTeamKick(mTeamMemberOperListHost.GetComponent<TeamMemberListItemUI>().uuid);
        }

        private void OnCallBackBtnClicked()
        {
            TeamCGHandler.sendCGTeamCallBack(mTeamMemberOperListHost.GetComponent<TeamMemberListItemUI>().uuid);
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.TEAM_MEMBER_CALLBACKING);
        }

        private void ClickClose()
        {
            hide();
        }

        private void OnFuncInfoChanged(RMetaEvent e)
        {
            UI.myAndApplyBtnGroup.toggleList[1].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.DUIWU);
        }

        public override void Destroy()
        {
            int len = 0;
            if (mApplyMemberList != null)
            {
                len = mApplyMemberList.Count;
                for (int i = 0; i < len; i++)
                {
                    mApplyMemberList[i].Destroy();
                }
                mApplyMemberList.Clear();
            }
            len = mTeamMemberList != null ? mTeamMemberList.Length : 0;
            for (int i = 0; i < len; i++)
            {
                if (mTeamMemberList[i] != null) mTeamMemberList[i].Destroy();
            }
            mTeamMemberList = null;
            if (UI != null)
            {
                InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, HideInviteOperList);
                InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject,
                    HideMyTeamMemberItemOperList);
                InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, FinishChangePosOperate);
            }
            functionModel.removeChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.removeChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);
            if (TeamModel.ins != null)
            {
                TeamModel.ins.teamMainView = null;
            }
            base.Destroy();
            UI = null;
        }
    }
}