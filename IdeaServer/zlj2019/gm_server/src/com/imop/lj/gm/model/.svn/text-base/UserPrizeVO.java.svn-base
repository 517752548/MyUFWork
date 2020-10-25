package com.imop.lj.gm.model;

import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Transient;

import com.imop.lj.db.model.UserPrize;
import com.imop.lj.gm.utils.StringUtil;

/**
 * GM补偿实体类:GM补偿实体
 *
 *
 */
@Entity
@Table(name = "t_user_prize")
public class UserPrizeVO {

	/** 主键 */
	private UserPrize userPrize;

	public UserPrize getUserPrize() {
		return userPrize;
	}

	public void setUserPrize(UserPrize userPrize) {
		this.userPrize = userPrize;
	}

	@Transient
	public String getFormatCoin() {
		return StringUtil.disInfo(userPrize.getCoin(), 1);
	}

	@Transient
	public String getFormatItem() {
		return StringUtil.disInfo(userPrize.getItem(), 2);
	}

}
