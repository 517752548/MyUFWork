//package com.imop.lj.gameserver.telnet.command;
//
//import java.text.ParseException;
//import java.util.Calendar;
//import java.util.Map;
//
//import net.sf.json.JSONObject;
//
//import org.apache.mina.common.IoSession;
//
//import com.imop.lj.core.util.TimeUtils;
//import com.imop.lj.gameserver.common.Globals;
//import com.imop.lj.gameserver.shopmall.ShopmallDef;
//
//public class OnSellCommand extends LoginedTelnetCommand {
//
//	/** 物品ID key字符串 */
//	private static final String CHAR_ID_KEY = "id";
//	/** 上架时间  key字符串 */
//	private static final String CHAR_ONSELLTIME_KEY = "sellTime";
//	/** 更新上架方式 key字符串*/
//	private static final String CHAR_TYPE_KEY = "type";
//
//	// 规则写死 on代表上架 off代表下架 now代表立即执行 gm后台发送的时候必须是这个规则,如果发送过来的
//	// 类型不属于下面的任何一个则视为无效
//	private String[] types = new String[]{"onsell","offsell","nowonsell","nowoffsell"};
//
//	public OnSellCommand() {
//		super("UPDATEMALLITEMSELL");
//	}
//
//	@Override
//	protected void doExec(String command, Map<String, String> params,
//			IoSession session) {
//		String _param = getCommandParam(command);
//		if (_param.length() == 0) {
//			sendError(session, "No param");
//			return;
//		}
//
//		JSONObject _json = JSONObject.fromObject(_param);
//		// 1.首先校验type的合法性,必须是types中的某一种
//		String _type = "";
//		if (_json.containsKey(CHAR_TYPE_KEY)) {
//			_type = _json.getString(CHAR_TYPE_KEY).trim();
//		}
//
//		boolean rightType = false;
//		for(String type : types){
//			if(type.equalsIgnoreCase(_type)){
//				rightType = true;
//				break;
//			}
//		}
//
//		if(!rightType){
//			sendError(session, "Bad type");
//			return;
//		}
//		//2.校验商品id的合法性
//		int _itemId = 0;
//		if (_json.containsKey(CHAR_ID_KEY)) {
//			String _strItemId = _json.getString(CHAR_ID_KEY).trim();
//			try{
//				_itemId = Integer.parseInt(_strItemId);
//			}
//			catch(Exception e){
//				sendError(session, "Bad charId");
//				return;
//			}
//		}
//
//		if (_itemId <= 0) {
//			sendError(session, "Bad charId");
//			return;
//		}
//		Calendar _sellTime = null;
//		//3.对于立即上架或下架物品不需要校验时间
//		if(!_type.contains("now")){
//			if (_json.containsKey(CHAR_ONSELLTIME_KEY)) {
//				String _strOnSellTime = _json.getString(CHAR_ONSELLTIME_KEY).trim();
//				try{
//					// 将字符串转化为日期
//					_sellTime = TimeUtils.getCalendarByYMDHM(_strOnSellTime);
//				}
//				catch(ParseException e){
//					sendError(session, "Bad sellTime");
//					return;
//				}
//			}
//
//			if (_sellTime == null) {
//				sendError(session, "Bad sellTime");
//				return;
//			}
//
//			long diff = _sellTime.getTimeInMillis() - Globals.getTimeService().now();
//			if(diff < 0){
//				sendError(session, "Bad sellTime");
//				return;
//			}
//		}
//
//		// 新建一个任务设置当前内存中商品的上架下架状态和数据库中物品的上架下架状态
//		UpdateShopmallItemOnSellTask task = new UpdateShopmallItemOnSellTask(_itemId,getSellByType(_type));
//		addTaskByType(_type,task,_sellTime);
//
//	}
//
//	private class UpdateShopmallItemOnSellTask implements Runnable
//	{
//		private int itemId;
//		private int onSell;
//
//		public UpdateShopmallItemOnSellTask(int itemId,int onSell){
//			this.itemId = itemId;
//			this.onSell = onSell;
//		}
//
//		@Override
//		public void run() {
//			Globals.getShopmallService().updateShopmallEntity(this.itemId, onSell);
//		}
//	}
//
//	/**
//	 * 根据传过来的上下架的类型返回上下架的值
//	 * @param type
//	 * @return
//	 */
//	private int getSellByType(String type){
//		int onsell = ShopmallDef.SELL_TRUE;
//		// type之前已经判断肯定不为空
//		if(type.contains("on")){
//			onsell = ShopmallDef.SELL_TRUE;
//		}
//		else if(type.contains("off")){
//			onsell = ShopmallDef.SELL_FALSE;
//		}
//
//		return onsell;
//	}
//
//	private void addTaskByType(String type,Runnable task,Calendar calendar){
//		// type之前已经判断肯定不为空
//		if(type.contains("now")){
//			Globals.getTimeEventService().addTask(task);
//		}
//		else{
//			Globals.getTimeEventService().addTask(calendar,task);
//		}
//	}
//
//}
