using System;
using System.IO;
namespace app.net
{

/**
 * 简单商品查询
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeSimpleSearch :BaseMessage
{
	
	/** 商品类别 */
	private int commodityType;
	/** 商品二级标签 */
	private int subTagId;
	/** 排序字段 */
	private int sortField;
	/** 1升序,2降序 */
	private int sortOrder;
	/** 装备颜色,0则显示全部 */
	private int equipColor;
	/** 装备等级 */
	private int equipLevel;
	/** 宝石等级 */
	private int gemLevel;
	/** 页数 */
	private int pageNum;
	
	public CGTradeSimpleSearch ()
	{
	}
	
	public CGTradeSimpleSearch (
			int commodityType,
			int subTagId,
			int sortField,
			int sortOrder,
			int equipColor,
			int equipLevel,
			int gemLevel,
			int pageNum )
	{
			this.commodityType = commodityType;
			this.subTagId = subTagId;
			this.sortField = sortField;
			this.sortOrder = sortOrder;
			this.equipColor = equipColor;
			this.equipLevel = equipLevel;
			this.gemLevel = gemLevel;
			this.pageNum = pageNum;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 商品类别
	WriteInt(commodityType);
	// 商品二级标签
	WriteInt(subTagId);
	// 排序字段
	WriteInt(sortField);
	// 1升序,2降序
	WriteInt(sortOrder);
	// 装备颜色,0则显示全部
	WriteInt(equipColor);
	// 装备等级
	WriteInt(equipLevel);
	// 宝石等级
	WriteInt(gemLevel);
	// 页数
	WriteInt(pageNum);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TRADE_SIMPLE_SEARCH;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}