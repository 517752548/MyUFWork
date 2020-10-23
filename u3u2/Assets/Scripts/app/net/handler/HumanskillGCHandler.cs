using app.xinfa;

namespace app.net
{
    public class HumanskillGCHandler : IGCHandler
    {
        public const string GCHsMainSkillInfoEvent = "GCHsMainSkillInfoEvent";
        public const string GCHsMainSkillUpgradeEvent = "GCHsMainSkillUpgradeEvent";
        public const string GCHsSubSkillUpgradeEvent = "GCHsSubSkillUpgradeEvent";
        public const string GCHsOpenPanelEvent = "GCHsOpenPanelEvent";

        public HumanskillGCHandler()
        {
            EventCore.addRMetaEventListener(GCHsMainSkillInfoEvent, GCHsMainSkillInfoHandler);
            EventCore.addRMetaEventListener(GCHsMainSkillUpgradeEvent, GCHsMainSkillUpgradeHandler);
            EventCore.addRMetaEventListener(GCHsSubSkillUpgradeEvent, GCHsSubSkillUpgradeHandler);
            EventCore.addRMetaEventListener(GCHsOpenPanelEvent, GCHsOpenPanelHandler);
        }
        
        private void GCHsMainSkillInfoHandler(RMetaEvent e)
        {
            GCHsMainSkillInfo msg = e.data as GCHsMainSkillInfo;
            XinFaModel.instance.XinFaInfo = msg;
        }
        
        private void GCHsMainSkillUpgradeHandler(RMetaEvent e)
        {
            GCHsMainSkillUpgrade msg = e.data as GCHsMainSkillUpgrade;
            XinFaModel.instance.XinFaShengJi(msg);
        }
        
        private void GCHsSubSkillUpgradeHandler(RMetaEvent e)
        {
            GCHsSubSkillUpgrade msg = e.data as GCHsSubSkillUpgrade;
            XinFaModel.instance.JiNengShengJi(msg);
        }
        
        
        private void GCHsOpenPanelHandler(RMetaEvent e)
        {
            GCHsOpenPanel msg = e.data as GCHsOpenPanel;
            XinFaModel.instance.GCHsOpenPanel = msg;
        }
        

    }
}