package com.renren.games.api.db.po;

import java.sql.Timestamp;

import com.renren.games.api.annotation.Comment;
import com.renren.games.api.db.PersistanceObject;
import com.renren.games.api.db.model.QQTaskMarketEntity;

public class QQTaskMarket implements PersistanceObject<String, QQTaskMarketEntity> {

	@Comment(content = "appid+openid")
	private String id;

	@Comment(content = "openid")
	private String openid;

	@Comment(content = "appid")
	private String appid;

	@Comment(content = "appid")
	private String contractid;

	@Comment(content = "创建时间")
	private Timestamp createTime;

	@Comment(content = "步骤1状态：0为未完成，1完成 奖励未生成，2完成 奖励生成 未领取，3完成 奖励生成 已经领取")
	private int step1Status;

	@Comment(content = "更新状态1时间")
	private Timestamp step1UpdateTime;

	@Comment(content = "步骤1领取礼包id")
	private String step1PayItem;

	@Comment(content = "步骤1订单id")
	private String step1Billno;

	@Comment(content = "步骤2状态：0为未完成，1完成 奖励未生成，2完成 奖励生成 未领取，3完成 奖励生成 已经领取")
	private int step2Status;

	@Comment(content = "更新状态2时间")
	private Timestamp step2UpdateTime;

	@Comment(content = "步骤2领取礼包id")
	private String step2PayItem;

	@Comment(content = "步骤2订单id")
	private String step2Billno;

	@Comment(content = "步骤3状态：0为未完成，1完成 奖励未生成，2完成 奖励生成 未领取，3完成 奖励生成 已经领取")
	private int step3Status;

	@Comment(content = "更新状态3时间")
	private Timestamp step3UpdateTime;

	@Comment(content = "步骤3领取礼包id")
	private String step3PayItem;

	@Comment(content = "步骤3订单id")
	private String step3Billno;

	@Comment(content = "步骤4状态：0为未完成，1完成 奖励未生成，2完成 奖励生成 未领取，3完成 奖励生成 已经领取")
	private int step4Status;

	@Comment(content = "更新状态4时间")
	private Timestamp step4UpdateTime;

	@Comment(content = "步骤4领取礼包id")
	private String step4PayItem;

	@Comment(content = "步骤4订单id")
	private String step4Billno;

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getOpenid() {
		return openid;
	}

	public void setOpenid(String openid) {
		this.openid = openid;
	}

	public String getAppid() {
		return appid;
	}

	public void setAppid(String appid) {
		this.appid = appid;
	}

	public String getContractid() {
		return contractid;
	}

	public void setContractid(String contractid) {
		this.contractid = contractid;
	}

	public Timestamp getCreateTime() {
		return createTime;
	}

	public void setCreateTime(Timestamp createTime) {
		this.createTime = createTime;
	}

	public int getStep1Status() {
		return step1Status;
	}

	public void setStep1Status(int step1Status) {
		this.step1Status = step1Status;
	}

	public Timestamp getStep1UpdateTime() {
		return step1UpdateTime;
	}

	public void setStep1UpdateTime(Timestamp step1UpdateTime) {
		this.step1UpdateTime = step1UpdateTime;
	}

	public String getStep1PayItem() {
		return step1PayItem;
	}

	public void setStep1PayItem(String step1PayItem) {
		this.step1PayItem = step1PayItem;
	}

	public String getStep1Billno() {
		return step1Billno;
	}

	public void setStep1Billno(String step1Billno) {
		this.step1Billno = step1Billno;
	}

	public int getStep2Status() {
		return step2Status;
	}

	public void setStep2Status(int step2Status) {
		this.step2Status = step2Status;
	}

	public Timestamp getStep2UpdateTime() {
		return step2UpdateTime;
	}

	public void setStep2UpdateTime(Timestamp step2UpdateTime) {
		this.step2UpdateTime = step2UpdateTime;
	}

	public String getStep2PayItem() {
		return step2PayItem;
	}

	public void setStep2PayItem(String step2PayItem) {
		this.step2PayItem = step2PayItem;
	}

	public String getStep2Billno() {
		return step2Billno;
	}

	public void setStep2Billno(String step2Billno) {
		this.step2Billno = step2Billno;
	}

	public int getStep3Status() {
		return step3Status;
	}

	public void setStep3Status(int step3Status) {
		this.step3Status = step3Status;
	}

	public Timestamp getStep3UpdateTime() {
		return step3UpdateTime;
	}

	public void setStep3UpdateTime(Timestamp step3UpdateTime) {
		this.step3UpdateTime = step3UpdateTime;
	}

	public String getStep3PayItem() {
		return step3PayItem;
	}

	public void setStep3PayItem(String step3PayItem) {
		this.step3PayItem = step3PayItem;
	}

	public String getStep3Billno() {
		return step3Billno;
	}

	public void setStep3Billno(String step3Billno) {
		this.step3Billno = step3Billno;
	}

	public int getStep4Status() {
		return step4Status;
	}

	public void setStep4Status(int step4Status) {
		this.step4Status = step4Status;
	}

	public Timestamp getStep4UpdateTime() {
		return step4UpdateTime;
	}

	public void setStep4UpdateTime(Timestamp step4UpdateTime) {
		this.step4UpdateTime = step4UpdateTime;
	}

	public String getStep4PayItem() {
		return step4PayItem;
	}

	public void setStep4PayItem(String step4PayItem) {
		this.step4PayItem = step4PayItem;
	}

	public String getStep4Billno() {
		return step4Billno;
	}

	public void setStep4Billno(String step4Billno) {
		this.step4Billno = step4Billno;
	}

	@Override
	public QQTaskMarketEntity toEntity() {
		QQTaskMarketEntity entity = new QQTaskMarketEntity();
		entity.setId(this.id);
		entity.setAppid(this.appid);
		entity.setContractid(this.contractid);
		entity.setCreateTime(this.createTime);
		entity.setOpenid(this.openid);

		entity.setStep1Billno(this.step1Billno);
		entity.setStep1PayItem(this.step1PayItem);
		entity.setStep1Status(this.step1Status);
		entity.setStep1UpdateTime(this.step1UpdateTime);

		entity.setStep2Billno(this.step2Billno);
		entity.setStep2PayItem(this.step2PayItem);
		entity.setStep2Status(this.step2Status);
		entity.setStep2UpdateTime(this.step2UpdateTime);

		entity.setStep3Billno(this.step3Billno);
		entity.setStep3PayItem(this.step3PayItem);
		entity.setStep3Status(this.step3Status);
		entity.setStep3UpdateTime(this.step3UpdateTime);

		entity.setStep4Billno(this.step4Billno);
		entity.setStep4PayItem(this.step4PayItem);
		entity.setStep4Status(this.step4Status);
		entity.setStep4UpdateTime(this.step4UpdateTime);
		return null;
	}

	@Override
	public void fromEntity(QQTaskMarketEntity entity) {
		this.id = entity.getId();
		this.appid = entity.getAppid();
		this.contractid = entity.getContractid();
		this.createTime = entity.getCreateTime();
		this.openid = entity.getOpenid();

		this.step1Billno = entity.getStep1Billno();
		this.step1PayItem = entity.getStep1PayItem();
		this.step1Status = entity.getStep1Status();
		this.step1UpdateTime = entity.getStep1UpdateTime();

		this.step2Billno = entity.getStep2Billno();
		this.step2PayItem = entity.getStep2PayItem();
		this.step2Status = entity.getStep2Status();
		this.step2UpdateTime = entity.getStep2UpdateTime();

		this.step3Billno = entity.getStep3Billno();
		this.step3PayItem = entity.getStep3PayItem();
		this.step3Status = entity.getStep3Status();
		this.step3UpdateTime = entity.getStep3UpdateTime();

		this.step4Billno = entity.getStep4Billno();
		this.step4PayItem = entity.getStep4PayItem();
		this.step4Status = entity.getStep4Status();
		this.step4UpdateTime = entity.getStep4UpdateTime();
	}

	@Override
	public String toString() {
		return "QQTaskMarket [id=" + id + ", openid=" + openid + ", appid=" + appid + ", contractid=" + contractid + ", createTime=" + createTime
				+ ", step1Status=" + step1Status + ", step1UpdateTime=" + step1UpdateTime + ", step1PayItem=" + step1PayItem + ", step1Billno="
				+ step1Billno + ", step2Status=" + step2Status + ", step2UpdateTime=" + step2UpdateTime + ", step2PayItem=" + step2PayItem
				+ ", step2Billno=" + step2Billno + ", step3Status=" + step3Status + ", step3UpdateTime=" + step3UpdateTime + ", step3PayItem="
				+ step3PayItem + ", step3Billno=" + step3Billno + ", step4Status=" + step4Status + ", step4UpdateTime=" + step4UpdateTime
				+ ", step4PayItem=" + step4PayItem + ", step4Billno=" + step4Billno + "]";
	}
}
