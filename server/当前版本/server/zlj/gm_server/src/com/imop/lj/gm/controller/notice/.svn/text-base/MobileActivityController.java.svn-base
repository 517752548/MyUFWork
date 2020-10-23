package com.imop.lj.gm.controller.notice;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.slf4j.Logger;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.notice.MobileActivityGmService;
import com.imop.lj.gm.service.notice.data.MobileActivityGroupsName;
import com.imop.lj.gm.service.notice.data.MobileActivityShowData;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsSecretaryLoadService;
import com.imop.lj.gm.utils.LangUtils;
//import com.imop.lj.gm.web.activity.data.prize.GmActivityPrizeIface;
import com.imop.lj.gm.web.activity.service.GMGlobals;
import com.imop.lj.gm.web.activity.service.Iface.ActivityCheckEnum;
import com.imop.lj.gm.web.activity.web.ActivityCheckBoxData;
//import com.imop.lj.gm.web.activity.web.ActivtiyWebService;

public class MobileActivityController extends MultiActionController{
	private Logger logger = GMGlobals.logger;
	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;
	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;
	private MobileActivityGmService mobileActivityGmService;
	private XlsSecretaryLoadService xlsSecretaryLoadService;
//	private ActivtiyWebService activtiyWebService;
//	public ActivtiyWebService getActivtiyWebService() {
//		return activtiyWebService;
//	}
//	public void setActivtiyWebService(ActivtiyWebService activtiyWebService) {
//		this.activtiyWebService = activtiyWebService;
//	}
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
	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}
	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}
	public SysUserService getSysUserService() {
		return sysUserService;
	}
	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}
	public MobileActivityGmService getMobileActivityGmService() {
		return mobileActivityGmService;
	}
	public void setMobileActivityGmService(
			MobileActivityGmService mobileActivityGmService) {
		this.mobileActivityGmService = mobileActivityGmService;
	}
	public XlsSecretaryLoadService getXlsSecretaryLoadService() {
		return xlsSecretaryLoadService;
	}
	public void setXlsSecretaryLoadService(
			XlsSecretaryLoadService xlsSecretaryLoadService) {
		this.xlsSecretaryLoadService = xlsSecretaryLoadService;
	}


	private String insertStr = 1+"";
	private String updateStr = 2+"";
	
	//初始化页面
	private String mobileActivityInitView;
	//修改页面
	private String updatemobileActivityView;
	//复制页面
	private String copymobileActivityView;
	//编辑预置活动
	private String editPresetActivityView;
	public String getMobileActivityInitView() {
		return mobileActivityInitView;
	}
	public void setMobileActivityInitView(String mobileActivityInitView) {
		this.mobileActivityInitView = mobileActivityInitView;
	}
	public String getUpdatemobileActivityView() {
		return updatemobileActivityView;
	}
	public void setUpdatemobileActivityView(String updatemobileActivityView) {
		this.updatemobileActivityView = updatemobileActivityView;
	}
	public String getCopymobileActivityView() {
		return copymobileActivityView;
	}
	public void setCopymobileActivityView(String copymobileActivityView) {
		this.copymobileActivityView = copymobileActivityView;
	}
	
	public String getEditPresetActivityView() {
		return editPresetActivityView;
	}
	public void setEditPresetActivityView(String editPresetActivityView) {
		this.editPresetActivityView = editPresetActivityView;
	}
	/** 初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {

		ModelAndView mav = new ModelAndView(this.getMobileActivityInitView());
		List<MobileActivityShowData> list = this.getMobileActivityGmService().getMobileActivityEntityShowList();
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),u.getLoginServerId());
		
		List<DBServer> serverIds=new ArrayList<DBServer>();
		serverIds.add(svr);
		mav.addObject("serverIds", serverIds);
		mav.addObject("mobileActivityShowData", list);
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}
	
	/****
	 * 修改页面
	 */
	public ModelAndView updateMobileActivity(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getUpdatemobileActivityView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		
		String activityId = request.getParameter("Id").trim();

		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		mav.addObject("loginUser", session.getAttribute("u"));

		List<DBServer> serverIds =new ArrayList<DBServer>();
		serverIds.add(svr);
		mav.addObject("serverIds", serverIds);
		GoodActivityEntity mobileActivityEntity = this.getMobileActivityGmService().getMobileActivityEntityOnId(activityId);
		if(mobileActivityEntity == null){
			return init(request,response);
		}
		
		MobileActivityShowData mobileActivityShowData = this.getMobileActivityGmService().getMobileActivityShowData(mobileActivityEntity);
		mav.addObject("mobileActivityShowData", mobileActivityShowData);
		
		List<MobileActivityGroupsName> list = this.getMobileActivityGmService().getMobileActivityGrops();
		mav.addObject("mobileActivityGroupsNameList", list);

		mav.addObject("DBType", LangUtils.getDBType());
		
		//修改   插入
		mav.addObject("operateType", updateStr);
		return mav;
	}

	/****
	 * 插入页面
	 */
	public ModelAndView insertMobileActivity(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getUpdatemobileActivityView());
		
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");

		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		mav.addObject("loginUser", session.getAttribute("u"));

		List<DBServer> serverIds =new ArrayList<DBServer>();
		serverIds.add(svr);
		mav.addObject("serverIds", serverIds);
		MobileActivityShowData mobileActivityShowData = this.getMobileActivityGmService().getMobileActivityShowDataNew();
		mav.addObject("mobileActivityShowData", mobileActivityShowData);
		
		List<MobileActivityGroupsName> list = this.getMobileActivityGmService().getMobileActivityGrops();
		mav.addObject("mobileActivityGroupsNameList", list);

		mav.addObject("DBType", LangUtils.getDBType());
		
		//修改   插入
		mav.addObject("operateType", insertStr);
		return mav;
	}
	
	/****
	 * 更新操作
	 */
	public ModelAndView updateMobileActivityDo(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String id = request.getParameter("content").trim();
		String dateStart = request.getParameter("dateStart").trim();
		String startTime = request.getParameter("startTime").trim();		
		String dateEnd = request.getParameter("dateEnd").trim();
		String endTime = request.getParameter("endTime").trim();	
		String activityTplId = request.getParameter("activityType").trim();	
		String activityName = request.getParameter("activityName").trim();
		String activityDesc = request.getParameter("activityDesc").trim();
		String activityUsable = request.getParameter("activityUsable").trim();
		String nameIcon = request.getParameter("nameIcon").trim();
		String titleIcon = request.getParameter("titleIcon").trim();
		
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());
		
		String str =  this.getMobileActivityGmService().modifyMobileActivity(svr,id,dateStart,startTime,dateEnd,endTime,
				activityTplId,activityName,activityDesc,activityUsable, nameIcon, titleIcon);
		
		if(str.equals(ActivityCheckEnum.OK.getIndex()+"")){
			//回到初始界面
			return init(request, response);
		}else{
			logger.info("MobileActivityController.updateMobileActivityDo() error activityId="+id+" str="+str+" user="+LoginUserService.getLoginUser().getLoginUserToString());
			return updateMobileActivityDoFailure(request, response,str);
		}
	}
	
	//修改 或插入失败 回到编辑界面
	public ModelAndView updateMobileActivityDoFailure(HttpServletRequest request,
			HttpServletResponse response,String errorStr) throws Exception {
		String id = request.getParameter("content").trim();
		String dateStart = request.getParameter("dateStart").trim();
		String startTime = request.getParameter("startTime").trim();		
		String dateEnd = request.getParameter("dateEnd").trim();
		String endTime = request.getParameter("endTime").trim();	
		String prizeGroupsId = request.getParameter("activityType").trim();	
		String activityName = request.getParameter("activityName").trim();
		String activityDesc = request.getParameter("activityDesc").trim();
		String activityUsable = request.getParameter("activityUsable").trim();
		String nameIcon = request.getParameter("nameIcon").trim();
		String titleIcon = request.getParameter("titleIcon").trim();
		
		//强制关闭状态
		String foreEnd = request.getParameter("forceEnd").trim();
		
		ModelAndView mav = new ModelAndView(this.getUpdatemobileActivityView());
		
		MobileActivityShowData mobileActivityShowData = new MobileActivityShowData(id,dateStart,startTime,dateEnd,endTime,prizeGroupsId,activityName,
				activityDesc,activityUsable,foreEnd, nameIcon, titleIcon);
		
		mav.addObject("mobileActivityShowData", mobileActivityShowData);
		
		List<MobileActivityGroupsName> list = this.getMobileActivityGmService().getMobileActivityGrops();
		mav.addObject("mobileActivityGroupsNameList", list);
			
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		mav.addObject("loginUser", session.getAttribute("u"));

		List<DBServer> serverIds =new ArrayList<DBServer>();
		serverIds.add(svr);
		mav.addObject("serverIds", serverIds);
		mav.addObject("loginUser", session.getAttribute("u"));
		mav.addObject("DBType", LangUtils.getDBType());
		//eroor 信息
		mav.addObject("error_msg", errorStr);
			
		//界面
		return mav;
	}
	
	
	/****
	 * 设置不可用
	 */
	public ModelAndView updateUseOrNotNotUse(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String id = request.getParameter("Id").trim();

		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());
		
		String str =  this.getMobileActivityGmService().updateMobileActivityUseNot(svr,id);
		
		if(str.equals(ActivityCheckEnum.OK.getIndex()+"")){
		}else{
			logger.info("MobileActivityController.updateUseOrNotNotUse() error activityId="+id+" str="+str+" user="+LoginUserService.getLoginUser().getLoginUserToString()+" str="+str);
		}
		//回到初始界面
		return init(request, response);
	}
	
	/****
	 * 设置可用
	 */
	public ModelAndView updateUseOrNotUse(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String id = request.getParameter("Id").trim();

		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());
		
		String str =  this.getMobileActivityGmService().updateMobileActivityUse(svr,id);
		
		if(str.equals(ActivityCheckEnum.OK.getIndex()+"")){
		}else{
			logger.info("MobileActivityController.updateUseOrNotUse() error activityId="+id+" str="+str+" user="+LoginUserService.getLoginUser().getLoginUserToString()+" str="+str);
		}
		//回到初始界面
		return init(request, response);
	}
	
	/****
	 * 强制关闭
	 */
	public ModelAndView forceEndActivity(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		
		String id = request.getParameter("Id").trim();

		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());
		
		String str =  this.getMobileActivityGmService().forceEndMobileActivity(svr,id);
		
		if(str.equals(ActivityCheckEnum.OK.getIndex()+"")){
		}else{
			logger.info("MobileActivityController.updateUseOrNotUse() error activityId="+id+" str="+str+" user="+LoginUserService.getLoginUser().getLoginUserToString()+" str="+str);
		}
		//回到初始界面
		return init(request, response);
	}
	
	/**
	 * 正常关闭所有正在进行的精彩活动
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView closeAllGoingActivity(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());
		
		String str =  this.getMobileActivityGmService().closeAllOnGoingActivity(svr);
		
		if(str.equals(ActivityCheckEnum.OK.getIndex()+"")){
		}else{
			logger.info("MobileActivityController.updateUseOrNotUse() error str="+str+" user="+LoginUserService.getLoginUser().getLoginUserToString()+" str="+str);
		}
		//回到初始界面
		return init(request, response);
	}
	
	/***
	 * 复制页面
	 */
	public ModelAndView copyMobileActivity(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getCopymobileActivityView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		
		String activityId = request.getParameter("Id").trim();

		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		mav.addObject("loginUser", session.getAttribute("u"));

		List<DBServer> serverIds =new ArrayList<DBServer>();
		serverIds.add(svr);
		mav.addObject("serverIds", serverIds);
		GoodActivityEntity mobileActivityEntity = this.getMobileActivityGmService().getMobileActivityEntityOnId(activityId);
		if(mobileActivityEntity == null){
			return init(request,response);
		}
		
		MobileActivityShowData mobileActivityShowData = this.getMobileActivityGmService().getMobileActivityShowData(mobileActivityEntity);
		//mobileActivityShowData.setUseOrNot(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_USE_NOT+"");
		mav.addObject("mobileActivityShowData", mobileActivityShowData);
		
		List<MobileActivityGroupsName> list = this.getMobileActivityGmService().getMobileActivityGrops();
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
	 * 复制活动 操作
	 */
	public ModelAndView copyMobileActivityDo(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		
		String id = request.getParameter("content").trim();
		String ids[] = request.getParameterValues("sId");
		
		String serverIdss = idsToIdsStr(ids);
		
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		
		GoodActivityEntity mobileActivityEntity = this.getMobileActivityGmService().getMobileActivityEntityOnId(id);
		if(mobileActivityEntity == null){
			return init(request,response);
		}
		
		String str =  this.getMobileActivityGmService().copyMobileActivity(svr,serverIdss,mobileActivityEntity,u.getLoginRegionId());
		
		if(str.equals(ActivityCheckEnum.OK.getIndex()+"")){
			//回到初始界面
			return init(request, response);
		}else{
			logger.info("MobileActivityController.updateMobileActivityDo() error activityId="+id+" str="+str+" user="+LoginUserService.getLoginUser().getLoginUserToString());
			return copyMobileActivityDoFailure(request, response,str);
		}
	}
	
	//修改 或插入失败 回到编辑界面
	public ModelAndView copyMobileActivityDoFailure(HttpServletRequest request,
			HttpServletResponse response,String errorStr) throws Exception {
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		
		String id = request.getParameter("content").trim();
		String ids[] = request.getParameterValues("sId");
		
		String serverIdss = idsToIdsStr(ids);
		
		ModelAndView mav = new ModelAndView(this.getUpdatemobileActivityView());
		
		GoodActivityEntity mobileActivityEntity = this.getMobileActivityGmService().getMobileActivityEntityOnId(id);
		if(mobileActivityEntity == null){
			return init(request,response);
		}
		
		MobileActivityShowData mobileActivityShowData = this.getMobileActivityGmService().getMobileActivityShowData(mobileActivityEntity);
		//mobileActivityShowData.setUseOrNot(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_USE_NOT+"");
		mav.addObject("mobileActivityShowData", mobileActivityShowData);
		
		List<MobileActivityGroupsName> list = this.getMobileActivityGmService().getMobileActivityGrops();
		mav.addObject("mobileActivityGroupsNameList", list);
		
		
		SysUser s = sysUserService.getUserByName(u.getUsername(),u.getLoginRegionId());
		List<DBServer> listSer = DBFactoryService.getServers(s.getServerIds(), u.getLoginRegionId());
		List<ActivityCheckBoxData> checkBox = getActivityCheckBoxDataList(listSer,serverIdss,u.getLoginRegionId());
		mav.addObject("checkBox", checkBox);

		mav.addObject("DBType", LangUtils.getDBType());
		
		
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());	
		//
		mav.addObject("currentSerName", svr.getDbServerName());
		mav.addObject("currentSerId", svr.getId());
		
		mav.addObject("mobileActivityShowData", mobileActivityShowData);
			
		mav.addObject("loginUser", session.getAttribute("u"));
		//eroor 信息
		mav.addObject("error_msg", errorStr);
			
		//界面
		return mav;
	}
	
	/**
	 * 编辑预置活动
	 * 
	 * @param request
	 * @param response
	 * @param errorStr
	 * @return
	 * @throws Exception
	 */
	public ModelAndView editPresetActivity(HttpServletRequest request,
			HttpServletResponse response,String errorStr) throws Exception {
		ModelAndView mav = new ModelAndView(this.getEditPresetActivityView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		return mav;
	}
	
	public ModelAndView startPresetActivity(HttpServletRequest request,
					HttpServletResponse response,String errorStr) throws Exception {
		HttpSession session = request.getSession();
		
		String dateStart = request.getParameter("dateStart").trim();
		String startTime = request.getParameter("startTime").trim();		
		
		String[] sIds = request.getParameterValues("sId");
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		for(int i=0;i<sIds.length;i++){
			DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
			this.mobileActivityGmService.startPresetActivity(svr, dateStart, startTime);
		}
		
		ModelAndView mav = new ModelAndView(this.getEditPresetActivityView());
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		mav.addObject("error_msg", this.excelLangManagerService.readGm(GMLangConstants.ITEM_WAIT_FLUSH));
		return mav;
	}
	
	/***
	 * ajax 
	 * 查询奖励
	 */
	public void ajaxQueryGroupsPrizes(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String groupsId = request.getParameter("activityType").trim();
		String groupsPrize = "";
		if(groupsId!=null && !groupsId.equals("")){
			groupsPrize = this.getXlsSecretaryLoadService().getMobileActivityPrize(Integer.parseInt(groupsId));
		}
		
		response.getWriter().print(groupsPrize);
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
