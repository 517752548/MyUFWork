package com.imop.lj.gm.controller.maintenance;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.dto.UserPrizeRes;
import com.imop.lj.gm.service.UserInfoService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.UserPrizeAllService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.web.activity.service.GMGlobals;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月20日 上午9:12:29
 * @version 1.0
 */

public class UserPrizeAllServerController extends MultiActionController {

	private GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	private Logger logger = GMGlobals.logger;
	/** GM全服补偿初始页面 */
	private String userPrizeAllInitView;
	/** GM全服补偿页面 */
	private String addAllServerUserPrizeView;
	/** GM补偿结果页面 */
	private String userPrizeResAllListView;
	/** 服务器状态Service */
	private UserPrizeAllService userPrizeAllService;
	/** 账户service */
	private UserInfoService userInfoService;
	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	public String getUserPrizeAllInitView() {
		return userPrizeAllInitView;
	}

	public void setUserPrizeAllInitView(String userPrizeAllInitView) {
		this.userPrizeAllInitView = userPrizeAllInitView;
	}

	public String getAddAllServerUserPrizeView() {
		return addAllServerUserPrizeView;
	}

	public void setAddAllServerUserPrizeView(String addAllServerUserPrizeView) {
		this.addAllServerUserPrizeView = addAllServerUserPrizeView;
	}

	public String getUserPrizeResAllListView() {
		return userPrizeResAllListView;
	}

	public void setUserPrizeResAllListView(String userPrizeResAllListView) {
		this.userPrizeResAllListView = userPrizeResAllListView;
	}

	public UserPrizeAllService getUserPrizeAllService() {
		return userPrizeAllService;
	}

	public void setUserPrizeAllService(UserPrizeAllService userPrizeAllService) {
		this.userPrizeAllService = userPrizeAllService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}
	
	public UserInfoService getUserInfoService() {
		return userInfoService;
	}

	public void setUserInfoService(UserInfoService userInfoService) {
		this.userInfoService = userInfoService;
	}

	/**
	 *GM补偿初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
//	public ModelAndView init(HttpServletRequest request,
//			HttpServletResponse response) throws Exception {
//		ModelAndView mav = new ModelAndView(getUserPrizeAllInitView());
//		String passportId = request.getParameter("passportId");
//		String id = request.getParameter("id");
//		String reason = request.getParameter("reason");
//		String date = request.getParameter("date");
//		String startTime = request.getParameter("startTime");
//		String endTime = request.getParameter("endTime");
//		if (date == null) {
//			date = DateUtil.formatDate(new Date());
//		}
//		
//		List<UserPrizeVO> userPrizelist = userPrizeAllService.getUserPrizeList(
//				passportId, reason, id, startTime, endTime, date);
//		mav.addObject("userPrizelist", userPrizelist);
//		mav.addObject("passportId", passportId);
//		mav.addObject("reason", reason);
//		mav.addObject("startTime", startTime);
//		mav.addObject("endTime", endTime);
//		mav.addObject("date", date);
//		mav.addObject("DBType", LangUtils.getDBType());
//		return mav;
//	}

	/** 删除GM补偿记录 */
//	public ModelAndView delUserPrize(HttpServletRequest request,
//			HttpServletResponse response) throws Exception {
//		ModelAndView mav = new ModelAndView(getUserPrizeAllInitView());
//		String id = request.getParameter("id");
//		String ids = request.getParameter("ids");
//		if (StringUtils.isNotBlank(id)) {
//			if (userPrizeAllService.delUserPrize(id)) {
//				response.getWriter().print("true");
//			} else {
//				response.getWriter().print("false");
//			}
//		}
//		if(StringUtils.isNotBlank(ids)){
//			ids=ids.substring(0, ids.length()-1);
//			String[] theIds = ids.split("_");
//			for(String _id : theIds){
//				if(!userPrizeAllService.delUserPrize(_id)){
//					response.getWriter().print("false");
//				}
//			}
//			response.getWriter().print("true");
//		}
//		return mav;
//	}

	/**
	 * 新增GM补偿记录初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView addUserPrizeInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getAddAllServerUserPrizeView());
		
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		List<DBServer> svr= dbFactoryService.getServerList(u.getLoginRegionId());
		List<DBServer> serverIds = new ArrayList<DBServer>();
		serverIds.addAll(svr);
		
		logger.info("UserPrizeAllServerController#addUserPrizeInit#loginUser id=" + u.getId() + ", name =" + u.getUsername());

		mav.addObject("currencyNum", gmConfig.currencyNum);
		mav.addObject("goldNum", gmConfig.goldNum);
		mav.addObject("itemNum", gmConfig.itemNum);
		mav.addObject("serverIds", serverIds);
		
		return mav;
	}

	/**
	 * 新增GM补偿记录
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView addUserPrize(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUserPrizeResAllListView());
		String currencyPack = "";
		for(Object currency : Mask.getMap("ljCurrency").keySet()){
			int index = (Integer)currency;
			String value = request.getParameter("currency" + index);
			if(value == null || value.isEmpty()){
				continue;
			}
			currencyPack = currencyPack + index + "=" + value + ";";
		}
		
		// 去掉最后一个分号
		if(!currencyPack.isEmpty() && currencyPack.charAt(currencyPack.length() - 1) == ';'){
			currencyPack = currencyPack.substring(0, currencyPack.length() - 1);
		}
		
		String reason = request.getParameter("reason").trim();
		String item = request.getParameter("item").trim();
		String userPrizeName = request.getParameter("userPrizeName").trim();
		String[] sIds = request.getParameterValues("sId");
		
		
		if(currencyPack.isEmpty() &&  item.isEmpty()) {
			mav.addObject("currencyNum", gmConfig.currencyNum);
			mav.addObject("goldNum", gmConfig.goldNum);
			mav.addObject("itemNum", gmConfig.itemNum);
			return mav;
		}
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		
		logger.info("UserPrizeAllServerController#addUserPrize#loginUser id=" + u.getId() + ", name =" + u.getUsername() 
				+ ", currencyPack="+ currencyPack
				+ ", item=" + item 
				+ ", userPrizeName =" + userPrizeName
				+ ", sIds=" + sIds.toString()
				);
		
		DBServer svr = null; 
		List<UserPrizeRes> resList = new ArrayList<UserPrizeRes>();
		
		for(int i=0 ;i < sIds.length; i++) {
			svr = dbFactoryService.getServer(sIds[i]);
			if(null != svr) {
				resList.addAll(userPrizeAllService.addUserPrize(svr, sIds[i],
						userPrizeName, reason, currencyPack, item));
			}
		}
		mav.addObject("resList", resList);
		mav.addObject("currencyNum", gmConfig.currencyNum);
		mav.addObject("goldNum", gmConfig.goldNum);
		mav.addObject("itemNum", gmConfig.itemNum);
		
		return mav;
	}
	
	/**
	 * 新增GM补偿记录
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
//	public ModelAndView addUserItemWithParams(HttpServletRequest request,
//			HttpServletResponse response) throws Exception {
//		ModelAndView mav = new ModelAndView(getUserPrizeResAllListView());
//		/**
//		 * 身份验证
//		 */
//		LoginUser user = (LoginUser) request.getSession()
//				.getAttribute("loginUser");
//		// 是不是超级管理员
//		if(!"super_admin".equals(user.getRole())) {
//			return mav;
//		}
//		
//		/**  
//		 *  0：道具id， 1：道具数量, 2强化等级， 3附魔等级， 4装备打孔数量， 5技能id、6武器等级， 7属性A串，8属性B串：
//		 */
//		String passportId = request.getParameter("passportId").trim();
//		String roleId = request.getParameter("roleId").trim();
//		String itemTemplateId = request.getParameter("templateId").trim();
//		String itemCount = request.getParameter("itemCount").trim();
//		String enhanceLevel = request.getParameter("enhanceLevel").trim();
//		String fumoLevel = request.getParameter("fumoLevel").trim();
//		String holeCount = request.getParameter("holeCount").trim();
//		String skillId = request.getParameter("skillId").trim();
//		String attrAParams = request.getParameter("attrAStr").trim();
//		String attrBParams = request.getParameter("attrBStr").trim();
//		String reason = request.getParameter("reason").trim();
//		String userPrizeName = request.getParameter("userPrizeName").trim();
//	
//		StringBuffer sb = new StringBuffer();
//		sb.append(itemTemplateId.length() > 0 ? itemTemplateId : 0);
//		sb.append(",");
//		sb.append(itemCount.length() > 0 ? itemCount : 0);
//		sb.append(",");
//		sb.append(enhanceLevel.length() > 0 ? enhanceLevel : 0);
//		sb.append(",");
//		sb.append(fumoLevel.length() > 0 ? fumoLevel : 0);
//		sb.append(",");
//		sb.append(holeCount.length() > 0 ? holeCount : 0);
//		sb.append(",");
//		sb.append(skillId.length() > 0 ? skillId : 0);
//		
//		String params = sb.toString();
//				
//		JSONObject json = new JSONObject();
//		json.put("id", roleId);
//		json.put("params", params);
//		json.put("attrA", attrAParams);
//		json.put("attrB", attrBParams);
//		
//		List<UserPrizeRes> resList = userPrizeAllService.addUserPrize(
//				LoginUserService.getLoginUser().getLoginServerId(),
//				userPrizeName, reason, "", "", json.toString());
//		
//		mav.addObject("resList", resList);
//		return mav;
//	}

	/**
	 * 同步要校验的数据
	 *
	 * @param request
	 * @param response
	 * @throws Exception
	 */
	public void checkData(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String item = request.getParameter("item");
		response.setCharacterEncoding("utf-8");
		boolean flag = true;
		if (StringUtils.isNotBlank(item)) {
			String[] arr = item.split(";");
			ArrayList<String> itemArray = new ArrayList<String>();
			for (int j = 0; j < arr.length; j++) {
				flag = userPrizeAllService.validItem(arr[j]);
				if (!flag) {
					response.getWriter().print(arr[j] + ":"	+ ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_NUM_WRONG));
					return;
				}
				String itId[] = arr[j].split("=");
				if (StringUtils.isBlank(itId[0])) {
					response.getWriter().print(itId[0] + ":" + ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_ID_NOT_NULL));
					return;
				}
				itId[0] = itId[0].trim();
				if (itemArray.contains(itId[0])) {
					flag = false;
					response.getWriter().print(itId[0] + ":" + ExcelLangManagerService.readGmLang(GMLangConstants.ECHO));
					return;
				} else if (!userPrizeAllService.authItem(itId[0])) {
					flag = false;
					response.getWriter().print(itId[0] + ":" + ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_WRONG));
					return;
				} else {
					itemArray.add(itId[0]);
				}
			}
		}
		
		response.getWriter().print("ok");
	}
}
