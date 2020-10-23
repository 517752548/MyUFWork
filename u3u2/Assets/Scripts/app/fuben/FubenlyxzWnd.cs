using UnityEngine;
using app.battle;
using app.utils;



namespace app.fuben
{

    public class FubenlyxzWnd : FubenBaseWnd
    {

        //[Inject(ui = "FubenlyxzUI")]
        //public GameObject ui;

        private FubenlyxzUI UI;

        private static FubenlyxzWnd _ins;

        private CFubenlyxz m_lyxz;
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.FirstWND);
        }
        */
        public static FubenlyxzWnd Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = Singleton.GetObj(typeof(FubenlyxzWnd)) as FubenlyxzWnd;
                    //_ins = new FubenlyxzWnd();
                }
                return _ins;
            }
        }
        
        public FubenlyxzWnd()
        {
            uiName = "FubenlyxzUI";
        }

        public override void initUI()
        {
            base.initUI();
            UI = ui.AddComponent<FubenlyxzUI>();
            UI.Init();
            UI.m_btn_quit.SetClickCallBack(QuitOnClick);
            m_bFinishLoad = true;

            EventCore.addRMetaEventListener(BattleManager.Enter_Battle, UpdateBattleView);
            EventCore.addRMetaEventListener(BattleManager.Exit_Battle, UpdateBattleView);

        }


        public override void show(RMetaEvent e = null)
        {
            base.show(e);
           
            if (UI != null) {
                if(UI.m_tex_boshu!=null) UI.m_tex_boshu.text = !string.IsNullOrEmpty(m_lyxz.m_tex_boshu)?ColorUtil.getColorText(m_str_colbrown, "当前正在刷新怪物:第" + m_lyxz.m_tex_boshu + "波") : ColorUtil.getColorText(m_str_colbrown, "当前正在刷新怪物:第0波");
                UpdateTime(m_lyxz);
                if (UI.m_tex_mosnum != null)
                {
                    UI.m_tex_mosnum.text = !string.IsNullOrEmpty(m_lyxz.m_tex_mosnum) ? ColorUtil.getColorText(m_str_colgreen, "当前击杀怪物数量:" + m_lyxz.m_tex_mosnum + "个") : ColorUtil.getColorText(m_str_colgreen, "当前击杀怪物数量:0个");
                }
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            m_timer.stop();
            base.hide(e);
        }

        public FubenlyxzWnd UpdateView(CFubenlyxz _lvxz)
        {
            m_lyxz = _lvxz;
            m_timer.Reset(1000,(int)m_lyxz.m_lTotolMiliSec);
            m_timer.Restart();
            preLoadUI();
            return this;

        }

        //退出绿野仙踪副本
        public void QuitOnClick() {
            FubenlyxzModel.ins.ChaneStatue(FubenlyxzModel.EStatue.Out);
        }

        public void UpdateBattleView(RMetaEvent e) {
            if (BattleManager.ins.m_bIsBattle)
            {
                UI.m_btn_quit.gameObject.SetActive(false);
                UI.m_tex_mosnum.gameObject.SetActive(false);
                UI.m_tex_boshu.transform.localPosition -= new Vector3(230,0,0);
                UI.m_tex_time.transform.localPosition -= new Vector3(230, 0, 0);
            }
            else {
                UI.m_btn_quit.gameObject.SetActive(true);
                UI.m_tex_mosnum.gameObject.SetActive(true);
                UI.m_tex_boshu.transform.localPosition += new Vector3(230, 0, 0);
                UI.m_tex_time.transform.localPosition += new Vector3(230, 0, 0);
            }
        }

        //每次进入副本时调用  
        public void EnterFuben() {
            if (m_timer == null)
            {
                m_timer = TimerManager.Ins.createTimer(RTimerHandler, null);
            }
        }
        
        #region 更新时间

        

        public void UpdateTime(CFubenlyxz _lvxz)
        {
            m_lyxz = _lvxz;
            if (UI.m_tex_time != null) UI.m_tex_time.text = TimeString.getTimeString((int)m_lyxz.m_lTotolMiliSec / 1000);
        }

        

        #endregion

        public void RTimerHandler(RTimer timer)
        {
            //ClientLog.Log("1");
            if (m_lyxz != null&& m_bFinishLoad) {
                m_lyxz.m_lTotolMiliSec -= 1000;
                UpdateTime(m_lyxz);
            }
        }
        
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


    public class CFubenlyxz {

        public string m_tex_boshu = "";
        //击杀怪物数量
        public string m_tex_mosnum = "";
        public long m_lTotolMiliSec = 0;  //总秒数

        public void SetEmpty() {
            m_tex_boshu = "";
            m_tex_mosnum = "";
            m_lTotolMiliSec = 0;
        }

    }

}

    
