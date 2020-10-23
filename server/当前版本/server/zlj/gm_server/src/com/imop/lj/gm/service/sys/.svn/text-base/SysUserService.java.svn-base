package com.imop.lj.gm.service.sys;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dao.sys.SysUserDAO;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.lj.gm.utils.Md5PasswordEncoder;

/**
 * 管理GM平台的系统用户Service
 *
 *
 */
public class SysUserService {

	/** 系统用户DAO */
	private SysUserDAO sysUserDAO;

	/** 数据库工厂 */
	private DBFactoryService dbFactoryService;

	/** db log */
	private static final Logger logger = LoggerFactory.getLogger("db");

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public SysUserDAO getSysUserDAO() {
		return sysUserDAO;
	}

	public void setSysUserDAO(SysUserDAO sysUserDAO) {
		this.sysUserDAO = sysUserDAO;
	}

	/**
	 * 根据用户名和密码,返回用户
	 *
	 * @param u
	 *            用户名
	 * @param p
	 *            密码
	 * @return 系统用户
	 * @throws Exception
	 */
	public SysUser getUserByName(String u, String regionId) {
		return dbFactoryService.getUserByName(u, regionId);
	}

	/**
	 * 根据用户名和密码及大区Id,返回用户
	 *
	 * @param u
	 *            用户名
	 * @param p
	 *            密码
	 * @param regionId
	 * 			     大区ID
	 * @return 系统用户
	 * @throws Exception
	 */
	public SysUser validateUser(String u, String p, String regionId) throws Exception {
		List<SysUser> sysUserList = dbFactoryService.getGMDAO().getSysUserNoRegion(u);
		if (sysUserList != null && !sysUserList.isEmpty()) {
			for (SysUser sysUser : sysUserList) {
				if (sysUser.getRegionId() == null) {
					continue;
				}
				// 玩家是该大区的或是全部大区的
				if (regionId.equalsIgnoreCase(sysUser.getRegionId()) || 
						sysUser.getRegionId().equalsIgnoreCase(SystemConstants.ALL_REGION_PRIVILEGE)) {
					if (validSysUser(sysUser, p)) {
						return sysUser;
					}
				}
			}
		}
		return null;
	}

	/**
	 * 验证密码
	 *
	 * @param sysUser
	 * @param password
	 * @return 正确返回true,错误返回false
	 */
	private boolean validSysUser(SysUser sysUser, String password) {
		String ps_encoded = Md5PasswordEncoder.encoderByMd5(password);
		if (ps_encoded.equals(sysUser.getPassword())) {// 测试时,没有加密密码
			return true;
		} else {
			return false;
		}

	}


	/**
	 * 删除系统用户
	 *
	 * @param id
	 */
	public boolean delSysUser(String id) {
		SysUser s = sysUserDAO.getById(SysUser.class, Integer.valueOf(id));
		LoginUser loginUser = LoginUserService.getLoginUser();
		if (sysUserDAO.delete(s)) {
			String info = "success:\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)+":"+loginUser.getUsername()+"\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+loginUser.getLoginRegionId()+"\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+loginUser.getLoginServerId()+"\t"+
				ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_DELETE)+ExcelLangManagerService.readGmLang(GMLangConstants.USER)
				+":"+s.getUsername()+"\t Date:"+(DateUtil.formatDateHour(new Date()));
			logger.info(info);
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 保存系统用户
	 *
	 * @param sysUserName
	 * @param password
	 * @param right
	 * @param serverId
	 */
	public boolean addSysUser(String sysUserName, String password,
			String right, String regionId) {
		SysUser u = new SysUser();
		u.setUsername(sysUserName);
		u.setPassword(Md5PasswordEncoder.encoderByMd5(password));
		u.setRole(right);
		u.setServerIds("");//服务器字段不用设置
		u.setLastLogonDate(new Date());
		u.setRegionId(regionId);
		LoginUser loginUser = LoginUserService.getLoginUser();
		if (sysUserDAO.save(u) != null) {
			String info = "success:\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)+":"+loginUser.getUsername()+"\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+loginUser.getLoginRegionId()+"\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+loginUser.getLoginServerId()+"\t"
				+"add SysUser(Name:"+u.getUsername()+",Password:"+password+",Role:"+right+",Date:"+DateUtil.formatDateHour(u.getLastLogonDate())+")";
			logger.info(info);
			return true;
		} else {
			return false;
		}

	}

	/**
	 * 判断用户是否是已经存在
	 *
	 * @param sysUserName
	 * @throws Exception
	 */
	public boolean isExist(String sysUserName, String regionId) {
		if (getUserByName(sysUserName, regionId) != null) {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 搜索系统用户
	 * @param searchType 搜索类型
	 * @param searchValue 搜索值
	 * @return
	 */
	public List<SysUser> searchSysUser(String searchType, String searchValue) {
		if (searchType != null) {
			searchType = searchType.trim();
		}
		if (searchValue != null) {
			searchValue = searchValue.trim();
		}
		List<SysUser> sysUserList = new ArrayList<SysUser>();
		if (null != sysUserDAO.getSysUserList(searchType, searchValue)) {
			for (SysUser sysUser : sysUserDAO.getSysUserList(searchType, searchValue)) {
				// 过滤无效数据
				if (sysUser.getRegionId() == null || 
						sysUser.getRegionId().equalsIgnoreCase("")) {
					continue;
				}
				sysUserList.add(sysUser);
			}
		}
		return sysUserList; 
	}

	/**
	 * 根据ID 找到系统用户
	 * @param id 用户id
	 * @return 系统用户
	 */
	public SysUser loadSysUser(String id) {
		if (id == null) {
			return null;
		}
		return dbFactoryService.getGMDAO().getById(SysUser.class, Integer.valueOf(id));
	}

	/**
	 * 编辑授权给用户
	 * @param id
	 * @param right
	 * @param serverId
	 * @return
	 */
	public boolean editSaveSysUser(String id, String right, String regionId) {
		SysUser u = loadSysUser(id);
		if(u==null){
			return false;
		}
		u.setRole(right);
		String s = "";
//		for (int i = 0; i < serverId.length - 1; i++) {
//			s = s + serverId[i] + ",";
//		}
//		s = s + serverId[serverId.length - 1];
//		u.setServerIds(s);
		// 如果修改为默认值0，则不作修改
		if (!regionId.equalsIgnoreCase(SystemConstants.GM_REGION)) {
			u.setRegionId(regionId);
		}
		
		LoginUser loginUser = LoginUserService.getLoginUser();
		if (sysUserDAO.merge(u) != null) {
			String info = "success:\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)+":"+loginUser.getUsername()+"\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+loginUser.getLoginRegionId()+"\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+loginUser.getLoginServerId()+"\t"+
				"grant SysUser(Name:"+u.getUsername()+",Role:"+right+",ServerIds:"+s+",Date:"+DateUtil.formatDateHour(u.getLastLogonDate())+")";
			logger.info(info);
			return true;
		} else {
			return false;
		}
	}
	
	/**
	 * 登录时更新用户，主要是增加所有服的权限用
	 * @param u
	 */
	public void updateSysUserOnLogin(SysUser u) {
		try {
			dbFactoryService.getGMDAO().saveOrUpdate(u);
		} catch (Exception e) {
			e.printStackTrace();
			logger.error("updateSysUserOnLogin failed!");
		}
	}

	/**
	 * 保存密码
	 * @param password
	 * @param id2
	 * @return
	 */
	public String savePassword(String oldPassword,String newPassword, String id) {
		SysUser u = loadSysUser(id);
		if(u==null){
			return "notOk";
		}
		if(!u.getPassword().equals(Md5PasswordEncoder.encoderByMd5(oldPassword))){
			return "psError";
		}
		u.setPassword(Md5PasswordEncoder.encoderByMd5(newPassword));
		LoginUser loginUser = LoginUserService.getLoginUser();
		if (sysUserDAO.merge(u) != null) {
			String info = "success:\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)+":"+loginUser.getUsername()+"\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+loginUser.getLoginRegionId()+"\t"
				+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+loginUser.getLoginServerId()+"\t"+
				"edit SysUser(Name:"+u.getUsername()+",newPassword:"+newPassword+",Date:"+DateUtil.formatDateHour(u.getLastLogonDate())+")";
				logger.info(info);
			return "ok";
		} else {
			return "notOk";
		}
	}
}
