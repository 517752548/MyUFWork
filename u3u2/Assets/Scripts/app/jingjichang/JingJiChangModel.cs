using System.Collections.Generic;
using app.human;
using app.net;

namespace app.jingjichang
{
    public class JingJiChangModel : AbsModel
    {
        public const string UpdateJingJiChangPanel = "updateJingJiChangPanel";
        public const string UpdateChallengeTimes = "updateChallengeTimes";
        public const string UpdateZhanBao = "updateZhanBao";
        public const string RemoveCd = "RemoveCd";

        private GCShowArenaPanelMain panelInfo;
        private int curChallengeTimes;
        private GCArenaBattleRecord zhanbaoInfo;
        private GCArenaRankRewardList rewardInfo;
        private List<ArenaMemberData> rankList;
        private GCArenaTopRankList myRankListInfo;
        private static JingJiChangModel _ins;
        public static JingJiChangModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new JingJiChangModel();
                }
                return _ins;
            }
        }
        public GCShowArenaPanelMain PanelInfo
        {
            get { return panelInfo; }
            set
            {
                panelInfo = value;
                CurChallengeTimes = panelInfo.getChallengeTimes();
                if (WndManager.Ins.IsWndShowing(GlobalConstDefine.JingJiChangView))
                {
                    dispatchChangeEvent(UpdateJingJiChangPanel, null);
                }
                else
                {
                    WndManager.open(GlobalConstDefine.JingJiChangView);
                }
            }
        }

        public int CurChallengeTimes
        {
            get { return curChallengeTimes; }
            set
            {
                curChallengeTimes = value;
                dispatchChangeEvent(UpdateChallengeTimes, null);
            }
        }

        public GCArenaBattleRecord ZhanbaoInfo
        {
            get { return zhanbaoInfo; }
            set
            {
                zhanbaoInfo = value;
                dispatchChangeEvent(UpdateZhanBao, null);
            }
        }

        public GCArenaRankRewardList RewardInfo
        {
            get { return rewardInfo; }
            set
            {
                rewardInfo = value;
                WndManager.open(GlobalConstDefine.JingJiChangRewardView);
            }
        }

        public List<ArenaMemberData> RankList
        {
            get { return rankList; }
            set
            {
                rankList = value;
                PaiHangModel.Ins.dispatchUpdateEvent();
            }
        }

        public GCArenaTopRankList MyRankListInfo
        {
            get { return myRankListInfo; }
            set { myRankListInfo = value; }
        }

        public void removeCD()
        {
            dispatchChangeEvent(RemoveCd, null);
        }
        /// <summary>
        /// 获得我在排行榜中的位置 索引
        /// </summary>
        /// <returns></returns>
        public int GetMyIndexInRankList()
        {
            for (int i = 0; RankList != null && i < RankList.Count; i++)
            {
                if (rankList[i].memberId.Equals(Human.Instance.Id))
                {
                    return i;
                }
            }
            return -1;
        }

        public override void Destroy()
        {
            panelInfo = null;
            curChallengeTimes = 0;
            zhanbaoInfo = null;
            rewardInfo = null;
            if (rankList != null)
            {
                rankList.Clear();
                rankList = null;
            }
            myRankListInfo = null;
            _ins = null;
        }
    }
}
