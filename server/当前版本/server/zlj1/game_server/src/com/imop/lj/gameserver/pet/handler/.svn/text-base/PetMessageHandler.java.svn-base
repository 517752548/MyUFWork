
package com.imop.lj.gameserver.pet.handler;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.pet.PetDef.PetTrainType;
import com.imop.lj.gameserver.pet.msg.CGPetAddPoint;
import com.imop.lj.gameserver.pet.msg.CGPetArtifice;
import com.imop.lj.gameserver.pet.msg.CGPetChangeFightState;
import com.imop.lj.gameserver.pet.msg.CGPetChangeName;
import com.imop.lj.gameserver.pet.msg.CGPetEmbedSkillEffect;
import com.imop.lj.gameserver.pet.msg.CGPetFire;
import com.imop.lj.gameserver.pet.msg.CGPetFriendChangeArray;
import com.imop.lj.gameserver.pet.msg.CGPetFriendChangePosition;
import com.imop.lj.gameserver.pet.msg.CGPetFriendInfo;
import com.imop.lj.gameserver.pet.msg.CGPetFriendOffArray;
import com.imop.lj.gameserver.pet.msg.CGPetFriendPutonArray;
import com.imop.lj.gameserver.pet.msg.CGPetFriendUnlock;
import com.imop.lj.gameserver.pet.msg.CGPetHorseArtifice;
import com.imop.lj.gameserver.pet.msg.CGPetHorseChangeName;
import com.imop.lj.gameserver.pet.msg.CGPetHorseFire;
import com.imop.lj.gameserver.pet.msg.CGPetHorsePerceptAddExp;
import com.imop.lj.gameserver.pet.msg.CGPetHorseRejuven;
import com.imop.lj.gameserver.pet.msg.CGPetHorseRide;
import com.imop.lj.gameserver.pet.msg.CGPetHorseTrain;
import com.imop.lj.gameserver.pet.msg.CGPetHorseTrainUpdate;
import com.imop.lj.gameserver.pet.msg.CGPetLeaderStudySkill;
import com.imop.lj.gameserver.pet.msg.CGPetOpenFriendPanel;
import com.imop.lj.gameserver.pet.msg.CGPetPerceptAddExp;
import com.imop.lj.gameserver.pet.msg.CGPetRefreshTalentSkill;
import com.imop.lj.gameserver.pet.msg.CGPetRejuven;
import com.imop.lj.gameserver.pet.msg.CGPetResetPoint;
import com.imop.lj.gameserver.pet.msg.CGPetSkillEffectOpenPosition;
import com.imop.lj.gameserver.pet.msg.CGPetSkillEffectUplevel;
import com.imop.lj.gameserver.pet.msg.CGPetStudyNormalSkill;
import com.imop.lj.gameserver.pet.msg.CGPetTrain;
import com.imop.lj.gameserver.pet.msg.CGPetTrainUpdate;
import com.imop.lj.gameserver.pet.msg.CGPetUnembedSkillEffect;
import com.imop.lj.gameserver.pet.msg.CGPetVariation;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class PetMessageHandler {	
	
	public PetMessageHandler() {	
	}	
		
	
	protected boolean checkRoleAndFuncForPercept(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.PERCEPT)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.PERCEPT);
			return false;
		}
		return true;
	}
	
	/**
	 * 武将加点
	 * @param player
	 * @param cgPetAddPoint
	 */
	public void handlePetAddPoint(Player player, CGPetAddPoint cgPetAddPoint) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetAddPoint.getPetId() <= 0) {
			return;
		}
		
		if (cgPetAddPoint.getAddArr().length != PetAProperty._END/2) {
			return;
		}
		
		//XXX 修改被刷的bug，数组中两个数是int最大值，另一个数是3，即可刷
		int[] arr = cgPetAddPoint.getAddArr();
		int maxPoint = Globals.getGameConstants().getLevelMax() * Globals.getGameConstants().getLeaderLevelUpAddPoint();
		for (int i = 0; i < arr.length; i++) {
			if (arr[i] < 0 || arr[i] > maxPoint) {
				return;
			}
		}
		
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetService().petAddPoint(player.getHuman(), cgPetAddPoint.getPetId(), cgPetAddPoint.getAddArr());
	}
	
	/**
 	* 宠物出战or休息
 	* 
 	* CodeGenerator
 	*/
	public void handlePetChangeFightState(Player player, CGPetChangeFightState cgPetChangeFightState) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetChangeFightState.getPetId() <= 0 || cgPetChangeFightState.getState() < 0) {
			return;
		}
		
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetService().changeFightState(player.getHuman(), cgPetChangeFightState.getPetId(), cgPetChangeFightState.getState());
	}
		/**
 	* 武将改名
 	* 
 	* CodeGenerator
 	*/
	public void handlePetChangeName(Player player, CGPetChangeName cgPetChangeName) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetChangeName.getPetId() <= 0 || cgPetChangeName.getNewName().isEmpty()) {
			return;
		}
		
		Globals.getPetService().changeName(player.getHuman(), cgPetChangeName.getPetId(), cgPetChangeName.getNewName());
	}
		/**
 	* 武将解雇
 	* 
 	* CodeGenerator
 	*/
	public void handlePetFire(Player player, CGPetFire cgPetFire) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetFire.getPetId() <= 0) {
			return;
		}
		
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetService().firePet(player.getHuman(), cgPetFire.getPetId());
	}
	
	/**
	 * 宠物刷天赋技能
	 * @param player
	 * @param cgPetRefreshTalentSkill
	 */
	public void handlePetRefreshTalentSkill(Player player, CGPetRefreshTalentSkill cgPetRefreshTalentSkill) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetRefreshTalentSkill.getPetId() <= 0) {
			return;
		}
		
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetService().refreshPetTalentSkill(player.getHuman(), cgPetRefreshTalentSkill.getPetId());
	}
	
	/**
	 * 宠物学习普通技能
	 * @param player
	 * @param cgPetStudyNormalSkill
	 */
	public void handlePetStudyNormalSkill(Player player, CGPetStudyNormalSkill cgPetStudyNormalSkill) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetStudyNormalSkill.getPetId() <= 0) {
			return;
		}
		if (cgPetStudyNormalSkill.getItemTplId() <= 0) {
			return;
		}
		
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetService().petStudyNormalSkill(player.getHuman(), cgPetStudyNormalSkill.getPetId(), cgPetStudyNormalSkill.getItemTplId());
	}
	
	/**
	* 还童，洗资质
	* 
	* CodeGenerator
	*/
	public void handlePetRejuven(Player player, CGPetRejuven cgPetRejuven) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetRejuven.getPetId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetService().petRejuvenation(player.getHuman(), cgPetRejuven.getPetId());
	}
	/**
	* 变异
	* 
	* CodeGenerator
	*/
	public void handlePetVariation(Player player, CGPetVariation cgPetVariation) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetVariation.getPetId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		boolean isBatch = cgPetVariation.getIsBatch() >  0;
		Globals.getPetService().petVariation(player.getHuman(), cgPetVariation.getPetId(), isBatch);
	}
	/**
	* 炼化，成长
	* 
	* CodeGenerator
	*/
	public void handlePetArtifice(Player player, CGPetArtifice cgPetArtifice) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetArtifice.getPetId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().petArtifice(player.getHuman(), cgPetArtifice.getPetId());
	}
	
	/**
	 * 宠物培养
	 * @param player
	 * @param cgPetTrain
	 */
	public void handlePetTrain(Player player, CGPetTrain cgPetTrain) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetTrain.getPetId() <= 0) {
			return;
		}
		if (cgPetTrain.getTrainTypeId() <= 0) {
			return;
		}
		PetTrainType trainType = PetTrainType.valueOf(cgPetTrain.getTrainTypeId());
		if (trainType == null) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().petTrain(player.getHuman(), cgPetTrain.getPetId(), trainType);
	}
	
	/**
	 * 宠物培养确认更新属性
	 * @param player
	 * @param cgPetTrainUpdate
	 */
	public void handlePetTrainUpdate(Player player, CGPetTrainUpdate cgPetTrainUpdate) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetTrainUpdate.getPetId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().petTrainUpdate(player.getHuman(), cgPetTrainUpdate.getPetId());
	}
	
	/**
	* 宠物悟性提升
	* 
	* CodeGenerator
	*/
	public void handlePetPerceptAddExp(Player player, CGPetPerceptAddExp cgPetPerceptAddExp) {
		if (!checkRoleAndFuncForPercept(player)) {
			return;
		}
		if (cgPetPerceptAddExp.getPetId() <= 0) {
			return;
		}
		if (cgPetPerceptAddExp.getAddType() <= 0) {
			return;
		}
		if (cgPetPerceptAddExp.getIsBatch() <= 0 || cgPetPerceptAddExp.getIsBatch() >= 3) {//1是，2否
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().petPerceptAddExp(player.getHuman(), cgPetPerceptAddExp.getPetId(),cgPetPerceptAddExp.getAddType(),cgPetPerceptAddExp.getIsBatch()==1?true:false);
	}
	
 	/** 骑宠改名
 	* 
 	* CodeGenerator
 	*/
	public void handlePetHorseChangeName(Player player, CGPetHorseChangeName cgPetHorseChangeName) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetHorseChangeName.getPetId() <= 0 || cgPetHorseChangeName.getNewName().isEmpty()) {
			return;
		}
		
		Globals.getPetService().petHorseChangeName(player.getHuman(), cgPetHorseChangeName.getPetId(), cgPetHorseChangeName.getNewName());
	}
		/**
 	* 骑宠放生
 	* 
 	* CodeGenerator
 	*/
	public void handlePetHorseFire(Player player, CGPetHorseFire cgPetHorseFire) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetHorseFire.getPetId() <= 0) {
			return;
		}
		
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetService().firePetHorse(player.getHuman(), cgPetHorseFire.getPetId());
	}
	
	/**
	 * 骑宠骑乘or休息
	 * @param player
	 * @param cgPetHorseRide
	 */
	public void handlePetHorseRide(Player player, CGPetHorseRide cgPetHorseRide) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetHorseRide.getPetId() <= 0 || cgPetHorseRide.getState() < 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().horseRide(player.getHuman(), cgPetHorseRide.getPetId(), cgPetHorseRide.getState());
	}
	
	/**
	* 骑宠悟性增加经验
	* 
	* CodeGenerator
	*/
	public void handlePetHorsePerceptAddExp(Player player, CGPetHorsePerceptAddExp cgPetHorsePerceptAddExp) {
		if (!checkRoleAndFuncForPercept(player)) {
			return;
		}
		if (cgPetHorsePerceptAddExp.getPetId() <= 0) {
			return;
		}
		if (cgPetHorsePerceptAddExp.getAddType() <= 0) {
			return;
		}
		if (cgPetHorsePerceptAddExp.getIsBatch() <= 0 || cgPetHorsePerceptAddExp.getIsBatch() >= 3) {//1是，2否
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().petHorsePerceptAddExp(player.getHuman(), cgPetHorsePerceptAddExp.getPetId(),cgPetHorsePerceptAddExp.getAddType(),cgPetHorsePerceptAddExp.getIsBatch()==1?true:false);
	}
	
	/**
	 * 骑宠培养
	 * @param player
	 * @param cgPetHorseTrain
	 */
	public void handlePetHorseTrain(Player player, CGPetHorseTrain cgPetHorseTrain) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetHorseTrain.getPetId() <= 0) {
			return;
		}
		if (cgPetHorseTrain.getTrainTypeId() <= 0) {
			return;
		}
		PetTrainType trainType = PetTrainType.valueOf(cgPetHorseTrain.getTrainTypeId());
		if (trainType == null) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().petHorseTrain(player.getHuman(), cgPetHorseTrain.getPetId(), trainType);
	}
	
	/**
	 * 骑宠培养确认更新属性
	 * @param player
	 * @param cgPetHorseTrainUpdate
	 */
	public void handlePetHorseTrainUpdate(Player player, CGPetHorseTrainUpdate cgPetHorseTrainUpdate) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetHorseTrainUpdate.getPetId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().petHorseTrainUpdate(player.getHuman(), cgPetHorseTrainUpdate.getPetId());
	}
	
	/**
	* 骑宠还童，洗资质
	* 
	* CodeGenerator
	*/
	public void handlePetHorseRejuven(Player player, CGPetHorseRejuven cgPetHorseRejuven) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetHorseRejuven.getPetId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetService().petHorseRejuvenation(player.getHuman(), cgPetHorseRejuven.getPetId());
	}
	
	/**
	* 骑宠炼化，成长
	* 
	* CodeGenerator
	*/
	public void handlePetHorseArtifice(Player player, CGPetHorseArtifice cgPetHorseArtifice) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetHorseArtifice.getPetId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().petHorseArtifice(player.getHuman(), cgPetHorseArtifice.getPetId());
	}
	
	
	/**
 	* 打开伙伴面板
 	* 
 	* CodeGenerator
 	*/
	public void handlePetOpenFriendPanel(Player player, CGPetOpenFriendPanel cgPetOpenFriendPanel) {
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
//		
//		Globals.getPetService().openFriendPanel(player.getHuman());
	}
		/**
 	* 请求单个伙伴的信息
 	* 
 	* CodeGenerator
 	*/
	public void handlePetFriendInfo(Player player, CGPetFriendInfo cgPetFriendInfo) {
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
//		
//		int tplId = cgPetFriendInfo.getTplId();
//		if (tplId <= 0) {
//			return;
//		}
//		
//		Globals.getPetService().sendFriendInfoMsg(player.getHuman(), tplId);
	}
		/**
 	* 切换正在使用的阵容
 	* 
 	* CodeGenerator
 	*/
	public void handlePetFriendChangeArray(Player player, CGPetFriendChangeArray cgPetFriendChangeArray) {
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
//		
//		int arrayIndex = cgPetFriendChangeArray.getArrayIndex();
//		if (arrayIndex < 0) {
//			return;
//		}
//		//战斗中，不能进行此操作
//		if (player.getHuman().isInAnyBattle()) {
//			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
//			return;
//		}
//		Globals.getPetService().changeFriendCurArray(player.getHuman(), arrayIndex);
	}
		/**
 	* 伙伴上阵
 	* 
 	* CodeGenerator
 	*/
	public void handlePetFriendPutonArray(Player player, CGPetFriendPutonArray cgPetFriendPutonArray) {
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
//		
//		int tplId = cgPetFriendPutonArray.getTplId();
//		int arrayIndex = cgPetFriendPutonArray.getArrayIndex();
//		int targetPosIndex = cgPetFriendPutonArray.getTargetPosIndex();
//		if (tplId <= 0 || arrayIndex < 0 || targetPosIndex < 0) {
//			return;
//		}
//		
//		//战斗中，不能进行此操作
//		if (player.getHuman().isInAnyBattle()) {
//			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
//			return;
//		}
//		Globals.getPetService().friendPutOnArray(player.getHuman(), arrayIndex, tplId, targetPosIndex);
	}
		/**
 	* 伙伴下阵
 	* 
 	* CodeGenerator
 	*/
	public void handlePetFriendOffArray(Player player, CGPetFriendOffArray cgPetFriendOffArray) {
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
//		
//		int arrayIndex = cgPetFriendOffArray.getArrayIndex();
//		int targetPosIndex = cgPetFriendOffArray.getTargetPosIndex();
//		if (targetPosIndex < 0 || arrayIndex < 0) {
//			return;
//		}
//		//战斗中，不能进行此操作
//		if (player.getHuman().isInAnyBattle()) {
//			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
//			return;
//		}
//		Globals.getPetService().friendOffArray(player.getHuman(), arrayIndex, targetPosIndex);
	}
		/**
 	* 伙伴调整位置
 	* 
 	* CodeGenerator
 	*/
	public void handlePetFriendChangePosition(Player player, CGPetFriendChangePosition cgPetFriendChangePosition) {
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
//		
//		int tplId = cgPetFriendChangePosition.getTplId();
//		int arrayIndex = cgPetFriendChangePosition.getArrayIndex();
//		int targetPosIndex = cgPetFriendChangePosition.getTargetPosIndex();
//		if (tplId <= 0 || targetPosIndex < 0 || arrayIndex < 0) {
//			return;
//		}
//		//战斗中，不能进行此操作
//		if (player.getHuman().isInAnyBattle()) {
//			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
//			return;
//		}
//		Globals.getPetService().friendChangePosition(player.getHuman(), arrayIndex, tplId, targetPosIndex);
	}
		/**
 	* 伙伴解锁
 	* 
 	* CodeGenerator
 	*/
	public void handlePetFriendUnlock(Player player, CGPetFriendUnlock cgPetFriendUnlock) {
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
//		
//		int tplId = cgPetFriendUnlock.getTplId();
//		int unlockId = cgPetFriendUnlock.getUnlockId();
//		if (tplId <= 0 || unlockId <= 0) {
//			return;
//		}
//		
//		Globals.getPetService().friendUnlock(player.getHuman(), tplId, unlockId);
	}
	
	/**
	 * 洗点
	 * @param player
	 * @param cgPetResetPoint
	 */
	public void handlePetResetPoint(Player player, CGPetResetPoint cgPetResetPoint) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetResetPoint.getPetId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getPetService().petResetPoint(player.getHuman(), cgPetResetPoint.getPetId());
	}
	
	/**
 	* 主将学习技能
 	* 
 	* CodeGenerator
 	*/
	public void handlePetLeaderStudySkill(Player player, CGPetLeaderStudySkill cgPetLeaderStudySkill) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetLeaderStudySkill.getItemTplId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetSkillService().leaderStudySkill(player.getHuman(), cgPetLeaderStudySkill.getItemTplId());
	}
		/**
 	* 主将技能开启仙符格子
 	* 
 	* CodeGenerator
 	*/
	public void handlePetSkillEffectOpenPosition(Player player, CGPetSkillEffectOpenPosition cgPetSkillEffectOpenPosition) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgPetSkillEffectOpenPosition.getSkillId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetSkillService().leaderSkillOpenPosition(player.getHuman(), cgPetSkillEffectOpenPosition.getSkillId());
	}
		/**
 	* 主将技能镶嵌仙符或更换仙符
 	* 
 	* CodeGenerator
 	*/
	public void handlePetEmbedSkillEffect(Player player, CGPetEmbedSkillEffect cgPetEmbedSkillEffect) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		//参数简单校验
		if (cgPetEmbedSkillEffect.getSkillId() <= 0) {
			return;
		}
		if (cgPetEmbedSkillEffect.getPosId() <= 0) {
			return;
		}
		if (cgPetEmbedSkillEffect.getItemIndex() < 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetSkillService().leaderSkillEmbed(player.getHuman(), cgPetEmbedSkillEffect.getSkillId(), 
				cgPetEmbedSkillEffect.getPosId(), cgPetEmbedSkillEffect.getItemIndex());
	}
	
	/**
	 * 主将技能卸下仙符
	 * @param player
	 * @param cgPetUnembedSkillEffect
	 */
	public void handlePetUnembedSkillEffect(Player player, CGPetUnembedSkillEffect cgPetUnembedSkillEffect) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		//参数简单校验
		if (cgPetUnembedSkillEffect.getSkillId() <= 0) {
			return;
		}
		if (cgPetUnembedSkillEffect.getPosId() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetSkillService().leaderSkillUnEmbed(player.getHuman(), cgPetUnembedSkillEffect.getSkillId(), 
				cgPetUnembedSkillEffect.getPosId());
	}

		/**
 	* 主将技能仙符升级
 	* 
 	* CodeGenerator
 	*/
	public void handlePetSkillEffectUplevel(Player player, CGPetSkillEffectUplevel cgPetSkillEffectUplevel) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		//参数简单校验
		if (cgPetSkillEffectUplevel.getSkillId() <= 0) {
			return;
		}
		if (cgPetSkillEffectUplevel.getPosId() <= 0) {
			return;
		}
		int len = cgPetSkillEffectUplevel.getItemIndexList().length;
		if (len <= 0 || len > player.getHuman().getInventory().getSkillEffectBag().getCapacity()) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		Globals.getPetSkillService().leaderSkillEffectUpLevel(player.getHuman(), 
				cgPetSkillEffectUplevel.getSkillId(), cgPetSkillEffectUplevel.getPosId(), 
				cgPetSkillEffectUplevel.getItemIndexList());
	}
	
}
