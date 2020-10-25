package com.imop.lj.gameserver.human;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.gameserver.common.Globals;

/**
 * 只是角色辅助的服务类,创建角色模版,初次登录奖励
 *
 */
public class HumanAssistantService implements InitializeRequired{


//	private TemplateService tmplService;
//
//	private ItemService itemService;

	/**
	 * <<国家,性别>,奖励模板>
	 */
//	private MultiKeyMap firstSendTempMap = new MultiKeyMap();

	public HumanAssistantService() {
//		this.tmplService = templateService;
//		this.itemService = itemService;
	}


	@Override
	public void init() {
	}

	/**
	 * 查看首次登陆，并进行相应操作
	 *
	 * @param human
	 */
	public void giveFirstLoginGifts(Human human) {
		// TODO给物品
//		FirstSendTemplate firstSend = this.getItemTempByTempId(human.getAllianceId(),human.getPetManager().getCustomPet().getSex());
//		if(firstSend != null)
//		{
//			Inventory inv = human.getInventory();
//			// 赠送物品
//			inv.addAllItems(firstSend.getFirstSendItems(),
//				ItemGenLogReason.FIRST_LOGIN, null, false);
//		}
	}

	public void initHuman(Human human) {

		doInitConfig(human);

		// 设置玩家旗号为名字的前两个字符
		//
		// 等级为1级
//		human.setLevel(RoleConstants.HUMAN_INIT_LEVEL_NUM);
		// 自定义武将初始化技能和兵种
//		Secretary customPet = human.getSecretaryManager().getCountSecretary();
//		switch(human.getAllianceType()) {
//		case TONGMENG:
//			Globals.getLearningService().giveLearnedSoldier(customPet, customPet.getJobTemplate().getSoldierIdOfTM());
//			break;
//		case ZHOUXIN:
//			Globals.getLearningService().giveLearnedSoldier(customPet, customPet.getJobTemplate().getSoldierIdOfZX());
//			break;
//		case GONGCHANGUOJI:
//			Globals.getLearningService().giveLearnedSoldier(customPet, customPet.getJobTemplate().getSoldierIdOfGCGJ());
//			break;
//		}
//		if(customPet.getJobTemplate().getSkillId() > 0)
//			Globals.getLearningService().giveLearnedSkill(customPet, customPet.getJobTemplate().getSkillId());
//		// 主背包初始页数
	//	human.setBagPageSize(RoleConstants.PRIM_BAG_INIT_PAGE);
		// 设置民忠
	//	human.setLoyaltyMax(Globals.getGameConstants().getLoyaltyMax());
	//	human.setLoyalty(human.getLoyaltyMax());

		// VIP初始化,只初始化级别


		// 军团初始化
	//	human.setGuildId(GuildDef.INVALID_NUM);
	//	human.setGuildMemberState(GuildDef.GuildMemberState.NONE.getIndex());
	//	human.setGuildContribution(0);
	//	human.setGuildGoldContribToday(0);
	//	human.setLastGuildGoldContribTime(0l);

		// 初始化官职等级为无官职
	//	human.setRank(RankDef.RankLevel.RANK0.getIndex());
		// 开启默认功能
	//	human.getGameFuncManager().openingDefaultFunc();

		// 默认开启消费提醒
		//human.setConsumeConfirm(true);

		//human.getConsumeConfirmManager().setConfirmStatus(ConsumeConfirm.CONSUME_CONFIRM, true);
		//human.getConsumeConfirmManager().setConfirmStatus(ConsumeConfirm.EMPLOYEE_REFRESH_CONFIRM,true);

		//循环把所有要提示的都加到数据库里面初始化

//		for(ConsumeConfirm consumeConfirm:ConsumeConfirm.values())
//		{
//			human.getConsumeConfirmManager().setConfirmStatusByKey(consumeConfirm.getIndex(),true);
//		}

//		human.setEmpRefreshConfirm(true);

	}


	private void doInitConfig(Human human)
	{
		//给点钱
		human.setBond(0);
		human.setGold(0);
		human.setSysBond(0);
		//初始化国家,刚开始不属于任何国家
		human.setCountry(Country.NO_COUNTRY.index);
		
		//给一些阅历值
//		human.setExp(0);
//		//给一些荣誉值
//		human.setHonor(0);
		//给一些体力
		human.setPower(Globals.getGameConstants().getSysHumanPowerMax());
//		//vip等级
//		human.setVipLevel(VipLevel.VIP0.getIndex());

		// 添加新的阵型
//		human.getArrayManager().onCompanyUpgradeAddNewArray();

		// 开启第一个关卡
		// 根据阵营分配
//		int stageId = Globals.getMissionService().getStartStageId(MissionEnemyType.NORNAL);
//		human.getMissionManager().openNewMissionStage(stageId);
//		human.getMissionManager().setCurrentStageId(stageId);
		// 开启第一个精英副本
//		int eliteStageId = Globals.getMissionService().getStartStageId(MissionEnemyType.ELITE);
//		human.getMissionManager().openNewMissionStage(eliteStageId);
//		human.getMissionManager().setCurrentEliteStageId(eliteStageId);

		// 给一个训练队列
//		human.setTrainingQueueMaxSize(2);

		//初始化公司收入
//		human.getIncomeManager().load();
	}
}
