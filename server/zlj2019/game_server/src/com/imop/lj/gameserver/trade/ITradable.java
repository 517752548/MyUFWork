package com.imop.lj.gameserver.trade;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.trade.bean.ICommodity;
public interface ITradable<T>{
	
	public static final Human tradeOwner = new Human();
	
	/**转化为商品*/
	public ICommodity<T> toCommodity();
	
	/**从卖家移除商品*/
	boolean removeCommodityFromSeller(Integer commodityNum);
	
	/**通过商品pojo初始化*/
	public void initByCommodity(ICommodity<?> commodity);
}
