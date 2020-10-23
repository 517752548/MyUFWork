package com.imop.lj.gameserver.command;

import com.imop.lj.core.command.ICommandProcessor;
import com.imop.lj.core.command.impl.CommandProcessorImpl;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.impl.ArenaCmd;
import com.imop.lj.gameserver.command.impl.BattleCmd;
import com.imop.lj.gameserver.command.impl.BehaviorCountClearCmd;
import com.imop.lj.gameserver.command.impl.BindIdBehaviorCountClearCmd;
import com.imop.lj.gameserver.command.impl.CDKeyCmd;
import com.imop.lj.gameserver.command.impl.ChangeVipLevelCmd;
import com.imop.lj.gameserver.command.impl.ChargeCmd;
import com.imop.lj.gameserver.command.impl.ClearItemCmd;
import com.imop.lj.gameserver.command.impl.ConsumeConfirmCmd;
import com.imop.lj.gameserver.command.impl.CorpsBossCmd;
import com.imop.lj.gameserver.command.impl.CorpsCmd;
import com.imop.lj.gameserver.command.impl.CorpsWarCmd;
import com.imop.lj.gameserver.command.impl.DbChangeCmd;
import com.imop.lj.gameserver.command.impl.DevilIncarnateCmd;
import com.imop.lj.gameserver.command.impl.DoublePointCmd;
import com.imop.lj.gameserver.command.impl.DrillGroundCmd;
import com.imop.lj.gameserver.command.impl.ExamCmd;
import com.imop.lj.gameserver.command.impl.FuncCmd;
import com.imop.lj.gameserver.command.impl.GiveItemCmd;
import com.imop.lj.gameserver.command.impl.GiveMoneyCmd;
import com.imop.lj.gameserver.command.impl.GivePetCmd;
import com.imop.lj.gameserver.command.impl.GiveSkillCmd;
import com.imop.lj.gameserver.command.impl.GiveTitleCmd;
import com.imop.lj.gameserver.command.impl.GoodActivityCmd;
import com.imop.lj.gameserver.command.impl.GuideCmd;
import com.imop.lj.gameserver.command.impl.HumanAddExpCmd;
import com.imop.lj.gameserver.command.impl.ItemCmd;
import com.imop.lj.gameserver.command.impl.KillCdTimeCmd;
import com.imop.lj.gameserver.command.impl.MapCmd;
import com.imop.lj.gameserver.command.impl.NvnCmd;
import com.imop.lj.gameserver.command.impl.OvermanCmd;
import com.imop.lj.gameserver.command.impl.PetUpdateCmd;
import com.imop.lj.gameserver.command.impl.PlotCmd;
import com.imop.lj.gameserver.command.impl.PubTaskCmd;
import com.imop.lj.gameserver.command.impl.QuestCmd;
import com.imop.lj.gameserver.command.impl.RelationCmd;
import com.imop.lj.gameserver.command.impl.TeamCmd;
import com.imop.lj.gameserver.command.impl.TimeLimitCmd;
import com.imop.lj.gameserver.command.impl.TimeQueueCmd;
import com.imop.lj.gameserver.command.impl.UpdateHumanLifeSkillLevelCmd;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月12日 下午3:36:00
 * @version 1.0
 */

public class CommandBaseProcessorGameServer <T extends ISession> extends
	CommandProcessorImpl<T> {

	public void register(ICommandProcessor<ISession> cmdProcessor) {
		cmdProcessor.registerCommand(new GiveItemCmd());
		cmdProcessor.registerCommand(new GiveMoneyCmd());
		cmdProcessor.registerCommand(new GiveItemCmd());
		cmdProcessor.registerCommand(new ChangeVipLevelCmd());
		cmdProcessor.registerCommand(new BehaviorCountClearCmd());
		cmdProcessor.registerCommand(new BindIdBehaviorCountClearCmd());
		cmdProcessor.registerCommand(new DrillGroundCmd());
		cmdProcessor.registerCommand(new TimeQueueCmd());
		cmdProcessor.registerCommand(new FuncCmd());
		cmdProcessor.registerCommand(new DbChangeCmd());
		cmdProcessor.registerCommand(new ClearItemCmd());
		cmdProcessor.registerCommand(new KillCdTimeCmd());
		cmdProcessor.registerCommand(new ConsumeConfirmCmd());
		cmdProcessor.registerCommand(new ChargeCmd());
		cmdProcessor.registerCommand(new GivePetCmd());
		cmdProcessor.registerCommand(new QuestCmd());
		cmdProcessor.registerCommand(new GoodActivityCmd());
		cmdProcessor.registerCommand(new RelationCmd());
		cmdProcessor.registerCommand(new ItemCmd());
		cmdProcessor.registerCommand(new CDKeyCmd());
		cmdProcessor.registerCommand(new PetUpdateCmd());
		cmdProcessor.registerCommand(new HumanAddExpCmd());
		cmdProcessor.registerCommand(new ExamCmd());
		cmdProcessor.registerCommand(new PubTaskCmd());
		cmdProcessor.registerCommand(new GiveSkillCmd());
		cmdProcessor.registerCommand(new MapCmd());
		cmdProcessor.registerCommand(new TeamCmd());
		cmdProcessor.registerCommand(new UpdateHumanLifeSkillLevelCmd());
		cmdProcessor.registerCommand(new GiveTitleCmd());
		cmdProcessor.registerCommand(new CorpsWarCmd());
		cmdProcessor.registerCommand(new OvermanCmd());
		cmdProcessor.registerCommand(new NvnCmd());
		cmdProcessor.registerCommand(new ArenaCmd());
		cmdProcessor.registerCommand(new CorpsCmd());
		cmdProcessor.registerCommand(new GuideCmd());
		cmdProcessor.registerCommand(new BattleCmd());
		cmdProcessor.registerCommand(new DoublePointCmd());
		cmdProcessor.registerCommand(new CorpsBossCmd());
		cmdProcessor.registerCommand(new DevilIncarnateCmd());
		cmdProcessor.registerCommand(new TimeLimitCmd());
		cmdProcessor.registerCommand(new PlotCmd());
		
	}
}
