using UnityEngine;
using System.Collections;
using app.net;

namespace app.yueka
{
    public class YueKaModel : AbsModel
    {
        public const string UPDATE_YUEKA_INFO = "UPDATE_YUEKA_INFO";

        private GCMonthCardInfo m_MonthCardInfo;
        private static YueKaModel ins;

        public static YueKaModel Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new YueKaModel();
                }
                return ins;
            }
        }

        public override void Destroy()
        {
            ins = null;
        }

        public GCMonthCardInfo MonthCardInfo
        {
            get
            {
                return m_MonthCardInfo;
            }
            set
            {
                m_MonthCardInfo = value;
                dispatchChangeEvent(UPDATE_YUEKA_INFO, value);
            }
        }
        
    }
}
