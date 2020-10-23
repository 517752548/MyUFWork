package com.imop.lj.gm.service.notice;

import java.text.MessageFormat;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONObject;

import org.slf4j.Logger;

import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.notice.MobileActivityDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.notice.data.MobileActivityGroupsName;
import com.imop.lj.gm.service.notice.data.MobileActivityShowData;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.MobileActivityInfo;
import com.imop.lj.gm.service.xls.XlsSecretaryLoadService;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.lj.gm.web.activity.data.prize.GmActivityPrizeIface;
import com.imop.lj.gm.web.activity.service.GMGlobals;
import com.imop.lj.gm.web.activity.service.Iface.ActivityCheckEnum;
import com.imop.lj.gm.web.activity.service.Iface.MobileActivityUseOrNotEnum;

public class MobileActivityGmService {
	/**db log */
	private Logger logger = GMGlobals.logger;
	//private Logger logger = LoggerFactory.getLogger("R");
	//private static final Logger logger = Logger.getLogger(MobileActivityGmService.class);
	
	/** 命令管理 Service */
	private CmdManageService cmdManageService;
	//可配置活动dao
	private MobileActivityDAO mobileActivityDAO;
	private XlsSecretaryLoadService xlsSecretaryLoadService;
	private ExcelLangManagerService excelLangManagerService;
	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}
	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}
	public MobileActivityDAO getMobileActivityDAO() {
		return mobileActivityDAO;
	}
	public void setMobileActivityDAO(MobileActivityDAO mobileActivityDAO) {
		this.mobileActivityDAO = mobileActivityDAO;
	}
	public XlsSecretaryLoadService getXlsSecretaryLoadService() {
		return xlsSecretaryLoadService;
	}
	public void setXlsSecretaryLoadService(
			XlsSecretaryLoadService xlsSecretaryLoadService) {
		this.xlsSecretaryLoadService = xlsSecretaryLoadService;
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
	public List<GoodActivityEntity> getMobileActivityEntityList(){
		return this.getMobileActivityDAO().getMobileActivityEntityList();
	}
	
	/***
	 *获得所有可配置活动
	 */
	public List<MobileActivityShowData> getMobileActivityEntityShowList(){
		List<MobileActivityShowData> list = new ArrayList<MobileActivityShowData>();
		
		List<GoodActivityEntity> tempList = this.getMobileActivityDAO().getMobileActivityEntityList();
		if(tempList==null || tempList.size()<=0){
			return list;
		}
		
		for(GoodActivityEntity entity:tempList){
			MobileActivityShowData data = getMobileActivityShowData(entity);
			list.add(data);
		}
		return list;
	}
	
	/***
	 * 创建 或偶的那个展示类
	 */
	public MobileActivityShowData getMobileActivityShowData(GoodActivityEntity entity){
		MobileActivityInfo info = this.getXlsSecretaryLoadService().getMobileActivityOnId(entity.getActivityTplId());
		return new MobileActivityShowData(entity, info.getName(), info.getDesc());
	}
	
	/***
	 * 获得一个活动  初始页面展示
	 */
	public MobileActivityShowData getMobileActivityShowDataNew(){
		MobileActivityShowData data = new MobileActivityShowData();
		long time = System.currentTimeMillis();
		data.setStartDate(DateUtil.formatDate(time));
		data.setStartTime(DateUtil.formateTimeLong(time));
		
		data.setEndDate(DateUtil.formatDate(time));
		data.setEndTime(DateUtil.formateTimeLong(time));
		
		data.setUseOrNot(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_USE_NOT+"");
		return data;
	}
	
	/***
	 * 获得下拉框  初始页面展示
	 */
	public List<MobileActivityGroupsName> getMobileActivityGrops(){
		List<MobileActivityInfo> list = this.getXlsSecretaryLoadService().getMobileActivityInfoAllMapList();
		List<MobileActivityGroupsName> listTemp = new ArrayList<MobileActivityGroupsName>();
		
		MobileActivityGroupsName dataTemp = new MobileActivityGroupsName("",-1);
		listTemp.add(dataTemp);
		
		for(MobileActivityInfo temp:list){
			if(checkMobileActivityUseOrNot(temp.getUseOrNot())){
				MobileActivityGroupsName data = new MobileActivityGroupsName("["+temp.getTemplateId()+"]"+temp.getName(),temp.getTemplateId());
				listTemp.add(data);
			}
		}
		
		return listTemp;
	}
	
	//判断可配置活动是否可用
	private boolean checkMobileActivityUseOrNot(int useOrNot){
		if(MobileActivityUseOrNotEnum.indexOf(useOrNot) == MobileActivityUseOrNotEnum.USE_ABLE){
			return true;
		}else{
			return false;
		}
	}
	
	/***
	 * 获得一个可配置活动
	 */
	public GoodActivityEntity getMobileActivityEntityOnId(String id){
		//活动内容
		if(id==null || id.equals("")){
			return null;
		}
		long activityId = Long.parseLong(id);
		GoodActivityEntity mobileActivityEntity =  this.getMobileActivityDAO().getById(GoodActivityEntity.class, activityId);
		return mobileActivityEntity;
	}
	
	
	/***
	 * 修改 活动
	 */
	public String modifyMobileActivity(DBServer ser,String id,String dateStart,String startTime,String dateEnd,String endTime,String activityTplId,String activityName,
			String activityDesc,String activityUsable, String nameIcon, String titleIcon){
		ExcelLangManagerService lang = excelLangManagerService;
		
		//活动id
		long activityId = 0l;
		if(id==null || id.equals("")){
		}else{
			activityId = Long.parseLong(id);
		}
		
		//开始日期
		if(dateStart==null ||dateStart.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		//开始时间
		if(startTime==null ||startTime.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		//结束日期
		if(dateEnd==null ||dateEnd.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		//结束时间
		if(endTime==null ||endTime.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		//活动模板id
		int aTplId = 0;
		if(activityTplId==null || activityTplId.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}else{
			aTplId = Integer.parseInt(activityTplId);
			if(this.getXlsSecretaryLoadService().getMobileActivityOnId(aTplId)==null){
				String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
				return errorStr;
			}
		}
		// XXX 活动名称和描述可以为空，为空时名称使用图片，描述使用模板中的
//		//活动名称
//		if(activityName==null || activityName.equals("")){
//			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE_SERVERS);
//			String errorStrTwo = lang.readGm(GMLangConstants.ACTIVITY_WEB_ACTIVIT_NAME);
//			errorStr =MessageFormat.format(errorStr,errorStrTwo);
//			return errorStr;
//		}
//		
//		//活动奖励描述
//		if(activityDesc==null || activityDesc.equals("")){
//			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE_SERVERS);
//			String errorStrTwo = lang.readGm(GMLangConstants.ACTIVITY_WEB_ACTIVIT_DESC);
//			errorStr =MessageFormat.format(errorStr,errorStrTwo);
//			return errorStr;
//		}
		if (null == activityName) {
			activityName = "";
		}
		if (null == activityDesc) {
			activityDesc = "";
		}
		
		//是否可用
		int activityUsableOrNot = 1000;
		if(activityUsable==null || activityUsable.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE_ACTIVITY);
			String errorStrTwo = lang.readGm(GMLangConstants.ACTIVITY_WEB_ACTIVY_USE_OR_NOT);
			errorStr =MessageFormat.format(errorStr,errorStrTwo);
			return errorStr;
		}else{
			activityUsableOrNot = Integer.parseInt(activityUsable);
		}

		
		//设置奖励
		//开始时间
		String startTimeStr = dateStart+" "+startTime;
		long mobileActivityStartTime = 0l;
		try {
			mobileActivityStartTime = DateUtil.formatDateHourToLong(startTimeStr);
		} catch (ParseException e) {
			logger.info("ActivityService.modifyActivity() ExceptionName="+e.getClass().getName()+" Exception ="+e.getMessage());
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		//结束时间
		String endtimeStr = dateEnd+" "+endTime;
		long mobileActivityEndTime = 0l;
		try {
			mobileActivityEndTime = DateUtil.formatDateHourToLong(endtimeStr);
		} catch (ParseException e) {
			logger.info("ActivityService.modifyActivity() ExceptionName="+e.getClass().getName()+" Exception ="+e.getMessage());
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		//时间校验
		if(mobileActivityEndTime<=mobileActivityStartTime){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_TIEM_FAILURE);
			return errorStr;
		}
		if (nameIcon == null || nameIcon.equalsIgnoreCase("")) {
			nameIcon = "0";
		}
		if (titleIcon == null || titleIcon.equalsIgnoreCase("")) {
			titleIcon = "0";
		}
		// 名称图标和标题图标
		int nameIconInt = Integer.parseInt(nameIcon);
		int titleIconInt = Integer.parseInt(titleIcon);
		if (nameIconInt < 0) {
			nameIconInt = 0;
		}
		if (titleIconInt < 0) {
			titleIconInt = 0;
		}
		nameIcon = nameIconInt+"";
		titleIcon = titleIconInt+"";
		
		//发送到gameserver
		String cmdstr = ceateSendCmdStr(activityId,mobileActivityStartTime,mobileActivityEndTime,aTplId,
				activityName,activityDesc,activityUsableOrNot, nameIcon, titleIcon);
		sendActivityToGameServer(ser,cmdstr);
		
		return ActivityCheckEnum.OK.getIndex()+"";
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
	
	/**
	 * 开启预置活动
	 * 
	 * @param server
	 * @param dateStart
	 * @param startTime
	 * @return
	 */
	public String startPresetActivity(DBServer server, String dateStart, String startTime){
		ExcelLangManagerService lang = excelLangManagerService;
		//开始日期
		if(dateStart==null ||dateStart.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
				
		//开始时间
		if(startTime==null ||startTime.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		//开始时间
		String startTimeStr = dateStart+" "+startTime;
		long presetStartTime = 0l;
		try {
			presetStartTime = DateUtil.formatDateHourToLong(startTimeStr);
		} catch (ParseException e) {
			logger.info("ActivityService.modifyActivity() ExceptionName="+e.getClass().getName()+" Exception ="+e.getMessage());
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		String cmd = "goodActivityStart " + presetStartTime;
		return cmdManageService.sendCmdResult(cmd, server);
	}
	
	/***
	 * 拼装发送数据
	 */
	public String ceateSendCmdStr(long activityId,long mobileActivityStartTime,long mobileActivityEndTime,int activityTplId,String activityName,
			String activityDesc,int activityUsableOrNot, String nameIcon, String titleIcon){
		String cmd = "GOOD_ACTIVITY_UPDATE";
		JSONObject json = new JSONObject();
		
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_ID_KEY, activityId);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_START_TIME_KEY, mobileActivityStartTime);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_END_TIME_KEY, mobileActivityEndTime);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_ACTIVITY_TPL_ID_KEY, activityTplId);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_NAME_KEY, activityName);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_DESC_KEY, activityDesc);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_KEY, activityUsableOrNot);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_NAMEICON_KEY, nameIcon);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_TITLEICON_KEY, titleIcon);
		
		cmd += " "+json.toString();
			
		return cmd;
	}
	
	/***
	 * 设置可用
	 */
	public String updateMobileActivityUse(DBServer dBServer,String id){
		ExcelLangManagerService lang = excelLangManagerService;
		//活动内容
		if(id==null || id.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		long activityId = Long.parseLong(id);
		
		String cmdstr = ceateUpdateMobileActivityUseCmdStr(activityId);
		sendActivityToGameServer(dBServer,cmdstr);
		
		return ActivityCheckEnum.OK.getIndex()+"";
	}
	
	//设置可用 拼装cmd
	private String ceateUpdateMobileActivityUseCmdStr(long id){
		String cmd = "GOOD_ACTIVITY_AVAILABLE";
		JSONObject json = new JSONObject();
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_ID_KEY, id);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_KEY, GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_USE);
		
		cmd += " "+json.toString();
		return cmd;
	}
	
	/***
	 * 设置可用
	 */
	public String forceEndMobileActivity(DBServer dBServer,String id){
		ExcelLangManagerService lang = excelLangManagerService;
		//活动内容
		if(id==null || id.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		long activityId = Long.parseLong(id);
		
		String cmdstr = ceatefForceEndMobileActivityUseCmdStr(activityId);
		sendActivityToGameServer(dBServer,cmdstr);
		
		return ActivityCheckEnum.OK.getIndex()+"";
	}
	
	//设置可用 拼装cmd
	private String ceatefForceEndMobileActivityUseCmdStr(long id){
		String cmd = "GOOD_ACTIVITY_FORCE_END";
		JSONObject json = new JSONObject();
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_ID_KEY, id);
		
		cmd += " "+json.toString();
		return cmd;
	}
	
	public String closeAllOnGoingActivity(DBServer dBServer){
		String cmd = "GOOD_ACTIVITY_CLOSE_ALL_GOING";
		cmd += " ";
		sendActivityToGameServer(dBServer,cmd);
		
		return ActivityCheckEnum.OK.getIndex()+"";
	}
	
	/***
	 * 设置不可用
	 */
	public String updateMobileActivityUseNot(DBServer dBServer,String id){
		ExcelLangManagerService lang = excelLangManagerService;
		//活动内容
		if(id==null || id.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		long activityId = Long.parseLong(id);
		
		String cmdstr = ceateUpdateMobileActivityUseNotCmdStr(activityId);
		sendActivityToGameServer(dBServer,cmdstr);
		
		return ActivityCheckEnum.OK.getIndex()+"";
	}
	
	//设置不可用 拼装cmd
	private String ceateUpdateMobileActivityUseNotCmdStr(long id){
		String cmd = "GOOD_ACTIVITY_AVAILABLE";
		JSONObject json = new JSONObject();
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_ID_KEY, id);
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_KEY, GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_USE_NOT);
		
		cmd += " "+json.toString();
		return cmd;
	}
	
	/***
	 * 设置可用
	 */
	public String updateMobileActivityForceEnd(DBServer dBServer,String id){
		ExcelLangManagerService lang = excelLangManagerService;
		//活动内容
		if(id==null || id.equals("")){
			String errorStr = lang.readGm(GMLangConstants.ACTIVITY_WEB_SVAE_FAILURE);
			return errorStr;
		}
		
		long activityId = Long.parseLong(id);
		
		String cmdstr = ceateUpdateMobileActivityForceEndCmdStr(activityId);
		sendActivityToGameServer(dBServer,cmdstr);
		
		return ActivityCheckEnum.OK.getIndex()+"";
	}
	
	//设置可用 拼装cmd
	private String ceateUpdateMobileActivityForceEndCmdStr(long id){
		String cmd = "GOOD_ACTIVITY_FORCE_END";
		JSONObject json = new JSONObject();
		json.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_ID_KEY, id);
		
		cmd += " "+json.toString();
		return cmd;
	}
	
	/***
	 * 复制活动
	 */
	public String copyMobileActivity(DBServer svr,String ids,GoodActivityEntity mobileActivityEntity,String regionId){
		//活动id
		long activityId = 0l;
		
		//发送到gameserver
		String cmdstr = ceateSendCmdStr(activityId,mobileActivityEntity.getStartTime(),mobileActivityEntity.getEndTime(),mobileActivityEntity.getActivityTplId(),
				mobileActivityEntity.getActivityName(),mobileActivityEntity.getActivityDesc(),mobileActivityEntity.getIsAvailable(),
				mobileActivityEntity.getNameIcon()+"", mobileActivityEntity.getTitleIcon()+"");
		sendCopyMobileActivity(svr,ids,cmdstr,regionId);
		
		return ActivityCheckEnum.OK.getIndex()+"";
	}
	
	/***
	 * 复制活动发送各服复制消息
	 */
	public void sendCopyMobileActivity(DBServer svr,String serverIds,String cmdstr,String regionId){
		List<DBServer> list = DBFactoryService.getServers(serverIds,regionId);
		for(DBServer ser:list){
			//if(ser.getServerId()!=svr.getServerId()){
				sendActivityToGameServer(ser,cmdstr);
			//}
		}
	}
}
