/**
 *
 */
package com.imop.lj.gm.service.notice;

import java.util.List;

import net.sf.json.JSONObject;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.maintenance.PrizeDAO;
import com.imop.lj.gm.dao.notice.GameNoticeDAO;
import com.imop.lj.gm.dao.notice.TimeNoticeDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.model.notice.GameNotice;
import com.imop.lj.gm.model.notice.TimeNotice;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.job.JobManageService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.maintenance.SvrStatusService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LogUtil;

/**
 * 大区同步 Service
 *
 * @author linfan
 *
 */
public class RegionSYNService {

	/** RegionSYNService LOG */
	private static final Logger logger = LoggerFactory.getLogger("telnet");

	/** 管理数据库大区Service */
	private DBFactoryService dbFactoryService;

	private CmdManageService cmdManageService;

	private GameNoticeDAO gameNoticeDAO;

	private TimeNoticeDAO timeNoticeDAO;


	private PrizeDAO prizeDAO;

	private JobManageService jobManageService;


	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	/** 处理Excel的多语言Service */
	private ExcelLangManagerService excelLangManagerService;


	public PrizeDAO getPrizeDAO() {
		return prizeDAO;
	}

	public void setPrizeDAO(PrizeDAO prizeDAO) {
		this.prizeDAO = prizeDAO;
	}

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
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

	public GameNoticeDAO getGameNoticeDAO() {
		return gameNoticeDAO;
	}

	public void setGameNoticeDAO(GameNoticeDAO gameNoticeDAO) {
		this.gameNoticeDAO = gameNoticeDAO;
	}

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	/**
	 * 大区同步
	 *
	 * @param contents
	 *            内容
	 * @param rid
	 *            大区ID
	 * @return
	 */
	public String synchronize(String[] contents, String rid) {
		StringBuilder result = new StringBuilder();
		DBServer svr = dbFactoryService.getServer(rid,dbFactoryService.getS1DbId(rid));
		List<String> serverIds = cmdManageService.getServerIds(svr);
		if (!("[]").equals(serverIds.toString())
				&& SvrStatusService.canConnect(svr)) {
			StringBuilder serverIdStr = new StringBuilder();
			logger.info("*********************Region synchronize data start**************************** ");
			LogUtil.logInfo(logger, "");
			result.append(ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+svr.getRegionName()+"----------------"+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+ExcelLangManagerService.readGmLang(GMLangConstants.START)+"\n\r");
			StringBuffer synLineId = new StringBuffer();
			for (String gs : serverIds) {
				serverIdStr.append(gs).append(',');
				synLineId.append(gs.substring(gs.length()-1)).append(',');
			}
			if (serverIdStr.length() > 0)
				serverIdStr = new StringBuilder(serverIdStr.substring(0,
						serverIdStr.length() - 1));
			for (int i = 0; i < contents.length; i++) {
				int contentId = Integer.valueOf(contents[i]);
				switch (contentId) {
				case 1:
					synTimeNotice(serverIdStr.toString(),synLineId.toString(),rid);
					result.append("\t"+ExcelLangManagerService.readGmLang(GMLangConstants.WEL_TIME_NOTICE)+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+"--------------"+ExcelLangManagerService.readGmLang(GMLangConstants.CMDSUCCESS)+"\n\r");
					break;
				case 2:
					synGameNotice(serverIdStr.toString(),rid,svr);
					result.append("\t"+ExcelLangManagerService.readGmLang(GMLangConstants.GAME)+
							ExcelLangManagerService.readGmLang(GMLangConstants.NOTICE)+
							ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+"--------------"+ExcelLangManagerService.readGmLang(GMLangConstants.CMDSUCCESS)+"\n\r");
					break;
				case 3:
					synPrize(rid);
					result.append("\t"+ExcelLangManagerService.readGmLang(GMLangConstants.PRIZE)+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+"--------------"+ExcelLangManagerService.readGmLang(GMLangConstants.CMDSUCCESS)+"\n\r");
					break;
				default:
					break;
				}
			}
			result.append(ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+svr.getRegionName()+"----------------"+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+ExcelLangManagerService.readGmLang(GMLangConstants.END));
		}else{
			result.append(ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)+":"+svr.getRegionName()+ExcelLangManagerService.readGmLang(GMLangConstants.ERR_TELNET_AS_DISCON));
		}
		logger.info("*********************Region synchronize data end**************************** ");
		return result.toString();

	}

	/**
	 * 同步定时公告
	 *
	 * @param rid
	 *            目标大区ID
	 * @param serverIds
	 *            取得目标服的所有线的id，逗号拼成字符串
	 */
	private void synTimeNotice(String serverIds,String synLineId,String rid) {
		logger.info("delete Target Region :" + rid + "(S1) -- time notice data ");
		String srcRegionId  = LoginUserService.getLoginRegionId();
		ParamGenericDAO s1Dao = new ParamGenericDAO();
		s1Dao.setRId(srcRegionId);
		s1Dao.setSId(dbFactoryService.getS1DbId(srcRegionId));
		s1Dao.setDbFactoryService(dbFactoryService);
		List<TimeNotice> srcList = s1Dao.getTimeNotices();
		ParamGenericDAO dao = new ParamGenericDAO();
		dao.setRId(rid);
		dao.setSId(dbFactoryService.getS1DbId(rid));
		dao.setDbFactoryService(dbFactoryService);
		List<TimeNotice> desList = dao.getTimeNotices();
		for (TimeNotice t : desList) {
			String timeNoticeId = String.valueOf(t.getId());
			logger.info("TimeNotice id :" + timeNoticeId
					+ "\t TimeNotice content :" + t.getContent());
			jobManageService.stopJob(rid, timeNoticeId, dbFactoryService.getS1DbId(rid));
		}
		dao.delALLTimeNotices();
		logger.info("input syn data -- time notice ");
		for (TimeNotice t : srcList) {
			logger.info("TimeNotice id :" + t.getId()
					+ "\t TimeNotice content :" + t.getContent());
			byte openType = t.getOpenType();
			if("0".equals(String.valueOf(openType))){
				t.setServerIds(serverIds);
			}else{
				String[] s1SvrIds = t.getServerIds().split(",");
				StringBuffer synSvrId = new StringBuffer();
				for(int j= 0;j<s1SvrIds.length;j++){
					if(StringUtils.isBlank(s1SvrIds[j])){
						continue;
					}
					String lineId = s1SvrIds[j].substring(3);
					if(synLineId.indexOf(lineId)!=-1){
						synSvrId.append(serverIds.substring(0,3)+lineId+",");
					}
				}
				String svrId = synSvrId.toString();
				if(!svrId.isEmpty()){
					t.setServerIds(svrId.substring(0,svrId.length()-1));
				}else{
					t.setServerIds(svrId);
				}
			}
			Integer newerId = (Integer) dao.saveObject(t);
			t.setId(newerId);
			JSONObject _o = new JSONObject();
			_o.put("ids", t.getServerIds());
			_o.put("content",t.getContent());
			String cmd = "notice " + _o.toString();
			jobManageService.addJob(rid, dbFactoryService.getS1DbId(rid), cmd, t);
		}
		logger.info("success：syn region：" + rid + " (S1)-- time notice");
	}

	/**
	 * 同步游戏公告
	 *
	 * @param rid
	 *            目标大区ID
	 * @param serverIds
	 *            取得目标服的所有线的id，逗号拼成字符串
	 */
	private void synGameNotice(String serverIds, String rid,DBServer svr) {
		logger.info("delete Target Region :" + rid + " (S1)-- game notice data ");
		String srcRegionId  = LoginUserService.getLoginRegionId();
		ParamGenericDAO s1Dao = new ParamGenericDAO();
		s1Dao.setRId(srcRegionId);
		s1Dao.setSId(dbFactoryService.getS1DbId(srcRegionId));
		s1Dao.setDbFactoryService(dbFactoryService);
		List<GameNotice> srcList = s1Dao.getValidGameNoticeList();
		GameNotice gameNoticeS1 = null;
		if(!srcList.isEmpty()){
			 gameNoticeS1 = srcList.get(0);
		}
		ParamGenericDAO dao = new ParamGenericDAO();
		dao.setRId(rid);
		dao.setSId(dbFactoryService.getS1DbId(rid));
		dao.setDbFactoryService(dbFactoryService);
		List<GameNotice> desList = dao.getValidGameNoticeList();
		GameNotice gameNotice = null;
		if(!desList.isEmpty()){
			gameNotice = desList.get(0);
		}
		if(gameNotice!=null ){
			logger.info("GameNotice id :" + gameNotice.getId()
					+ "\t GameNotice content :" + gameNotice.getContent());
		}
		dao.delALLGameNotices();
		logger.info("input syn data -- game notice ");
		if(gameNoticeS1!=null){
			logger.info("GameNotice id :" + gameNoticeS1.getId()
					+ "\t GameNotice content :" + gameNoticeS1.getContent());
			gameNoticeS1.setServerIds(serverIds);
			gameNoticeS1.setStatus(SystemConstants.RELEASE);
			Integer newerId = (Integer) dao.saveObject(gameNoticeS1);
			gameNoticeS1.setId(newerId);
			JSONObject _o = new JSONObject();
			_o.put("content",gameNoticeS1.getContent());
			_o.put("type",SystemConstants.GAME_NOTICE_TYPE);
			String cmd="notice " +_o.toString() ;
			cmdManageService.sendCmd(cmd, svr,false);
		}
		logger.info("success：syn region：" + rid + " (S1)-- game notice");
	}

	/**
	 * 同步发奖礼包
	 *
	 * @param rid
	 *            目标服ID
	 * @param serverIds
	 *            取得目标服的所有线的id，逗号拼成字符串
	 */
	private void synPrize(String rid) {
		logger.info("delete Target Region :" + rid + " (S1) -- prize data ");
		String srcRegionId = LoginUserService.getLoginRegionId();
		ParamGenericDAO s1Dao = new ParamGenericDAO();
		s1Dao.setRId(srcRegionId);
		s1Dao.setSId(dbFactoryService.getS1DbId(srcRegionId));
		s1Dao.setDbFactoryService(dbFactoryService);
//		List<Prize> listS1 = s1Dao.getPrizes();
		ParamGenericDAO dao = new ParamGenericDAO();
		dao.setRId(rid);
		dao.setSId(dbFactoryService.getS1DbId(rid));
		dao.setDbFactoryService(dbFactoryService);
//		List<Prize> list = dao.getPrizes();
//		for (Prize p : list) {
//			logger.info("Prize id :" + p.getId() + "\t Prize Name :"
//					+ p.getPrizeName());
//		}
		dao.delALLPrizes();
		logger.info("input syn data -- prize ");
//		for (Prize p : listS1) {
//			p.setCreateTime(new Timestamp(new Date().getTime()));
//			Integer newerId = (Integer) dao.saveObject(p);
//			p.setId(newerId);
//			logger.info("Prize id :" + p.getId()
//					+ "\t Prize Name :" + p.getPrizeName());
//
//		}
		logger.info("success：syn region：" + rid + " (S1)-- prize");
	}


}
