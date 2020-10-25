package com.imop.lj.gameserver.guaji.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回挂机信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGuaJiPanel extends GCMessage{
	
	/** 挂机信息 */
	private com.imop.lj.common.model.human.GuaJiInfo guaJiInfo;

	public GCGuaJiPanel (){
	}
	
	public GCGuaJiPanel (
			com.imop.lj.common.model.human.GuaJiInfo guaJiInfo ){
			this.guaJiInfo = guaJiInfo;
	}

	@Override
	protected boolean readImpl() {
	// 挂机信息
	com.imop.lj.common.model.human.GuaJiInfo _guaJiInfo = new com.imop.lj.common.model.human.GuaJiInfo();

	// 遇敌间隔
	int _guaJiInfo_encounterSecond = readInteger();
	//end
	_guaJiInfo.setEncounterSecond (_guaJiInfo_encounterSecond);

	// 增加人物经验(1-1倍经验,2-2倍经验)
	int _guaJiInfo_humanExpTimes = readInteger();
	//end
	_guaJiInfo.setHumanExpTimes (_guaJiInfo_humanExpTimes);

	// 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验)
	int _guaJiInfo_petExpTimes = readInteger();
	//end
	_guaJiInfo.setPetExpTimes (_guaJiInfo_petExpTimes);

	// 是否开启满怪
	boolean _guaJiInfo_fullEnemy = readBoolean();
	//end
	_guaJiInfo.setFullEnemy (_guaJiInfo_fullEnemy);

	// 切换场景暂停
	boolean _guaJiInfo_switchScene = readBoolean();
	//end
	_guaJiInfo.setSwitchScene (_guaJiInfo_switchScene);

	// 挂机分钟数
	int _guaJiInfo_guaJiMinute = readInteger();
	//end
	_guaJiInfo.setGuaJiMinute (_guaJiInfo_guaJiMinute);

	// 剩余挂机时间,毫秒
	long _guaJiInfo_leftTime = readLong();
	//end
	_guaJiInfo.setLeftTime (_guaJiInfo_leftTime);

	// 所需挂机点数
	int _guaJiInfo_needGuaJiPoint = readInteger();
	//end
	_guaJiInfo.setNeedGuaJiPoint (_guaJiInfo_needGuaJiPoint);

	// 是否挂机
	boolean _guaJiInfo_guaJi = readBoolean();
	//end
	_guaJiInfo.setGuaJi (_guaJiInfo_guaJi);



		this.guaJiInfo = _guaJiInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	int guaJiInfo_encounterSecond = guaJiInfo.getEncounterSecond ();

	// 遇敌间隔
	writeInteger(guaJiInfo_encounterSecond);

	int guaJiInfo_humanExpTimes = guaJiInfo.getHumanExpTimes ();

	// 增加人物经验(1-1倍经验,2-2倍经验)
	writeInteger(guaJiInfo_humanExpTimes);

	int guaJiInfo_petExpTimes = guaJiInfo.getPetExpTimes ();

	// 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验)
	writeInteger(guaJiInfo_petExpTimes);

	boolean guaJiInfo_fullEnemy = guaJiInfo.getFullEnemy ();

	// 是否开启满怪
	writeBoolean(guaJiInfo_fullEnemy);

	boolean guaJiInfo_switchScene = guaJiInfo.getSwitchScene ();

	// 切换场景暂停
	writeBoolean(guaJiInfo_switchScene);

	int guaJiInfo_guaJiMinute = guaJiInfo.getGuaJiMinute ();

	// 挂机分钟数
	writeInteger(guaJiInfo_guaJiMinute);

	long guaJiInfo_leftTime = guaJiInfo.getLeftTime ();

	// 剩余挂机时间,毫秒
	writeLong(guaJiInfo_leftTime);

	int guaJiInfo_needGuaJiPoint = guaJiInfo.getNeedGuaJiPoint ();

	// 所需挂机点数
	writeInteger(guaJiInfo_needGuaJiPoint);

	boolean guaJiInfo_guaJi = guaJiInfo.getGuaJi ();

	// 是否挂机
	writeBoolean(guaJiInfo_guaJi);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_GUA_JI_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GUA_JI_PANEL";
	}

	public com.imop.lj.common.model.human.GuaJiInfo getGuaJiInfo(){
		return guaJiInfo;
	}
		
	public void setGuaJiInfo(com.imop.lj.common.model.human.GuaJiInfo guaJiInfo){
		this.guaJiInfo = guaJiInfo;
	}
}