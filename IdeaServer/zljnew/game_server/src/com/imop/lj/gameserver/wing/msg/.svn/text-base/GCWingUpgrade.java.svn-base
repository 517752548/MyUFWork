package com.imop.lj.gameserver.wing.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 升阶翅膀结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWingUpgrade extends GCMessage{
	
	/** 翅膀 */
	private com.imop.lj.gameserver.wing.WingInfo wing;
	/** 升阶翅膀结果 1成功 2失败 */
	private int result;

	public GCWingUpgrade (){
	}
	
	public GCWingUpgrade (
			com.imop.lj.gameserver.wing.WingInfo wing,
			int result ){
			this.wing = wing;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {
	// 翅膀
	com.imop.lj.gameserver.wing.WingInfo _wing = new com.imop.lj.gameserver.wing.WingInfo();

	// 翅膀类型id
	int _wing_templateId = readInteger();
	//end
	_wing.setTemplateId (_wing_templateId);

	// 是否已装备
	int _wing_isEquip = readInteger();
	//end
	_wing.setIsEquip (_wing_isEquip);

	// 翅膀阶数
	int _wing_wingLevel = readInteger();
	//end
	_wing.setWingLevel (_wing_wingLevel);

	// 翅膀祝福值
	int _wing_wingBless = readInteger();
	//end
	_wing.setWingBless (_wing_wingBless);

	// 翅膀战斗力
	int _wing_wingPower = readInteger();
	//end
	_wing.setWingPower (_wing_wingPower);


	// 升阶翅膀结果 1成功 2失败
	int _result = readInteger();
	//end



		this.wing = _wing;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	int wing_templateId = wing.getTemplateId ();

	// 翅膀类型id
	writeInteger(wing_templateId);

	int wing_isEquip = wing.getIsEquip ();

	// 是否已装备
	writeInteger(wing_isEquip);

	int wing_wingLevel = wing.getWingLevel ();

	// 翅膀阶数
	writeInteger(wing_wingLevel);

	int wing_wingBless = wing.getWingBless ();

	// 翅膀祝福值
	writeInteger(wing_wingBless);

	int wing_wingPower = wing.getWingPower ();

	// 翅膀战斗力
	writeInteger(wing_wingPower);


	// 升阶翅膀结果 1成功 2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_WING_UPGRADE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_WING_UPGRADE";
	}

	public com.imop.lj.gameserver.wing.WingInfo getWing(){
		return wing;
	}
		
	public void setWing(com.imop.lj.gameserver.wing.WingInfo wing){
		this.wing = wing;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}