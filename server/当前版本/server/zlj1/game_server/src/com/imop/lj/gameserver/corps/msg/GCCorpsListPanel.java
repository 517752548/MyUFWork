package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 军团列表面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsListPanel extends GCMessage{
	
	/** 当前页数 */
	private int currPage;
	/** 总数页数 */
	private int maxPageNum;
	/** 军团信息列表 */
	private com.imop.lj.common.model.corps.SimpleCorpsInfo[] simpleCorpsInfos;
	/** 军团列表功能列表 */
	private com.imop.lj.common.model.corps.CorpsFuncInfo[] corpsListPanelFuncInfoList;

	public GCCorpsListPanel (){
	}
	
	public GCCorpsListPanel (
			int currPage,
			int maxPageNum,
			com.imop.lj.common.model.corps.SimpleCorpsInfo[] simpleCorpsInfos,
			com.imop.lj.common.model.corps.CorpsFuncInfo[] corpsListPanelFuncInfoList ){
			this.currPage = currPage;
			this.maxPageNum = maxPageNum;
			this.simpleCorpsInfos = simpleCorpsInfos;
			this.corpsListPanelFuncInfoList = corpsListPanelFuncInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 当前页数
	int _currPage = readInteger();
	//end


	// 总数页数
	int _maxPageNum = readInteger();
	//end


	// 军团信息列表
	int simpleCorpsInfosSize = readUnsignedShort();
	com.imop.lj.common.model.corps.SimpleCorpsInfo[] _simpleCorpsInfos = new com.imop.lj.common.model.corps.SimpleCorpsInfo[simpleCorpsInfosSize];
	int simpleCorpsInfosIndex = 0;
	for(simpleCorpsInfosIndex=0; simpleCorpsInfosIndex<simpleCorpsInfosSize; simpleCorpsInfosIndex++){
		_simpleCorpsInfos[simpleCorpsInfosIndex] = new com.imop.lj.common.model.corps.SimpleCorpsInfo();
	// 军团ID
	long _simpleCorpsInfos_corpsId = readLong();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setCorpsId (_simpleCorpsInfos_corpsId);

	// 军团名称
	String _simpleCorpsInfos_name = readString();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setName (_simpleCorpsInfos_name);

	// 军团级别
	int _simpleCorpsInfos_level = readInteger();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setLevel (_simpleCorpsInfos_level);

	// 团长名称
	String _simpleCorpsInfos_presidentName = readString();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setPresidentName (_simpleCorpsInfos_presidentName);

	// 团长ID
	long _simpleCorpsInfos_presidentId = readLong();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setPresidentId (_simpleCorpsInfos_presidentId);

	// 团长模板Id
	int _simpleCorpsInfos_presidentTplId = readInteger();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setPresidentTplId (_simpleCorpsInfos_presidentTplId);

	// 团长等级
	int _simpleCorpsInfos_presidentLevel = readInteger();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setPresidentLevel (_simpleCorpsInfos_presidentLevel);

	// 当前成员数量
	int _simpleCorpsInfos_currMemNum = readInteger();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setCurrMemNum (_simpleCorpsInfos_currMemNum);

	// 最大成员数量
	int _simpleCorpsInfos_maxMemNum = readInteger();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setMaxMemNum (_simpleCorpsInfos_maxMemNum);

	// 所属国家
	int _simpleCorpsInfos_country = readInteger();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setCountry (_simpleCorpsInfos_country);

	// 军团QQ
	String _simpleCorpsInfos_qq = readString();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setQq (_simpleCorpsInfos_qq);

	// 公告
	String _simpleCorpsInfos_notice = readString();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setNotice (_simpleCorpsInfos_notice);

	// 军团排名
	int _simpleCorpsInfos_rank = readInteger();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setRank (_simpleCorpsInfos_rank);

	// 是否已经申请 1是 0否
	int _simpleCorpsInfos_isApplied = readInteger();
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setIsApplied (_simpleCorpsInfos_isApplied);

	// 军团功能列表
	int simpleCorpsInfos_corpsFuncInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsFuncInfo[] _simpleCorpsInfos_corpsFuncInfoList = new com.imop.lj.common.model.corps.CorpsFuncInfo[simpleCorpsInfos_corpsFuncInfoListSize];
	int simpleCorpsInfos_corpsFuncInfoListIndex = 0;
	for(simpleCorpsInfos_corpsFuncInfoListIndex=0; simpleCorpsInfos_corpsFuncInfoListIndex<simpleCorpsInfos_corpsFuncInfoListSize; simpleCorpsInfos_corpsFuncInfoListIndex++){
		_simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex] = new com.imop.lj.common.model.corps.CorpsFuncInfo();
	// 功能标题
	String _simpleCorpsInfos_corpsFuncInfoList_title = readString();
	//end
	_simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].setTitle (_simpleCorpsInfos_corpsFuncInfoList_title);

	// 附加描述
	String _simpleCorpsInfos_corpsFuncInfoList_desc = readString();
	//end
	_simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].setDesc (_simpleCorpsInfos_corpsFuncInfoList_desc);

	// 功能类型ID
	int _simpleCorpsInfos_corpsFuncInfoList_funcId = readInteger();
	//end
	_simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].setFuncId (_simpleCorpsInfos_corpsFuncInfoList_funcId);

	// 军团ID
	long _simpleCorpsInfos_corpsFuncInfoList_corpsUUID = readLong();
	//end
	_simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].setCorpsUUID (_simpleCorpsInfos_corpsFuncInfoList_corpsUUID);

	// 功能是否可用 1:可用，0：不可用
	int _simpleCorpsInfos_corpsFuncInfoList_available = readInteger();
	//end
	_simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].setAvailable (_simpleCorpsInfos_corpsFuncInfoList_available);
	}
	//end
	_simpleCorpsInfos[simpleCorpsInfosIndex].setCorpsFuncInfoList (_simpleCorpsInfos_corpsFuncInfoList);
	}
	//end


	// 军团列表功能列表
	int corpsListPanelFuncInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsFuncInfo[] _corpsListPanelFuncInfoList = new com.imop.lj.common.model.corps.CorpsFuncInfo[corpsListPanelFuncInfoListSize];
	int corpsListPanelFuncInfoListIndex = 0;
	for(corpsListPanelFuncInfoListIndex=0; corpsListPanelFuncInfoListIndex<corpsListPanelFuncInfoListSize; corpsListPanelFuncInfoListIndex++){
		_corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex] = new com.imop.lj.common.model.corps.CorpsFuncInfo();
	// 功能标题
	String _corpsListPanelFuncInfoList_title = readString();
	//end
	_corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].setTitle (_corpsListPanelFuncInfoList_title);

	// 附加描述
	String _corpsListPanelFuncInfoList_desc = readString();
	//end
	_corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].setDesc (_corpsListPanelFuncInfoList_desc);

	// 功能类型ID
	int _corpsListPanelFuncInfoList_funcId = readInteger();
	//end
	_corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].setFuncId (_corpsListPanelFuncInfoList_funcId);

	// 军团ID
	long _corpsListPanelFuncInfoList_corpsUUID = readLong();
	//end
	_corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].setCorpsUUID (_corpsListPanelFuncInfoList_corpsUUID);

	// 功能是否可用 1:可用，0：不可用
	int _corpsListPanelFuncInfoList_available = readInteger();
	//end
	_corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].setAvailable (_corpsListPanelFuncInfoList_available);
	}
	//end



		this.currPage = _currPage;
		this.maxPageNum = _maxPageNum;
		this.simpleCorpsInfos = _simpleCorpsInfos;
		this.corpsListPanelFuncInfoList = _corpsListPanelFuncInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 当前页数
	writeInteger(currPage);


	// 总数页数
	writeInteger(maxPageNum);


	// 军团信息列表
	writeShort(simpleCorpsInfos.length);
	int simpleCorpsInfosIndex = 0;
	int simpleCorpsInfosSize = simpleCorpsInfos.length;
	for(simpleCorpsInfosIndex=0; simpleCorpsInfosIndex<simpleCorpsInfosSize; simpleCorpsInfosIndex++){

	long simpleCorpsInfos_corpsId = simpleCorpsInfos[simpleCorpsInfosIndex].getCorpsId();

	// 军团ID
	writeLong(simpleCorpsInfos_corpsId);

	String simpleCorpsInfos_name = simpleCorpsInfos[simpleCorpsInfosIndex].getName();

	// 军团名称
	writeString(simpleCorpsInfos_name);

	int simpleCorpsInfos_level = simpleCorpsInfos[simpleCorpsInfosIndex].getLevel();

	// 军团级别
	writeInteger(simpleCorpsInfos_level);

	String simpleCorpsInfos_presidentName = simpleCorpsInfos[simpleCorpsInfosIndex].getPresidentName();

	// 团长名称
	writeString(simpleCorpsInfos_presidentName);

	long simpleCorpsInfos_presidentId = simpleCorpsInfos[simpleCorpsInfosIndex].getPresidentId();

	// 团长ID
	writeLong(simpleCorpsInfos_presidentId);

	int simpleCorpsInfos_presidentTplId = simpleCorpsInfos[simpleCorpsInfosIndex].getPresidentTplId();

	// 团长模板Id
	writeInteger(simpleCorpsInfos_presidentTplId);

	int simpleCorpsInfos_presidentLevel = simpleCorpsInfos[simpleCorpsInfosIndex].getPresidentLevel();

	// 团长等级
	writeInteger(simpleCorpsInfos_presidentLevel);

	int simpleCorpsInfos_currMemNum = simpleCorpsInfos[simpleCorpsInfosIndex].getCurrMemNum();

	// 当前成员数量
	writeInteger(simpleCorpsInfos_currMemNum);

	int simpleCorpsInfos_maxMemNum = simpleCorpsInfos[simpleCorpsInfosIndex].getMaxMemNum();

	// 最大成员数量
	writeInteger(simpleCorpsInfos_maxMemNum);

	int simpleCorpsInfos_country = simpleCorpsInfos[simpleCorpsInfosIndex].getCountry();

	// 所属国家
	writeInteger(simpleCorpsInfos_country);

	String simpleCorpsInfos_qq = simpleCorpsInfos[simpleCorpsInfosIndex].getQq();

	// 军团QQ
	writeString(simpleCorpsInfos_qq);

	String simpleCorpsInfos_notice = simpleCorpsInfos[simpleCorpsInfosIndex].getNotice();

	// 公告
	writeString(simpleCorpsInfos_notice);

	int simpleCorpsInfos_rank = simpleCorpsInfos[simpleCorpsInfosIndex].getRank();

	// 军团排名
	writeInteger(simpleCorpsInfos_rank);

	int simpleCorpsInfos_isApplied = simpleCorpsInfos[simpleCorpsInfosIndex].getIsApplied();

	// 是否已经申请 1是 0否
	writeInteger(simpleCorpsInfos_isApplied);

	com.imop.lj.common.model.corps.CorpsFuncInfo[] simpleCorpsInfos_corpsFuncInfoList = simpleCorpsInfos[simpleCorpsInfosIndex].getCorpsFuncInfoList();

	// 军团功能列表
	writeShort(simpleCorpsInfos_corpsFuncInfoList.length);
	int simpleCorpsInfos_corpsFuncInfoListIndex = 0;
	int simpleCorpsInfos_corpsFuncInfoListSize = simpleCorpsInfos_corpsFuncInfoList.length;
	for(simpleCorpsInfos_corpsFuncInfoListIndex=0; simpleCorpsInfos_corpsFuncInfoListIndex<simpleCorpsInfos_corpsFuncInfoListSize; simpleCorpsInfos_corpsFuncInfoListIndex++){

	String simpleCorpsInfos_corpsFuncInfoList_title = simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].getTitle();

	// 功能标题
	writeString(simpleCorpsInfos_corpsFuncInfoList_title);

	String simpleCorpsInfos_corpsFuncInfoList_desc = simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].getDesc();

	// 附加描述
	writeString(simpleCorpsInfos_corpsFuncInfoList_desc);

	int simpleCorpsInfos_corpsFuncInfoList_funcId = simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].getFuncId();

	// 功能类型ID
	writeInteger(simpleCorpsInfos_corpsFuncInfoList_funcId);

	long simpleCorpsInfos_corpsFuncInfoList_corpsUUID = simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].getCorpsUUID();

	// 军团ID
	writeLong(simpleCorpsInfos_corpsFuncInfoList_corpsUUID);

	int simpleCorpsInfos_corpsFuncInfoList_available = simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex].getAvailable();

	// 功能是否可用 1:可用，0：不可用
	writeInteger(simpleCorpsInfos_corpsFuncInfoList_available);
	}
	//end
	}
	//end


	// 军团列表功能列表
	writeShort(corpsListPanelFuncInfoList.length);
	int corpsListPanelFuncInfoListIndex = 0;
	int corpsListPanelFuncInfoListSize = corpsListPanelFuncInfoList.length;
	for(corpsListPanelFuncInfoListIndex=0; corpsListPanelFuncInfoListIndex<corpsListPanelFuncInfoListSize; corpsListPanelFuncInfoListIndex++){

	String corpsListPanelFuncInfoList_title = corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].getTitle();

	// 功能标题
	writeString(corpsListPanelFuncInfoList_title);

	String corpsListPanelFuncInfoList_desc = corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].getDesc();

	// 附加描述
	writeString(corpsListPanelFuncInfoList_desc);

	int corpsListPanelFuncInfoList_funcId = corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].getFuncId();

	// 功能类型ID
	writeInteger(corpsListPanelFuncInfoList_funcId);

	long corpsListPanelFuncInfoList_corpsUUID = corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].getCorpsUUID();

	// 军团ID
	writeLong(corpsListPanelFuncInfoList_corpsUUID);

	int corpsListPanelFuncInfoList_available = corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex].getAvailable();

	// 功能是否可用 1:可用，0：不可用
	writeInteger(corpsListPanelFuncInfoList_available);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPS_LIST_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPS_LIST_PANEL";
	}

	public int getCurrPage(){
		return currPage;
	}
		
	public void setCurrPage(int currPage){
		this.currPage = currPage;
	}

	public int getMaxPageNum(){
		return maxPageNum;
	}
		
	public void setMaxPageNum(int maxPageNum){
		this.maxPageNum = maxPageNum;
	}

	public com.imop.lj.common.model.corps.SimpleCorpsInfo[] getSimpleCorpsInfos(){
		return simpleCorpsInfos;
	}

	public void setSimpleCorpsInfos(com.imop.lj.common.model.corps.SimpleCorpsInfo[] simpleCorpsInfos){
		this.simpleCorpsInfos = simpleCorpsInfos;
	}	

	public com.imop.lj.common.model.corps.CorpsFuncInfo[] getCorpsListPanelFuncInfoList(){
		return corpsListPanelFuncInfoList;
	}

	public void setCorpsListPanelFuncInfoList(com.imop.lj.common.model.corps.CorpsFuncInfo[] corpsListPanelFuncInfoList){
		this.corpsListPanelFuncInfoList = corpsListPanelFuncInfoList;
	}	
}