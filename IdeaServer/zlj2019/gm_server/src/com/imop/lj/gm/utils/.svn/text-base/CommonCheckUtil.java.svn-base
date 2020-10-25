package com.imop.lj.gm.utils;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;
import java.util.regex.Pattern;

import net.sf.json.JSONObject;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsItemLoadService;

/**
 * 通用检查逻辑
 * 
 * 例如：全服礼包物品和货币检查
 * 
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午1:51:15
 * @version 1.0
 */

public class CommonCheckUtil {

	public GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	/**
	 * 检查发奖是的货币和物品
	 * @param <ExcelLangManagerService>
	 * 
	 * 
	 * @param currrStr
	 * @param items
	 * @return
	 */
	public static boolean checkCurrencyAndItemStr(StringBuffer sb
			, String currencyPack, String items, final Logger logger, XlsItemLoadService xlsItemLoadService) {
		
		if(!StringUtils.isNotBlank(currencyPack) && !StringUtils.isNotBlank(items)) {
			setErroLog(sb, logger, "failure:\t empty params , currencyPack is null and item is null");
			return false;
		}
		// 货币
		if (StringUtils.isNotBlank(currencyPack)) {
			Set<String> currencySet = new HashSet<String>();
			String[] currencyStrs = currencyPack.split(";"); 
			for (String currencyStr : currencyStrs) {
				String[] curr = currencyStr.split("=");
				String currency = curr[0];
				String coinNum = curr[1];

//				if ("2".equals(currency)) {
//					if (!StringUtil.srtLDE(coinNum, gmConfig.goldNum)) {
//						setErroLog(sb, logger, "failure:\t " + ExcelLangManagerService.readGmLang(GMLangConstants.GOLD_NUM_WRONG));
//						return false;
//					}
//				} else if ("3".equals(currency)) {// 内币
//					if (!StringUtil.srtLDE(coinNum, gmConfig.sysBond)) {
//						setErroLog(sb, logger, "failure:\t " + ExcelLangManagerService.readGmLang(GMLangConstants.CURRENCY_NUM_WRONG));
//						return false;
//					}
//				} else if ("9".equals(currency)) {
//					// 礼券
//					if (!StringUtil.srtLDE(coinNum, gmConfig.giftBond)) {
//						setErroLog(sb, logger, "failure:\t " + ExcelLangManagerService.readGmLang(GMLangConstants.CURRENCY_NUM_WRONG));
//						return false;
//					}
//				} else {
//					setErroLog(sb, logger, "failure:\t "+ ExcelLangManagerService.readGmLang(GMLangConstants.CURRENCY_TYPE_ERROR));
//					return false;
//				}

				if (currencySet.contains(currency)) {
					setErroLog(sb, logger, "failure:\t " + ExcelLangManagerService.readGmLang(GMLangConstants.CURRENCY_TYPE_DUP));
					 return false;
				} 
			}
		}

		// 设置物品
		if (StringUtils.isNotBlank(items)) {
			String[] arr = items.split(";");
			boolean itemFlag = true;
			ArrayList<String> itemArray = new ArrayList<String>();
			for (int j = 0; j < arr.length; j++) {
				itemFlag = validItem(arr[j]);
				if (!itemFlag) {
					break;
				}
				String itId[] = arr[j].split("=");
				if (StringUtils.isBlank(itId[0])) {
					itemFlag = false;
					break;
				}
				itId[0] = itId[0].trim();
				if (itemArray.contains(itId[0])) {
					itemFlag = false;
					setErroLog(sb, logger, "failure:\t" + "(" + itId[0]+ ")"
									+ ExcelLangManagerService.readGmLang(GMLangConstants.ECHO));
					return false;
				} else if (!authItem(itId[0], logger, xlsItemLoadService)) {
					itemFlag = false;
					setErroLog(sb, logger, "failure:\t" + "(" + itId[0] + ")"
									+ ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_WRONG));
					return false;
				} 
			}
			if (!itemFlag) {
				setErroLog(sb, logger, "failure:\t" + ExcelLangManagerService
										.readGmLang(GMLangConstants.ITEM_NUM_WRONG));
				return false;
			}
		}
		
		return true;
	}
	
	/**
	 * 验证物品填写格式
	 *
	 * @param itemInfo
	 *            每条补偿物品信息
	 * @return 不符合返回false,反之返回true
	 */
	public static boolean validItem(String itemInfo) {
		itemInfo = itemInfo.trim();
		boolean b = Pattern.matches("^[0-9]{1,10}=[0-9]{1,3}$", itemInfo.trim());
		if (!b) {
			return false;
		}
		String itId[] = itemInfo.split("=");
//		if (StringUtil.srtGE(itId[1], gmConfig.itemNum)
//				|| StringUtil.srtLE(itId[1], 0)) {
//			return false;
//		}
		return true;
	}
	
	/**
	 * 验证物品的真实性
	 *
	 * @param itemId
	 *            物品ID
	 * @return 物品ID正确返回真,反之返回假
	 */
	public static boolean authItem(String itemId, Logger logger, XlsItemLoadService xlsItemLoadService) {
		if (StringUtils.isBlank(itemId)) {
			return true;
		}
		itemId = itemId.trim();
		logger.error(itemId);
		HashMap<String, Map<String, String>> xlsData = xlsItemLoadService
				.getXlsData();
		Map<String, String> itemMap = xlsData.get("items");
		if (itemMap!=null && itemMap.containsKey(itemId)) {
			return true;
		}
		return false;
	}
	
	/**
	 * 设置日志信息
	 * @param sb
	 * @return
	 */
	private static void setErroLog(StringBuffer sb, Logger logger, String logInfo) {
		sb.append(logInfo);
		logger.info(sb.toString());
	}
	
	public static String buildJsonStr(String currencyPack, String items) {
		JSONObject jsonObj = new JSONObject();
		// 货币
		if (StringUtils.isNotBlank(currencyPack)) {
			jsonObj.put("coin", currencyPack);
		}

		// 设置物品
		if (StringUtils.isNotBlank(items)) {
			jsonObj.put("item", items);
		}
		return jsonObj.toString();
	}
}
