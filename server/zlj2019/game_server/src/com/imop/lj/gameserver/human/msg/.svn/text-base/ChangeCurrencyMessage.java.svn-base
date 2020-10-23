package com.imop.lj.gameserver.human.msg;

import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

/**
 * 修改货币消息(场景线程内调用)
 * 
 * @author xiaowei.liu
 * 
 */
public class ChangeCurrencyMessage extends SysInternalMessage {
	public static final String CURRENCY_SYS_BOND_KEY = "sysBond";
	public static final String CURRENCY_GOLD_KEY = "gold";
	public static final String CURRENCY_GIFT_BOND_KEY = "giftBond";
	public static final String CURRENCY_BLUE_HUFU_KEY = "blueHufu";
	public static final String CURRENCY_PURPLE_HUFU_KEY = "purpleHufu";
	public static final String CURRENCY_GOLDEN_HUFU_KEY = "goldenHufu";
	public static final String CURRENCY_POWER_KEY = "power";
	public static final String CURRENCY_NAME_SOUL_KEY = "soul";
	public static final String CURRENCY_HONOR_KEY = "honor";
	public static final String CURRENCY_HERO_SOUL_KEY = "heroSoul";
	public static final String CURRENCY_LUCKY_DRAW_CHIP_KEY = "luckyDrawChip";
	public static final String CURRENCY_MONSTER_WAR_CHIP_KEY = "monsterWarChip";
	public static final String CURRENCY_GEM_MAZE_ENERGY_KEY = "gemMazeEnergy";
	public static final String CURRENCY_CARD_POINT_KEY = "cardPoint";
	public static final String CURRENCY_ARMOUR_KEY = "armour";
	
	private long roleId;
	private String currencyType;
	private int value;
	
	public ChangeCurrencyMessage(long roleId, String currencyType, int value){
		this.roleId = roleId;
		this.currencyType = currencyType;
		this.value = value;
	}
	
	@Override
	public void execute() {
		if(value < 0){
			if(Loggers.gmcmdLogger.isWarnEnabled()){
				Loggers.gmcmdLogger.warn(String.format("#ChangeCurrencyMessage#execute roleId = %d, currencyType = %s , value = %d", roleId, currencyType, value));
			}
			return;
		}
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if(player == null){
			this.changeCurrencyOffline();
		}else{
			Human human = player.getHuman();
			if(human == null){
				if(Loggers.gmcmdLogger.isWarnEnabled()){
					Loggers.gmcmdLogger.warn("#ChangeCurrencyMessage#execute roleId = " + roleId + ", may be login......");
				}
				return;
			}else{
				this.changeCurrencyOnline(human);
			}
		}
	}
	
	protected void changeCurrencyOnline(Human human){
		if(CURRENCY_SYS_BOND_KEY.equals(currencyType)){
			// 绑定元宝
			human.setSysBond(value);
		}else if(CURRENCY_GOLD_KEY.equals(currencyType)){
			// 金币
			human.setGold(value);
		}else if(CURRENCY_GIFT_BOND_KEY.equals(currencyType)){
			// 礼券
			human.setGiftBond(value);
		}else if(CURRENCY_POWER_KEY.equals(currencyType)){
			// 体力
			human.setPower(value);
		}else if(CURRENCY_HONOR_KEY.equals(currencyType)){
			// 声望
			human.setHonor(value);
		}else{
			if(Loggers.gmcmdLogger.isWarnEnabled()){
				Loggers.gmcmdLogger.warn(String.format("#ChangeCurrencyMessage#execute roleId = %d, currencyType = %s , value = %d, currencyType does not exist!!!", roleId, currencyType, value));
			}
			return;
		}
		
		if(Loggers.gmcmdLogger.isWarnEnabled()){
			Loggers.gmcmdLogger.warn(String.format("#ChangeCurrencyMessage#execute roleId = %d, currencyType = %s , value = %d succ", roleId, currencyType, value));
		}
		human.snapChangedProperty(true);
	}
	
	protected void changeCurrencyOffline(){
		BindUUIDIoOperation ope = new ChangeCurrencyOperation(roleId, currencyType, value);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(ope);
	}
	
	public static class ChangeCurrencyOperation implements BindUUIDIoOperation{
		private long roleId;
		private String currencyType;
		private int value;
	
		public ChangeCurrencyOperation(long roleId, String currencyType,
				int value) {
			super();
			this.roleId = roleId;
			this.currencyType = currencyType;
			this.value = value;
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
			List<HumanEntity> entityList = Globals.getDaoService().getHumanDao().queryHumanByUUID(roleId);
			if(entityList== null || entityList.isEmpty()){
				if(Loggers.gmcmdLogger.isWarnEnabled()){
					Loggers.gmcmdLogger.warn(String.format("#ChangeCurrencyMessage#execute roleId = %d, currencyType = %s , value = %d, character does not exist!!!", roleId, currencyType, value));
				}
				return STAGE_STOP_DONE;
			}
			
			HumanEntity entity = entityList.get(0);
			if(CURRENCY_SYS_BOND_KEY.equals(currencyType)){
				// 绑定元宝
				entity.setSysBond(value);
			}else if(CURRENCY_GOLD_KEY.equals(currencyType)){
				// 金币
				entity.setGold(value);
			}else if(CURRENCY_GIFT_BOND_KEY.equals(currencyType)){
				// 礼券
				entity.setGiftBond(value);
			}
//			else if(CURRENCY_BLUE_HUFU_KEY.equals(currencyType)){
//				// 蓝色虎符
//				entity.setBlueHufu(value);
//			}else if(CURRENCY_PURPLE_HUFU_KEY.equals(currencyType)){
//				// 紫色虎符
//				entity.setPurpleHufu(value);
//			}else if(CURRENCY_GOLDEN_HUFU_KEY.equals(currencyType)){
//				// 金色虎符
//				entity.setGoldenHufu(value);
//			}
			else if(CURRENCY_POWER_KEY.equals(currencyType)){
				// 体力
				entity.setPower(value);
			}
//			else if(CURRENCY_NAME_SOUL_KEY.equals(currencyType)){
//				// 真气
//				entity.setSoul(value);
//			}
			else if(CURRENCY_HONOR_KEY.equals(currencyType)){
				// 声望
				entity.setHonor(value);
			}
//			else if(CURRENCY_HERO_SOUL_KEY.equals(currencyType)){
//				// 将魂
//				entity.setHeroSoul(value);
//			}else if(CURRENCY_LUCKY_DRAW_CHIP_KEY.equals(currencyType)){
//				// 女神宝藏
//				entity.setLuckyDrawChip(value);
//			}else if(CURRENCY_MONSTER_WAR_CHIP_KEY.equals(currencyType)){
//				// 南蛮碎片
//				entity.setMonsterWarChip(value);
//			}else if(CURRENCY_GEM_MAZE_ENERGY_KEY.equals(currencyType)){
//				// 宝石迷阵
//				// TODO
//			}else if(CURRENCY_CARD_POINT_KEY.equals(currencyType)){
//				// 卡牌点数
//				entity.setCardPoint(value);
//			}else if(CURRENCY_ARMOUR_KEY.equals(currencyType)){
//				// 战甲精华
//				// TODO
//			}
			else{
				if(Loggers.gmcmdLogger.isWarnEnabled()){
					Loggers.gmcmdLogger.warn(String.format("#ChangeCurrencyMessage#execute roleId = %d, currencyType = %s , value = %d, currencyType does not exist!!!", roleId, currencyType, value));
				}
				
				return STAGE_STOP_DONE;
			}
			
			Globals.getDaoService().getHumanDao().update(entity);
			if(Loggers.gmcmdLogger.isWarnEnabled()){
				Loggers.gmcmdLogger.warn(String.format("#ChangeCurrencyOperation#doIo roleId = %d, currencyType = %s , value = %d succ", roleId, currencyType, value));
			}
			return STAGE_STOP_DONE;
		}
		
		@Override
		public long getBindUUID() {
			return roleId;
		}
		
	}

}
