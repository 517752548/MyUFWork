
package com.imop.lj.gameserver.battle.handler;

import com.imop.lj.gameserver.battle.msg.CGBattleLeaderReadyPvp;
import com.imop.lj.gameserver.battle.msg.CGBattleLeaderReadyTeam;
import com.imop.lj.gameserver.battle.msg.CGBattleNextRound;
import com.imop.lj.gameserver.battle.msg.CGBattleNextRoundPvp;
import com.imop.lj.gameserver.battle.msg.CGBattleNextRoundTeam;
import com.imop.lj.gameserver.battle.msg.CGBattlePvpCancelAuto;
import com.imop.lj.gameserver.battle.msg.CGBattleReadReportEnd;
import com.imop.lj.gameserver.battle.msg.CGBattleSpeedup;
import com.imop.lj.gameserver.battle.msg.CGBattleStartPvp;
import com.imop.lj.gameserver.battle.msg.CGBattleStartPvpConfirm;
import com.imop.lj.gameserver.battle.msg.CGBattleStartTeampvp;
import com.imop.lj.gameserver.battle.msg.CGBattleTeamCancelAuto;
import com.imop.lj.gameserver.battle.msg.CGBattleUpdateAutoAction;
import com.imop.lj.gameserver.battle.msg.CGPlayBattleReport;
import com.imop.lj.gameserver.battle.msg.CGPlayBattleReportByStrId;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.util.StringUtil;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class BattleMessageHandler {	
	
	public BattleMessageHandler() {	
	}	
		/**
 	* 客户端请求播放战报
 	* 
 	* CodeGenerator
 	*/
	public void handlePlayBattleReport(Player player, CGPlayBattleReport cgPlayBattleReport) {
//		//FIXME test
//		Globals.getBattleService().testBattle(player.getHuman());
		
//		Globals.getBattleReportService().playBattleReport(player.getHuman(), cgPlayBattleReport.getId(), false,cgPlayBattleReport.getToBackType());
	}
		/**
 	* 客户端请求播放战报
 	* 
 	* CodeGenerator
 	*/
	public void handlePlayBattleReportByStrId(Player player, CGPlayBattleReportByStrId cgPlayBattleReportByStrId) {
		String idStr = cgPlayBattleReportByStrId.getIdStr();
		long id = StringUtil.parseStringTOLong(idStr);
		Globals.getBattleReportService().playBattleReport(player.getHuman(), id, false,cgPlayBattleReportByStrId.getToBackType());
	}
	
	/**
	 * 请求下一轮战报
	 * @param player
	 * @param cgBattleNextRound
	 */
	public void handleBattleNextRound(Player player, CGBattleNextRound cgBattleNextRound) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		boolean isAuto = cgBattleNextRound.getIsAuto() == 1;
		int selSkillId = cgBattleNextRound.getSelSkillId();
		int selTarget = cgBattleNextRound.getSelTarget();
		int selItemId = cgBattleNextRound.getSelItemId();
		int petSelSkillId = cgBattleNextRound.getPetSelSkillId();
		int petSelTarget = cgBattleNextRound.getPetSelTarget();
		int petSelItemId = cgBattleNextRound.getPetSelItemId();
		long summonPetId = cgBattleNextRound.getSummonPetId();
		if (selSkillId < 0 || petSelSkillId < 0 ||
				selTarget < 0 || petSelTarget < 0 ||
				selItemId < 0 || petSelItemId < 0 ||
				summonPetId < 0) {
			return;
		}
		Globals.getBattleService().requestPVEBattleRound(player.getHuman(), isAuto, 
				selSkillId, selTarget, selItemId, petSelSkillId, petSelTarget, petSelItemId, summonPetId);
	}
	
	public void handleBattleStartPvp(Player player, CGBattleStartPvp cgBattleStartPvp) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		if (cgBattleStartPvp.getTargetPlayerId() <= 0) {
			return;
		}
		
		Globals.getPvpService().requestStartPvpBattle(player.getHuman(), cgBattleStartPvp.getTargetPlayerId());
	}
	
	public void handleBattleStartPvpConfirm(Player player, CGBattleStartPvpConfirm cgBattleStartPvpConfirm) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		if (cgBattleStartPvpConfirm.getSourcePlayerId() <= 0) {
			return;
		}
		boolean isAgree = cgBattleStartPvpConfirm.getAgree() == 1 ? true : false;
		
		Globals.getPvpService().startPvpBattleConfirm(player.getHuman(), cgBattleStartPvpConfirm.getSourcePlayerId(), isAgree);
	}
	
	public void handleBattlePvpCancelAuto(Player player, CGBattlePvpCancelAuto cgBattlePvpCancelAuto) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getPvpService().cancelAuto(player.getHuman());
	}
	
	public void handleBattleNextRoundPvp(Player player, CGBattleNextRoundPvp cgBattleNextRoundPvp) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		boolean isAuto = cgBattleNextRoundPvp.getIsAuto() == 1;
		int selSkillId = cgBattleNextRoundPvp.getSelSkillId();
		int selTarget = cgBattleNextRoundPvp.getSelTarget();
		int selItemId = cgBattleNextRoundPvp.getSelItemId();
		int petSelSkillId = cgBattleNextRoundPvp.getPetSelSkillId();
		int petSelTarget = cgBattleNextRoundPvp.getPetSelTarget();
		int petSelItemId = cgBattleNextRoundPvp.getPetSelItemId();
		long summonPetId = cgBattleNextRoundPvp.getSummonPetId();
		if (selSkillId < 0 || petSelSkillId < 0 ||
				selTarget < 0 || petSelTarget < 0 ||
				selItemId < 0 || petSelItemId < 0 ||
				summonPetId < 0) {
			return;
		}
		
		Globals.getPvpService().chooseSkillRound(player.getHuman(), isAuto, 
				selSkillId, selTarget, selItemId, petSelSkillId, petSelTarget, petSelItemId, summonPetId);
	}
	
	public void handleBattleUpdateAutoAction(Player player, CGBattleUpdateAutoAction cgBattleUpdateAutoAction) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		int petTypeId = cgBattleUpdateAutoAction.getPetTypeId();
		int selSkillId = cgBattleUpdateAutoAction.getSelSkillId();
		if (petTypeId <= 0 || selSkillId <= 0) {
			return;
		}
		
		Globals.getBattleService().changeAutoAction(player.getHuman(), petTypeId, selSkillId);
	}
	
	public void handleBattleNextRoundTeam(Player player, CGBattleNextRoundTeam cgBattleNextRoundTeam) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		boolean isAuto = cgBattleNextRoundTeam.getIsAuto() == 1;
		int selSkillId = cgBattleNextRoundTeam.getSelSkillId();
		int selTarget = cgBattleNextRoundTeam.getSelTarget();
		int selItemId = cgBattleNextRoundTeam.getSelItemId();
		int petSelSkillId = cgBattleNextRoundTeam.getPetSelSkillId();
		int petSelTarget = cgBattleNextRoundTeam.getPetSelTarget();
		int petSelItemId = cgBattleNextRoundTeam.getPetSelItemId();
		long summonPetId = cgBattleNextRoundTeam.getSummonPetId();
		if (selSkillId < 0 || petSelSkillId < 0 ||
				selTarget < 0 || petSelTarget < 0 ||
				selItemId < 0 || petSelItemId < 0 ||
				summonPetId < 0) {
			return;
		}
		
		//组队pvp
		if (Globals.getTeamPvpService().isInTeamPvpBattle(player.getCharId())) {
			Globals.getTeamPvpService().chooseSkillRound(player.getHuman(), isAuto, 
					selSkillId, selTarget, selItemId, petSelSkillId, petSelTarget, petSelItemId, summonPetId);
		} else {
			Globals.getTeamService().getTeamBattleLogic().chooseSkillRound(player.getHuman(), isAuto, 
					selSkillId, selTarget, selItemId, petSelSkillId, petSelTarget, petSelItemId, summonPetId);
		}
	}
	
	public void handleBattleTeamCancelAuto(Player player, CGBattleTeamCancelAuto cgBattleTeamCancelAuto) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		//组队pvp
		if (Globals.getTeamPvpService().isInTeamPvpBattle(player.getCharId())) {
			Globals.getTeamPvpService().cancelAuto(player.getHuman());
		} else {
			Globals.getTeamService().getTeamBattleLogic().cancelAuto(player.getHuman());
		}
	}
	
	/**
 	* 主将准备中状态已完毕pvp
 	* 
 	* CodeGenerator
 	*/
	public void handleBattleLeaderReadyPvp(Player player, CGBattleLeaderReadyPvp cgBattleLeaderReadyPvp) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getPvpService().onLeaderReady(player.getHuman());
	}
		/**
 	* 主将准备中状态已完毕team
 	* 
 	* CodeGenerator
 	*/
	public void handleBattleLeaderReadyTeam(Player player, CGBattleLeaderReadyTeam cgBattleLeaderReadyTeam) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		//组队pvp
		if (Globals.getTeamPvpService().isInTeamPvpBattle(player.getCharId())) {
			Globals.getTeamPvpService().onLeaderReady(player.getHuman());
		} else {
			Globals.getTeamService().getTeamBattleLogic().onLeaderReady(player.getHuman());
		}
	}
	
	/**
	 * 客户端播放战报完毕，请求结束战斗
	 * @param player
	 * @param cgBattleReadReportEnd
	 */
	public void handleBattleReadReportEnd(Player player, CGBattleReadReportEnd cgBattleReadReportEnd) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getBattleService().requestReadLastReportEnd(player.getHuman());
	}
	
	/**
	 * 请求组队pvp战斗
	 * @param player
	 * @param cgBattleStartTeampvp
	 */
	public void handleBattleStartTeampvp(Player player, CGBattleStartTeampvp cgBattleStartTeampvp) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		if (cgBattleStartTeampvp.getTargetPlayerId() <= 0) {
			return;
		}
		
		Globals.getCorpsWarService().startTeamPvpFight(player.getHuman(), cgBattleStartTeampvp.getTargetPlayerId());
	}

	/**
	 * 战斗加速功能，用于前台播放战报的时候加速
	 * @param player
	 * @param cgBattleSpeedup
	 */
	public void handleBattleSpeedup(Player player, CGBattleSpeedup cgBattleSpeedup) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgBattleSpeedup.getSpeed() < 0) {
			return;
		}
		
		Globals.getBattleService().speedup(player.getHuman(), cgBattleSpeedup.getSpeed());
	}
	
	}
