using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.net;

namespace app.mozufuben
{
    public class MoZuFubenModel:AbsModel
    {
        //更新魔族数据事件类型
        public string UPDATE_MOZU_DATA = "UPDATE_MOZU_DATA";
        //魔族副本类型-普通
        public int MoZuFuBenType_NORMAL = 12;
        //魔族副本类型-困难
        public int MoZuFuBenType_HARD = 13;

        private static MoZuFubenModel _ins;
        public static MoZuFubenModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MoZuFubenModel();
                }
                return _ins;
            }
        }
        
        private GCOpenSiegedemontaskPanel mozuData;

        public GCOpenSiegedemontaskPanel MozuData
        {
            get { return mozuData; }
            set
            {
                mozuData = value;
                //dispatchChangeEvent(UPDATE_MOZU_DATA,mozuData);
            }
        }

        public void setMozuTaskDone(int questtype)
        {
            for (int i=0;mozuData!=null&&i<mozuData.getQuestPanelInfo().Length;i++)
            {
                if (mozuData.getQuestPanelInfo()[i].questType==questtype)
                {
                    mozuData.getQuestPanelInfo()[i].finishTimes = mozuData.getQuestPanelInfo()[i].totalTimes;
                    break;
                }
            }
        }

        public override void Destroy()
        {
            _ins = null;
        }
    }


}