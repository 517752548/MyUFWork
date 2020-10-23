using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.net;

namespace app.xianhu
{
    public class XianHuModel : AbsModel
    {
        public const string UPDATE_RANK_LIST = "UPDATE_RANK_LIST";
        public const string REFRESH_XAINHU_INFO = "REFRESH_XAINHU_INFO";
        private Dictionary<int, GCXianhuRankList> m_xianhu_ranklist = new Dictionary<int, GCXianhuRankList>();
        public GCXianhuRankList GetXianHuRankList(int type)
        {
            if (m_xianhu_ranklist.ContainsKey(type))
            {
                return m_xianhu_ranklist[type];
            }
            return null;
        }

        public void SetXianHuRankList(int type, GCXianhuRankList ranklist)
        {
            if (m_xianhu_ranklist.ContainsKey(type))
            {
                m_xianhu_ranklist[type] = ranklist;
            }
            else
            {
                m_xianhu_ranklist.Add(type, ranklist);
            }
            dispatchChangeEvent(UPDATE_RANK_LIST, ranklist);
        }

        private GCXianhuPanel m_xianhu_panel;
        public GCXianhuPanel XianHuPanel
        {
            get
            {
                return m_xianhu_panel;
            }
            set
            {
                m_xianhu_panel = value;
                dispatchChangeEvent(REFRESH_XAINHU_INFO, value);
            }
        }

        private static XianHuModel ins;

        public static XianHuModel Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new XianHuModel();
                }
                return ins;
            }
        }

        public override void Destroy()
        {
            ins = null;
        }


    }
}
