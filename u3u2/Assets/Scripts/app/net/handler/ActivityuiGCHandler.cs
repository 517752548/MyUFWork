using app.model;

namespace app.net
{
    public class ActivityuiGCHandler : IGCHandler
    {
        public const string GCActivityUiInfoEvent = "GCActivityUiInfoEvent";
        public const string GCAcitvityUiRewardInfoEvent = "GCAcitvityUiRewardInfoEvent";

        private ActivityModel mActivityModel = null;

        public ActivityuiGCHandler()
        {
            EventCore.addRMetaEventListener(GCActivityUiInfoEvent, GCActivityUiInfoHandler);
            EventCore.addRMetaEventListener(GCAcitvityUiRewardInfoEvent, GCAcitvityUiRewardInfoHandler);
        }

        private void GCActivityUiInfoHandler(RMetaEvent e)
        {
            GCActivityUiInfo msg = e.data as GCActivityUiInfo;
            if (mActivityModel == null)
            {
                // mActivityModel = Singleton.getObj(typeof(ActivityModel)) as ActivityModel;
                mActivityModel = ActivityModel.Ins;
            }
            mActivityModel.ActivityInfo = msg;
        }

        private void GCAcitvityUiRewardInfoHandler(RMetaEvent e)
        {
            GCAcitvityUiRewardInfo msg = e.data as GCAcitvityUiRewardInfo;
            if (mActivityModel == null)
            {
                // mActivityModel = Singleton.getObj(typeof(ActivityModel)) as ActivityModel;
                mActivityModel = ActivityModel.Ins;
            }
            mActivityModel.HuoyueduRewardList = msg;
        }


    }
}