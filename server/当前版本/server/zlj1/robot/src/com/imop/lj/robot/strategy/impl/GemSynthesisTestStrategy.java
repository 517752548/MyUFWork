package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.battle.msg.CGPlayBattleReport;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.equip.msg.CGEqpGemSynthesis;
import com.imop.lj.gameserver.map.msg.CGMapFightNpc;
import com.imop.lj.gameserver.map.msg.CGMapPlayerMove;
import com.imop.lj.gameserver.team.msg.CGTeamCreate;
import com.imop.lj.gameserver.wizardraid.msg.CGWizardraidAnswerEnterTeam;
import com.imop.lj.gameserver.wizardraid.msg.CGWizardraidAskEnterTeam;
import com.imop.lj.gameserver.wizardraid.msg.CGWizardraidEnterSingle;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class GemSynthesisTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public GemSynthesisTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		//1.准备材料
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		chatmsg.setContent("!giveitem 80010 900");//绿宝石(1级)*900个
		this.sendMessage(chatmsg);
		
		//2.正常合成三合一
		CGEqpGemSynthesis gemSynTestThree = new CGEqpGemSynthesis();
		gemSynTestThree.setGemLevel(2);//合成2级红宝石宝石
		gemSynTestThree.setGemType(2);//绿宝石(1级)
		gemSynTestThree.setSynthesisBase(3);//三合一
		gemSynTestThree.setSynthesisType(1);//单一
		this.sendMessage(gemSynTestThree);
		
		//2.1.正常合成四合一
//		CGEqpGemSynthesis gemSynTestFour = new CGEqpGemSynthesis();
//		gemSynTestFour.setGemLevel(2);//合成2级红宝石宝石
//		gemSynTestFour.setGemType(2);//绿宝石(1级)
//		gemSynTestFour.setSynthesisBase(4);//四合一
//		gemSynTestFour.setSynthesisType(1);//单一
//		this.sendMessage(gemSynTestFour);
		
		//2.2.正常合成五合一
//		CGEqpGemSynthesis gemSynTestFive = new CGEqpGemSynthesis();
//		gemSynTestFive.setGemLevel(2);//合成2级红宝石宝石
//		gemSynTestFive.setGemType(2);//绿宝石(1级)
//		gemSynTestFive.setSynthesisBase(4);//五合一
//		gemSynTestFive.setSynthesisType(1);//全部
//		this.sendMessage(gemSynTestFive);
		
		//3.边界测试：宝石0级和宝石顶级  --测试通过 √
//		CGEqpGemSynthesis gemSynTest2 = new CGEqpGemSynthesis();
////		gemSynTest2.setGemLevel(0);//合成0级红宝石宝石
//		gemSynTest2.setGemLevel(10);//合成10级红宝石宝石
//		gemSynTest2.setGemType(2);//绿宝石(1级)
//		gemSynTest2.setSynthesisBase(3);//三合一
//		gemSynTest2.setSynthesisType(2);//全部
//		this.sendMessage(gemSynTest2);
		
		//4.边界测试：合成基数 --测试通过 √
//		CGEqpGemSynthesis gemSynTest3 = new CGEqpGemSynthesis();
//		gemSynTest3.setGemLevel(2);//合成2级红宝石宝石
//		gemSynTest3.setGemType(2);//绿宝石(1级)
//		gemSynTest3.setSynthesisBase(6);//六合一
//		gemSynTest3.setSynthesisType(2);//全部
//		this.sendMessage(gemSynTest3);
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
