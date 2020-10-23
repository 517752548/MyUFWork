package com.imop.lj.gameserver.siegedemon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 进入组队副本
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSiegedemonEnterTeam extends GCMessage{
	
	/** 副本类型,12-正常,13-困难 */
	private int siegeType;

	public GCSiegedemonEnterTeam (){
	}
	
	public GCSiegedemonEnterTeam (
			int siegeType ){
			this.siegeType = siegeType;
	}

	@Override
	protected boolean readImpl() {

	// 副本类型,12-正常,13-困难
	int _siegeType = readInteger();
	//end



		this.siegeType = _siegeType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 副本类型,12-正常,13-困难
	writeInteger(siegeType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SIEGEDEMON_ENTER_TEAM;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SIEGEDEMON_ENTER_TEAM";
	}

	public int getSiegeType(){
		return siegeType;
	}
		
	public void setSiegeType(int siegeType){
		this.siegeType = siegeType;
	}
}