package com.imop.lj.gameserver.team.handler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.team.TeamDef.TeamInviteType;
import com.imop.lj.gameserver.team.msg.CGTeamApply;
import com.imop.lj.gameserver.team.msg.CGTeamApplyAgree;
import com.imop.lj.gameserver.team.msg.CGTeamApplyAuto;
import com.imop.lj.gameserver.team.msg.CGTeamApplyList;
import com.imop.lj.gameserver.team.msg.CGTeamApplyListClean;
import com.imop.lj.gameserver.team.msg.CGTeamAutoMatch;
import com.imop.lj.gameserver.team.msg.CGTeamAway;
import com.imop.lj.gameserver.team.msg.CGTeamBack;
import com.imop.lj.gameserver.team.msg.CGTeamCallBack;
import com.imop.lj.gameserver.team.msg.CGTeamChangeLeader;
import com.imop.lj.gameserver.team.msg.CGTeamChangePosition;
import com.imop.lj.gameserver.team.msg.CGTeamChatSpeak;
import com.imop.lj.gameserver.team.msg.CGTeamChooseTarget;
import com.imop.lj.gameserver.team.msg.CGTeamCreate;
import com.imop.lj.gameserver.team.msg.CGTeamInviteList;
import com.imop.lj.gameserver.team.msg.CGTeamInvitePlayer;
import com.imop.lj.gameserver.team.msg.CGTeamInvitePlayerAnswer;
import com.imop.lj.gameserver.team.msg.CGTeamKick;
import com.imop.lj.gameserver.team.msg.CGTeamMy;
import com.imop.lj.gameserver.team.msg.CGTeamQuit;
import com.imop.lj.gameserver.team.msg.CGTeamShowList;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class TeamMessageHandler {	
	
	public TeamMessageHandler() {	
	}	
		/**
 	* 创建队伍
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamCreate(Player player, CGTeamCreate cgTeamCreate) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getTeamService().playerCreateTeam(player.getHuman());
	}
	
	/**
	 * 请求我的队伍
	 * @param player
	 * @param cgTeamMy
	 */
	public void handleTeamMy(Player player, CGTeamMy cgTeamMy) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getTeamService().showMyTeam(player.getHuman());
	}
		/**
 	* 设置队伍自动匹配
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamAutoMatch(Player player, CGTeamAutoMatch cgTeamAutoMatch) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		boolean isAuto = cgTeamAutoMatch.getIsAutoMatch() == 1 ? true : false;
		Globals.getTeamService().changeTeamAutoMatch(player.getHuman(), isAuto, true);
	}
		/**
 	* 申请列表
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamApplyList(Player player, CGTeamApplyList cgTeamApplyList) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getTeamService().openApplyListPanel(player.getHuman());
	}
		/**
 	* 清空申请列表
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamApplyListClean(Player player, CGTeamApplyListClean cgTeamApplyListClean) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getTeamService().clearApplyList(player.getHuman());
	}
	/**
	 * 同意申请
	 * @param player
	 * @param cgTeamApplyListClean
	 */
	public void handleTeamApplyAgree(Player player, CGTeamApplyAgree cgTeamApplyAgree) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		long targetRoleId = cgTeamApplyAgree.getTargetPlayerId();
		if (targetRoleId <= 0) {
			return;
		}
		
		Globals.getTeamService().agreeApplyer(player.getHuman(), targetRoleId);
	}
		/**
 	* 选择队伍的目标
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamChooseTarget(Player player, CGTeamChooseTarget cgTeamChooseTarget) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		int targetId = cgTeamChooseTarget.getTargetId();
		int levelMin = cgTeamChooseTarget.getLevelMin();
		int levelMax = cgTeamChooseTarget.getLevelMax();
		boolean isAutoMatch = cgTeamChooseTarget.getIsAutoMatch() == 1 ? true : false;
		if (targetId < 0 || levelMin <= 0 || levelMax <= 0) {
			return;
		}
		
		Globals.getTeamService().chooseTarget(player.getHuman(), targetId, levelMin, levelMax, isAutoMatch);
	}
		/**
 	* 显示队伍列表界面
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamShowList(Player player, CGTeamShowList cgTeamShowList) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		int targetId = cgTeamShowList.getTargetId();
		if (targetId < 0) {
			return;
		}
		
		Globals.getTeamService().openTeamListPanel(player.getHuman(), targetId);
	}
		/**
 	* 申请加入队伍
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamApply(Player player, CGTeamApply cgTeamApply) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		int teamId = cgTeamApply.getTeamId();
		if (teamId <= 0) {
			return;
		}
		
		Globals.getTeamService().applyJoinTeam(player.getHuman(), teamId);
	}
		/**
 	* 自动申请加入队伍
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamApplyAuto(Player player, CGTeamApplyAuto cgTeamApplyAuto) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		boolean isAuto = cgTeamApplyAuto.getIsAuto() == 1 ? true : false;
		int targetId = cgTeamApplyAuto.getTargetId();
		if (targetId < 0) {
			return;
		}
		
		Globals.getTeamService().autoApplyJoinTeam(player.getHuman(), isAuto, targetId);
	}
		/**
 	* 邀请成员列表
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamInviteList(Player player, CGTeamInviteList cgTeamInviteList) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		TeamInviteType invType = TeamInviteType.valueOf(cgTeamInviteList.getInviteTypeId());
		if (null == invType) {
			return;
		}
		
		Globals.getTeamService().showInviteList(player.getHuman(), invType);
	}
		/**
 	* 邀请成员加入队伍
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamInvitePlayer(Player player, CGTeamInvitePlayer cgTeamInvitePlayer) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		long targetRoleId = cgTeamInvitePlayer.getTargetPlayerId();
		if (targetRoleId <= 0) {
			return;
		}
		TeamInviteType invType = TeamInviteType.valueOf(cgTeamInvitePlayer.getInviteTypeId());
		if (null == invType) {
			return;
		}
		
		Globals.getTeamService().invitePlayerJoinTeam(player.getHuman(), invType, targetRoleId);
	}
		/**
 	* 邀请成员弹出提示框的响应
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamInvitePlayerAnswer(Player player, CGTeamInvitePlayerAnswer cgTeamInvitePlayerAnswer) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		boolean isAgree = cgTeamInvitePlayerAnswer.getAgree() == 1 ? true : false;
		int teamId = cgTeamInvitePlayerAnswer.getTeamId();
		if (teamId <= 0) {
			return;
		}
		
		Globals.getTeamService().invitedPlayerAnswer(player.getHuman(), teamId, isAgree);
	}
		/**
 	* 暂离队伍
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamAway(Player player, CGTeamAway cgTeamAway) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getTeamService().playerAwayFromTeam(player.getHuman());
	}
		/**
 	* 退出队伍
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamQuit(Player player, CGTeamQuit cgTeamQuit) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getTeamService().playerLeaveTeam(player.getHuman());
	}
		/**
 	* 回到队伍，暂离状态下
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamBack(Player player, CGTeamBack cgTeamBack) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getTeamService().playerReturnTeam(player.getHuman());
	}
		/**
 	* 召唤队友归队
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamCallBack(Player player, CGTeamCallBack cgTeamCallBack) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		long targetRoleId = cgTeamCallBack.getTargetPlayerId();
		if (targetRoleId <= 0) {
			return;
		}
		
		Globals.getTeamService().callPlayerBack(player.getHuman(), targetRoleId);
	}
		/**
 	* 一键喊话
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamChatSpeak(Player player, CGTeamChatSpeak cgTeamChatSpeak) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getTeamService().teamChatJoin(player.getHuman());
	}
		/**
 	* 调整队员位置
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamChangePosition(Player player, CGTeamChangePosition cgTeamChangePosition) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		long targetRoleId = cgTeamChangePosition.getTargetPlayerId();
		int targetPosition = cgTeamChangePosition.getTargetPosition();
		if (targetRoleId <= 0 || targetPosition <= 0) {
			return;
		}
		
		Globals.getTeamService().changePlayerPosition(player.getHuman(), targetRoleId, targetPosition);
	}
		/**
 	* 升为队长
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamChangeLeader(Player player, CGTeamChangeLeader cgTeamChangeLeader) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		long targetRoleId = cgTeamChangeLeader.getTargetPlayerId();
		if (targetRoleId <= 0) {
			return;
		}
		
		Globals.getTeamService().playerChangeLeader(player.getHuman(), targetRoleId);
	}
		/**
 	* 请离队伍
 	* 
 	* CodeGenerator
 	*/
	public void handleTeamKick(Player player, CGTeamKick cgTeamKick) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		long targetRoleId = cgTeamKick.getTargetPlayerId();
		if (targetRoleId <= 0) {
			return;
		}
		
		Globals.getTeamService().kickPlayer(player.getHuman(), targetRoleId);
	}
	}
