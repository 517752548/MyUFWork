package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.ReasonDesc;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.CommonBag;
import com.imop.lj.gameserver.item.msg.ItemMessageBuilder;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.player.Player;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年3月12日 下午5:28:07
 * @version 1.0
 */

public class ItemCommand extends LoginedTelnetCommand {

	/** 角色ID key字符串 */
	private static final String CHAR_ID = "id";
	/** passport ID key字符串 */
	private static final String PARAM = "params";
	/** 道具属性 A */
	private static final String ATTRA = "attrA";
	/** 道具属性 B */
	private static final String ATTRB = "attrB";
	
	public ItemCommand() {
		super("ITEMCOMMAND");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		JSONObject _json = JSONObject.fromObject(_param);

		long _charId = Long.parseLong(_json.getString(CHAR_ID));
		final String param = _json.getString(PARAM);
		final String attrA = _json.getString(ATTRA);
		final String attrB = _json.getString(ATTRB);
		
		if(_charId == 0) {
			sendError(session, "Bad charId");
			return;
		}
		if (param == null || "".equalsIgnoreCase(param)) {
			sendError(session, "Bad param");
			return;
		}

		Player player = Globals.getOnlinePlayerService().getPlayer(_charId);
		if (player == null) {
			sendError(session, "The player found,but offline");
			return;
		}

		executeOnLinePlayer(player, param, attrA, attrB);
		

		this.sendMessage(session, "Sended");		
	}

	
	/**
	 * 在线玩家发放装备 
	 * 
	 * commands 0：道具id， 1：道具数量, 2强化等级， 3附魔等级， 4装备打孔数量， 5技能id、6武器等级， 7属性A串，8属性B串：
	 * @param attrAStr 道具属性A
	 * @param attrBStr 道具属性B
	 * 
	 */
	public static void executeOnLinePlayer(Player player, String param, String attrAStr, String attrBStr) {
		String[] commands = param.split(",");
		Human human = player.getHuman();
		// 字符串检查如果常常小于9，非法
		if(commands.length != 7) {
			return;
		}
		int itemId = Integer.parseInt(commands[0]);
		int count = Integer.parseInt(commands[1]);
		int[] params = new int[commands.length - 2];
		int srcPos = 2;
		// 定死：2-6 
		for(int i  = 0; i< 5; i++) {
			params[i] = Integer.parseInt(commands[srcPos + i]);
		}
		// 解析参数
		int[] attrA = null;
		if(attrAStr.trim() != "" && attrAStr.trim().length() > 0) {
			attrA = StringUtils.getIntArray(attrAStr, ",");
		}else {
			attrA = new int[0];
		}
		int[] attrB = null;
		if(attrBStr.trim() != "" && attrBStr.trim().length() > 0) {
			attrB = StringUtils.getIntArray(attrBStr, ",");
		} else {
			attrB = new int[0];
		}
		// 物品模板
		ItemTemplate template = Globals.getItemService().getItemTempByTempId(itemId);
		if (template == null) {
			human.sendSystemMessage("该物品不存在！");
			return;
		}
		
		ItemGenLogReason itemGenLogReason = ItemGenLogReason.GM_CREATE_REWARD;
		String detailReason = "GmCmd#ItemCmd";
		// 记录道具产生日志
		String genKey = KeyUtil.UUIDKey();
		//日志
		try {
			do {
				Globals.getLogService().sendItemGenLog(human, itemGenLogReason, detailReason, template.getId(), template.getName()
						, count, 0, "", genKey);
				// 增加物品增加原因到reasonDetail
				String countChangeReason = " [genReason:" + itemGenLogReason.getClass()
						.getField(itemGenLogReason.name()).getAnnotation(ReasonDesc.class).value() + "] ";
				detailReason = detailReason == null ? countChangeReason : detailReason + countChangeReason;
			} while (false);
		} catch (Exception e) {
			Loggers.gmcmdLogger.error(LogUtils.buildLogInfoStr(human.getUUID() + "", "GmCmd#ItemCmd#记录向包中添加一定数量物品日志时出错"), e);
		}
		
		// 主道具包
		CommonBag primBag = human.getInventory().getPrimBag();
//		CommonBag tempBag = human.getInventory().getTempBag();
		// 添加到的背包
		CommonBag addBag = null;
		
		Item emptyItem = null;
		int left = count;
		Item newItem = null;
		for(; left > 0; ) {
			emptyItem = primBag.getEmptySlot();
			
			if(null != emptyItem) {
				addBag = primBag;
			}
//			else if(null != tempBag.getEmptySlot()) {
//				emptyItem = tempBag.getEmptySlot();
//				addBag = tempBag;
//			}
			
			if(null != addBag && null != emptyItem) {
				newItem = Globals.getItemService().newActivatedInstanceForGM(human, template, addBag.getBagType(), emptyItem.getIndex(),
						true, attrA, attrB, params);
				newItem.setModified();
				primBag.putItem(newItem);
				
				if (template.getMaxOverlap() >= left) {
					// 可以全部放入
					newItem.changeOverlap(left, ItemLogReason.GM_CREATE_REWARD, detailReason, genKey, true);
					left = 0;
				} else {
					// 只能放一部分
					newItem.changeOverlap(template.getMaxOverlap(), ItemLogReason.GM_CREATE_REWARD, detailReason, genKey, true);
					left -= template.getMaxOverlap();
				}
				
				Globals.getBaseModelCache().addItemInfoCache(ItemMessageBuilder.createItemInfo(newItem));
				// 刷新物品
//				AbstractEquipmentFeature feature = (AbstractEquipmentFeature)newItem.getFeature();
//				EquipHelper.flushItemAndProp(human, feature, true);
				// 通知客户端物品变化
				GCMessage message = newItem.getUpdateMsgAndResetModify();
				human.sendMessage(message);
			}
		}
	}
}
