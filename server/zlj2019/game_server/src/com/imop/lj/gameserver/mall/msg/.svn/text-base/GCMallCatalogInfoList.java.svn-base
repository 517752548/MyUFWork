package com.imop.lj.gameserver.mall.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回商城标签列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMallCatalogInfoList extends GCMessage{
	
	/** 商城标签列表 */
	private com.imop.lj.common.model.mall.MallCatalogInfo[] mallCatalogInfoList;

	public GCMallCatalogInfoList (){
	}
	
	public GCMallCatalogInfoList (
			com.imop.lj.common.model.mall.MallCatalogInfo[] mallCatalogInfoList ){
			this.mallCatalogInfoList = mallCatalogInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 商城标签列表
	int mallCatalogInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.mall.MallCatalogInfo[] _mallCatalogInfoList = new com.imop.lj.common.model.mall.MallCatalogInfo[mallCatalogInfoListSize];
	int mallCatalogInfoListIndex = 0;
	for(mallCatalogInfoListIndex=0; mallCatalogInfoListIndex<mallCatalogInfoListSize; mallCatalogInfoListIndex++){
		_mallCatalogInfoList[mallCatalogInfoListIndex] = new com.imop.lj.common.model.mall.MallCatalogInfo();
	// 标签ID
	int _mallCatalogInfoList_catalogId = readInteger();
	//end
	_mallCatalogInfoList[mallCatalogInfoListIndex].setCatalogId (_mallCatalogInfoList_catalogId);

	// 标签名称
	String _mallCatalogInfoList_name = readString();
	//end
	_mallCatalogInfoList[mallCatalogInfoListIndex].setName (_mallCatalogInfoList_name);

	// 标签类型；0：热卖列表; 1:限购列表; 2:金币列表
	int _mallCatalogInfoList_catalogType = readInteger();
	//end
	_mallCatalogInfoList[mallCatalogInfoListIndex].setCatalogType (_mallCatalogInfoList_catalogType);
	}
	//end



		this.mallCatalogInfoList = _mallCatalogInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 商城标签列表
	writeShort(mallCatalogInfoList.length);
	int mallCatalogInfoListIndex = 0;
	int mallCatalogInfoListSize = mallCatalogInfoList.length;
	for(mallCatalogInfoListIndex=0; mallCatalogInfoListIndex<mallCatalogInfoListSize; mallCatalogInfoListIndex++){

	int mallCatalogInfoList_catalogId = mallCatalogInfoList[mallCatalogInfoListIndex].getCatalogId();

	// 标签ID
	writeInteger(mallCatalogInfoList_catalogId);

	String mallCatalogInfoList_name = mallCatalogInfoList[mallCatalogInfoListIndex].getName();

	// 标签名称
	writeString(mallCatalogInfoList_name);

	int mallCatalogInfoList_catalogType = mallCatalogInfoList[mallCatalogInfoListIndex].getCatalogType();

	// 标签类型；0：热卖列表; 1:限购列表; 2:金币列表
	writeInteger(mallCatalogInfoList_catalogType);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MALL_CATALOG_INFO_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MALL_CATALOG_INFO_LIST";
	}

	public com.imop.lj.common.model.mall.MallCatalogInfo[] getMallCatalogInfoList(){
		return mallCatalogInfoList;
	}

	public void setMallCatalogInfoList(com.imop.lj.common.model.mall.MallCatalogInfo[] mallCatalogInfoList){
		this.mallCatalogInfoList = mallCatalogInfoList;
	}	
}