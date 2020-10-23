using System.Collections.Generic;
using app.net;
using app.team;
using app.zone;

namespace app.fuben
{
    public class FubenbpjsModel 
    {
        private static FubenbpjsModel mIns;
        private CFubenbpjs m_bpjs = new CFubenbpjs();
        public EStatue m_eStatue = EStatue.Out;
        private int m_nTimes;  //副本次数

        public static FubenbpjsModel ins
        {
            get
            {
                if (mIns==null)
                {
                    //mIns = Singleton.getObj(typeof (FubenbpjsModel)) as FubenbpjsModel;
                    mIns = new FubenbpjsModel();
                }
                return mIns;
            }
        }

        public CorpsWarRankInfo[] Rankinfo
        {
            get
            {
                return m_rankinfo;
            }
            set
            {
                m_rankinfo = value;
            }
        }

        public enum EStatue
        {
            PerIn, //可以进入副本 但还未进入 需等界面加载完成
            In, // 在副本里面
            Out,  //在副本外面
            UpdateOutView,  //退出时只更新到退出后的界面 不发离开地图的消息
            UpdateView, //更新界面
        }

        /// <summary>
        /// 进入帮派竞赛副本
        /// </summary>
        public void EnterBpjs() {
            if (TeamModel.ins.hasTeam())
            {
                CorpsCGHandler.sendCGEnterCorpswar();
            }
            else {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.BANGPAIJINGSAI_NEED_TEAM);
            }
        }

        /// <summary>
        /// 帮派竞赛消息 返回
        /// </summary>
        public void GCCorpswarInfoHandler(GCCorpswarInfo msg)
        {
            m_bpjs.SetEmpty();
            m_bpjs.m_nScore = msg.getCorpsScore();
            m_bpjs.m_strbpname = msg.getCorpsName();
            m_bpjs.m_lTotolMiliSec = msg.getLeftTime();
            if (m_bpjs.m_lTotolMiliSec==0)
            {
                m_bpjs.m_lTotolMiliSec = 3000;
            }
            else
            {
                m_bpjs.m_lTotolMiliSec += 1000;
            }
            m_bpjs.state = msg.getState();

            if (m_eStatue == EStatue.Out)
            {
                //刚进入副本
                m_eStatue = EStatue.PerIn;
                FubenbpjsWnd.Ins.EnterFuben();
            }
            ChaneStatue(EStatue.UpdateView);
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        public void ChaneStatue(EStatue statue)
        {
            switch (statue)
            {
                case EStatue.In:
                    //进入副本时
                    List<string> list = new List<string>();
                    list.Add(ZoneUI.USER_INFO);
                    list.Add(ZoneUI.CHAT_INFO);
                    list.Add(ZoneUI.QUEST_INFO);
                    list.Add(ZoneUI.EXP_BAR);
                    list.Add(ZoneUI.MAIN_BUTTONS);
                    ZoneUI.ins.showPart(list);
                    FubenbpjsWnd.Ins.UpdateView(m_bpjs);
                    m_eStatue = statue;
                    break;
                case EStatue.Out:
                    //退出副本时
                    CorpsCGHandler.sendCGLeaveCorpswar();
                    break;
                case EStatue.UpdateOutView:
                    //退出副本时
                    FubenbpjsWnd.Ins.hide();
                    m_eStatue = EStatue.Out;
                    break;
                case EStatue.UpdateView:
                    if (m_eStatue == EStatue.In)
                    {
                        //如果已经在副本里了 才更新界面
                        FubenbpjsWnd.Ins.UpdateView(m_bpjs);
                    }
                    break;
            } 

        }

        public void Enter()
        {
            if (m_eStatue == EStatue.PerIn || m_eStatue == EStatue.In)
            {
                ChaneStatue(EStatue.In);
            }
        }

        public void ExitMap()
        {
            if (m_eStatue != EStatue.Out)
            {

                FubenbpjsWnd.Ins.hide();
                m_eStatue = EStatue.Out;
            }

        }

        #region 帮派排名

        CorpsWarRankInfo[] m_rankinfo;
        private FubenbpphView m_view_fbbpph;

        //打开帮派排行面板
        public void OpenBpph() {
            CorpsCGHandler.sendCGCorpswarRankList();
        }

        //打开帮派面板的消息返回
        public void GCOpenBpph(GCCorpswarRankList msg) {
            Rankinfo = msg.getCwRankInfoList();
            WndManager.open(GlobalConstDefine.Fuben_bpph);
        }

        #endregion

        /// <summary>
        /// 是否在副本里 true在里面 false不在里面
        /// </summary>
        public bool IsInBpjs()
        {
            if (m_eStatue == EStatue.In)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Destroy()
        {
            m_bpjs.SetEmpty();
            m_eStatue = EStatue.Out;
            m_nTimes = 0;
            mIns = null;
        }
    }

    public class CFubenbpjs
    {
        public int m_nScore = 0;
        public long m_lTotolMiliSec = 0;  //总毫秒数
        public string m_strbpname ="";
        /** 活动当前状态，1准备中，2已开始 */
        public int state;

        public void SetEmpty()
        {
            m_nScore = 0;
            m_lTotolMiliSec = 0;
            m_strbpname = "";
            state = 0;
        }

    }

}

    
