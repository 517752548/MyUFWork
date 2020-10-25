package com.imop.lj.gm.utils;
/**
 * 错误信息格式类
 * @author linfan
 *
 */
public class ErrorsUtil {


	/**
	 * 构造一个标准格式的错误信息
	 *     [errorCode] [origin] [param]
	 * 例：[ITEM.ERR.NOEXIST] [#GS.ItemLogicalProcessor.onRepair] [bagId:1001,bagIndex:2]
	 *
	 * @param className  类名
	 *
	 * @param method
	 *             方法名
	 * @param param
	 *             需要记录实时数据
	 * @return
	 */
	public static String error(String className, String method, String param) {
		StringBuilder _errorStr = new StringBuilder("[").append(className).append("] [method:").append(method).append("]");
		if(param != null && param.length() > 0) {
			_errorStr.append(" [reason:").append(param).append("]");
		}
		return _errorStr.toString();
	}

	/**
	 * 构造一个标准格式的错误信息
	 * @param c 类
	 * @param method 方法名
	 * @param e 异常e
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public static String error(Class c, String method,  Throwable e) {
		StringBuilder _errorStr = new StringBuilder("[").append(c.toString()).append("] [method:").append(method).append("]");
		_errorStr.append(" [reason:").append(e).append("]");

		return _errorStr.toString();
	}

}
