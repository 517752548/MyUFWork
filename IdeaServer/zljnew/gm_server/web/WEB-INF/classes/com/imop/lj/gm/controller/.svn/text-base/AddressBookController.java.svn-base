package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.AddressBookService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;

public class AddressBookController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String addressBookInitView;
	//vip通讯录服务
	private AddressBookService addressBookService;
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

	public String getAddressBookInitView() {
		return addressBookInitView;
	}
	public void setAddressBookInitView(String addressBookInitView) {
		this.addressBookInitView = addressBookInitView;
	}
	public AddressBookService getAddressBookService() {
		return addressBookService;
	}
	public void setAddressBookService(AddressBookService addressBookService) {
		this.addressBookService = addressBookService;
	}
	/*
	 * 秘书页面列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getAddressBookInitView());
//		String searchType = request.getParameter("searchType");
//		String searchValue = request.getParameter("searchValue");
//		String startDate = request.getParameter("startDate");
//		String endDate = request.getParameter("endDate");
//
//		List<AddressBookEntity>  addressBookList = this.getAddressBookService().getAllAddressBooks(searchType,searchValue,startDate,endDate);
//		mav.addObject("addressBookList", addressBookList);
//
//		if(searchType == null){
//			mav.addObject("searchType", "roleId");
//		}else{
//			mav.addObject("searchType", searchType);
//		}
//		mav.addObject("searchValue", searchValue);
//		mav.addObject("startDate", startDate);
//		mav.addObject("endDate", endDate);
//
//		LoginUser u = (LoginUser) request.getSession()
//		.getAttribute("loginUser");
//		HashMap roleMap = (HashMap) request.getSession()
//		.getAttribute("roleMap");
//		SysUser s = sysUserService.loadSysUser(u.getId());
//		mav.addObject("sRole", s.getRole());
//		mav.addObject("lev", roleMap.get(s.getRole()));
//		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}
}
