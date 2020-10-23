package com.imop.lj.gm.controller.maintenance;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.model.PrizeVO;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.maintenance.PrizeService;
import com.imop.lj.gm.service.maintenance.UserPrizeService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LangUtils;

/**
 * 发奖礼包Controller
 *
 *
 */
public class PrizeController extends MultiActionController {
	
	private GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	/** 发奖礼包初始页面 */
	private String prizeListView;

	/** 发奖礼包初始页面 */
	private String addPrizeInitView;

	/** 服务器状态Service */
	private PrizeService prizeService;

	/** 发奖礼包结果页面 */
	private String prizeResListView;

	/** GM补偿Service */
	private UserPrizeService userPrizeService;

	public UserPrizeService getUserPrizeService() {
		return userPrizeService;
	}

	public void setUserPrizeService(UserPrizeService userPrizeService) {
		this.userPrizeService = userPrizeService;
	}

	public String getPrizeListView() {
		return prizeListView;
	}

	public void setPrizeListView(String prizeListView) {
		this.prizeListView = prizeListView;
	}

	public String getAddPrizeInitView() {
		return addPrizeInitView;
	}

	public void setAddPrizeInitView(String addPrizeInitView) {
		this.addPrizeInitView = addPrizeInitView;
	}

	public PrizeService getPrizeService() {
		return prizeService;
	}

	public void setPrizeService(PrizeService prizeService) {
		this.prizeService = prizeService;
	}

	public String getPrizeResListView() {
		return prizeResListView;
	}

	public void setPrizeResListView(String prizeResListView) {
		this.prizeResListView = prizeResListView;
	}

	/**
	 *发奖礼包初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getPrizeListView());
		String id = request.getParameter("id");
		List<PrizeVO> prizeList = prizeService.getPrizeList(id);
		mav.addObject("prizeList", prizeList);
		mav.addObject("id", id);
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}

	/** 删除发奖礼包记录 */
	public ModelAndView delPrize(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String id = request.getParameter("id");
		if (prizeService.delPrize(id)) {
			response.getWriter().print("true");
		} else {
			response.getWriter().print("false");
		}
		return null;
	}

	/**
	 * 新增发奖礼包记录初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView addPrizeInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getAddPrizeInitView());
		mav.addObject("currencys", UserPrizeService.getCurrencyConfigMap().values());
		mav.addObject("currencyNumLimit", gmConfig.currencyNum);
		mav.addObject("goldNumLimit", gmConfig.goldNum);
		mav.addObject("itemNumLimit", gmConfig.itemNum);
		return mav;
	}

	/**
	 * 新增发奖礼包记录
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView addPrize(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getAddPrizeInitView());
		String prizeId = request.getParameter("prizeId").trim();
		String prizeName = request.getParameter("prizeName").trim();
		String currencyPack = "";
		for(Object currency : UserPrizeService.getCurrencyConfigMap().keySet()){
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
		
		String item = request.getParameter("item").trim();
		if (prizeService.validatePrizeId(prizeId)) {
			if (prizeService.addPrize(LoginUserService.getLoginUser().getLoginServerId(), currencyPack, item, prizeId, prizeName)) {
				mav.addObject("cmd", true);
			} else {
				mav.addObject("cmd", false);
			}
		} else {
			mav.addObject("prizeIdErr", true);
		}
		mav.addObject("prizeId", prizeId);
		mav.addObject("currencyPack", currencyPack);
		mav.addObject("item", item);
		mav.addObject("prizeName", prizeName);
		mav.addObject("currencyNumLimit", gmConfig.currencyNum);
		mav.addObject("goldNumLimit", gmConfig.goldNum);
		mav.addObject("itemNumLimit", gmConfig.itemNum);
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
		String prizeId = request.getParameter("prizeId").trim();
		String item = request.getParameter("item");
		response.setCharacterEncoding("utf-8");
		if (!prizeService.validatePrizeId(prizeId)) {
			response.getWriter().
			print(ExcelLangManagerService.readGmLang(GMLangConstants.PRIZE_ID)+ExcelLangManagerService.readGmLang(GMLangConstants.PRIZE_FMT));
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

}
