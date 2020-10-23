package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class CorpsBuildLog extends BaseLog{

	//帮派ID
    private long corpsId;
	//帮派名
    private String corpsName;
	//帮派等级
    private int corpsLevel;
	//帮派人数
    private int memberNum;
	//帮派当前经验
    private long currExp;
	//帮派当前资金
    private long curFund;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(corpsId);
		list.add(corpsName);
		list.add(corpsLevel);
		list.add(memberNum);
		list.add(currExp);
		list.add(curFund);
		return list;
	}
	
	public long getCorpsId() {
		return corpsId;
	}
	public String getCorpsName() {
		return corpsName;
	}
	public int getCorpsLevel() {
		return corpsLevel;
	}
	public int getMemberNum() {
		return memberNum;
	}
	public long getCurrExp() {
		return currExp;
	}
	public long getCurFund() {
		return curFund;
	}
        
	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}
	public void setCorpsName(String corpsName) {
		this.corpsName = corpsName;
	}
	public void setCorpsLevel(int corpsLevel) {
		this.corpsLevel = corpsLevel;
	}
	public void setMemberNum(int memberNum) {
		this.memberNum = memberNum;
	}
	public void setCurrExp(long currExp) {
		this.currExp = currExp;
	}
	public void setCurFund(long curFund) {
		this.curFund = curFund;
	}

}