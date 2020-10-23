package com.imop.lj.gm.model.log;

import java.util.List;

public class MateriaSynthesisLog extends BaseLog {

    private String sourceUUId;
    private String targetUUId;
    private String targetNum;
    private String costBond;
    private String costMaterial;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(this.sourceUUId);
		list.add(this.targetUUId);
		list.add(this.targetNum);
		list.add(this.costBond);
		list.add(this.costMaterial);
		return list;
	}

	public String getSourceUUId() {
		return sourceUUId;
	}

	public void setSourceUUId(String sourceUUId) {
		this.sourceUUId = sourceUUId;
	}

	public String getTargetUUId() {
		return targetUUId;
	}

	public void setTargetUUId(String targetUUId) {
		this.targetUUId = targetUUId;
	}

	public String getTargetNum() {
		return targetNum;
	}

	public void setTargetNum(String targetNum) {
		this.targetNum = targetNum;
	}

	public String getCostBond() {
		return costBond;
	}

	public void setCostBond(String costBond) {
		this.costBond = costBond;
	}

	public String getCostMaterial() {
		return costMaterial;
	}

	public void setCostMaterial(String costMaterial) {
		this.costMaterial = costMaterial;
	}


}
