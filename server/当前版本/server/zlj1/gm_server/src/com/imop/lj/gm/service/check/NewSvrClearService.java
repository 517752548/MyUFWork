package com.imop.lj.gm.service.check;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dao.check.NewSvrCheckDAO;
import com.imop.lj.gm.dao.check.NewSvrClearDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.notice.TimeNoticeService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.ErrorsUtil;
import com.imop.lj.gm.utils.LogUtil;

/**
 * 新服清理Service
 *
 * @author lin fan
 *
 */
public class NewSvrClearService {

	private NewSvrClearDAO newSvrClearDAO;

	private NewSvrCheckDAO newSvrCheckDAO;

	private TimeNoticeService timeNoticeService;

	private CmdManageService cmdManageService;

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public TimeNoticeService getTimeNoticeService() {
		return timeNoticeService;
	}

	public void setTimeNoticeService(TimeNoticeService timeNoticeService) {
		this.timeNoticeService = timeNoticeService;
	}

	public NewSvrCheckDAO getNewSvrCheckDAO() {
		return newSvrCheckDAO;
	}

	public void setNewSvrCheckDAO(NewSvrCheckDAO newSvrCheckDAO) {
		this.newSvrCheckDAO = newSvrCheckDAO;
	}

	/** vitRecLog log */
	private static final Logger vitRecLog = LoggerFactory
			.getLogger("vitRecLog");

	public NewSvrClearDAO getNewSvrClearDAO() {
		return newSvrClearDAO;
	}

	public void setNewSvrClearDAO(NewSvrClearDAO newSvrClearDAO) {
		this.newSvrClearDAO = newSvrClearDAO;
	}

	/**
	 * @return
	 */
	public boolean newSvrClear() {
		try {
			StringBuffer info= new StringBuffer();
			info.append("\t\n");
			info.append("**********************Batch delete table start!**********************\t\n");

			info.append("Batch delete t_user_info start.\t\n");
			newSvrClearDAO.deleteUserInfo();
			info.append("Batch delete t_user_info end.\t\n");

			info.append("Batch delete t_character_info start.\t\n");
			newSvrClearDAO.deleteRole();
			info.append("Batch delete t_character_info end.\t\n");

			info.append("Batch delete t_item_info start.\t\n");
			newSvrClearDAO.deleteItem();
			info.append("Batch delete t_item_info end.\t\n");

//			info.append("Batch delete t_pet_info start.\t\n");
//			newSvrClearDAO.deletePet();
//			info.append("Batch delete t_pet_info end.\t\n");

			info.append("Batch delete t_battle_info_snap start.\t\n");
			newSvrClearDAO.deleteBattleSnap();
			info.append("Batch delete t_battle_info_snap end.\t\n");

			info.append("Batch delete t_scene_info start.\t\n");
			newSvrClearDAO.deleteScene();
			info.append("Batch delete t_scene_info end.\t\n");

			info.append("Batch delete t_silverore_info start.\t\n");
			newSvrClearDAO.deleteSilverore();
			info.append("Batch delete t_silverore_info end.\t\n");

//			info.append("Batch delete t_mission_enemy_info start.\t\n");
//			newSvrClearDAO.deleteMissionEnemyEntity();
//			info.append("Batch delete t_mission_enemy_info end.\t\n");

			info.append("Batch delete t_mail_info start.\t\n");
			newSvrClearDAO.deleteMailEntity();
			info.append("Batch delete t_mail_info end.\t\n");

//			info.append("Batch delete t_farm_info start.\t\n");
//			newSvrClearDAO.deleteFarmEntity();
//			info.append("Batch delete t_farm_info end.\t\n");

//			info.append("Batch delete t_shopmall_info start.\t\n");
//			newSvrClearDAO.deleteShopmallEntity();
//			info.append("Batch delete t_shopmall_info end.\t\n");

			info.append("Batch delete t_daily_task start.\t\n");
			newSvrClearDAO.deleteDailyTaskInfo();
			info.append("Batch delete t_daily_task end.\t\n");

			info.append("Batch delete t_doing_task start.\t\n");
			newSvrClearDAO.deleteDoingTaskInfo();
			info.append("Batch delete t_doing_task end.\t\n");

			info.append("Batch delete t_finished_quest start.\t\n");
			newSvrClearDAO.deleteFinishTaskInfo();
			info.append("Batch delete t_finished_quest end.\t\n");

//			info.append("Batch delete t_guild start.\t\n");
//			newSvrClearDAO.deleteGuildInfo();
//			info.append("Batch delete t_guild end.\t\n");

//			info.append("Batch delete t_guild_member start.\t\n");
//			newSvrClearDAO.deleteGuildMemberInfo();
//			info.append("Batch delete t_guild_member end.\t\n");

//			info.append("Batch delete t_festival_info start.\t\n");
//			newSvrClearDAO.deleteFestivalEntity();
//			info.append("Batch delete t_festival_info end.\t\n");

//			info.append("Batch delete t_arena_log start.\t\n");
//			newSvrClearDAO.deleteArenaLog();
//			info.append("Batch delete t_arena_log end.\t\n");

//			info.append("Batch delete t_arena_rank start.\t\n");
//			newSvrClearDAO.deleteArenaRank();
//			info.append("Batch delete t_arena_rank end.\t\n");

			info.append("Batch delete t_arena_snap start.\t\n");
			newSvrClearDAO.deleteArenaSnap();
			info.append("Batch delete t_arena_snap end.\t\n");
			//新加
			info.append("Batch delete t_boss_info start.\t\n");
			newSvrClearDAO.deleteBossEntity();
			info.append("Batch delete t_boss_info end.\t\n");

			info.append("Batch delete t_branch_info start.\t\n");
			newSvrClearDAO.deleteBranchEntity();
			info.append("Batch delete t_branch_info end.\t\n");

			info.append("Batch delete t_employee_info start.\t\n");
			newSvrClearDAO.deleteEmployeeEntity();
			info.append("Batch delete t_employee_info end.\t\n");

			info.append("Batch delete t_escort_help_snap start.\t\n");
			newSvrClearDAO.deleteEscortHelpSnapEntity();
			info.append("Batch delete t_escort_help_snap end.\t\n");

			info.append("Batch delete t_escort_snap start.\t\n");
			newSvrClearDAO.deleteEscortSnapEntity();
			info.append("Batch delete t_escort_snap end.\t\n");

			info.append("Batch delete t_hunter_info start.\t\n");
			newSvrClearDAO.deleteHunterEntity();
			info.append("Batch delete t_hunter_info end.\t\n");

			info.append("Batch delete t_relation_info start.\t\n");
			newSvrClearDAO.deleteRelationEntity();
			info.append("Batch delete t_relation_info end.\t\n");

			info.append("Batch delete t_secretary_info start.\t\n");
			newSvrClearDAO.deleteSecretaryEntity();
			info.append("Batch delete t_secretary_info end.\t\n");

			info.append("Batch delete t_sort_arenalevel start.\t\n");
			newSvrClearDAO.deleteSortArenaLevelEntity();
			info.append("Batch delete t_sort_arenalevel end.\t\n");

			info.append("Batch delete t_sort_companyIncomelevel start.\t\n");
			newSvrClearDAO.deleteSortCompanyIncomeLevelEntity();
			info.append("Batch delete t_sort_companyIncomelevel end.\t\n");

			info.append("Batch delete t_sort_honorlevel start.\t\n");
			newSvrClearDAO.deleteSortHonorLevelEntity();
			info.append("Batch delete t_sort_honorlevel end.\t\n");

			info.append("Batch delete t_temp_hunt_bag start.\t\n");
			newSvrClearDAO.deleteTempHuntBagEntity();
			info.append("Batch delete t_temp_hunt_bag end.\t\n");

			info.append("Batch delete t_time_notice start.\t\n");
			newSvrClearDAO.deleteTimeNotice();
			info.append("Batch delete t_time_notice end.\t\n");

			info.append("Batch delete t_transcation start.\t\n");
			newSvrClearDAO.deleteTranscationEntity();
			info.append("Batch delete t_transcation end.\t\n");

			info.append("Batch delete t_prize start.\t\n");
			newSvrClearDAO.deletePrize();
			info.append("Batch delete t_prize end.\t\n");

			info.append("Batch delete t_user_prize start.\t\n");
			newSvrClearDAO.deleteUserPrize();
			info.append("Batch delete t_user_prize end.\t\n");
			//TODO
			info.append("**********************Batch delete table end!**********************\t\n");
			LogUtil.logInfo(vitRecLog, info.toString());
			return true;
		} catch (Exception e) {
			vitRecLog.error(ErrorsUtil.error(this.getClass(), "canClear", e));
			e.printStackTrace();
		}
		return false;
	}

	/**
	 * 能否清服
	 *
	 * @return 角色个数大于10，则不能清服,返回false;反之返回真
	 */
	public boolean canClear() {
		try {
			String num = newSvrCheckDAO.getAutoIncrement();
			if (Long.valueOf(num) <= SystemConstants.ROLE_NUM) {
				return true;
			}
		} catch (Exception e) {
			vitRecLog.error(ErrorsUtil.error(this.getClass(), "canClear", e));
			e.printStackTrace();
		}
		return false;
	}

	/**
	 * World Server 是否是活动状态
	 * @return 活动返回true,反之返回false
	 */
	public boolean wsActive() {
		DBServer svr = LoginUserService.getDBServer();
		String result = cmdManageService.sendCmd("ws_status", svr, true).toString();
		if (result.indexOf("error") != -1) {
			return false;
		}
		return true;
	}

	/**
	 * @return
	 */
	public String addClearResult() {
		StringBuffer info= new StringBuffer();
		info.append("----------"+ExcelLangManagerService.readGmLang(GMLangConstants.NEWSVR_CLEAR)
		+ExcelLangManagerService.readGmLang(GMLangConstants.RESULT)
		+"----------\t\n");
		try {
			info.append("t_user_info:"+newSvrClearDAO.getRecordNum("t_user_info")+"\t\n");
			info.append("t_character_info:"+newSvrClearDAO.getRecordNum("t_character_info")+"\t\n");
			info.append("t_battle_info_snap:"+newSvrClearDAO.getRecordNum("t_battle_info_snap")+"\t\n");
			info.append("t_item_info:"+newSvrClearDAO.getRecordNum("t_item_info")+"\t\n");
//			info.append("t_pet_info:"+newSvrClearDAO.getRecordNum("t_pet_info")+"\t\n");
			info.append("t_scene_info:"+newSvrClearDAO.getRecordNum("t_scene_info")+"\t\n");
//			info.append("t_farm_info:"+newSvrClearDAO.getRecordNum("t_farm_info")+"\t\n");
//			info.append("t_shopmall_info:"+newSvrClearDAO.getRecordNum("t_shopmall_info")+"\t\n");
			info.append("t_silverore_info:"+newSvrClearDAO.getRecordNum("t_silverore_info")+"\t\n");
//			info.append("t_mission_enemy_info:"+newSvrClearDAO.getRecordNum("t_mission_enemy_info")+"\t\n");
			info.append("t_mail_info:"+newSvrClearDAO.getRecordNum("t_mail_info")+"\t\n");
			info.append("t_daily_task:"+newSvrClearDAO.getRecordNum("t_daily_task")+"\t\n");
//			info.append("t_festival_info:"+newSvrClearDAO.getRecordNum("t_festival_info")+"\t\n");
			info.append("t_doing_task:"+newSvrClearDAO.getRecordNum("t_doing_task")+"\t\n");
			info.append("t_finished_quest:"+newSvrClearDAO.getRecordNum("t_finished_quest")+"\t\n");
//			info.append("t_guild:"+newSvrClearDAO.getRecordNum("t_guild")+"\t\n");
//			info.append("t_guild_member:"+newSvrClearDAO.getRecordNum("t_guild_member")+"\t\n");
			info.append("t_prize:"+newSvrClearDAO.getRecordNum("t_prize")+"\t\n");
			info.append("t_user_prize:"+newSvrClearDAO.getRecordNum("t_user_prize")+"\t\n");
//			info.append("t_arena_log:"+newSvrClearDAO.getRecordNum("t_arena_log")+"\t\n");
//			info.append("t_arena_rank:"+newSvrClearDAO.getRecordNum("t_arena_rank")+"\t\n");
			info.append("t_arena_snap:"+newSvrClearDAO.getRecordNum("t_arena_snap")+"\t\n");
			//新加
			info.append("t_boss_info:"+newSvrClearDAO.getRecordNum("t_boss_info")+"\t\n");
			info.append("t_branch_info:"+newSvrClearDAO.getRecordNum("t_branch_info")+"\t\n");
			info.append("t_employee_info:"+newSvrClearDAO.getRecordNum("t_employee_info")+"\t\n");
			info.append("t_escort_help_snap:"+newSvrClearDAO.getRecordNum("t_escort_help_snap")+"\t\n");
			info.append("t_escort_snap:"+newSvrClearDAO.getRecordNum("t_escort_snap")+"\t\n");
			info.append("t_hunter_info:"+newSvrClearDAO.getRecordNum("t_hunter_info")+"\t\n");
			info.append("t_relation_info:"+newSvrClearDAO.getRecordNum("t_relation_info")+"\t\n");
			info.append("t_secretary_info:"+newSvrClearDAO.getRecordNum("t_secretary_info")+"\t\n");
			info.append("t_sort_arenalevel:"+newSvrClearDAO.getRecordNum("t_sort_arenalevel")+"\t\n");
			info.append("t_sort_companyIncomelevel:"+newSvrClearDAO.getRecordNum("t_sort_companyIncomelevel")+"\t\n");
			info.append("t_sort_honorlevel:"+newSvrClearDAO.getRecordNum("t_sort_honorlevel")+"\t\n");
			info.append("t_temp_hunt_bag:"+newSvrClearDAO.getRecordNum("t_temp_hunt_bag")+"\t\n");
			info.append("t_time_notice:"+newSvrClearDAO.getRecordNum("t_time_notice")+"\t\n");
			info.append("t_transcation:"+newSvrClearDAO.getRecordNum("t_transcation")+"\t\n");

			//TODO
		} catch (Exception e) {
			e.printStackTrace();
		}
		return info.toString();
	}

}
