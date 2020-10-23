package com.imop.lj.gm.service.job;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

import org.apache.log4j.Logger;
import org.quartz.Job;
import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.GameServerVO;
import com.imop.lj.gm.dto.ServerStateVO;
import com.imop.lj.gm.dto.WorldServerVO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.maintenance.SvrStatusService;
import com.imop.lj.gm.utils.SpringContext;

/**
 * @author linfan
 * @author kai.shi
 */
public class ServerAlertJob implements Job {

	/** 记录每组服务器MAP,KEY 值记录大区ID(rId),value值 WorldServerVO */
	private static TreeMap<String, TreeMap<String, WorldServerVO>> regionGroupList = new TreeMap<String, TreeMap<String, WorldServerVO>>();

	private static ServerAlertJob _inst;

	private Logger telnetlog = Logger.getLogger("telnet");

	private SpringContext wac = SpringContext.getInstance();

	private DBFactoryService dbFactoryService = (DBFactoryService) (wac
			.getBean("dbFactoryService"));

	private CmdManageService cmdManageService = (CmdManageService) (wac
			.getBean("cmdManageService"));

	private SvrStatusService svrStatusService = (SvrStatusService) (wac
			.getBean("svrStatusService"));

	public static TreeMap<String, TreeMap<String, WorldServerVO>> getRegionGroupList() {
		return regionGroupList;
	}

	public static void setRegionGroupList(
			TreeMap<String, TreeMap<String, WorldServerVO>> regionGroupList) {
		ServerAlertJob.regionGroupList = regionGroupList;
	}

	public static ServerAlertJob getInstance() {
		if (_inst == null) {
			_inst = new ServerAlertJob();
		}
		return _inst;
	}

	@Override
	public void execute(JobExecutionContext paramJobExecutionContext)
			throws JobExecutionException {
		boolean checkSwitch = SystemConstants.getScanState();
		if(checkSwitch){
			String info = "--------------------------"
					+ new Date(System.currentTimeMillis())
					+ " AlertJob Start-------------------";
			System.out.println(info);
			telnetlog.info(info);
			scanSvr();
			info = "--------------------------"
					+ new Date(System.currentTimeMillis())
					+ " AlertJob End-------------------";
			System.out.println(info);
			telnetlog.info(info);
		}
	}

	@SuppressWarnings("unchecked")
	public synchronized void scanSvr() {
		//得到大区Map<大区id，大区名字>
		Map<String, String> regionMap = DBFactoryService.getRegionMap();
		//遍历大区
		for (Map.Entry<String, String> m : regionMap.entrySet()) {
			List<DBServer> dbSvrList = dbFactoryService.getServerList(m
					.getKey());
			TreeMap<String, WorldServerVO> worldServerMap = new TreeMap<String, WorldServerVO>(
					new Comparator() {
						@Override
						public int compare(Object paramT1, Object paramT2) {
							return paramT1.hashCode() - paramT2.hashCode();
						}

					});
			for (int i = 0; i < dbSvrList.size(); i++) {
				DBServer dbSvr = dbSvrList.get(i);
				if (dbSvr.isGM()) {
					continue;
				}
				WorldServerVO worldServer = new WorldServerVO();
				worldServer.setServerName("WorldServer");
				ArrayList<ServerStateVO> svrList = new ArrayList<ServerStateVO>();

				List<GameServerVO> wsList = svrStatusService.getWSList(dbSvr);
				if (!wsList.isEmpty()) {
					GameServerVO wsSer = wsList.get(0);
					worldServer.setSvrVersion(wsSer.getVersion());
					worldServer.setServerName(wsSer.getServerName());
					worldServer.setLoginWallEnabled(wsSer.getLoginWallEnabled());
					worldServer.setState(true);
					worldServer.setType("ws");
				}

				List<GameServerVO> gameServerList = svrStatusService
						.getGameServerList(dbSvr);
				ServerStateVO svr = null;
				int totalNum = 0;
				for (int j = 0; j < gameServerList.size(); j++) {
					svr = new ServerStateVO();
					GameServerVO gsSer = gameServerList.get(j);
					svr.setServerName(gsSer.getServerName());
					svr.setOnlineNum(gsSer.getOnlineNum());
					svr.setState(true);
					svr.setType("gs");
					totalNum = totalNum + svr.getOnlineNum();
					svrList.add(svr);
				}
				worldServer.setOnlineNum(totalNum);

				DBServer dbServer = svrStatusService.getDbServerStatus(dbSvr);
				svr = new ServerStateVO();
				svr.setType("db");
				if (dbServer != null) {
					svr.setServerName(dbServer.getServerName());
					svr.setState(dbServer.isConnectStatus());
					ParamGenericDAO dao = new ParamGenericDAO();
					dao.setRId(dbServer.getRegionId());
					dao.setSId(dbServer.getId());
					dao.setDbFactoryService(dbFactoryService);
					svr.setSvrVersion(dao.getDBVersion());
					worldServer.setDbServer(svr);
				}

				worldServer.setSvrList(svrList);
				worldServerMap.put(dbSvr.getId(), worldServer);
			}
			regionGroupList.put(m.getKey(), worldServerMap);
		}
	}


}
