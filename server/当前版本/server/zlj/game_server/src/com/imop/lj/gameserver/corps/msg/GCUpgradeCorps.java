package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回升级帮派建筑结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUpgradeCorps extends GCMessage{
	
	/** 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑 */
	private int buildType;
	/** 升级结果,1成功,2失败 */
	private int result;

	public GCUpgradeCorps (){
	}
	
	public GCUpgradeCorps (
			int buildType,
			int result ){
			this.buildType = buildType;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑
	int _buildType = readInteger();
	//end


	// 升级结果,1成功,2失败
	int _result = readInteger();
	//end



		this.buildType = _buildType;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑
	writeInteger(buildType);


	// 升级结果,1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_UPGRADE_CORPS;
	}
	
	@Override
	public String getTypeName() {
		return "GC_UPGRADE_CORPS";
	}

	public int getBuildType(){
		return buildType;
	}
		
	public void setBuildType(int buildType){
		this.buildType = buildType;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}