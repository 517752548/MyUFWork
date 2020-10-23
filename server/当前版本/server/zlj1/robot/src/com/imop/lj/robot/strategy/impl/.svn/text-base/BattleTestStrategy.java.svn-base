package com.imop.lj.robot.strategy.impl;

import java.lang.reflect.Field;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.google.gson.JsonObject;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.battle.msg.CGBattleNextRound;
import com.imop.lj.gameserver.battle.msg.CGBattleUpdateAutoAction;
import com.imop.lj.gameserver.battle.msg.CGPlayBattleReport;
import com.imop.lj.gameserver.battle.msg.GCBattleReportPart;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.map.msg.CGMapPlayerEnter;
import com.imop.lj.gameserver.map.msg.CGMapPlayerMove;
import com.imop.lj.gameserver.pubtask.msg.CGFinishPubtask;
import com.imop.lj.gameserver.pubtask.msg.CGGiveUpPubtask;
import com.imop.lj.gameserver.pubtask.msg.CGOpenPubtaskPanel;
import com.imop.lj.gameserver.pubtask.msg.CGPubtaskAccept;
import com.imop.lj.gameserver.quest.msg.CGAcceptQuest;
import com.imop.lj.gameserver.quest.msg.CGFinishQuest;
import com.imop.lj.gameserver.tower.msg.CGGuaji;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

import net.sf.json.JSONObject;

/**
 *
 */
public class BattleTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public BattleTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		//TODO 回归测试(读取技能模板列表,参考skill.xls-->设置玩家技能,give skill-->设置宠物技能-->读取战报的变化是否达到预期,分析GCBattleReportPart,参考BattleReportDefine)
		
		/////////////////////////////1.单人PVE测试开始////////////////////////////////////////
		testPVEBattle();
		/////////////////////////////1.单人PVE测试结束////////////////////////////////////////
		
		/////////////////////////////2.单人PVP测试开始////////////////////////////////////////
//		testPVPBattle();
		/////////////////////////////2.单人PVP测试结束////////////////////////////////////////
		
		/////////////////////////////3.组队PVE测试开始////////////////////////////////////////
//		testTeamPVEBattle();
		/////////////////////////////3.组队PVE测试结束////////////////////////////////////////
		
		/////////////////////////////4.组队PVP测试开始////////////////////////////////////////
//		testTeamPVPBattle();
		/////////////////////////////4.组队PVP测试结束////////////////////////////////////////
		
		
		
		
		
		
		
		
		
		
	}
	
	public void testPVEBattle(){
		//选择技能战斗
		/** 是否自动战斗，0否，1是 */
		int isAuto;
		/** 玩家选择的技能Id */
		int selSkillId;
		/** 玩家选择的技能目标 */
		int selTarget;
		/** 玩家选择的道具Id */
		int selItemId;
		/** 宠物选择的技能Id */
		int petSelSkillId;
		/** 宠物选择的技能目标,大于100是对方,小于100是己方 */
		int petSelTarget;
		/** 宠物选择的道具Id */
		int petSelItemId;
		/** 召唤宠物Id */
		long summonPetId;
//		CGBattleNextRound nextMsg = new CGBattleNextRound(0,3,0,0,1,101,0,0);
//		this.sendMessage(nextMsg);
		
		//设置玩家自动战斗技能
		CGBattleUpdateAutoAction updateAutoMsg = new CGBattleUpdateAutoAction(1,3);
		this.sendMessage(updateAutoMsg);
		//设置宠物自动战斗技能
		CGBattleUpdateAutoAction updatePetAutoMsg = new CGBattleUpdateAutoAction(2,1);
		this.sendMessage(updatePetAutoMsg);
		
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		chatmsg.setContent("!battle 145");//通天塔1层的怪物
		this.sendMessage(chatmsg);
	}

	/**
	 * 技能效果Id:	302:RECORD_CONTENT_SKILLID
	 * 目标:		401:REPORT_ITEM_TARGET
	 * 血量变化:	402:REPORT_ITEM_HP
	 * @return
	 * @throws IllegalArgumentException
	 * @throws IllegalAccessException
	 */
	public Map<Integer,String> getBpDefineMap() throws IllegalArgumentException, IllegalAccessException{
		Field[] fields = BattleReportDefine.class.getFields();
		Map<Integer,String> bpDefineMap = Maps.newTreeMap();
		for (Field f : fields) {
			bpDefineMap.put(f.getInt(f.getName()), f.getName());
		}
		//1:ATTACKERS
		return bpDefineMap;
//		for(Entry<Integer, String>entry : bpDefineMap.entrySet()){
//			System.out.println(entry.getKey() +":" +entry.getValue());
//		}
	}
	
	@Override
	public void onResponse(IMessage message) {
		//单人PVE战报解析
		if (message instanceof GCBattleReportPart) {
			GCBattleReportPart msg = (GCBattleReportPart) message;
//			System.out.println(msg.getReportPack());
//			JSONObject _json = JSONObject.fromObject(msg.getReportPack());
//			JSONObject _lockJson = JsonUtils.getJSONObject(_json, "lock");
//			if (_lockJson != null) {
//				_reason = JsonUtils.getString(_lockJson, "reason");
//			}
			
			//自动战斗
			CGBattleNextRound nextMsg = new CGBattleNextRound(1, 0, 0, 0, 0, 0, 0, 0);
			this.sendMessage(nextMsg);
		}
		
		
		
		
	}
}
