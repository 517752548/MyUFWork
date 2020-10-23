using app.net;
using UnityEngine;
using app.battle;
using app.utils;


namespace app.fuben
{
    /// <summary>
    /// 帮派竞赛界面
    /// </summary>
    public class FubenbpjsWnd : FubenBaseWnd
    {
        //[Inject(ui = "FubenbpjsUI")]
        //public GameObject ui;

        private FubenbpjsUI UI;

        private static FubenbpjsWnd _ins;

        private CFubenbpjs m_bpjs;

        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.FirstWND);
        }
        */
        public static FubenbpjsWnd Ins
        {
            get
            {
                if (_ins == null)
                {
                     _ins = Singleton.GetObj(typeof(FubenbpjsWnd)) as FubenbpjsWnd;
                    //_ins = new FubenbpjsWnd();
                }
                return _ins;
            }
        }
        
        public FubenbpjsWnd()
        {
            uiName = "FubenbpjsUI";
        }

        public override void initUI()
        {
            base.initUI();
            UI = ui.AddComponent<FubenbpjsUI>();
            UI.Init();
            UI.m_btn_quit.SetClickCallBack(QuitOnClick);
            m_bFinishLoad = true;

            EventCore.addRMetaEventListener(BattleManager.Enter_Battle, UpdateBattleView);
            EventCore.addRMetaEventListener(BattleManager.Exit_Battle, UpdateBattleView);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            if (UI != null)
            {
                if (UI.m_tex_beiyong != null) UI.m_tex_beiyong.text = !string.IsNullOrEmpty(m_bpjs.m_strbpname) ? ColorUtil.getColorText(m_str_colbrown, LangConstant.BANGPAI+"：" + m_bpjs.m_strbpname) : ColorUtil.getColorText(m_str_colbrown, LangConstant.BANGPAI+"：");
                UpdateTime(m_bpjs);
                if (UI.m_tex_jifen != null) UI.m_tex_jifen.text = ColorUtil.getColorText(m_str_colgreen, LangConstant.CUR_JIFEN + m_bpjs.m_nScore);
                if (m_bpjs.state == 1)
                {
                    //准备中
                    UI.zhunbeizhongLabel.gameObject.SetActive(true);
                    UI.jinxingzhongLabel.gameObject.SetActive(false);
                }
                else if (m_bpjs.state == 2)
                {
                    //进行中
                    UI.zhunbeizhongLabel.gameObject.SetActive(false);
                    UI.jinxingzhongLabel.gameObject.SetActive(true);
                }
                else
                {
                    UI.zhunbeizhongLabel.gameObject.SetActive(false);
                    UI.jinxingzhongLabel.gameObject.SetActive(false);
                }
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            m_timer.stop();
            base.hide(e);
        }

        public FubenbpjsWnd UpdateView(CFubenbpjs _bpjs)
        {
            m_bpjs = _bpjs;
            m_timer.Reset(1000, (int)m_bpjs.m_lTotolMiliSec);
            m_timer.Restart();
            preLoadUI();
            return this;

        }

        public void QuitOnClick()
        {
            FubenbpjsModel.ins.ChaneStatue(FubenbpjsModel.EStatue.Out);
        }


        public void UpdateBattleView(RMetaEvent e)
        {
            if (BattleManager.ins.m_bIsBattle)
            {
                UI.m_btn_quit.gameObject.SetActive(false);
                UI.m_tex_jifen.gameObject.SetActive(false);
                UI.m_tex_beiyong.transform.localPosition -= new Vector3(230, 0, 0);
                UI.m_tex_time.transform.localPosition -= new Vector3(230, 0, 0);
                UI.jinxingzhongLabel.transform.localPosition -= new Vector3(230, 0, 0);
            }
            else
            {
                UI.m_btn_quit.gameObject.SetActive(true);
                UI.m_tex_jifen.gameObject.SetActive(true);
                UI.m_tex_beiyong.transform.localPosition += new Vector3(230, 0, 0);
                UI.m_tex_time.transform.localPosition += new Vector3(230, 0, 0);
                UI.jinxingzhongLabel.transform.localPosition += new Vector3(230, 0, 0);
            }
        }

        //每次进入副本时调用  
        public void EnterFuben()
        {
            if (m_timer == null)
            {
                m_timer = TimerManager.Ins.createTimer(RTimerHandler, RTimerEndHandler);
            }
        }

        #region 更新时间

        public void RTimerEndHandler(RTimer timer)
        {
            if (m_bpjs != null && m_bpjs.state == 1 && m_bFinishLoad)
            {
                CorpsCGHandler.sendCGCorpswarInfo();
            }
        }

        public void RTimerHandler(RTimer timer)
        {
            if (m_bpjs != null && m_bFinishLoad)
            {
                m_bpjs.m_lTotolMiliSec -= 1000;
                UpdateTime(m_bpjs);
            }
        }

        public void UpdateTime(CFubenbpjs _bpjs)
        {
            m_bpjs = _bpjs;
            if (UI.m_tex_time != null)
            {
                UI.m_tex_time.text = TimeString.getTimeString((int)m_bpjs.m_lTotolMiliSec / 1000);
            }
        }

        #endregion

        public override void Destroy()
        {
            EventCore.removeRMetaEventListener(BattleManager.Enter_Battle, UpdateBattleView);
            EventCore.removeRMetaEventListener(BattleManager.Exit_Battle, UpdateBattleView);
            
            if (m_timer != null)
            {
                m_timer.stop();
                m_timer = null;
            }
            _ins = null;
            base.Destroy();
            UI = null;
        }

    }


}


