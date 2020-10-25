package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.BranchService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;

/**
 * 游戏玩家管理Controller
 *
 * @author linfan
 *
 */
public class BranchManageController extends MultiActionController {

	/** 用户管理初始页面 */
	private String branchInitView;


	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 用户管理Service */
	private BranchService branchService;

	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;




	/**
	 * 游戏玩家管理页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getBranchInitView());
//		String searchType = request.getParameter("searchType");
//		String searchValue = request.getParameter("searchValue");
//		String startLevel = request.getParameter("startLevel");
//		String endLevel = request.getParameter("endLevel");
//		String startIndexSort = request.getParameter("startIndexSort");
//		String endIndexSort = request.getParameter("endIndexSort");
//
//		List<BranchEntity> branchList = branchService.getBranchList(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort);
//		mav.addObject("branchList", branchList);
//
//		if(searchType == null){
//			mav.addObject("searchType", "roleId");
//		}else{
//			mav.addObject("searchType", searchType);
//		}
//		mav.addObject("searchValue", searchValue);
//		mav.addObject("startLevel", startLevel);
//		mav.addObject("endLevel", endLevel);
//		mav.addObject("startIndexSort", startIndexSort);
//		mav.addObject("endIndexSort", endIndexSort);
//
//		LoginUser u = (LoginUser) request.getSession()
//		.getAttribute("loginUser");
//		HashMap roleMap = (HashMap) request.getSession()
//		.getAttribute("roleMap");
//		SysUser s = sysUserService.loadSysUser(u.getId());
//		mav.addObject("sRole", s.getRole());
//		mav.addObject("lev", roleMap.get(s.getRole()));
//		mav.addObject("DBType", LangUtils.getDBType());
//		/*GMTemplateService gm  = new GMTemplateService();
//		Map<Integer,CompanyTypeTemplate> map =   gm.getCompanyAll(CompanyTypeTemplate.class, request);
//		for(CompanyTypeTemplate vo:map.values())
//		{
//			System.out.println(vo.getName());
//			System.out.println(vo.getSheetName());
//		}*/
		return mav;
	}




	public String getBranchInitView() {
		return branchInitView;
	}




	public void setBranchInitView(String branchInitView) {
		this.branchInitView = branchInitView;
	}




	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}




	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}




	public BranchService getBranchService() {
		return branchService;
	}




	public void setBranchService(BranchService branchService) {
		this.branchService = branchService;
	}




	public SysUserService getSysUserService() {
		return sysUserService;
	}




	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}



}
