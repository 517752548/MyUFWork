using System.Collections.Generic;
using app.net;

namespace app.model
{
    public class QianDaoModel:AbsModel
    {
        public const string UPDATE_MEIRI_QIANDAO = "UPDATE_MEIRI_QIANDAO";
        private static QianDaoModel _ins;

        /// <summary>
        /// 31天的奖励
        /// </summary>
        private List<RewardInfoData> rewardList;
        private GCDaliyGiftPannelApply qiandaoInfo;

        public List<RewardInfoData> RewardList
        {
            get { return rewardList; }
            set { rewardList = value; }
        }
        /// <summary>
        /// 获得一天的奖励
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public RewardInfoData getDayReward(int day)
        {
            if (rewardList!=null&&day < rewardList.Count)
            {
                return rewardList[day];
            }
            return null;
        }
        
        public GCDaliyGiftPannelApply QiandaoInfo
        {
            get { return qiandaoInfo; }
            set
            {
                qiandaoInfo = value;
                dispatchChangeEvent(UPDATE_MEIRI_QIANDAO,null);
            }
        }

        public static QianDaoModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new QianDaoModel();
                }
                return _ins;
            }
            set { _ins = value; }
        }
        
        public void gotQiandaoResult(int result)
        {
            //if (result == 1) ZoneBubbleManager.ins.BubbleSysMsg("恭喜签到成功！");
        }

        public void gotBuqianResult(int result)
        {
            //if (result == 1) ZoneBubbleManager.ins.BubbleSysMsg("恭喜补签成功！");
        }

        public override void Destroy()
        {
            _ins = null;
            if (rewardList != null)
            {
                rewardList.Clear();
                rewardList = null;
            }
            qiandaoInfo = null;
        }
    }
}
