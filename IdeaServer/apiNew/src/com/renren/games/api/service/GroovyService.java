package com.renren.games.api.service;

import groovy.lang.Binding;
import groovy.lang.GroovyShell;

import org.slf4j.Logger;

import com.renren.games.api.core.Loggers;

/**
 * groovy 动态更改类信息
 * 
 * @author yuanbo.gao
 *
 */
public class GroovyService {
	Logger logger = Loggers.platformlocalLogger;
	
	public static final String GLOBALS_PKG_NAME = "";
	
	protected GroovyShell groovyShell;
	protected Binding binding;
	
	public GroovyService(){
		binding = new Binding();
		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		groovyShell = new GroovyShell(classLoader, binding);
	}
	
	public String execCode(String uuid,String url,String strCode) {
		String gs = GLOBALS_PKG_NAME + strCode;
		logger.info(uuid + ":" + "url=" + url + ":");
		logger.info(strCode);
		Object ret = groovyShell.evaluate(gs);
		return ret == null ? "[null]" : ret.toString();
	}
}
