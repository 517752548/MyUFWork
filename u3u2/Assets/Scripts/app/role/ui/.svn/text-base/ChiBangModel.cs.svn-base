using System.Collections.Generic;
using app.db;
using app.net;
using app.zone;

namespace app.role
{
    public class ChiBangModel : AbsModel
    {
        public const string UPDATE_WINGLIST = "UPDATE_WINGLIST";
        public const string UPDATE_CURWING = "UPDATE_CURWING";

        private List<WingInfo> _wingList;

        public List<WingInfo> WingList
        {
            get { return _wingList; }
            set
            {
                _wingList = value;
                dispatchChangeEvent(UPDATE_WINGLIST, null);
                dispatchChangeEvent(UPDATE_CURWING, null);
                updateMyWingWear();
            }
        }
        private static ChiBangModel _ins;
        public static ChiBangModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    //_ins = Singleton.getObj(typeof(ChiBangModel)) as ChiBangModel;
                    _ins = new ChiBangModel();
                }
                return _ins;
            }
        }
        public void updateWingInfo(WingInfo winginfo)
        {
            for (int i = 0; WingList != null && i < WingList.Count; i++)
            {
                if (WingList[i].templateId == winginfo.templateId)
                {
                    WingList[i] = winginfo;
                    dispatchChangeEvent(UPDATE_WINGLIST, null);
                    dispatchChangeEvent(UPDATE_CURWING, null);
                    updateMyWingWear();
                    break;
                }
            }
        }

        public void updateMyWingWear()
        {
            WingTemplate tpl = null;
            for (int i = 0; WingList != null && i < WingList.Count; i++)
            {
                if (WingList[i].isEquip == 1)
                {
                    tpl = WingTemplateDB.Instance.getTemplate(WingList[i].templateId);
                    break;
                }
            }
            
            if (ZoneCharacterManager.ins.self != null)
            {
                if (tpl == null)
                {
                    ZoneCharacterManager.ins.self.HideWing(true);
                }
                else
                {
                    ZoneCharacterManager.ins.self.ShowWing(tpl);
                }
            }
        }

        /// <summary>
        /// 获得当前正在穿的翅膀的信息
        /// </summary>
        /// <returns></returns>
        public WingInfo GetCurWearWingInfo()
        {
            for (int i = 0; WingList != null && i < WingList.Count; i++)
            {
                if (WingList[i].isEquip == 1)
                {
                    return WingList[i];
                }
            }
            return null;
        }
        
        public override void Destroy()
        {
            if (_wingList != null)
            {
                _wingList.Clear();
                _wingList = null;
            }
        }

    }
}
