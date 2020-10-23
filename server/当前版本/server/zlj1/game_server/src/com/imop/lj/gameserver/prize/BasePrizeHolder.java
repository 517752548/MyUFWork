package com.imop.lj.gameserver.prize;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import net.sf.json.JSONObject;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.model.MoneyBonus;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;

/**
 * 奖励基类
 * 
 * 
 */
public abstract class BasePrizeHolder {
	
	/** 角色ID key字符串 */
	private static final String CHAR_ID = "id";
	/** passport ID key字符串 */
	private static final String PARAM = "params";
	/** 道具属性 A */
	private static final String ATTRA = "attrA";
	/** 道具属性 B */
	private static final String ATTRB = "attrB";
	
	/** 奖励物品列表 */
	private ItemParam[] itemList;
	
	/** 货币奖励列表 */
	private MoneyBonus[] coinList;
	
	/** 奖励物品列表 */
	private ItemParam[] itemParamsList;
	
	abstract public int getUniqueId();

	public ItemParam[] getItemList() {
		return itemList;
	}


	public MoneyBonus[] getCoinList() {
		return coinList;
	}

	public void setItemList(ItemParam[] itemList) {
		this.itemList = itemList;
	}

	public void setCoinList(MoneyBonus[] coinList) {
		this.coinList = coinList;
	}

	public ItemParam[] getItemParamsList() {
		return itemParamsList;
	}

	public void setItemParamsList(ItemParam[] itemParamsList) {
		this.itemParamsList = itemParamsList;
	}

	/**
	 * 检查奖励是否可以领取
	 * 
	 * @param player
	 * @return
	 */
	public boolean checkPlayerCanGet(Player player) {
//TODO 当前版本都可领取		
//		Human human = player.getHuman();
//		// 判断背包空间
//		if (itemList != null) {
//			if (!human.getInventory().checkSpace(Arrays.asList(itemList), true)) {
//				return false;
//			}
//		}

		// 此处没有对金钱进行判断，系统默认为任何时候都可以给

		return true;
	}

	/**
	 * 奖励玩家
	 * 
	 * @param player
	 */
	public void doPrizePlayer(Player player) {
		Human human = player.getHuman();
		// 给玩家物品
		if (itemList != null) {
			human.getInventory().addAllItems(
					Arrays.asList(itemList),
					ItemGenLogReason.PLATFORM_PRIZE, 
					MessageFormat.format(ItemGenLogReason.PLATFORM_PRIZE.getReasonText(),getUniqueId()),
					true);
		}

		// 给玩家金钱
		if (coinList != null) {
			for (MoneyBonus mb : coinList) {
				Currency currency = Currency.valueOf(mb.getType());
				human.giveMoney(mb.getMoney(), currency, true,
						MoneyLogReason.PLATFORM_PRIZE, 
						MessageFormat.format(MoneyLogReason.PLATFORM_PRIZE.getReasonText(),getUniqueId()));
			}
		}
		// 给玩家带有属性的道具
		if(this.itemParamsList != null) {
			for(ItemParam itemParam : this.itemParamsList) {
				parseAndAddHumanItemWithAttr(human, itemParam.getParams());
			}
		}
	}
	
	public Reward toReawrd(long roleId) {
		List<RewardParam> paramList = new ArrayList<RewardParam>();
		if (itemList != null) {
			for (ItemParam ip : itemList) {
				RewardParam rp = new RewardParam(RewardType.REWARD_ITEM, ip.getTemplateId(), ip.getCount());
				paramList.add(rp);
			}
		}
		
		if (coinList != null) {
			for (MoneyBonus mb : coinList) {
				RewardParam rp = new RewardParam(RewardType.REWARD_CURRENCY, mb.getType(), mb.getMoney());
				paramList.add(rp);
			}
		}
		
		if(this.itemParamsList != null) {
			//TODO FIXME 带属性的道具目前reward不支持
			
		}
		
		if (paramList.isEmpty()) {
			return null;
		}
		
		Reward reward = Globals.getRewardService().createRewardByFixedContent(roleId, RewardReasonType.USER_PRIZE_REWARD, paramList, "userPrizeHolder");
		return reward;
	}

	/**
	 * commands 0：道具id， 1：道具数量, 2强化等级， 3附魔等级， 4装备打孔数量， 5技能id 6属性A串，7属性B串：
	 * @param attrAStr 道具属性A
	 * @param attrBStr 道具属性B
	 * 
	 * @param human
	 * @param itemParams
	 */
	private void parseAndAddHumanItemWithAttr(Human human, String itemParams) {
		if (itemParams == null || itemParams.trim().length() == 0) {
			return ;
		}
		
		if (itemParams.length() == 0) {
			return ;
		}
		// 解析json串
		JSONObject _json = JSONObject.fromObject(itemParams);

		long charId = Long.parseLong(_json.getString(CHAR_ID));
		if(charId == 0) {
			return ;
		}
		final String param = _json.getString(PARAM);
		final String attrAStr = _json.getString(ATTRA);
		final String attrBStr = _json.getString(ATTRB);
		
		String[] commands = param.split(",");
		// 字符串检查如果常常小于9，非法
		if(commands.length != 6) {
			return ;
		}
		int itemId = Integer.parseInt(commands[0]);
		int count = Integer.parseInt(commands[1]);
		int[] params = new int[commands.length - 2];
		int srcPos = 2;
		// 定死：2-5 2强化等级， 3附魔等级， 4装备打孔数量， 5技能id
		for(int i = 0; i< 4; i++) {
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
		
		Globals.getItemService().addItemByParams(false, ItemGenLogReason.PLATFORM_PRIZE, "", ItemLogReason.PLATFORM_PRIZE,
				human, itemId, count, attrA, attrB, params);
	}
	
}
