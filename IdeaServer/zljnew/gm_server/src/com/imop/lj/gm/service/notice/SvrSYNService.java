package com.imop.lj.gm.service.notice;

import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import net.sf.json.JSONObject;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.PrizeInfo;
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
 * 服务器同步 Service
 *
 *
 */
public class SvrSYNService {

	/** SvrSYNService LOG */
	private static final Logger logger = LoggerFactory.getLogger("telnet");

	private CmdManageService cmdManageService;

	private GameNoticeDAO gameNoticeDAO;

	private TimeNoticeDAO timeNoticeDAO;

	private DBFactoryService dbFactoryService;

	private PrizeDAO prizeDAO;

	private JobManageService jobManageService;

	/** 处理Excel的多语言Service */
	private ExcelLangManagerService excelLangManagerService;
	//内置浏览器服务
	private BrosorUrlService brosorUrlService;

	public BrosorUrlService getBrosorUrlService() {
		return brosorUrlService;
	}

	public void setBrosorUrlService(BrosorUrlService brosorUrlService) {
		this.brosorUrlService = brosorUrlService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

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
	 * 服务器同步
	 *
	 * @param contents
	 *            内容
	 * @param ids
	 *            服务器ID
	 * @return
	 */
	public String synchronize(String[] contents, String id, DBServer svr) {
		StringBuilder result = new StringBuilder();
		List<String> serverIds = cmdManageService.getServerIds(svr);
		if (!("[]").equals(serverIds.toString())
				&& SvrStatusService.canConnect(svr)) {
			StringBuilder serverIdStr = new StringBuilder();
			logger.info("*********************Server synchronize data start**************************** ");
			LogUtil.logInfo(logger, "");
			result.append(ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+svr.getDbServerName()+"----------------"+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+ExcelLangManagerService.readGmLang(GMLangConstants.START)+"\n\r");
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
					synTimeNotice(serverIdStr.toString(),synLineId.toString(),id);
					result.append("\t"+ExcelLangManagerService.readGmLang(GMLangConstants.WEL_TIME_NOTICE)+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+"--------------"+ExcelLangManagerService.readGmLang(GMLangConstants.CMDSUCCESS)+"\n\r");
					break;
				case 2:
					synGameNotice(serverIdStr.toString(),id,svr);
					result.append("\t"+ExcelLangManagerService.readGmLang(GMLangConstants.GAME)+
							ExcelLangManagerService.readGmLang(GMLangConstants.NOTICE)+
							ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+"--------------"+ExcelLangManagerService.readGmLang(GMLangConstants.CMDSUCCESS)+"\n\r");
					break;
				case 3:
					synPrize(id);
					result.append("\t"+ExcelLangManagerService.readGmLang(GMLangConstants.PRIZE)+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+"--------------"+ExcelLangManagerService.readGmLang(GMLangConstants.CMDSUCCESS)+"\n\r");
					break;
//				case 5:
//					//TODO
//					if(synBrosorUrl(id,svr)){
//						result.append("\t"+ExcelLangManagerService.readGmLang(GMLangConstants.BROSORURL_URLURL)+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+"--------------"+ExcelLangManagerService.readGmLang(GMLangConstants.CMDSUCCESS)+"\n\r");
//					}else{
//						result.append("\t"+ExcelLangManagerService.readGmLang(GMLangConstants.BROSORURL_URLURL)+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+"--------------"+ExcelLangManagerService.readGmLang(GMLangConstants.BROSORURL_UPDATEURLFAILURE)+"\n\r");
//					}
//						break;
				default:
					break;
				}
			}
			result.append(ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+svr.getDbServerName()+"----------------"+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+ExcelLangManagerService.readGmLang(GMLangConstants.END));
		}else{
			result.append(ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER)+":"+svr.getDbServerName()+ExcelLangManagerService.readGmLang(GMLangConstants.ERR_TELNET_AS_DISCON));
		}
		logger.info("*********************Server synchronize data end**************************** ");
		return result.toString();

	}
	
//	/**
//	 * 同步url内置浏览器
//	 *
//	 * @param id
//	 *            目标服ID
//	 * @param serverIds
//	 *            取得目标服的所有线的id，逗号拼成字符串
//	 */
//	private Boolean synBrosorUrl(String id,DBServer svr) {
//		logger.info("delete Target service :" + id + " -- BrosorUrl data ");
//		String result = "";
//		String rId = LoginUserService.getLoginRegionId();
//		ParamGenericDAO s1Dao = new ParamGenericDAO();
//		s1Dao.setRId(rId);
//		s1Dao.setSId(SystemConstants.DB_TEMPLATE);
//		s1Dao.setDbFactoryService(dbFactoryService);
//		List<BroserEntity> listS1 = s1Dao.getAllBroserList();
//		ParamGenericDAO dao = new ParamGenericDAO();
//		dao.setRId(rId);
//		dao.setSId(id);
//		dao.setDbFactoryService(dbFactoryService);
//		List<BroserEntity> list = dao.getAllBroserList();
//		for (BroserEntity p : list) {
//			logger.info("BroserEntity id :" + p.getId() + "\t BroserEntity TerminalType :"
//					+ p.getTerminalType()+ "\t BroserEntity brosorUrl :"
//					+ p.getBrosorUrl()+ "\t BroserEntity brosorUrlType :"
//					+ p.getBrosorUrlType());
//		}
//		dao.delALLBrosorUrl();
//		logger.info("input syn data -- BroserEntity ");
//		for (BroserEntity p : listS1) {
//			p.setUpdateTime(new Timestamp(new Date().getTime()));
//			Integer newerId = (Integer) dao.save(p);
//			p.setId(newerId);
//			logger.info("BroserEntity id :" + p.getId()+ "\t BroserEntity TerminalType :"
//					+ p.getTerminalType()+ "\t BroserEntity brosorUrl :"
//					+ p.getBrosorUrl()+ "\t BroserEntity brosorUrlType :"
//					+ p.getBrosorUrlType());
//
//		}
//		logger.info("success：(syn server：" + id + ")\t BroserEntity \t");
//		for (BroserEntity p : listS1) {
//			//未成功继续发送
////			while(!isSuccess){
////			brosorUrlService.releaseTimeNoticeAnsyc(p, svr);
////			}
//			if(!brosorUrlService.releaseTimeNoticeAnsyc(p, svr)){
//				logger.info("BroserEntity id :" + p.getId()+ "\t BroserEntity TerminalType :"
//						+ p.getTerminalType()+ "\t BroserEntity brosorUrl :"
//						+ p.getBrosorUrl()+ "\t BroserEntity brosorUrlType :"
//						+ p.getBrosorUrlType()
//						+ "\t DBServer ConnectTime :"+svr.getConnectTime()
//						+ "\t DBServer DbIp :"+svr.getDbIp()
//						+ "\t DBServer DbName :"+	svr.getDbName()
//						+ "\t DBServer DbPassword :"+	svr.getDbPassword()
//						+ "\t DBServer Dbport :"+	svr.getDbport()
//						+ "\t DBServer DbServerName :"+	svr.getDbServerName()
//						+ "\t DBServer DbType :"+	svr.getDbType()
//						+ "\t DBServer DbUsername :"+	svr.getDbUsername()
//						+ "\t DBServer Id :"+	svr.getId()
//						+ "\t DBServer PrvColor :"+	svr.getPrvColor()
//						+ "\t DBServer RegionId :"+	svr.getRegionId()
//						+ "\t DBServer RegionName :"+	svr.getRegionName()
//						+ "\t DBServer ServerId :"+	svr.getServerId()
//						+ "\t DBServer ServerName :"+	svr.getServerName()
//						+ "\t DBServer ServerURL :"+	svr.getServerURL()
//						+ "\t DBServer TelnetIp :"+	svr.getTelnetIp()
//						+ "\t DBServer TelnetPort :"+	svr.getTelnetPort()
//						);
//				return false;
//			}
//		}
//		return true;
//	}
	/**
	 * 同步定时公告
	 *
	 * @param id
	 *            目标服ID
	 * @param serverIds
	 *            取得目标服的所有线的id，逗号拼成字符串
	 */
	private void synTimeNotice(String serverIds,String synLineId,String id) {
		logger.info("delete Target service :" + id + " -- time notice data ");
		String rId = LoginUserService.getLoginRegionId();
		ParamGenericDAO s1Dao = new ParamGenericDAO();
		s1Dao.setRId(rId);
		s1Dao.setSId(dbFactoryService.getS1DbId(rId));
		s1Dao.setDbFactoryService(dbFactoryService);
		List<TimeNotice> listS1 = s1Dao.getTimeNotices();
		ParamGenericDAO dao = new ParamGenericDAO();
		dao.setRId(rId);
		dao.setSId(id);
		dao.setDbFactoryService(dbFactoryService);
		List<TimeNotice> list = dao.getTimeNotices();
		for (TimeNotice t : list) {
			String timeNoticeId = String.valueOf(t.getId());
			logger.info("TimeNotice id :" + timeNoticeId
					+ "\t TimeNotice content :" + t.getContent());
			jobManageService.stopJob(rId, timeNoticeId, id);
		}

		dao.delALLTimeNotices();

		logger.info("input syn data -- time notice ");
		for (TimeNotice t : listS1) {
			logger.info("TimeNotice id :" + t.getId()
					+ "\t TimeNotice content :" + t.getContent());
			byte openType = t.getOpenType();
			if("0".equals(String.valueOf(openType))){
				t.setServerIds(serverIds);
			}else {
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
			jobManageService.addJob(rId, id, cmd, t);
		}
		logger.info("success：(syn server：" + id + ")\t time notice\t");
	}

	/**
	 * 同步游戏公告
	 *
	 * @param id
	 *            目标服ID
	 * @param serverIds
	 *            取得目标服的所有线的id，逗号拼成字符串
	 */
	private void synGameNotice(String serverIds,String id,DBServer svr) {
		logger.info("delete Target service :" + id + " -- game notice data ");
		String rId = LoginUserService.getLoginRegionId();
		ParamGenericDAO s1Dao = new ParamGenericDAO();
		s1Dao.setRId(rId);
		s1Dao.setSId(dbFactoryService.getS1DbId(rId));
		s1Dao.setDbFactoryService(dbFactoryService);
		List<GameNotice> gameNoticeS1List = s1Dao.getValidGameNoticeList();
		GameNotice gameNoticeS1 = null;
		if(!gameNoticeS1List.isEmpty()){
			 gameNoticeS1 = gameNoticeS1List.get(0);
		}
		ParamGenericDAO dao = new ParamGenericDAO();
		dao.setRId(rId);
		dao.setSId(id);
		dao.setDbFactoryService(dbFactoryService);
		List<GameNotice> gameNoticeList = dao.getValidGameNoticeList();
		GameNotice gameNotice = null;
		if(!gameNoticeList.isEmpty()){
			gameNotice = gameNoticeList.get(0);
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
		logger.info("success：(syn server：" + id + ")\t game notice\t");
	}

	/**
	 * 同步发奖礼包
	 *
	 * @param id
	 *            目标服ID
	 * @param serverIds
	 *            取得目标服的所有线的id，逗号拼成字符串
	 */
	private void synPrize(String id) {
		logger.info("delete Target service :" + id + " -- prize data ");
		String rId = LoginUserService.getLoginRegionId();
		ParamGenericDAO s1Dao = new ParamGenericDAO();
		s1Dao.setRId(rId);
		s1Dao.setSId(dbFactoryService.getS1DbId(rId));
		s1Dao.setDbFactoryService(dbFactoryService);
		List<PrizeInfo> listS1 = s1Dao.getPrizes();
		ParamGenericDAO dao = new ParamGenericDAO();
		dao.setRId(rId);
		dao.setSId(id);
		dao.setDbFactoryService(dbFactoryService);
		List<PrizeInfo> list = dao.getPrizes();
		for (PrizeInfo p : list) {
			logger.info("PrizeInfo id :" + p.getId() + "\t PrizeInfo Name :"
					+ p.getPrizeName());
		}
		dao.delALLPrizes();
		logger.info("input syn data -- prize ");
		for (PrizeInfo p : listS1) {
			p.setCreateTime(new Timestamp(new Date().getTime()));
			Integer newerId = (Integer) dao.saveObject(p);
			p.setId(newerId);
			logger.info("Prize id :" + p.getId()
					+ "\t Prize Name :" + p.getPrizeName());

		}
		logger.info("success：(syn server：" + id + ")\t prize \t");
	}
}
