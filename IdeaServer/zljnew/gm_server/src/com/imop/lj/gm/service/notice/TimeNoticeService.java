/**
 * 
 */
package com.imop.lj.gm.service.notice;

import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.notice.TimeNoticeDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.notice.TimeNotice;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.job.JobManageService;
import com.imop.lj.gm.service.job.SchedulerService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.lj.gm.utils.ErrorsUtil;

/**
 * 处理Excel的多语言 Service
 * 
 * @author linfan
 * 
 */
public class TimeNoticeService {
	
	public GmConfig gmConfig;
	
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	/**db log */
	private   Logger logger = LoggerFactory.getLogger("db");
	
	/**telnet log */
	private   Logger telnetlogger = LoggerFactory.getLogger("telnet");
	
	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	/** 定时公告 DAO */
	private TimeNoticeDAO timeNoticeDAO;

	/** 定时任务Service */
	private JobManageService jobManageService;
    
	/** 调度Service*/
	private SchedulerService schedulerService;
	

	/** 处理Excel的多语言Service */
	private ExcelLangManagerService excelLangManagerService;
	
	
	public SchedulerService getSchedulerService() {
		return schedulerService;
	}

	public void setSchedulerService(SchedulerService schedulerService) {
		this.schedulerService = schedulerService;
	}

	public JobManageService getJobManageService() {
		return jobManageService;
	}

	public void setJobManageService(JobManageService jobManageService) {
		this.jobManageService = jobManageService;
	}

	public TimeNoticeDAO getTimeNoticeDAO() {
		return timeNoticeDAO;
	}

	public void setTimeNoticeDAO(TimeNoticeDAO timeNoticeDAO) {
		this.timeNoticeDAO = timeNoticeDAO;
	}

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	/**
	 * 查询所有的定时公告
	 * 
	 * @return 定时公告列表
	 */
	public List<TimeNotice> getTimeNoticeList(String type) {
		return timeNoticeDAO.getTimeNoticeList(type);
	}

	/**
	 * 添加定时公告
	 * 
	 * @param startTime
	 * @param endTime
	 * @param interval
	 * @param operator
	 * @param content
	 * @param pattern 
	 * @throws Exception
	 */
	public boolean addTimeNotice(String startTime, String endTime,
			String interval, String operator, String content,
			String serverIDs,DBServer dbServer, String pattern, String type, String subType,ParamGenericDAO dao) throws Exception {
		boolean valid = validContion(startTime, endTime, interval, operator, content,serverIDs,pattern);
		if(!valid){
			return false;
		}
		try{
			TimeNotice notice = new TimeNotice();
			notice.setContent(content);
			notice.setEndTime(Timestamp.valueOf(endTime));
			notice.setStartTime(Timestamp.valueOf(startTime));
			notice.setIntervalTime(Integer.valueOf(interval));
			notice.setOperator(operator);
			notice.setOpenType(Byte.valueOf(pattern));
			notice.setType(Byte.valueOf(type));
			notice.setSubType(Byte.valueOf(subType));
			notice.setServerIds(serverIDs);
			Integer newerId = (Integer) dao.save(notice);
			String cmd = TimeNotice.createNoticeCmd(notice);
			telnetlogger.info("************** addTimeNotice to job start **********");
			schedulerService.scheduleTimeNotice(notice, dbServer, cmd);
			LoginUser loginUser = LoginUserService.getLoginUser();
			if (newerId != null) {
				String info = "success:\t"
					+ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)+":"+loginUser.getUsername()+"\t"
					+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+loginUser.getLoginRegionId()+"\t"
					+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+loginUser.getLoginServerId()+"\t"
					+"Add TimeNotice(id:"+notice.getId()+",content:"+content+",StartTime:"+startTime+",EndTime:"+endTime+",IntervalTime:"+interval+",Operator:"+operator+",ServerIds:"+serverIDs+")"
					+"\t Date:"+DateUtil.formatDateHour(new Date());
				logger.info(info);
				return true;
			} else {
				return false;
			}
		}catch (Exception e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(),"saveTimeNotice", e.getMessage()));
			return false;
		}
	}

	/**
	 * 删除定时公告
	 * 
	 * @param id
	 */
	public void delTimeNotice(String id, String dbSrvId,String regionId) {
		TimeNotice notice = timeNoticeDAO.getById(TimeNotice.class, Integer
				.valueOf(id));
		telnetlogger.info("**************delete TimeNotice start **********");
		jobManageService.stopJob(regionId,id, dbSrvId);
		telnetlogger.info("**************delete TimeNotice end ************");
		timeNoticeDAO.delete(notice);
		LoginUser loginUser = LoginUserService.getLoginUser();
		String info = "success:\t"
			+ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)+":"+loginUser.getUsername()+"\t"
			+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+loginUser.getLoginRegionId()+"\t"
			+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+loginUser.getLoginServerId()+"\t"+
			"Delete TimeNotice(id:"+id+")\t Date:"+(DateUtil.formatDateHour(new Date()));
	    logger.info(info);
	}

	/**
	 * @param id
	 * @return
	 */
	public TimeNotice loadTimeNotice(String id) {
		if (id == null) {
			return null;
		}
		return timeNoticeDAO.getById(TimeNotice.class, Integer.valueOf(id));
	}

	/**
	 * @param id
	 * @param startTime
	 * @param endTime
	 * @param interval
	 * @param operator
	 * @param content
	 * @param serverIDs
	 * @return
	 * @throws Exception 
	 */
	public boolean saveTimeNotice(String id, String startTime, String endTime,
			String interval, String operator, String content,
			String serverIDs, DBServer svr ,String pattern,String type,String subType ,ParamGenericDAO dao) throws Exception {
		if(StringUtils.isBlank(id))
		{
			return addTimeNotice(startTime, endTime, interval, operator, content, serverIDs, svr, pattern, type,subType,dao);
		}
		boolean valid = validContion(startTime, endTime, interval, operator, content,serverIDs,pattern);
		if(!valid){
			return false;
		}
		try{
			TimeNotice notice = dao.getById(TimeNotice.class, Integer
					.valueOf(id));
			notice.setContent(content);
			notice.setEndTime(Timestamp.valueOf(endTime));
			notice.setStartTime(Timestamp.valueOf(startTime));
			notice.setIntervalTime(Integer.valueOf(interval));
			notice.setOperator(operator);
			notice.setServerIds(serverIDs);
			notice.setOpenType(Byte.valueOf(pattern));
			notice.setType(Byte.valueOf(type));
			notice.setSubType(Byte.valueOf(subType));
			LoginUser loginUser = LoginUserService.getLoginUser();
			if (dao.merge(notice) != null) {
				String info = "success:\t"
					+ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)+":"+loginUser.getUsername()+"\t"
					+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+loginUser.getLoginRegionId()+"\t"
					+ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+loginUser.getLoginServerId()+"\t"
					+"Edit TimeNotice(id:"+notice.getId()+",content:"+content+",StartTime:"+startTime+",EndTime:"+endTime+",IntervalTime:"+interval+",Operator:"+operator+",ServerIds:"+serverIDs+")"
					+"\t Date:"+DateUtil.formatDateHour(new Date());
				logger.info(info);
				String cmd = TimeNotice.createNoticeCmd(notice);
				telnetlogger.info("**************Edit  TimeNotice to job start **********");
				schedulerService.scheduleTimeNotice(notice, svr, cmd);
				telnetlogger.info("************** Edit TimeNotice to job start ***********");
				return true;
			} else {
				return false;
			}
		}
		catch (Exception e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(),"saveTimeNotice", e.getMessage()));
			return false;
		}
	}
	
	/**
	 * @param startTime
	 * @param endTime
	 * @param interval
	 * @param operator
	 * @param content
	 * @param serverIDs
	 * @param pattern
	 * @return
	 */
	private boolean validContion(String startTime, String endTime,
			String interval, String operator, String content,
			String serverIDs, String pattern) {
		if(StringUtils.isBlank(startTime)||StringUtils.isBlank(endTime)
			||StringUtils.isBlank(interval)||StringUtils.isBlank(operator)
			||StringUtils.isBlank(content)||StringUtils.isBlank(pattern)||StringUtils.isBlank(serverIDs)){
			return false;
		}
		if (content.length() > gmConfig.noticeLen) {
			return false;
		}
		return true;
	 }

	/**
	 * 发布公告
	 * 
	 * @param id
	 */
	public boolean releaseTimeNotice(String id, DBServer svr) {
		TimeNotice notice = timeNoticeDAO.getById(TimeNotice.class, Integer.valueOf(id));
		String cmd = TimeNotice.createNoticeCmd(notice);
		List<String> result = cmdManageService.sendCmd(cmd, svr, false);
		if (!"[]".equals(result.toString())) {
			return false;
		}
		LoginUser loginUser = LoginUserService.getLoginUser();
		String info = "success:\t" + ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN) + ":"
				+ loginUser.getUsername() + "\t" + ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)
				+ ":" + loginUser.getLoginRegionId() + "\t"
				+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER) + ":"
				+ loginUser.getLoginServerId() + "\t" + "Release GameNotice(id:" + id + ",content:"
				+ notice.getContent() + ",ServerIds:" + notice.getServerIds() + ")" + "\t Date:"
				+ DateUtil.formatDateHour(new Date());
		logger.info(info);
		return true;
	}
	
	
}
