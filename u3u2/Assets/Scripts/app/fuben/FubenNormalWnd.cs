
using System.Collections.Generic;
using app.mozufuben;
using app.net;
using app.zone;
using app.confirm;

namespace app.fuben
{
    public class FubenNormalWnd : FubenBaseWnd
    {
        private static FubenNormalWnd _ins;
        private GameUUButton quitButton;
        public MapType currentMapType;
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.MAINUI);
        }
        */

        public FubenNormalWnd()
        {
            uiName = "FubenNvsNUI";
        }

        public static FubenNormalWnd Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = Singleton.GetObj(typeof(FubenNormalWnd)) as FubenNormalWnd;
                }
                return _ins;
            }
        }

        public override void initUI()
        {
            base.initUI();
            GameUUButton[] l = ui.GetComponentsInChildren<GameUUButton>();
            quitButton = l[0];

            quitButton.SetClickCallBack(QuitOnClick);

            m_bFinishLoad = true;
        }

        public void showWnd(MapType maptype)
        {
            currentMapType = maptype;
            preLoadUI();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            List<string> list = new List<string>();
            list.Add(ZoneUI.USER_INFO);
            list.Add(ZoneUI.CHAT_INFO);
            list.Add(ZoneUI.QUEST_INFO);
            list.Add(ZoneUI.EXP_BAR);
            list.Add(ZoneUI.MAP_INFO);
            list.Add(ZoneUI.MAIN_BUTTONS);
            ZoneUI.ins.showPart(list);
            if (ZoneUI.ins.UI != null && ZoneUI.ins.UI.mapBtn != null)
            {
                ZoneUI.ins.UI.mapBtn.gameObject.SetActive(false);
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            currentMapType = MapType.NONE;
            if (ZoneUI.ins.UI != null && ZoneUI.ins.UI.mapBtn != null)
            {
                ZoneUI.ins.UI.mapBtn.gameObject.SetActive(true);
            }
        }


        //退出副本
        public void QuitOnClick()
        {
            switch (currentMapType)
            {
                case MapType.NVN_WAR:
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, LangConstant.SURE_LEAVE_NVN, cofirmHandler);
                    break;
                case MapType.MOZU:
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, LangConstant.SURE_LEAVE_MOZU, cofirmHandler);
                    break;
            }
        }

        private void cofirmHandler(RMetaEvent e)
        {
            switch (currentMapType)
            {
                case MapType.NVN_WAR:
                    NvnCGHandler.sendCGNvnLeave();
                    break;
                case MapType.MOZU:
                    SiegedemonCGHandler.sendCGSiegedemonLeave();
                    break;
            }
        }

        public override void Destroy()
        {
            if (m_timer != null)
            {
                m_timer.stop();
                m_timer = null;
            }
            
            _ins = null;
            
            base.Destroy();
        }
    }


}

    
