package com.imop.lj.gm.model.log;

import java.util.List;

public class HeritageLog extends BaseLog {
    private long fromSeretaryUuid; //传承秘书uuid
    private long toSeretaryUuid;   //被传承秘书uuid
    private String result;  //详细原因
    private int oprationgType; //普通0  vip1
	public long getFromSeretaryUuid() {
		return fromSeretaryUuid;
	}
	public void setFromSeretaryUuid(long fromSeretaryUuid) {
		this.fromSeretaryUuid = fromSeretaryUuid;
	}
	public long getToSeretaryUuid() {
		return toSeretaryUuid;
	}
	public void setToSeretaryUuid(long toSeretaryUuid) {
		this.toSeretaryUuid = toSeretaryUuid;
	}
	public String getResult() {
		return result;
	}
	public void setResult(String result) {
		this.result = result;
	}
	public int getOprationgType() {
		return oprationgType;
	}
	public void setOprationgType(int oprationgType) {
		this.oprationgType = oprationgType;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(fromSeretaryUuid);
		list.add(toSeretaryUuid);
		list.add(result);
		list.add(oprationgType);
		return list;
	}
}
