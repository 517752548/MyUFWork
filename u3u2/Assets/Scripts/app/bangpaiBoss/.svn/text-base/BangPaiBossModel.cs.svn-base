using UnityEngine;
using System.Collections;
using app.net;
using app.tips;
using app.team;
using app.human;
using app.role;
using app.confirm;

namespace app.bangpaiBoss
{
    public class BangPaiBossModel : AbsModel
    {
        public const string UPDATE_BOSS_INFO = "UPDATE_BOSS_INFO";
        public const string UPDATE_RANK_LIST = "UPDATE_RANK_LIST";

        private static BangPaiBossModel ins;

        public static BangPaiBossModel Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new BangPaiBossModel();
                }
                return ins;
            }
        }

        private GCCorpsBossInfo mBossInfo;
        public GCCorpsBossInfo bossInfo
        {
            get
            {
                return mBossInfo;
            }
            set
            {
                mBossInfo = value;
                dispatchChangeEvent(UPDATE_BOSS_INFO, value);

            }
        }

        public GCCorpsbossAskEnterTeam askEnterTeam
        {
            set
            {
                HandlerAskEnterTeam(value.getBossLevel());
            }
        }

        private GCCorpsbossRankList mCorpsBossRankList;
        public GCCorpsbossRankList corpsBossRankList
        {
            get
            {
                return mCorpsBossRankList;
            }
            set
            {
                mCorpsBossRankList = value;
                dispatchChangeEvent(UPDATE_RANK_LIST, value);
            }
        }

        private GCCorpsbossCountRankList mCorpsBossCountRankList;
        public GCCorpsbossCountRankList corpsBossCountRankList
        {
            get
            {
                return mCorpsBossCountRankList;
            }
            set
            {
                mCorpsBossCountRankList = value;
                dispatchChangeEvent(UPDATE_RANK_LIST, null);
            }
        }




        public CorpsBossInfoData GetBossInfoDataByLevel(int level)
        {
            CorpsBossInfoData[] infoDatas = bossInfo.getCorpsBossInfoDataList();

            for (int i = 0; i < infoDatas.Length; i++)
            {
                if (infoDatas[i].bossLevel == level)
                {
                    return infoDatas[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enterLevel">从1开始的</param>
        private void HandlerAskEnterTeam(int enterLevel)
        {
            if (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id)
            {
                //本人是队长
                PopInfoWnd.Ins.ShowInfo(LangConstant.WAIT_MEMBER_AGREE);
                CorpsbossCGHandler.sendCGCorpsbossAnswerEnterTeam(1);
            }
            else
            {
                ConfirmWndParam param = new ConfirmWndParam()
                {
                    _isSingleBtn = false,
                    _secondsLeftForHide = 10,
                    cancelHandler = CancelEnter,
                    hideHandlerFlag = ConfirmWndCancleEnum.CONFIRM,
                    title = LangConstant.TISHI,
                    info = string.Format("是否同意进入帮派Boss{0}-{1}", (((enterLevel-1) / 5) + 1), ((enterLevel-1) % 5+1)),
                    confirmHandler = ConfirmEnter
                };
                ConfirmWnd.Ins.ShowConfirmByParam(param);
            }
        }

        private void ConfirmEnter(RMetaEvent e = null)
        {
            CorpsbossCGHandler.sendCGCorpsbossAnswerEnterTeam(1);
        }

        private void CancelEnter(RMetaEvent e = null)
        {
            CorpsbossCGHandler.sendCGCorpsbossAnswerEnterTeam(0);
        }

        public override void Destroy()
        {
            mBossInfo = null;
            mCorpsBossRankList = null;
            mCorpsBossCountRankList = null;
            ins = null;
        }
    }
}
