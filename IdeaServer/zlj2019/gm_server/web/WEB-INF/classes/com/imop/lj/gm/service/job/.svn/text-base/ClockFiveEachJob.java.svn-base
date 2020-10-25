package com.imop.lj.gm.service.job;

import com.imop.lj.core.util.HttpUtil;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.utils.SpringContext;
import net.sf.json.JSONObject;
import org.apache.log4j.Logger;
import org.quartz.Job;
import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;

import java.io.File;
import java.io.IOException;
import java.util.List;


public class ClockFiveEachJob implements Job {

	private Logger clock0JobLog = Logger.getLogger("ClockFiveEachJob");
	private final String apiurl = "http://api.ts.wywlwx.com.cn/channel/wingloong/updateserver?";
	private static SpringContext wac = SpringContext.getInstance();
	private static DBFactoryService dbFactoryService = (DBFactoryService) (wac
			.getBean("dbFactoryService"));
	@Override
	public void execute(JobExecutionContext arg0)
			throws JobExecutionException {

		JSONObject js = dbFactoryService.getDbJson();
		if(js.size()==0){
			return;
		}
		System.out.println("js"+js.toString());
		try {
			HttpUtil.postUrlJson(apiurl,js.toString());
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	

}
