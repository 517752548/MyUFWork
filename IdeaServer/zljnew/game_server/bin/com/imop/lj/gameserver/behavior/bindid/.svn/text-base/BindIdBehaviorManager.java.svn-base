package com.imop.lj.gameserver.behavior.bindid;

import java.util.HashMap;
import java.util.Map;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.behavior.template.BindIdBehaviorTemplate;
import com.imop.lj.gameserver.cache.service.TemplateCacheService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/**
 * 绑定Id的行为记录管理器
 * 
 */
public class BindIdBehaviorManager implements JsonPropDataHolder {
	public static int MAX_REFRESH_DAY = 30;

	/** 玩家角色 */
	private Human human = null;
	/** 行为基础数据字典 */
	private Map<BindIdBehaviorTypeEnum, BindIdBehaviorRecordBase> behaviorBaseMap;
	/** 行为数据字典 Map<行为类型，Map<行为Id， 行为记录>>*/
	private Map<BindIdBehaviorTypeEnum, Map<Long, BindIdBehaviorRecord>> behaviorMap;

	/**
	 * 类参数构造器
	 * 
	 * @param human
	 * @throws IllegalArgumentException
	 *             if human == null
	 * 
	 */
	public BindIdBehaviorManager(Human human) {
		if (human == null) {
			throw new IllegalArgumentException("human is null");
		}

		this.human = human;
		this.behaviorBaseMap = new HashMap<BindIdBehaviorTypeEnum, BindIdBehaviorRecordBase>();
		this.behaviorMap = new HashMap<BindIdBehaviorTypeEnum, Map<Long,BindIdBehaviorRecord>>();

		for (BindIdBehaviorTypeEnum behaviorType : BindIdBehaviorTypeEnum.values()) {
			// 设置行为记录字典
			this.behaviorBaseMap.put(behaviorType, new BindIdBehaviorRecordBase());
			this.behaviorMap.put(behaviorType, new HashMap<Long, BindIdBehaviorRecord>());
		}
	}

	/**
	 * 初始化
	 * 
	 * @param tempServ
	 */
	public void init(TemplateCacheService tempServ) {
		if (tempServ == null) {
			return;
		}

		// 获取行为字典
		Map<Integer, BindIdBehaviorTemplate> behavTplMap = tempServ.getAll(BindIdBehaviorTemplate.class);

		if (behavTplMap == null) {
			return;
		}

		for (BindIdBehaviorTypeEnum behaviorType : BindIdBehaviorTypeEnum.values()) {
			// 获取行为配置模版
			BindIdBehaviorTemplate behavTpl = behavTplMap.get(behaviorType.getIndex());
			// 获取行为记录
			BindIdBehaviorRecordBase brb = this.behaviorBaseMap.get(behaviorType);
			if (brb == null) {
				continue;
			}

			if (behavTpl != null) {
				// 操作次数上限
				brb.setOpCountMax(behavTpl.getOpCountMax());
				// 检查重置时间
				resetBehaviorRecord(behaviorType);
			}
		}

		this.resetBehaviorMaxOpVip();
	}
	
	/**
	 * 重置vip相关最大数，初始化行为管理器调用，及vip升级时调用，这里与相应行为类型对应。
	 */
	public void resetBehaviorMaxOpVip() {
//		int vipLevel = human.getVipLevel();
//		VipConfigTemplate vipTmp = Globals.getTemplateCacheService().get(vipLevel, VipConfigTemplate.class);
//		if (vipTmp == null) {
//			throw new IllegalArgumentException("vipLevel is not exist!!");
//		}
//		
//		// TODO 根据vip等级设置behaviorBaseMap中的最大操作次数
//		
//		// 副本购买次数
//		int raidBuyTimes = Globals.getVipService().getCountForVipTypeEnumOnOpen(human, VipTypeEnum.RAID_BUY_TIMES);
//		BindIdBehaviorRecordBase brb1 = this.behaviorBaseMap.get(BindIdBehaviorTypeEnum.RAID_BUY);
//		brb1.setOpCountMax(raidBuyTimes);
//		
//		// 过关斩将购买次数
//		int heroMissionBuyTimes = Globals.getVipService().getCountForVipTypeEnumOnOpen(human, VipTypeEnum.HERO_MISSION_BUY_TIMES);
//		BindIdBehaviorRecordBase brb2 = this.behaviorBaseMap.get(BindIdBehaviorTypeEnum.HERO_MISSION_BUY);
//		brb2.setOpCountMax(heroMissionBuyTimes);
		
	}
	
	/**
	 * 根据行为类型和行为Id获取行为记录
	 * @param behaviorType
	 * @param behaviorId
	 * @return
	 */
	private BindIdBehaviorRecord getBindIdBehaviorRecord(BindIdBehaviorTypeEnum behaviorType, long behaviorId) {
		BindIdBehaviorRecordBase brb = this.behaviorBaseMap.get(behaviorType);
		if (brb == null) {
			// 非法数据
			return null;
		}
		Map<Long, BindIdBehaviorRecord> bm = this.behaviorMap.get(behaviorType);
		if (null == bm) {
			// 非法数据
			return null;
		}
		
		BindIdBehaviorRecord br = bm.get(behaviorId);
		// 如果没有此Id的记录，则新增一条初始数据
		if (null == br) {
			br = new BindIdBehaviorRecord();
			br.setId(behaviorId);
			br.setOpCount(0);
			br.setOpAddCount(0);
			// 设置最后一次操作时间
			br.setLastOpTime(Globals.getTimeService().now());
			// 设置基础数据的引用
			br.setBehaviorRecordBase(brb);
			
			// 放入map
			bm.put(behaviorId, br);
		}
		return br;
	}
	
	/**
	 * 对某种行为类型增加操作次数
	 * 
	 * @param behaviorType
	 * @param behaviorId
	 * @return
	 */
	public boolean addOp(BindIdBehaviorTypeEnum behaviorType, int behaviorId) {
		BindIdBehaviorRecord br = getBindIdBehaviorRecord(behaviorType, behaviorId);
		if (br == null) {
			return false;
		}
		resetBehaviorRecord(behaviorType);

		int oldOpCount = br.getOpCount();
		int newOpCount = oldOpCount;
		int oldAddCount = br.getOpAddCount();

		br.setOpAddCount(br.getOpAddCount() + 1);

		int newAddCount = br.getOpAddCount();
		// 记录日志
		Globals.getLogService().sendBehaviorLog(human, LogReasons.BehaviorLogReason.ADD_OP_ADD_COUNT, "bindid", behaviorType.getIndex(), oldOpCount,
				newOpCount, oldAddCount, newAddCount);

		return true;
	}

	/**
	 * 获取操作行为次数
	 * 
	 * @param behaviorType
	 * @param behaviorId
	 * @return
	 * 
	 */
	public int getCount(BindIdBehaviorTypeEnum behaviorType, long behaviorId) {
		// 获取行为记录
		BindIdBehaviorRecord br = getBindIdBehaviorRecord(behaviorType, behaviorId);

		if (br == null) {
			return 0;
		}
		if (this.isCanRefreshBehavior(behaviorType)) {
			return 0;
		} else {
			return br.getOpCount();
		}
	}

	/**
	 * 获取最大操作行为次数（含额外增加的次数）
	 * 
	 * @param behaviorType
	 * @param behaviorId
	 * @return
	 * 
	 */
	public int getMaxCount(BindIdBehaviorTypeEnum behaviorType, long behaviorId) {
		// 获取行为记录
		BindIdBehaviorRecord br = getBindIdBehaviorRecord(behaviorType, behaviorId);
		if (null == br) {
			// 非法数据
			return 0;
		}
		BindIdBehaviorRecordBase brb = br.getBehaviorRecordBase();
		// 最大行为操作次数=基础值中的最大次数+额外增加次数
		return brb.getOpCountMax() + br.getOpAddCount();
	}
	
	/**
	 * 获取原始的最大行为次数，不包含额外增加的次数
	 * @param behaviorType
	 * @return
	 */
	public int getMaxCountRaw(BindIdBehaviorTypeEnum behaviorType) {
		// 获取行为记录
		BindIdBehaviorRecordBase brb = this.behaviorBaseMap.get(behaviorType);
		if (null == brb) {
			// 非法数据
			return 0;
		}
		return brb.getOpCountMax();
	}

	/**
	 * 获取操作行为剩余次数
	 * 
	 * @param behaviorType
	 * @param behaviorId
	 * @return
	 */
	public int getLeftCount(BindIdBehaviorTypeEnum behaviorType, long behaviorId) {
		resetBehaviorRecord(behaviorType);
		int leftCount = getMaxCount(behaviorType, behaviorId) - getCount(behaviorType, behaviorId);
		if (leftCount < 0) {
			leftCount = 0;
		}
		return leftCount;
	}

	/**
	 * 获取购买的操作行为次数
	 * 
	 * @param behaviorType
	 * @param behaviorId
	 * @return
	 * 
	 */
	public int getOpAddCount(BindIdBehaviorTypeEnum behaviorType, long behaviorId) {
		// 获取行为记录
		BindIdBehaviorRecord br = getBindIdBehaviorRecord(behaviorType, behaviorId);
		if (null == br) {
			// 非法数据
			return 0;
		}
		// 最大行为操作次数
		return br.getOpAddCount();
	}
	
	/**
	 * 是否可以重置行为操作类型
	 * 
	 * @param behaviorType
	 *            行为枚举类型
	 */
	public boolean isCanRefreshBehavior(BindIdBehaviorTypeEnum behaviorType) {
		BindIdBehaviorRecordBase brb = this.behaviorBaseMap.get(behaviorType);
		if (brb == null) {
			return false;
		}
		long resetTime = brb.getResetTime();
		// 如果该行为允许重置
		if (behaviorType.getRefreshImpl().canRefresh()) {
			// 已经过了重置时间了，需要重置
			if (resetTime <= Globals.getTimeService().now()) {
				return true;
			}
		}
		return false;
	}

	/**
	 * 重置枚举类型，根据操作时间判断重置次数
	 * 
	 * @param behaviorType
	 *            行为枚举类型
	 */
	private void resetBehaviorRecord(BindIdBehaviorTypeEnum behaviorType) {
		BindIdBehaviorRecordBase brb = this.behaviorBaseMap.get(behaviorType);
		if (brb == null) {
			return;
		}
		// 判断是否需要重置
		if (this.isCanRefreshBehavior(behaviorType)) {
			resetBehaviorNoCheck(behaviorType, false);
		}
	}
	
	/**
	 * 重新设置重置时间，并清除所有操作记录
	 * @param behaviorType
	 * @param isForce 是否强制刷新重置时间，只有gm命令的时候才能设置为true
	 */
	private void resetBehaviorNoCheck(BindIdBehaviorTypeEnum behaviorType, boolean isForce) {
		BindIdBehaviorRecordBase brb = this.behaviorBaseMap.get(behaviorType);
		if (brb == null) {
			return;
		}
		
		long resetTime = brb.getResetTime();
		if (isForce) {
			// 如果强制刷新更新时间，则设为0，这样就会重新计算
			resetTime = 0;
		}
		
		long now = Globals.getTimeService().now();
		// 修正后的重置时间
		long nextResetTime = resetTime;
		// 如果还没有重置时间，则构建初始的重置时间
		if (nextResetTime <= 0) {
			nextResetTime = behaviorType.getRefreshImpl().buildInitResetTime(behaviorType);
		}
		
		// 如果重置时间小于等于当前时间，则需要修正
		if (nextResetTime <= now) {
			long periodTime = behaviorType.getRefreshImpl().getPeriod(behaviorType);
			if (periodTime > 0) {
				// 上次重置时间距离现在差几个周期
				long count = ((now - nextResetTime) / periodTime) + 1;
				// 得到大于当前时间的最近一次重置时间
				nextResetTime = nextResetTime + periodTime * count;
			} else {
				nextResetTime = 0;
			}
		}
		// 更新重置时间
		brb.setResetTime(nextResetTime);
		
		// 重置该类型的所有行为数据
		Map<Long, BindIdBehaviorRecord> bm = this.behaviorMap.get(behaviorType);
		for (BindIdBehaviorRecord br : bm.values()) {
			br.setOpCount(0);
			br.setOpAddCount(0);
			br.setLastOpTime(now);
		}
		
		// 存库
		human.setModified();
		
		Loggers.humanLogger.info("resetBehaviorNoCheck;behaviorType="+behaviorType+";resetTime="+TimeUtils.formatYMDHMTime(resetTime)+
				";nextResetTime="+TimeUtils.formatYMDHMTime(nextResetTime)+";now="+TimeUtils.formatYMDHMTime(now) + ";isForce="+isForce);
	}
	
	/**
	 * 获取当前的重置时间
	 * @param behaviorType
	 * @return
	 */
	public long getCurResetTime(BindIdBehaviorTypeEnum behaviorType) {
		long resetTime = 0;
		BindIdBehaviorRecordBase brb = this.behaviorBaseMap.get(behaviorType);
		if (brb == null) {
			return resetTime;
		}
		resetBehaviorRecord(behaviorType);
		resetTime = brb.getResetTime();
		return resetTime;
	}
	
	/**
	 * 获取上一次的重置时间
	 * @param behaviorType
	 * @return
	 */
	public long getLastRestTime(BindIdBehaviorTypeEnum behaviorType) {
		long lastResetTime = getCurResetTime(behaviorType);
		// 大于0时才合法
		if (lastResetTime > 0) {
			// 上一周期为当前周期减去一个周期
			lastResetTime -= behaviorType.getRefreshImpl().getPeriod(behaviorType);
		}
		if (lastResetTime < 0) {
			lastResetTime = 0;
		}
		return lastResetTime;
	}
	
	/**
	 * 是否可以做指定类型的行为操作
	 * 
	 * @param bindIdBehaviorType
	 * @return
	 * 
	 */
	public boolean canDo(BindIdBehaviorTypeEnum bindIdBehaviorType, long behaviorId) {
		if (bindIdBehaviorType == null) {
			return false;
		}
		// 获取行为记录
		BindIdBehaviorRecord br = getBindIdBehaviorRecord(bindIdBehaviorType, behaviorId);
		if (br == null) {
			return false;
		}

		return this.getCount(bindIdBehaviorType, behaviorId) < (this.getMaxCount(bindIdBehaviorType, behaviorId));
	}

	/**
	 * 将指定行为类型的操作次数 +1
	 * 
	 * @param behaviorType
	 *            行为类型
	 * @return
	 * 
	 */
	public boolean doBehavior(BindIdBehaviorTypeEnum behaviorType, long behaviorId) {
		if (!this.canDo(behaviorType, behaviorId)) {
			return false;
		}

		this.resetBehaviorRecord(behaviorType);
		
		// 获取行为记录
		BindIdBehaviorRecord br = getBindIdBehaviorRecord(behaviorType, behaviorId);

		int oldOpCount = br.getOpCount();
		int oldAddCount = br.getOpAddCount();
		int newAddCount = oldAddCount;

		// 行为次数+1
		br.setOpCount(br.getOpCount() + 1);
		br.setLastOpTime(Globals.getTimeService().now());

		// 保存玩家信息
		this.human.setModified();

		int newOpCount = br.getOpCount();
		// 记录日志
		Globals.getLogService().sendBehaviorLog(human, LogReasons.BehaviorLogReason.DO_BEHAVIOR, "bindid", behaviorType.getIndex(), oldOpCount, newOpCount,
				oldAddCount, newAddCount);

		return true;
	}

	/**
	 * 序列化为 JSON 字符串
	 * 
	 * @return
	 */
	@Override
	public String toJsonProp() {
		// 行为类型列表
		BindIdBehaviorTypeEnum[] behavTypes = BindIdBehaviorTypeEnum.values();
		// JSON 数组
		JSONObject json = new JSONObject();

		for (BindIdBehaviorTypeEnum behaviorType : behavTypes) {
			if (behaviorType == BindIdBehaviorTypeEnum.UNKNOWN) {
				// 如果是未知行为类型,
				// 则直接跳过
				continue;
			}

			BindIdBehaviorRecordBase brb = this.behaviorBaseMap.get(behaviorType);
			if (null == brb) {
				continue;
			}
			// 获取行为记录
			Map<Long, BindIdBehaviorRecord> brMap = this.behaviorMap.get(behaviorType);
			if (brMap == null) {
				continue;
			}
			
			JSONArray bMapJsonArr = new JSONArray();
			// 公共数据
			bMapJsonArr.add(brb.toJson());
			
			// 将行为记录序列化为 JSON
			JSONArray brMapJsonArr = new JSONArray();
			for (BindIdBehaviorRecord br : brMap.values()) {
				String brJson = br.toJson();
				if (brJson != null) {
					brMapJsonArr.add(brJson);
				}
			}
			bMapJsonArr.add(brMapJsonArr);

			// 以行为类型作为关键字
			String key = String.valueOf(behaviorType.getIndex());
			json.put(key, bMapJsonArr);
		}
		
		return json.toString();
	}

	/**
	 * 从 JSON 字符串中反序列化
	 * 
	 * @param value
	 */
	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.equalsIgnoreCase("")) {
			return;
		}

		// 行为类型列表
		BindIdBehaviorTypeEnum[] behaviorTypes = BindIdBehaviorTypeEnum.values();
		// JSON 数组
		JSONObject json = JSONObject.fromObject(value);
		long now = Globals.getTimeService().now();
		for (BindIdBehaviorTypeEnum behaviorType : behaviorTypes) {
			// 以行为类型作为关键字
			String key = String.valueOf(behaviorType.getIndex());
			if (!json.containsKey(key)) {
				continue;
			}

			// 获取行为记录 JSON 字符串
			String brStr = json.getString(key);
			
			// 公共数据
			JSONArray bMapJsonArr = JSONArray.fromObject(brStr);
			String brbStr = bMapJsonArr.getString(0);
			if (null != brbStr) {
				BindIdBehaviorRecordBase brb = new BindIdBehaviorRecordBase();
				brb.loadJson(brbStr);
				this.behaviorBaseMap.put(behaviorType, brb);
			}
			
			// 创建行为记录
			JSONArray brMapJsonArr = bMapJsonArr.getJSONArray(1);
			if (null != brMapJsonArr && !brMapJsonArr.isEmpty()) {
				for (int i = 0; i < brMapJsonArr.size(); i++) {
					String brJsonStr = brMapJsonArr.getString(i);
					if (null != brJsonStr) {
						BindIdBehaviorRecord br = new BindIdBehaviorRecord();
						br.setBehaviorRecordBase(behaviorBaseMap.get(behaviorType));
						br.loadJson(brJsonStr);
						// 如果不是只做一次的，把30天以前的数据清掉 TODO 这里这样写不合适。。。 FIXME
						if (behaviorType.getRefreshImpl() != BindIdBehaviorImplFactory.REFRESH_ONCE_TIME &&
								br.getLastOpTime() < now - MAX_REFRESH_DAY * TimeUtils.DAY) {
							continue;
						}
						// 放入map
						this.behaviorMap.get(behaviorType).put(br.getId(), br);
					}
				}
			}
		}
	}

	/**
	 * 清除操作行为, <font color='#990000'>注意: 只能在 GM 命令类中使用!</font>
	 * 
	 * @param behaviorType
	 * 
	 */
	public void gmClear(BindIdBehaviorTypeEnum behaviorType) {
		// 清除已操作次数
		this.behaviorMap.get(behaviorType).clear();
		// 更新重置时间，因为可能QA改系统时间了
		resetBehaviorNoCheck(behaviorType, true);
		// 保存玩家信息
		this.human.setModified();
	}
	
	/**
	 * 行为基础数据类
	 * @author yu.zhao
	 *
	 */
	public class BindIdBehaviorRecordBase {
		/** 操作次数上限 */
		private int opCountMax;
		/** 重置时间的时间戳 */
		private long resetTime;
		
		private BindIdBehaviorRecordBase() {
			
		}

		public int getOpCountMax() {
			return opCountMax;
		}

		public void setOpCountMax(int opCountMax) {
			this.opCountMax = opCountMax;
		}

		public long getResetTime() {
			return resetTime;
		}

		public void setResetTime(long resetTime) {
			this.resetTime = resetTime;
		}
		
		@Override
		public String toString() {
			return "BindIdBehaviorRecordBase [opCountMax=" + opCountMax
					+ ", resetTime=" + resetTime + "]";
		}

		public String toJson() {
			JSONArray jsonArr = new JSONArray();
			jsonArr.add(getOpCountMax());
			jsonArr.add(getResetTime());
			return jsonArr.toString();
		}
		
		public void loadJson(String json) {
			if (null == json || json.equalsIgnoreCase("")) {
				return;
			}
			
			JSONArray jsonArr = JSONArray.fromObject(json);
			if (null == jsonArr || jsonArr.isEmpty()) {
				return;
			}
			
			setOpCountMax(jsonArr.getInt(0));
			setResetTime(jsonArr.getLong(1));
		}
	}
	
	/**
	 * 行为数据类
	 * @author yu.zhao
	 *
	 */
	public class BindIdBehaviorRecord {
		/** 操作Id，每一行为类型中唯一即可 */
		private long id;
		/** 操作次数 */
		private int opCount;
		/** 附加操作次数，用于增加额外次数，如购买额外的竞技场次数，额外次数只是增加操作次数上限，只允许做加法 */
		private int opAddCount;
		/** 上次操作时间 */
		private long lastOpTime;
		
		/** 基础数据引用 */
		private BindIdBehaviorRecordBase behaviorRecordBase;
		
		private BindIdBehaviorRecord() {
			
		}
		
		public long getId() {
			return id;
		}

		public void setId(long id) {
			this.id = id;
		}

		public int getOpCount() {
			return opCount;
		}

		public void setOpCount(int opCount) {
			this.opCount = opCount;
		}

		public int getOpAddCount() {
			return opAddCount;
		}

		public void setOpAddCount(int opAddCount) {
			this.opAddCount = opAddCount;
		}

		public long getLastOpTime() {
			return lastOpTime;
		}

		public void setLastOpTime(long lastOpTime) {
			this.lastOpTime = lastOpTime;
		}
		
		public BindIdBehaviorRecordBase getBehaviorRecordBase() {
			return behaviorRecordBase;
		}

		public void setBehaviorRecordBase(BindIdBehaviorRecordBase behaviorRecordBase) {
			this.behaviorRecordBase = behaviorRecordBase;
		}

		@Override
		public String toString() {
			return "BindIdBehaviorRecord [id=" + id + ", opCount=" + opCount
					+ ", opAddCount=" + opAddCount + ", lastOpTime="
					+ lastOpTime + ", behaviorReocrdBase=" + behaviorRecordBase
					+ "]";
		}

		/**
		 * 序列化为 JSON 字符串
		 * 
		 * @return
		 */
		public String toJson() {
			JSONArray jsonArr = new JSONArray();
			jsonArr.add(getId());
			jsonArr.add(getOpCount());
			jsonArr.add(getOpAddCount());
			jsonArr.add(getLastOpTime());
			return jsonArr.toString();
		}
		
		/**
		 * 从 JSON 字符串中反序列化对象
		 * 
		 * @param json
		 */
		public void loadJson(String json) {
			if (null == json || json.equalsIgnoreCase("")) {
				return;
			}
			JSONArray jsonArr = JSONArray.fromObject(json);
			if (null == jsonArr || jsonArr.isEmpty()) {
				return;
			}
			
			setId(jsonArr.getLong(0));
			setOpCount(jsonArr.getInt(1));
			setOpAddCount(jsonArr.getInt(2));
			setLastOpTime(jsonArr.getLong(3));
		}
	}
	
}
