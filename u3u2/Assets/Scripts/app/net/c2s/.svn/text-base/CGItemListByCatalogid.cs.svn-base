using System;
using System.IO;
namespace app.net
{

/**
 * 根据标签ID获取物品列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGItemListByCatalogid :BaseMessage
{
	
	/** 标签ID */
	private int catalogId;
	
	public CGItemListByCatalogid ()
	{
	}
	
	public CGItemListByCatalogid (
			int catalogId )
	{
			this.catalogId = catalogId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 标签ID
	WriteInt(catalogId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ITEM_LIST_BY_CATALOGID;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}