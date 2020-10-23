package com.imop.lj.tools.data;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.io.FileUtils;

public class GenClientCfgFiles {

	public static final String tplPath = "/tpl.txt";
	public static final String tplDBPath = "/tplDB.txt";
	public static final String srcPath = "/1.txt";
//	public static final String genPath = "E:/uuu/client/trunk/u3u2/Assets/Scripts/app/db/cfg/";
	
	
	@SuppressWarnings("unchecked")
	public static void main(String[] args) throws IOException {
		//生成路径在配置中设置
		String genPath = args[0];
		if (genPath == null || genPath.isEmpty()) {
			System.out.println("failed!genPath is null!");
			return;
		}
		
		//拿到文件名
		List<String> array = new ArrayList<String>();
		List<String> lst0 = FileUtils.readLines(new File(System.getProperty("user.dir")+srcPath));
		for (int i = 0; i < lst0.size(); i += 2) {
			array.add(lst0.get(i).substring(0, lst0.get(i).length() - 5));
		}
		//替换tpl
		List<String> lst = FileUtils.readLines(new File(System.getProperty("user.dir")+tplPath));
		if(!lst.isEmpty()){
			for (int i = 0; i < array.size(); i++) {
				for (int j = 0; j < lst.size(); j++) {
				
					if(lst.get(j).contains("public")){
						lst.remove(j);
						lst.add(j, "    public class "+array.get(i)+" : "+	array.get(i)+"VO");
					}
				}
				//输出
				FileUtils.writeLines(new File(genPath+array.get(i)+".cs"), lst);
			}
		}
		
		//替换 tplDB
		List<String> lst2 = FileUtils.readLines(new File(System.getProperty("user.dir")+tplDBPath));
		if(!lst2.isEmpty()){
			for (int i = 0; i < array.size(); i++) {
				for (int j = 0; j < lst.size(); j++) {
					if(lst2.get(j).contains("public")){
						lst2.remove(j);
						lst2.add(j, "    public class "+array.get(i)+"DB"+" : "+	array.get(i)+"DBBase");
					}
				}
				//输出
				FileUtils.writeLines(new File(genPath+array.get(i)+"DB"+".cs"), lst2);
			}
		}
		
		System.out.println("done");
	}
}
