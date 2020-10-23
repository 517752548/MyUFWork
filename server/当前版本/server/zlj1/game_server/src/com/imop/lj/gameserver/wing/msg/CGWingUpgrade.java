package com.imop.lj.gameserver.wing.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.wing.handler.WingHandlerFactory;

/**
 * 升阶翅膀
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWingUpgrade extends CGMessage{
	
	/** 翅膀模板Id */
	private int templateId;
	/** 升阶方式 1手动2自动 */
	private int upgradeType;
	
	public CGWingUpgrade (){
	}
	
	public CGWingUpgrade (
			int templateId,
			int upgradeType ){
			this.templateId = templateId;
			this.upgradeType = upgradeType;
	}
	
	@Override
	protected boolean readImpl() {

	// 翅膀模板Id
	int _templateId = readInteger();
	//end


	// 升阶方式 1手动2自动
	int _upgradeType = readInteger();
	//end



			this.templateId = _templateId;
			this.upgradeType = _upgradeType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 翅膀模板Id
	writeInteger(templateId);


	// 升阶方式 1手动2自动
	writeInteger(upgradeType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_WING_UPGRADE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_WING_UPGRADE";
	}

	public int getTemplateId(){
		return templateId;
	}
		
	public void setTemplateId(int templateId){
		this.templateId = templateId;
	}

	public int getUpgradeType(){
		return upgradeType;
	}
		
	public void setUpgradeType(int upgradeType){
		this.upgradeType = upgradeType;
	}


	@Override
	public void execute() {
		WingHandlerFactory.getHandler().handleWingUpgrade(this.getSession().getPlayer(), this);
	}
}