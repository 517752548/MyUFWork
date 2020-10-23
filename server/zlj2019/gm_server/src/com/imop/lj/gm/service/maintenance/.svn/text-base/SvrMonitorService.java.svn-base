package com.imop.lj.gm.service.maintenance;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.ServerStateVO;
import com.imop.lj.gm.dto.WorldServerVO;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.job.ServerAlertJob;

/**
 * 报警监控Service
 *
 */
public class SvrMonitorService {

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/**服务器状态Service */
	private SvrStatusService svrStatusService;

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public SvrStatusService getSvrStatusService() {
		return svrStatusService;
	}

	public void setSvrStatusService(SvrStatusService svrStatusService) {
		this.svrStatusService = svrStatusService;
	}



	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}


	/**
	 * 得到svrGroupList
	 * @param loginRegionId
	 * @return
	 */
	public Map<String, WorldServerVO> getSvrGroupList(String loginRegionId) {
		return ServerAlertJob.getRegionGroupList().get(loginRegionId);
	}


	/**
	 * 得到World Server 的对象列表
	 *
	 * @return World Server对象列表
	 */
	public String getS1Version() {
		String version = "";
		String cmd = "ws_status";
		DBServer dBServer= dbFactoryService.getServer(LoginUserService.getLoginRegionId(),dbFactoryService.getS1DbId(LoginUserService.getLoginRegionId()));
		List<String> jostring = cmdManageService.sendCmd(cmd, dBServer,true);
		String result = jostring.toString();
		if(result.indexOf("error")!=-1||result.indexOf("slave")!=-1||result.indexOf("unknown")!=-1){
			return version;
		}
		if(result.startsWith("[")){
			JSONArray _arrays = JSONArray.fromObject(result);
			for (int i = 0; i < _arrays.size();) {
				JSONObject o = (JSONObject) _arrays.get(i);
				 version = o.getString("version");
				 break;
				}
		}
		return version;
	}

	/**
	 * 得到防火墙状态
	 * @param rid
	 * @param svrId
	 * @return
	 */
	public String getLoginWallStatus(String svrId){
		String loginWall = "";
		WorldServerVO wsVo = ServerAlertJob.getRegionGroupList().get(LoginUserService.getLoginRegionId()).get(svrId);
		if(wsVo.getLoginWallEnabled() != null)
		{
			loginWall = wsVo.getLoginWallEnabled();
		}
		return loginWall;

	}


}
