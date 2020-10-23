using app.human;
using app.team;
using app.confirm;

namespace app.net
{
	public class MarryGCHandler : IGCHandler
	{
		public const string GCFirstMarryEvent = "GCFirstMarryEvent";
		public const string GCMarryInfoEvent = "GCMarryInfoEvent";
		public const string GCFirstFireMarryEvent = "GCFirstFireMarryEvent";
	    private HunYinModel hunyinModel;
		public MarryGCHandler()
        {
            EventCore.addRMetaEventListener(GCFirstMarryEvent, GCFirstMarryHandler);
            EventCore.addRMetaEventListener(GCMarryInfoEvent, GCMarryInfoHandler);
            EventCore.addRMetaEventListener(GCFirstFireMarryEvent, GCFirstFireMarryHandler);
		    //hunyinModel = Singleton.getObj(typeof (HunYinModel)) as HunYinModel;
            hunyinModel = HunYinModel.Ins;
        }
        
        private void GCFirstMarryHandler(RMetaEvent e)
        {
        	GCFirstMarry msg = e.data as GCFirstMarry;
            int cost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.MARRY_COST);
            string othername = TeamModel.ins.getTeamFirstOtherMemberInfo(Human.Instance.Id).name;
            string tishi = "结婚需要扣除队长" + cost + "银票,"+"你是否确定要与 " +othername+ " 结婚？";
            ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, tishi, sureJieHun, cancelJieHun);
        }

        private void sureJieHun(RMetaEvent e)
        {
            int cost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.MARRY_COST);
            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD,cost,surehandler);
        }

	    private void surehandler(RMetaEvent e)
	    {
            MarryCGHandler.sendCGMarry(1);
	    }

        private void cancelJieHun(RMetaEvent e)
        {
            MarryCGHandler.sendCGMarry(0);
        }

        private void GCMarryInfoHandler(RMetaEvent e)
        {
        	GCMarryInfo msg = e.data as GCMarryInfo;
            hunyinModel.MyMarryInfo = msg;
        }
        
        private void GCFirstFireMarryHandler(RMetaEvent e)
        {
        	GCFirstFireMarry msg = e.data as GCFirstFireMarry;
            string othername = TeamModel.ins.getTeamFirstOtherMemberInfo(Human.Instance.Id).name;
            string tishi = "离婚后，夫妻关系解除，夫妻称号消失，夫妻好友度不变。你是否确定要与" + othername + "离婚？";
            ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, tishi, sureLiHun, cancelLiHun);
        }

        private void sureLiHun(RMetaEvent e)
        {
            MarryCGHandler.sendCGFireMarry(1);
        }

        private void cancelLiHun(RMetaEvent e)
        {
            MarryCGHandler.sendCGFireMarry(0);
        }
	}
}