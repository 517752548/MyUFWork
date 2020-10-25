package com.imop.lj.gameserver.guaji.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.guaji.handler.GuajiHandlerFactory;

/**
 * 开始挂机
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGStartGuaJi extends CGMessage{
	
	/** 遇敌间隔 */
	private int encounterSecond;
	/** 增加人物经验(1-1倍经验,2-2倍经验) */
	private int humanExpTimes;
	/** 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验) */
	private int petExpTimes;
	/** 1开启，0关闭 */
	private int fullEnemy;
	/** 1开启，0关闭 */
	private int switchScene;
	/** 挂机分钟数 */
	private int guaJiMinute;
	/** 所需挂机点数 */
	private int needGuaJiPoint;
	
	public CGStartGuaJi (){
	}
	
	public CGStartGuaJi (
			int encounterSecond,
			int humanExpTimes,
			int petExpTimes,
			int fullEnemy,
			int switchScene,
			int guaJiMinute,
			int needGuaJiPoint ){
			this.encounterSecond = encounterSecond;
			this.humanExpTimes = humanExpTimes;
			this.petExpTimes = petExpTimes;
			this.fullEnemy = fullEnemy;
			this.switchScene = switchScene;
			this.guaJiMinute = guaJiMinute;
			this.needGuaJiPoint = needGuaJiPoint;
	}
	
	@Override
	protected boolean readImpl() {

	// 遇敌间隔
	int _encounterSecond = readInteger();
	//end


	// 增加人物经验(1-1倍经验,2-2倍经验)
	int _humanExpTimes = readInteger();
	//end


	// 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验)
	int _petExpTimes = readInteger();
	//end


	// 1开启，0关闭
	int _fullEnemy = readInteger();
	//end


	// 1开启，0关闭
	int _switchScene = readInteger();
	//end


	// 挂机分钟数
	int _guaJiMinute = readInteger();
	//end


	// 所需挂机点数
	int _needGuaJiPoint = readInteger();
	//end



			this.encounterSecond = _encounterSecond;
			this.humanExpTimes = _humanExpTimes;
			this.petExpTimes = _petExpTimes;
			this.fullEnemy = _fullEnemy;
			this.switchScene = _switchScene;
			this.guaJiMinute = _guaJiMinute;
			this.needGuaJiPoint = _needGuaJiPoint;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 遇敌间隔
	writeInteger(encounterSecond);


	// 增加人物经验(1-1倍经验,2-2倍经验)
	writeInteger(humanExpTimes);


	// 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验)
	writeInteger(petExpTimes);


	// 1开启，0关闭
	writeInteger(fullEnemy);


	// 1开启，0关闭
	writeInteger(switchScene);


	// 挂机分钟数
	writeInteger(guaJiMinute);


	// 所需挂机点数
	writeInteger(needGuaJiPoint);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_START_GUA_JI;
	}
	
	@Override
	public String getTypeName() {
		return "CG_START_GUA_JI";
	}

	public int getEncounterSecond(){
		return encounterSecond;
	}
		
	public void setEncounterSecond(int encounterSecond){
		this.encounterSecond = encounterSecond;
	}

	public int getHumanExpTimes(){
		return humanExpTimes;
	}
		
	public void setHumanExpTimes(int humanExpTimes){
		this.humanExpTimes = humanExpTimes;
	}

	public int getPetExpTimes(){
		return petExpTimes;
	}
		
	public void setPetExpTimes(int petExpTimes){
		this.petExpTimes = petExpTimes;
	}

	public int getFullEnemy(){
		return fullEnemy;
	}
		
	public void setFullEnemy(int fullEnemy){
		this.fullEnemy = fullEnemy;
	}

	public int getSwitchScene(){
		return switchScene;
	}
		
	public void setSwitchScene(int switchScene){
		this.switchScene = switchScene;
	}

	public int getGuaJiMinute(){
		return guaJiMinute;
	}
		
	public void setGuaJiMinute(int guaJiMinute){
		this.guaJiMinute = guaJiMinute;
	}

	public int getNeedGuaJiPoint(){
		return needGuaJiPoint;
	}
		
	public void setNeedGuaJiPoint(int needGuaJiPoint){
		this.needGuaJiPoint = needGuaJiPoint;
	}


	@Override
	public void execute() {
		GuajiHandlerFactory.getHandler().handleStartGuaJi(this.getSession().getPlayer(), this);
	}
}