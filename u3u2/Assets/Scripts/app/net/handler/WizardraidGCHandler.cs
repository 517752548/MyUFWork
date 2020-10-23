using app.fuben;

namespace app.net
{
	public class WizardraidGCHandler : IGCHandler
	{
		public const string GCWizardraidLeftTimesEvent = "GCWizardraidLeftTimesEvent";
		public const string GCWizardraidEnterSingleEvent = "GCWizardraidEnterSingleEvent";
		public const string GCWizardraidAskEnterTeamEvent = "GCWizardraidAskEnterTeamEvent";
		public const string GCWizardraidEnterTeamEvent = "GCWizardraidEnterTeamEvent";
		public const string GCWizardraidInfoEvent = "GCWizardraidInfoEvent";

		public WizardraidGCHandler()
        {
            EventCore.addRMetaEventListener(GCWizardraidLeftTimesEvent, GCWizardraidLeftTimesHandler);
            EventCore.addRMetaEventListener(GCWizardraidEnterSingleEvent, GCWizardraidEnterSingleHandler);
            EventCore.addRMetaEventListener(GCWizardraidAskEnterTeamEvent, GCWizardraidAskEnterTeamHandler);
            EventCore.addRMetaEventListener(GCWizardraidEnterTeamEvent, GCWizardraidEnterTeamHandler);
            EventCore.addRMetaEventListener(GCWizardraidInfoEvent, GCWizardraidInfoHandler);
        }
        
        private void GCWizardraidLeftTimesHandler(RMetaEvent e)
        {
        	GCWizardraidLeftTimes msg = e.data as GCWizardraidLeftTimes;
            FubenlyxzModel.ins.GCWizardraidLeftTimesHandler(msg);
        }
        
        private void GCWizardraidEnterSingleHandler(RMetaEvent e)
        {
        	GCWizardraidEnterSingle msg = e.data as GCWizardraidEnterSingle;
            FubenlyxzModel.ins.GCWizardraidEnterSingleHandler(msg);
        }
        
        private void GCWizardraidAskEnterTeamHandler(RMetaEvent e)
        {
        	GCWizardraidAskEnterTeam msg = e.data as GCWizardraidAskEnterTeam;
            FubenlyxzModel.ins.GCWizardraidAskEnterTeamHandler(msg);
        }
        
        private void GCWizardraidEnterTeamHandler(RMetaEvent e)
        {
        	GCWizardraidEnterTeam msg = e.data as GCWizardraidEnterTeam;
            FubenlyxzModel.ins.GCWizardraidEnterTeamHandler(msg);
        }
        
        private void GCWizardraidInfoHandler(RMetaEvent e)
        {
        	GCWizardraidInfo msg = e.data as GCWizardraidInfo;
            FubenlyxzModel.ins.GCWizardraidInfoHandler(msg);
        }
        

	}
}