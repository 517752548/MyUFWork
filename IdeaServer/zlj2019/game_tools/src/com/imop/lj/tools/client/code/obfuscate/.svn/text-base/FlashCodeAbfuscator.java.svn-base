package com.imop.lj.tools.client.code.obfuscate;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import com.imop.lj.core.util.MD5Util;

public class FlashCodeAbfuscator {

	Map<String, String> folderKeyMap = new HashMap<String, String>();

	Map<String, String> fileNameMap = new HashMap<String, String>();

	String[] ingoreAry = { "com.renren.rmeta", "com.greensock", "flash.", "adobe.", "air.", "fl.", "flashx.","mx." };

	public static File rootFile = new File("D:\\workspace\\client\\lj\\LongJiangWeb\\src");

	public static File obfuscateRootFile = new File("D:\\workspace\\client\\lj\\LongJiangWeb\\obfuscated_java_src1");

	public List<File> fileList = new ArrayList<File>();

	private List<String> ingoreNamesArray = new ArrayList<String>();

	public FlashCodeAbfuscator(String baseDir) {
		rootFile = new File(baseDir);
		obfuscateRootFile = new File(rootFile.getParent() + File.separator + "obfuscated_src");
		this.delFile(obfuscateRootFile);
		this.init();
	}

	public FlashCodeAbfuscator(String baseDir, String obBaseDir) {
		rootFile = new File(baseDir);
		obfuscateRootFile = new File(obBaseDir);
		this.delFile(obfuscateRootFile);
		this.init();
	}

	/**
	 * 初始化
	 */
	public void init() {
		this.randomKey();
	}

	public void execute() throws Exception {
		this.getFolders(rootFile);
		this.obfuscate(fileList);
	}

	/**
	 * 获得要混淆的文件，先混淆文件名
	 * 
	 * @param file
	 * @throws Exception
	 */
	public void getFolders(File file) throws Exception {
		File[] files = file.listFiles();
		for (File tempFile : files) {
			if (file.getAbsolutePath().indexOf(".svn") == -1) {
				if (tempFile.isDirectory()) {
					createObfuscatedFolder(tempFile);
					getFolders(tempFile);
				} else if ("config.xml".equalsIgnoreCase(tempFile.getName()) || tempFile.getName().toLowerCase().endsWith(".as")) {
					File newFile = null;
					if (tempFile.getName().toLowerCase().endsWith(".as")) {
						String fileName = tempFile.getName().substring(0, tempFile.getName().length() - 3);
						if ("CreateRole".equals(fileName) || "Login".equals(fileName) || "webMain".equals(fileName)) {
							newFile = new File(createObfuscatedFolder(tempFile.getParentFile()) + File.separator + fileName + ".as");
						} else {
							newFile = new File(createObfuscatedFolder(tempFile.getParentFile()) + File.separator + "R"
									+ MD5Util.createMD5String(fileName) + ".as");
						}
						fileList.add(newFile);
						// trace(newFile.name);
						System.out.println("载入总数:" + fileList.size());
						fileNameMap.put(newFile.getName().split("\\.as")[0], fileName);
					} else {
						newFile = new File(createObfuscatedFolder(tempFile.getParentFile()) + File.separator + tempFile.getName());
					}
					this.copyFile(tempFile, newFile);

					System.out.println("[Copy]" + tempFile + " copy to : " + newFile);
				} else {
					System.out.println("[ERROR]!!!!!!!!!!!!!!忽略的文件" + tempFile.getAbsolutePath());
					throw new Exception("[getFolders]中src应该不会含有非as的文件" + tempFile.getAbsolutePath());
				}
			} else {
				System.out.println("[ERROR]!!!!!!!!!!!!!!忽略svn文件" + tempFile.getAbsolutePath());
			}
		}
	}

	/**
	 * copy文件
	 * 
	 * @param oldFile
	 * @param newFile
	 * @throws Exception
	 */
	public void copyFile(File oldFile, File newFile) throws Exception {
		InputStream is = null;
		FileOutputStream fos = null;
		try {
			if (oldFile.exists()) {
				is = new FileInputStream(oldFile);
				fos = new FileOutputStream(newFile);
				byte[] buffer = new byte[1024];
				int byteread = 0;
				while ((byteread = is.read(buffer)) != -1) {
					fos.write(buffer, 0, byteread);
				}
			}
		}catch(Exception e){
			e.printStackTrace();
			throw new Exception("[copyFile] 失败,源文件名:" + oldFile.getName() + ";" + "新文件:" + newFile.getName());
		}  finally {
			if (is != null) {
				is.close();
			}
			if (fos != null) {
				fos.close();
			}
		}
	}

	/**
	 * 删除文件
	 * 
	 * @param file
	 */
	public void delFile(File file) {
		if (file.isDirectory()) {
			File[] files = file.listFiles();
			for (File tempFile : files) {
				delFile(tempFile);
			}
		}
		System.out.println("[Del]:" + file);
		file.delete();
	}

	/**
	 * 数字加密
	 */
	public void randomKey() {
		String[] temp_ar = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
				"Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
				"y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
		List<String> ary_aA0 = Arrays.asList(temp_ar);
		List<String> ary_aA0_obfus = new ArrayList<String>(Arrays.asList(temp_ar));
		Collections.shuffle(ary_aA0_obfus);

		for (int i = 0; i < ary_aA0.size(); i++) {
			folderKeyMap.put(ary_aA0.get(i), ary_aA0_obfus.get(i));
		}
	}

	/**
	 * 生成混淆目录文件
	 * 
	 * @param file
	 * @return
	 */
	public File createObfuscatedFolder(File file) {
		String rootPath = rootFile.getAbsolutePath() + File.separator;
		// 去掉头
		String filePath = file.getAbsolutePath().substring(rootPath.length() - 1);
		String[] pathAry = filePath.split("\\" + File.separator);
		String createPath = "";
		for (String path : pathAry) {
			String newPath = getObfuscatedFolderName(path);
			createPath += newPath + File.separator;
		}
		File createFile = new File(obfuscateRootFile.getAbsolutePath() + File.separator + createPath);
		if (!createFile.exists()) {
			createFile.mkdirs();
		}
		return createFile;
	}

	/**
	 * 混淆文件
	 * @throws Exception 
	 * 
	 */
	public void obfuscate(List<File> fileList) throws Exception {
		Map<File, String> writedFiles = new HashMap<File, String>();
		for (File file : fileList) {
			try {
				String content = obfuscateOne(file);
				writedFiles.put(file, content);
			} catch (Exception e) {
				e.printStackTrace();
				throw new Exception("[obfuscate]混淆文件出错,文件名:" + file.getName());
			}
		}
		
		for(Entry<File,String> entry : writedFiles.entrySet()){
			this.writeTxtFile(entry.getKey(), entry.getValue());
		}
	}

	/**
	 * 读取文件
	 * 
	 * @param file
	 * @return
	 * @throws Exception
	 */
	public String readTxtFile(File file) throws Exception {
		BufferedReader br = null;
		StringBuilder sb = new StringBuilder();
		try {
			br = new BufferedReader(new InputStreamReader(new FileInputStream(file), "UTF-8"));
			String readLine = "";
			while ((readLine = br.readLine()) != null) {
				sb.append(readLine + "\n");
			}
		} catch(Exception e){
			e.printStackTrace();
			throw new Exception("[readTxtFile] 失败,文件名:" + file.getName());
		} finally {
			if (br != null) {
				br.close();
			}
		}
		return sb.toString();
	}

	/**
	 * 混淆单个文件
	 * 
	 * @param file
	 */
	public String obfuscateOne(File file) throws Exception{
		String outputStr = this.readTxtFile(file);

		// var notesSAry:Array = outputStr.split("\n");
		// String[] notesSAry = content.split("\n");

		// StringBuilder sb = new StringBuilder();

		// 干掉注释//
		String[] notesSAry = outputStr.split("\n");
		outputStr = "";
		for (int i = 0; i < notesSAry.length; i++) {
			String tempStr = notesSAry[i];
			int tempIndex = tempStr.indexOf("//");

			if (tempIndex > 0 && tempIndex != -1) {
				if (tempIndex >= 5) {
					if (!"http:".equalsIgnoreCase(tempStr.substring(tempIndex - 5, tempIndex))) {
						if (tempStr.indexOf("/*") != -1 && tempStr.indexOf("/*") < tempIndex) {
						} else if (tempStr.indexOf("*/") != -1 && tempStr.indexOf("*/") < tempIndex) {

						} else {
							tempStr = tempStr.substring(0, tempIndex) + "\n";
						}
					}
				} else {
					tempStr = tempStr.substring(0, tempIndex) + "\n";
				}
			} else if (tempIndex == 0) {
				tempStr = "";
			}
			outputStr += tempStr + "\n";
		}

		// 干掉注释/**/
		String[] notesAry = outputStr.split("\\/\\*");
		if (notesAry.length > 1) {
			outputStr = notesAry[0];
			for (int i = 1; i < notesAry.length; i++) {
				String[] tempNotesAry = notesAry[i].split("\\*\\/");
				for (int j = 1; j < tempNotesAry.length; j++) {
					outputStr += tempNotesAry[j];
				}
			}
		}

		String currentClassName = null;
		try {
			currentClassName = outputStr.split("class ")[1].split(" ")[0].split("\\{")[0].split("\n")[0].split("\r")[0];
		} catch (Exception e) {
			currentClassName = outputStr.split("interface ")[1].split(" ")[0].split("\\{")[0].split("\n")[0].split("\r")[0];
		}
		System.out.println("currentClassName:" + currentClassName);

		String tempReplaceStr;

		String[] ary = outputStr.split("import ");
		String tempStr;
		// 导入类
		ingoreNamesArray = new ArrayList<String>();
		Map<String, Boolean> replaceMap = new HashMap<String, Boolean>();
		if (ary.length > 1) {
			for (int i = 0; i < ary.length; i++) {
				if (ary[i].indexOf(";") > -1) {
					tempStr = ary[i].split(";")[0];
					String className = testIngore(tempStr);
					if (className != null) {
						InputInfo obj = getNewImport(tempStr);
						if ("*".equalsIgnoreCase(className)) {
							String[] tempStarAry = outputStr.split(tempStr);
							if (tempStarAry.length > 2) {
								throw new Exception("[obfuscateOne]解析文件有问题" + file.getName());
							}
							outputStr = tempStarAry[0] + obj.importPath + tempStarAry[1];
						} else {
							outputStr = outputStr.replaceAll(tempStr + ";", obj.getImportPath() + ";");
						}
						if ("*".equalsIgnoreCase(className)) {
							String url = tempStr.replaceAll("\\.", "\\" + File.separator);
							File importStrFile = new File(rootFile.getAbsolutePath() + File.separator + url.substring(0, url.length() - 1));
							File[] tempFileAry = null;
							if (importStrFile.exists()) {
								tempFileAry = importStrFile.listFiles();
							}
							if (tempFileAry != null && tempFileAry.length > 0) {
								String tempClassName = null;
								for (int importIndex = 0; importIndex < tempFileAry.length; importIndex++) {
									File tempStarFile = tempFileAry[importIndex];
									if (tempStarFile.getName().toLowerCase().endsWith(".as")) {
										tempClassName = tempStarFile.getName().substring(0, tempStarFile.getName().length() - 3);
										if (outputStr.indexOf(tempClassName) != -1) {
											replaceMap.put(tempClassName, true);
										}

									}
								}
							}
						} else {
							// tempReplaceStr =
							// replaceClassName(outputStr,className);
							replaceMap.put(className, true);
						}
					}
				}
			}
			for (Entry<String, Boolean> entry : replaceMap.entrySet()) {
				tempReplaceStr = replaceClassName(outputStr, entry.getKey());
				if (tempReplaceStr.length() > 0) {
					outputStr = tempReplaceStr;
				}
			}
		}

		tempReplaceStr = replaceClassName(outputStr, currentClassName);
		if (tempReplaceStr.length() > 0) {
			outputStr = tempReplaceStr;
		}

		// 包名
		String[] packageAry = outputStr.split("package ");
		if (packageAry.length > 1) {
			packageAry = packageAry[1].split("\\{");
			String newPackageName = getNewPackage(packageAry[0]);
			outputStr = outputStr.replace(packageAry[0], newPackageName);
		}

		// 同级目录类名
		File[] fileParentAry = file.getParentFile().listFiles();
		for (int i = 0; i < fileParentAry.length; i++) {
			File tempFile = fileParentAry[i];
			if (!tempFile.isDirectory() && tempFile.getName().toLowerCase().endsWith(".as") && !tempFile.getName().equalsIgnoreCase(file.getName())) {

				Boolean needReplace = true;
				String tempName = tempFile.getName().substring(0, tempFile.getName().length() - 3);
				for (int j = 0; j < ingoreNamesArray.size(); j++) {
					if (ingoreNamesArray.get(j).equals(fileNameMap.get(tempName))) {
						needReplace = false;
					}
				}
				if (needReplace) {
					tempReplaceStr = replaceClassName(outputStr, fileNameMap.get(tempName));
					if (tempReplaceStr.length() > 0) {
						outputStr = tempReplaceStr;
					}
				}

			}
		}

		System.out.println("----------------");

		String uiReg = "com.renren.longjiang.app.ui";
		String newUIImport = getNewPackage("com.renren.longjiang.app.ui");
		outputStr = outputStr.replaceAll(uiReg, newUIImport);
		return outputStr;
		// this.writeTxtFile(file, outputStr);
	}

	public void writeTxtFile(File file, String content) throws Exception {
		FileWriter fw = null;
		try {
			fw = new FileWriter(file);

			fw.write(content);
			fw.flush();
		} catch(Exception e){
			e.printStackTrace();
			throw new Exception("[writeTxtFile] 失败,文件名:" + file.getName());
		} finally {
			if (fw != null) {
				fw.close();
			}
		}
	}

	protected String replaceClassName(String str, String className) {
		Pattern pattern = Pattern.compile("[0-9a-zA-Z_]");
		if ("Login".equals(className) || "CreateRole".equals(className) || "webMain".equals(className) || "*".equals(className)) {
			return "";
		}
		String[] ary = str.split(className);
		String str1 = "";

		for (int i = 0; i < ary.length; i++) {
			String tempName = "";
			if (i + 1 < ary.length) {
				Matcher matcher1 = pattern.matcher(ary[i].substring(ary[i].length() - 1));
				Matcher matcher2 = pattern.matcher(ary[i + 1].substring(0, 1));
				if (!matcher1.find() && !matcher2.find()) {
					tempName = getMD5ClassName(className);
				} else {
					tempName = className;
				}
			}
			str1 += ary[i] + tempName;
		}
		return str1;
	}

	/**
	 * 测试是否忽略
	 * 
	 * @return
	 * 
	 */
	protected String testIngore(String str) {
		String[] ary = str.split("\\.");
		if (ary.length <= 0) {
			return null;
		}
		for (int i = 0; i < ingoreAry.length; i++) {
			if (str.indexOf(ingoreAry[i]) == 0) {
				ingoreNamesArray.add(ary[ary.length - 1]);
				return null;
			}
		}

		return ary[ary.length - 1];
	}

	/**
	 * 获得新导入路径
	 * 
	 * @param className
	 * 
	 */
	protected InputInfo getNewImport(String importPath) {
		String str = "";
		String[] ary = importPath.split("\\.");
		for (int i = 0; i < ary.length - 1; i++) {
			str += (getObfuscatedFolderName(ary[i])) + ".";
		}
		String fileName = null;
		if (ary.length > 1) {
			if ("*".equals(ary[ary.length - 1])) {
				fileName = "*";
			} else {
				fileName = getMD5ClassName(ary[ary.length - 1]);
			}
		}
		str += fileName;
		InputInfo info = new InputInfo(fileName, str);
		return info;
	}

	/**
	 * 获得包名
	 * 
	 * @param packagePath
	 * @return
	 * 
	 */
	protected String getNewPackage(String packagePath) {
		if (packagePath.length() > 1) {

			String newPath = "";
			String[] ary = packagePath.split("\\.");

			for (int i = 0; i < ary.length; i++) {
				if (i < ary.length - 1) {
					newPath += getObfuscatedFolderName(ary[i]) + ".";
				} else {
					newPath += getObfuscatedFolderName(ary[i]);
				}
			}
			return newPath;
		}
		return "";
	}

	protected String getMD5ClassName(String str) {
		return "R" + MD5Util.createMD5String(str);
	}

	/**
	 * 混淆名字
	 * 
	 * @param name_str
	 * @return
	 */
	protected String getObfuscatedFolderName(String name_str) {
		if (name_str == null || "".equalsIgnoreCase(name_str)) {
			return "";
		}
		String str = "r";
		for (char c : name_str.toCharArray()) {
			if (folderKeyMap.containsKey("" + c)) {
				str += folderKeyMap.get("" + c);
			} else {
				str += c;
			}
		}
		return str;
	}

	public static void main(String[] args) {
		FlashCodeAbfuscator abfuscator = null;
		try {
			 if (args.length == 1) {
				 abfuscator = new FlashCodeAbfuscator(args[0]);
			 }else if(args.length == 2){
				 abfuscator = new FlashCodeAbfuscator(args[0],args[1]);
			 }
			 else{
				 throw new RuntimeException("参数不合法");
			 }
//			String baseDir = "D:\\workspace\\client\\lj\\LongJiangWeb\\src";
//			abfuscator = new FlashCodeAbfuscator(baseDir);
			abfuscator.execute();
		} catch (Exception e) {
			e.printStackTrace();
		}

		// String b = "classA con.aga.dadfa" + "\n";

		// flashCodeAbfuscator.delFile(obfuscateRootFile);
		// String a = "classA con.aga.dadfa" + "\n";
		// a += "classB con.aga.dadfa" + "\n";
		// String[] s = a.split("\n");
		// System.out.println(s);
		// String[] as = a.split("\\.");
		// System.out.println(a.replace("con.aga.dadfa", "a"));
		// System.out.println(MD5Util.createMD5String("GameWorld"));
	}

}

class InputInfo {
	String fileName;
	String importPath;

	public InputInfo(String fileName, String importPath) {
		this.fileName = fileName;
		this.importPath = importPath;
	}

	public String getFileName() {
		return fileName;
	}

	public void setFileName(String fileName) {
		this.fileName = fileName;
	}

	public String getImportPath() {
		return importPath;
	}

	public void setImportPath(String importPath) {
		this.importPath = importPath;
	}

}
