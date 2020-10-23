using app.net;

namespace app.model
{
    public class OnlineRewardModel : AbsModel
    {
        public const string ONLINE_REWARD_UPDATE = "ONLINE_REWARD_UPDATE";

        /// <summary>
        /// 更新红点状态
        /// </summary>
        public const string UPDATE_REDDOT_STATE = "UPDATE_REDDOT_STATE";

        public const string UPDATE_ON_TIMER = "UPDATE_ON_TIMER";
        public const string UPDATE_END_TIMER = "UPDATE_END_TIMER";

        private RTimer mTimer;

        private GCOnlinegiftInfo mGiftInfo;

        public GCOnlinegiftInfo giftinfo
        {
            set
            {
                mGiftInfo = value;
                HandlerGiftInfo(value);
            }
            get
            {
                return mGiftInfo;
            }
        }
        private static OnlineRewardModel _ins;
        public static OnlineRewardModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new OnlineRewardModel();
                    EventCore.addRMetaEventListener(_ins.GetFinalEventType(UPDATE_END_TIMER), _ins.SendEndTimer);
                }
                return _ins;
            }
        }

        public void SendEndTimer(RMetaEvent rMetaEvent)
        {
            OnlinegiftCGHandler.sendCGGetOnlinegiftInfo();
        }

        private void HandlerGiftInfo(GCOnlinegiftInfo giftInfo)
        {
            dispatchChangeEvent(ONLINE_REWARD_UPDATE, null);
            dispatchChangeEvent(UPDATE_REDDOT_STATE, null);
            if (giftInfo.getCdTime() > 0)
            {
                if (mTimer != null)
                {
                    mTimer.stop();
                    mTimer = null;
                }
                 mTimer = TimerManager.Ins.createTimer(500, (int)giftInfo.getCdTime(), OnTimer, EndTimer);
                 mTimer.start();
            }
        }

        private void OnTimer(RTimer timer)
        {
            dispatchChangeEvent(UPDATE_ON_TIMER,timer);
        }

        private void EndTimer(RTimer timer)
        {
            dispatchChangeEvent(UPDATE_END_TIMER,timer);
        }

        public bool HaveRedDot()
        {
            if (giftinfo != null)
            {
                if (giftinfo.getCdTime() == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public override void Destroy()
        {
            EventCore.removeRMetaEventListener(_ins.GetFinalEventType(UPDATE_END_TIMER), _ins.SendEndTimer);
            _ins = null;
            if (mTimer != null)
            {
                mTimer.stop();
                mTimer = null;
            }
            mGiftInfo = null;
        }
    }
}
