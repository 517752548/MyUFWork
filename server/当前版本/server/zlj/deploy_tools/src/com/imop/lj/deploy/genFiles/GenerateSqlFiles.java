package com.imop.lj.deploy.genFiles;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.Reader;
import java.io.Writer;
import java.nio.charset.Charset;

import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;

import com.imop.lj.deploy.Deploy;
import com.imop.lj.deploy.config.DeployConfig;
import com.imop.lj.deploy.config.VersionConfig;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年5月8日 下午12:07:45
 * @version 1.0
 */

public class GenerateSqlFiles {

	private static String initSqlFileName = "db_init.sql";
	private static String updateSqlFileName = "db_update.sql";
	private static String REPLACE = "${server_id}";
	
	private static String SOURCE_SQL_PATH = "";

	/**
	 * 生成db_init.sql 和 db_update.sql2个文件
	 * 
	 * @param outRoot	生成输出路径
	 * @param serverDBId	生成的服务器名称
	 * @param versionStr	db_update.sql 版本号
	 */
	public static void generateSqlFiles(VersionConfig versionConfig, File outRoot, DeployConfig deployConfig, String _templateRootPath) {
		try {
//			SOURCE_SQL_PATH = rootPath + Deploy.SQL_ROOT + File.separator;
			/**
			 * 生成db_init.sql
			 */
			genInitSql(versionConfig, outRoot, deployConfig, _templateRootPath);
			/**
			 * 生成更新文件
			 */
			genUpdateSqlFils(versionConfig, outRoot, deployConfig, _templateRootPath);
		} catch(Exception ex) {
			ex.printStackTrace();
		}
	}
	
	
	private static void genInitSql(VersionConfig versionConfig, File outRoot, DeployConfig deployConfig, String _templateRootPath) {
		try {
			File fileDir = new File(outRoot + File.separator + Deploy.SQL_ROOT);
			if(!fileDir.exists()) {
				fileDir.mkdirs();	
				fileDir.setWritable(true);
			}
			
			// 创建目标文件
			File targetFile = new File(fileDir.getPath() + File.separator + initSqlFileName);
			if(!targetFile.exists()) {
				targetFile.createNewFile();
			}
			
			String _template = _templateRootPath + File.separator + "db_init.sql";
			
			VelocityContext context = new VelocityContext();
			
			Writer w = new OutputStreamWriter(new FileOutputStream(targetFile), "UTF-8");
			context.put("deployConfig", deployConfig);
			context.put("versionConfig", versionConfig);
			context.put("server_id", deployConfig.getPrefixServerName());
			Velocity.mergeTemplate(_template, "UTF-8", context, w);
			w.close();
			
//			File tempFile = new File(SOURCE_SQL_PATH + initSqlFileName);
//			// 原始目录
//			Reader sourceReader = new InputStreamReader(new FileInputStream(tempFile), Charset.forName("UTF-8"));
//			// 创建文件
//			generateFile(sourceReader, targetFile, serverDBId);
			System.out.println("生成 db_init.sql 完成");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	
	private static void genUpdateSqlFils(VersionConfig versionConfig, File outRoot, DeployConfig deployConfig, String _templateRootPath) {
		try {
			// 创建目标文件
			File fileDir = new File(outRoot	+ File.separator + Deploy.SQL_ROOT);
			if(!fileDir.exists()) {
				fileDir.mkdirs();	
				fileDir.setWritable(true);
			}
			File targetFile = new File(fileDir.getPath() + File.separator + updateSqlFileName );
			if(!targetFile.exists()) {
				targetFile.createNewFile();
			}
//			// 原始目录路径
////			VelocityContext context = new VelocityContext();
////			Writer w = new OutputStreamWriter(new FileOutputStream(targetFile), "UTF-8");
////			context.put("deployConfig", deployConfig);
////			context.put("versionConfig", versionConfig);
////			context.put("getScript", "$.getScript(qqScriptUrl);");
////			Velocity.mergeTemplate(configTemplate, "UTF-8", context, w);
//
//			// 按行读取文件查找替换的字符
//			Reader sourceReader = new InputStreamReader(new FileInputStream(SOURCE_SQL_PATH + updateSqlFileName), Charset.forName("UTF-8"));
//			// 创建文件
//			generateFile(sourceReader, targetFile, serverDBId);
			
			String _template = _templateRootPath + File.separator + "db_update.sql";
			
			VelocityContext context = new VelocityContext();
			
			Writer w = new OutputStreamWriter(new FileOutputStream(targetFile), "UTF-8");
			context.put("deployConfig", deployConfig);
			context.put("versionConfig", versionConfig);
			context.put("server_id", deployConfig.getPrefixServerName());
			System.out.println(deployConfig.getPrefixServerName());
			Velocity.mergeTemplate(_template, "UTF-8", context, w);
			w.close();
			
			System.out.println("生成 db_update.sql 完成");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private static void generateFile(Reader resourceReader, File targetFile, String serverName) {
		try {
			FileWriter targetWriter = new FileWriter(targetFile);
			BufferedWriter bw = new BufferedWriter(targetWriter);
			// 按行读取文件查找替换的字符
			BufferedReader br = new BufferedReader(resourceReader);
			String lineStr = null;
			while ((lineStr = br.readLine()) != null) {
				// 替换数据库名
				if(lineStr.contains(REPLACE)) {
					lineStr = lineStr.replace(REPLACE, serverName);
				} 
				bw.write(lineStr);
				bw.write("\n");
			}
			bw.close();
			targetWriter.close();
			br.close();
			resourceReader.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
}
