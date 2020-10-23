using System;
using System.Collections.Generic;
using app.fuben;
using app.net;
using app.confirm;

namespace app.team
{
    public class TeamModel
    {
        public const string UPDATE_TEAM_LIST = "UPDATE_TEAM_LIST";

        public TeamMemberInfo[] myTeamMemberList { get; set; }
        public TeamMemberInfo[] teamApplyMemberList { get; set; }
        public GCTeamMyTeamInfo teamPurposeInfo { get; set; }
        public GCTeamApplyAuto teamApplyAuto { get; set; }
        public int teamInviteListType { get; set; }
        public TeamInvitePlayerInfo[] teamInviteList { get; set; }

        public TeamMainView teamMainView { get; set; }
        public TeamApplyView teamApplyView { get; set; }
        public TeamPurposeEditorView teamPurposeEditorView { get; set; }
        public TeamInviteView teamInviteView { get; set; }


        private static TeamModel mIns;

        public static TeamModel ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new TeamModel();
                }
                return mIns;
            }
        }


        public long GetLeaderUUID()
        {
            if (myTeamMemberList == null)
            {
                return 0;
            }

            int len = myTeamMemberList.Length;
            for (int i = 0; i < len; i++)
            {
                if (myTeamMemberList[i].isLeader != 0)
                {
                    return myTeamMemberList[i].uuid;
                }
            }
            return 0;
        }

        public TeamMemberInfo GetTeamMemberInfo(long uuid)
        {
            if (myTeamMemberList == null)
            {
                return null;
            }

            int len = myTeamMemberList.Length;
            for (int i = 0; i < len; i++)
            {
                if (myTeamMemberList[i].uuid == uuid)
                {
                    return myTeamMemberList[i];
                }
            }
            return null;
        }
        
        /// <summary>
        /// 判断当前是否有队伍
        /// </summary>
        /// <returns></returns>
        public bool hasTeam()
        {
            return teamPurposeInfo != null;
        }

        /// <summary>
        /// 获得队伍人数
        /// </summary>
        /// <returns></returns>
        public int getTeamMemberNum()
        {
            if (myTeamMemberList == null)
            {
                return 0;
            }
            return myTeamMemberList.Length;
        }

        /// <summary>
        /// 获得第一个队伍成员(他人)名称
        /// 用于师徒、结婚 获得另一个人的名字
        /// </summary>
        /// <returns></returns>
        public TeamMemberInfo getTeamFirstOtherMemberInfo(long myuuid)
        {
            if (myTeamMemberList == null)
            {
                return null;
            }
            for (int i=0;i<myTeamMemberList.Length;i++)
            {
                if (!myTeamMemberList[i].uuid.Equals(myuuid))
                {
                    return myTeamMemberList[i];
                }
            }
            return null;
        }


        public void doTeamAway()
        {
            if (FubenbpjsModel.ins.IsInBpjs())
            {
                ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, "你正在进行帮派竞赛，暂离队伍会退出活动，是否确认？",
                    delegate(RMetaEvent e) { TeamCGHandler.sendCGTeamAway(); });
            }
            else
            {
                TeamCGHandler.sendCGTeamAway();
            }
        }

        public void doTeamQuit()
        {
            if (FubenbpjsModel.ins.IsInBpjs())
            {
                ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, "你正在进行帮派竞赛，退出队伍会退出活动，是否确认？",
                    delegate(RMetaEvent e) { TeamCGHandler.sendCGTeamQuit(); });
            }
            else
            {
                TeamCGHandler.sendCGTeamQuit();
            }
        }
        /// <summary>
        /// 获得队伍成员列表，剔除暂离成员
        /// </summary>
        /// <returns></returns>
        public List<TeamMemberInfo> GetTeamListExceptZanLi()
        {
            List<TeamMemberInfo> tmpList = new List<TeamMemberInfo>();
            for (int i = 0; myTeamMemberList!=null&&i < myTeamMemberList.Length; i++)
            {
                if (myTeamMemberList[i].status!=2)
                {
                    tmpList.Add(myTeamMemberList[i]);
                }
            }
            return tmpList;
        }

        public void dispatchUpdateTeamListEvent()
        {
            EventCore.dispathRMetaEventByParms(UPDATE_TEAM_LIST,null);
        }
    }
}