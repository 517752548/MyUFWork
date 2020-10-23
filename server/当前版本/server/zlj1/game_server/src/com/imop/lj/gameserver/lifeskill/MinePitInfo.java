package com.imop.lj.gameserver.lifeskill;

public class MinePitInfo {

	private Integer id;
	private Integer mineTypeId;
	private Integer miningTypeId;
	private String minerName;
	private Long minerId;
	private Integer minerTplId;
	private Long endTime;
	
	
	
	public MinePitInfo(Integer id, Integer mineTypeId, Integer miningTypeId,
			String minerName, Long minerId, Integer minerTplId, Long endTime) {
		super();
		this.id = id;
		this.mineTypeId = mineTypeId;
		this.miningTypeId = miningTypeId;
		this.minerName = minerName;
		this.minerId = minerId;
		this.minerTplId = minerTplId;
		this.endTime = endTime;
	}
	public MinePitInfo() {
		super();
	}
	public Integer getId() {
		return id;
	}
	public void setId(Integer id) {
		this.id = id;
	}
	public Integer getMineTypeId() {
		return mineTypeId;
	}
	public void setMineTypeId(Integer mineTypeId) {
		this.mineTypeId = mineTypeId;
	}
	public Integer getMiningTypeId() {
		return miningTypeId;
	}
	public void setMiningTypeId(Integer miningTypeId) {
		this.miningTypeId = miningTypeId;
	}
	public String getMinerName() {
		return minerName;
	}
	public void setMinerName(String minerName) {
		this.minerName = minerName;
	}
	public Integer getMinerTplId() {
		return minerTplId;
	}
	public void setMinerTplId(Integer minerTplId) {
		this.minerTplId = minerTplId;
	}
	public Long getEndTime() {
		return endTime;
	}
	public void setEndTime(Long endTime) {
		this.endTime = endTime;
	}
	public Long getMinerId() {
		return minerId;
	}
	public void setMinerId(Long minerId) {
		this.minerId = minerId;
	}
	
	
}
