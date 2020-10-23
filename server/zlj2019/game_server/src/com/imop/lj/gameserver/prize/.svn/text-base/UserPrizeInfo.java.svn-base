package com.imop.lj.gameserver.prize;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.db.model.UserPrize;


/**
 * 玩家奖励的基本信息，奖励ID和奖励名
 * 
 * 
 * 
 */
public class UserPrizeInfo {
	/** 奖励Id */
	private String prizeId;
	/** 奖励名 */
	private String prizeName;
	/**平台奖励唯一编号 */
	private int uniqueId;

	/** 奖励类型  1 平台奖励还是 0 gm奖励  */
	private int prizeType;
	
	/**过期时间*/
	private long expireTime;
	public UserPrizeInfo()
	{
		
	}
	
	private UserPrizeInfo(String prizeId, String prizeName,int uniqueId,int prizeType, long expireTime) {
		this.prizeId = prizeId;
		this.prizeName = prizeName;
		this.uniqueId=uniqueId;
		this.prizeType=prizeType;
		this.expireTime = expireTime;
	}

	public static List<UserPrizeInfo> getFromUserPrizes(
			List<UserPrize> userPrizes) {
		List<UserPrizeInfo> _basicInfos = new ArrayList<UserPrizeInfo>();
		if (userPrizes == null) {
			return _basicInfos;
		}

		for (UserPrize _userPrize : userPrizes) {
			UserPrizeInfo _info = new UserPrizeInfo(String.valueOf(_userPrize.getId()),	_userPrize.getUserPrizeName(),0,0, _userPrize.getExpireTime().getTime());
					
			_basicInfos.add(_info);
		}

		return _basicInfos;
	}
	public static List<UserPrizeInfo> getFromPlatformPrizeHolders(
			List<PlatformPrizeHolder> userPrizes) {
		List<UserPrizeInfo> _basicInfos = new ArrayList<UserPrizeInfo>();
		if (userPrizes == null) {
			return _basicInfos;
		}

		for (PlatformPrizeHolder _userPrize : userPrizes) {
			UserPrizeInfo _info = new UserPrizeInfo(_userPrize.getPrizeId() + "", _userPrize.getPrizeName(),_userPrize.getUniqueId(), 1 , 0);
			_info.setPrizeType(PrizeDef.PRIZE_TYPE_PLATFORM);
			_basicInfos.add(_info);
		}

		return _basicInfos;
	}
	public String getPrizeId() {
		return prizeId;
	}

	public void setPrizeId(String prizeId) {
		this.prizeId = prizeId;
	}

	public String getPrizeName() {
		return prizeName;
	}

	public void setPrizeName(String prizeName) {
		this.prizeName = prizeName;
	}

	public int getUniqueId() {
		return uniqueId;
	}

	public int getPrizeType() {
		return prizeType;
	}

	public void setUniqueId(int uniqueId) {
		this.uniqueId = uniqueId;
	}

	public void setPrizeType(int prizeType) {
		this.prizeType = prizeType;
	}

	public long getExpireTime() {
		return expireTime;
	}

	public void setExpireTime(long expireTime) {
		this.expireTime = expireTime;
	}
}
