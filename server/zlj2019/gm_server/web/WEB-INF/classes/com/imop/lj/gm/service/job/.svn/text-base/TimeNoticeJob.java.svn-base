/*
 * Created on Sep 21, 2006
 *
 * This class is a simple Job which prints out execution time with its trigger's name
 */
package com.imop.lj.gm.service.job;

import java.util.Date;

import org.apache.log4j.Logger;
import org.quartz.Job;
import org.quartz.JobDataMap;
import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.NoticeConstants.NoticeType;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.model.notice.TimeNotice;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.SpringContext;

/**
 *
 * 定时公告 Service
 *
 * @author lin fan
 *
 */
public class TimeNoticeJob implements Job {

	private Logger telnetlog = Logger.getLogger("telnet");

	/**GM 游戏后台管理系统 */
	private static	SpringContext wac = SpringContext.getInstance();

	/** 命令管理 Service */
	private static	CmdManageService cmdManageService = (CmdManageService) (wac
				.getBean("cmdManageService"));
	/**处理Excel的多语言类 */
	private static ExcelLangManagerService lang = (ExcelLangManagerService) (wac
			.getBean("excelLangManagerService"));

	public void execute(JobExecutionContext context)
			throws JobExecutionException {
		JobDataMap dataMap = context.getJobDetail().getJobDataMap();
		DBServer dbServer = (DBServer) dataMap.get("srv");
		String cmd = dataMap.getString("cmd");
		TimeNotice n = (TimeNotice) dataMap.get("n");
		String serverName = dbServer.getDbServerName();
		Date now = new Date();
		StringBuilder info = new StringBuilder();
		try {
			if(n.getContent().contains("[Link") && n.getType() != NoticeType.CHAT_NOTICE.getIndex()) {
				//聊天公告格式，但是别的类型，不发送了，避免显示错误
				info.append("error happend, time notice content:" + n.getContent() + " but not chat notice : " + n.getType());
				return;
			}
			cmdManageService.sendCmd(cmd, dbServer,false);
			info.append(lang.readGm(GMLangConstants.ADD_NOTICE)+"("+lang.readGm(GMLangConstants.COMMON_SERVER)+":").append(serverName).append("\t"+lang.readGm(GMLangConstants.RECORD_KEY)+":")
					.append(n.getId()).append(") at ").append(now);
		} catch (Exception e) {
			e.printStackTrace();
			info.append(lang.readGm(GMLangConstants.ADD_NOTICE)+"("+lang.readGm(GMLangConstants.COMMON_SERVER)+":").append(serverName).append("\t"+lang.readGm(GMLangConstants.RECORD_KEY)+":")
					.append(n.getId()).append(") at ").append(now);
			info.append("\r\n");
			info.append(lang.readGm(GMLangConstants.EXCEPTION)+"：").append(e.getMessage());
		}
		telnetlog.info(info);
	}
}
