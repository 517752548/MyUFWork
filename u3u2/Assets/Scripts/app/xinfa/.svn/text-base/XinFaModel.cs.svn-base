using app.net;
using app.pet;
using app.zone;
using app.state;

namespace app.xinfa
{
    public enum ResType
    {
        zero,
        FA_MU,//1伐木
        CAI_YAO,//2采药
        CAI_KUANG,//3采矿
        SHOU_LIE,//4狩猎
    }

    public class XinFaModel : AbsModel
    {
        public const string OPENXINFAJINENG_PANEL = "OPENXINFAJINENG_PANEL";
        public const string SKILL_LEARN_SUCCESS = "SKILL_LEARN_SUCCESS";
        public const string SKILL_EFFECT_UPDATE = "SKILL_EFFECT_UPDATE";
        public const string SKILL_EFFECT_UPGRADE_SUCCESS = "SKILL_EFFECT_UPGRADE_SUCCESS";
        public const string XINFA_INFO = "XINFA_INFO";
        public const string XINFA_SHENGJI = "XINFA_SHENGJI";
        public const string JINENG_INFO = "JINENG_INFO";
        public const string JINENG_SHENGJI = "JINENG_SHENGJI";
        public const string QUICK_SKILL_REFRESH = "QUICK_SKILL_REFRESH";
        public const string SHENG_HUO_JI_NENG_KAI_SHI = "SHENG_HUO_JI_NENG_KAI_SHI";
        public const string SHENG_HUO_REFRESH = "SHENG_HUO_REFRESH";

        private int m_autonpcid = -1;
        public int AutoNpcid
        {
            get
            {
                return m_autonpcid;
            }
            set
            {
                m_autonpcid = value;
            }
        }
        private static XinFaModel mXinFaModel;

        public static XinFaModel instance
        {
            get
            {
                if (mXinFaModel == null)
                {
                    mXinFaModel = new XinFaModel();
                }
                return mXinFaModel;
            }
        }

        private GCHsOpenPanel mGCHsOpenPanel;
        public GCHsOpenPanel GCHsOpenPanel
        {
            get
            {
                return mGCHsOpenPanel;
            }
            set
            {
                mGCHsOpenPanel = value;
                dispatchChangeEvent(OPENXINFAJINENG_PANEL, value);
            }
        }

        private GCHsMainSkillInfo m_xinfainfo;
        public GCHsMainSkillInfo XinFaInfo
        {
            get
            {
                return m_xinfainfo;
            }
            set
            {
                m_xinfainfo = value;
                dispatchChangeEvent(XINFA_INFO, value);
            }
        }

        private GCLifeSkillInfo m_shenghuoinfo;
        public GCLifeSkillInfo ShengHuoInfo
        {
            get
            {
                return m_shenghuoinfo;
            }
            set
            {
                m_shenghuoinfo = value;
                dispatchChangeEvent(SHENG_HUO_REFRESH, value);
            }
        }

        public override void Destroy()
        {
            mXinFaModel = null;
            mGCHsOpenPanel = null;
        }

        public void XinFaShengJi(GCHsMainSkillUpgrade msg)
        {
            dispatchChangeEvent(XINFA_SHENGJI, msg);
        }

        public void JiNengShengJi(GCHsSubSkillUpgrade msg)
        {
            dispatchChangeEvent(JINENG_SHENGJI, msg);
        }

        public void UpdateShortInfo()
        {
            dispatchChangeEvent(QUICK_SKILL_REFRESH, null);
        }

        public int GetXinFaLevel(int xinfaid)
        {
            MainSkillInfo[] mainSkillInfos = XinFaInfo.getMainSkillInfos();
            for (int i = 0; i < mainSkillInfos.Length; ++i)
            {
                if (mainSkillInfos[i].mindId == xinfaid)
                {
                    return mainSkillInfos[i].mindLevel;
                }
            }
            return 1;
        }

        /// <summary>
        /// 收到开始采集回调
        /// </summary>
        public void StartCaiJi()
        {
            dispatchChangeEvent(SHENG_HUO_JI_NENG_KAI_SHI, null);
            DoSthProgressBar.Ins.ShowInfo(LangConstant.ZHENGZAI_CAIJI, timeend, null, true, CancelCaiJi, ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.SHENGHUO_CD) / 1000, true);
        }

        public void EndCaiJi()
        {
            DoSthProgressBar.Ins.hide();
        }

        /// <summary>
        /// 进度条走到最后发送CGPING
        /// </summary>
        /// <param name="e"></param>
        public void timeend(RMetaEvent e)
        {
            CommonCGHandler.sendCGPing();
        }

        /// <summary>
        /// 发送取消采集消息
        /// </summary>
        /// <param name="e"></param>
        private void CancelCaiJi(RMetaEvent e)
        {
            LifeskillCGHandler.sendCGCancelLifeSkill();
        }

        /// <summary>
        /// 检查是否自动NPC
        /// </summary>
        public void checkAutoFindResPoint()
        {
            if (-1 != m_autonpcid)
            {
                ZoneCharacter player = ZoneCharacterManager.ins.self;
                if (player != null && player.displayModel != null
                 && (player.curBehavType == ZoneCharacterBehavType.NONE || player.curBehavType == ZoneCharacterBehavType.IDLE)
                 && StateManager.Ins.getCurState().state == StateDef.zoneState)
                {
                    LinkParse.Ins.doLink(LinkTypeDef.FindNPC + "-" + ZoneModel.ins.mapTpl.Id + "-" + m_autonpcid);
                }
            }
        }

        public void StopAutoFindResPoint()
        {
            if (AutoMaticManager.Ins.CurAutoMaticType == AutoMaticManager.AutoMaticType.AutoFindResPoint)
            {
                AutoNpcid = -1;
            }
        }
    }

}