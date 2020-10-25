package com.imop.lj.gm.service;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.regex.Pattern;

import net.sf.json.JSONObject;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.UserInfo;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.UserInfoDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.ErrorsUtil;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.lj.gm.utils.LogUtil;

/**
 * 游戏玩家信息Service
 *
 * @author linfan
 *
 */
public class UserInfoService {

	private UserInfoDAO userInfoDAO;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	private DBFactoryService dbFactoryService;
	/** db log */
	private static final Logger logger = LoggerFactory.getLogger("db");

	/** vitRecLog log */
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public UserInfoDAO getUserInfoDAO() {
		return userInfoDAO;
	}

	public void setUserInfoDAO(UserInfoDAO userInfoDAO) {
		this.userInfoDAO = userInfoDAO;
	}

	/**
	 * 得到游戏玩家List
	 *
	 * @return 游戏玩家List
	 * @throws Exception
	 */
	public List<UserInfo> getUserInfoList() throws Exception {
		return userInfoDAO.getUserInfoList();
	}

	/**
	 * 根据条件查询UserInfo
	 *
	 * @param searchType
	 *            条件类型
	 * @param searchValue
	 *            条件值
	 * @param userStatus
	 * @param accountType
	 * @return UserInfoList
	 * @throws Exception
	 */
	public List<UserInfo> searchUserInfo(String searchType, String searchValue, String userStatus, String accountType)
			throws Exception {
		if (searchType != null) {
			searchType = searchType.trim();
		}
		if (searchValue != null) {
			searchValue = searchValue.trim();
		}
		return userInfoDAO.searchUserInfo(searchType, searchValue,userStatus,accountType);
	}

	/**
	 * 用户授权,并保存用户
	 * @param id 用户ID
	 * @param privilege 权限
	 * @param DBServer
	 * @param name 操作人
	 */
	public boolean savePlayer(String id, String privilege, DBServer svr,
			String name) {
		if (id == null || privilege == null) {
			return false;
		}
		UserInfo u = getUserInfo(id);
		if (u == null) {
			return false;
		}
		if (!SystemConstants.DB_TYPE.equals(LangUtils.getDBType())){
			return false;
		}
		try {
			kickOut(name, id, svr);
			u.setRole(Integer.valueOf(privilege));
			userInfoDAO.merge(u);
			LogUtil.logInfo(vitRecLog, "grant User[Id:"+u.getId()+",Name:"+u.getName()+",Privilege:"+privilege+"]");
		} catch (Exception e) {
			vitRecLog.error(ErrorsUtil.error(this.getClass(), "savePlayer", e));
		    e.printStackTrace();
		}
		return true;
	}

	/**
	 * 根据账号id踢人
	 *
	 * @param id
	 * @param svr
	 * @param id
	 * @return
	 */
	private boolean kickOut(String name, String id, DBServer svr) {
		JSONObject _o = new JSONObject();
		_o.put("pid", id);
		String cmd = "kickout " + _o.toString();
		String result = cmdManageService.sendCmd(cmd, svr,false).toString();
		if (result.indexOf("Sended") != -1) {
			LogUtil.logInfo(vitRecLog, "kickOut User[Id:"+id+"]");
			return true;
		}
		return false;

	}

	/**
	 * 根据玩家ID,得到玩家实体对象
	 *
	 * @param id
	 *            玩家ID
	 * @return 玩家实体对象
	 */
	public UserInfo getUserInfo(String id) {
		UserInfo u = null;
		if (StringUtils.isNotBlank(id)) {
			u = userInfoDAO.getById(UserInfo.class, id);
		}
		return u;
	}

	/**
	 * 加锁用户
	 * @param id 账号id
	 * @param lockReason 锁号原因
	 * @param name 操作人
	 * @param svr  DBServer
	 * @return 操作成功返回true,反之返回false
	 */
	public boolean lockUser(String id, String lockReason, DBServer svr,
			String name) {
		if (id == null) {
			return false;
		}
		UserInfo u = getUserInfo(id);
		if (u == null) {
			return false;
		}
		if (!SystemConstants.DB_TYPE.equals(LangUtils.getDBType())){
			return false;
		}
		kickOut(name, id, svr);
		u.setLockStatus(1);
		String prop = u.getProps();
		JSONObject jo = null;
		JSONObject lock = null;
		if(StringUtils.isBlank(prop)){
			prop= null;
		}
		try {
			jo = JSONObject.fromObject(prop);
		} catch (Exception e) {
			logger.error("database : the form of prop is not correct!");
			jo = new JSONObject();
		}
		if (jo.isNullObject()) {
			jo = new JSONObject();
		}
		lock = new JSONObject();
		lock.put("reason", lockReason);
		jo.put("lock", lock);
		u.setProps(jo.toString());
		userInfoDAO.merge(u);
		String info =
			ExcelLangManagerService.readGmLang(GMLangConstants.LOCK)+ExcelLangManagerService.readGmLang(GMLangConstants.USER)
			+":"+u.getName();
		LogUtil.logInfo(vitRecLog, info);
		return true;
	}

	/**
	 * 得到锁号原因
	 * @param prop  账号属性
	 * @return 锁号原因
	 */
	public String getLockReason(String prop) {
		String reason = "";
		JSONObject jo = null;
		JSONObject lock = null;
		jo = JSONObject.fromObject(prop);
		if (!jo.isNullObject()) {
			lock=JSONObject.fromObject(jo.getString("lock"));
			if (!lock.isNullObject()){
				reason = lock.getString("reason");
			}
		}
		return reason;

	}

	/**
	 * 解锁用户
	 * @param id 账号id
	 * @param svr DBServer
	 * @param username 操作人
	 * @return	操作成功返回true,反之返回false
	 */
	public boolean unlockUser(String id, DBServer svr, String username) {
		if (id == null) {
			return false;
		}
		UserInfo u = getUserInfo(id);
		if (u == null) {
			return false;
		}
		if (!SystemConstants.DB_TYPE.equals(LangUtils.getDBType())){
			return false;
		}
		u.setLockStatus(0);
		String prop = u.getProps();
		JSONObject jo = null;
		JSONObject lock = null;
		jo = JSONObject.fromObject(prop);
		if (jo.isNullObject()) {
			jo = new JSONObject();
		}
		lock = new JSONObject();
		lock.put("reason", "");
		jo.put("lock", lock);
		u.setProps(jo.toString());
		userInfoDAO.merge(u);
		String info =ExcelLangManagerService.readGmLang(GMLangConstants.UNLOCK)+ExcelLangManagerService.readGmLang(GMLangConstants.USER)
			+":"+u.getName();
		LogUtil.logInfo(vitRecLog, info);
		return true;
	}

	/**
	 * 批量锁号功能
	 * @param userIds
	 * @param string
	 * @param svr
	 * @param lockReason
	 * @return
	 */
	public boolean batchLockUsers(String userIds, String lockReason, DBServer svr, String name) {
		if (StringUtils.isBlank(userIds)) {
			return false;
		}
		userIds = userIds.replace("[", "").replace("]", "").trim();
		boolean b =Pattern.matches("^([0-9||,]+)$",userIds) ;
		if(!b){
			return false;
		}
		String [] ids = userIds.replace("[", "").split(",");
		for(int i=0;i<ids.length;i++){
			String id = ids[i];
			lockUser(id, lockReason, svr, name);
		}
		return true;
	}

	/**
	 * 批量解锁功能
	 * @param userIds
	 * @param svr
	 * @param username
	 * @return
	 */
	public boolean unBatchlockUser(String userIds, DBServer svr, String username) {
		if (StringUtils.isBlank(userIds)) {
			return false;
		}
		userIds = userIds.replace("[", "").replace("]", "").trim();
		boolean b =Pattern.matches("^([0-9||,]+)$",userIds) ;
		if(!b){
			return false;
		}
		String [] ids = userIds.replace("[", "").split(",");
		for(int i=0;i<ids.length;i++){
			String id = ids[i];
			unlockUser(id, svr, username);
		}
		return true;
	}

	/**
	 * 多次搜索
	 *
	 * @param ids
	 * @param type
	 * @return
	 */
	public String batchSearch(String ids, String type, String regionId) {
		ids = ids.replace("\r\n", ",").trim();
		boolean b = Pattern.matches("^([0-9||,]+)$", ids);
		if (!b) {
			return ExcelLangManagerService.readGmLang(GMLangConstants.CONTENT_ERR);
		}
		String[] _ids = ids.split(",");
		if (_ids.length > 20) {
			return ExcelLangManagerService.readGmLang(GMLangConstants.SEARCH_NUM_LIMIT);
		}
		StringBuffer _result = new StringBuffer();
		for (String _id : _ids) {
			if (StringUtils.isEmpty(_id)) {
				return ExcelLangManagerService.readGmLang(GMLangConstants.CONTENT_ERR);
			}
			//全区搜索 XXX 默认都是region 1
			if (type.equals("3")) {
				boolean isThisRegion = false;
				List<DBServer> _servers = dbFactoryService.getServerList(regionId);
				for (DBServer _server : _servers) {
					ParamGenericDAO _genericDAO = new ParamGenericDAO();
					_genericDAO.setRId(regionId);
					_genericDAO.setSId(_server.getId());
					_genericDAO.setDbFactoryService(dbFactoryService);
					if (_genericDAO.isExistPassportId(_id)) {
						isThisRegion = true;
						_result.append(_server.getDbServerName()).append(",");
					}
				}
				if (!isThisRegion) {
					_result.append(ExcelLangManagerService.readGmLang(GMLangConstants.WHOLE_SEARCH_NO_RESULT));
				}
				_result.append("\n");
			} else {
				try {
					UserInfo _info = userInfoDAO.getUserInfo(Long.parseLong(_id.trim()));
					if (_info == null) {
						return ExcelLangManagerService.readGmLang(GMLangConstants.ID_ERR) + ":" + _id;
					}
					if (type.equals("1")) {
						_result.append(_id + "\t" + _info.getLastLoginTime() + "\n");
					} else if (type.equals("2")) {
						_result.append(_id + "\t" + _info.getLastLoginIp() + "\n");
					}
				} catch (NumberFormatException e) {
					e.printStackTrace();
					return ExcelLangManagerService.readGmLang(GMLangConstants.ID_ERR) + ":" + _id;
				} catch (Exception e) {
					e.printStackTrace();
					return ExcelLangManagerService.readGmLang(GMLangConstants.ID_ERR) + ":" + _id;
				}
			}
		}
		return _result.toString();
	}
	/**
	 * 禁言操作
	 */
	public boolean foribdTalkDo(String id,String forbidedate,String forbidetime,DBServer svr){
		long passId =0;
		if(id==null || "".equals(id)){
			logger.info("UserInfoService foribdTalkDo id is null");
			return false;
		}else{
			passId = Long.parseLong(id);
		}
		if(passId == 0){
			logger.info("UserInfoService foribdTalkDo id is 0");
			return false;
		}
		if("".equals(forbidedate)){
			logger.info("UserInfoService foribdTalkDo forbidedate is null");
			return false;

		}
		if("".equals(forbidetime)){
			logger.info("UserInfoService foribdTalkDo forbidetime is null");
			return false;

		}
//		String sDt = "08/31/2006 21:08:00";
		//2012-06-15
		//16:42:16
		String[] str = forbidedate.split("-");
		String foribDataStr = str[1]+"/"+str[2]+"/"+str[0]+" "+forbidetime;
		SimpleDateFormat sdf= new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
		Date foribeDataTime;
		try {
			foribeDataTime = sdf.parse(foribDataStr);
			//继续转换得到秒数的long型
			long foribeDataTimeLong = foribeDataTime.getTime();
			String updateStr = "update UserInfo u set u.foribedTalkTime="+foribeDataTimeLong+" where id ="+passId;
			userInfoDAO.updateByHQL(updateStr);

			//创建cmd
			String cmd = "foribeTalk";
			//0禁言1取消 int
			cmd += " foribedType="+0;
			cmd += " passId="+passId;
			cmd += " foribeDataTimeLong="+foribeDataTimeLong;

			List<String> result = cmdManageService.sendCmd(cmd, svr, false);
			if (!"[ok]".equals(result.toString())) {
				return false;
			}
			LoginUser loginUser = LoginUserService.getLoginUser();
			String info = "success:\t" + ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN) + ":"
					+ loginUser.getUsername() + "\t" + ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)
					+ ":" + loginUser.getLoginRegionId() + "\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER) + ":"
					+ loginUser.getLoginServerId() + "\t" + "foribedTalk (passportid:" + passId + ",foribeDataTimeLong:"+ foribeDataTimeLong;
			logger.info(info);
			return true;
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			logger.info("Date foribeDataTime ParseException");
			e.printStackTrace();
		}
		return false;
	}
	/*
	 * 取消禁言操作
	 */
	public boolean cancleForibdTalkDo(String id,DBServer svr){
		long passId =0;
		if(id==null || "".equals(id)){
			logger.info("UserInfoService foribdTalkDo id is null");
			return false;
		}else{
			passId = Long.parseLong(id);
		}
		if(passId == 0){
			logger.info("UserInfoService foribdTalkDo id is 0");
			return false;
		}
		long foribeDataTimeLong = 0l;
		try {
			String updateStr = "update UserInfo u set u.foribedTalkTime="+foribeDataTimeLong+" where id ="+passId;
			userInfoDAO.updateByHQL(updateStr);

			//创建cmd
			String cmd = "foribeTalk";
			//0禁言1取消 int
			cmd += " foribedType="+1;
			cmd += " passId="+passId;
			cmd += " foribeDataTimeLong="+foribeDataTimeLong;

			List<String> result = cmdManageService.sendCmd(cmd, svr, false);
			if (!"[ok]".equals(result.toString())) {
				return false;
			}
			LoginUser loginUser = LoginUserService.getLoginUser();
			String info = "success:\t" + ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN) + ":"
					+ loginUser.getUsername() + "\t" + ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)
					+ ":" + loginUser.getLoginRegionId() + "\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER) + ":"
					+ loginUser.getLoginServerId() + "\t" + "foribedTalk (passportid:" + passId + ",foribeDataTimeLong:"+ foribeDataTimeLong;
			logger.info(info);
			return true;
		} catch (Exception e) {
			// TODO Auto-generated catch block
			logger.info("Date foribeDataTime Exception");
			e.printStackTrace();
		}
		return false;
	}
	
	/**
	 * 禁言操作
	 */
	public boolean foribdTalkDoByCrm(String id,long foribeDataTimeLong,DBServer svr){
		long passId =0;
		if(id==null || "".equals(id)){
			logger.info("UserInfoService foribdTalkDo id is null");
			return false;
		}else{
			passId = Long.parseLong(id);
		}
		if(passId == 0){
			logger.info("UserInfoService foribdTalkDo id is 0");
			return false;
		}
		//继续转换得到秒数的long型
		String updateStr = "update UserInfo u set u.foribedTalkTime="+foribeDataTimeLong+" where id ="+passId;
		
		ParamGenericDAO s1Dao = new ParamGenericDAO();
		s1Dao.setRId(svr.getRegionId());
		s1Dao.setSId(svr.getId());
		s1Dao.setDbFactoryService(dbFactoryService);
		
		
		s1Dao.updateByHQL(updateStr);
		
		//创建cmd
		String cmd = "foribeTalk";
		//0禁言1取消 int
		cmd += " foribedType="+0;
		cmd += " passId="+passId;
		cmd += " foribeDataTimeLong="+foribeDataTimeLong;
		
		List<String> result = cmdManageService.sendCmd(cmd, svr, false);
		if (!"[ok]".equals(result.toString())) {
			return false; 
		}
		return true;
	}
	
	/*
	 * 取消禁言操作
	 */
	public boolean cancleForibdTalkDoByCrm(String id,DBServer svr){
		long passId =0;
		if(id==null || "".equals(id)){
			logger.info("UserInfoService foribdTalkDo id is null");
			return false;
		}else{
			passId = Long.parseLong(id);
		}
		if(passId == 0){
			logger.info("UserInfoService foribdTalkDo id is 0");
			return false;
		}
		long foribeDataTimeLong = 0l;
		try {
			String updateStr = "update UserInfo u set u.foribedTalkTime="+foribeDataTimeLong+" where id ="+passId;
			
			ParamGenericDAO s1Dao = new ParamGenericDAO();
			s1Dao.setRId(svr.getRegionId());
			s1Dao.setSId(svr.getId());
			s1Dao.setDbFactoryService(dbFactoryService);
			
			//创建cmd
			String cmd = "foribeTalk";
			//0禁言1取消 int
			cmd += " foribedType="+1;
			cmd += " passId="+passId;
			cmd += " foribeDataTimeLong="+foribeDataTimeLong;
			
			List<String> result = cmdManageService.sendCmd(cmd, svr, false);
			if (!"[ok]".equals(result.toString())) {
				return false;
			}
			return true;
		} catch (Exception e) {
			// TODO Auto-generated catch block
			logger.info("Date foribeDataTime Exception");
			e.printStackTrace();
		}
		return false;
	}
	
	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}
}
