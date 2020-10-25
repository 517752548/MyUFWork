package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 仙葫排行数据
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCXianhuRankList extends GCMessage{
	
	/** 排行类型 */
	private int rankType;
	/** 我的排名 */
	private int myRank;
	/** 我的开启次数 */
	private int myNum;
	/** 我的军团Id */
	private long myCorpsId;
	/** 我的军团名字 */
	private String myCorpsName;
	/** 仙葫排行榜信息 */
	private com.imop.lj.common.model.XianhuRankInfo[] xianhuRankInfoList;

	public GCXianhuRankList (){
	}
	
	public GCXianhuRankList (
			int rankType,
			int myRank,
			int myNum,
			long myCorpsId,
			String myCorpsName,
			com.imop.lj.common.model.XianhuRankInfo[] xianhuRankInfoList ){
			this.rankType = rankType;
			this.myRank = myRank;
			this.myNum = myNum;
			this.myCorpsId = myCorpsId;
			this.myCorpsName = myCorpsName;
			this.xianhuRankInfoList = xianhuRankInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 排行类型
	int _rankType = readInteger();
	//end


	// 我的排名
	int _myRank = readInteger();
	//end


	// 我的开启次数
	int _myNum = readInteger();
	//end


	// 我的军团Id
	long _myCorpsId = readLong();
	//end


	// 我的军团名字
	String _myCorpsName = readString();
	//end


	// 仙葫排行榜信息
	int xianhuRankInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.XianhuRankInfo[] _xianhuRankInfoList = new com.imop.lj.common.model.XianhuRankInfo[xianhuRankInfoListSize];
	int xianhuRankInfoListIndex = 0;
	for(xianhuRankInfoListIndex=0; xianhuRankInfoListIndex<xianhuRankInfoListSize; xianhuRankInfoListIndex++){
		_xianhuRankInfoList[xianhuRankInfoListIndex] = new com.imop.lj.common.model.XianhuRankInfo();
	// 玩家ID
	long _xianhuRankInfoList_roleId = readLong();
	//end
	_xianhuRankInfoList[xianhuRankInfoListIndex].setRoleId (_xianhuRankInfoList_roleId);

	// 玩家姓名
	String _xianhuRankInfoList_name = readString();
	//end
	_xianhuRankInfoList[xianhuRankInfoListIndex].setName (_xianhuRankInfoList_name);

	// 排名
	int _xianhuRankInfoList_rank = readInteger();
	//end
	_xianhuRankInfoList[xianhuRankInfoListIndex].setRank (_xianhuRankInfoList_rank);

	// 级别
	int _xianhuRankInfoList_level = readInteger();
	//end
	_xianhuRankInfoList[xianhuRankInfoListIndex].setLevel (_xianhuRankInfoList_level);

	// 玩家模板Id
	int _xianhuRankInfoList_tplId = readInteger();
	//end
	_xianhuRankInfoList[xianhuRankInfoListIndex].setTplId (_xianhuRankInfoList_tplId);

	// 帮派ID
	long _xianhuRankInfoList_corpsId = readLong();
	//end
	_xianhuRankInfoList[xianhuRankInfoListIndex].setCorpsId (_xianhuRankInfoList_corpsId);

	// 帮派名称
	String _xianhuRankInfoList_corpsName = readString();
	//end
	_xianhuRankInfoList[xianhuRankInfoListIndex].setCorpsName (_xianhuRankInfoList_corpsName);

	// 开启次数
	int _xianhuRankInfoList_num = readInteger();
	//end
	_xianhuRankInfoList[xianhuRankInfoListIndex].setNum (_xianhuRankInfoList_num);
	}
	//end



		this.rankType = _rankType;
		this.myRank = _myRank;
		this.myNum = _myNum;
		this.myCorpsId = _myCorpsId;
		this.myCorpsName = _myCorpsName;
		this.xianhuRankInfoList = _xianhuRankInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 排行类型
	writeInteger(rankType);


	// 我的排名
	writeInteger(myRank);


	// 我的开启次数
	writeInteger(myNum);


	// 我的军团Id
	writeLong(myCorpsId);


	// 我的军团名字
	writeString(myCorpsName);


	// 仙葫排行榜信息
	writeShort(xianhuRankInfoList.length);
	int xianhuRankInfoListIndex = 0;
	int xianhuRankInfoListSize = xianhuRankInfoList.length;
	for(xianhuRankInfoListIndex=0; xianhuRankInfoListIndex<xianhuRankInfoListSize; xianhuRankInfoListIndex++){

	long xianhuRankInfoList_roleId = xianhuRankInfoList[xianhuRankInfoListIndex].getRoleId();

	// 玩家ID
	writeLong(xianhuRankInfoList_roleId);

	String xianhuRankInfoList_name = xianhuRankInfoList[xianhuRankInfoListIndex].getName();

	// 玩家姓名
	writeString(xianhuRankInfoList_name);

	int xianhuRankInfoList_rank = xianhuRankInfoList[xianhuRankInfoListIndex].getRank();

	// 排名
	writeInteger(xianhuRankInfoList_rank);

	int xianhuRankInfoList_level = xianhuRankInfoList[xianhuRankInfoListIndex].getLevel();

	// 级别
	writeInteger(xianhuRankInfoList_level);

	int xianhuRankInfoList_tplId = xianhuRankInfoList[xianhuRankInfoListIndex].getTplId();

	// 玩家模板Id
	writeInteger(xianhuRankInfoList_tplId);

	long xianhuRankInfoList_corpsId = xianhuRankInfoList[xianhuRankInfoListIndex].getCorpsId();

	// 帮派ID
	writeLong(xianhuRankInfoList_corpsId);

	String xianhuRankInfoList_corpsName = xianhuRankInfoList[xianhuRankInfoListIndex].getCorpsName();

	// 帮派名称
	writeString(xianhuRankInfoList_corpsName);

	int xianhuRankInfoList_num = xianhuRankInfoList[xianhuRankInfoListIndex].getNum();

	// 开启次数
	writeInteger(xianhuRankInfoList_num);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_XIANHU_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_XIANHU_RANK_LIST";
	}

	public int getRankType(){
		return rankType;
	}
		
	public void setRankType(int rankType){
		this.rankType = rankType;
	}

	public int getMyRank(){
		return myRank;
	}
		
	public void setMyRank(int myRank){
		this.myRank = myRank;
	}

	public int getMyNum(){
		return myNum;
	}
		
	public void setMyNum(int myNum){
		this.myNum = myNum;
	}

	public long getMyCorpsId(){
		return myCorpsId;
	}
		
	public void setMyCorpsId(long myCorpsId){
		this.myCorpsId = myCorpsId;
	}

	public String getMyCorpsName(){
		return myCorpsName;
	}
		
	public void setMyCorpsName(String myCorpsName){
		this.myCorpsName = myCorpsName;
	}

	public com.imop.lj.common.model.XianhuRankInfo[] getXianhuRankInfoList(){
		return xianhuRankInfoList;
	}

	public void setXianhuRankInfoList(com.imop.lj.common.model.XianhuRankInfo[] xianhuRankInfoList){
		this.xianhuRankInfoList = xianhuRankInfoList;
	}	
}