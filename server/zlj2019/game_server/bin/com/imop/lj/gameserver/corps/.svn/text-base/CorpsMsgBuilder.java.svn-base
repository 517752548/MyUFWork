package com.imop.lj.gameserver.corps;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.corps.CorpsBenifitInfo;
import com.imop.lj.common.model.corps.CorpsBuildingInfo;
import com.imop.lj.common.model.corps.CorpsEventInfo;
import com.imop.lj.common.model.corps.CorpsFuncInfo;
import com.imop.lj.common.model.corps.CorpsMemberFuncInfo;
import com.imop.lj.common.model.corps.CorpsMemberInfo;
import com.imop.lj.common.model.corps.DetailCorpsInfo;
import com.imop.lj.common.model.corps.MemberApplyInfo;
import com.imop.lj.common.model.corps.SimpleCorpsInfo;
import com.imop.lj.common.model.corps.StorageCorpsMemberInfo;
import com.imop.lj.common.model.corps.StorageItemInfo;
import com.imop.lj.common.model.corps.StorageItemTempInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.PageUtil.PageResult;
import com.imop.lj.gameserver.corps.CorpsDef.BuildType;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsEventNoticeType;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsBuildData;
import com.imop.lj.gameserver.corps.model.CorpsEvent;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.corps.model.CorpsStorageItem;
import com.imop.lj.gameserver.corps.msg.GCCorpsChangedMemberInfo;
import com.imop.lj.gameserver.corps.msg.GCCorpsEventNotice;
import com.imop.lj.gameserver.corps.msg.GCCorpsListPanel;
import com.imop.lj.gameserver.corps.msg.GCCorpsMemberInfo;
import com.imop.lj.gameserver.corps.msg.GCCorpsStorage;
import com.imop.lj.gameserver.corps.msg.GCDegradeCorps;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsBenifitPanel;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsBuildingPanel;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsMemberList;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsPanel;
import com.imop.lj.gameserver.corps.msg.GCStorageItemList;
import com.imop.lj.gameserver.corps.msg.GCUpdateSingleCorps;
import com.imop.lj.gameserver.corps.template.CorpsUpgradeTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.util.TimeDifferenceStr;

/**
 * 军团信息构建
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsMsgBuilder {
	/**
	 * 创建军团列表
	 * 
	 * @param pr
	 * @return
	 */
	public static GCCorpsListPanel createGCCorpsListPanel(Human human, PageResult<Corps> pr) {
		GCCorpsListPanel panel = new GCCorpsListPanel();
		panel.setCurrPage(pr.getCurrPage());
		panel.setMaxPageNum(pr.getMaxPage());
		
		List<SimpleCorpsInfo> corpsList = new ArrayList<SimpleCorpsInfo>();
		for(Corps corps : pr.getResultList()){
			corpsList.add(createSimpleCorpsInfo(human, corps));
		}
		panel.setSimpleCorpsInfos(corpsList.toArray(new SimpleCorpsInfo[0]));
		panel.setCorpsListPanelFuncInfoList(createCorpsFuncInfoArray(human, 0, CorpsDef.corpsListPanelFuncList));
		return panel;
	}
	
	/**
	 * 创建个人军团相关信息
	 * 
	 * @param pr
	 * @return
	 */
	public static GCCorpsMemberInfo createGCCorpsMemberInfo(Human human,CorpsMember mem) {
		GCCorpsMemberInfo info = new GCCorpsMemberInfo();
		info.setCorpsMemInfo(createCorpsMemberInfo(human, mem));
		info.setCorpsName(mem.getCorps().getName());
		return info;
	}
	
	/**
	 * 创建已修改的军团成员相关信息
	 * 
	 * @param pr
	 * @return
	 */
	public static GCCorpsChangedMemberInfo createGCCorpsChangedMemberInfo(Human human,List<CorpsMemberInfo> list,Integer type) {
		GCCorpsChangedMemberInfo info = new GCCorpsChangedMemberInfo();
		List<CorpsMemberInfo> destList = new ArrayList<CorpsMemberInfo>();
		for(CorpsMemberInfo mem : list){
			if(mem != null){
				destList.add(mem);
			}
		}
		info.setCorpsMemInfoList(destList.toArray(new CorpsMemberInfo[0]));
		info.setChangeType(type);
		return info;
	}
	
	
	/**
	 * 创建军团信息
	 * 
	 * @param human
	 * @param corps
	 * @return
	 */
	public static SimpleCorpsInfo createSimpleCorpsInfo(Human human, Corps corps){
		SimpleCorpsInfo info = new SimpleCorpsInfo();
		info.setCorpsId(corps.getId());
		info.setName(corps.getName());
		info.setLevel(corps.getLevel());
		info.setPresidentName(corps.getPresidentName());
		info.setPresidentId(corps.getPresident());
		info.setPresidentLevel(Globals.getOfflineDataService().getUserLevel(corps.getPresident()));
		info.setPresidentTplId(Globals.getOfflineDataService().getUserTplId(corps.getPresident()));
		info.setCurrMemNum(corps.getCorpsMemberManager().size());
		info.setMaxMemNum(corps.capacity());
		info.setCountry(corps.getCountry());
		info.setRank(corps.getRank());
		info.setQq(corps.getQq());
		info.setNotice(corps.getNotice());
		info.setIsApplied(null == corps.getCorpsMemberApplyManager().getApplyCorpsMemberByRoleId(human.getUUID()) ? 0 : 1);
		info.setCorpsFuncInfoList(createCorpsFuncInfoArray(human, corps.getId(), CorpsDef.corspListFuncList));
		return info;
	}
	
	/**
	 * 创建详细军团信息
	 * 
	 * @param human
	 * @param corps
	 * @param isDegrade 是否降级
	 * @return
	 */
	public static DetailCorpsInfo createDetailCorpsInfo(Human human, Corps corps, boolean isDegrade){
		DetailCorpsInfo info = new DetailCorpsInfo();
		info.setCorpsId(corps.getId());
		info.setName(corps.getName());
		//降级后的前台显示完全根据帮派等级决定
		info.setLevel(corps.getLevel());
		
		//获取模板
		CorpsUpgradeTemplate nextTemp = Globals.getTemplateCacheService().get(corps.getLevel() + 1, CorpsUpgradeTemplate.class);
		
		info.setCurrExp(corps.getCurrExp());
		info.setCurrFund(corps.getCurrFund());
		if(nextTemp != null){
			info.setHasNextLevel(1);
		}else{
			info.setHasNextLevel(0);
		}
		
		info.setPresidentName(corps.getPresidentName());
		info.setCurrMemNum(corps.getCorpsMemberManager().size());
		info.setRank(corps.getRank());
		info.setNotice(corps.getNotice());
		//这里改成传剩下的时间
		info.setDisbandConfirmDate(corps.getDisbandConfirmDate() - Globals.getTimeService().now());
		return info;
	}
	
	/**
	 * 创建详细帮派建筑信息
	 * 
	 * @param human
	 * @param corps
	 * @param isDegrade 是否降级
	 * @return
	 */
	public static CorpsBuildingInfo createCorpsBuildingInfo(Human human, Corps corps, boolean isDegrade, int type){
		CorpsBuildingInfo info = new CorpsBuildingInfo();
		//初始化帮派建筑信息
		Map<Integer, CorpsBuildData> buildingMap = corps.getBuildingMap();
		if(buildingMap.isEmpty()){
			for(BuildType buildType : CorpsDef.BuildType.values()){
				CorpsBuildData data = new CorpsBuildData();
				data.setCorpsId(corps.getId());
				data.setBuildType(buildType.getIndex());
				//建筑等级特殊处理
				if(BuildType.JUYI.getIndex() == buildType.getIndex()){
					data.setLevel(corps.getLevel());
				}else{
					//建筑默认是1级
					data.setLevel(1);
				}
				data.setUpgradeTime(0);
				buildingMap.put(buildType.getIndex(), data);
			}
			corps.setBuildingMap(buildingMap);
			corps.setModified();
		}
		CorpsBuildData data = corps.getCorpsBuildingByType(type);
		if(data == null){
			return null;
		}
		info.setCorpsId(corps.getId());
		info.setBuildingLevel(data.getCurLevel(type));
		info.setBuildType(type);

		if(data.getUpgradeTime() <= 0L){
			info.setUpgradeCountDownTime(0L);
		}else if(data.getUpgradeTime() > 0 && !isDegrade){
			//正常升级
			info.setUpgradeCountDownTime(data.getUpgradeTime() - Globals.getTimeService().now());
		}else if(data.getUpgradeTime() > 0 && isDegrade){
			//遇到降级操作,如果建筑正在升级,则取消
			info.setUpgradeCountDownTime(0L);
		}
		return info;
	}
	
	/**
	 * 创建帮派福利信息
	 * @param human
	 * @param corps
	 * @param canReceive
	 * @return
	 */
	public static CorpsBenifitInfo createCorpsBenifitInfo(Human human, CorpsMember mem, int canReceive){
		CorpsBenifitInfo info = new CorpsBenifitInfo();
		info.setCorpsId(mem.getCorpsId());
		info.setLastWeekContribution(mem.getLastWeekContribution());
		info.setCanReceive(canReceive);
		return info;
	}
	
	/**
	 * 创建军团功能列表
	 * 
	 * @param human
	 * @param corpsId
	 * @param funcList
	 * @return
	 */
	public static CorpsFuncInfo[] createCorpsFuncInfoArray(Human human, long corpsId, CorpsTypeEnum[] funcList){
		List<CorpsFuncInfo> list = new ArrayList<CorpsFuncInfo>();
//		for(CorpsTypeEnum func : funcList){
//			if(func.getFunc().canSee(human, corpsId)){
//				CorpsFuncInfo info = new CorpsFuncInfo();
//				String title = func.getFunc().getTitle();
//				info.setTitle(title);
//				info.setDesc(func.getFunc().getDesc(human, corpsId));
//				info.setFuncId(func.getIndex());
//				info.setCorpsUUID(corpsId);
//				info.setAvailable(func.getFunc().isAvailable(human, corpsId) == null ? 1 : 0);
//				list.add(info);
//			}
//		}
		return list.toArray(new CorpsFuncInfo[0]);
	}
	
	/**
	 * 创建军团面板
	 * 
	 * @param corps
	 * @return
	 */
	public static GCOpenCorpsPanel createGCOpenCorpsPanel(Human human, Corps corps){
		GCOpenCorpsPanel resp = new GCOpenCorpsPanel();
		//军团信息
		resp.setDetailCorpsInfo(createDetailCorpsInfo(human, corps, false));
		//申请信息
		resp.setMemberApplyInfoList(createMemberApplyInfoArray(human, corps));
		//军团事件
		resp.setCorpsEventInfoList(createCorpsEventInfoArray(human, corps));
		//军团信息功能
		resp.setCorpsPanelFuncInfoList(createCorpsFuncInfoArray(human, corps.getId(), CorpsDef.corpsPanelFuncList));
		return resp;
	}
	
	/**
	 * 创建帮派降级消息
	 * @param human
	 * @param corps
	 * @return
	 */
	public static GCDegradeCorps createGCDegradeCorps(Human human, Corps corps, int type){
		GCDegradeCorps msg = new GCDegradeCorps();
		msg.setDetailCorpsInfo(createDetailCorpsInfo(human, corps,true));
		msg.setCorpsBuildingInfo(createCorpsBuildingInfo(human, corps,true, type));
		return msg;
	}
	
	/**
	 * 创建帮派建筑面板
	 * 
	 * @param corps
	 * @param isDegrade
	 * @return
	 */
	public static GCOpenCorpsBuildingPanel createGCOpenCorpsBuildingPanel(Human human, Corps corps, boolean isDegrade, int type){
		GCOpenCorpsBuildingPanel msg = new GCOpenCorpsBuildingPanel();
		msg.setCorpsBuildingInfo(createCorpsBuildingInfo(human, corps, isDegrade, type));
		return msg;
	}
	
	/**
	 * 创建单条军团信息
	 * 
	 * @param human
	 * @param corps
	 * @return
	 */
	public static GCUpdateSingleCorps createGCSingleCorps(Human human, Corps corps){
		GCUpdateSingleCorps resp = new GCUpdateSingleCorps();
		resp.setSimpleCorpsInfo(createSimpleCorpsInfo(human, corps));
		return resp;
	}
	
	/**
	 * 创建军团成员列表
	 * 
	 * @param human
	 * @param corps
	 * @return
	 */
	public static GCOpenCorpsMemberList createGCOpenCorpsMemberList(Human human, Corps corps){
		GCOpenCorpsMemberList resp = new GCOpenCorpsMemberList();
		List<CorpsMemberInfo> list = new ArrayList<CorpsMemberInfo>();
		for(CorpsMember mem : corps.getCorpsMemberManager().getCorpsMemberList()){
			list.add(createCorpsMemberInfo(human, mem));
		}
		resp.setCorpsMemInfoList(list.toArray(new CorpsMemberInfo[0]));
		resp.setCorpsPanelFuncInfoList(createCorpsFuncInfoArray(human, corps.getId(), CorpsDef.memListCorpsFuncList));
		return resp;
	}
	
	
	/**
	 * 创建军团成员信息
	 * 
	 * @param human
	 * @param mem
	 * @return
	 */
	public static CorpsMemberInfo createCorpsMemberInfo(Human human, CorpsMember mem){
		CorpsMemberInfo info = new CorpsMemberInfo();
		info.setMemId(mem.getRoleId());
		info.setName(mem.getName());
		info.setTplId(mem.getTplId());
		info.setLevel(mem.getLevel());
		info.setMemJob(mem.getJob()==null ? 0:mem.getJob().getIndex());
		info.setPetJob(mem.getPetJob()==null ? 0:mem.getPetJob().getIndex());
		info.setTodayDonate(mem.getTodayDonate());
		info.setTotalDonate(mem.getTotalDonate());
		info.setWeekContribution(mem.getWeekContribution());
		info.setTotalContribution(mem.getTotalContribution());
		info.setLastOfflineTime(mem.getLogoutTime());
		if(mem.isOnline()){
			info.setOnlineDesc(Globals.getLangService().readSysLang(LangConstants.NOW_ONLINE));
		}else{
			info.setOnlineDesc(TimeDifferenceStr.getTimeDifferenceStrInstance().timeDifferenceStr(mem.getLogoutTime()));
		}
		info.setCorpsMemberFuncInfoList(createCorpsMemFuncInfoArray(human, mem.getRoleId(), CorpsDef.memListCorpsMemFuncList));
		return info;
	}
	
	
	/**
	 * 创建军团成员功能列表
	 * 
	 * @param human
	 * @param memId
	 * @param funcList
	 * @return
	 */
	public static CorpsMemberFuncInfo[] createCorpsMemFuncInfoArray(Human human, long memId, CorpsMemberTypeEnum[] funcList){
		List<CorpsMemberFuncInfo> list = new ArrayList<CorpsMemberFuncInfo>();
//		for(CorpsMemberTypeEnum func : funcList){
//			if(func.getFunc().canSee(human, memId)){
//				CorpsMemberFuncInfo info = new CorpsMemberFuncInfo();
//				String title = func.getFunc().getTitle();
//				info.setTitle(title);
//				info.setFuncId(func.getIndex());
//				info.setDesc(func.getFunc().getDesc());
//				info.setMemUUID(memId);
//				info.setAvailable(func.getFunc().isAvailable(human, memId) == null ? 1 : 0);
//				list.add(info);
//			}
//		}
		return list.toArray(new CorpsMemberFuncInfo[0]);
	}
	
	/**
	 * 生成申请信息
	 * 
	 * @param human
	 * @param corps
	 * @return
	 */
	private static MemberApplyInfo[] createMemberApplyInfoArray(Human human, Corps corps){
		List<MemberApplyInfo> list = new ArrayList<MemberApplyInfo>();
		for(CorpsMember mem : corps.getCorpsMemberApplyManager().getCorpsMemberList()){
			MemberApplyInfo info = new MemberApplyInfo();
			info.setMemId(mem.getRoleId());
			info.setName(mem.getName());
			info.setLevel(mem.getLevel());
			info.setPetJob(mem.getPetJob() == null ? 0 : mem.getPetJob().index);
			info.setSex(mem.getSex() == null ? 0 : mem.getSex().index);
			info.setApplyFuncInfoList(createCorpsMemFuncInfoArray(human, info.getMemId(), CorpsDef.applyListCorpsMemFuncList));
			list.add(info);
		}
		
		return list.toArray(new MemberApplyInfo[0]);
	}
	
	/**
	 * 生成军团事件
	 * 
	 * @param human
	 * @param corps
	 * @return
	 */
	private static CorpsEventInfo[] createCorpsEventInfoArray(Human human, Corps corps){
		List<CorpsEventInfo> list = new ArrayList<CorpsEventInfo>();
		for(CorpsEvent event : corps.getCorpsEventList()){
			CorpsEventInfo info = new CorpsEventInfo();
			info.setCorpsLog(event.getTips());
			info.setOnlineDesc(TimeDifferenceStr.getTimeDifferenceStrInstance().timeDifferenceStr(event.getCreateTime()));
			list.add(info);
		}
		return list.toArray(new CorpsEventInfo[0]);
	}
	
	/**
	 * 创建军团仓库返回信息
	 * 
	 * @param human
	 * @param corps
	 * @return
	 */
	public static GCCorpsStorage createGCCorpsStorage(Human human, Corps corps){
		GCCorpsStorage resp = new GCCorpsStorage();
		//成员列表
		List<StorageCorpsMemberInfo> memList = new ArrayList<StorageCorpsMemberInfo>();
		for(CorpsMember mem : corps.getCorpsMemberManager().getCorpsMemberList()){
			memList.add(createStorageCorpsMemberInfo(mem));
		}
		resp.setStorageMemList(memList.toArray(new StorageCorpsMemberInfo[0]));
		
		Map<Integer, StorageItemTempInfo> map = new HashMap<Integer, StorageItemTempInfo>();
		
		//物品列表
		List<StorageItemInfo> itemList = new ArrayList<StorageItemInfo>();
		int index = 0;
		for(CorpsStorageItem item : corps.getStorage().getItemList()){
			//填充模版
			StorageItemTempInfo tempInfo = map.get(item.getItemTempId());
			if(tempInfo == null){
				tempInfo = createStorageItemTempInfo(item.getItemTempId());
				map.put(tempInfo.getTempId(), tempInfo);
			}
			
			itemList.add(createStorageItemInfo(item.getItemTempId(), item.getNum(), index));
			index ++;
		}
		resp.setStorageItemList(itemList.toArray(new StorageItemInfo[0]));
		
		//物品模版列表
		resp.setStorageItemTempList(map.values().toArray(new StorageItemTempInfo[0]));
		
		//设置权限
		resp.setCanAllccation(human.getUUID() == corps.getPresident() ? 1 : 0);
		return resp;
	}
	
	/**
	 * 创建军团仓库物品信息
	 * 
	 * @param human
	 * @param corps
	 * @return
	 */
	public static GCStorageItemList createGCStorageItemList(Human human, Corps corps) {
		GCStorageItemList resp = new GCStorageItemList();

		Map<Integer, StorageItemTempInfo> map = new HashMap<Integer, StorageItemTempInfo>();

		// 物品列表
		List<StorageItemInfo> itemList = new ArrayList<StorageItemInfo>();
		int index = 0;
		for (CorpsStorageItem item : corps.getStorage().getItemList()) {
			// 填充模版
			StorageItemTempInfo tempInfo = map.get(item.getItemTempId());
			if (tempInfo == null) {
				tempInfo = createStorageItemTempInfo(item.getItemTempId());
				map.put(tempInfo.getTempId(), tempInfo);
			}

			itemList.add(createStorageItemInfo(item.getItemTempId(), item.getNum(), index));
			index++;
		}
		resp.setStorageItemList(itemList.toArray(new StorageItemInfo[0]));

		// 物品模版列表
		resp.setStorageItemTempList(map.values().toArray(new StorageItemTempInfo[0]));
		return resp;
	}

	/**
	 * 仓库成员信息
	 * 
	 * @param corps
	 * @return
	 */
	private static StorageCorpsMemberInfo createStorageCorpsMemberInfo(CorpsMember mem){
		StorageCorpsMemberInfo info = new StorageCorpsMemberInfo();
		info.setMemId(mem.getRoleId());
		info.setName(mem.getName());
		info.setJobName(Globals.getLangService().readSysLang(mem.getJob().getLangId()));
		info.setTotalContribution(mem.getTotalContribution());

		return info;
	}
	
	/**
	 * 仓库物品模版信息
	 * 
	 * @param corps
	 * @return
	 */
	private static StorageItemTempInfo createStorageItemTempInfo(int tempId){
		StorageItemTempInfo info = new StorageItemTempInfo();
		ItemTemplate temp = Globals.getTemplateCacheService().get(tempId, ItemTemplate.class);
		if(temp != null){
			info.setTempId(temp.getId());
			info.setName(temp.getName());
			info.setIconId(temp.getIcon());
			info.setDesc(temp.getDesc());
			info.setPrice(temp.getSellPrice());
			info.setQuality(temp.getRarityId());
			info.setUseLevel(temp.getLevel());
		}
		return info;
	}
	
	/**
	 * 仓库成员信息
	 * 
	 * @param corps
	 * @return
	 */
	private static StorageItemInfo createStorageItemInfo(int tempId, int num, int index){
		StorageItemInfo info = new StorageItemInfo();
		info.setTempId(tempId);
		info.setNum(num);
		info.setIndex(index);
		return info;
	}
	
	/**
	 * 创建军团事件通知
	 * 
	 * @param type
	 * @param param
	 * @return
	 */
	public static GCCorpsEventNotice createGCCorpsEventNotice(CorpsEventNoticeType type, long param){
		GCCorpsEventNotice notice = new GCCorpsEventNotice();
		notice.setCorpsEventType(type.getIndex());
		notice.setParam(param);
		return notice;
	}

	public static GCOpenCorpsBenifitPanel createGCOpenCorpsBenifitPanel(Human human,CorpsMember mem,int canReceive) {
		GCOpenCorpsBenifitPanel msg = new GCOpenCorpsBenifitPanel();
		msg.setCorpsBenifitInfo(createCorpsBenifitInfo(human, mem, canReceive));
		return msg;
	}
	
	
}
