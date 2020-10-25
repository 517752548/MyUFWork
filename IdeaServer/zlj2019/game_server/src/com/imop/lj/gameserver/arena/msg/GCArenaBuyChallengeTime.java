package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 购买挑战次数结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaBuyChallengeTime extends GCMessage{
	
	/** 当前可以挑战挑战次数 */
	private int challengeTimes;
	/** 购买竞技场次数消耗金票数 */
	private int buyChallengeTimesCost;

	public GCArenaBuyChallengeTime (){
	}
	
	public GCArenaBuyChallengeTime (
			int challengeTimes,
			int buyChallengeTimesCost ){
			this.challengeTimes = challengeTimes;
			this.buyChallengeTimesCost = buyChallengeTimesCost;
	}

	@Override
	protected boolean readImpl() {

	// 当前可以挑战挑战次数
	int _challengeTimes = readInteger();
	//end


	// 购买竞技场次数消耗金票数
	int _buyChallengeTimesCost = readInteger();
	//end



		this.challengeTimes = _challengeTimes;
		this.buyChallengeTimesCost = _buyChallengeTimesCost;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 当前可以挑战挑战次数
	writeInteger(challengeTimes);


	// 购买竞技场次数消耗金票数
	writeInteger(buyChallengeTimesCost);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ARENA_BUY_CHALLENGE_TIME;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ARENA_BUY_CHALLENGE_TIME";
	}

	public int getChallengeTimes(){
		return challengeTimes;
	}
		
	public void setChallengeTimes(int challengeTimes){
		this.challengeTimes = challengeTimes;
	}

	public int getBuyChallengeTimesCost(){
		return buyChallengeTimesCost;
	}
		
	public void setBuyChallengeTimesCost(int buyChallengeTimesCost){
		this.buyChallengeTimesCost = buyChallengeTimesCost;
	}
}