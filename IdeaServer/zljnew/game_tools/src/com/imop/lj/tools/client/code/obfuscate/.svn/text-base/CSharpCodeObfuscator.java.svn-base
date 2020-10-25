package com.imop.lj.tools.client.code.obfuscate;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CSharpCodeObfuscator {

	Map<String, String> folderKeyMap = new HashMap<String, String>();

	Map<String, String> fileNameMap = new HashMap<String, String>();
	
	//Map<类名，混淆类名>
	Map<String, String> clzNameMap = new HashMap<String, String>();
	//Map<namespace名，混淆namespace名>
	Map<String, String> namespaceMap = new HashMap<String, String>();
	
	String[] skipFile = {"config.xml"};
	
	//不混淆的特定类，在初始化时会加到ignoreClzSet中
	String[] ignoreClzArr = {"NGUIModify"};
	//不混淆的类名集合，会根据继承指定类不混淆来动态增加
	Set<String> ignoreClzSet = new HashSet<String>();
	//【直接继承】这些类的类，不混淆
	String[] ignoreExtendsClzArr = {"Attribute", "MonoBehaviour"};
	//【直接继承】以这些字符串开头的类，不混淆，尽量少用！
	String[] ignoreExtendsClzArrStartWith = {"UI"};

	//以这些字符串开始的namespace不混淆
	String[] ingoreNamespaceAry = { "System", "UnityEngine", "Mono", "Apex" };
	
	//查找类名的正则，$3是继承的类，目前只支持直接继承的，间接继承的还需优化
	Pattern clzNamePtn = Pattern.compile(
			"(class|interface|enum|struct)\\s+([_a-zA-Z0-9]+)[^:\n]*:{0,1}\\s*([<>_a-zA-Z0-9,\\s]*)");
	
	String postFix = ".cs";
	
	String[] hArray = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
			"Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
			"y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
	
	String[] h1Array = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
			"Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
			"y", "z" };
	
	public static File rootFile = new File("E:\\uuu\\client\\trunk\\u3u1\\Assets\\Scripts");

	public static File obfuscateRootFile = new File("E:\\u3u1_obfuscated");

	public List<File> fileList = new ArrayList<File>();

//	private List<String> ingoreNamesArray = new ArrayList<String>();

	public CSharpCodeObfuscator(String baseDir) {
		rootFile = new File(baseDir);
		obfuscateRootFile = new File(rootFile.getParent() + File.separator + "obfuscated_src");
		this.delFile(obfuscateRootFile);
		this.init();
	}

	public CSharpCodeObfuscator(String baseDir, String obBaseDir) {
		rootFile = new File(baseDir);
		obfuscateRootFile = new File(obBaseDir);
		this.delFile(obfuscateRootFile);
		this.init();
	}
	
	public CSharpCodeObfuscator() {
		this.delFile(obfuscateRootFile);
		this.init();
	} 

	/**
	 * 初始化
	 */
	public void init() {
		this.randomKey();
		
		for (int i = 0; i < ignoreClzArr.length; i++) {
			ignoreClzSet.add(ignoreClzArr[i]);
		}
	}

	public void execute() throws Exception {
		this.genMap(rootFile);
		
		for (String ns : namespaceMap.keySet()) {
			System.out.println("ns=" + ns);
		}
		
		this.obfuscate(fileList);
	}
	
	private void genMap(File file) throws Exception {
		int fileNum = 0;
		File[] files = file.listFiles();
		for (File tempFile : files) {
			if (!tempFile.isDirectory()) {
				//只处理.cs文件
				if (tempFile.getName().toLowerCase().endsWith(postFix)) {
					fileNum++;
					if (isSkipFile(tempFile)) {
						continue;
					}
					
					File newFile = new File(createObfuscatedFolder(tempFile.getParentFile()) + File.separator + tempFile.getName());
					this.copyFile(tempFile, newFile);
//					System.out.println("[Copy]" + tempFile + " copy to : " + newFile);
					
					fileList.add(newFile);
					
					String fileStr = readTxtFile(newFile);
					
					Set<String> clzNameSet = findClzName(fileStr);
					if (clzNameSet != null) {
						for (String clzName : clzNameSet) {
							if (clzNameMap.containsKey(clzName)) {
								throw new Exception("类名重复！暂不支持同名类，请修改！clzName=" + clzName);
							}
							System.out.println("ClassName=" + clzName);
							clzNameMap.put(clzName, getRandConcatMD5(clzName));
						}
					}
					
					String ns = findNamespace(fileStr);
					if (ns != null && !ns.equalsIgnoreCase("")) {
						if (isIgnoreNs(ns)) {
							System.out.println("ignore namespace=" + ns);
							continue;
						}
						System.out.println("namespace=" + ns);
						namespaceMap.put(ns, getRandConcatMD5(ns));
					}
				}
			} else {
				createObfuscatedFolder(tempFile);
				genMap(tempFile);
			}
		}
		
		System.out.println("fileNum=" + fileNum);
	}
	
	private String obFile(File file) throws Exception {
		String outputStr = readTxtFile(file);
		
		String fileName = file.getName();
		if ("GlobalConstDefine.cs".equals(fileName)) {
			System.out.println("ff");
		}
		
		// 干掉注释//
		String[] notesSAry = outputStr.split("\n");
		outputStr = "";
		for (int i = 0; i < notesSAry.length; i++) {
			String tempStr = notesSAry[i];
			int tempIndex = tempStr.indexOf("//");
			if (tempIndex == -1 || (tempStr.indexOf("\"") < tempIndex && tempStr.lastIndexOf("\"") > tempIndex)) {
				//不含有//，且//不在双引号内，则不处理
			} else if (tempIndex > 0 && tempIndex != -1) {
				if (tempIndex >= 5) {
					if (!"http:".equalsIgnoreCase(tempStr.substring(tempIndex - 5, tempIndex))) {
						if (tempStr.indexOf("/*") != -1 && tempStr.indexOf("/*") < tempIndex) {
						} else if (tempStr.indexOf("*/") != -1 && tempStr.indexOf("*/") < tempIndex) {

						} else {
							tempStr = tempStr.substring(0, tempIndex) ;
						}
					}
				} else {
					tempStr = tempStr.substring(0, tempIndex) ;
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
		
		System.out.println("file=" + file.getName());
		
		//替换namespace
		String[] ns1 = outputStr.split("namespace\\s+");
		if (ns1 != null && ns1.length > 1) {
			String[] ns2 = ns1[1].split("\\{");
			if (ns2 != null && ns2.length > 0) {
				String ns = ns2[0].trim();
				if (ns != null && !ns.equalsIgnoreCase("")) {
					outputStr = outputStr.replace(ns, namespaceMap.get(ns));
				}
			}
		}
		
		//替换using namespace
		for (Entry<String, String> entry : namespaceMap.entrySet()) {
			String ns = entry.getKey();
			String nsMd5 = entry.getValue();
			outputStr = outputStr.replaceAll("using\\s+" + ns +"\\s*;", "using " + nsMd5 + ";");
			
			//GlobalConstDefine中有类名字符串，在WndManager中通过反射调用
			outputStr = outputStr.replaceAll("\"" + ns +"(\\.[_a-zA-Z]+)\"", "\"" + nsMd5 +"$1\"");
		}
		
		//替换类名
		for (Entry<String, String> entry : clzNameMap.entrySet()) {
			String tempReplaceStr = replaceClassName(outputStr, entry.getKey(), entry.getValue());
			if (tempReplaceStr.length() > 0) {
				outputStr = tempReplaceStr;
			}
		}
		
		return outputStr;
	}
	
	protected String replaceClassName(String str, String className, String md5ClzName) {
		if (isIgnoreClz(className)) {
			return "";
		}
		
		Pattern pattern = Pattern.compile("[0-9a-zA-Z_]");
		String[] ary = str.split(className);
		String str1 = "";

		for (int i = 0; i < ary.length; i++) {
			String tempName = "";
			if (i + 1 < ary.length) {
				Matcher matcher1 = pattern.matcher(ary[i].substring(ary[i].length() - 1));
				Matcher matcher2 = pattern.matcher(ary[i + 1].substring(0, 1));
				if (!matcher1.find() && !matcher2.find()) {
					tempName = md5ClzName;
				} else {
					tempName = className;
				}
			}
			str1 += ary[i] + tempName;
		}
		return str1;
	}
	
	private boolean isSkipFile(File tempFile) {
		for (int i = 0; i < skipFile.length; i++) {
			if (skipFile[i].equalsIgnoreCase(tempFile.getName())) {
				return true;
			}
		}
		return false;
	}
	
	private boolean isIgnoreClz(String clzName) {
		if (ignoreClzSet.contains(clzName)) {
			return true;
		}
		return false;
	}
	
	private boolean isIgnoreNs(String ns) {
		for (int i = 0; i < ingoreNamespaceAry.length; i++) {
			if (ns.startsWith(ingoreNamespaceAry[i])) {
				return true;
			}
		}
		return false;
	}
	
	private Set<String> findClzName(String str) throws Exception {
		Set<String> clzNameSet = new HashSet<String>();
		Matcher mt = clzNamePtn.matcher(str);
		String clzName = null;
		String baseName = null;
		while (mt.find()) {
			clzName = mt.group(2);
			baseName = mt.group(3);
			if (baseName != null && !baseName.equalsIgnoreCase("")) {
				System.out.println("baseName=" + baseName);
				if (baseName.contains(",")) {
					String[] b1 = baseName.split(",");
					for (int i = 0; i < b1.length; i++) {
						String[] b2 = b1[i].split("<");
						String baseClzName = b2 != null ? b2[0] : b1[i];
						if (isIgnoreExtends(baseClzName.trim())) {
							ignoreClzSet.add(clzName);
							break;
						}
					}
				} else {
					String[] b1 = baseName.split("<");
					String baseClzName = b1 != null ? b1[0] : baseName;
					if (isIgnoreExtends(baseClzName.trim())) {
						ignoreClzSet.add(clzName);
					}
				}
			}
			if (clzNameSet.contains(clzName)) {
				throw new Exception("类名重复！不允许相同的类名存在！请修改！clzName=" +clzName);
			}
			clzNameSet.add(clzName);
		}
		return clzNameSet;
	}
	
	private boolean isIgnoreExtends(String baseClzName) {
		for (int i= 0; i < ignoreExtendsClzArr.length; i++) {
			if (ignoreExtendsClzArr[i].equals(baseClzName)) {
				return true;
			}
		}
		for (int i= 0; i < ignoreExtendsClzArrStartWith.length; i++) {
			if (baseClzName.startsWith(ignoreExtendsClzArrStartWith[i])) {
				return true;
			}
		}
		
		return false;
	}
	
	private String findNamespace(String str) {
		String ns = "";
		String[] packageAry = str.split("namespace ");
		if (packageAry.length > 1) {
			packageAry = packageAry[1].split("\\{");
			if (packageAry != null && packageAry.length > 0) {
				ns = packageAry[0].trim();
			}
		}
		return ns;
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
		List<String> ary_aA0 = Arrays.asList(hArray);
		List<String> ary_aA0_obfus = new ArrayList<String>(Arrays.asList(hArray));
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
				String content = obFile(file);//obfuscateOne(file);
				writedFiles.put(file, content);
			} catch (Exception e) {
				e.printStackTrace();
				throw new Exception("[obfuscate]混淆文件出错,文件名:" + file.getName());
			}
		}
		System.out.println("total file count=" + fileList.size());
		
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
	
	

	/**
	 * 获得包名
	 * 
	 * @param packagePath
	 * @return
	 * 
	 */
	protected String getNewPackage(String packagePath) {
		if (packagePath.length() > 1) {

			String newPath = getObfuscatedFolderName(packagePath);
//			String[] ary = packagePath.split("\\.");
//
//			for (int i = 0; i < ary.length; i++) {
//				if (i < ary.length - 1) {
//					newPath += getObfuscatedFolderName(ary[i]) + ".";
//				} else {
//					newPath += getObfuscatedFolderName(ary[i]);
//				}
//			}
			return newPath;
		}
		return "";
	}

	private String getRandConcatMD5(String str) {
		return h1Array[random(0, h1Array.length - 1)].toLowerCase() + createMD5String(str);
	}
	
	public static int random(int low, int hi) {
		return (int) (low + (hi - low + 0.9) * Math.random());
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
		return name_str;
//		String str = prefix;
//		for (char c : name_str.toCharArray()) {
//			if (folderKeyMap.containsKey("" + c)) {
//				str += folderKeyMap.get("" + c);
//			} else {
//				str += c;
//			}
//		}
//		return str;
	}

	public static void main(String[] args) {
		CSharpCodeObfuscator abfuscator = null;
		try {
//			test("namespace app.camp { public string a = \"a.b.MM\"; k=\"a.b.c.Dl\"; using a.b.c.d ;   public enum  PetInTeam:a  interface ff  {        public PetItem petItem;                public int teamId;        public long petUUId;    }}");
			
			 if (args.length == 1) {
				 abfuscator = new CSharpCodeObfuscator(args[0]);
			 }else if(args.length == 2){
				 abfuscator = new CSharpCodeObfuscator(args[0],args[1]);
			 }
			 else{
				 abfuscator = new CSharpCodeObfuscator();
//				 throw new RuntimeException("参数不合法");
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
	
	private static void test(String outputStr) throws Exception
	{
		CSharpCodeObfuscator abfuscator = new CSharpCodeObfuscator();
		File f= new File("E:\\uuu\\client\\trunk\\u3u1\\Assets\\Scripts\\app\\db\\base\\TemplateDBBase.cs");
//		File f= new File("E:\\uuu\\client\\trunk\\u3u1\\Assets\\Scripts\\app\\human\\Human.cs");
		String txt = abfuscator.readTxtFile(f);
		outputStr = txt;
		
		Matcher mt = abfuscator.clzNamePtn.matcher(outputStr);
		String clzName = null;
		String baseName = null;
		while (mt.find()) {
			clzName = mt.group(2);
			System.out.println("clz=" + clzName);
			baseName = mt.group(3);
			if (baseName != null && !baseName.equalsIgnoreCase("")) {
				System.out.println("baseName=" + baseName);
			}
		}
		
		
		
//		String[] a = outputStr.split("namespace\\s+");
//		for(int i = 0; i < a.length; i++){
//			System.out.println(a[i]);	
//		}
		
		System.out.println("end");
		System.exit(1);
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
	
	/**
	 * 将输入的字符串进行MD5加密（编码）
	 *
	 * @param inputString
	 * @return
	 */
	public static String createMD5String(String inputString) {
		return encodeByMD5(inputString);
	}
	
	/**
	 * 对字符串进行MD5编码
	 *
	 * @param originStr
	 * @return
	 */
	public static String encodeByMD5(String originStr) {
		if (originStr != null) {
			try {
				// 创建具有指定算法名称的信息摘要
				MessageDigest md = MessageDigest.getInstance("MD5");
				// 使用指定的字节数组对摘要进行最后的更新，然后完成摘要计算
				char[] _charStr = originStr.toCharArray();
				byte[] _byteStr = new byte[_charStr.length];
				for (int i = 0; i < _charStr.length; i++) {
					_byteStr[i] = (byte)_charStr[i];
				}
				byte[] _results = md.digest(_byteStr);
				StringBuffer _hexValue = new StringBuffer();
				for (int i = 0; i < _results.length; i++) {
					int _val = ((int)_results[i]) & 0xff;
					if(_val < 16){
						_hexValue.append("0");
					}
					_hexValue.append(Integer.toHexString(_val));
				}
				return _hexValue.toString();
			} catch (Exception ex) {
				ex.printStackTrace();
			}
		}
		return null;
	}
	
}

