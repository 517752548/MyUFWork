package com.imop.lj.gm.service.maintenance;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.GameServerVO;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.platform.core.log.Loggers;

/**
 * 服务器状态
 *
 *
 */
public class SvrStatusService {

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	/**
	 * 得到GameServer 的 对象列表
	 *
	 * @return GameServer对象列表
	 */
	public List<GameServerVO> getGameServerList(DBServer svr) {
		String cmd = "gs_status";
		List<GameServerVO> gameServerList= getServerObjectList(svr,cmd);
		return gameServerList;
	}


	/**
	 * 得到DBS Server 的对象列表
	 *
	 * @return DBS Server对象列表
	 */
	public List<GameServerVO> getDBSList(DBServer svr) {
		String cmd = "dbs_status";
		List<GameServerVO> dBSList= getServerObjectList(svr,cmd);
		return dBSList;
	}


	/**
	 * 得到World Server 的对象列表
	 *
	 * @return World Server对象列表
	 */
	public List<GameServerVO> getWSList(DBServer svr) {
		String cmd = "ws_status";
		List<GameServerVO> wSList= getServerObjectList(svr,cmd);
		return wSList;
	}


	/**
	 * 得到Login Server 的对象列表
	 *
	 * @return World Server对象列表
	 */
	public List<GameServerVO> getLSList(DBServer svr) {
		String cmd = "ls_status";
		List<GameServerVO> lSList= getServerObjectList(svr,cmd);
		return lSList;
	}

	/**
	 * 得到Agent Server 的对象列表
	 *
	 * @return World Server对象列表
	 */
	public List<GameServerVO> getASList(DBServer svr) {
		String cmd = "as_status";
		List<GameServerVO> aSList= getServerObjectList(svr,cmd);
		return aSList;
	}

	/**
	 * 得到LOG Server 的对象列表
	 *
	 * @return LOG Server对象列表
	 */
	public List<GameServerVO> getLogSvrList(DBServer svr) {
		String cmd = "log_status";
		List<GameServerVO> logSvrList= getServerObjectList(svr,cmd);
		return logSvrList;
	}



	/**
	 * 得到各服务器总的在线人数
	 * @param gameServerList
	 * @return 总的在线人数
	 */
	public int getTotalOnlineNum(List<GameServerVO> gameServerList) {
		int totalOnlineNum = 0;
		for(int i=0;i<gameServerList.size();i++){
			totalOnlineNum += gameServerList.get(i).getOnlineNum();
		}
		return totalOnlineNum;
	}

	/**
	 * 得到DbServer的Status
	 * @param svr
	 * @return DbServer的Status
	 */
	public DBServer getDbServerStatus(DBServer svr) {
	    long time1 = System.currentTimeMillis();
	    boolean canConnect = canConnect(svr);
		long time2 = System.currentTimeMillis();
		long time = time2 - time1;
		svr.setConnectStatus(canConnect);
		svr.setConnectTime(time);
		return svr;
	}

	public static boolean canConnect(DBServer svr) {
		try {
			Class.forName("com.mysql.jdbc.Driver");
		} catch (ClassNotFoundException e1) {
			e1.printStackTrace();
		}
		String url = "jdbc:mysql://" + svr.getDbIp() +":"+svr.getDbport()+ "/"
				+ svr.getDbName() + "?user=" + svr.getDbUsername() + "&password="
				+ svr.getDbPassword()
				+ "&useUnicode=true&characterEncoding=utf-8";
		System.out.println("url:"+url);
		try {
		    Connection c = DriverManager.getConnection(url);
			c.close();
			return true;
		} catch (SQLException e) {
			Loggers.getGmLogger().error("连接失败",e);
			return false;
		}
	}

	public List<GameServerVO>  getServerObjectList(DBServer svr,String cmd){
		List<GameServerVO> serverObjectList = new ArrayList<GameServerVO>();
		List<String> jostring = cmdManageService.sendCmd(cmd, svr,true);
		String result = jostring.toString();
		if("gs_status".equals(cmd) || "log_status".equals(cmd)){
			result = result.substring(1, result.length()-1);
		}
		if(result.indexOf("error")!=-1||result.indexOf("slave")!=-1||result.indexOf("unknown")!=-1){
			return serverObjectList;
		}
		if(result.startsWith("[")){
			JSONArray _arrays = JSONArray.fromObject(result);
			for (int i = 0; i < _arrays.size(); i++) {
				JSONObject o = (JSONObject) _arrays.get(i);
				GameServerVO vo = new GameServerVO();

				vo.setServerName(o.getString("name"));
				vo.setServerType(o.getInt("type"));
				if("gs_status".equals(cmd) || "as_status".equals(cmd)){
					if(o.has("onlinePlayerCount")){
						vo.setOnlineNum(o.getInt("onlinePlayerCount"));
					}
					if(o.has("loginWallEnabled")){
						vo.setLoginWallEnabled(o.getString("loginWallEnabled"));
					}
					if(o.has("wallowControlled")){
						vo.setWallowControlled(Boolean.valueOf(o.getString("wallowControlled")));
					}
				}
				if("dbs_status".equals(cmd)){
					if(o.has("agentStatus")){
						vo.setAgentStatus(o.getString("agentStatus"));
					}
				}
				if("ws_status".equals(cmd)){
					if(o.has("loginWallEnabled")){
						vo.setLoginWallEnabled(o.getString("loginWallEnabled"));
					}
					if(o.has("petCacheStatus")){
						vo.setPetCacheStatus(o.getString("petCacheStatus"));
					}
					if(o.has("itemCacheStatus")){
						vo.setItemCacheStatus(o.getString("itemCacheStatus"));
					}
				}
				vo.setIp(o.getString("ip"));
				vo.setPort(o.getString("port"));
				vo.setVersion(o.getString("version"));
				vo.setFreeMemory(o.getLong("freeMemory"));
				vo.setUsedMemory(o.getLong("usedMemory"));
				vo.setTotalMemory(o.getLong("totalMemory"));
				vo.setCpuRate(o.getDouble("cpuUsageRate"));
				vo.setTimestamp(DateUtil.formateDateLong(o.getLong("lastUpdateTime")));
				serverObjectList.add(vo);
			}
		}
		return serverObjectList;

	}


}
