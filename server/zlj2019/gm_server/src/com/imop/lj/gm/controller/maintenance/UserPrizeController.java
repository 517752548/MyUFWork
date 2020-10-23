package com.imop.lj.gm.controller.maintenance;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import net.sf.json.JSONObject;

import org.apache.commons.lang.StringUtils;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.poifs.filesystem.POIFSFileSystem;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.dto.UserPrizeRes;
import com.imop.lj.gm.model.UserPrizeVO;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.maintenance.UserPrizeService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.lj.gm.utils.PoiUtils;
import com.imop.lj.gm.utils.UploadFileUtil;

/**
 * GM补偿Controller
 *
 *
 */
public class UserPrizeController extends MultiActionController {

	private GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	/** GM补偿初始页面 */
	private String userPrizeListView;

	/** GM补偿初始页面 */
	private String addUserPrizeInitView;
	
	/** GM补偿带有属性的道具*/
	private String addUserPrizeParamsInitView;

	/** 服务器状态Service */
	private UserPrizeService userPrizeService;

	/** GM补偿结果页面 */
	private String userPrizeResListView;

	/** csv批量补偿初始页面 */
	private String csvBatchPrizeInitView;

	public String getUserPrizeResListView() {
		return userPrizeResListView;
	}

	public void setUserPrizeResListView(String userPrizeResListView) {
		this.userPrizeResListView = userPrizeResListView;
	}

	public String getAddUserPrizeInitView() {
		return addUserPrizeInitView;
	}

	public void setAddUserPrizeInitView(String addUserPrizeInitView) {
		this.addUserPrizeInitView = addUserPrizeInitView;
	}

	public String getUserPrizeListView() {
		return userPrizeListView;
	}

	public void setUserPrizeListView(String userPrizeListView) {
		this.userPrizeListView = userPrizeListView;
	}

	public UserPrizeService getUserPrizeService() {
		return userPrizeService;
	}

	public void setUserPrizeService(UserPrizeService userPrizeService) {
		this.userPrizeService = userPrizeService;
	}

	public String getCsvBatchPrizeInitView() {
		return csvBatchPrizeInitView;
	}

	public void setCsvBatchPrizeInitView(String csvBatchPrizeInitView) {
		this.csvBatchPrizeInitView = csvBatchPrizeInitView;
	}

	public String getAddUserPrizeParamsInitView() {
		return addUserPrizeParamsInitView;
	}

	public void setAddUserPrizeParamsInitView(String addUserPrizeParamsInitView) {
		this.addUserPrizeParamsInitView = addUserPrizeParamsInitView;
	}

	/**
	 *GM补偿初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUserPrizeListView());
		String passportId = request.getParameter("passportId");
		String id = request.getParameter("id");
		String reason = request.getParameter("reason");
		String date = request.getParameter("date");
		String startTime = request.getParameter("startTime");
		String endTime = request.getParameter("endTime");
		if (date == null) {
			date = DateUtil.formatDate(new Date());
		}
		List<UserPrizeVO> userPrizelist = userPrizeService.getUserPrizeList(
				passportId, reason, id, startTime, endTime, date);
		mav.addObject("userPrizelist", userPrizelist);
		mav.addObject("passportId", passportId);
		mav.addObject("reason", reason);
		mav.addObject("startTime", startTime);
		mav.addObject("endTime", endTime);
		mav.addObject("date", date);
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}

	/** 删除GM补偿记录 */
	public ModelAndView delUserPrize(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUserPrizeListView());
		String id = request.getParameter("id");
		String ids = request.getParameter("ids");
		if (StringUtils.isNotBlank(id)) {
			if (userPrizeService.delUserPrize(id)) {
				response.getWriter().print("true");
			} else {
				response.getWriter().print("false");
			}
		}
		if(StringUtils.isNotBlank(ids)){
			ids=ids.substring(0, ids.length()-1);
			String[] theIds = ids.split("_");
			for(String _id : theIds){
				if(!userPrizeService.delUserPrize(_id)){
					response.getWriter().print("false");
				}
			}
			response.getWriter().print("true");
		}
		return mav;
	}

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
		ModelAndView mav = new ModelAndView(getAddUserPrizeInitView());
		mav.addObject("currencys", UserPrizeService.getCurrencyConfigMap().values());
		mav.addObject("currencyNum", gmConfig.currencyNum);
		mav.addObject("goldNum", gmConfig.goldNum);
		mav.addObject("itemNum", gmConfig.itemNum);
		return mav;
	}
	/**
	 * 新增GM补偿带有属性的道具记录初始页面
	 * 
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView addUserPrizeItemWithParamsInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getAddUserPrizeParamsInitView());
		
		/**
		 * 身份验证
		 */
		LoginUser user = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		// 是不是超级管理员
		if(!"super_admin".equals(user.getRole())) {
			return new ModelAndView(this.getAddUserPrizeInitView());
		}
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
		ModelAndView mav = new ModelAndView(getUserPrizeResListView());
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
		
		String reason = request.getParameter("reason").trim();
		String passportIds = request.getParameter("passportIds").trim();
		String item = request.getParameter("item").trim();
		String userPrizeName = request.getParameter("userPrizeName").trim();
		List<UserPrizeRes> resList = userPrizeService.addUserPrize(
				LoginUserService.getLoginUser().getLoginServerId(),
				userPrizeName, passportIds, reason, currencyPack, item);
		mav.addObject("resList", resList);
		mav.addObject("currencys", UserPrizeService.getCurrencyConfigMap().values());
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
	public ModelAndView addUserItemWithParams(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUserPrizeResListView());
		/**
		 * 身份验证
		 */
		LoginUser user = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		// 是不是超级管理员
		if(!"super_admin".equals(user.getRole())) {
			return mav;
		}
		
		/**  
		 *  0：道具id， 1：道具数量, 2强化等级， 3附魔等级， 4装备打孔数量， 5技能id、6武器等级， 7属性A串，8属性B串：
		 */
		String passportId = request.getParameter("passportId").trim();
		String roleId = request.getParameter("roleId").trim();
		String itemTemplateId = request.getParameter("templateId").trim();
		String itemCount = request.getParameter("itemCount").trim();
		String enhanceLevel = request.getParameter("enhanceLevel").trim();
		String fumoLevel = request.getParameter("fumoLevel").trim();
		String holeCount = request.getParameter("holeCount").trim();
		String skillId = request.getParameter("skillId").trim();
		String attrAParams = request.getParameter("attrAStr").trim();
		String attrBParams = request.getParameter("attrBStr").trim();
		String reason = request.getParameter("reason").trim();
		String userPrizeName = request.getParameter("userPrizeName").trim();
	
		StringBuffer sb = new StringBuffer();
		sb.append(itemTemplateId.length() > 0 ? itemTemplateId : 0);
		sb.append(",");
		sb.append(itemCount.length() > 0 ? itemCount : 0);
		sb.append(",");
		sb.append(enhanceLevel.length() > 0 ? enhanceLevel : 0);
		sb.append(",");
		sb.append(fumoLevel.length() > 0 ? fumoLevel : 0);
		sb.append(",");
		sb.append(holeCount.length() > 0 ? holeCount : 0);
		sb.append(",");
		sb.append(skillId.length() > 0 ? skillId : 0);
		
		String params = sb.toString();
				
		JSONObject json = new JSONObject();
		json.put("id", roleId);
		json.put("params", params);
		json.put("attrA", attrAParams);
		json.put("attrB", attrBParams);
		
		String passportIdAndCount = passportId + "=" + roleId;
		
		List<UserPrizeRes> resList = userPrizeService.addUserPrize(
				LoginUserService.getLoginUser().getLoginServerId(),
				userPrizeName, passportIdAndCount, reason, "", "", json.toString());
		
		mav.addObject("resList", resList);
		return mav;
	}

	/**
	 * 导入CSV初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView csvBatchPrizeInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getCsvBatchPrizeInitView());
		return mav;
	}

	/**
	 * 导入CSV
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView importCSV(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUserPrizeResListView());
		String file = UploadFileUtil.uploadFile(request, "userPrize");
		if (StringUtils.isNotBlank(file)) {
//			CsvReader cu = new CsvReader(SystemConstants.UPLOAD_PATH + "\\"	+ file);
//			List<UserPrizeRes> resList = new ArrayList<UserPrizeRes>();
//			try {
//				for (int i = 1; i < cu.getRowNum(); i++) {
//					if (cu.getColNum(i) < 7) {
//						UserPrizeRes userPrizeRes = new UserPrizeRes();
//						userPrizeRes.setResult("GM Prize file:"	+ ExcelLangManagerService.readGmLang(GMLangConstants.FMT_WRONG));
//						resList.add(userPrizeRes);
//						continue;
//					}
//					String rowInfo = cu.getRowInfo(i) + " ";
//					if (StringUtils.isBlank(rowInfo)) {
//						continue;
//					}
//					String[] temp = rowInfo.split(",");
//					String serId = temp[0].trim();
//					if (StringUtils.isBlank(serId)) {
//						UserPrizeRes userPrizeRes = new UserPrizeRes();
//						userPrizeRes.setResult(ExcelLangManagerService.readGmLang(GMLangConstants.SERVER_ID) + ":" + ExcelLangManagerService
//										.readGmLang(GMLangConstants.NULL));
//						resList.add(userPrizeRes);
//						continue;
//					}
//					boolean b = Pattern.matches("^([0-9]+)$", serId);
//					if (!b) {
//						UserPrizeRes userPrizeRes = new UserPrizeRes();
//						userPrizeRes.setResult(ExcelLangManagerService.readGmLang(GMLangConstants.SERVER_ID) + ":" + ExcelLangManagerService
//										.readGmLang(GMLangConstants.FMT_WRONG));
//						resList.add(userPrizeRes);
//						continue;
//					}
//					//String convertUserPrizeName = new String(temp[1].trim().getBytes("GBK"),"ISO-8859-1");
//					//String prizeName = new String(convertUserPrizeName.getBytes("ISO-8859-1"),"UTF-8");
//					List<UserPrizeRes> list = userPrizeService.addUserPrize(
//							serId, temp[1].trim(), temp[2].trim(), temp[3].trim(), temp[4].trim(), temp[5].trim(), temp[6].trim());
//					resList.addAll(list);
//				}
//			} catch (Exception e) {
//				e.printStackTrace();
//			}
//
//			cu.csvClose();
			String path = SystemConstants.UPLOAD_PATH + "\\" + file;
			InputStream fout = null;
			List<UserPrizeRes> resList = new ArrayList<UserPrizeRes>();
			try {
				fout = new FileInputStream(path);
				HSSFWorkbook wb = null;
				wb = new HSSFWorkbook(new POIFSFileSystem(fout));
//				for (Entry<String, List<LangModel>> subEntry : entry.getValue().entrySet()) {
//					String sheetName = subEntry.getKey();
//					int index = wb.getSheetIndex(sheetName);
//					if (index == -1) {
//						continue;
//					}
				HSSFSheet sheet = wb.getSheetAt(0);
			//	System.out.println(sheet.getLastRowNum());
				if(sheet.getLastRowNum() > 0){
					for (int i = 1; i <= sheet.getLastRowNum(); i++) {
						HSSFRow row = sheet.getRow(i);
//						System.out.println(PoiUtils.getStringValue(row.getCell(0)).trim() + ";" + 
//								PoiUtils.getStringValue(row.getCell(1)).trim() + ";" + 
//								PoiUtils.getStringValue(row.getCell(2)).trim() + ";" + 
//								PoiUtils.getStringValue(row.getCell(3)).trim() + ";" + 
//								PoiUtils.getStringValue(row.getCell(4)).trim() + ";" + 
//								PoiUtils.getStringValue(row.getCell(5)).trim() + ";" + 
//								PoiUtils.getStringValue(row.getCell(6)).trim() + ";" );
						String serId = PoiUtils.getStringValue(row.getCell(0));
						List<UserPrizeRes> list = userPrizeService.addUserPrize(
								serId, 
								PoiUtils.getStringValue(row.getCell(1)).trim(), 
								PoiUtils.getStringValue(row.getCell(2)).trim(), 
								PoiUtils.getStringValue(row.getCell(3)).trim(), 
								PoiUtils.getStringValue(row.getCell(4)).trim(), 
								PoiUtils.getStringValue(row.getCell(5)).trim());
						resList.addAll(list);
//					}
				}
				}
			} catch (Exception e) {
				logger.error("Unknown Exception", e);
			} finally {
				if (fout != null) {
					try {
						fout.close();
					} catch (IOException e) {
						logger.error("IOException", e);
					}
				}
			}
			mav.addObject("resList", resList);
		}
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
		String passportIds = request.getParameter("passportIds").trim();
		String item = request.getParameter("item");
		response.setCharacterEncoding("utf-8");
		if (StringUtils.isNotBlank(passportIds)) {
			String[] ids = passportIds.split(";");
			boolean passportFlag = true;
			ArrayList<String> passportArray = new ArrayList<String>();
			for (int j = 0; j < ids.length; j++) {
				passportFlag = userPrizeService.validPassportInfo(ids[j]);
				if (!passportFlag) {
					response.getWriter().print(ids[j] + ":"	+ ExcelLangManagerService.readGmLang(GMLangConstants.USERID_WRONG));
					return;
				}
				String[] passId = ids[j].split("=");
				if (StringUtils.isBlank(passId[0])) {
					response.getWriter().print(passId[0] + ":" + ExcelLangManagerService.readGmLang(GMLangConstants.USERID_NOT_NULL));
					return;
				}
				passId[0] = passId[0].trim();
				System.out.println(passId[0].trim());
				if (passportArray.contains(passId[0])) {
					passportFlag = false;
					response.getWriter().print(passId[0] + ":" + ExcelLangManagerService.readGmLang(GMLangConstants.ECHO));
					return;
				} else if (!userPrizeService.authPassport(passId[0], passId[1])) {
					passportFlag = false;
					response.getWriter().print(passId[0] + ":" + ExcelLangManagerService.readGmLang(GMLangConstants.USERID_NOT_MATCH));
					return;
				} else {
					passportArray.add(passId[0]);
				}
			}
		}
		if (StringUtils.isNotBlank(item)) {
			String[] arr = item.split(";");
			boolean itemFlag = true;
			ArrayList<String> itemArray = new ArrayList<String>();
			for (int j = 0; j < arr.length; j++) {
				itemFlag = userPrizeService.validItem(arr[j]);
				if (!itemFlag) {
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
					itemFlag = false;
					response.getWriter().print(itId[0] + ":" + ExcelLangManagerService.readGmLang(GMLangConstants.ECHO));
					return;
				} else if (!userPrizeService.authItem(itId[0])) {
					itemFlag = false;
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
