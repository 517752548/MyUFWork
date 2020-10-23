package com.imop.lj.gameserver.item.msg;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.player.Player;

/**
 * 删除物品消息(在场景线程中执行，避免多线程问题)
 * 
 * @author xiaowei.liu
 * 
 */
public class DelItemMessage extends SysInternalMessage {
	protected String itemId;
	protected int bagType;
	protected int bagIndex;
	protected int num;
	protected long roleUUID;
	protected String loginUserStr;
	
	public DelItemMessage(String itemId, int bagType, int bagIndex, int num,
			long roleUUID, String loginUserStr) {
		super();
		this.itemId = itemId;
		this.bagType = bagType;
		this.bagIndex = bagIndex;
		this.num = num;
		this.roleUUID = roleUUID;
		this.loginUserStr = loginUserStr;
	}



	@Override
	public void execute() {
		Player player = Globals.getOnlinePlayerService().getPlayer(this.roleUUID);
		if(player == null){
			// 离线删除
			BindUUIDIoOperation update = new DelItemOperation(itemId, bagType, bagIndex, num, roleUUID, loginUserStr);	
			Globals.getAsyncService().createOperationAndExecuteAtOnce(update);
			
		}else{
			Human human = player.getHuman();
			if(human == null){
				// 此时可能处于登陆过程中，不进行删除操作
				if(Loggers.gmcmdLogger.isWarnEnabled()){
					Loggers.gmcmdLogger.warn("#DelItemMessage#execute uuid = " + this.roleUUID + ", may be login......");
				}
				return;
			}
			
			Item item = human.getInventory().getItemByUUID(this.itemId);
			if(Item.isEmpty(item)){
				if(Loggers.gmcmdLogger.isWarnEnabled()){
					Loggers.gmcmdLogger.warn("#DelItemMessage#execute uuid = " + this.roleUUID + ", itemId = " + this.itemId + " is empty!!!");
				}
				return;
			}
			
			if(human.getInventory().dropItem(item.getBagType(), item.getIndex(), ItemLogReason.GM_DEL_ITEM, ItemLogReason.GM_DEL_ITEM.getReasonText())){
				// 删除成功
				if(Loggers.gmcmdLogger.isWarnEnabled()){
					Loggers.gmcmdLogger.warn(String.format("#DelItemMessage#execute roleUUID = %d , itemId = %s, operatorUUID = %s, bagType = %d, bagIndex = %d, num = %d", roleUUID, itemId, loginUserStr, bagType, bagIndex, num));
				}
			}else{
				// 删除失败
				if(Loggers.gmcmdLogger.isWarnEnabled()){
					Loggers.gmcmdLogger.warn("#DelItemMessage#execute uuid = " + this.roleUUID + ", itemId = " + this.itemId + ", delete fail!!!");
				}
			}
		}
	}
	
	public static class DelItemOperation implements BindUUIDIoOperation{
		protected String itemId;
		protected int bagType;
		protected int bagIndex;
		protected int num;
		protected long roleUUID;
		protected String loginUserStr;
		
		public DelItemOperation(String itemId, int bagType, int bagIndex,
				int num, long roleUUID, String loginUserStr) {
			super();
			this.itemId = itemId;
			this.bagType = bagType;
			this.bagIndex = bagIndex;
			this.num = num;
			this.roleUUID = roleUUID;
			this.loginUserStr = loginUserStr;
		}

		@Override
		public int doStop() {
			return STAGE_STOP_DONE;
		}
		
		@Override
		public int doStart() {
			return STAGE_START_DONE;
		}
		
		@Override
		public int doIo() {
			Globals.getDaoService().getItemDao().delItem(itemId, roleUUID);
			if(Loggers.gmcmdLogger.isWarnEnabled()){
				Loggers.gmcmdLogger.warn(String.format("#DelItemOperation#doIo roleUUID = %d , itemId = %s, operatorUUID = %s, bagType = %d, bagIndex = %d, num = %d", roleUUID, itemId, loginUserStr, bagType, bagIndex, num));
			}
			return STAGE_STOP_DONE;
		}
		
		@Override
		public long getBindUUID() {
			return roleUUID;
		}
		
	}
}
