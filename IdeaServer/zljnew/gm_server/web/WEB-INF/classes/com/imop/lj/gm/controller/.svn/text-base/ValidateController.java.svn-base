package com.imop.lj.gm.controller;

import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.db.PrivilegeService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.utils.LangUtils;


/**
 * 校验登录GM平台的用户
 * @author linfan
 *@author kai.shi
 */
public class ValidateController extends MultiActionController {

	/** 用户登录页面 */
	private String loginView;

	/** index */
	private String indexView;

	/** 首页 */
	private String homePageView;

	/** 系统管理员Service */
	private SysUserService sysUserService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;
	public TemplateService  gmTemplateService;
	public String getIndexView() {
		return indexView;
	}

	public void setIndexView(String indexView) {
		this.indexView = indexView;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public String getHomePageView() {
		return homePageView;
	}

	public void setHomePageView(String homePageView) {
		this.homePageView = homePageView;
	}

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	public String getLoginView() {
		return loginView;
	}

	public void setLoginView(String loginView) {
		this.loginView = loginView;
	}

	/**
     * 验证用户登录信息
     * @param request
     * @param response
     * @return 用户信息正确,返回GM平台管理主页面,反之返回到登录页面
     * @throws Exception
     */
	public ModelAndView index(HttpServletRequest request,
			HttpServletResponse response){
		ModelAndView mav = new ModelAndView(getIndexView());
		String  regionID= request.getParameter("regionID");	
		
		if(StringUtils.isBlank(regionID)){
			return mav;
		}else{
			mav = new ModelAndView(getLoginView());
			regionID = regionID.trim();
		}
		Map<String, String> regions = DBFactoryService.getRegionMap();
		List<DBServer> dbServerList = null;
		if(("undefined").equals(regionID)){
			if(!regions.isEmpty()){
				regionID = regions.keySet().iterator().next();
				dbServerList = dbFactoryService.getServerList(regionID);
			}

		}else{
			dbServerList = dbFactoryService.getServerList(regionID);
		}

		mav.addObject("regions", regions);
		mav.addObject("regionID", regionID);
		mav.addObject("dbServerList", dbServerList);
		return mav;

	}
	//初始化template
	private void initTemplate()
	{
//		String templateDir="D:\\makemoney\\ios\\game_server\\config\\templates.xml";
//		gmTemplateService = new TemplateService(GmConfig.baseResourceDir+File.separator+GmConfig.scriptDir,false);
//		gmTemplateService.init(ConfigUtil.getConfigURL(templateDir));

	}

	public ModelAndView validateUser(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav =  new ModelAndView(getIndexView());;
		String u = request.getParameter("username");
		String p = request.getParameter("password");
		String loginServerId = request.getParameter("server_id");
		String loginRegionId = request.getParameter("region_id");
		if((u==null)||(p==null)||(loginServerId==null)||(loginRegionId==null)){
		}else{
			LoginUser loginUser= new LoginUser();
		    loginUser.setLoginServerId(loginServerId);
		    loginUser.setLoginRegionId(loginRegionId);
			LoginUserService.pushUser(loginUser);
			
			// 玩家有所有服的权限，即不区分服务器
			SysUser s = sysUserService.validateUser(u,p,loginRegionId);
			if (s != null) {
				List<DBServer> dbServerList = dbFactoryService.getServerList(loginRegionId);
				if (dbServerList != null && !dbServerList.isEmpty()) {
					String serverStr = "";
					for (DBServer server : dbServerList) {
						serverStr += server.getId() + ",";
					}
					s.setServerIds(serverStr.substring(0, serverStr.length() - 1));
					sysUserService.updateSysUserOnLogin(s);
				}
			}
			
			if (s != null) {
				if(s.getServerIds().contains(loginServerId)){
					HttpSession session = request.getSession();
					loginUser.setId(String.valueOf(s.getId()));
					loginUser.setUsername(u);
					loginUser.setPassword(p);
					loginUser.setLoginRegionId(loginRegionId);
					loginUser.setLoginServerId(loginServerId);
					loginUser.setRole(s.getRole());
					loginUser.setServerIds(s.getServerIds());
					loginUser.setLastLogonDate(s.getLastLogonDate());
					session.setAttribute("roleMap", PrivilegeService.getRoleMap());
					session.setAttribute("loginUser", loginUser);
					session.setAttribute("language", LangUtils.getLanguage());
					session.setAttribute("regionId", loginRegionId);
					mav = new ModelAndView(getHomePageView());
					initTemplate();
					session.setAttribute("gmTemplateService",gmTemplateService);

				}else{
					mav.addObject("noRight", true);
				}
			}else{
				mav.addObject("noUser", true);
			}
			LoginUserService.popUser();
		}
		return mav;
	}
}
