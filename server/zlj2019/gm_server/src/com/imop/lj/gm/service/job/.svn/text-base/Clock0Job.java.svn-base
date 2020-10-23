package com.imop.lj.gm.service.job;

import java.io.File;

import org.apache.log4j.Logger;
import org.quartz.Job;
import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gm.constants.SystemConstants;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2013年12月11日 下午4:02:05
 * @version 1.0
 */

public class Clock0Job implements Job {

	private Logger clock0JobLog = Logger.getLogger("Clock0Job");


	@Override
	public void execute(JobExecutionContext arg0)
			throws JobExecutionException {
		// TODO 删除文件
		delFileUnDirect(SystemConstants.UPLOAD_PATH);
		System.out.println("删除文件-----");
	}
	
	/**
	 * 删除指定文件夹下的过期文件
	 * 过期天数在 SystemConstants.UPLOAD_MP3_FILE_DAY_NUM 定义；
	 * 遇到文件夹，递归删除
	 * @param fileRootPath
	 */
	protected void delFileUnDirect(String fileRootPath) {
		try{
			File file = new File(fileRootPath);
			// 删除文件夹下的大于当前时间*天的文件
			if(file.isDirectory() ) {
				File[] files = file.listFiles();
				if(files == null || files.length ==0) {
					return;
				}
				
				for(File f : files) {
					// 删除过期的 mp3 文件
					if(f.isFile() && canDel(f)) {
						f.delete();
					}else {
						delFileUnDirect(f.getAbsolutePath());
					}
				}
			}
		}catch(Exception ex) {
			ex.printStackTrace();
			clock0JobLog.error(ex);
		}
	}
	/**
	 * 判断文件是否过期
	 * @param file
	 * @return
	 */
	protected boolean canDel(File file) {
		if(null != file ) {
			String fileName = file.getName();
			if( !fileName.toLowerCase().endsWith(".mp3")) {
				return false;
			}
			long modifiedTime = file.lastModified();
			if(SystemConstants.UPLOAD_MP3_FILE_DAY_NUM <= TimeUtils.getSoFarWentDays(modifiedTime, System.currentTimeMillis())) {
				return true;
			}
		}
		return false;
	}
}
