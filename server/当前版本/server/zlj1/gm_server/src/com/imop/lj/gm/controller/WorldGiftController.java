package com.imop.lj.gm.controller;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.WorldGiftVO;
import com.imop.lj.gm.service.WorldGiftService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.UserPrizeService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LangUtils;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午12:08:55
 * @version 1.0
 */

public class WorldGiftController extends MultiActionController {

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;
	/** 处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;
	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;
	
	private WorldGiftService worldGiftService;
	
	private UserPrizeService userPrizeService;
	/** 初始页面 */
	private String initGiftView;
	/** 生成页面 */
	private String addGiftView;

	/** log */
	private static final Logger logger = LoggerFactory.getLogger("gm.worldgif");
	/**
	 * 全服礼包初始页面
	 * 
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitGiftView());
		
		Object jspGiftId = request.getAttribute("giftId");
		List<WorldGiftVO> giftList = new ArrayList<WorldGiftVO>();
		if(jspGiftId == null) {
			giftList.addAll(worldGiftService.getAllWorldGift());
		} else {
			String giftId = jspGiftId.toString();
			giftList.add(worldGiftService.getWorldGift(giftId)) ;
		}
		
		mav.addObject("giftList", giftList);
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}
	
	public ModelAndView addInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		
		ModelAndView mav = new ModelAndView(getAddGiftView());
		
		/**
		 * 身份验证
		 */
		LoginUser user = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		// 是不是超级管理员
		if(!"super_admin".equals(user.getRole())) {
			logger.error("#WorldGiftController#addInit user is not super_admin!, user id = " + user.getId());
			return new ModelAndView(this.getInitGiftView());
		}
		
		mav.addObject("DBType", LangUtils.getDBType());
		
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
	public ModelAndView addWorldGift(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitGiftView());
		
		LoginUser user = (LoginUser) request.getSession().getAttribute("loginUser");
		
		logger.info("#WorldGiftController#addWorldGift#start , user id = " + user.getId());
		
		String giftId = request.getParameter("giftId").trim();
		String giftName = request.getParameter("giftName").trim();
		if(!isExistGiftId(giftId) ) {
			return mav;
		}
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
		String items = request.getParameter("item").trim();
		if(!validItem(items)) {
			return mav;
		}
		// 发送保存
		List<WorldGiftVO> list = new ArrayList<WorldGiftVO>();
		WorldGiftVO vo = worldGiftService.addWorldGift(giftId, giftName, currencyPack, items);
		String errorMessage = vo.getResult();
		boolean isSucc = "succ".equals(errorMessage); 
		if(isSucc) {
			list.add(vo);
		}
		
		logger.info("#WorldGiftController#addWorldGift#end , user id = " + user.getId()
				+ "result is " + errorMessage + (isSucc ? vo.toString() : "" )
				);
		
		mav.addObject("giftList",list);
		mav.addObject("DBType", LangUtils.getDBType());
		mav.addObject("error_msg", errorMessage);
		return mav;
	}
	
	/**
	 * 同步要校验的数据
	 *
	 * @param request
	 * @param response
	 * @throws Exception
	 */
	public void checkData(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String prizeId = request.getParameter("giftId").trim();
		String item = request.getParameter("item");
		response.setCharacterEncoding("utf-8");
		if (!isExistGiftId(prizeId)) {
			response.getWriter().
			print(ExcelLangManagerService.readGmLang(GMLangConstants.WORLD_GIFT_ID)+ExcelLangManagerService.readGmLang(GMLangConstants.PRIZE_FMT));
			return;
		}
		// 已经存在
		if( !worldGiftService.validGiftIdExist(prizeId)) {
			response.getWriter().
			print(ExcelLangManagerService.readGmLang(GMLangConstants.WORLD_GIFT_ID)+ExcelLangManagerService.readGmLang(GMLangConstants.ECHO));
			return;
		}
		if (StringUtils.isNotBlank(item)) {
			String[] arr = item.split(";");
			boolean itemFlag = true;
			ArrayList<String> itemArray = new ArrayList<String>();
			for (int j = 0; j < arr.length; j++) {
				itemFlag = userPrizeService.validItem(arr[j]);
				if (!itemFlag) {
					response.getWriter().
					print(arr[j]+":"+ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_NUM_WRONG));
					return;
				}
				String itId[] = arr[j].split("=");
				if (StringUtils.isBlank(itId[0])) {
					response.getWriter().
					print(itId[0]+":"+ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_ID_NOT_NULL));
					return;
				}
				itId[0] = itId[0].trim();
				if (itemArray.contains(itId[0])) {
					itemFlag = false;
					response.getWriter().
					print(itId[0]+":"+ExcelLangManagerService.readGmLang(GMLangConstants.ECHO));
					return ;
				} else if (!userPrizeService.authItem(itId[0])) {
					itemFlag = false;
					response.getWriter().
					print(itId[0]+":"+ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_WRONG));
					return ;
				} else {
					itemArray.add(itId[0]);
				}
			}
		}
		response.getWriter().print("ok");
	}
	
	private boolean isExistGiftId(String giftId) {
		if (!worldGiftService.validGiftId(giftId)) {
			logger.error(ExcelLangManagerService.readGmLang(GMLangConstants.WORLD_GIFT_ID)+ExcelLangManagerService.readGmLang(GMLangConstants.PRIZE_FMT));
			return false;
		}
		// 已经存在
		if( !worldGiftService.validGiftIdExist(giftId)) {
			logger.error(ExcelLangManagerService.readGmLang(GMLangConstants.WORLD_GIFT_ID)+ExcelLangManagerService.readGmLang(GMLangConstants.ECHO));
			return false;
		}
		return true;
	}
	
	private boolean validItem(String item) {
		
		if (StringUtils.isNotBlank(item)) {
			String[] arr = item.split(";");
			boolean itemFlag = true;
			ArrayList<String> itemArray = new ArrayList<String>();
			for (int j = 0; j < arr.length; j++) {
				itemFlag = userPrizeService.validItem(arr[j]);
				if (!itemFlag) {
					logger.error(arr[j]+":"+ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_NUM_WRONG));
					return false;
				}
				String itId[] = arr[j].split("=");
				if (StringUtils.isBlank(itId[0])) {
					logger.error(itId[0]+":"+ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_ID_NOT_NULL));
					return false;
				}
				itId[0] = itId[0].trim();
				if (itemArray.contains(itId[0])) {
					itemFlag = false;
					logger.error(itId[0]+":"+ExcelLangManagerService.readGmLang(GMLangConstants.ECHO));
					return false;
				} else if (!userPrizeService.authItem(itId[0])) {
					itemFlag = false;
					logger.error(itId[0]+":"+ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_WRONG));
					return false;
				} else {
					itemArray.add(itId[0]);
				}
			}
		}
		return true;
	}
	/**
	 * ===================getter/setter==============
	 */

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

	public String getInitGiftView() {
		return initGiftView;
	}

	public void setInitGiftView(String initGiftView) {
		this.initGiftView = initGiftView;
	}

	public String getAddGiftView() {
		return addGiftView;
	}

	public void setAddGiftView(String addGiftView) {
		this.addGiftView = addGiftView;
	}

	public WorldGiftService getWorldGiftService() {
		return worldGiftService;
	}

	public void setWorldGiftService(WorldGiftService worldGiftService) {
		this.worldGiftService = worldGiftService;
	}

	public UserPrizeService getUserPrizeService() {
		return userPrizeService;
	}

	public void setUserPrizeService(UserPrizeService userPrizeService) {
		this.userPrizeService = userPrizeService;
	}

	
}
