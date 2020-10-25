package com.imop.lj.gameserver.cd;

import net.sf.json.JSONArray;

import com.imop.lj.gameserver.common.Globals;

/**
 * 冷却队列对象
 *
 * @author haijiang.jin
 *
 */
public class CdQueue {
	/** 队列类型 */
	private CdTypeEnum cdType;
	/** 图标 */
	private String icon;
	/** 队列名称 */
	private String name;
	/** 索引位置 */
	private int index;
	/** 开始时间 */
	private long startTime;
	/** 结束时间 */
	private long endTime;
	/** 上次操作时间 */
	private long lastOpTime;
	/** 操作次数 */
	private int opCount;
	/** 增加队列所需金币 */
	private int addNeedGold;
	/** 清除 Cd 间隔时间 */
	private long killCdSpaceTime;
	/** 清除 Cd 所需金币 */
	private int killCdNeedGold;
	/** 冷却时间阈值 */
	private long cdTimeThreshold;
	/** 是否已经开启 */
	private boolean opened;
	/** 冷却队列信息 */
	private CdQueueInfo cdQueueInfo;

	/**
	 * 类默认构造器
	 *
	 */
	public CdQueue() {
		this.cdQueueInfo = new CdQueueInfo();
	}

	/**
	 * 类参数构造器
	 *
	 * @param cdType 冷却类型
	 * @param cdTimeThreshold 冷却时间阈值
	 */
	public CdQueue(CdTypeEnum cdType, long cdTimeThreshold) {
		this();

		this.cdType = cdType;
		this.cdTimeThreshold = cdTimeThreshold;
	}

	/**
	 * 获取队列类型
	 *
	 * @return
	 */
	public CdTypeEnum getCdType() {
		return this.cdType;
	}

	/**
	 * 设置队列类型
	 *
	 * @param value
	 */
	public void setCdType(CdTypeEnum value) {
		this.cdType = value;
	}

	/**
	 * 获取图标
	 *
	 * @return
	 */
	public String getIcon() {
		return this.icon;
	}

	/**
	 * 设置图标
	 *
	 * @param value
	 */
	public void setIcon(String value) {
		this.icon = value;
	}

	/**
	 * 获取名称
	 *
	 * @return
	 */
	public String getName() {
		return this.name;
	}

	/**
	 * 设置名称
	 *
	 * @param value
	 */
	public void setName(String value) {
		this.name = value;
	}

	/**
	 * 获取索引位置
	 *
	 * @return
	 */
	public int getIndex() {
		return this.index;
	}

	/**
	 * 设置索引位置
	 *
	 * @param value
	 */
	public void setIndex(int value) {
		this.index = value;
	}

	/**
	 * 获取开始时间
	 *
	 * @return
	 */
	public long getStartTime() {
		return this.startTime;
	}

	/**
	 * 获取结束时间
	 *
	 * @return
	 */
	public long getEndTime() {
		return this.endTime;
	}

	/**
	 * 获取上次操作时间
	 *
	 * @return
	 */
	public long getLastOpTime() {
		return this.lastOpTime;
	}

	/**
	 * 设置上次操作时间
	 *
	 * @param value
	 */
	public void setLastOpTime(long value) {
		this.lastOpTime = value;
	}

	/**
	 * 获取操作次数
	 *
	 * @return
	 */
	public int getOpCount() {
		return this.opCount;
	}

	/**
	 * 设置操作次数
	 *
	 * @param value
	 */
	public void setOpCount(int value) {
		this.opCount = value;
	}

	/**
	 * 增加操作次数
	 *
	 * @param value
	 */
	public void addOpCount(int value) {
		this.opCount += value;
	}

	/**
	 * 获取增加队列所需金币
	 *
	 * @return
	 */
	public int getAddNeedGold() {
		return this.addNeedGold;
	}

	/**
	 * 设置增加队列所需金币
	 *
	 * @param value
	 */
	public void setAddNeedGold(int value) {
		this.addNeedGold = value;
	}

	/**
	 * 获取清除 Cd 间隔时间
	 *
	 * @return
	 */
	public long getKillCdSpaceTime() {
		return this.killCdSpaceTime;
	}

	/**
	 * 设置清除 Cd 间隔时间
	 *
	 * @param value
	 */
	public void setKillCdSpaceTime(long value) {
		this.killCdSpaceTime = value;
	}

	/**
	 * 获取清除 Cd 所需金币
	 *
	 * @return
	 */
	public int getKillCdNeedGold() {
		return killCdNeedGold;
	}

	/**
	 * 设置清除 Cd 所需金币
	 *
	 * @param value
	 */
	public void setKillCdNeedGold(int value) {
		this.killCdNeedGold = value;
	}

	/**
	 * 设置开始时间和结束时间
	 *
	 * @param startTime
	 * @param endTime
	 */
	public void setTimes(long startTime, long endTime) {
		if (startTime > endTime) {
			throw new IllegalArgumentException("startTime > endTime");
		}

		this.startTime = startTime;
		this.endTime = endTime;
	}

	/**
	 * 获取冷却时间阈值, 单位毫秒
	 *
	 * @return
	 */
	public long getCdTimeThreshold() {
		return this.cdTimeThreshold;
	}

	/**
	 * 设置冷却时间阈值, 单位毫秒
	 *
	 * @param value
	 */
	public void setCdTimeThreshold(long value) {
		this.cdTimeThreshold = value;
	}

	/**
	 * 是否可以继续累计时间
	 *
	 * @return
	 */
	public boolean canAddTime() {
		if (!this.opened) {
			return false;
		}

//		java.sql.Timestamp timestamp = new Timestamp(this.endTime);
//		System.out.println(timestamp);
		if (this.endTime < Globals.getTimeService().now()) {
			// 如果冷却队列结束时间小于当前时间,
			// 则说明该队列已经彻底冷却, 可以继续累计时间
			return true;
		}

		if ((this.endTime - this.startTime) < this.getCdTimeThreshold()) {
			// 如果开始时间和结束时间的时间差
			// 小于冷却时间阈值,
			// 那么说明该冷却队列还可以继续累计时间
			return true;
		}

		return false;
	}

	/**
	 * 是否已开启当前冷却队列
	 *
	 * @return
	 */
	public boolean isOpened() {
		return this.opened;
	}

	/**
	 * 开启或关闭冷却队列
	 *
	 * @param value
	 */
	public void setOpened(boolean value) {
		this.opened = value;
	}

	/**
	 * 获取当前时间与结束时间的时间差, 单位: 毫秒.
	 * <br>
	 * 如果冷却队列的结束时间小于当前时间, 则返回 0
	 *
	 * @return
	 */
	public long getCurrTimeDiff() {
		// 获取当前时间
		long currTime = Globals.getTimeService().now();

		if (this.endTime < currTime) {
			return 0;
		} else {
			return this.endTime - currTime;
		}
	}

	/**
	 * 获取清除时间所需金币
	 *
	 * @return
	 */
	public int getKillCurrTimeNeedGold() {
		// 获取当前时间差
		long currTimeDiff = this.getCurrTimeDiff();

		if (currTimeDiff <= 0) {
			// 如果队列已经彻底冷却,
			// 则直接退出
			return 0;
		}

		// 获取单位时间
		double unitTimes = (float)currTimeDiff / (float)this.getKillCdSpaceTime();
		// 向上取整
		unitTimes = (int)Math.ceil(unitTimes);
		if(unitTimes == 0 ){
			unitTimes = 1;
		}

		// 计算所需金币
		return this.getKillCdNeedGold() * (int)unitTimes;
	}

	/**
	 * 将当前对象转换为 JSON 字符串
	 *
	 * @return
	 */
	public String toJsonStr() {
		JSONArray jsonArr = new JSONArray();

		jsonArr.add(this.getCdType().getIndex());
		jsonArr.add(this.getIndex());
		jsonArr.add(this.isOpened() ? 1 : 0);
		jsonArr.add(this.getStartTime());
		jsonArr.add(this.getEndTime());
		jsonArr.add(this.getCdTimeThreshold());
		jsonArr.add(this.getLastOpTime());
		jsonArr.add(this.getOpCount());

		return jsonArr.toString();
	}

	/**
	 * 从 JSON 中还原对象
	 *
	 * @param json
	 */
	public void fromJsonStr(String jsonStr) {
		if (jsonStr == null ||
			jsonStr.isEmpty()) {
			return;
		}

		JSONArray jsonArr = JSONArray.fromObject(jsonStr);

		int i = 0;

		this.setCdType(CdTypeEnum.valueOf(jsonArr.getInt(i++)));
		this.setIndex(jsonArr.getInt(i++));
		this.setOpened(jsonArr.getInt(i++) == 1);
		this.setTimes(jsonArr.getLong(i++), jsonArr.getLong(i++));
		this.setCdTimeThreshold(jsonArr.getLong(i++));
		this.setLastOpTime(jsonArr.getLong(i++));
		this.setOpCount(jsonArr.getInt(i++));
	}

	/**
	 * 获取冷却队列信息
	 *
	 * @return
	 */
	public CdQueueInfo getCdQueueInfo() {
		this.cdQueueInfo.setCdTypeInt(this.getCdType() == null ? 0 : this.getCdType().getIndex());
		this.cdQueueInfo.setIndex(this.getIndex());
		this.cdQueueInfo.setName(this.getName());
		this.cdQueueInfo.setCurrTimeDiff((int)this.getCurrTimeDiff());
		this.cdQueueInfo.setOpened(this.isOpened());
		this.cdQueueInfo.setCanAddTime(this.canAddTime());
		this.cdQueueInfo.setIcon(this.icon);
		return this.cdQueueInfo;
	}
}
