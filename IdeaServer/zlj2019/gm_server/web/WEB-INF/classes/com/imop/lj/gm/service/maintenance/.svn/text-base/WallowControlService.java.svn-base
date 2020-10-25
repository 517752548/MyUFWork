package com.imop.lj.gm.service.maintenance;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.GameServerVO;
import com.imop.lj.gm.service.db.DBFactoryService;

/**
 *
 * 反沉迷Service
 *
 */
public class WallowControlService {

	/**命令管理 Service */
	private CmdManageService cmdManageService;

	/**服务器状态 */
	private SvrStatusService svrStatusService;

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public SvrStatusService getSvrStatusService() {
		return svrStatusService;
	}

	public void setSvrStatusService(SvrStatusService svrStatusService) {
		this.svrStatusService = svrStatusService;
	}

	/**
	 * 得到带有放沉迷状态颜色的DBServer,显示用
	 * @param name 操作人
	 * @param name 操作人的可以管理的svrIds
	 * @return 带有权限颜色的DBServer列表
	 */
	@SuppressWarnings("unchecked")
	public  List<DBServer> getWallowColorDBServer(String name ,String svrIds, String regionId){
		List<DBServer> svrList = new ArrayList();
		List<DBServer> svrs= DBFactoryService.getServers(svrIds, regionId);
		for (int i = 0; i < svrs.size(); i++) {
			DBServer dBServer = svrs.get(i);
			String cmd = "gs_status";
				List<GameServerVO> lsList= svrStatusService.getServerObjectList(dBServer,cmd);
				if(lsList.size()==0){
					dBServer.setPrvColor("red");
				}else{
					boolean _status = lsList.get(0).getWallowControlled();
					if(_status){
						dBServer.setPrvColor("#00ff00");
					}else{
						dBServer.setPrvColor("yellow");
					}
				};
			svrList.add(dBServer);
		}
		return svrList;
	}

}
