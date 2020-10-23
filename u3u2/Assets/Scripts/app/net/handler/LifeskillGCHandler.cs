using app.xinfa;
using app.zone;

namespace app.net
{
	public class LifeskillGCHandler : IGCHandler
	{
		public const string GCUseLifeSkillEvent = "GCUseLifeSkillEvent";
		public const string GCLifeSkillUpgradeEvent = "GCLifeSkillUpgradeEvent";
		public const string GCLifeSkillInfoEvent = "GCLifeSkillInfoEvent";

		public LifeskillGCHandler()
        {
            EventCore.addRMetaEventListener(GCUseLifeSkillEvent, GCUseLifeSkillHandler);
            EventCore.addRMetaEventListener(GCLifeSkillUpgradeEvent, GCLifeSkillUpgradeHandler);
            EventCore.addRMetaEventListener(GCLifeSkillInfoEvent, GCLifeSkillInfoHandler);
        }
        
        private void GCUseLifeSkillHandler(RMetaEvent e)
        {
        	GCUseLifeSkill msg = e.data as GCUseLifeSkill;
            if (null != ZoneCharacterManager.ins && null != ZoneCharacterManager.ins.self && HeadFlag.ZHAN_DOU != ZoneCharacterManager.ins.self.isInBattle)
            {
                ZoneCharacterManager.ins.self.isInBattle = (HeadFlag)msg.getResult();
            }
            if (msg.getResult() > 0)
            {

                XinFaModel.instance.StartCaiJi();
            }
            else
            {
                XinFaModel.instance.EndCaiJi();
            }
        }
        
        private void GCLifeSkillUpgradeHandler(RMetaEvent e)
        {
        	GCLifeSkillUpgrade msg = e.data as GCLifeSkillUpgrade;
        	
        }
        
        private void GCLifeSkillInfoHandler(RMetaEvent e)
        {
        	GCLifeSkillInfo msg = e.data as GCLifeSkillInfo;
            XinFaModel.instance.ShengHuoInfo = msg;
        }
        

	}
}