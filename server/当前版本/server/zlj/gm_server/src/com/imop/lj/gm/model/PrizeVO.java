package com.imop.lj.gm.model;

import javax.persistence.Transient;

import com.imop.lj.gm.utils.StringUtil;
import com.imop.lj.db.model.PrizeInfo;


/**
 * GM发奖礼包VO
 *
 */
public class PrizeVO {

	private PrizeInfo prize;


	public PrizeInfo getPrize() {
		return prize;
	}

	public void setPrize(PrizeInfo prize) {
		this.prize = prize;
	}

	@Transient
	public String getFormatCoin() {
		return StringUtil.disInfo(prize.getCoin(), 1);
	}

	@Transient
	public String getFormatItem() {
		return StringUtil.disInfo(prize.getItem(), 2);
	}

	@Transient
	public String getFormatPet() {
		return StringUtil.disInfo(prize.getPet(), 3);
	}
}
