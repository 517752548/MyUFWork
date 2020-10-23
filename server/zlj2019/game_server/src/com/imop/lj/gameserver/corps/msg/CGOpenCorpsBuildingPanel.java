package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 打开帮派建筑面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenCorpsBuildingPanel extends CGMessage{
	
	/** 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑 */
	private int buildType;
	
	public CGOpenCorpsBuildingPanel (){
	}
	
	public CGOpenCorpsBuildingPanel (
			int buildType ){
			this.buildType = buildType;
	}
	
	@Override
	protected boolean readImpl() {

	// 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑
	int _buildType = readInteger();
	//end



			this.buildType = _buildType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑
	writeInteger(buildType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_OPEN_CORPS_BUILDING_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OPEN_CORPS_BUILDING_PANEL";
	}

	public int getBuildType(){
		return buildType;
	}
		
	public void setBuildType(int buildType){
		this.buildType = buildType;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleOpenCorpsBuildingPanel(this.getSession().getPlayer(), this);
	}
}