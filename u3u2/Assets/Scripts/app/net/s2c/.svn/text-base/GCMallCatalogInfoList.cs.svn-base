
using System;
namespace app.net
{
/**
 * 返回商城标签列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMallCatalogInfoList :BaseMessage
{
	/** 商城标签列表 */
	private MallCatalogInfoData[] mallCatalogInfoList;

	public GCMallCatalogInfoList ()
	{
	}

	protected override void ReadImpl()
	{

	// 商城标签列表
	int mallCatalogInfoListSize = ReadShort();
	MallCatalogInfoData[] _mallCatalogInfoList = new MallCatalogInfoData[mallCatalogInfoListSize];
	int mallCatalogInfoListIndex = 0;
	MallCatalogInfoData _mallCatalogInfoListTmp = null;
	for(mallCatalogInfoListIndex=0; mallCatalogInfoListIndex<mallCatalogInfoListSize; mallCatalogInfoListIndex++){
		_mallCatalogInfoListTmp = new MallCatalogInfoData();
		_mallCatalogInfoList[mallCatalogInfoListIndex] = _mallCatalogInfoListTmp;
	// 标签ID
	int _mallCatalogInfoList_catalogId = ReadInt();	_mallCatalogInfoListTmp.catalogId = _mallCatalogInfoList_catalogId;
		// 标签名称
	string _mallCatalogInfoList_name = ReadString();	_mallCatalogInfoListTmp.name = _mallCatalogInfoList_name;
		// 标签类型；0：热卖列表; 1:限购列表; 2:金币列表
	int _mallCatalogInfoList_catalogType = ReadInt();	_mallCatalogInfoListTmp.catalogType = _mallCatalogInfoList_catalogType;
		}
	//end



		this.mallCatalogInfoList = _mallCatalogInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MALL_CATALOG_INFO_LIST;
	}
	
	public override string getEventType()
	{
		return MallGCHandler.GCMallCatalogInfoListEvent;
	}
	

	public MallCatalogInfoData[] getMallCatalogInfoList(){
		return mallCatalogInfoList;
	}


}
}