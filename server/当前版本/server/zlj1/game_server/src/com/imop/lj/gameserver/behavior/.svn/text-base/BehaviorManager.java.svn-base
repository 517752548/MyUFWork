package com.imop.lj.gameserver.behavior;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.model.BehaviorInfo;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.behavior.template.BehaviorTemplate;
import com.imop.lj.gameserver.cache.service.TemplateCacheService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.human.msg.GCBehaviorInfo;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

/**
 * 行为记录管理器
 * 
 */
public class BehaviorManager implements JsonPropDataHolder {

	/** 玩家角色 */
	private Human human = null;
	/** 行为记录字典 */
	private Map<BehaviorTypeEnum, BehaviorRecord> behaviorMap;

	/**
	 * 类参数构造器
	 * 
	 * @param human
	 * @throws IllegalArgumentException
	 *             if human == null
	 * 
	 */
	public BehaviorManager(Human human) {
		if (human == null) {
			throw new IllegalArgumentException("human is null");
		}

		this.human = human;
		this.behaviorMap = new HashMap<BehaviorTypeEnum, BehaviorRecord>();

		for (BehaviorTypeEnum behaviorType : BehaviorTypeEnum.values()) {
			// 设置行为记录字典
			this.behaviorMap.put(behaviorType, new BehaviorRecord());
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
		Map<Integer, BehaviorTemplate> behavTplMap = tempServ.getAll(BehaviorTemplate.class);

		if (behavTplMap == null) {
			return;
		}

		for (BehaviorTypeEnum behavType : BehaviorTypeEnum.values()) {
			// 获取行为配置模版
			BehaviorTemplate behavTpl = behavTplMap.get(behavType.getIndex());

			// 获取行为记录
			BehaviorRecord br = this.behaviorMap.get(behavType);

			if (br == null) {
				continue;
			}

			if (behavTpl != null) {
				// 操作次数上限
				br.setOpCountMax(behavTpl.getOpCountMax());
				// 重置时间
				br.setResetTime(behavTpl.getResetTime());
			}
		}

		this.resetBehaviorMaxOpVip(true);
	}

	/**
	 * 重置vip相关最大数，初始化行为管理器调用，及vip升级时调用，这里与相应行为类型对应。
	 */
	public void resetBehaviorMaxOpVip(boolean isInit) {
		//vip增加次数相关的
		VipFuncTypeEnum[] vArr = VipFuncTypeEnum.values();
		for (int i = 0; i < vArr.length; i++) {
			VipFuncTypeEnum vType = vArr[i];
			//只取次数相关的
			if (vType.getBehaviorTypeEnum() != null) {
				BehaviorRecord br = this.behaviorMap.get(vType.getBehaviorTypeEnum());
				BehaviorTemplate bTpl = Globals.getTemplateCacheService().get(vType.getBehaviorTypeEnum().getIndex(), BehaviorTemplate.class);
				br.setOpCountMax(bTpl.getOpCountMax() + Globals.getVipService().getAddCountByVip(getHuman(), vType));
			}
		}
		if (!isInit) {
			noticeBehaviorInfo();
		}
	}
	
	/**
	 * 通知客户端行为信息
	 * XXX 注意：该消息目前只通知getOpCountMax这个数 只在resetBehaviorMaxOpVip方法中发生变化，
	 * 		如果该消息增加其他字段，注意修改对应字段时，都需要发此消息
	 */
	public void noticeBehaviorInfo() {
		List<BehaviorInfo> infoList = new ArrayList<BehaviorInfo>();
		for (BehaviorTypeEnum key : this.behaviorMap.keySet()) {
			BehaviorInfo info = new BehaviorInfo(0, key.getIndex(), this.behaviorMap.get(key).getOpCountMax());
			infoList.add(info);
		}
		getHuman().sendMessage(new GCBehaviorInfo(infoList.toArray(new BehaviorInfo[0])));
	}

	/**
	 * 对某种行为类型增加操作次数
	 * 
	 * @param behaviorType
	 * @return
	 */
	public boolean addOp(BehaviorTypeEnum behaviorType) {
		return addOp(behaviorType, 1);
	}
	
	public boolean addOp(BehaviorTypeEnum behaviorType, int add) {
		BehaviorRecord br = this.behaviorMap.get(behaviorType);
		if (br == null) {
			return false;
		}
		resetBehaviorRecord(behaviorType);
		
		int oldOpCount = br.getOpCount();
		int newOpCount = oldOpCount;
		int oldAddCount = br.getOpAddCount();

		br.setOpAddCount(br.getOpAddCount() + add);

		int newAddCount = br.getOpAddCount();
		// 记录日志
		Globals.getLogService().sendBehaviorLog(human, LogReasons.BehaviorLogReason.ADD_OP_ADD_COUNT, "", behaviorType.getIndex(), oldOpCount,
				newOpCount, oldAddCount, newAddCount);

		return true;
	}

	public Map<BehaviorTypeEnum, BehaviorRecord> getBehaviorRecords() {
		return behaviorMap;
	}

	/**
	 * 获取玩家角色
	 * 
	 * @return
	 */
	public Human getHuman() {
		return this.human;
	}

	/**
	 * 获取操作行为次数
	 * 
	 * @param behaviorType
	 * @return
	 * 
	 */
	public int getCount(BehaviorTypeEnum behaviorType) {
		// 获取行为记录
		BehaviorRecord br = this.behaviorMap.get(behaviorType);

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
	 * 获取最大操作行为次数
	 * 
	 * @param behaviorType
	 * @return
	 * 
	 */
	public int getMaxCount(BehaviorTypeEnum behaviorType) {
		// 获取行为记录
		BehaviorRecord br = this.behaviorMap.get(behaviorType);
		// 最大行为操作次数
		return br.getOpCountMax() + br.getOpAddCount();
	}

	/**
	 * 获取操作行为剩余次数
	 * 
	 * @param behaviorType
	 * @return
	 */
	public int getLeftCount(BehaviorTypeEnum behaviorType) {
		resetBehaviorRecord(behaviorType);
		int leftCount = getMaxCount(behaviorType) - getCount(behaviorType);
		if (leftCount < 0) {
			leftCount = 0;
		}
		return leftCount;
	}

	/**
	 * 获取购买的操作行为次数
	 * 
	 * @param behaviorType
	 * @return
	 * 
	 */
	public int getOpAddCount(BehaviorTypeEnum behaviorType) {
		// 获取行为记录
		BehaviorRecord br = this.behaviorMap.get(behaviorType);
		// 最大行为操作次数
		return br.getOpAddCount();
	}
	
	/**
	 * 获取行为的最后一次操作时间
	 * @param behaviorType
	 * @return
	 */
	public long getLastOpTime(BehaviorTypeEnum behaviorType) {
		long lastOpTime = 0;
		BehaviorRecord br = this.behaviorMap.get(behaviorType);
		if (null != br) {
			lastOpTime = br.getLastOpTime();
		}
		return lastOpTime;
	}

	/**
	 * 重置枚举类型，根据操作时间判断重置次数
	 * 
	 * @param behaviorType
	 *            行为枚举类型
	 */
	private void resetBehaviorRecord(BehaviorTypeEnum behaviorType) {
		long now = Globals.getTimeService().now();

		BehaviorRecord br = this.behaviorMap.get(behaviorType);
		if (br == null) {
			return;
		}
		if (this.isCanRefreshBehavior(behaviorType)) {
			br.setOpCount(0);
			br.setOpAddCount(0);
			br.setLastOpTime(now);
		}
		human.setModified();
	}
	
	/**
	 * 是否有行为记录数据
	 */
	public boolean hasBehaviorRecord(BehaviorTypeEnum behaviorType) {
		BehaviorRecord br = this.behaviorMap.get(behaviorType);
		if (br == null) {
			return false;
		}
		if (br.getLastOpTime() == 0) {
			return false;
		}
		return true;
	}

	/**
	 * 是否可以重置行为操作类型
	 * 
	 * @param behaviorType
	 *            行为枚举类型
	 */
	public boolean isCanRefreshBehavior(BehaviorTypeEnum behaviorType) {
		BehaviorRecord br = this.behaviorMap.get(behaviorType);
		if (br == null) {
			return false;
		}

		long now = Globals.getTimeService().now();
		return behaviorType.getRefreshCheck().check(br, now);
	}

	public long getTodayResetTime(BehaviorTypeEnum behaviorType) {
		long now = Globals.getTimeService().now();
		long _todayResetTime = 0;
		Calendar _calendarTools = Calendar.getInstance();
		BehaviorRecord br = this.behaviorMap.get(behaviorType);
		if (br == null) {
			return _todayResetTime;
		}
		// int resetHour = br.getResetTime();
		int resetHour = 0;
		TimeUtils.getTodayBegin(Globals.getTimeService());
		_calendarTools.setTimeInMillis(now);
		_calendarTools.set(Calendar.HOUR_OF_DAY, resetHour);
		_calendarTools.set(Calendar.MINUTE, 0);
		_calendarTools.set(Calendar.SECOND, 0);
		_calendarTools.set(Calendar.MILLISECOND, 0);
		// 今日行为重置时间
		_todayResetTime = _calendarTools.getTimeInMillis();
		return _todayResetTime;
	}

	/**
	 * 是否可以做指定类型的行为操作
	 * 
	 * @param behaviorType
	 * @return
	 * 
	 */
	public boolean canDo(BehaviorTypeEnum behaviorType) {
		if (behaviorType == null) {
			return false;
		}

		// 获取行为记录
		BehaviorRecord br = this.behaviorMap.get(behaviorType);

		if (br == null) {
			return false;
		}

		return this.getCount(behaviorType) < (this.getMaxCount(behaviorType));
	}

	/**
	 * 将指定行为类型的操作次数 +1
	 * 
	 * @param behaviorType
	 *            行为类型
	 * @return
	 * 
	 */
	public boolean doBehavior(BehaviorTypeEnum behaviorType) {
		return doBehavior(behaviorType, 1);
	}

	/**
	 * 将指定行为类型的操作次数 +n  (如果超出上限则设置为上限值)
	 * 
	 * @param behaviorType
	 *            行为类型
	 * @return
	 * 
	 */
	public boolean doBehavior(BehaviorTypeEnum behaviorType, int n) {
		if (!this.canDo(behaviorType)) {
			return false;
		}
		if (n <= 0) {
			return false;
		}
		this.resetBehaviorRecord(behaviorType);

		// 获取行为记录
		BehaviorRecord br = this.behaviorMap.get(behaviorType);

		int oldOpCount = br.getOpCount();
		int oldAddCount = br.getOpAddCount();
		int newAddCount = oldAddCount;
		
		//计算应该增加的行为次数
		int resNum = n;
		if(this.getCount(behaviorType) + n > this.getMaxCount(behaviorType)){
			resNum = this.getMaxCount(behaviorType) - this.getCount(behaviorType);
		}
		if(resNum <= 0){
			return false;
		}
		
		// 行为次数+resNum
		br.setOpCount(br.getOpCount() + resNum);
		br.setLastOpTime(Globals.getTimeService().now());

		// 保存玩家信息
		this.human.setModified();

		int newOpCount = br.getOpCount();
		// 记录日志
		Globals.getLogService().sendBehaviorLog(human, LogReasons.BehaviorLogReason.DO_BEHAVIOR_MULTIPLE, "", behaviorType.getIndex(), oldOpCount, newOpCount,
				oldAddCount, newAddCount);

//		// 发kaiying行为日志
//		Globals.getQQKaiYingLogService().sendActLog(human.getPlayer(), KaiyingLogActType.BEHAVIOR, behaviorType.getIndex());
		//活力值增加，功能按钮变化
		if (behaviorType == BehaviorTypeEnum.TOTAL_ACTIVITY_NUM) {
			Globals.getFuncService().onFuncChanged(getHuman(), FuncTypeEnum.ACTIVITY_UI);
		} else {
			Globals.getActivityUIService().onDoBehavior(getHuman(), behaviorType, oldOpCount);
		}
		//汇报热云
		Globals.getReyunService().reportBehavior(human.getPlayer(), behaviorType, n);
		//汇报dataEye
		Globals.getDataEyeService().behaviorLog(human.getPlayer(), behaviorType, n);
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
		BehaviorTypeEnum[] behavTypes = BehaviorTypeEnum.values();
		// JSON 数组
		JSONObject json = new JSONObject();

		for (BehaviorTypeEnum behavType : behavTypes) {
			if (behavType == BehaviorTypeEnum.UNKNOWN) {
				// 如果是未知行为类型,
				// 则直接跳过
				continue;
			}

			// 获取行为记录
			BehaviorRecord br = this.behaviorMap.get(behavType);

			if (br == null) {
				continue;
			}

			// 以行为类型作为关键字
			String key = String.valueOf(behavType.getIndex());
			// 将行为记录序列化为 JSON
			String value = br.toJson();

			json.put(key, value);
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
		if (value == null) {
			return;
		}

		// 行为类型列表
		BehaviorTypeEnum[] behaviorTypes = BehaviorTypeEnum.values();
		// JSON 数组
		JSONObject json = JSONObject.fromObject(value);

		for (BehaviorTypeEnum behaviorType : behaviorTypes) {
			// 以行为类型作为关键字
			String key = String.valueOf(behaviorType.getIndex());

			if (!json.containsKey(key)) {
				continue;
			}

			// 获取行为记录 JSON 字符串
			String brStr = json.getString(key);
			// 创建行为记录
			BehaviorRecord br = this.behaviorMap.get(behaviorType);
			// 反序列化
			br.loadJson(brStr);

			// 注: 反序列化的时候有对行为的次数操作,但是这里不用调用更新活跃度和
			// 奖品信息的情况,因为会从数据库读取

			// 更新重置时间
			this.resetBehaviorRecord(behaviorType);
		}
	}

	/**
	 * 清除操作行为, <font color='#990000'>注意: 只能在 GM 命令类中使用!</font>
	 * 
	 * @param behaviorType
	 * 
	 */
	public void gmClear(BehaviorTypeEnum behaviorType) {
		// 获取行为记录
		BehaviorRecord br = this.behaviorMap.get(behaviorType);

		if (br == null) {
			return;
		}

		// 操作数置 0
		br.setOpCount(0);
		// updateLivenessBehaviorInfo(br,behaviorType);
		// 保存玩家信息
		this.human.setModified();
	}

	public class BehaviorRecord {
		/** 操作次数 */
		private int opCount;
		/** 附加操作次数，用于增加额外次数，如购买额外的竞技场次数，额外次数只是增加操作次数上限，只允许做加法 */
		private int opAddCount;
		/** 操作次数上限 */
		private int opCountMax;
		/** 上次操作时间 */
		private long lastOpTime;
		/** 重置时间 为小时 如值为1，重置时间为每天1点钟 */
		private int resetTime;

		/**
		 * 类默认构造器
		 * 
		 */
		private BehaviorRecord() {
			this.opCount = 0;
			this.opCountMax = 0;
			this.lastOpTime = 0;
			this.opAddCount = 0;
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
		private void setOpCount(int value) {
			this.opCount = value;
		}

		/**
		 * 获取操作次数上限
		 * 
		 * @return
		 */
		public int getOpCountMax() {
			return this.opCountMax;
		}

		/**
		 * 设置操作次数上限
		 * 
		 * @param value
		 */
		private void setOpCountMax(int value) {
			this.opCountMax = value;
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
		private void setLastOpTime(long value) {
			this.lastOpTime = value;
		}

		/**
		 * 获取重置时间
		 * 
		 * @return
		 */
		public int getResetTime() {
			return this.resetTime;
		}

		/**
		 * 设置重置时间
		 * 
		 * @param value
		 */
		private void setResetTime(int value) {
			this.resetTime = value;
		}

		/** 获取附加操作次数，用于增加额外次数，如购买额外的竞技场次数 */
		public int getOpAddCount() {
			return opAddCount;
		}

		/** 设置附加操作次数，用于增加额外次数，如购买额外的竞技场次数 */
		private void setOpAddCount(int opAddCount) {
			this.opAddCount = opAddCount;
		}

		/**
		 * 序列化为 JSON 字符串
		 * 
		 * @return
		 */
		public String toJson() {
			// 创建 JSON 数组对象
			JSONArray jsonArray = new JSONArray();

			jsonArray.add(this.getOpCount());
			jsonArray.add(this.getLastOpTime());
			jsonArray.add(this.getOpAddCount());

			return jsonArray.toString();
		}

		/**
		 * 从 JSON 字符串中反序列化对象
		 * 
		 * @param json
		 */
		public void loadJson(String json) {
			if (json == null) {
				return;
			}

			// 创建 JSON 数组对象
			JSONArray jsonArray = JSONArray.fromObject(json);
			int i = 0;

			if (jsonArray.size() > i) {
				this.setOpCount(jsonArray.getInt(i++));
			}

			if (jsonArray.size() > i) {
				this.setLastOpTime(jsonArray.getLong(i++));
			}

			if (jsonArray.size() > i) {
				this.setOpAddCount(jsonArray.getInt(i++));
			}
		}
	}
}
