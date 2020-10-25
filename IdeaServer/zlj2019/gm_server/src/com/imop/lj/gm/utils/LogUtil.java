package com.imop.lj.gm.utils;

import java.lang.annotation.Annotation;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.persistence.Column;

import org.slf4j.Logger;

import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.LoginUserService;

/**
 * 日志记录辅助工具
 *
 * @author lin fan
 * @version 2010-4-27
 */
public class LogUtil {

	private static final Pattern GETTER_METHOD = Pattern.compile("get(.+)");
	/**
	 * 记录 info 级别日志
	 *
	 * @param logger
	 * @param info
	 * @param obj
	 */
	public static void logInfo(Logger logger, String info) {
		   LoginUser loginUser = LoginUserService.getLoginUser();
		   String message = "RegionId:"+loginUser.getLoginRegionId()+"\tServerId:"+loginUser.getLoginServerId()+
		   "\tOperator:"+loginUser.getUsername()+"\t"+info;
		   logger.info(message);
	}

	/**
	 * 记录bean 字段
	 * @param o 对象
	 * @param c
	 * @return bean 记录属性字符串
	 */
	@SuppressWarnings("unchecked")
	public static String logBeanInfo(Object o,Logger logger) {
		String info = "[";
		Class  c =o.getClass();
		Method[] _allMethods = c.getMethods();
		try {
			for (Method _method : _allMethods) {
				String _name = _method.getName();
				Matcher _matcher = GETTER_METHOD.matcher(_name);
				if (!_matcher.matches()) {
					continue;
				}
				Annotation a = _method.getAnnotation(Column.class);
				if(a==null){
					continue;
				}
				String _fieldName = _matcher.group(1);
				_fieldName = _fieldName.substring(0, 1).toLowerCase()
						+ _fieldName.substring(1);
				Field ll = c.getDeclaredField(_fieldName);
				ll.setAccessible(true);
				Object value = ll.get(o);
				info = info + _fieldName + ":" + value + ";";
			}
		} catch (IllegalArgumentException e) {
			logger.error(ErrorsUtil.error(LogUtil.class.toString(), "logBeanInfo", e.getMessage()));
			e.printStackTrace();
		} catch (SecurityException e) {
			logger.error(ErrorsUtil.error(LogUtil.class.toString(), "logBeanInfo", e.getMessage()));
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			logger.error(ErrorsUtil.error(LogUtil.class.toString(), "logBeanInfo", e.getMessage()));
			e.printStackTrace();
		} catch (Exception e) {
			logger.error(ErrorsUtil.error(c.toString(), "logBeanInfo", e.getMessage()));
			e.printStackTrace();
		}
		info = info + "]";
		return info;
	}





}
