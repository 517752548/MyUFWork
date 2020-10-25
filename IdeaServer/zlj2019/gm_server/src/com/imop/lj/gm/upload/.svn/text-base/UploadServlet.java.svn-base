package com.imop.lj.gm.upload;

import java.io.File;
import java.io.IOException;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.fileupload.DiskFileUpload;
import org.apache.commons.fileupload.FileItem;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.utils.ErrorsUtil;

public class UploadServlet extends HttpServlet {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	/** DBFactoryService LOG */
	private static final Logger logger = LoggerFactory.getLogger(UploadServlet.class);
	
	@SuppressWarnings("unchecked")
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		DiskFileUpload fu = new DiskFileUpload();
		// 文件大小最大值，5M
		fu.setSizeMax(5242880);
		// 缓冲区大小，5k
		fu.setSizeThreshold(5120);
		// 临时目录tempPath
		// fu.setRepositoryPath(tempPath);
		// 因为每次只上传一个文件，所以未设置循环
		fu.setHeaderEncoding("utf-8");
		List fileItems = null;
		String fileName = "";
		try {
			fileItems = fu.parseRequest(request);
			if(fileItems == null ){
				logger.error("upload file is null");
				return;
			}
			Object obj = fileItems.get(0);
			FileItem fi = (FileItem) obj;
			String name = (new File(fi.getName())).getName();
			
//			if (!name.equals("") && name.lastIndexOf(".csv") != -1) {
				// fileName = fi.getFieldName();
//				Date date = new Date();
//				SimpleDateFormat sdf = new SimpleDateFormat("yyyy_MM_dd_HH_mm_SS");
//				String dateStr = sdf.format(date);
				fileName = name;
				
				if(fileName.toLowerCase().lastIndexOf(".mp3") != -1 && fileName.toLowerCase().length() == 37){
					File dir = new File(SystemConstants.UPLOAD_PATH + File.separator  + fileName.toLowerCase().substring(18,24))  ;
					if (dir.mkdirs()) {
						logger.info("dir:" + dir + " mk success!");
					}
				}
				fi.write(new File(SystemConstants.UPLOAD_PATH + File.separator  + fileName.toLowerCase().substring(18,24) + File.separator + fileName));
//			}
		} catch (Exception e) {
			e.printStackTrace();
			logger.error(ErrorsUtil.error(UploadServlet.class.toString(), "uploadFile", e.getMessage()));
		}
	}
	
//	public static void main(String[] args){
//		
//		System.out.println("288516249174935515130911102021001.mp3".substring(18,24));
//	}
}
