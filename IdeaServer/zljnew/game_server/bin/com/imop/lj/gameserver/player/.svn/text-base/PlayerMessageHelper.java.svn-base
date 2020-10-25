package com.imop.lj.gameserver.player;

import java.util.HashSet;
import java.util.Set;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.common.msg.CGHandshake;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.onlinegift.msg.CGGetSpecOnlineGiftShowInfo;
import com.imop.lj.gameserver.player.msg.CGAccountActivationcode;
import com.imop.lj.gameserver.player.msg.CGCreateRole;
import com.imop.lj.gameserver.player.msg.CGEnterScene;
import com.imop.lj.gameserver.player.msg.CGPlayerCookieLogin;
import com.imop.lj.gameserver.player.msg.CGPlayerEnter;
import com.imop.lj.gameserver.player.msg.CGPlayerLogin;
import com.imop.lj.gameserver.player.msg.CGPlayerTokenLogin;
import com.imop.lj.gameserver.player.msg.CGRoleRandomName;
import com.imop.lj.gameserver.player.msg.CGRoleTemplate;

public class PlayerMessageHelper {
	protected static Set<Class<?>> cgmessageWithoutMessage = new HashSet<Class<?>>();
	
	static{
		cgmessageWithoutMessage.add(CGHandshake.class);
		
		cgmessageWithoutMessage.add(CGPlayerLogin.class);
		cgmessageWithoutMessage.add(CGPlayerCookieLogin.class);
		cgmessageWithoutMessage.add(CGPlayerTokenLogin.class);
		cgmessageWithoutMessage.add(CGRoleTemplate.class);
		cgmessageWithoutMessage.add(CGRoleRandomName.class);
		cgmessageWithoutMessage.add(CGCreateRole.class);
		cgmessageWithoutMessage.add(CGPlayerEnter.class);
		
		cgmessageWithoutMessage.add(CGEnterScene.class);
		cgmessageWithoutMessage.add(CGAccountActivationcode.class);
	}
	
	
	public static boolean isWithoutSceneMessage(CGMessage msg){
		return cgmessageWithoutMessage.contains(msg.getClass());
	}
	/**
	 * 打坐允许发的消息
	 */
	protected static Set<Class<?>> dazuoAllowMsg = new HashSet<Class<?>>();
	static{
		
		
		//副本自动战斗，检查最后一轮
//		RaidCGMessage.CG_CHECK_CLEAN_RAID();
//		//关卡自动战斗，检查最后一轮
//		MissionCGMessage.CG_CHECK_CLEAN_MISSION();
		//竞技场 领奖倒计时到点 刷新竞技场
//		ArenaCGMessage.CG_SHOW_ARENA_PANEL();

//		dazuoAllowMsg.add(CGPing.class);
//		dazuoAllowMsg.add(CGFuncUpdate.class);
//		dazuoAllowMsg.add(CGBunEatFinishMsg.class);
//		//吃包子，通知服务器吃了几个包子
//		dazuoAllowMsg.add(CGBunEatFinishMsg.class);
//		//竞技场 领奖倒计时到点 刷新竞技场
//		dazuoAllowMsg.add(CGShowArenaPanel.class);
//		
////		dazuoAllowMsg.add(CanGetPrizeNumMessage.class);
//		
////		dazuoAllowMsg.add(SchedulePlayerAsyncFinishMessage.class);
////		dazuoAllowMsg.add(SysGivePowerMessage.class);
//		dazuoAllowMsg.add(CGPracticeEndMsg.class);
		dazuoAllowMsg.add(CGGetSpecOnlineGiftShowInfo.class);
	}

	public static boolean isDazuoAllowMsg(IMessage msg) {
		return dazuoAllowMsg.contains(msg.getClass());
	}
}
