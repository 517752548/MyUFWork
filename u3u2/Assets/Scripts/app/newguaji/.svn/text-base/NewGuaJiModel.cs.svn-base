using UnityEngine;
using System.Collections;
using app.net;
using app.zone;
using app.state;

namespace app.newguaji
{
    public class NewGuaJiModel : AbsModel
    {
        public const string REFRESH_GUAJI_INFO = "REFRESH_GUAJI_INFO";

        public static bool IsGuajiing = false;

        private int guajiMapId = -1;
        private static NewGuaJiModel ins;

        public static NewGuaJiModel Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new NewGuaJiModel();
                }
                return ins;
            }
        }

        private GCGuaJiPanel m_guajipanel;
        public GCGuaJiPanel GuajiPanel
        {
            get
            {
                return m_guajipanel;
            }
            set
            {
                m_guajipanel = value;
                dispatchChangeEvent(REFRESH_GUAJI_INFO, value);
            }
        }

        public override void Destroy()
        {
            ins = null;
        }
    }
}
