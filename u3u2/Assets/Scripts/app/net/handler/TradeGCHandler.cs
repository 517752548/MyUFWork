using app.confirm;

namespace app.net
{
	public class TradeGCHandler : IGCHandler
	{
		public const string GCTradeBoothinfoEvent = "GCTradeBoothinfoEvent";
		public const string GCTradeCommodityListEvent = "GCTradeCommodityListEvent";
        public const string GCTradeSellResultEvent = "GCTradeSellResultEvent";

		public TradeGCHandler()
        {
            EventCore.addRMetaEventListener(GCTradeBoothinfoEvent, GCTradeBoothinfoHandler);
            EventCore.addRMetaEventListener(GCTradeCommodityListEvent, GCTradeCommodityListHandler);
            EventCore.addRMetaEventListener(GCTradeSellResultEvent, GCTradeSellResultHandler);
        }
        
        private void GCTradeBoothinfoHandler(RMetaEvent e)
        {
        	GCTradeBoothinfo msg = e.data as GCTradeBoothinfo;
        	EventCore.dispathRMetaEventByParms(PaiMaiHangSellScript.TANWEI_LIST,msg);
        }
        
        private void GCTradeCommodityListHandler(RMetaEvent e)
        {
        	GCTradeCommodityList msg = e.data as GCTradeCommodityList;
        	EventCore.dispathRMetaEventByParms(PaiMaiHangBuyScript.SHANGPIN_LIST,msg);
        }

        private void GCTradeSellResultHandler(RMetaEvent e)
        {
            GCTradeSellResult msg = e.data as GCTradeSellResult;
            if (msg.getResult() == 1) {
                ConfirmWnd.Ins.ShowJinribuzaitishiShangjia("上架成功", "税率统为10%", null);
            }
        }

	}
}