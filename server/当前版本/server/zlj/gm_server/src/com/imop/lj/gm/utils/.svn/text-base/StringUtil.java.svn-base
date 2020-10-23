package com.imop.lj.gm.utils;

import java.util.HashMap;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.model.CurrencyConfig;
import com.imop.lj.gm.service.maintenance.UserPrizeService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsItemLoadService;

/**
 * GM 游戏系统<br>
 * String工具类
 *
 *
 */
public class StringUtil {

	private static Log log = LogFactory.getLog(StringUtil.class);

	/**
	 * 由字符串转换为长整类型
	 *
	 * @param num
	 *            字符串
	 * @return 转换后的长整类型
	 */
	public static long parseStringTOLong(String num) {
		try {
			return Long.valueOf(num.trim());
		} catch (Exception e) {
			log.error(e);
		}
		return -1;
	}

	/**
	 * 由字符串转换为整数类型
	 *
	 * @param num
	 *            字符串
	 * @return 转换后的整数类型
	 */
	public static int parseStringTOInt(String num) {
		try {
			return Integer.valueOf(num.trim());
		} catch (Exception e) {
			log.error(e);
		}
		return -1;
	}

	/**
	 * num 小于等于 desNum
	 * @param num
	 * @param desNum
	 * @return 满足返回true, 反之返回false
	 */
	public static boolean srtLDE(String num,int desNum) {
		try {
			int srcNum = Integer.valueOf(num.trim());
			if (srcNum <= desNum && srcNum > 0) {
				return true;
			}
		} catch (Exception e) {
			log.error(e);
		}
		return false;
	}
	/**
	 * num 小于 desNum
	 * @param num
	 * @param desNum
	 * @return 满足返回true, 反之返回false
	 */
	public static boolean srtLE(String num,int desNum) {
		try {
			int srcNum = Integer.valueOf(num.trim());
			if(srcNum<desNum){
				return true;
			}
		} catch (Exception e) {
			log.error(e);
		}
		return false;
	}

	/**
	 * num 大于 desNum
	 * @param num
	 * @param desNum
	 * @return 满足返回true, 反之返回false
	 */
	public static boolean srtGE(String num,int desNum) {
		try {
			int srcNum = Integer.valueOf(num.trim());
			if(srcNum > desNum){
				return true;
			}
		} catch (Exception e) {
			log.error(e);
		}
		return false;
	}

	/**
	 * 数据库字段转化为页面数据显示用
	 * @param str	参数
	 * @param type  类型
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public static String disInfo(String str, int type) {

		if (str == null)
			return "";
		if (str.trim().length() == 0)
			return "";
		String res = "";
		Map<String, Map> m = Mask.init();
		String[] arr = str.split(";");
		for (String s : arr) {
			String entity = "";
			String value = "";
			if (s.contains("=")){
				String [] info = s.split("=");
				if(info.length<2){
					return "";
				}
				entity = info[0].trim();
				value = info[1].trim();
			} else if (type == 1 || type == 3) {
				entity = "0";
			}
			HashMap <String, Map<String, String>>  xlsData = XlsItemLoadService.getStaticXlsData();
			switch (type) {
			case 1: {
				// FIXME 增加类型，从货币配置中读取
				CurrencyConfig cc = UserPrizeService.getCurrencyConfigMap().get(Integer.parseInt(entity));
				if(cc!=null){
					res += cc.getName() + "  "
					+ value + "| ";
				}else{
					res += entity + "  "
					+ value + "| ";
				}
				break;
			}
			case 2: {
				String itemName =  xlsData.get("items").get(entity);
				if(itemName==null){
					itemName = "";
				}
				res+= itemName+"("+entity+")"+value+ExcelLangManagerService.readGmLang(GMLangConstants.GE)+";";
				break;
			}
			case 3: {
				String petName = xlsData.get("pets").get(entity);
				if(petName==null){
					petName = "";
				}
				res+= petName +"("+entity+")"+value+ExcelLangManagerService.readGmLang(GMLangConstants.GRADE);
				break;
			}
			}
		}
		return res;
	}


	/**
	 * 过滤公告内容的font标签的size属性,页面显示用
	 * @param content 公告内容
	 * @return  公告内容
	 */
	public static String filterContent(String content){
		String regLink = "SIZE=\".*?\"";
		Pattern plink = Pattern.compile(regLink);
		Matcher _matcherLink = plink.matcher(content);
		while(_matcherLink.find()){
			String key = _matcherLink.group();
			content = content.replace(key, "");
		}
		return content;
	}
}
