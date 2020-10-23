package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class WingLog extends BaseLog{

	//模版ID
    private int tempId;
	//翅膀阶数
    private int wingLevel;
	//翅膀祝福值
    private int wingBless;
	//翅膀战斗力
    private int wingPower;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(tempId);
		list.add(wingLevel);
		list.add(wingBless);
		list.add(wingPower);
		return list;
	}
	
	public int getTempId() {
		return tempId;
	}
	public int getWingLevel() {
		return wingLevel;
	}
	public int getWingBless() {
		return wingBless;
	}
	public int getWingPower() {
		return wingPower;
	}
        
	public void setTempId(int tempId) {
		this.tempId = tempId;
	}
	public void setWingLevel(int wingLevel) {
		this.wingLevel = wingLevel;
	}
	public void setWingBless(int wingBless) {
		this.wingBless = wingBless;
	}
	public void setWingPower(int wingPower) {
		this.wingPower = wingPower;
	}

}