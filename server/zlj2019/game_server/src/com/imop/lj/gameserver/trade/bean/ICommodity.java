package com.imop.lj.gameserver.trade.bean;

import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.trade.ITradable;
import com.imop.lj.gameserver.trade.TradeDef.CommodityType;
import com.imop.lj.gameserver.trade.search.SimpleSearchInfo;
public interface ICommodity<T> {
	/** 得到商品的id*/
	public String getCommodityId();
	
	/** 转换成交易用的Json*/
	public String toCommodityJson();
	
	/** 从交易用的Json中初始化*/
	public void loadFromCommodityJson(String str);
	
	/** 得到交易类型*/
	public CommodityType getCommodityType();
	
	/** 得到模板类型*/
	public Integer getBaseTemplateId();
	
	/** 得到模板类型*/
	public TemplateObject getTemplateObject();
	
	/** 得到上架费用类型*/
	public Currency getListingFeeType();
	
	/** 得到上架费用*/
	public Integer getListingFeeNum();
	
	/**是否满足参数条件*/
	public boolean isMatch();
	
	/**得到商品叠加数*/
	public Integer getOverLap();
	
	/**初始化特殊参数 有嵌套关系的，需要类初始化完毕之后才能初始化或修改的属性*/
	public boolean initSpecialParam(ITradable<?> trade);
	
	/**是否满足参数条件(简单查询)*/
	public boolean isMatch(SimpleSearchInfo ssi);
	
	/**得到商品评分*/
	public Integer getScore();
	
	/** 判断售价是不是在范围内*/
	public boolean inTheRange(Currency c, Integer price);
	
	/** 转换成交易用的Json*/
	public String toCommodityJsonForTradeInfo();
	
	/** 设置参加交易的商品数量*/
	public void setCommodityOverLap(Integer overlap);
	
	public String getName();
	
}
