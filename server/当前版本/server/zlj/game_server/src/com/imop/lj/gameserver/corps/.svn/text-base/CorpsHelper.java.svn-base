package com.imop.lj.gameserver.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberState;
import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.corps.template.CorpsUpgradeTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.model.CorpsMainMap;

/**
 * 军团帮助类
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsHelper {
	/**
	 * 创建申请状态的军团成员
	 * 
	 * @param human
	 * @param corpsId
	 * @return
	 */
	public static CorpsMember createCorpsMember(Human human, Corps corps) {
		CorpsMember mem = new CorpsMember(corps);
		mem.setCorps(corps);
		mem.setId(Globals.getUUIDService().getNextUUID(UUIDType.CORPS_MEMBER));
		mem.setRoleId(human.getUUID());
		mem.setCorpsId(corps.getId());
		mem.setName(human.getName());
		mem.setJob(MemberJob.NONE);
		mem.setState(CorpsMemberState.WAIT_APPLY);
		mem.setJoinDate(Globals.getTimeService().now());
		mem.setLogoutTime(Globals.getTimeService().now());
		mem.setPetJob(human.getJobType());
		mem.setSex(human.getSex());
		mem.activate();
		return mem;
	}
	
	/**
	 * 创建军团，指定human为会长，激活军团，并为会长添加10000点贡献，激活团长，并将团长加入相应集合中
	 * 
	 * @param human
	 * @param name
	 * @return
	 */
	public static Corps createCorps(Human human, String name, String notice){
		//创建军团
		Corps corps = new Corps();
		corps.setId(Globals.getUUIDService().getNextUUID(UUIDType.CORPS));
		corps.setCountry(human.getCountry());
		corps.setName(name);
		corps.setLevel(1);
		CorpsUpgradeTemplate temp = Globals.getTemplateCacheService().get(1, CorpsUpgradeTemplate.class);
		if(temp == null){
			Loggers.corpsLogger.error("CorpsHelper.createCorpsMember error temp level = 1, corpsUpgradeTemplate does not exist!!!");
		}else{
			corps.setCurrMemNum(1);
		}
		corps.setNotice(Globals.getLangService().readSysLang(LangConstants.DEF_CORPS_NOTICE));
		corps.setCurrExp(0);
		corps.setCurrFund(0);
		corps.setPresident(human.getUUID());
		corps.setPresidentName(human.getName());
		corps.setCreater(human.getUUID());
		corps.setCreateDate(Globals.getTimeService().now());
		corps.setInDb(false);
		//激活军团
		corps.activate();
		
		//创建军团地图
		CorpsMainMap mainMap = Globals.getMapService().createCorpsMap(corps.getId());
		corps.setMainMap(mainMap);
		
		//创建团长
		CorpsMember president = CorpsHelper.createCorpsMember(human, corps);
		president.setJob(MemberJob.PRESIDENT);
		president.setJoinDate(Globals.getTimeService().now());
		president.setState(CorpsMemberState.NORMAL);
		president.setLogoutTime(Globals.getTimeService().now());
		president.setInDb(false);
		president.setOnline(true);
		
		//分配初始化捐献
		president.setTodayDonate(Globals.getGameConstants().getInitDonate());
		president.setTotalDonate(Globals.getGameConstants().getInitDonate());
		president.setDonateDate(Globals.getTimeService().now());
		
		//分配初始化贡献
		president.setWeekContribution(Globals.getGameConstants().getInitContribution());
		president.setTotalContribution(Globals.getGameConstants().getInitContribution());
		president.setLastWeekContribution(Globals.getGameConstants().getInitContribution());
		president.setContributeDate(0L);
		president.setBenifitDate(0L);
		
		//激活团长
		president.activate();
		
		//将团长添加到相应集合中
		corps.addCorpsMember(president);
		
		president.setModified();
		corps.setModified();
		return corps;
	}
}
