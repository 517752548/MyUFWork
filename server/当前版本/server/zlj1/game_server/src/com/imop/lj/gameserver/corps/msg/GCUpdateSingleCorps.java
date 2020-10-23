package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 更新单条军团信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUpdateSingleCorps extends GCMessage{
	
	/** 军团信息 */
	private com.imop.lj.common.model.corps.SimpleCorpsInfo simpleCorpsInfo;

	public GCUpdateSingleCorps (){
	}
	
	public GCUpdateSingleCorps (
			com.imop.lj.common.model.corps.SimpleCorpsInfo simpleCorpsInfo ){
			this.simpleCorpsInfo = simpleCorpsInfo;
	}

	@Override
	protected boolean readImpl() {
	// 军团信息
	com.imop.lj.common.model.corps.SimpleCorpsInfo _simpleCorpsInfo = new com.imop.lj.common.model.corps.SimpleCorpsInfo();

	// 军团ID
	long _simpleCorpsInfo_corpsId = readLong();
	//end
	_simpleCorpsInfo.setCorpsId (_simpleCorpsInfo_corpsId);

	// 军团名称
	String _simpleCorpsInfo_name = readString();
	//end
	_simpleCorpsInfo.setName (_simpleCorpsInfo_name);

	// 军团级别
	int _simpleCorpsInfo_level = readInteger();
	//end
	_simpleCorpsInfo.setLevel (_simpleCorpsInfo_level);

	// 团长名称
	String _simpleCorpsInfo_presidentName = readString();
	//end
	_simpleCorpsInfo.setPresidentName (_simpleCorpsInfo_presidentName);

	// 团长ID
	long _simpleCorpsInfo_presidentId = readLong();
	//end
	_simpleCorpsInfo.setPresidentId (_simpleCorpsInfo_presidentId);

	// 团长模板Id
	int _simpleCorpsInfo_presidentTplId = readInteger();
	//end
	_simpleCorpsInfo.setPresidentTplId (_simpleCorpsInfo_presidentTplId);

	// 团长等级
	int _simpleCorpsInfo_presidentLevel = readInteger();
	//end
	_simpleCorpsInfo.setPresidentLevel (_simpleCorpsInfo_presidentLevel);

	// 当前成员数量
	int _simpleCorpsInfo_currMemNum = readInteger();
	//end
	_simpleCorpsInfo.setCurrMemNum (_simpleCorpsInfo_currMemNum);

	// 最大成员数量
	int _simpleCorpsInfo_maxMemNum = readInteger();
	//end
	_simpleCorpsInfo.setMaxMemNum (_simpleCorpsInfo_maxMemNum);

	// 所属国家
	int _simpleCorpsInfo_country = readInteger();
	//end
	_simpleCorpsInfo.setCountry (_simpleCorpsInfo_country);

	// 军团QQ
	String _simpleCorpsInfo_qq = readString();
	//end
	_simpleCorpsInfo.setQq (_simpleCorpsInfo_qq);

	// 公告
	String _simpleCorpsInfo_notice = readString();
	//end
	_simpleCorpsInfo.setNotice (_simpleCorpsInfo_notice);

	// 军团排名
	int _simpleCorpsInfo_rank = readInteger();
	//end
	_simpleCorpsInfo.setRank (_simpleCorpsInfo_rank);

	// 是否已经申请 1是 0否
	int _simpleCorpsInfo_isApplied = readInteger();
	//end
	_simpleCorpsInfo.setIsApplied (_simpleCorpsInfo_isApplied);

	// 军团功能列表
	int simpleCorpsInfo_corpsFuncInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsFuncInfo[] _simpleCorpsInfo_corpsFuncInfoList = new com.imop.lj.common.model.corps.CorpsFuncInfo[simpleCorpsInfo_corpsFuncInfoListSize];
	int simpleCorpsInfo_corpsFuncInfoListIndex = 0;
	for(simpleCorpsInfo_corpsFuncInfoListIndex=0; simpleCorpsInfo_corpsFuncInfoListIndex<simpleCorpsInfo_corpsFuncInfoListSize; simpleCorpsInfo_corpsFuncInfoListIndex++){
		_simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex] = new com.imop.lj.common.model.corps.CorpsFuncInfo();
	// 功能标题
	String _simpleCorpsInfo_corpsFuncInfoList_title = readString();
	//end
	_simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].setTitle (_simpleCorpsInfo_corpsFuncInfoList_title);

	// 附加描述
	String _simpleCorpsInfo_corpsFuncInfoList_desc = readString();
	//end
	_simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].setDesc (_simpleCorpsInfo_corpsFuncInfoList_desc);

	// 功能类型ID
	int _simpleCorpsInfo_corpsFuncInfoList_funcId = readInteger();
	//end
	_simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].setFuncId (_simpleCorpsInfo_corpsFuncInfoList_funcId);

	// 军团ID
	long _simpleCorpsInfo_corpsFuncInfoList_corpsUUID = readLong();
	//end
	_simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].setCorpsUUID (_simpleCorpsInfo_corpsFuncInfoList_corpsUUID);

	// 功能是否可用 1:可用，0：不可用
	int _simpleCorpsInfo_corpsFuncInfoList_available = readInteger();
	//end
	_simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].setAvailable (_simpleCorpsInfo_corpsFuncInfoList_available);
	}
	//end
	_simpleCorpsInfo.setCorpsFuncInfoList (_simpleCorpsInfo_corpsFuncInfoList);



		this.simpleCorpsInfo = _simpleCorpsInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	long simpleCorpsInfo_corpsId = simpleCorpsInfo.getCorpsId ();

	// 军团ID
	writeLong(simpleCorpsInfo_corpsId);

	String simpleCorpsInfo_name = simpleCorpsInfo.getName ();

	// 军团名称
	writeString(simpleCorpsInfo_name);

	int simpleCorpsInfo_level = simpleCorpsInfo.getLevel ();

	// 军团级别
	writeInteger(simpleCorpsInfo_level);

	String simpleCorpsInfo_presidentName = simpleCorpsInfo.getPresidentName ();

	// 团长名称
	writeString(simpleCorpsInfo_presidentName);

	long simpleCorpsInfo_presidentId = simpleCorpsInfo.getPresidentId ();

	// 团长ID
	writeLong(simpleCorpsInfo_presidentId);

	int simpleCorpsInfo_presidentTplId = simpleCorpsInfo.getPresidentTplId ();

	// 团长模板Id
	writeInteger(simpleCorpsInfo_presidentTplId);

	int simpleCorpsInfo_presidentLevel = simpleCorpsInfo.getPresidentLevel ();

	// 团长等级
	writeInteger(simpleCorpsInfo_presidentLevel);

	int simpleCorpsInfo_currMemNum = simpleCorpsInfo.getCurrMemNum ();

	// 当前成员数量
	writeInteger(simpleCorpsInfo_currMemNum);

	int simpleCorpsInfo_maxMemNum = simpleCorpsInfo.getMaxMemNum ();

	// 最大成员数量
	writeInteger(simpleCorpsInfo_maxMemNum);

	int simpleCorpsInfo_country = simpleCorpsInfo.getCountry ();

	// 所属国家
	writeInteger(simpleCorpsInfo_country);

	String simpleCorpsInfo_qq = simpleCorpsInfo.getQq ();

	// 军团QQ
	writeString(simpleCorpsInfo_qq);

	String simpleCorpsInfo_notice = simpleCorpsInfo.getNotice ();

	// 公告
	writeString(simpleCorpsInfo_notice);

	int simpleCorpsInfo_rank = simpleCorpsInfo.getRank ();

	// 军团排名
	writeInteger(simpleCorpsInfo_rank);

	int simpleCorpsInfo_isApplied = simpleCorpsInfo.getIsApplied ();

	// 是否已经申请 1是 0否
	writeInteger(simpleCorpsInfo_isApplied);

	com.imop.lj.common.model.corps.CorpsFuncInfo[] simpleCorpsInfo_corpsFuncInfoList = simpleCorpsInfo.getCorpsFuncInfoList ();

	// 军团功能列表
	writeShort(simpleCorpsInfo_corpsFuncInfoList.length);
	int simpleCorpsInfo_corpsFuncInfoListIndex = 0;
	int simpleCorpsInfo_corpsFuncInfoListSize = simpleCorpsInfo_corpsFuncInfoList.length;
	for(simpleCorpsInfo_corpsFuncInfoListIndex=0; simpleCorpsInfo_corpsFuncInfoListIndex<simpleCorpsInfo_corpsFuncInfoListSize; simpleCorpsInfo_corpsFuncInfoListIndex++){

	String simpleCorpsInfo_corpsFuncInfoList_title = simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].getTitle();

	// 功能标题
	writeString(simpleCorpsInfo_corpsFuncInfoList_title);

	String simpleCorpsInfo_corpsFuncInfoList_desc = simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].getDesc();

	// 附加描述
	writeString(simpleCorpsInfo_corpsFuncInfoList_desc);

	int simpleCorpsInfo_corpsFuncInfoList_funcId = simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].getFuncId();

	// 功能类型ID
	writeInteger(simpleCorpsInfo_corpsFuncInfoList_funcId);

	long simpleCorpsInfo_corpsFuncInfoList_corpsUUID = simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].getCorpsUUID();

	// 军团ID
	writeLong(simpleCorpsInfo_corpsFuncInfoList_corpsUUID);

	int simpleCorpsInfo_corpsFuncInfoList_available = simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex].getAvailable();

	// 功能是否可用 1:可用，0：不可用
	writeInteger(simpleCorpsInfo_corpsFuncInfoList_available);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_UPDATE_SINGLE_CORPS;
	}
	
	@Override
	public String getTypeName() {
		return "GC_UPDATE_SINGLE_CORPS";
	}

	public com.imop.lj.common.model.corps.SimpleCorpsInfo getSimpleCorpsInfo(){
		return simpleCorpsInfo;
	}
		
	public void setSimpleCorpsInfo(com.imop.lj.common.model.corps.SimpleCorpsInfo simpleCorpsInfo){
		this.simpleCorpsInfo = simpleCorpsInfo;
	}
}