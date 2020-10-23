package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PubExpLog extends BaseLog{

	//增加经验
    private long addExp;
	//当前级别
    private int pubLevel;
	//当前经验
    private long pubExp;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(addExp);
		list.add(pubLevel);
		list.add(pubExp);
		return list;
	}
	
	public long getAddExp() {
		return addExp;
	}
	public int getPubLevel() {
		return pubLevel;
	}
	public long getPubExp() {
		return pubExp;
	}
        
	public void setAddExp(long addExp) {
		this.addExp = addExp;
	}
	public void setPubLevel(int pubLevel) {
		this.pubLevel = pubLevel;
	}
	public void setPubExp(long pubExp) {
		this.pubExp = pubExp;
	}

}