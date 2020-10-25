package com.imop.lj.gm.web.activity.service.Iface;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gm.web.activity.data.ActivityDataPO;
//import com.imop.lj.gm.web.activity.data.prize.ActivityGiveDoubleCommerceCatPrize;
//import com.imop.lj.gm.web.activity.data.prize.ActivityGiveDoubleCommerceMeettingPrize;
//import com.imop.lj.gm.web.activity.data.prize.ActivityGiveDoubleCommerceQuestPrize;
//import com.imop.lj.gm.web.activity.data.prize.ActivityGiveFlowersPrize;
//import com.imop.lj.gm.web.activity.data.prize.ActivityMyCarModifyPrize;
//import com.imop.lj.gm.web.activity.data.prize.ActivityPrize;
//import com.imop.lj.gm.web.activity.data.prize.ActivitySecteryDelvelopPrize;
//import com.imop.lj.gm.web.activity.data.prize.ActivityShowPrize;
//import com.imop.lj.gm.web.activity.data.prize.ActivityStarEmployPrize;
//import com.imop.lj.gm.web.activity.data.prize.ActivityWashDiamondPrize;
//import com.imop.lj.gm.web.activity.data.prize.ArenaRAnkActivityPrize;
//import com.imop.lj.gm.web.activity.data.prize.ArenaWinTimesActivityPrize;
//import com.imop.lj.gm.web.activity.data.prize.ChargeActivityPrize;
//import com.imop.lj.gm.web.activity.data.prize.CommerceArenaActivityPrize;
//import com.imop.lj.gm.web.activity.data.prize.CommerceMyHomeActivityPrize;
//import com.imop.lj.gm.web.activity.data.prize.CompanyIncomActivityPrize;
//import com.imop.lj.gm.web.activity.data.prize.CompanyLevelActivityPrize;
//import com.imop.lj.gm.web.activity.data.prize.LoginDayActivityPrize;
//import com.imop.lj.gm.web.activity.data.prize.LoginOndayActivityPrize;
import com.imop.lj.gm.web.activity.service.GMGlobals;

public enum ActivityWebTypeEnum implements IndexedEnum {
//	/**
//	 * 没有活动
//	 */
//	NULL(0){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			//GMGlobals.getInstance().getActivityService().getChargeActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 *充值活动
//	 */
//	ACTIVITY_CHARGE(1){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ChargeActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getChargeActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return true;
//		}
//	},
//	/**
//	 *每天登陆
//	 */
//	ACTIVITY_LOGIN_ONE_DAY(2){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new LoginOndayActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getLoginOnDayActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 *连续登陆
//	 */
//	ACTIVITY_LOGIN_DAY(3){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new LoginDayActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getLoginDayActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 *商会是我家
//	 */
//	ACTIVITY_COMMERCE_LEVEL(4){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new CommerceMyHomeActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getCommerceMyHomeActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 *决战竞技场！彰显商会实力！
//	 */
//	ACTIVITY_COMMERCE_ARENA(5){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new CommerceArenaActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getCommerceArenaActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 *谁是新人王？重金悬赏！
//	 */
//	ACTIVITY_ARENA_WIN_TIMES(6){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ArenaWinTimesActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getArenaWinTimesActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	
//	/**
//	 *悬赏最强CEO！谁能称雄？
//	 */
//	ACTIVITY_ARENA_RANAK(7){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ArenaRAnkActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getArenaRankActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return true;
//		}
//	},
//	
//	/**
//	 * 悬赏最富CEO！富豪大排行！
//	 */
//	ACTIVITY_COMPANY_INCOM(8){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new CompanyIncomActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getCompanyIncomeActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return true;
//		}
//	},
//	
//	/**
//	 * 谁是新人王？公司等级
//	 */
//	ACTIVITY_COMPANY_LEVEL(9){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new CompanyLevelActivityPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getCompanyLevelActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return true;
//		}
//	},
//	/**
//	 * 显示类活动发奖不再这里做
//	 */
//	ACTIVITY_SHOW(10){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivityShowPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			//GMGlobals.getInstance().getActivityService().getCompanyLevelActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return true;
//		}
//	},
//	/**
//	 * 双倍奖励,商会任务
//	 */
//	ACTIVITY_GIVE_DOUBLE_COMMERCEQUEST(11){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivityGiveDoubleCommerceQuestPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			//GMGlobals.getInstance().getActivityService().getGiveDoubleCommerceActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 * 双倍奖励,贸易大会
//	 */
//	ACTIVITY_GIVE_DOUBLE_COMMERCEMEETING(12){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivityGiveDoubleCommerceMeettingPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			//GMGlobals.getInstance().getActivityService().getGiveDoubleCommerceMeettingActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 * 双倍奖励,喂养招财猫
//	 */
//	ACTIVITY_GIVE_DOUBLE_COMMERC_CAT(13){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivityGiveDoubleCommerceCatPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			//GMGlobals.getInstance().getActivityService().getGiveDoubleCommerceCatActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 * 双倍奖励,鲜花赠送
//	 */
//	ACTIVITY_GIVE_DOUBLE_FLOWERS(14){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivityGiveFlowersPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getGiveDoubleFlowersActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 * 明星员工 公司必备！
//	 */
//	ACTIVITY_STAR_EMPLOY(15){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivityStarEmployPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getStarEmployActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return true;
//		}
//	},	
//	/**
//	 * 秘书培养 公司必备！
//	 */
//	ACTIVITY_SECTERY_DELVELOP(16){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivitySecteryDelvelopPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getSesteryDelvelopActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return true;
//		}
//	},
//	/**
//	 * 珠宝洗练  洗一送一
//	 */
//	ACTIVITY_WASH_DIAMOND(17){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivityWashDiamondPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getWashDiamondActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
//	/**
//	 * 座驾改装季 改装一送一
//	 */
//	ACTIVITY_MYCAR_MODIFY(18){
//		/*** 活动奖励初始化类*/
//		public ActivityPrize activityPrizeData(){
//			return new ActivityMyCarModifyPrize();
//		}
//		/*** 活动奖励发放*/
//		public void activityPrizeSend(ActivityDataPO activityDataPO){
//			GMGlobals.getInstance().getActivityService().getMyCarModifyActivityService().givePrizeOnCharge(activityDataPO);
//		}
//		/*** 阶段web显示*/
//		public boolean shwostage(){
//			return false;
//		}
//	},
	;
	private final int index;
	/** 按索引顺序存放的枚举数组 */
	private static final List<ActivityWebTypeEnum> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(ActivityWebTypeEnum.values());
	
//	/*** 活动奖励初始化类*/
//	public abstract ActivityPrize activityPrizeData();
//	
//	/*** 活动奖励发放*/
//	public abstract void activityPrizeSend(ActivityDataPO activityDataPO);
//	/*** 阶段web显示*/
//	public abstract boolean shwostage();

	@Override
	public int getIndex() {
		return this.index;
	}

	private ActivityWebTypeEnum(int index) {
		this.index = index;
	}

	/***
	 * 根据指定的索引获取枚举的定义
	 * 
	 * @param index
	 * @return 枚举
	 */
	public static ActivityWebTypeEnum indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}
}
