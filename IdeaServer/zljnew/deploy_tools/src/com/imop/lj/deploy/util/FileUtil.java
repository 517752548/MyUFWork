package com.imop.lj.deploy.util;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

import org.apache.commons.lang.StringUtils;

import com.imop.lj.deploy.Deploy;

/**
 *
 *
 */
public class FileUtil {
	/**
	 * 创建一个目录
	 *
	 * @param dir
	 * @exception RuntimeException
	 *                ,创建目录失败会抛出此异常
	 */
	public static void createDir(File dir) {
		if (!dir.exists() && !dir.mkdirs()) {
			throw new RuntimeException("Can't create the dir [" + dir + "]");
		}
	}

	/**
	 * 删除一个文件或者目录
	 *
	 * @param file
	 */
	public static void delete(File file) {
		if (file.isFile()) {
			file.delete();
		} else if (file.isDirectory()) {
			File[] _files = file.listFiles();
			for (File _f : _files) {
				delete(_f);
			}
			file.delete();
		}
	}

	/**
	 * 压缩zip文件
	 * @param file
	 * @param dest
	 * @throws IOException
	 */
	public static void zip(File file, File dest) throws IOException {
		ZipOutputStream _zip1 = new ZipOutputStream(new FileOutputStream(dest));
		zipFiles(file, _zip1, file.getAbsolutePath());
		_zip1.close();
	}

	private static void zipFiles(File file, ZipOutputStream out, String root) throws IOException {
		String _entryName = file.getAbsolutePath();
		if (_entryName.equals(root)) {
			//
			_entryName="";
		} else {
			int _ri = _entryName.indexOf(root);
			_entryName = _entryName.substring(_ri + root.length()+1);
			_entryName = _entryName.replace('\\', '/');
		}
		if (file.isFile()) {
			out.putNextEntry(new ZipEntry(_entryName));
			FileInputStream _fin = new FileInputStream(file);
			byte[] _b = new byte[1024];
			int len = 0;
			while ((len = _fin.read(_b)) != -1) {
				out.write(_b, 0, len);
			}
			_fin.close();
		} else {
			out.putNextEntry(new ZipEntry(_entryName + "/"));
			File[] _files = file.listFiles();
			for (File _f : _files) {
				zipFiles(_f, out, root);
			}
		}
	}
	
	/**
	 * 拷贝文件夹
	 * 
	 * @param srcPath 源文件夹
	 * @param destFilePath 目标文件夹 
	 */
	public static void copyDict(String srcPath, String destFilePath) {
		File file = new File(srcPath);
		if( !file.exists()) {
			return;
		}
		if(!file.isDirectory()){
			return;
		}
		File[] fileList = file.listFiles();
		for(File f : fileList) {
			if( f.isDirectory()) {
				if(ignoreFile(f.getName().toLowerCase())) {
					continue;
				}
				copyChildDict(f.getPath(), destFilePath+File.separator);
			}
		}
	}
	
	public static void copyChildDict(String srcPath, String destFilePath) {
		
		File file = new File(srcPath);
		if( !file.exists()) {
			return;
		}
		if(!file.isDirectory()){
			return;
		} else if(!needCopy(file.getName())) {
			// 不是指定要拷贝的文件夹，继续找下级文件夹
			File[] fileList = file.listFiles();
			for(File f : fileList) {
				if(f.isDirectory()){
					// 递归
					if(ignoreFile(f.getName())){
						continue;
					}
//					createDir(new File(destFilePath + File.separator + f.getName()));
					copyChildDict(f.getPath(), destFilePath);
				}
			}
		}
		
		if(!needCopy(file.getName())){
			return;
		}
		destFilePath = formatPath(destFilePath + file.getName());
		if(!new File(destFilePath).exists()) {
			createDir(new File(destFilePath));
		}
		File[] fileList = file.listFiles();
		for(File f : fileList) {
			if(f.isFile()) {
				copyFile(f, destFilePath);
			} else {
				if(ignoreFile(f.getName())){
					continue;
				}
				// 递归
//				createDir(new File(destFilePath + File.separator + f.getName()));
//				copyDict(f.getPath(), destFilePath + File.separator + f.getName());
			}
		}
	}
	/**
	 * 复制文件
	 * @param srcFile
	 * @param destFilePath
	 */
	public static void copyFile(File srcFile, String destFilePath) {
		try {
			if(!srcFile.isFile()) {
				return;
			}
			
			destFilePath = formatPath(destFilePath) + srcFile.getName();
			
			File destFile = new File(destFilePath);
			if(destFile.exists()) {
				destFile.setWritable(true);
			}
			FileInputStream in  = new FileInputStream(srcFile);
			FileOutputStream out = new FileOutputStream(destFilePath);
			int readCount = 0;
			byte[] bytes = new byte[1024];
			while( (readCount = in.read(bytes)) != -1) {
				out.write(bytes, 0 ,readCount);
			}
			out.close();
			in.close();
		}catch( Exception ex) {
			ex.printStackTrace();
		}
	}
	
	public static String formatPath(String path) {
		if(!path.endsWith(File.separator)) {
			path = path + File.separator;
		}
		return path;
	}
	
	private static boolean needCopy(String fileName) {
		
		if(".svn".equals(fileName)) {
			return false;
		}
		String checkName = "";
		if(fileName.startsWith(".")) {
			return false;
		}
		if(fileName.contains(".")) {
			checkName = fileName.split(".")[0];
		}else {
			checkName = fileName;
		}
		if(!StringUtils.isEmpty(checkName)) {
			for(String copyName : Deploy.COPY_DIR) {
				if(copyName.toLowerCase().equals(fileName.toLowerCase())) {
					return true;
				}
			}
		}
		
		return false;
	}
	/**
	 * 需要忽略的文件 例如：.svn文件
	 * @param fileName
	 * @return
	 */
	private static boolean ignoreFile(String fileName) {
		if(".svn".equals(fileName)) {
			return true;
		}
		
		return false;
	}
//	public static void main(String[] args) {
//		File srcFile = new File("C:\\srcFile");
//		FileUtil.copyFile(srcFile, "D:\\testFileCopy");
//		FileUtil.copyDict("C:\\srcFile", "D:\\testFileCopy");
//	}
}
