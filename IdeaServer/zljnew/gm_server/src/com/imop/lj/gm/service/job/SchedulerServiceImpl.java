package com.imop.lj.gm.service.job;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.quartz.JobDetail;
import org.quartz.Scheduler;
import org.quartz.SchedulerException;
import org.quartz.SimpleTrigger;
import org.quartz.impl.StdSchedulerFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.model.notice.TimeNotice;

public class SchedulerServiceImpl implements SchedulerService {

	@SuppressWarnings("unchecked")
	private static List triggerList= new ArrayList();


	private Logger telnetlog = LoggerFactory.getLogger("telnet");


	@SuppressWarnings("unchecked")
	@Override
	public void scheduleTimeNotice(TimeNotice n,DBServer srv,String cmd) {

        try {
        	telnetlog.info("*******schedule start***************");
        	Scheduler scheduler= StdSchedulerFactory.getDefaultScheduler();
        	JobDetail jobDetail = new JobDetail("timeNoticeTrigger"+n.getId(), "TimeNoticeJobGroup"+srv.getRegionId()+"_"+srv.getId(),
					TimeNoticeJob.class);
			jobDetail.getJobDataMap().put("srv", srv);
			jobDetail.getJobDataMap().put("n", n);
			jobDetail.getJobDataMap().put("cmd", cmd);
            scheduler.addJob(jobDetail, true);
            long i = ((long)n.getIntervalTime())*60*1000;
            SimpleTrigger simpleTrigger = new SimpleTrigger("timeNoticeTrigger"+n.getId(), "TimeNoticeJobGroup"+srv.getRegionId()+"_"+srv.getId(), jobDetail.getName(),
            		"TimeNoticeJobGroup"+srv.getRegionId()+"_"+srv.getId(), n.getStartTime(), n.getEndTime(), SimpleTrigger.REPEAT_INDEFINITELY, i);

            if(!triggerList.contains(simpleTrigger)){
            	telnetlog.info("TimeNoticeTrigger:"+simpleTrigger.getFullName()+"   scheduleJob");
            	scheduler.scheduleJob(simpleTrigger);
            }else{
            	 telnetlog.info("TimeNoticeTrigger:"+simpleTrigger.getFullName()+"   rescheduleJob");
            	scheduler.rescheduleJob("timeNoticeTrigger"+n.getId(), "TimeNoticeJobGroup"+srv.getRegionId()+"_"+srv.getId(), simpleTrigger);
            }
            triggerList.add(simpleTrigger);
            if(!scheduler.isStarted())
            {
            	scheduler.start();
            }
            telnetlog.info("*******schedule end***************");
        } catch (SchedulerException e) {
        	e.printStackTrace();
        	telnetlog.error(e.getMessage());
        }
    }


	/* (non-Javadoc)
	 * @see com.mop.lzr.gm.service.job.SchedulerService#monitorSvr()
	 */
	@Override
	public void monitorSvr() {
		boolean checkSwitch = SystemConstants.getScanState();
		if(checkSwitch){
			try {
				Scheduler scheduler= StdSchedulerFactory.getDefaultScheduler();
				JobDetail jobDetail = new JobDetail("monitorSvrTrigger", "monitorSvrGroup",ServerAlertJob.class);
				scheduler.addJob(jobDetail, true);
				SimpleTrigger simpleTrigger = new SimpleTrigger("monitorSvrTrigger","monitorSvrGroup",jobDetail.getName(),jobDetail.getGroup(),new Date(), null, SimpleTrigger.REPEAT_INDEFINITELY,SystemConstants.SCHINTERVAL_TIME*60*1000);

				 if(!triggerList.contains(simpleTrigger)){
		            	telnetlog.info("monitorSvrTrigger:"+simpleTrigger.getFullName()+"   scheduleJob");
		            	scheduler.scheduleJob(simpleTrigger);
		            }else{
		            	 telnetlog.info("monitorSvrTrigger:"+simpleTrigger.getFullName()+"   rescheduleJob");
		            	scheduler.rescheduleJob("monitorSvrTrigger","monitorSvrGroup", simpleTrigger);
		            }
		            triggerList.add(simpleTrigger);

		            if(!scheduler.isStarted())
		            {
		            	scheduler.start();
		            }
			} catch (Exception e) {
				telnetlog.error("Exception:",e);
				e.printStackTrace();
			}
		}

	}

	}

