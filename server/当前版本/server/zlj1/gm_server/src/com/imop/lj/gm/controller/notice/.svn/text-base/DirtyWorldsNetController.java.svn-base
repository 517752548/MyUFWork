package com.imop.lj.gm.controller.notice;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.slf4j.Logger;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.notice.DirtyWorldsTypeService;
import com.imop.lj.gm.service.notice.data.DirtyWorldsNetshow;
import com.imop.lj.gm.service.notice.data.MobileActivityGroupsName;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.lj.gm.web.activity.service.GMGlobals;
import com.imop.lj.gm.web.activity.web.ActivityCheckBoxData;
//import com.imop.lj.gm.web.activity.web.ActivtiyWebService;

public class DirtyWorldsNetController extends MultiActionController{
	private Logger logger = GMGlobals.logger;
	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;
	private DirtyWorldsTypeService dirtyWorldsTypeService;
//	private ActivtiyWebService ActivtiyWebService;
	
	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}
	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}
	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}
	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}
	public SysUserService getSysUserService() {
		return sysUserService;
	}
	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}
	public DirtyWorldsTypeService getDirtyWorldsTypeService() {
		return dirtyWorldsTypeService;
	}
	public void setDirtyWorldsTypeService(
			DirtyWorldsTypeService dirtyWorldsTypeService) {
		this.dirtyWorldsTypeService = dirtyWorldsTypeService;
	}
//	public ActivtiyWebService getActivtiyWebService() {
//		return ActivtiyWebService;
//	}
//	public void setActivtiyWebService(ActivtiyWebService activtiyWebService) {
//		ActivtiyWebService = activtiyWebService;
//	}

	//初始化页面
	private String dirtyWorldsNetInitView;
	private String dirtyWorldsNetEditView;
	private String refrushdirtyWorldsNetView;
	public String getDirtyWorldsNetInitView() {
		return dirtyWorldsNetInitView;
	}
	public void setDirtyWorldsNetInitView(String dirtyWorldsNetInitView) {
		this.dirtyWorldsNetInitView = dirtyWorldsNetInitView;
	}
	public String getDirtyWorldsNetEditView() {
		return dirtyWorldsNetEditView;
	}
	public void setDirtyWorldsNetEditView(String dirtyWorldsNetEditView) {
		this.dirtyWorldsNetEditView = dirtyWorldsNetEditView;
	}
	public String getRefrushdirtyWorldsNetView() {
		return refrushdirtyWorldsNetView;
	}
	public void setRefrushdirtyWorldsNetView(String refrushdirtyWorldsNetView) {
		this.refrushdirtyWorldsNetView = refrushdirtyWorldsNetView;
	}
	/** 初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {

		ModelAndView mav = new ModelAndView(this.getDirtyWorldsNetInitView());
		DirtyWorldsNetshow data= this.getDirtyWorldsTypeService().getMobileActivityEntityList();
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),u.getLoginServerId());
		
		List<DBServer> serverIds=new ArrayList<DBServer>();
		serverIds.add(svr);
		mav.addObject("serverIds", serverIds);
		mav.addObject("dirtyWorldsType", data);
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}
	
	/***
	 * 复制页面
	 */
	public ModelAndView editView(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getDirtyWorldsNetEditView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		
		String activityId = request.getParameter("Id").trim();

		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		mav.addObject("loginUser", session.getAttribute("u"));

		List<DBServer> serverIds =new ArrayList<DBServer>();
		serverIds.add(svr);
		mav.addObject("serverIds", serverIds);
		DirtyWorldsNetshow data= this.getDirtyWorldsTypeService().getMobileActivityEntityList();
		if(data == null){
			return init(request,response);
		}
		
		mav.addObject("dirtyWorldsType", data);
		
		List<MobileActivityGroupsName> list = this.getDirtyWorldsTypeService().getMobileActivityGrops();
		mav.addObject("mobileActivityGroupsNameList", list);
		
		SysUser s = sysUserService.getUserByName(u.getUsername(),u.getLoginRegionId());
		List<DBServer> listSer = DBFactoryService.getServers(s.getServerIds(), u.getLoginRegionId());
		List<ActivityCheckBoxData> checkBox = getActivityCheckBoxDataList(listSer,"", u.getLoginRegionId());
		mav.addObject("checkBox", checkBox);

		mav.addObject("DBType", LangUtils.getDBType());
		
		//
		mav.addObject("currentSerName", svr.getDbServerName());
		mav.addObject("currentSerId", svr.getId());
		return mav;
	}
	
	/***
	 * 编辑页面
	 */
	public ModelAndView editDo(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String dirtyWorldsType = request.getParameter("activityType").trim();
		String ids[] = request.getParameterValues("sId");
		
		String serverIdss = idsToIdsStr(ids);
		
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		
		String str =  this.getDirtyWorldsTypeService().copyMobileActivity(svr,serverIdss,dirtyWorldsType,u.getLoginRegionId());
		
		return init(request,response);
	}
	
	/***
	 * 刷新页面
	 */
	public ModelAndView refrushView(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getRefrushdirtyWorldsNetView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		
		String activityId = request.getParameter("Id").trim();

		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		mav.addObject("loginUser", session.getAttribute("u"));

		List<DBServer> serverIds =new ArrayList<DBServer>();
		serverIds.add(svr);
		mav.addObject("serverIds", serverIds);
		DirtyWorldsNetshow data= this.getDirtyWorldsTypeService().getMobileActivityEntityList();
		if(data == null){
			return init(request,response);
		}
		
		mav.addObject("dirtyWorldsType", data);
		
		List<MobileActivityGroupsName> list = this.getDirtyWorldsTypeService().getMobileActivityGrops();
		mav.addObject("mobileActivityGroupsNameList", list);
		
		SysUser s = sysUserService.getUserByName(u.getUsername(),u.getLoginRegionId());
		List<DBServer> listSer = DBFactoryService.getServers(s.getServerIds(), u.getLoginRegionId());
		List<ActivityCheckBoxData> checkBox = getActivityCheckBoxDataList(listSer,"",u.getLoginRegionId());
		mav.addObject("checkBox", checkBox);

		mav.addObject("DBType", LangUtils.getDBType());
		
		//
		mav.addObject("currentSerName", svr.getDbServerName());
		mav.addObject("currentSerId", svr.getId());
		return mav;
	}
	
	/***
	 * 刷新页面
	 */
	public ModelAndView refrushDo(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String ids[] = request.getParameterValues("sId");
		
		String serverIdss = idsToIdsStr(ids);
		
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		
		String str =  this.getDirtyWorldsTypeService().refrashMobileActivity(svr,serverIdss,u.getLoginRegionId());
		
		return init(request,response);
	}
	
	/**
	 * ids[] toString
	 */
	public String idsToIdsStr(String ids[]){
		String str = "";
		
		if(ids==null){
			return str;
		}
		
		if(ids.length<=0){
			return str;
		}
		if(ids.length>=1){
			str = str+ids[0];
		}
		
		for(int i=1;i<ids.length;i++){
			str = str+","+ids[i];
		}
		
		return str;
	}
	
	public List<ActivityCheckBoxData> getActivityCheckBoxDataList(List<DBServer> _servers,String serverIds, String regionId){
		List<ActivityCheckBoxData> list = new ArrayList<ActivityCheckBoxData>();
		
		List<DBServer> listSelect = DBFactoryService.getServers(serverIds, regionId);
		//过滤World
		_servers = getListDBServer(_servers);
		
		for(DBServer dBServer :_servers){
			ActivityCheckBoxData activityCheckBoxData = new ActivityCheckBoxData();
			activityCheckBoxData.setServerId(dBServer.getId());
			activityCheckBoxData.setServerName(dBServer.getDbServerName());
			if(listSelect.contains(dBServer)){
				activityCheckBoxData.setSelectecd(1);
			}else{
				activityCheckBoxData.setSelectecd(0);
			}
			list.add(activityCheckBoxData);
		}
		return list;
	}
	
	public List<DBServer> getListDBServer(List<DBServer> list){	
		List<DBServer> temp = new ArrayList<DBServer>();
		for(DBServer dbserver:list){
			if(isWorldServer(dbserver)){
				temp.add(dbserver);
			}
		}
		
		list.removeAll(temp);
		return list;
	}
	
	//world  服判断
	public boolean isWorldServer(DBServer svr){
		int id = Integer.parseInt(svr.getServerId());
		List<Integer> serverIdList = GmConfig.getGmConfigInstance().getWorldServerIdList();
		if(serverIdList.contains(id)){
			return true;
		}
		return false;
	}
}
