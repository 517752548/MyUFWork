package com.imop.lj.gm.model.log;

import java.util.List;

public class CommerceLog extends BaseLog{
	private long commerceId;// 商会ID
	private String commerceName;// 商会名
	private int commerceLevel;// 商会等级
	private int commerceSymbolLevel;// 商会会徽等级
	private int memberNums;// 商会人数
	private int status;// 商会状态
	private String result; //详细操作
	private long commerceMemberRoleId;// 被操作者玩家id
	private String memberName;//被操作者玩家名称
	private int oprationgType;//操作类型
	public long getCommerceId() {
		return commerceId;
	}
	public void setCommerceId(long commerceId) {
		this.commerceId = commerceId;
	}
	public String getCommerceName() {
		return commerceName;
	}
	public void setCommerceName(String commerceName) {
		this.commerceName = commerceName;
	}
	public int getCommerceLevel() {
		return commerceLevel;
	}
	public void setCommerceLevel(int commerceLevel) {
		this.commerceLevel = commerceLevel;
	}
	public int getCommerceSymbolLevel() {
		return commerceSymbolLevel;
	}
	public void setCommerceSymbolLevel(int commerceSymbolLevel) {
		this.commerceSymbolLevel = commerceSymbolLevel;
	}
	public int getMemberNums() {
		return memberNums;
	}
	public void setMemberNums(int memberNums) {
		this.memberNums = memberNums;
	}
	public int getStatus() {
		return status;
	}
	public void setStatus(int status) {
		this.status = status;
	}
	public String getResult() {
		return result;
	}
	public void setResult(String result) {
		this.result = result;
	}
	public long getCommerceMemberRoleId() {
		return commerceMemberRoleId;
	}
	public void setCommerceMemberRoleId(long commerceMemberRoleId) {
		this.commerceMemberRoleId = commerceMemberRoleId;
	}
	public String getMemberName() {
		return memberName;
	}
	public void setMemberName(String memberName) {
		this.memberName = memberName;
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
		list.add(commerceId);
		list.add(commerceName);
		list.add(commerceLevel);
//		list.add(commerceSymbolLevel);
		list.add(memberNums);
		list.add(status);
		list.add(result);
		list.add(commerceMemberRoleId);
		list.add(memberName);
		list.add(oprationgType);
		return list;
	}
}
