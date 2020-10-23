package com.imop.lj.gm.utils;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.servlet.http.HttpServletRequest;

import org.apache.commons.fileupload.DiskFileUpload;
import org.apache.commons.fileupload.FileItem;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.LoginUser;

/**
 * 
 * 升级文件工具类
 * 
 */
public class UploadFileUtil {

	/** DBFactoryService LOG */
	private static final Logger logger = LoggerFactory.getLogger(UploadFileUtil.class);

	@SuppressWarnings("unchecked")
	public static String uploadFile(HttpServletRequest request, String filename) {
		LoginUser u = (LoginUser) request.getSession().getAttribute("loginUser");
		DiskFileUpload fu = new DiskFileUpload();
		// 文件大小最大值，5M
		fu.setSizeMax(5242880);
		// 缓冲区大小，5k
		fu.setSizeThreshold(5120);
		// 临时目录tempPath
		// fu.setRepositoryPath(tempPath);
		// 因为每次只上传一个文件，所以未设置循环
		fu.setHeaderEncoding("utf-8");
		List fileItems;
		String fileName = "";
		try {
			fileItems = fu.parseRequest(request);
			Object obj = fileItems.get(0);
			FileItem fi = (FileItem) obj;
			String name = fi.getName();
			if (!name.equals("") && name.lastIndexOf(".xls") != -1) {
				// fileName = fi.getFieldName();
				Date date = new Date();
				SimpleDateFormat sdf = new SimpleDateFormat("yyyy_MM_dd_HH_mm_SS");
				String dateStr = sdf.format(date);
				fileName = filename + "_by_" + u.getUsername() + "_" + dateStr + ".csv";
				File dir = new File(SystemConstants.UPLOAD_PATH);
				if (dir.mkdirs()) {
					logger.info("dir:" + dir + " mk success!");
				}
				;
				fi.write(new File(SystemConstants.UPLOAD_PATH + "\\" + fileName));
			}
		} catch (Exception e) {
			logger.error(ErrorsUtil.error(UploadFileUtil.class.toString(), "uploadFile", e.getMessage()));
		}
		return fileName;
	}

}
