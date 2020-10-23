using System.Linq;
using app.fuben;

namespace app.net
{
    public class CorpsGCHandler : IGCHandler
    {
        public const string GCCorpsListPanelEvent = "GCCorpsListPanelEvent";
        public const string GCUpdateSingleCorpsEvent = "GCUpdateSingleCorpsEvent";
        public const string GCOpenCorpsPanelEvent = "GCOpenCorpsPanelEvent";
        public const string GCOpenCorpsMemberListEvent = "GCOpenCorpsMemberListEvent";
        public const string GCCorpsStorageEvent = "GCCorpsStorageEvent";
        public const string GCStorageItemListEvent = "GCStorageItemListEvent";
        public const string GCCorpsEventNoticeEvent = "GCCorpsEventNoticeEvent";
        public const string GCCorpsMemberInfoEvent = "GCCorpsMemberInfoEvent";
        public const string GCCorpsChangedMemberInfoEvent = "GCCorpsChangedMemberInfoEvent";
        public const string GCCorpswarInfoEvent = "GCCorpswarInfoEvent";
        public const string GCCorpswarRankListEvent = "GCCorpswarRankListEvent";
        public const string GCOpenCorpsBuildingPanelEvent = "GCOpenCorpsBuildingPanelEvent";
        public const string GCUpgradeCorpsEvent = "GCUpgradeCorpsEvent";
        public const string GCDegradeCorpsEvent = "GCDegradeCorpsEvent";
        public const string GCOpenCorpsBenifitPanelEvent = "GCOpenCorpsBenifitPanelEvent";
        public const string GCGetBenifitEvent = "GCGetBenifitEvent";
        public const string GCOpenCorpsCultivatePanelEvent = "GCOpenCorpsCultivatePanelEvent";
        public const string GCCultivateSkillEvent = "GCCultivateSkillEvent";
        public const string GCOpenCorpsAssistPanelEvent = "GCOpenCorpsAssistPanelEvent";
        public const string GCLearnAssistSkillEvent = "GCLearnAssistSkillEvent";
        public const string GCMakeItemEvent = "GCMakeItemEvent";
        public const string GCOpenCorpsRedEnvelopePanelEvent = "GCOpenCorpsRedEnvelopePanelEvent";
		public const string GCCreateCorpsRedEnvelopeEvent = "GCCreateCorpsRedEnvelopeEvent";
		public const string GCGotCorpsRedEnvelopeEvent = "GCGotCorpsRedEnvelopeEvent";
		public const string GCOpenAllocatePanelEvent = "GCOpenAllocatePanelEvent";

        private CorpModel corpModel;

        public CorpsGCHandler()
        {
            EventCore.addRMetaEventListener(GCCorpsListPanelEvent, GCCorpsListPanelHandler);
            EventCore.addRMetaEventListener(GCUpdateSingleCorpsEvent, GCUpdateSingleCorpsHandler);
            EventCore.addRMetaEventListener(GCOpenCorpsPanelEvent, GCOpenCorpsPanelHandler);
            EventCore.addRMetaEventListener(GCOpenCorpsMemberListEvent, GCOpenCorpsMemberListHandler);
            EventCore.addRMetaEventListener(GCCorpsStorageEvent, GCCorpsStorageHandler);
            EventCore.addRMetaEventListener(GCStorageItemListEvent, GCStorageItemListHandler);
            EventCore.addRMetaEventListener(GCCorpsEventNoticeEvent, GCCorpsEventNoticeHandler);
            EventCore.addRMetaEventListener(GCCorpsMemberInfoEvent, GCCorpsMemberInfoHandler);
            EventCore.addRMetaEventListener(GCCorpsChangedMemberInfoEvent, GCCorpsChangedMemberInfoHandler);
            EventCore.addRMetaEventListener(GCCorpswarInfoEvent, GCCorpswarInfoHandler);
            EventCore.addRMetaEventListener(GCCorpswarRankListEvent, GCCorpswarRankListHandler);
            EventCore.addRMetaEventListener(GCOpenCorpsBuildingPanelEvent, GCOpenCorpsBuildingPanelHandler);
            EventCore.addRMetaEventListener(GCUpgradeCorpsEvent, GCUpgradeCorpsHandler);
            EventCore.addRMetaEventListener(GCDegradeCorpsEvent, GCDegradeCorpsHandler);
            EventCore.addRMetaEventListener(GCOpenCorpsBenifitPanelEvent, GCOpenCorpsBenifitPanelHandler);
            EventCore.addRMetaEventListener(GCGetBenifitEvent, GCGetBenifitHandler);
            EventCore.addRMetaEventListener(GCOpenCorpsCultivatePanelEvent, GCOpenCorpsCultivatePanelHandler);
            EventCore.addRMetaEventListener(GCCultivateSkillEvent, GCCultivateSkillHandler);
            EventCore.addRMetaEventListener(GCOpenCorpsAssistPanelEvent, GCOpenCorpsAssistPanelHandler);
            EventCore.addRMetaEventListener(GCLearnAssistSkillEvent, GCLearnAssistSkillHandler);
            EventCore.addRMetaEventListener(GCMakeItemEvent, GCMakeItemHandler);
            EventCore.addRMetaEventListener(GCOpenCorpsRedEnvelopePanelEvent, GCOpenCorpsRedEnvelopePanelHandler);
            EventCore.addRMetaEventListener(GCCreateCorpsRedEnvelopeEvent, GCCreateCorpsRedEnvelopeHandler);
            EventCore.addRMetaEventListener(GCGotCorpsRedEnvelopeEvent, GCGotCorpsRedEnvelopeHandler);
            EventCore.addRMetaEventListener(GCOpenAllocatePanelEvent, GCOpenAllocatePanelHandler);
            //corpModel = Singleton.getObj(typeof(CorpModel)) as CorpModel;
            corpModel = CorpModel.Ins;
        }

        private void GCCorpsListPanelHandler(RMetaEvent e)
        {
            GCCorpsListPanel msg = e.data as GCCorpsListPanel;
            corpModel.CorpListPanel = msg;
        }

        private void GCUpdateSingleCorpsHandler(RMetaEvent e)
        {
            GCUpdateSingleCorps msg = e.data as GCUpdateSingleCorps;
            corpModel.UpdateOneCorpInfo(msg.getSimpleCorpsInfo());
        }

        private void GCOpenCorpsPanelHandler(RMetaEvent e)
        {
            GCOpenCorpsPanel msg = e.data as GCOpenCorpsPanel;
            corpModel.MyCorpInfo = msg;
        }

        private void GCOpenCorpsMemberListHandler(RMetaEvent e)
        {
            GCOpenCorpsMemberList msg = e.data as GCOpenCorpsMemberList;
            corpModel.MemberList = msg.getCorpsMemInfoList().ToList();
        }

        private void GCCorpsStorageHandler(RMetaEvent e)
        {
            //GCCorpsStorage msg = e.data as GCCorpsStorage;

        }

        private void GCStorageItemListHandler(RMetaEvent e)
        {
            //GCStorageItemList msg = e.data as GCStorageItemList;
        }

        private void GCCorpsEventNoticeHandler(RMetaEvent e)
        {
            GCCorpsEventNotice msg = e.data as GCCorpsEventNotice;
            if (msg.getCorpsEventType() == 1)
            {
                //�����ɹ�
                CorpsCGHandler.sendCGOpenCorpsMemberList();
                CorpsCGHandler.sendCGOpenCorpsPanel();
            }
            if (msg.getCorpsEventType() == 2)
            {
                //��ɢ�ɹ�
                WndManager.Ins.close(GlobalConstDefine.CorpsOfMineView_Name);
            }
        }

        private void GCCorpsMemberInfoHandler(RMetaEvent e)
        {
            GCCorpsMemberInfo msg = e.data as GCCorpsMemberInfo;
            corpModel.MyCorpMemberInfo = msg;
        }

        private void GCCorpsChangedMemberInfoHandler(RMetaEvent e)
        {
            GCCorpsChangedMemberInfo msg = e.data as GCCorpsChangedMemberInfo;
            corpModel.updateMemberList(msg);
        }

        private void GCCorpswarInfoHandler(RMetaEvent e)
        {
            GCCorpswarInfo msg = e.data as GCCorpswarInfo;
            FubenbpjsModel.ins.GCCorpswarInfoHandler(msg);
        }

        private void GCCorpswarRankListHandler(RMetaEvent e)
        {
            GCCorpswarRankList msg = e.data as GCCorpswarRankList;
            fuben.FubenbpjsModel.ins.GCOpenBpph(msg);
        }
        
        private void GCOpenCorpsBuildingPanelHandler(RMetaEvent e)
        {
        	GCOpenCorpsBuildingPanel msg = e.data as GCOpenCorpsBuildingPanel;
            corpModel.buildingPanel = msg;
        }
        
        private void GCUpgradeCorpsHandler(RMetaEvent e)
        {
        	GCUpgradeCorps msg = e.data as GCUpgradeCorps;
            corpModel.GCUpgradeCorps = msg;
        	
        }
        
        private void GCDegradeCorpsHandler(RMetaEvent e)
        {
        	GCDegradeCorps msg = e.data as GCDegradeCorps;
            corpModel.GCDegradeCorps = msg;
        	
        }

        private void GCGetBenifitHandler(RMetaEvent e)
        {
            GCGetBenifit msg = e.data as GCGetBenifit;
            corpModel.GCGetBenifit = msg;
        }

        private void GCOpenCorpsBenifitPanelHandler(RMetaEvent e)
        {
            GCOpenCorpsBenifitPanel msg = e.data as GCOpenCorpsBenifitPanel;
            if (msg != null)
            {
                corpModel.corpsBenifitInfo = msg.getCorpsBenifitInfo();
            }

        }

        private void GCOpenCorpsCultivatePanelHandler(RMetaEvent e)
        {
            GCOpenCorpsCultivatePanel msg = e.data as GCOpenCorpsCultivatePanel;
            bool upgradeResult = false;
            if (CorpModel.Ins.GCOpenCultivatePanel != null)
            {
                CorpsSkillInfo[] currentState = msg.getCorpsSkillInfoList();
                CorpsSkillInfo[] beforeState = CorpModel.Ins.GCOpenCultivatePanel.getCorpsSkillInfoList();
                for (int i = 0; i < currentState.Length; i++)
                {
                    for (int j = 0; j < beforeState.Length; j++)
                    {
                        if (currentState[i].skillId == beforeState[j].skillId)
                        {
                            if (currentState[i].level > beforeState[j].level)
                            {
                                upgradeResult = true;
                                break;
                            }
                        }
                    }
                }
            }
            CorpModel.Ins.upgradeResult = upgradeResult;
            CorpModel.Ins.GCOpenCultivatePanel = msg;
        }

        private void GCCultivateSkillHandler(RMetaEvent e)
        {
            GCCultivateSkill msg = e.data as GCCultivateSkill;
        }

        private void GCOpenCorpsAssistPanelHandler(RMetaEvent e)
        {
            GCOpenCorpsAssistPanel msg = e.data as GCOpenCorpsAssistPanel;
            CorpModel.Ins.GCOpenCorpsAssistPanel = msg;
        }

        private void GCLearnAssistSkillHandler(RMetaEvent e)
        {
            GCLearnAssistSkill msg = e.data as GCLearnAssistSkill;
            CorpModel.Ins.upgradeResult = msg.getResult() == 1;
        }

        private void GCMakeItemHandler(RMetaEvent e)
        {
           // GCMakeItem msg = e.data as GCMakeItem;

        }     

        private void GCOpenCorpsRedEnvelopePanelHandler(RMetaEvent e)
        {
        	GCOpenCorpsRedEnvelopePanel msg = e.data as GCOpenCorpsRedEnvelopePanel;
            CorpModel.Ins.GCOpenCorpsRedEnvelopePanel = msg;
        }
        
        private void GCCreateCorpsRedEnvelopeHandler(RMetaEvent e)
        {
        	GCCreateCorpsRedEnvelope msg = e.data as GCCreateCorpsRedEnvelope;
            CorpModel.Ins.GCCreateCorpsRedEnvelope = msg;
        }
        
        private void GCGotCorpsRedEnvelopeHandler(RMetaEvent e)
        {
        	GCGotCorpsRedEnvelope msg = e.data as GCGotCorpsRedEnvelope;
            CorpModel.Ins.GCGotCorpsRedEnvelope = msg;
        }
        
        private void GCOpenAllocatePanelHandler(RMetaEvent e)
        {
        	GCOpenAllocatePanel msg = e.data as GCOpenAllocatePanel;
            CorpModel.Ins.GCOpenAllocatePanel = msg;
        }

	}
}