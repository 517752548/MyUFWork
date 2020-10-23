using app.net;
using app.reward;
using app.team;
using app.tips;
using app.zone;
using UnityEngine;

namespace app.nvsn
{
    public class NvsNModel : AbsModel
    {
        public const string UPDATE_MYINFO = "UPDATE_MYINFO";
        public const string UPDATE_RANKLIST = "UPDATE_RANKLIST";
        public const string UPDATE_MATCHEDTEAMINFO = "UPDATE_MATCHEDTEAMINFO";
        public const string UPDATE_STATUS = "UPDATE_STATUS";
        /// <summary>
        /// 我的信息
        /// </summary>
        private GCNvnMyInfo myInfo;
        private NvnRankInfo[] rankList;
        private GCNvnRankList myrankInfo;
        private GCNvnMatchedTeamInfo matchedTeamInfo;
        private int currentNvsNStatus;
        private GCNvnRule ruleData;
        private string ruleStr = null;
        private static NvsNModel _ins;
        public static NvsNModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new NvsNModel();
                }
                return _ins;
            }
        }
        public GCNvnMyInfo MyInfo
        {
            get { return myInfo; }
            set
            {
                myInfo = value;
                CurrentNvsNStatus = myInfo.getTeamStatus();
                if (!WndManager.Ins.IsWndShowing(GlobalConstDefine.NvsNView))
                {
                    WndManager.open(GlobalConstDefine.NvsNView);
                }
                else
                {
                    dispatchChangeEvent(UPDATE_MYINFO, null);
                }
            }
        }

        public NvnRankInfo[] RankList
        {
            get { return rankList; }
            set
            {
                rankList = value;
                dispatchChangeEvent(UPDATE_RANKLIST, null);
                PaiHangModel.Ins.dispatchUpdateEvent();
            }
        }

        public GCNvnMatchedTeamInfo MatchedTeamInfo
        {
            get { return matchedTeamInfo; }
            set
            {
                matchedTeamInfo = value;
                dispatchChangeEvent(UPDATE_MATCHEDTEAMINFO, null);
            }
        }

        public int CurrentNvsNStatus
        {
            get { return currentNvsNStatus; }
            set
            {
                currentNvsNStatus = value;
                dispatchChangeEvent(UPDATE_STATUS, null);
            }
        }

        public GCNvnRule RuleData
        {
            get { return ruleData; }
            set
            {
                ruleData = value;
            }
        }

        public GCNvnRankList MyrankInfo
        {
            get { return myrankInfo; }
            set { myrankInfo = value; }
        }

        public void EnterNvsNScene()
        {
            if (!TeamModel.ins.hasTeam())
            {
                ZoneBubbleManager.ins.BubbleSysMsg("单人状态下不可参加活动，请组队(至少2人)前来");
                return;
            }
            //if (TeamModel.ins.getTeamMemberNum() != 2)
            //{
            //    ZoneBubbleManager.ins.BubbleSysMsg("组队人数至少2人，才可参与该活动");
            //    return;
            //}
            if (ZoneModel.ins.CheckMapType(MapType.NVN_WAR, ZoneModel.ins.mapTpl.Id))
            {
                //当前在nvn地图中
                NvnCGHandler.sendCGNvnOpenPanel();
            }
            else
            {
                //当前不在nvn地图中
                NvnCGHandler.sendCGNvnEnter();
            }
        }

        public void OpenRuleWnd()
        {
            if (ruleData == null)
            {
                NvnCGHandler.sendCGNvnRule();
            }
            else
            {
                if (!string.IsNullOrEmpty(ruleStr))
                {
                    PopInfoWnd.Ins.ShowInfo(ruleStr, LangConstant.TISHI, TextAnchor.MiddleLeft, 820);
                    return;
                }
                int len = RuleData.getShowRewardList().Length;
                string rewardStr = "";
                for (int i = 0; i < len; i++)
                {
                    RewardData rewarddata = new RewardData();
                    rewarddata.ParseReward(ruleData.getShowRewardList()[i]);
                    rewardStr += RuleData.getShowRewardNameList()[i] + ":" + rewarddata.GetRewardToString();
                    if (i != len - 1)
                    {
                        rewardStr += "\n";
                    }
                }
                ruleStr = "1、N vs N联赛需要玩家" + ruleData.getLevel() + "级才可参加\n" +
                        "2、必须组队才可参加联赛，单人状态无法进入联赛场景。\n" +
                           "队伍人数最少" + ruleData.getMemberNum() + "人。\n" +
                        "3、联赛每周五晚上20:00——20:30进行\n" +
                        "4、联赛每周积分累计，每月1号凌晨发送上个月联赛排名奖励。\n" +
                        "5、联赛排名奖励说明\n" + rewardStr;
                PopInfoWnd.Ins.ShowInfo(ruleStr, LangConstant.TISHI, TextAnchor.MiddleLeft, 820);
            }
        }

        public override void Destroy()
        {
            myInfo = null;
            rankList = null;
            myrankInfo = null;
            matchedTeamInfo = null;
            currentNvsNStatus = 0;
            ruleData = null;
            ruleStr = null;
            _ins=null;
        }
    }
}
