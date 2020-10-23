package com.imop.lj.gameserver.common.service;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.model.human.NoticeTipsInfo;
import com.imop.lj.common.model.human.TipsInfoDef.MailBoxInfoType;
import com.imop.lj.core.time.TimeService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.INoticeTipsHandler;
import com.imop.lj.gameserver.common.NoticeTips;
import com.imop.lj.gameserver.common.NoticeTipsDef.NoticeState;
import com.imop.lj.gameserver.common.NoticeTipsDef.NoticeType;
import com.imop.lj.gameserver.common.msg.GCNoticeTipsInfoAdd;
import com.imop.lj.gameserver.common.msg.GCNoticeTipsInfoList;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.template.MailBoxInfoTemplate;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.player.Player;

public class NoticeTipsInfoService implements InitializeRequired{
	/**
	 * tips时效为3天  72小时
	 */
	public static final long TIPS_AGING = 72 * 3600 * 1000;
	
	/**全局tips 系统小信封 结构 Map<用户id,Map<时间,tips操作对象>**/
	protected Map<Long,Map<Long,NoticeTips>> sysNoticeTipsInfoMap = new HashMap<Long,Map<Long,NoticeTips>>();
	
	public NoticeTipsInfoService(){
		
	}
	
	@Override
	public void init() {
		
	}
	
	protected void putNoticTips(long humanId,NoticeTips noticeTips){
		Map<Long, NoticeTips> map = sysNoticeTipsInfoMap.get(humanId);
		if(map == null){
			map = new LinkedHashMap<Long,NoticeTips>();
		}
		if(map.size() > Globals.getGameConstants().getNoticeTipsMaxSize()){
			cleanUpTips(humanId);
		}
		map.put(noticeTips.getCreateTime(), noticeTips);
		sysNoticeTipsInfoMap.put(humanId, map);
	}
	
	
	/**
	 * 清理tips
	 * @param humanId
	 */
	protected void cleanUpTips(long humanId){
		TimeService timeService = Globals.getTimeService();
		Map<Long,NoticeTips> map = sysNoticeTipsInfoMap.get(humanId);
		if(map == null || map.size() == 0){
			return;
		}
		
		Iterator<Entry<Long,NoticeTips>> iterator =  map.entrySet().iterator();
		while(iterator.hasNext()){
			Entry<Long,NoticeTips> entry = iterator.next();
			long diff = timeService.now() - entry.getKey();
			if(diff > TIPS_AGING || diff <= 0){
				iterator.remove();
			}
		}
	}
	
	public INoticeTipsHandler getNoticeTipsHandler(long humanId,long tag){
		Map<Long,NoticeTips> map = sysNoticeTipsInfoMap.get(humanId);
		if(map == null){
			return null;
		}
		NoticeTips noticeTips = map.remove(tag);
		if(noticeTips == null){
			return null;
		}
		INoticeTipsHandler handler = noticeTips.getHandler();
		return handler;
	}
	
	/**
	 * 组装玩家发的小信封并发送
	 * @param fromHumanId
	 * @param toHumanId
	 * @param mType
	 * @param content
	 */
	public void sendNoticeTipsByPlayer(long fromHumanId, long toHumanId, String content){
		NoticeTips noticeTips = new NoticeTips();
		noticeTips.setHandler(null);
		noticeTips.setType(NoticeType.NOTICE);
		noticeTips.setContent(content);
		
		UserSnap us = Globals.getOfflineDataService().getUserSnap(fromHumanId);
		if(us == null){
			return ;
		}
		noticeTips.setFromRoleId(fromHumanId);
		noticeTips.setFromRoleName(us.getName());
		noticeTips.setFromRoleJobType(us.getHumanJobTypeId());
		noticeTips.setFromRoleLevel(us.getLevel());
		//TODO 敏感词过滤,时间间隔,信息长度,黑名单判断,这部分应该在调用之前判断
		noticeTips.setFromRoleTplId(us.getHumanTplId());
		sendNoticeTipsInfo(toHumanId, noticeTips);
	}
	
	
	
	/**
	 * 组装系统小信封并发送
	 * @param fromHumanId sys1 develop2
	 * @param toHumanId
	 * @param mType
	 * @param handler
	 * @param params
	 */
	public void sendNoticeTipsBySys(long fromHumanId, long toHumanId, MailBoxInfoType mType, INoticeTipsHandler handler, Object... params) {
        MailBoxInfoTemplate mailBoxInfoTemplate = Globals.getTemplateCacheService().get(
				mType.getIndex(), MailBoxInfoTemplate.class);
		NoticeTips noticeTips = new NoticeTips();
		if (handler != null) {
			noticeTips.setHandler(handler);
			noticeTips.setType(NoticeType.HANDLE);
		}
		String tipsInfo = mailBoxInfoTemplate.getInfo();
		String content = tipsInfo;
		if (params != null) {
			content = MessageFormat.format(tipsInfo, params);
		}
		noticeTips.setIcon(mailBoxInfoTemplate.getIcon());
		noticeTips.setContent(content);
		noticeTips.setFromRoleId(fromHumanId);
		sendNoticeTipsInfo(toHumanId, noticeTips);
	}
	
	
	/**
	 * 发送小信封
	 * @param humanId
	 * @param noticeTips 小信封
	 */
	protected void sendNoticeTipsInfo(long humanId, NoticeTips noticeTips){
		Player player = Globals.getOnlinePlayerService().getPlayer(humanId);
		if(player == null || !player.isInScene()) {
			this.putNoticTips(humanId, noticeTips);
		}else{
			GCNoticeTipsInfoAdd gcNoticeTipsInfoAdd = new GCNoticeTipsInfoAdd();
			gcNoticeTipsInfoAdd.setNoticeTipsInfo(noticeTips.buildNoticTipsInfo());
			player.getHuman().sendMessage(gcNoticeTipsInfoAdd);
			noticeTips.setState(NoticeState.SENDED);
			if(noticeTips.getType() == NoticeType.HANDLE && noticeTips.getHandler() != null){
				this.putNoticTips(humanId, noticeTips);
			}
		}
	}
	
	public void sendNoticeTipsInfoList(Human human){
		TimeService timeService = Globals.getTimeService();
		Map<Long,NoticeTips> map = sysNoticeTipsInfoMap.get(human.getUUID());
		
		if(map == null || map.size() == 0){
			return;
		}
		
		List<NoticeTipsInfo> noticeTipsInfoList = new ArrayList<NoticeTipsInfo>();
		
		Iterator<Entry<Long,NoticeTips>> iterator =  map.entrySet().iterator();
		while(iterator.hasNext()){
			Entry<Long,NoticeTips> entry = iterator.next();
			long diff = timeService.now() - entry.getKey();
			if(diff > TIPS_AGING){
				iterator.remove();
				continue;
			}
			NoticeTips noticeTips = entry.getValue();
			if(noticeTips.getState() == NoticeState.NOT_SEND){
				noticeTips.setState(NoticeState.SENDED);
				noticeTipsInfoList.add(noticeTips.buildNoticTipsInfo());
				if(noticeTips.getType() == NoticeType.NOTICE){
					iterator.remove();
				}
			}
		}
		
		GCNoticeTipsInfoList gcNoticeTipsInfoList = new GCNoticeTipsInfoList();
		gcNoticeTipsInfoList.setNoticeTipsInfoList(noticeTipsInfoList.toArray(new NoticeTipsInfo[0]));
		human.sendMessage(gcNoticeTipsInfoList);
	}
}
