package com.imop.lj.gameserver.common.handler;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.INoticeTipsHandler;
import com.imop.lj.gameserver.common.msg.CGClickNoticeTipsInfo;
import com.imop.lj.gameserver.common.msg.CGOfflineUserBaseInfo;
import com.imop.lj.gameserver.common.msg.CGOfflineUserLeaderInfo;
import com.imop.lj.gameserver.common.msg.CGOfflineUserPetInfo;
import com.imop.lj.gameserver.common.msg.CGPing;
import com.imop.lj.gameserver.common.msg.CGSelectOption;
import com.imop.lj.gameserver.common.msg.CGSendNoticeTips;
import com.imop.lj.gameserver.common.msg.CGSetConsumeConfirm;
import com.imop.lj.gameserver.common.msg.GCPing;
import com.imop.lj.gameserver.human.ConsumeConfirmInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.StaticHandlelHolder;

/**
 * 各模块通用消息处理器
 *
 */
public class CommonMessageHandler {
	
	/**
	 * 处理 ping 消息
	 * 
	 * @param player
	 * @param cgPing
	 */
	public void handlePing(Player player, CGPing cgPing) {
		GCPing msg = new GCPing(Globals.getTimeService().now());
		player.sendMessage(msg);
	}

	/**
	 * 处理确认框选择消息
	 *
	 * @param player
	 * @param cgSelectOption
	 */
	public void handleSelectOption(Player player, CGSelectOption cgSelectOption) {
		if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			return;
		}
		StaticHandlelHolder holder = human.getStaticHandlelHolder();

		// 获取状态处理器
		IStaticHandler handler = holder.getHandler();
		// 获取状态标识
		String tag = holder.getTag();

		// 取得保存的数据后清空
		holder.clear();

		if ((tag != null) && (tag.equals(cgSelectOption.getTag()))) {
			if (handler != null) {
				handler.exec(human, cgSelectOption.getSeletctedValue() == 1 ? true : false);
				handler.setConfirm(human, cgSelectOption.getIsSelected());
			}
		}
	}

//	/**
//	 * 处理确认框选择消息
//	 *
//	 * @param player
//	 * @param cgSelectOption
//	 */
//	public void handlePayShow(Player player, CGPayShow cgPayShow) {
//		GCPayShow gcPayShow = new GCPayShow();
//		ConsumeConfirmInfo[] consumeConfirmInfo = player.getHuman().getConsumeConfirmManager().getListConfirm();
//
//		gcPayShow.setConsumeConfirmInfoList(consumeConfirmInfo);
//		player.sendMessage(gcPayShow);
//	}

	/**
	 * 设置消费确认提示
	 *
	 * CodeGenerator
	 */
	public void handleSetConsumeConfirm(Player player, CGSetConsumeConfirm cgSetConsumeConfirm) {
		Map<Integer, Integer> confirmInfoMap = new HashMap<Integer, Integer>();
		ConsumeConfirmInfo consumeConfirmInfo[] = cgSetConsumeConfirm.getConsumeConfirmInfoList();
		for (ConsumeConfirmInfo single : consumeConfirmInfo) {
			// Human
			confirmInfoMap.put(single.getConfirmType(), single.getIsSelected());
		}
	}

	/**
	 * 选择确认小信封
	 * 
	 * CodeGenerator
	 */
	public void handleClickNoticeTipsInfo(Player player, CGClickNoticeTipsInfo cgClickNoticeTipsInfo) {
		if (player == null) {
			return;
		}
		String tag = cgClickNoticeTipsInfo.getTag();
		if (tag == null || !(tag.equalsIgnoreCase(tag))) {
			return;
		}

		Long key = Long.parseLong(tag);

		// 获取tips处理器
		INoticeTipsHandler handler = Globals.getNoticeTipsInfoService().getNoticeTipsHandler(player.getHuman().getUUID(), key);

		if (handler != null) {
			handler.exec(cgClickNoticeTipsInfo.getValue());
		}
	}
	
	/**
	 * 发送小信封
	 * 
	 * CodeGenerator
	 */
	
	public void handleSendNoticeTips(Player player, CGSendNoticeTips cgSendNoticeTips) {
		if (player == null) {
			return;
		}
		Long tag = cgSendNoticeTips.getRoleId();
		if (tag == null || tag <= 0L) {
			return;
		}
		if(cgSendNoticeTips.getContent() == null || cgSendNoticeTips.getContent().isEmpty()){
			return;
		}
		//Globals.getNoticeTipsInfoService().sendNoticeTipsByPlayer(player.getHuman().getUUID(), tag, cgSendNoticeTips.getContent());
	}
	
	public void handleOfflineUserBaseInfo(Player player, CGOfflineUserBaseInfo cgOfflineUserBaseInfo) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		long targetId = cgOfflineUserBaseInfo.getRoleId();
		if (targetId <= 0) {
			return;
		}
		
		Globals.getOfflineDataService().sendRoleBaseInfoMsg(player.getHuman(), targetId);
	}
	
	public void handleOfflineUserLeaderInfo(Player player, CGOfflineUserLeaderInfo cgOfflineUserLeaderInfo) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		long targetId = cgOfflineUserLeaderInfo.getRoleId();
		if (targetId <= 0) {
			return;
		}
		
		Globals.getOfflineDataService().sendRoleLeaderInfoMsg(player.getHuman(), targetId);
	}
	
	public void handleOfflineUserPetInfo(Player player, CGOfflineUserPetInfo cgOfflineUserPetInfo) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		long targetId = cgOfflineUserPetInfo.getRoleId();
		long targetPetId = cgOfflineUserPetInfo.getPetId();
		if (targetId <= 0 || targetPetId <= 0) {
			return;
		}
		
		Globals.getOfflineDataService().sendRolePetInfoMsg(player.getHuman(), targetId, targetPetId);
	}
}
