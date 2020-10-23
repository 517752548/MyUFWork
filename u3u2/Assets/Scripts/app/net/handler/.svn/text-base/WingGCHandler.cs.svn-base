
using System.Linq;
using app.role;

namespace app.net
{
	public class WingGCHandler : IGCHandler
	{
		public const string GCWingPanelEvent = "GCWingPanelEvent";
		public const string GCWingUpgradeEvent = "GCWingUpgradeEvent";

        private ChiBangModel chibangModel;

		public WingGCHandler()
        {
            EventCore.addRMetaEventListener(GCWingPanelEvent, GCWingPanelHandler);
            EventCore.addRMetaEventListener(GCWingUpgradeEvent, GCWingUpgradeHandler);

            //chibangModel = Singleton.getObj(typeof(ChiBangModel)) as ChiBangModel;
            chibangModel = ChiBangModel.Ins;
        }
        
        private void GCWingPanelHandler(RMetaEvent e)
        {
        	GCWingPanel msg = e.data as GCWingPanel;
            chibangModel.WingList = msg.getWingList().ToList();
        }
        
        private void GCWingUpgradeHandler(RMetaEvent e)
        {
        	GCWingUpgrade msg = e.data as GCWingUpgrade;
            chibangModel.updateWingInfo(msg.getWing());
        }
        

	}
}