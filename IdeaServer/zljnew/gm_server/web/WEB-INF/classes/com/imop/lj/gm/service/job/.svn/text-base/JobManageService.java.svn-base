package com.imop.lj.gm.service.job;

import java.util.Date;
import java.util.List;
import java.util.Map;

import org.quartz.Scheduler;
import org.quartz.SchedulerException;
import org.quartz.impl.StdSchedulerFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.notice.TimeNoticeDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.model.notice.TimeNotice;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.SpringContext;

/**
 * 定时任务Service
 *
 * @author linfan
 * @author kai.shi
 */
public class JobManageService {

	private Logger telnetlog = LoggerFactory.getLogger("telnet");

	private Scheduler scheduler = null;

	private DBFactoryService dbFactoryService;

	private SchedulerService schedulerService;

	private TimeNoticeDAO timeNoticeDAO;


	private static SpringContext wac = SpringContext.getInstance();

	private static ExcelLangManagerService lang = (ExcelLangManagerService) (wac
			.getBean("excelLangManagerService"));

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public TimeNoticeDAO getTimeNoticeDAO() {
		return timeNoticeDAO;
	}

	public void setTimeNoticeDAO(TimeNoticeDAO timeNoticeDAO) {
		this.timeNoticeDAO = timeNoticeDAO;
	}

	public SchedulerService getSchedulerService() {
		return schedulerService;
	}

	public void setSchedulerService(SchedulerService schedulerService) {
		this.schedulerService = schedulerService;
	}

	/**
	 * 加载定时公告
	 */
	public void loadTimeNotice() {
		Map<String, List<DBServer>> svrs = dbFactoryService.getDbServerList();
		telnetlog.info("******************loadTimeNotice  start*************************");
		for (String regionId : svrs.keySet()) {
			List<DBServer> dbservers = dbFactoryService.getServerList(regionId);
			for (DBServer svr : dbservers) {
				if(svr.isGM()){
					continue;
				}
				String id = svr.getId();
				String rid = svr.getRegionId();
				telnetlog.info("db:\t DBId:"+id+"\t RegionId \t"+rid);
				ParamGenericDAO s1Dao = new ParamGenericDAO();
				s1Dao.setRId(rid);
				s1Dao.setSId(id);
				s1Dao.setDbFactoryService(dbFactoryService);
				List<TimeNotice> list = s1Dao.getValidTimeNoticeList();
				if (list != null) {
					for (TimeNotice n : list) {
						String cmd = TimeNotice.createNoticeCmd(n);
						telnetlog.info("[TimeNotice (id:"+n.getId()+",content:"+n.getContent()+",ServerIds:"+n.getServerIds()+
								",Operator:" +n.getOperator()+",StartTime:"+n.getStartTime()+",EndTime"+n.getEndTime()+",intervalTime:"+
								n.getIntervalTime()+")]");
						schedulerService.scheduleTimeNotice(n, svr, cmd);
					}
				}
			}
		}
		telnetlog.info("******************loadTimeNotice   end*************************");
	}

	/**
	 * 添加任务 job
	 *
	 * @param noticeId
	 *            公告id
	 *
	 * @param dbSrvId
	 *            服务器id
	 * @param cmd
	 *            命令
	 * @param n
	 *            定時公告
	 *
	 * @param 数据库
	 *            Server
	 */
	public void addJob(String rid, String dbSrvId, String cmd, TimeNotice n) {
		DBServer dbServer = dbFactoryService.getServer(rid, dbSrvId);
		telnetlog.info("addJob[TimeNotice (id:"+n.getId()+",content:"+n.getContent()+",ServerIds:"+n.getServerIds()+
				",Operator:" +n.getOperator()+",StartTime:"+n.getStartTime()+",EndTime"+n.getEndTime()+",intervalTime:"+
				n.getIntervalTime()+")]");
		schedulerService.scheduleTimeNotice(n, dbServer, cmd);
	}

	/**
	 * 删除Job
	 * @param rid  大区ID
	 * @param id  定时公告ID
	 * @param dbSrvId   数据库服务器ID
	 */
	public void stopJob(String rid, String id, String dbSrvId) {

		String serverName = dbFactoryService.getServer(rid, dbSrvId)
				.getDbServerName();
		try {
			scheduler = StdSchedulerFactory.getDefaultScheduler();
			scheduler.unscheduleJob("timeNoticeTrigger" + id,
					"TimeNoticeJobGroup" + rid + "_" + dbSrvId);
			telnetlog.info(lang.readGm(GMLangConstants.CANCEL_NOTICE) + "("
					+ lang.readGm(GMLangConstants.COMMON_SERVER) + ":"
					+ serverName + "\t"
					+ lang.readGm(GMLangConstants.RECORD_KEY) + ":" + id
					+ ") at" + new Date());
		} catch (SchedulerException e) {
			e.printStackTrace();
		}
	}

	  /**
	 * 监控服务器
	 * @param n 定时公告
	 * @param svr DBServer
	 * @param cmd 命令
	 */
	public void monitorSvr(){
		schedulerService.monitorSvr();
	};

}
