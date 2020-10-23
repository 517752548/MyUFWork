using app.activity;
using app.net;

namespace app.model
{
    /// <summary>
    /// 活动id定义
    /// </summary>
    public class ActivityIdDef
    {
        public const int JIUGUANRENWU = 1;//酒馆任务
        public const int KEJU = 2;//科举-乡试
        public const int CAIKUANG = 3;//采矿
        public const int CHUBAO = 4;//除暴安良
        public const int CANGBAOTU = 5;//藏宝图任务
        public const int LVYE = 6;//绿野仙踪
        public const int YUNLIANG = 7;//护送粮草任务
        public const int JINGJICHANG = 8;//竞技场
        public const int CHONGWUDAO = 9;//宠物岛
        public const int NVSN = 10;//N vs N联赛
        public const int BANGPAIJINGSAI = 11;//帮派竞赛
        public const int BANGPAIRENWU = 12;//帮派任务
        public const int FENGYAO_YAOMO = 13;//封妖
        public const int FENGYAO_MOWANG = 14;//封印魔王
        public const int HUNSHIMOWANG = 15;//混世魔王
        public const int XIANSHIDATI = 16;//限时答题
        public const int XIANSHISHAGUAI = 17;//限时杀怪
        public const int XIANSHINPC = 18;//限时NPC
        public const int RINGTASK = 22;//跑环
    }
    /// <summary>
    /// 活动行为id定义
    /// </summary>
    public class ActivityBehaviorIdDef
    {
        public const int JIUGUANRENWU = 7;//酒馆任务
        public const int KEJU = 8;//科举-乡试
        public const int CAIKUANG = 14;//采矿
        public const int CHUBAO = 15;//除暴安良
        public const int CANGBAOTU = 16;//藏宝图任务
        public const int LVYE = 10;//绿野仙踪
        public const int YUNLIANG = 17;//护送粮草任务
        public const int JINGJICHANG = 1;//竞技场
            //宠物岛
            //N vs N联赛
            //帮派竞赛
        public const int BANGPAIRENWU = 18;//帮派任务
    }

    public class ActivityModel:AbsModel
    {
        public const string UPDATE_ACTIVITYlIST = "UPDATE_ACTIVITYlIST";
        private GCActivityUiInfo activityInfo;
        private GCAcitvityUiRewardInfo huoyueduRewardList;

        private static ActivityModel _ins;
        public static ActivityModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    //_ins = Singleton.getObj(typeof(ActivityModel)) as ActivityModel;
                    _ins = new ActivityModel();
                }
                return _ins;
            }
        }

        public GCActivityUiInfo ActivityInfo
        {
            get { return activityInfo; }
            set
            {
                activityInfo = value;
                if (IsRequestActivityList)
                {
                    if (!WndManager.Ins.IsWndShowing(typeof (ActivityListView)))
                    {
                        WndManager.open(GlobalConstDefine.ActivityListView_Name);
                    }
                    else
                    {
                        dispatchChangeEvent(UPDATE_ACTIVITYlIST, null);
                    }
                    IsRequestActivityList = false;
                }
                else
                {
                    dispatchChangeEvent(UPDATE_ACTIVITYlIST, null);
                }
            }
        }

        public GCAcitvityUiRewardInfo HuoyueduRewardList
        {
            get { return huoyueduRewardList; }
            set
            {
                huoyueduRewardList = value;
            }
        }

        public bool IsRewardCanGet(int huoyuedu)
        {
            int len = activityInfo.getRewardGainList().Length;
            for (int i=0;i<len;i++)
            {
                if (activityInfo.getRewardGainList()[i]==huoyuedu)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsRequestActivityList
        { get; set; }

        public void requestActivityList()
        {
            IsRequestActivityList = true;
            ActivityuiCGHandler.sendCGAcitvityUiRewardInfo();
            ActivityuiCGHandler.sendCGActivityUi();
        }

        public override void Destroy()
        {
            IsRequestActivityList = false;
            activityInfo = null;
            huoyueduRewardList = null;
            _ins = null;
        }

    }


}
