package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class CommoditySellLog extends BaseLog{

	//出售商品详细信息
    private String sellInfo;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(sellInfo);
		return list;
	}
	
	public String getSellInfo() {
		return sellInfo;
	}
        
	public void setSellInfo(String sellInfo) {
		this.sellInfo = sellInfo;
	}

}