package com.imop.lj.gm.service.insertDBBatch;

import java.util.List;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.web.activity.service.GMGlobals;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月20日 下午6:35:27
 * @version 1.0
 */
public class InsertDBThread extends Thread {
	
	private GenericDAO dao = null;
	private List<Object> list = null;
	private int insertCount = 0;
	private int sleepNum = 100;
	
	
	public InsertDBThread(final GenericDAO dao, final List<Object> list) {
		this.dao = dao;
		this.list = list;
		this.insertCount = 0;
		this.sleepNum = 100;
	}
	
	public InsertDBThread(final GenericDAO dao, final List<Object> list, final int sleepNum) {
		this.dao = dao;
		this.list = list;
		this.insertCount = 0;
		this.sleepNum = sleepNum;
		
	}

	@Override
	public void run() {
		if(null == dao || null == list || list.isEmpty()) {
			return;
		}
		try {
			for (Object o : list) {
				dao.save(o);
				insertCount++;
				if (sleepNum == insertCount) {
					insertCount = 0;
					sleep(100);
				}
			}
			System.out.println("InsertDBThread run time = "  + TimeUtils.formatHMTime(System.currentTimeMillis()));
		} catch (InterruptedException e) {
			GMGlobals.logger.info("InsertDBThread#run, InterruptedException=", e);
			e.printStackTrace();
		} catch (Exception ex) {
			GMGlobals.logger.info("InsertDBThread#run, Exception=", ex);
			ex.printStackTrace();
			
		}
		

	}
}
