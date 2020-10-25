package com.imop.lj.gameserver.goodactivity.useractivity;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityUserPO;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;

/**
 * 玩家活动对象
 * @author yu.zhao
 *
 */
public abstract class AbstractUserGoodActivity {
	/** 玩家Id */
	private long charId;
	
	/** 活动对象引用 */
	private AbstractGoodActivity activity;
	
	/** 玩家活动数据逻辑模型 */
	private AbstractGoodActivityUserDataModel userDataModel;
	
	/** 玩家活动数据存储对象，可能为null */
	private GoodActivityUserPO goodActivityUserPO;
	
	public AbstractUserGoodActivity(long charId, AbstractGoodActivity activity) {
		this.charId = charId;
		this.activity = activity;
		this.userDataModel = buildUserDataModel();
	}
	
	/**
	 * 构建玩家数据模型对象，子类实现
	 * @return
	 */
	protected abstract AbstractGoodActivityUserDataModel buildUserDataModel();
	
	/**
	 * 获取玩家Id
	 * @return
	 */
	public long getCharId() {
		return charId;
	}
	
	/**
	 * 获取玩家数据模型对象
	 * @return
	 */
	public AbstractGoodActivityUserDataModel getUserDataModel() {
		return userDataModel;
	}

	public AbstractGoodActivity getGoodActivity() {
		return activity;
	}
	
	public GoodActivityUserPO getGoodActivityUserPO() {
		return goodActivityUserPO;
	}

	public void setGoodActivityUserPO(GoodActivityUserPO goodActivityUserPO) {
		this.goodActivityUserPO = goodActivityUserPO;
	}
	
	public void onDelete() {
		this.goodActivityUserPO.onDelete();
	}
	
	@Override
	public String toString() {
		return "AbstractUserGoodActivity [charId=" + charId + ", activityId="
				+ activity.getId() + ", userDataModel=" + userDataModel
				+ ", goodActivityUserPO=" + goodActivityUserPO + "]";
	}
	
}
