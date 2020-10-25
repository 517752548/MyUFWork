package com.imop.lj.gm.model;

import java.util.Date;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.WorldGiftEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午1:05:38
 * @version 1.0
 */

public class WorldGiftVO extends BaseVO {

	private int id;
	private int giftId;
	private String giftName;
	private String giftParams;
	private Date createTime;
	
	public WorldGiftVO() {
		
	}
	
	public WorldGiftVO(WorldGiftEntity entity) {
		init(entity);
	}
	
	public void init(WorldGiftEntity entity) {
		this.id = entity.getId();
		this.giftId = entity.getGiftId();
		this.giftName = entity.getGiftName();
		this.giftParams = entity.getGiftParams();
		this.createTime = new Date( entity.getCreateTime());
	}
	
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getGiftId() {
		return giftId;
	}

	public void setGiftId(int giftId) {
		this.giftId = giftId;
	}

	public String getGiftName() {
		return giftName;
	}

	public void setGiftName(String giftName) {
		this.giftName = giftName;
	}

	public String getGiftParams() {
		return giftParams;
	}

	public void setGiftParams(String giftParams) {
		this.giftParams = giftParams;
	}

	public Date getCreateTime() {
		return createTime;
	}

	public void setCreateTime(Date createTime) {
		this.createTime = createTime;
	}
	
	@Override
	public String toString( ) {
		return  "id = " + this.id
				+ "giftId = " + this.giftId
				+ ", giftName = " + this.giftName 
				+ ", giftParams = " + this.giftParams 
				+ ", createTime = " + TimeUtils.formatYMDHMSTime(createTime.getTime())
 				;
	}

//	@Transient
//	public String getFormatCoin() {
//		return StringUtil.disInfo(prize.getCoin(), 1);
//	}
//
//	@Transient
//	public String getFormatItem() {
//		return StringUtil.disInfo(prize.getItem(), 2);
//	}
}
