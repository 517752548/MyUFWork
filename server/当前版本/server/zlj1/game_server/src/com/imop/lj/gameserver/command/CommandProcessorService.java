package com.imop.lj.gameserver.command;

import org.slf4j.Logger;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.command.ICommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月11日 上午11:37:31
 * @version 1.0
 */

public class CommandProcessorService implements InitializeRequired {

	private Logger logger = Loggers.commandProcessorLogger;
	
	private CommandBaseProcessorGameServer<ISession> cmdProcessor;

	public CommandProcessorService() {
		cmdProcessor = new CommandBaseProcessorGameServer<ISession>();
	}

	@Override
	public void init() {
		cmdProcessor.register(cmdProcessor);

	}

//	private void registerCmd() {
//		cmdProcessor.registerCommand(new GiveMoneyCmd());
//		cmdProcessor.registerCommand(new GiveItemCmd());
//		cmdProcessor.registerCommand(new ChangeVipLevelCmd());
//		cmdProcessor.registerCommand(new BehaviorCountClearCmd());
//		cmdProcessor.registerCommand(new BindIdBehaviorCountClearCmd());
//		cmdProcessor.registerCommand(new DrillGroundCmd());
//		cmdProcessor.registerCommand(new FormationCmd());
//		cmdProcessor.registerCommand(new TimeQueueCmd());
//		cmdProcessor.registerCommand(new BattleCmd());
//		cmdProcessor.registerCommand(new MissionCmd());
//		cmdProcessor.registerCommand(new RaidCmd());
//		cmdProcessor.registerCommand(new ArenaCmd());
//		cmdProcessor.registerCommand(new BossWarWorldCmd());
//		cmdProcessor.registerCommand(new CorpsWarCmd());
//		cmdProcessor.registerCommand(new MoneyTreeCmd());
//		cmdProcessor.registerCommand(new FuncCmd());
//		cmdProcessor.registerCommand(new LandlordCmd());
//		cmdProcessor.registerCommand(new GuideCmd());
//		cmdProcessor.registerCommand(new PopTipsCmd());
//		cmdProcessor.registerCommand(new StoryCmd());
//		cmdProcessor.registerCommand(new HorseCmd());
//		cmdProcessor.registerCommand(new LandCmd());
//		cmdProcessor.registerCommand(new DbChangeCmd());
//		cmdProcessor.registerCommand(new ClearItemCmd());
//		cmdProcessor.registerCommand(new KillCdTimeCmd());
//		cmdProcessor.registerCommand(new ConsumeConfirmCmd());
//		cmdProcessor.registerCommand(new ChargeCmd());
//		cmdProcessor.registerCommand(new PassTaskCmd());
//		cmdProcessor.registerCommand(new ChooseCountryCmd());
//		cmdProcessor.registerCommand(new GivePetCmd());
//		cmdProcessor.registerCommand(new QuestCmd());
//		cmdProcessor.registerCommand(new GoodActivityCmd());
//		cmdProcessor.registerCommand(new RelationCmd());
//		cmdProcessor.registerCommand(new BunCmd());
//		cmdProcessor.registerCommand(new ItemCmd());
//		cmdProcessor.registerCommand(new MonsterWarCmd());
//		cmdProcessor.registerCommand(new ArmourCmd());
//		cmdProcessor.registerCommand(new CardCmd());
//		cmdProcessor.registerCommand(new TurntableCmd());
//		cmdProcessor.registerCommand(new BankCmd());
//		cmdProcessor.registerCommand(new GemMazeCmd());
//		cmdProcessor.registerCommand(new ConvertMallCmd());
//		cmdProcessor.registerCommand(new QQMarketTaskCmd());
//
//	}

	
	public String execute(Player player, String commandStr) {
		if(null == player) {
			logger.info("#CommandProcessorService#execute#commandStr :" + commandStr + " , player is null, return!");
			return "Fail";
		}
		Human human = player.getHuman();
		if (human == null) {
			return "Fail";
		}
		
		if (commandStr.startsWith(ICommand.CMD_PREFIX)) {
			// 命令方式
			logger.info("#CommandProcessorService#execute#commandStr=" + commandStr + " is command! humanUUID=" +human.getUUID());

			if (this.cmdProcessor != null) {
				this.cmdProcessor.execute(player.getSession(), commandStr);

				// 获取空格字符索引
				int spaceCharIndex = commandStr.indexOf(" ");

				String cmdName = "";
				String cmdParams = "";

				if (spaceCharIndex == -1) {
					cmdName = commandStr;
				} else {
					// 命令名称和命令参数
					cmdName = commandStr.substring(0, spaceCharIndex);
					cmdParams = commandStr.substring(spaceCharIndex);
				}

				try {
					// 记录 GM 命令日志
					Globals.getLogService().sendGmCommandLog(human, LogReasons.GmCommandLogReason.REASON_VALID_USE_GMCMD, commandStr,
							human.getName(), player.getClientIp(), cmdName, null, cmdParams, null);
				} catch (Exception ex) {
					logger.error("#CommandProcessorService#sendGmCommandLog#error:", ex);
				}
				return "Succ";
			}
		}
		return "Fail";
	}
}
