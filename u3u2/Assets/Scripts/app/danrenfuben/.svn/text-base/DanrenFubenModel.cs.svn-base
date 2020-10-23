using app.net;

namespace app.danrenfuben
{
    public class DanrenFubenModel : AbsModel
    {
        public const string GET_DUNGEONINFO = "GET_DUNGEONINFO";
        public const string GET_REWARDINFO = "GET_REWARDINFO";
        private GCPlotDungeonInfo normalInfo;
        private GCPlotDungeonInfo harderInfo;
        private GCDailyPlotDungeonInfo mGCDailyPlotDungeonInfo;
        private static DanrenFubenModel mIns;

        public static DanrenFubenModel Instance
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new DanrenFubenModel();
                }
                return mIns;
            }
        }

        public GCPlotDungeonInfo GCPlotDungeonInfo
        {
            set
            {
                if (value.getPlotDungeonType() == 0)
                {
                    normalInfo = value;
                }
                else
                {
                    harderInfo = value;
                }
                dispatchChangeEvent(GET_DUNGEONINFO,null);
            }

        }

        public GCPlotDungeonInfo GetDungeonInfoByType(DungeonType type)
        {
            if (type == DungeonType.HARDER)
            {
                return harderInfo;
            }
            else
            {
                return normalInfo;
            }
        }
        
        public GCDailyPlotDungeonInfo GCDailyPlotDungeonInfo
        {
            set
            {
                mGCDailyPlotDungeonInfo = value;
                dispatchChangeEvent(GET_REWARDINFO,null);
            }
            get
            {
                return mGCDailyPlotDungeonInfo;
            }
        }

        public override void Destroy()
        {
            mGCDailyPlotDungeonInfo = null;
            normalInfo = null;
            harderInfo = null;
            mIns = null;

        }
    }
}
