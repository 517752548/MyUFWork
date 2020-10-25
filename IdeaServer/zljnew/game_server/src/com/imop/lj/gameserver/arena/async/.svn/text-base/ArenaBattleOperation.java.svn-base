package com.imop.lj.gameserver.arena.async;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.util.CommonUtil;
import com.imop.lj.gameserver.arena.model.ArenaOpponent;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BattleIIoOperation;

public class ArenaBattleOperation implements BattleIIoOperation {
	/** 攻击方玩家Id */
	private long roleId;
	/** 防守方玩家数据 */
	private ArenaOpponent targetOp;
	/** 战斗类型 */
	private BattleType type;
	/** 攻击者战斗对象 */
	private Fighter<?> attacker;
	/** 防守者战斗对象 */
	private Fighter<?> defender;
	
	/** 战斗过程对象 */
	private BattleProcess battleProcess;
	
	public ArenaBattleOperation(long roleId, ArenaOpponent targetOp, BattleType type, Fighter<?> attacker, Fighter<?> defender) {
		this.roleId = roleId;
		this.targetOp = targetOp;
		this.type = type;
		this.attacker = attacker;
		this.defender = defender;
	}

	@Override
	public int doStart() {
		try {
			//创建战斗过程对象
			this.battleProcess = new BattleProcess(roleId, type, attacker, defender);
		} catch (Exception e) {
			//日志
			Loggers.battleLogger.error(e.getMessage(), e);
			//战斗结束
			return STAGE_IO_DONE;
		}
		
		return STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		try {
			//开始战斗
			battleProcess.start();
			
			//每轮战斗
			for (int i = 0; i < battleProcess.getBattle().getMaxRound(); i++) {
				if (Loggers.battleLogger.isDebugEnabled()) {
					Loggers.battleLogger.debug("第 " + (i + 1) + " 轮战斗开始-----");
				}
				
				if (!battleProcess.getBattle().inProgress()) {
					break;
				}
				
				//一轮战斗
				battleProcess.round();
				
				if (Loggers.battleLogger.isDebugEnabled()) {
					Loggers.battleLogger.debug("第 " + (i + 1) + " 轮战斗结束-----");
				}
				
				//战斗结束，生成最终战报
				if (battleProcess.isBattleEnd()) {
					battleProcess.makeFinalReport();
					break;
				}
			}
		} catch(Exception e) {
			Loggers.battleLogger.error(CommonUtil.exceptionToString(e));
			e.printStackTrace();
		}
		
		return STAGE_IO_DONE;
	}

	@Override
	public int doStop() {
		IMessage msg = new SysInternalMessage() {
			@Override
			public void execute() {
				Globals.getArenaService().onBattleEnd(roleId, targetOp, battleProcess);
			}
		};
		//交由场景线程处理，因为玩家可能离线
		Globals.getSceneService().getCommonScene().putMessage(msg);
		
		return STAGE_STOP_DONE;
	}
	
}
