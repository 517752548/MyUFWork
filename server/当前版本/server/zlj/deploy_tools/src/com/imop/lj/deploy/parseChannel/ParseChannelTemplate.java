package com.imop.lj.deploy.parseChannel;

import java.io.File;

import org.apache.commons.lang.StringUtils;

import com.imop.lj.deploy.config.DeployConfig;
import com.imop.lj.deploy.config.ServerConfig;

/**
 * 根据配置的channelName取对应平台的模板
 * 
 * 如果没有平台名字，默认是人人平台
 *  
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年1月7日 上午11:18:47
 * @version 1.0
 */

public class ParseChannelTemplate {
	
	
	/**
	 * 取配置表中的deployConfig中channelName （平台名称） 取模板的跟目录
	 * 
	 * @param serverConfig
	 * @param deployConfig
	 * @return
	 */
	public static String getTemplateRootPathByChannelName(String rootPath, DeployConfig deployConfig) {
		
		String path = "";
		String templateRootPath = rootPath;
		if( null == rootPath ||  null == deployConfig) {
			return "";
		} else {
			String channelName = deployConfig.getChannelName().trim();
			if(!StringUtils.isEmpty(channelName)) {
				channelName = channelName.toLowerCase();
				
				for(ChannelNameEnum channelNameEnum : ChannelNameEnum.values()) {
					if(channelName.equals(channelNameEnum.getName().toLowerCase()) ) {
						if(!StringUtils.isEmpty(channelNameEnum.getPath())) {
							path = templateRootPath + File.separator + channelNameEnum.getPath()
									+ File.separator;
							break;
						}
					}
				}
			}
		}
		if ("".equals(path)) {
			path = templateRootPath + File.separator + ChannelNameEnum.CN_RENREN.getPath()
					+ File.separator;
		}
		// 格式化path
		formatePath(path);
		
		System.out.println("ParseChannelTemplate. getTemplateRootPathByChannelName=" + path);
		return path;
	}
	/**
	 * 根据配置表中的 deployConfig中channelName （平台名称） 取模板目录
	 * 
	 * @param serverConfig-----模板路径
	 * @param deployConfig
	 * @return
	 */
	public static String getTemplateByChannelName(String rootPath, ServerConfig serverConfig, DeployConfig deployConfig) {
		String serverConfigTemplatePackage = serverConfig != null ? serverConfig.getTemplatePackage() : "";
		String path = getTemplateRootPathByChannelName(rootPath, deployConfig) + serverConfigTemplatePackage;
		// 格式化path
		formatePath(path);
		
		System.out.println("ParseChannelTemplate. getTemplateByChannelName=" + path);
		return path;
	}

	/**
	 * 格式化路径以"/"结束
	 * @param path
	 */
	private static void formatePath(String path) {
		
		if(path.contains("\\")) {
			path = path.replace("\\", File.separator);
		}
		
		if(!path.endsWith(File.separator)) {
			path = path + File.separator;
		}
	}
}
