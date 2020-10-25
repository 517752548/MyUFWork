package com.imop.lj.gameserver.sample;

import java.util.HashSet;
import java.util.Set;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.sample.template.IgnoreCollectStrategyMessageTemplate;

/**
 * 采样服务
 * 
 * @author xiaowei.liu
 * 
 */
public class SampleService implements InitializeRequired {
	
	//特殊消息，不打印内容，只打印消息名字
	protected Set<Short> spec = new HashSet<Short>();
	
	@Override
	public void init() {
		spec.add(MessageType.GC_MAP_PLAYER_CHANGED_LIST);
		spec.add(MessageType.GC_CHAT_MSG);
		spec.add(MessageType.GC_PLAY_BATTLE_REPORT);
		spec.add(MessageType.GC_BATTLE_REPORT_PART);
		spec.add(MessageType.GC_BATTLE_REPORT_PVP);
		spec.add(MessageType.GC_BATTLE_REPORT_TEAM);
		spec.add(MessageType.GC_BAG_UPDATE);
		spec.add(MessageType.GC_ITEM_UPDATE);
	}

	/**
	 * 指定消息类型ID，是否忽略采样策略
	 * 
	 * @param messageTypeId
	 * @return
	 */
	public boolean isIgnoreCollectStratety(short messageTypeId) {
		return Globals.getTemplateCacheService().get(messageTypeId, IgnoreCollectStrategyMessageTemplate.class) != null;
	}

	public boolean isSpecMsg(short messageTypeId) {
		return spec.contains(messageTypeId);
	}
	
	public Object msgToString(IMessage msg) {
		//如果是开启了db升级策率，则认为是线上，部分消息不打印内容，只打印名字
		if (msg != null && Globals.getConfig().isUpgradeDbStrategy() &&
				spec.contains(msg.getType())) {
			return msg.getTypeName();
		}
		return msg;
	}
}
