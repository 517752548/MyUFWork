package com.imop.lj.gm.controller;

import java.util.HashMap;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.ItemService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.utils.LangUtils;

public class ItemController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String itemInitView;
	//道具服务
	private ItemService itemService;
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
	public String getItemInitView() {
		return itemInitView;
	}
	public void setItemInitView(String itemInitView) {
		this.itemInitView = itemInitView;
	}
	public ItemService getItemService() {
		return itemService;
	}
	public void setItemService(ItemService itemService) {
		this.itemService = itemService;
	}
	/*
	 * 道具页面列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getItemInitView());
		String searchType = request.getParameter("searchType");
		String searchValue = request.getParameter("searchValue");
		String startLevel = request.getParameter("startLevel");
		String endLevel = request.getParameter("endLevel");
		String startIndexSort = request.getParameter("startIndexSort");
		String delete = request.getParameter("state");

		List<ItemEntity>  itemList = this.getItemService().getAllItems(searchType,searchValue,startLevel,endLevel,startIndexSort, delete);
		mav.addObject("itemList", itemList);

		if(searchType == null){
			mav.addObject("searchType", "roleId");
		}else{
			mav.addObject("searchType", searchType);
		}
		mav.addObject("searchValue", searchValue);
		mav.addObject("startLevel", startLevel);
		mav.addObject("endLevel", endLevel);
		mav.addObject("startIndexSort", startIndexSort);
		mav.addObject("state", delete);
		LoginUser u = (LoginUser) request.getSession()
		.getAttribute("loginUser");
		HashMap roleMap = (HashMap) request.getSession()
		.getAttribute("roleMap");
		SysUser s = sysUserService.loadSysUser(u.getId());
		mav.addObject("sRole", s.getRole());
		mav.addObject("lev", roleMap.get(s.getRole()));
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}
	
	@SuppressWarnings("unchecked")
	public ModelAndView delItem(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String itemId = request.getParameter("itemId");
		String bagType = request.getParameter("bagType");
		String bagIndex = request.getParameter("bagIndex");
		String num = request.getParameter("num");
		String roleUUID = request.getParameter("roleUUID");
		
		if (itemId != null) {
			itemId = itemId.trim();
		}
		if (bagType != null) {
			bagType = bagType.trim();
		}
		if (bagIndex != null) {
			bagIndex = bagIndex.trim();
		}
		if(num != null){
			num = num.trim();
		}
		if(roleUUID != null){
			roleUUID = roleUUID.trim();
		}
		
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		//用户信息
		String uStr = u.getLoginUserToString();
		if (this.getItemService().delItemDo(itemId,bagType,bagIndex,num,roleUUID,uStr,svr)) {
			response.getWriter().print("ok");
		} else {
			response.getWriter().print("failurue");
		}
		//response.getWriter().print(ceoWarCraftService.modifyCeoCraftWardo(id,serverType,startTimedate,isuseable,svr));
		return null;
	}

}
