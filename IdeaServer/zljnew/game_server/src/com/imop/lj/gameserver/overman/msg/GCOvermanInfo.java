package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 师徒相关信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOvermanInfo extends GCMessage{
	
	/** 师傅charId */
	private long overman;
	/** 师傅charId */
	private String overmanName;
	/** 师傅的模版id */
	private int overmanTemplateId;
	/** 师傅是否在线,1是,0否 */
	private boolean isOnline;
	/** 徒弟信息 */
	private com.imop.lj.gameserver.overman.LowermanInfo[] lowerList;

	public GCOvermanInfo (){
	}
	
	public GCOvermanInfo (
			long overman,
			String overmanName,
			int overmanTemplateId,
			boolean isOnline,
			com.imop.lj.gameserver.overman.LowermanInfo[] lowerList ){
			this.overman = overman;
			this.overmanName = overmanName;
			this.overmanTemplateId = overmanTemplateId;
			this.isOnline = isOnline;
			this.lowerList = lowerList;
	}

	@Override
	protected boolean readImpl() {

	// 师傅charId
	long _overman = readLong();
	//end


	// 师傅charId
	String _overmanName = readString();
	//end


	// 师傅的模版id
	int _overmanTemplateId = readInteger();
	//end


	// 师傅是否在线,1是,0否
	boolean _isOnline = readBoolean();
	//end


	// 徒弟信息
	int lowerListSize = readUnsignedShort();
	com.imop.lj.gameserver.overman.LowermanInfo[] _lowerList = new com.imop.lj.gameserver.overman.LowermanInfo[lowerListSize];
	int lowerListIndex = 0;
	for(lowerListIndex=0; lowerListIndex<lowerListSize; lowerListIndex++){
		_lowerList[lowerListIndex] = new com.imop.lj.gameserver.overman.LowermanInfo();
	// 玩家id
	long _lowerList_uuid = readLong();
	//end
	_lowerList[lowerListIndex].setUuid (_lowerList_uuid);

	// 拜师时间
	long _lowerList_createTime = readLong();
	//end
	_lowerList[lowerListIndex].setCreateTime (_lowerList_createTime);

	// 玩家名称
	String _lowerList_humanName = readString();
	//end
	_lowerList[lowerListIndex].setHumanName (_lowerList_humanName);

	// 等级
	int _lowerList_level = readInteger();
	//end
	_lowerList[lowerListIndex].setLevel (_lowerList_level);

	// 战力
	int _lowerList_fightPower = readInteger();
	//end
	_lowerList[lowerListIndex].setFightPower (_lowerList_fightPower);

	// 模版id
	int _lowerList_templateId = readInteger();
	//end
	_lowerList[lowerListIndex].setTemplateId (_lowerList_templateId);

	// 是否在线,1是,0否
	boolean _lowerList_isOnline = readBoolean();
	//end
	_lowerList[lowerListIndex].setIsOnline (_lowerList_isOnline);
	}
	//end



		this.overman = _overman;
		this.overmanName = _overmanName;
		this.overmanTemplateId = _overmanTemplateId;
		this.isOnline = _isOnline;
		this.lowerList = _lowerList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 师傅charId
	writeLong(overman);


	// 师傅charId
	writeString(overmanName);


	// 师傅的模版id
	writeInteger(overmanTemplateId);


	// 师傅是否在线,1是,0否
	writeBoolean(isOnline);


	// 徒弟信息
	writeShort(lowerList.length);
	int lowerListIndex = 0;
	int lowerListSize = lowerList.length;
	for(lowerListIndex=0; lowerListIndex<lowerListSize; lowerListIndex++){

	long lowerList_uuid = lowerList[lowerListIndex].getUuid();

	// 玩家id
	writeLong(lowerList_uuid);

	long lowerList_createTime = lowerList[lowerListIndex].getCreateTime();

	// 拜师时间
	writeLong(lowerList_createTime);

	String lowerList_humanName = lowerList[lowerListIndex].getHumanName();

	// 玩家名称
	writeString(lowerList_humanName);

	int lowerList_level = lowerList[lowerListIndex].getLevel();

	// 等级
	writeInteger(lowerList_level);

	int lowerList_fightPower = lowerList[lowerListIndex].getFightPower();

	// 战力
	writeInteger(lowerList_fightPower);

	int lowerList_templateId = lowerList[lowerListIndex].getTemplateId();

	// 模版id
	writeInteger(lowerList_templateId);

	boolean lowerList_isOnline = lowerList[lowerListIndex].getIsOnline();

	// 是否在线,1是,0否
	writeBoolean(lowerList_isOnline);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OVERMAN_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OVERMAN_INFO";
	}

	public long getOverman(){
		return overman;
	}
		
	public void setOverman(long overman){
		this.overman = overman;
	}

	public String getOvermanName(){
		return overmanName;
	}
		
	public void setOvermanName(String overmanName){
		this.overmanName = overmanName;
	}

	public int getOvermanTemplateId(){
		return overmanTemplateId;
	}
		
	public void setOvermanTemplateId(int overmanTemplateId){
		this.overmanTemplateId = overmanTemplateId;
	}

	public boolean getIsOnline(){
		return isOnline;
	}
		
	public void setIsOnline(boolean isOnline){
		this.isOnline = isOnline;
	}

	public com.imop.lj.gameserver.overman.LowermanInfo[] getLowerList(){
		return lowerList;
	}

	public void setLowerList(com.imop.lj.gameserver.overman.LowermanInfo[] lowerList){
		this.lowerList = lowerList;
	}	
}