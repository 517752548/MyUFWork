package com.imop.lj.gameserver.battle.report;

import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.IBattle;

public interface IReportRecord {
	public void addToContent(Phase phase,List<RecordContent> peportItems);
	
	public void addToContent(Phase phase, RecordContent recordContent);
	
	public void setBattle(IBattle battle);
}
