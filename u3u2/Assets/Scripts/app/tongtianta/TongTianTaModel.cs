using app.state;
using app.zone;
using app.net;
using app.db;
using System.Collections.Generic;

namespace app.tongtianta
{
    public class TongTianTaModel : AbsModel
    {
        public const string UPDATE_TOWERINFO = "UPDATE_TOWERINFO";
        public const string UPDATE_DOUBLESTATUS = "UPDATE_DOUBLESTATUS";
        public const string GET_TOWER_REWARD = "GET_TOWER_REWARD";
        public const string START_AUTO = "START_AUTO";
        
        public static bool IsGuajiing = false;

        private int guajiMapId = -1;

        private TowerInfo mTowerInfo;
        private GCOpenDoubleStatus mDoubleStatus;
        private GCTowerReward mTowerReward;

        private static TongTianTaModel mIns;
        public static TongTianTaModel ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new TongTianTaModel();
                }
                return mIns;
            }
        }
        
        public TowerInfo towerInfo
        {
            get
            {
                return mTowerInfo;
            }
            set
            {
                mTowerInfo = value;
                dispatchChangeEvent(UPDATE_TOWERINFO, value);
            }
        }
       
        public GCOpenDoubleStatus doubleStatus
        {
            get
            {
                return mDoubleStatus;
            }
            set
            {
                mDoubleStatus = value;
                dispatchChangeEvent(UPDATE_DOUBLESTATUS,value);
            }
        }
        
        public GCTowerReward towerReward
        {
            set
            {
                mTowerReward = value;
                dispatchChangeEvent(GET_TOWER_REWARD, value);
            }
            get
            {
                return mTowerReward;
            }
        }

        public GCGuaji guajiResult
        {
            set
            {
                if (value.getResult() == 1)
                {
                    StartAuto(ZoneModel.ins.tryEnterZoneId);
                    guajiMapId = ZoneModel.ins.tryEnterZoneId;
                    dispatchChangeEvent(START_AUTO,value);
                }
                else
                {
                    AutoMaticManager.Ins.StopAutoMatic();
                }
            }
        }
        
        public void StartAuto(int mapId)
        {
            AutoMaticManager.Ins.CurAutoMaticType = AutoMaticManager.AutoMaticType.AutoGuaJi;
            LinkParse.Ins.doLink(LinkTypeDef.GuaJI+"-" + mapId.ToString());
            IsGuajiing = true;
        }

        public void DoUpdate()
        {
            if (guajiMapId == -1)
            {
                return;
            }
            ZoneCharacter player = ZoneCharacterManager.ins.self;
            if (player != null && player.displayModel != null
             && (player.curBehavType == ZoneCharacterBehavType.NONE || player.curBehavType == ZoneCharacterBehavType.IDLE)
             && StateManager.Ins.getCurState().state == StateDef.zoneState)
            {
                LinkParse.Ins.doLink(LinkTypeDef.GuaJI + "-" + guajiMapId);
            }
        }

        public TowerMapTemplate IsShowNPCBuddle(MapTemplate maptemplate)
        {
            if (maptemplate == null)
            {
               return null;  
            }
            TowerMapTemplate tpl = null;
            Dictionary<int, TowerMapTemplate> towerTpls = TowerMapTemplateDB.Instance.getIdKeyDic();
            foreach (var item in towerTpls)
            {
                if (item.Value.mapId == maptemplate.Id)
                {
                    tpl = item.Value;
                    break;
                }
            }
            return tpl;
        }

        public void StopAuto()
        {
            EffectUtil.Ins.RemoveEffect(ClientConstantDef.GUAJI_EFFECT_NAME);
            AutoMaticManager.Ins.CurAutoMaticType = AutoMaticManager.AutoMaticType.None;
            LinkParse.Ins.ClearLink();
            IsGuajiing = false;
        }

        public bool IsNpcShowBattle(int npcId)
        {
            MapNpcTemplate mapNpcTemplate = null;
            Dictionary<int, MapNpcTemplate> mapNpcTpls = MapNpcTemplateDB.Instance.getIdKeyDic();
            foreach (var item in mapNpcTpls)
            {
                if (item.Value.npcId == npcId)
                {
                    mapNpcTemplate = item.Value;
                    break;
                }
            }
            if (mapNpcTemplate == null)
            {
                return true;
            }

            TowerMapTemplate towerMapTemplate = null;
            Dictionary<int, TowerMapTemplate> towerMapTpls = TowerMapTemplateDB.Instance.getIdKeyDic();
            foreach (var item in towerMapTpls)
            {
                if (item.Value.mapId == mapNpcTemplate.mapId)
                {
                    towerMapTemplate = item.Value;
                    break;
                }
            }
            if (towerMapTemplate == null)
            {
                return true;
            }
            if (towerInfo == null)
            {
                return true;
            }
           return ((towerInfo.curTowerLevel + 1) == towerMapTemplate.towerLevelId);
        }

        public override void Destroy()
        {
            guajiMapId = -1;
            mTowerInfo = null;
            mTowerReward = null;
            mDoubleStatus = null;
            mIns = null;
        }
    }
}
