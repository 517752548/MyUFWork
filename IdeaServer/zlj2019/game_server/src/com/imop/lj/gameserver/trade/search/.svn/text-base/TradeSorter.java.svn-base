package com.imop.lj.gameserver.trade.search;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.gameserver.trade.Trade;
import com.imop.lj.gameserver.trade.TradeDef.TradeOrderType;
import com.imop.lj.gameserver.trade.TradeDef.TradeSortableFieldType;

public class TradeSorter {
	
	public static Map<TradeSortableFieldType,Map<TradeOrderType,Comparator<Trade>>> map = Maps.newHashMap();
	
	public static boolean sortTrade(List<Trade> list,TradeSortableFieldType fieldId,TradeOrderType order){
		if(map == null || map.isEmpty()){
			initMap();
		}
		if(!map.containsKey(fieldId) || !map.get(fieldId).containsKey(order)){
			return false;
		}
		Collections.sort(list, map.get(fieldId).get(order));
		return true;
	}
	
	private static void initMap() {
		//价格排序
		Map<TradeOrderType,Comparator<Trade>> map_1 = Maps.newHashMap();
		map_1.put(TradeOrderType.ASC, new Comparator<Trade>() {
	        public int compare(Trade o1, Trade o2) {
	            Integer a = (Integer) o1.getCurrencyNum() * o1.getCommodityNum();
	            Integer b = (Integer) o2.getCurrencyNum() * o2.getCommodityNum();
	            // 升序
	            return a.compareTo(b);
	        }
		});
		map_1.put(TradeOrderType.DES, new Comparator<Trade>() {
	        public int compare(Trade o1, Trade o2) {
	        	Integer a = (Integer) o1.getCurrencyNum() * o1.getCommodityNum();
	            Integer b = (Integer) o2.getCurrencyNum() * o2.getCommodityNum();
	            //降序
	            return b.compareTo(a);
	        }
		});
		map.put(TradeSortableFieldType.PRICE, map_1);
		
		//装备的评分排序
		Map<TradeOrderType,Comparator<Trade>> map_2 = Maps.newHashMap();
		map_2.put(TradeOrderType.ASC, new Comparator<Trade>() {
	        public int compare(Trade o1, Trade o2) {
	            Integer a = (Integer) o1.getCommodityPojo().getScore();
	            Integer b = (Integer) o2.getCommodityPojo().getScore();
	            // 升序
	            return a.compareTo(b);
	        }
		});
		map_2.put(TradeOrderType.DES, new Comparator<Trade>() {
	        public int compare(Trade o1, Trade o2) {
	        	Integer a = (Integer) o1.getCommodityPojo().getScore();
	            Integer b = (Integer) o2.getCommodityPojo().getScore();
	            //降序
	            return b.compareTo(a);
	        }
		});
		map.put(TradeSortableFieldType.SCORE, map_2);
	}

}
