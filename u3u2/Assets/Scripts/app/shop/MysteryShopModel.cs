using System.Collections;
using app.net;


namespace app.shop
{
    public class MysteryShopModel : AbsModel
    {
        public const string MYSTERY_SHOP_UPDATE = "MYSTERY_SHOP_UPDATE";
        public const string MYSTERY_SHOP_UPDATE_TIME = "MYSTERY_SHOP_UPDATE_TIME";
        public const string MYSTERY_SHOP_TIME_END = "MYSTERY_SHOP_TIME_END";

        private RTimer mTimer;

        private static MysteryShopModel mIns;

        public static MysteryShopModel Ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new MysteryShopModel();
                }
                return mIns;
            }
        }

        private GCMysteryShopInfo mMysteryShopInfo;

        public GCMysteryShopInfo mysteryShopInfo
        {
            set
            {
                mMysteryShopInfo = value;
                dispatchChangeEvent(MYSTERY_SHOP_UPDATE,value);
                HandlerTimer();
            }

            get
            {
                return mMysteryShopInfo;
            }
        }

        private void HandlerTimer()
        {
            if (mMysteryShopInfo.getCd() > 0)
            {
                if (mTimer != null)
                {
                    mTimer.stop();
                    mTimer = null;
                }

                mTimer = TimerManager.Ins.createTimer(500, int.Parse(mMysteryShopInfo.getCd().ToString()), OnTimer, TimerEnd);
                mTimer.start();

              
            }
            else
            {
                dispatchChangeEvent(MYSTERY_SHOP_TIME_END,null);
            }
        }
     

        private void OnTimer(RTimer timer)
        {
            dispatchChangeEvent(MYSTERY_SHOP_UPDATE_TIME, timer);
        }

        private void TimerEnd(RTimer timer)
        {
            MysteryshopCGHandler.sendCGReqMysteryShopInfo();
        }

        public override void Destroy()
        {
            mIns = null;
            mMysteryShopInfo = null;
            if (mTimer != null)
            {
                mTimer.stop();
                mTimer = null;
            }
        }
    }
}
