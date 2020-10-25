package com.imop.lj.gm.service.notice;

import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONObject;

import org.slf4j.Logger;

import com.imop.lj.db.model.DirtyWordsTypeEntity;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.notice.DirtyWorldsTypeDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.notice.data.DirtyWorldsNetshow;
import com.imop.lj.gm.service.notice.data.DirtyWorldsTypeEnum;
import com.imop.lj.gm.service.notice.data.MobileActivityGroupsName;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.web.activity.service.GMGlobals;
import com.imop.lj.gm.web.activity.web.ActivityCheckBoxData;

public class DirtyWorldsTypeService {
	/**db log */
	private Logger logger = GMGlobals.logger;
	
	/** 命令管理 Service */
	private CmdManageService cmdManageService;
	//可配置活动dao
	private DirtyWorldsTypeDAO dirtyWorldsTypeDAO;
	private ExcelLangManagerService excelLangManagerService;
	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}
	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}
	
	public DirtyWorldsTypeDAO getDirtyWorldsTypeDAO() {
		return dirtyWorldsTypeDAO;
	}
	public void setDirtyWorldsTypeDAO(DirtyWorldsTypeDAO dirtyWorldsTypeDAO) {
		this.dirtyWorldsTypeDAO = dirtyWorldsTypeDAO;
	}
	
	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}
	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}
	/***
	 *获得所有可配置活动
	 */
	public DirtyWorldsNetshow getMobileActivityEntityList(){
		List<DirtyWordsTypeEntity> list = getMobileActivityEntityLists();
		if(list!=null && list.size()>0){
			DirtyWorldsNetshow tmep = new DirtyWorldsNetshow(list.get(list.size()-1),this.getExcelLangManagerService());
			return tmep;
		}else{
			return null;
		}
	}
	
	
	public List<DirtyWordsTypeEntity> getMobileActivityEntityLists(){
		return this.getDirtyWorldsTypeDAO().getDirtyWorldsTypeEntityList();
	}
	
	/***
	 * 获得下拉框  初始页面展示
	 */
	public List<MobileActivityGroupsName> getMobileActivityGrops(){
		List<MobileActivityGroupsName> listTemp = new ArrayList<MobileActivityGroupsName>();
		MobileActivityGroupsName dataTemp0 = new MobileActivityGroupsName(this.getExcelLangManagerService().readGm(GMLangConstants.DIRTY_WORLDS_NET_GAMESERVER),DirtyWorldsTypeEnum.GAMESERVER.getIndex());
		listTemp.add(dataTemp0);
		
		MobileActivityGroupsName dataTemp1 = new MobileActivityGroupsName(this.getExcelLangManagerService().readGm(GMLangConstants.DIRTY_WORLDS_NET_PART),DirtyWorldsTypeEnum.PART.getIndex());
		listTemp.add(dataTemp1);
		
		MobileActivityGroupsName dataTemp2 = new MobileActivityGroupsName(this.getExcelLangManagerService().readGm(GMLangConstants.DIRTY_WORLDS_NET_FULL),DirtyWorldsTypeEnum.FULL.getIndex());
		listTemp.add(dataTemp2);
		
		return listTemp;
	}
	
	/***
	 * 复制活动
	 */
	public String copyMobileActivity(DBServer svr,String ids, String dirtyWorldsType, String regionId){
		//发送到gameserver
		String cmd = "dirtyWorldsSet";
		int type = Integer.parseInt(dirtyWorldsType);
		JSONObject json = new JSONObject();
		json.put("dirtyWorldsType", type);
		cmd = cmd + " "+json.toString();
		sendCopyMobileActivity(svr,ids,cmd, regionId);
		
		return "";
	}
	
	/***
	 * 复制活动发送各服复制消息
	 */
	public void sendCopyMobileActivity(DBServer svr,String serverIds,String cmdstr, String regionId){
		List<DBServer> list = DBFactoryService.getServers(serverIds, regionId);
		for(DBServer ser:list){
			//if(ser.getServerId()!=svr.getServerId()){
				sendActivityToGameServer(ser,cmdstr);
			//}
		}
	}
	
	//发送到gameserver
	private void sendActivityToGameServer(DBServer dBServer,String cmdstr){
		try{
			List<String> result = this.getCmdManageService().sendCmd(cmdstr, dBServer, false);
		}catch(Exception e){
			logger.info("ActivityService.sendActivityToGameServer() ExceptionName="+e.getClass().getName()+" Exception ="+e.getMessage()+" serverName="+dBServer.getDbServerName()+" servicerId="
					+dBServer.getServerId()+" regionId="+dBServer.getRegionId()+" cmd="+cmdstr);
		}
	}
	
	/***
	 * 复制活动
	 */
	public String refrashMobileActivity(DBServer svr,String ids, String regionId){
		//发送到gameserver
		String cmd = "dirtyWorldsRefrash";
		sendCopyMobileActivity(svr,ids,cmd,regionId);
		
		return "";
	}
	
	/***
	 * 获得dbserver 对应复选框内容
	 */
	public List<ActivityCheckBoxData> getActivityCheckBoxDataList(List<DBServer> _servers,String serverIds,String regionId){
		List<ActivityCheckBoxData> list = new ArrayList<ActivityCheckBoxData>();
		
		List<DBServer> listSelect = DBFactoryService.getServers(serverIds,regionId);
		
		for(DBServer dBServer :_servers){
			ActivityCheckBoxData activityCheckBoxData = new ActivityCheckBoxData();
			activityCheckBoxData.setServerId(dBServer.getId());
			activityCheckBoxData.setServerName(dBServer.getDbServerName());
			if(listSelect.contains(dBServer)){
				activityCheckBoxData.setSelectecd(1);
			}else{
				activityCheckBoxData.setSelectecd(0);
			}
			list.add(activityCheckBoxData);
		}
		return list;
	}

}
