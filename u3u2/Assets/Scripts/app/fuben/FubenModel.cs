using app.mozufuben;
using app.net;
using app.nvsn;
using app.utils;
using app.zone;
using app.tongtianta;

/// <summary>
/// 副本基类
/// </summary>
namespace app.fuben
{
    public class FubenModel
    {
        public static bool IsInFuBen()
        {
            bool isinfuben=false;
            if (FubenlyxzModel.ins.IsInLyxz())
            {
                isinfuben = true;
                return isinfuben;
            }
            if (FubenbpjsModel.ins.IsInBpjs())
            {
                isinfuben = true;
                return isinfuben;
            }
            if (ZoneModel.ins.CheckMapType(MapType.NVN_WAR, ZoneModel.ins.mapTpl.Id))
            {
                isinfuben = true;
                return isinfuben;
            }
            if (ZoneModel.ins.CheckMapType(MapType.MOZU, ZoneModel.ins.mapTpl.Id))
            {
                isinfuben = true;
                return isinfuben;
            }
            return isinfuben;
        }
    }

    public class FubenBaseWnd : BaseUI
    {

        public bool m_bFinishLoad = false;

        protected string m_str_colbrown = "#f0e1ce";
        protected string m_str_colgreen = "#67da61";
        protected RTimer m_timer;

    }

    public class FubenManager {

        static FubenManager fubenmgr = new FubenManager();

        private FubenManager() {

        }

        public static FubenManager Instance
        {
            get
            {
                return fubenmgr;
            }
        }

        public void FubenEnter() {
            if (!ZoneModel.ins.CheckMapType(MapType.WIZARD_RAID, ZoneModel.ins.mapTpl.Id))
            {
                FubenlyxzModel.ins.ExitMap();
            }
            else
            {
                FubenlyxzModel.ins.Enter();
            }
            if (!ZoneModel.ins.CheckMapType(MapType.CORPS_WAR, ZoneModel.ins.mapTpl.Id))
            {
                FubenbpjsModel.ins.ExitMap();
            }
            else
            {
                FubenbpjsModel.ins.Enter();
            }

            if (ZoneModel.ins.CheckMapType(MapType.NVN_WAR, ZoneModel.ins.mapTpl.Id))
            {
                NvnCGHandler.sendCGNvnOpenPanel();

                FubenNormalWnd.Ins.showWnd(MapType.NVN_WAR);
            }
            else
            {
                FubenNormalWnd.Ins.hide();
                if (WndManager.Ins.IsWndShowing(GlobalConstDefine.NvsNView))
                {
                    WndManager.Ins.close(GlobalConstDefine.NvsNView);
                }
            }

            if (ZoneModel.ins.CheckMapType(MapType.MOZU, ZoneModel.ins.mapTpl.Id))
            {
                FubenNormalWnd.Ins.showWnd(MapType.MOZU);
            }
            else
            {
                FubenNormalWnd.Ins.hide();
            }

            //if (ZoneModel.ins.CheckMapType(MapType.TOWER, ZoneModel.ins.mapTpl.Id))
            //{
            //    GuaJiView.ins.preLoadUI();
            //}
            //else
            //{
            //    GuaJiView.ins.hide();
            //}

            
        }

    }

}
    
