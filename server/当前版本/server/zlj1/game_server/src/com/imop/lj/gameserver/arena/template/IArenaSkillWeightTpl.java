package com.imop.lj.gameserver.arena.template;


/**
 * 该接口就是为了兼容ArenaLeaderSkillWeightTemplate和ArenaPetSkillWeightTemplate中的伙伴
 * @author yu.zhao
 *
 */
public interface IArenaSkillWeightTpl {
	public int getId();
	
	public int getSkillId();

	public boolean isFirst();
	
	public int getWeight();
	
	public int getCdRound();

}
