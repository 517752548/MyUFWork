using UnityEngine;
using System;
using System.Collections.Generic;
using app.net;
using app.state;
using app.zone;
using app.human;
using app.db;
using app.confirm;

namespace app.team
{
    public class TeamManager
    {
        private static TeamManager mIns = new TeamManager();

        public static TeamManager ins
        {
            get
            {
                return mIns;
            }
        }

        public TeamManager()
        {
            if (TeamManager.ins != null)
            {
                throw new Exception("TeamManager instance already exists!");
            }
        }

        /// <summary>
        /// 收到我的队伍列表。
        /// </summary>
        public void OnReceivedMyTeamMemberList(TeamMemberInfo[] data)
        {
            TeamModel.ins.myTeamMemberList = data;

            if (ZoneCharacterManager.ins.self != null)
            {
                ZoneCharacterManager.ins.self.isLeader = (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id);
            }

            if (TeamModel.ins.teamMainView != null && TeamModel.ins.teamMainView.isShown)
            {
                TeamModel.ins.teamMainView.UpdateTeamMemberList(data);
            }

            if (data == null)
            {
                ZoneModel.ins.isCanMoveFreely = true;
            }
            else
            {
                if (TeamModel.ins.teamApplyView != null && TeamModel.ins.teamApplyView.isShown)
                {
                    TeamModel.ins.teamApplyView.hide();
                }

                TeamMemberInfo myInfo = TeamModel.ins.GetTeamMemberInfo(Human.Instance.Id);

                if (myInfo.isLeader != 0)
                {
                    ZoneModel.ins.isCanMoveFreely = true;
                    if (StateManager.Ins.getCurState().state == StateDef.zoneState)
                    {
                        ZoneCharacterManager.ins.TeamMembersFollowMe(ZoneCharacterManager.ins.self.localPosition);
                    }
                }
                else
                {
                    ZoneModel.ins.isCanMoveFreely = (myInfo.status != 1);
                    if (!ZoneModel.ins.isCanMoveFreely && StateManager.Ins.getCurState().state == StateDef.zoneState)
                    {
                        ZoneCharacter leader = ZoneCharacterManager.ins.GetCharacter(TeamModel.ins.GetLeaderUUID());
                        if (leader != null)
                        {
                            ZoneCharacterManager.ins.TeamLeaderPosUpdated(leader);
                        }
                    }
                }
            }

            if (StateManager.Ins.getCurState().state == StateDef.zoneState || StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                if (ZoneUI.ins.isShown)
                {
                    ZoneUI.ins.UpdateTeamInfo();
                }
            }

            if (!ZoneModel.ins.isCanMoveFreely && ZoneManager.ins.curZoneInited && ZoneCharacterManager.ins.self != null)
            {
                ZoneCharacter leader = ZoneCharacterManager.ins.GetCharacter(TeamModel.ins.GetLeaderUUID());
                if (leader != null)
                {
                    ZoneModel.ins.teamLeaderLTPixelPos = ZoneUtil.ConvertUnityPos2LeftTopPixelPos(leader.localPosition);
                    ZoneCharacterManager.ins.TeamLeaderPosUpdated(leader);
                }
            }
            TeamModel.ins.dispatchUpdateTeamListEvent();
        }

        /// <summary>
        /// 收到申请入队的玩家列表。
        /// </summary>
        public void OnReceivedTeamApplyMemberList(TeamMemberInfo[] data)
        {
            TeamModel.ins.teamApplyMemberList = data;
            if (TeamModel.ins.teamMainView != null && TeamModel.ins.teamMainView.isShown)
            {
                TeamModel.ins.teamMainView.UpdateApplyList(data);
            }
        }

        /// <summary>
        /// 收到我的队伍信息。
        /// </summary>
        public void OnReceivedMyTeamInfo(GCTeamMyTeamInfo data)
        {
            TeamModel.ins.teamPurposeInfo = data;
            if (TeamModel.ins.teamMainView != null && TeamModel.ins.teamMainView.isShown)
            {
                TeamModel.ins.teamMainView.UpdateTeamPurposeInfo(data);
            }

            if (TeamModel.ins.teamPurposeEditorView != null && TeamModel.ins.teamPurposeEditorView.isShown)
            {
                TeamModel.ins.teamPurposeEditorView.UpdateTeamPurposeInfo(data);
            }

            if (StateManager.Ins.getCurState().state == StateDef.zoneState || StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                if (ZoneUI.ins.isShown)
                {
                    //ZoneUI.ins.UpdateTeamInfo();
                }
            }
        }

        /// <summary>
        /// 收到队伍列表。
        /// </summary>
        public void OnReceivedTeamApplyList(TeamInfo[] data)
        {
            if (TeamModel.ins.teamApplyView != null && TeamModel.ins.teamApplyView.isShown)
            {
                TeamModel.ins.teamApplyView.ShowTeamList(data);
            }
        }

        /// <summary>
        /// 申请入队成功。
        /// </summary>
        /// <param name="teamId">Team identifier.</param>
        public void OnReceivedTeamApplySuccss(int teamId)
        {
            if (TeamModel.ins.teamApplyView != null && TeamModel.ins.teamApplyView.isShown)
            {
                TeamModel.ins.teamApplyView.SetApplyItemToApplied(teamId);
            }
        }

        /// <summary>
        /// 接收到自动匹配申请列表中的队伍的消息。
        /// </summary>
        public void OnReceivedTeamApplyAuto(GCTeamApplyAuto teamApplyAuto)
        {
            TeamModel.ins.teamApplyAuto = teamApplyAuto;
            if (TeamModel.ins.teamApplyView != null && TeamModel.ins.teamApplyView.isShown)
            {
                TeamModel.ins.teamApplyView.OnReceivedTeamApplyAuto();
            }

            if (StateManager.Ins.getCurState().state == StateDef.zoneState || StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                if (ZoneUI.ins.isShown)
                {
                    ZoneUI.ins.UpdateTeamInfo();
                }
            }
            TeamModel.ins.dispatchUpdateTeamListEvent();
        }

        /// <summary>
        /// 收到邀请成员列表。
        /// </summary>
        /// <param name="inviteType">1、好友，2、帮派。</param>
        /// <param name="data">Data.</param>
        public void OnReceivedInviteList(int inviteType, TeamInvitePlayerInfo[] data)
        {
            TeamModel.ins.teamInviteListType = inviteType;
            TeamModel.ins.teamInviteList = data;

            if (TeamModel.ins.teamInviteView != null && TeamModel.ins.teamInviteView.isShown)
            {
                TeamModel.ins.teamInviteView.ShowInviteList(inviteType, data);
            }
            else
            {
                WndManager.open(GlobalConstDefine.TeamInviteView_Name);
            }
        }

        /// <summary>
        /// 邀请成员成功。
        /// </summary>
        /// <param name="targetPlayerId">Target player identifier.</param>
        public void OnReceivedInviteSuccess(long targetPlayerId)
        {
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.TEAM_INVITE_SUCCESS);
            if (TeamModel.ins.teamInviteView != null && TeamModel.ins.teamInviteView.isShown)
            {
                TeamModel.ins.teamInviteView.SetInviteItemToInvited(targetPlayerId);
            }
        }

        /// <summary>
        /// 收到队伍邀请。
        /// </summary>
        /// <param name="teamId">Team identifier.</param>
        public void OnReceivedTeamInviteNotice(int teamId, string inviteName)
        {
            TeamTargetTemplate teamTargetTpl = null;
            if (TeamModel.ins.teamPurposeInfo != null)
            {
                teamTargetTpl = TeamTargetTemplateDB.Instance.getTemplate(TeamModel.ins.teamPurposeInfo.getTargetId());
            }
            ConfirmWnd.Ins.ShowConfirm("组队邀请", inviteName + " 邀请你加入队伍", OnAcceptInvite, OnRefuseInvite).data = teamId;
        }

        private void OnAcceptInvite(RMetaEvent e)
        {
            int teamId = (int)(e.data);
            TeamCGHandler.sendCGTeamInvitePlayerAnswer(teamId, 1);
        }

        private void OnRefuseInvite(RMetaEvent e)
        {
            int teamId = (int)(e.data);
            TeamCGHandler.sendCGTeamInvitePlayerAnswer(teamId, 0);
        }

        /// <summary>
        /// 收到归队邀请。
        /// </summary>
        public void OnReceivedTeamCallBackNotice()
        {
            ConfirmWnd.Ins.ShowConfirm("", LangConstant.TEAM_CALL_BACK_TIPS, OnConfirmCallBack);
        }

        private void OnConfirmCallBack(RMetaEvent e)
        {
            TeamCGHandler.sendCGTeamBack();
        }

        public void OnReceivedTeamQuit()
        {
            if (TeamModel.ins.hasTeam())
            {
                OnReceivedMyTeamInfo(null);
                OnReceivedMyTeamMemberList(null);
                OnReceivedTeamApplyList(null);
                OnReceivedTeamApplyAuto(null);
                if (TeamModel.ins.teamMainView != null && TeamModel.ins.teamMainView.isShown)
                {
                    TeamModel.ins.teamMainView.ShowTeam();
                }
            }
        }
    }
}