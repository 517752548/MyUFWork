package com.imop.lj.gm.service.maintenance;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.GameServerVO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.SpringContext;

/**
 *
 * 访问控制管理 Service
 *
 */
public class AccessControlService {

	/** AccessControlService LOG */
	private static final Logger logger = LoggerFactory.getLogger("telnet");

	private static SpringContext wac = SpringContext.getInstance();

	/**命令管理 Service */
	private CmdManageService cmdManageService;

	/**服务器状态 */
	private SvrStatusService svrStatusService;

	private static ExcelLangManagerService lang = (ExcelLangManagerService) (wac
			.getBean("excelLangManagerService"));

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
	 * 命令窗口发送命令,返回影响结果
	 *
	 * @param cmd
	 *            命令
	 * @param svr
	 *            服务器
	 * @return msg
	 */
	public String sendCmdResult(String cmd, DBServer svr) {
		StringBuilder result = new StringBuilder();
			List<String> resultList = cmdManageService.sendCmd(cmd, svr,false);
			String resultStr = resultList.toString();
			if (resultStr.indexOf("error") != -1||resultStr.indexOf("slave") != -1||resultStr.indexOf("unknown") != -1) {
				logger.info("DBServer:" + svr.getDbServerName() + "--"
						+ lang.readGm(GMLangConstants.CMDFAILED));
				result.append("DBServer:" + svr.getDbServerName() + "--"
						+ lang.readGm(GMLangConstants.CMDFAILED));
			} else if (resultList.toString().indexOf("unknown") != -1) {
				logger.info("DBServer:" + svr.getDbServerName() + "--"
						+ lang.readGm(GMLangConstants.UNKNOWNCMD));
				result.append("DBServer:" + svr.getDbServerName() + "--"
						+ lang.readGm(GMLangConstants.UNKNOWNCMD));
			} else if (resultList.toString().indexOf("connect error") != -1) {
				logger.info("DBServer:" + svr.getDbServerName() + "--"
						+ lang.readGm(GMLangConstants.ERR_TELNET_AS_DISCON));
				result.append("DBServer:" + svr.getDbServerName() + "--"
						+ lang.readGm(GMLangConstants.ERR_TELNET_AS_DISCON));
			} else {
				logger.info("DBServer:" + svr.getDbServerName() + "--"
						+ lang.readGm(GMLangConstants.CMDSUCCESS));
				result.append("DBServer:" + svr.getDbServerName() + "--"
						+ lang.readGm(GMLangConstants.CMDSUCCESS));
			}


		return result.toString();
	}
	/**
	 * 得到带有权限颜色的DBServer,显示用
	 * @param name 操作人
	 * @param name 操作人的可以管理的svrIds
	 * @return 带有权限颜色的DBServer列表
	 */
	@SuppressWarnings("unchecked")
	public  List<DBServer> getPriColorDBServer(String name ,String svrIds, String regionId){
		List<DBServer> svrList = new ArrayList();
		List<DBServer> svrs= DBFactoryService.getServers(svrIds, regionId);
		for (int i = 0; i < svrs.size(); i++) {
			DBServer dBServer = svrs.get(i);
			String cmd = "gs_status";
				List<GameServerVO> lsList= svrStatusService.getServerObjectList(dBServer,cmd);
				if(lsList.size()==0){
					dBServer.setPrvColor("red");
				}else{
					String prv = lsList.get(0).getLoginWallEnabled();
					if("false".equals(prv)){
						dBServer.setPrvColor("#00ff00");
					}else if("true".equals(prv)){
						dBServer.setPrvColor("yellow");
					}
				};
			svrList.add(dBServer);
		}
		return svrList;

	}




}
