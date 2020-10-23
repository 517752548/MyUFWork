package com.imop.lj.gm.service.check;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.check.NewSvrCheckDAO;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;

/**
 * 自检报告Service
 *
 * @author lin fan
 *
 */
public class NewSvrCheckService {

	private NewSvrCheckDAO newSvrCheckDAO;

	private DBFactoryService dbFactoryService;

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public NewSvrCheckDAO getNewSvrCheckDAO() {
		return newSvrCheckDAO;
	}

	public void setNewSvrCheckDAO(NewSvrCheckDAO newSvrCheckDAO) {
		this.newSvrCheckDAO = newSvrCheckDAO;
	}

	/**
	 * 得到玩家角色总数
	 *
	 * @return 角色总数
	 */
	public String getAutoIncrement() {
		return newSvrCheckDAO.getAutoIncrement();
	}

	/**
	 * 得到数据库版本号
	 *
	 * @return 数据库版本号
	 */
	public String getDBVersion(String id) {
		if("s1".equals(id)){
			ParamGenericDAO s1Dao = new ParamGenericDAO();
			s1Dao.setRId(LoginUserService.getLoginRegionId());
			s1Dao.setSId(dbFactoryService.getS1DbId(LoginUserService.getLoginRegionId()));
			s1Dao.setDbFactoryService(dbFactoryService);
			return s1Dao.getDBVersion();
		}else{
			return newSvrCheckDAO.getDBVersion();
		}

	}

	/**
	 * 得到定时公告数量
	 * @param id
	 * @return 定时公告数量
	 */
	public long getTimeNoticeNum(String id) {
		if("s1".equals(id)){
			ParamGenericDAO s1Dao = new ParamGenericDAO();
			s1Dao.setRId(LoginUserService.getLoginRegionId());
			s1Dao.setSId(dbFactoryService.getS1DbId(LoginUserService.getLoginRegionId()));
			s1Dao.setDbFactoryService(dbFactoryService);
			return s1Dao.getS1TimeNoticeNum();
		}else{
			return newSvrCheckDAO.getTimeNoticeNum();
		}
	}

	/**
	 * 得到游戏公告数量
	 * @param id
	 * @return 游戏公告数量
	 */
	public long getGameNoticeNum(String id) {
		if("s1".equals(id)){
			ParamGenericDAO s1Dao = new ParamGenericDAO();
			s1Dao.setRId(LoginUserService.getLoginRegionId());
			s1Dao.setSId(dbFactoryService.getS1DbId(LoginUserService.getLoginRegionId()));
			s1Dao.setDbFactoryService(dbFactoryService);
			return s1Dao.getS1GameNoticeNum();
		}else{
			return newSvrCheckDAO.getGameNoticeNum();
		}
	}

	/**
	 * 得到发奖礼包数量
	 * @param id
	 * @return 得到发奖礼包数量
	 */
	public long getPrizeNum(String id) {
		if("s1".equals(id)){
			ParamGenericDAO s1Dao = new ParamGenericDAO();
			s1Dao.setRId(LoginUserService.getLoginRegionId());
			s1Dao.setSId(dbFactoryService.getS1DbId(LoginUserService.getLoginRegionId()));
			s1Dao.setDbFactoryService(dbFactoryService);
			return s1Dao.getPrizeNum();
		}else{
			return newSvrCheckDAO.getPrizeNum();
		}
	}

	/**
	 * 得到游戏活动数量
	 * @param id
	 * @return 得到游戏活动数量
	 */
	public long getActNum(String id) {
		if("s1".equals(id)){
			ParamGenericDAO s1Dao = new ParamGenericDAO();
			s1Dao.setRId(LoginUserService.getLoginRegionId());
			s1Dao.setSId(dbFactoryService.getS1DbId(LoginUserService.getLoginRegionId()));
			s1Dao.setDbFactoryService(dbFactoryService);
			return s1Dao.getActNum();
		}else{
			return newSvrCheckDAO.getActNum();
		}
	}

}
