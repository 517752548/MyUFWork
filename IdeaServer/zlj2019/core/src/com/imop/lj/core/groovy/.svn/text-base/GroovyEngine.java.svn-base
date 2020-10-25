package com.imop.lj.core.groovy;

import groovy.lang.GroovyClassLoader;
import groovy.lang.GroovyObject;

import java.io.File;

/**
 * 动态调用java代码
 *
 * @author xxxxxx
 *
 */
public class GroovyEngine {

	/**
	 * 执行对应的文件
	 * @param groovyFile 文件路径
	 * @return 执行结果
	 */
	public static String runFile(String groovyFile) {
		return run(0, groovyFile);
	}

	/**
	 * 执行对应的代码
	 * @param code 代码
	 * @return 执行结果
	 */
	public static String run(String code) {
		return run(1, code);
	}

	/**
	 *
	 * @param type 0 文件 ，1 代码
	 * @param param 文件路径或者代码
	 * @return 执行结果，错误的时候返回error
	 */
	public static String run(int type,String param) {
		String result = "";
		ClassLoader parent =  GroovyEngine.class.getClassLoader();
		GroovyClassLoader loader = new GroovyClassLoader(parent);
		Class<?> groovyClass;
		try {
			if (type == 1) {
				groovyClass = loader.parseClass(param);
			} else {
				groovyClass = loader.parseClass(new File(param));
			}
			GroovyObject groovyObject = (GroovyObject) groovyClass.newInstance();
			Object[] args = {};
			Object obj = groovyObject.invokeMethod("run", args);
			result = "excute ok!" + obj;
		} catch (Exception e) {
			result = "excute error:" + e.getMessage();
			e.printStackTrace();
		}

		return result;
	}

}
