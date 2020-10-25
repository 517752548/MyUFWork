package com.imop.lj.gm.service.log;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.log.LogReasonDAO;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;


/**
 *
 * 日志表加载 Service
 * @author lin fan
 *
 */
public class LogReasonService {

	private LogReasonDAO logReasonDAO;


	private DBFactoryService dbFactoryService;

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}
	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}
	public LogReasonDAO getLogReasonDAO() {
		return logReasonDAO;
	}
	public void setLogReasonDAO(LogReasonDAO logReasonDAO) {
		this.logReasonDAO = logReasonDAO;
	}

	/**
	 * 日志Type映射表
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public Map getLogTypes() {
		Map logTypeMap = new HashMap();
		List logTypes = logReasonDAO.getLogTypeList();
		if(logTypes!=null){
			for(int i=0;i<logTypes.size();i++){
				Object []  temp  =  (Object[]) logTypes.get(i);
				logTypeMap.put(temp[0], temp[1]);
			}
		}
		return logTypeMap;
	}
	/**
	 * 日志Type映射表
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public Map getLogNameList() {
		Map logNameMap = new HashMap();
		String svrId = LoginUserService.getLoginServerId();
		if(svrId.indexOf("log_")==-1){
			svrId = "log_"+svrId;
		}
		ParamGenericDAO dao = new ParamGenericDAO();
		dao.setRId(LoginUserService.getLoginRegionId());
		dao.setSId(svrId);
		dao.setDbFactoryService(dbFactoryService);
		List logTypes = dao.getLogNameList();
		//[company_log, 公司, 549]   [learn_gift_log, 学习属性, 533]
		if(logTypes!=null){
			for(int i=0;i<logTypes.size();i++){
				Object []  temp  =  (Object[]) logTypes.get(i);
				//log日志过滤
				if(!temp[0].equals("company_log") && !temp[0].equals("learn_gift_log")){
					logNameMap.put(temp[0], temp[1]);
				}
			}
		}
		return logNameMap;
	}

	/**
	 * 日志原因映射表
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public Map getLogReasons(String logTable) {
		Map logReasonMap = new TreeMap();
		List logReasons = logReasonDAO.getLogReason(logTable);
		for(int i=0;i<logReasons.size();i++){
			Object []  temp  =  (Object[]) logReasons.get(i);
			logReasonMap.put(temp[0].toString(), temp[1].toString());
		}
		return logReasonMap;
	}
}




