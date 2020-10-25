package com.imop.lj.gameserver.cache.template;

import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.exchange.template.ExchangeTemplate;

public class ExchangeTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	
	/** Map<花费货币类型Id,<要兑换的货币类型Id,比例关系>>*/
	private Map<Integer, Map<Integer, Integer>> exchangeMap = Maps.newHashMap();
	
	public ExchangeTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}
	
	@Override
	public void init() {
		initExchangeMap();
	}

	private void initExchangeMap() {
		for(ExchangeTemplate tpl : templateService.getAll(ExchangeTemplate.class).values()){
			int costId = tpl.getCostId();
			Map<Integer, Integer> map = exchangeMap.get(costId);
			if(map == null){
				map = Maps.newHashMap();
				exchangeMap.put(costId,	map);
			}
			map.put(tpl.getExchangeId(), tpl.getScale());
		}
	}
	
	public int getScale(int costId, int exchangeId){
		if(exchangeMap.containsKey(costId)){
			if(exchangeMap.get(costId) != null){
				return exchangeMap.get(costId).get(exchangeId);
			}
		}
		
		return 0;
	}
	
}