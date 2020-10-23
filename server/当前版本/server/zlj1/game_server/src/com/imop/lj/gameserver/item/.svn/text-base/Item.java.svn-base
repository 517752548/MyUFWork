package com.imop.lj.gameserver.item;

import java.sql.Timestamp;
import java.util.Collections;
import java.util.List;

import net.sf.json.JSONObject;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.core.msg.DataType;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.container.Bag;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.common.container.Containable;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.wealth.Expireable;
import com.imop.lj.gameserver.item.ItemDef.Catalogue;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.msg.GCRemoveItem;
import com.imop.lj.gameserver.item.msg.ItemMessageBuilder;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.role.properties.amend.AmendTriple;
import com.imop.lj.gameserver.trade.ITradable;
import com.imop.lj.gameserver.trade.bean.ICommodity;
import com.imop.lj.gameserver.trade.bean.TradeItem;

/**
 * 
 * 一个道具，每个非空（count>0）的物品对应数据库中一条记录
 * 
 * 
 */
public class Item implements Containable, PersistanceObject<String, ItemEntity>, Expireable, ITradable<Item>{

	/** 道具的实例UUID */
	private String UUID;
	/** 道具模板 */
	private ItemTemplate template;
	/** 堆叠个数 */
	private int overlap;
	/** 所在包裹 */
	private BagType bagType;
	/** 所在格子的位置 */
	private int index;
	/** 是否已经变更了 */
	private boolean modified;
	/** 冷却的绝对时间点，存库时需要存相对时间，即还需要多长时间可以冷却 */
	private long coolDownTimePoint;
	/** 物品的生命期的状态 */
	private final LifeCycle lifeCycle;
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 道具实例属性，消耗品此属性为null */
	private ItemFeature feature;
	/** 所有者 */
	private Human owner;
	/** 佩戴者uuid (宠物or武将) 0表示没有佩带者 */
	private long wearerId;
	/** 创建时间 */
	private Timestamp createTime;
	/** 时限 */
	private Timestamp deadline;
//	/** 是否已经被锁定 */
//	private boolean isLocked;
	/** 是否为查看他人信息 */
	private boolean see = false;
	
	private long lastUpdateTime;
	
	/**
	 * 判断一个item是否为空，不考虑锁定，过期，销毁等特殊情况 <br/>
	 * 注意，检测一个item是否为可以放东西的空格不可以用此方法这种格子的条件为(item != null && item.isEmpty())
	 * 
	 * @param item
	 * @return
	 */
	public static boolean isEmpty(Item item) {
		return item == null || item.isEmpty();
	}

	/**
	 * 判断是否属于同一个道具模板
	 * 
	 * @param templateId
	 * @param item
	 * @return
	 */
	public static boolean isSameTemplateId(int templateId, Item item) {
		return item != null && !item.isEmpty() && item.getTemplateId() == templateId;
	}

	/**
	 * 判断是否为同一种道具，即他们的道具模板是同一个，不考虑绑定状态，不考虑锁定，过期，销毁等特殊情况
	 * 
	 * 
	 * @param itemA
	 * @param itemB
	 * @return 
	 *         如果itemA,itemB任意一个为null或为空，有模板但不同时返回false，否则返回true。当两个都为空时同样返回false
	 */
	public static boolean isSameItem(Item itemA, Item itemB) {
		if (Item.isEmpty(itemA) || Item.isEmpty(itemB)) {
			return false;
		}
		if (itemA.getTemplateId() == itemB.getTemplateId()) {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 判断两个道具能否叠加在一起，规则为，两个非空item如果模板相同，绑定状态相同，就可以叠加。不考虑锁定，过期，销毁等特殊情况
	 * 
	 * 
	 * @param itemA
	 * @param itemB
	 * @return
	 */
	public static boolean canMerge(Item itemA, Item itemB) {
		if (Item.isEmpty(itemA) || Item.isEmpty(itemB)) {
			return false;
		}
		return isSameItem(itemA, itemB);
	}

	/**
	 * @param owner
	 *            所有者
	 * @param template
	 *            道具模板
	 * @param bagId
	 *            所在包的id 例如主背包的id为{@link Bag#PRIM_BAG_ID}
	 * @param index
	 *            在包中的索引
	 * @param overlap
	 *            堆叠数量
	 */
	private Item(Human owner, long wearerId, ItemTemplate template, BagType bagType, int index, int overlap) {
		lifeCycle = new LifeCycleImpl(this);
		this.owner = owner;
		this.wearerId = wearerId;
		this.template = template;
		if (this.template != null) {
			this.feature = template.initItemFeature(this);
		}
		this.bagType = bagType == null ? BagType.NULL : bagType;
		this.overlap = overlap;
		this.index = index;
	}
	
	private Item(Human owner, long wearerId, ItemTemplate template, BagType bagType, int index, int overlap, ItemFeature itemFeature) {
		lifeCycle = new LifeCycleImpl(this);
		this.owner = owner;
		this.wearerId = wearerId;
		this.template = template;
		this.feature = itemFeature;
		this.bagType = bagType == null ? BagType.NULL : bagType;
		this.overlap = overlap;
		this.index = index;
	}
	
	/**
	 * 构建一个虚拟的Item，只有feature，其他什么都没有
	 * @param template
	 */
	private Item(ItemTemplate template) {
		this.lifeCycle = null;
		this.template = template;
		if (this.template != null) {
			this.feature = template.initItemFeature(this);
		}
	}

	/**
	 * 由一个已存在物品来构造一个物品，相当于复制
	 * <p>
	 * <strong>注意：</strong> <br>
	 * 1.该对象的生命周期并没有进行复制，处于未激活状态， 需要使用者根据相关业务逻辑，适时进行激活。 <br>
	 * 2.该对象与被复制对象的{@link #feature}用的是同一个引用， 如果这样实现有什么不合适请修改，改为深度复制。
	 * 
	 * @param item
	 *            已存在的物品
	 * 
	 */
	private Item(Item item) {
		this.UUID = KeyUtil.UUIDKey();
		this.template = item.template;
		this.overlap = item.overlap;
		this.bagType = item.bagType;
		this.index = item.index;
		this.coolDownTimePoint = item.coolDownTimePoint;
		this.lifeCycle = new LifeCycleImpl(this);
		this.feature = item.feature;
		feature.bindItem(this);
		this.owner = item.owner;
		this.wearerId = item.wearerId;
		this.createTime = item.createTime;
		this.deadline = item.deadline;
		this.lastUpdateTime = item.lastUpdateTime;
	}

	/**
	 * 物品数据加载完成后进行数据的校验,只能校验通过的物品才可以在加载后加入到{@link Inventory}当中.
	 * 
	 * @return true,数据正常,校验通过;false,数据异常,校验未通过
	 */
	public boolean validateOnLoaded(ItemEntity itemInfo) {
		if (this.isEmpty()) {
			try {
				onDelete();
				// 记录删除日志
				Human owner = getOwner();

				Globals.getLogService().sendItemLog(owner, ItemLogReason.LOAD_VALID_ERR, "加载时发现道具模板不存在，删除道具", bagType.index, index,
						itemInfo.getTemplateId(), UUID, 0, overlap, "", DataType.obj2byte(itemInfo));
				if (Loggers.itemLogger.isWarnEnabled()) {
					Loggers.itemLogger.warn(LogUtils.buildLogInfoStr(getCharId() + "",
							String.format("[Found empty item from db item=%s", itemInfo.toString())));
				}
			} catch (Exception e) {
				Loggers.itemLogger.error(LogUtils.buildLogInfoStr(getOwner().getUUID() + "", "记录道具数量变化日志时出错"), e);
			}
			return false;
		} else {
			try {
				// 查找相同位置是否已经有物品了
				Item item = this.getOwner().getInventory().getItemByIndex(getBagType(), getWearerId(), index);
				if (!Item.isEmpty(item)) {
					// 相同位置的物品重复,删除自身,记录删除日志
					onDelete();
					Human owner = getOwner();
					Globals.getLogService().sendItemLog(owner, ItemLogReason.LOAD_VALID_ERR, "加载时发现此道具所在的位置已经有道具了，删除自身", bagType.index, index,
							itemInfo.getTemplateId(), UUID, 0, overlap, "", DataType.obj2byte(itemInfo));
					if (Loggers.itemLogger.isWarnEnabled()) {
						Loggers.itemLogger.error(LogUtils.buildLogInfoStr(getCharId() + "",
								String.format("[Found duplicate item from db item=%s", itemInfo.toString())));
					}
					return false;
				}
			} catch (Exception e) {
				Loggers.itemLogger.error(LogUtils.buildLogInfoStr(getOwner().getUUID() + "", "记录道具数量变化日志时出错"), e);
			}
		}
		return true;
	}

	/**
	 * 创建一个已经激活的道具，即创建之后将直接出现在游戏世界中，初始叠加数为0
	 * 
	 * 创建道具,都必须首先创建到主背包中,不能直接穿到身上
	 * 
	 * @param owner
	 *            所有者
	 * @param template
	 *            道具模板
	 * @param bagId
	 *            所在包id
	 * @param index
	 *            在包中的索引
	 * @return
	 */
	public static Item newActivatedInstance(Human owner, ItemTemplate template, BagType bagType, int index) {
		Assert.notNull(owner);
		Assert.notNull(template);
		Item item = new Item(owner, 0, template, bagType, index, 0);
		//TODO 执行物品创建操作
		item.getFeature().onCreate();
		item.setUUID(KeyUtil.UUIDKey());
		item.setCreateTime(new Timestamp(Globals.getTimeService().now()));
		item.setDeadline(new Timestamp(TimeUtils.getDeadLine(item.getCreateTime(),
				template.getExpiredHour(),TimeUtils.HOUR)));
		item.lifeCycle.activate();
		return item;
	}
	/**
	 * 创建一个已经激活的道具，即创建之后将直接出现在游戏世界中
	 * 
	 * 创建道具,都必须首先创建到主背包中,不能直接穿到身上
	 * 
	 * 宝石镶嵌专用
	 * @param owner
	 *            所有者
	 * @param template
	 *            道具模板
	 * @param bagId
	 *            所在包id
	 * @param index
	 *            在包中的索引
	 * @return
	 */
	public static Item newActivatedInstance(Human owner, ItemTemplate template, BagType bagType, int index,int overlap) {
		Assert.notNull(owner);
		Assert.notNull(template);
		Item item = new Item(owner, 0, template, bagType, index, overlap);
		//TODO 执行物品创建操作
		item.getFeature().onCreate();
		item.setUUID(KeyUtil.UUIDKey());
		item.setCreateTime(new Timestamp(Globals.getTimeService().now()));
		item.setDeadline(new Timestamp(TimeUtils.getDeadLine(item.getCreateTime(),
				template.getExpiredHour(),TimeUtils.HOUR)));
		item.lifeCycle.activate();
		return item;
	}
	/**
	 * 创建一个已经激活的道具，即创建之后将直接出现在游戏世界中，初始叠加数为0
	 * 
	 * 创建道具,都必须首先创建到主背包中,不能直接穿到身上
	 * 
	 * GM 创建物品，其他方法不要用！！！
	 * @param owner
	 * @param template
	 * @param bagType
	 * @param index
	 * @return
	 */
	public static Item newActivatedInstanceForGM(Human owner, ItemTemplate template, BagType bagType, int index, int[] attrA, int[] attrB, int...params) {
		Assert.notNull(owner);
		Assert.notNull(template);
		Item item = new Item(owner, 0, template, bagType, index, 0);
		//TODO 执行物品创建操作
		item.getFeature().onGMCreate(attrA, attrB, params);
		item.setUUID(KeyUtil.UUIDKey());
		item.setCreateTime(new Timestamp(Globals.getTimeService().now()));
		item.setDeadline(new Timestamp(TimeUtils.getDeadLine(item.getCreateTime(),
				template.getExpiredHour(),TimeUtils.HOUR)));
		item.lifeCycle.activate();
		return item;
	}
	
	public static Item newActivatedInstanceWithParams(Human owner, ItemTemplate template, BagType bagType, int index, int[] attrA, int[] attrB, int...params) {
		Assert.notNull(owner);
		Assert.notNull(template);
		Item item = new Item(owner, 0, template, bagType, index, 0);
		//TODO 执行物品创建操作
		item.getFeature().onCreateByParams(attrA, attrB, params);
		item.setUUID(KeyUtil.UUIDKey());
		item.setCreateTime(new Timestamp(Globals.getTimeService().now()));
		item.setDeadline(new Timestamp(TimeUtils.getDeadLine(item.getCreateTime(),
				template.getExpiredHour(),TimeUtils.HOUR)));
		item.lifeCycle.activate();
		return item;
	}
	
	public static Item newActivatedInstanceWithFeature(Human owner, ItemTemplate template, BagType bagType, int index, ItemFeature itemFeature) {
		Assert.notNull(owner);
		Assert.notNull(template);
		Item item = new Item(owner, 0, template, bagType, index, 0, itemFeature);
		item.setUUID(KeyUtil.UUIDKey());
		item.setCreateTime(new Timestamp(Globals.getTimeService().now()));
		item.setDeadline(new Timestamp(TimeUtils.getDeadLine(item.getCreateTime(),
				template.getExpiredHour(),TimeUtils.HOUR)));
		item.lifeCycle.activate();
		itemFeature.bindItem(item);
		return item;
	}

	/**
	 * 创建若干个绑定了模板但不绑定所有者的道具，创建时默认是未激活状态，即不会出现在游戏世界中，也不会对应数据库中的记录<br />
	 * 此方法只用于创建Item对象，而不关心任何业务逻辑
	 * 
	 * 未激活的Item,自然不需要设置佩戴者
	 * 
	 * @param template
	 *            道具模板
	 * @param bagId
	 *            道具所在的包ID
	 * @param index
	 *            道具在包中的索引
	 * @return
	 * @throws IllegalArgumentException
	 *             如果template为null
	 */
	public static Item newDeactivedInstance(Human owner, ItemTemplate template, BagType bagType, int index) {
		Assert.notNull(template);
		Assert.notNull(bagType);
		Item item = new Item(owner, 0, template, bagType, index, 0);
		//TODO 执行物品创建操作
		item.getFeature().onCreate();
		item.lifeCycle.deactivate();
		item.setUUID(KeyUtil.UUIDKey());
		item.setCreateTime(new Timestamp(Globals.getTimeService().now()));
		item.setDeadline(new Timestamp(TimeUtils.getDeadLine(item.getCreateTime(),
				template.getExpiredHour(),TimeUtils.HOUR)));
		return item;
	}

	/**
	 * 创建一个空的item实例，背包中的道具格子初始化时需要用空道具初始化
	 * 
	 * @param owner
	 * @param bagType
	 * @param index
	 * @return
	 */
	public static Item newEmptyOwneredInstance(Human owner, BagType bagType, int index) {
		Assert.notNull(owner);
		return new Item(owner, 0, null, bagType, index, 0);
	}
	
	/**
	 * 构建一个只有tpl和feature的虚拟item
	 * @param tpl
	 * @return
	 */
	public static Item newEmptyVirtualInstance(ItemTemplate tpl) {
		return new Item(tpl);
	}

	/**
	 * 根据一个item创建一个item实例，复制
	 * <p>
	 * <strong>注意：</strong> <br>
	 * 1.该对象的生命周期并没有进行复制，处于未激活状态， 需要使用者根据相关业务逻辑，适时进行激活。 <br>
	 * 2.该对象与被复制对象的{@link #feature}用的是同一个引用， 如果这样实现有什么不合适请修改，改为深度复制。
	 * 
	 * @param item
	 *            被复制的item
	 * @return 新创建的item实例
	 */
	public static Item newCloneInstance(Item item) {
		Assert.notNull(item);
		return new Item(item);
	}

	/**
	 * 从ItemEntity生成一个item实例
	 * 
	 * @param entity
	 * @return
	 */
	public static Item buildFromItemEntity(ItemEntity entity, Human owner) {
		int templateId = entity.getTemplateId();
		ItemTemplate template = Globals.getTemplateCacheService().get(templateId, ItemTemplate.class);
		if (template == null) {
			Loggers.itemLogger.error("item tpl not exist!maybe delete by someone!templateId=" + 
					templateId + ";humanId=" + owner.getCharId());
			return null;
		}
		BagType bagType = BagType.valueOf(entity.getBagId());
		Item item = new Item(owner, entity.getWearerId(), template, bagType, entity.getBagIndex(), entity.getOverlap());
		item.fromEntity(entity);
		return item;
	}

	@Override
	public BagType getBagType() {
		return bagType;
	}

	@Override
	public int getIndex() {
		return index;
	}

	@Override
	public int getOverlap() {
		return overlap;
	}

	@Override
	public int getMaxOverlap() {
		return template != null ? template.getMaxOverlap() : 0;
	}

	@Override
	public long getCharId() {
		Human owner = getOwner();
		return owner == null ? -1 : owner.getCharId();
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public long getStartTiming() {
		return this.createTime.getTime();
	}

	@Override
	public String getDbId() {
		return UUID;
	}

	@Override
	public void setDbId(String id) {
		this.UUID = id;
	}

	@Override
	public boolean isInDb() {
		return isInDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle != null) {
			modified = true;
			// 为了防止发生一些错误的使用状况,暂时把此处的检查限制得很严格
			this.lifeCycle.checkModifiable();
			if (this.lifeCycle.isActive() && !this.isEmpty()) {
				// 物品的生命期处于活动状态,并且该物品不是空的,则执行通知更新机制进行
				this.onUpdate();
			}
		}
	}
	
	/**
	 * 将修改状态还原
	 */
	public void resetModified() {
		this.modified = false;
	}

	/**
	 * 是否有时效的道具
	 * @return
	 */
	public boolean isTimeLimitItem() {
		return template.getExpiredHour() > 0;
	}
	
	@Override
	public long getExpireTime() {
		return template != null ? 
				template.getExpiredHour() == 0 ?
						Expireable.CAN_USE_FOREVER
						: TimeUtils.getDeadLine(this.createTime,template.getExpiredHour(), TimeUtils.HOUR)
				: 0;
	}

	@Override
	public boolean isExpired() {
		if (template == null) {
			return false;
		}
		long now = Globals.getTimeService().now();
		return isExpireDateExpired(now);
	}
	
	/**
	 * 是否能够删除
	 * @return
	 */
	public boolean canDeleteInTemp(){
		if(this.bagType != BagType.TEMP){
			return false;
		}
		
		long deadline = this.getDeadlineTime();
		long now = Globals.getTimeService().now();
		
		//如果【当前时间】>= 【进入临时背包时间】 + 【有效期】则删除
		return now >= deadline;
	}

	@Override
	public void fromEntity(ItemEntity entity) {
		// 这里是加载的时候调用的，尽量不调用自己的set方法，因为set方法会通知更新，这是没有必要的
		BagType bagType = BagType.valueOf(entity.getBagId());
		this.bagType = bagType;
		this.index = entity.getBagIndex();
		this.overlap = entity.getOverlap();
		this.UUID = entity.getId();
		this.setCreateTime(entity.getCreateTime());
		this.deadline = entity.getDeadline();
		this.setLastUpdateTime(entity.getLastUpdateTime());
		//buildFeature(entity);
		//每种Feature根据JSON初始本身数据
		this.feature.fromPros(entity.getProperties());
	}

	@Override
	public ItemEntity toEntity() {
		ItemEntity entity = new ItemEntity();
		entity.setId(this.getUUID());
		entity.setTemplateId(this.getTemplateId());
		entity.setBagId(this.getBagType().index);
		entity.setBagIndex(this.getIndex());
		entity.setOverlap(this.getOverlap());
		entity.setCharId(this.getOwner().getUUID());
		entity.setWearerId(this.getWearerId());
		entity.setCreateTime(this.getCreateTime());
		entity.setDeadline(this.deadline);
		entity.setLastUpdateTime(this.getLastUpdateTime());
		//entity.setProperties(Globals.getItemService().buildPropJsonString(feature));
		// 改为每种Feature生成存储数据
		if(this.getFeature() != null){
			// 此处可能为空，在删除物品时，featuer被置为NULL
			entity.setProperties(this.getFeature().toProps(false));
		}else{
			entity.setProperties("");
		}

		return entity;
	}

	/* ============== 业务方法BEGIN ============== */

	/**
	 * 修改物品实例的数量
	 * 
	 * @param newOverlap
	 *            设置物品的目标数量,当物品的数量设置为0时,将触发物品的删除事件
	 * @param reason
	 *            物品数量改变的原因
	 * @param detailReason
	 *            改变原因详细说明（可无）
	 * @param genKey
	 *            物品产生的key(物品删除时可无)
	 * @param needSendLog
	 *            是否需要向logserver发送日志
	 */
	public void changeOverlap(final int newOverlap, ItemLogReason reason, String detailReason, String genKey, boolean needSendLog) {
		if (newOverlap == this.overlap) {
			return;
		}
		int oldOverlap = this.overlap;
		// 规范化，防止出现非法值
		this.overlap = normalizeOverlap(newOverlap);
		//最后一次更新时间改变
		this.setLastUpdateTime(Globals.getTimeService().now());

		// 通知inventory该 实例的数量被修改了
		getOwner().getInventory().onItemCountChanged(getTemplateId());

		// 转换转化为数据对象,用于记录详细的道具属性,接到detailReason后面,作为log的其他参数
		ItemEntity entity = toEntity();
		if (this.overlap > 0) {
			try {
				// 记录数量变化日志
				Human owner = getOwner();
				Globals.getLogService().sendItemLog(owner, reason, detailReason, getBagType().index, getIndex(), getTemplateId(), UUID,
						overlap - oldOverlap, overlap, genKey, DataType.obj2byte(entity));
			} catch (Exception e) {
				Loggers.itemLogger.error(LogUtils.buildLogInfoStr(getOwner().getUUID() + "", "记录道具数量变化日志时出错"), e);
			}
			setModified();
		} else if (this.overlap == 0) {
			try {
				// 记录物品删除日志 ： 数量变成0
				Human owner = getOwner();
				Globals.getLogService().sendItemLog(owner, reason, detailReason, getBagType().index, getIndex(), getTemplateId(), UUID,
						overlap - oldOverlap, overlap, genKey, DataType.obj2byte(entity));
			} catch (Exception e) {
				Loggers.itemLogger.error(LogUtils.buildLogInfoStr(getOwner().getUUID() + "", "记录道具数量变化日志时出错"), e);
			}
			// 物品已经被删除
			onDelete();
		} else {
			throw new IllegalStateException("The overlap must not be <0 ");
		}
	}

	/**
	 * 删除这个道具
	 * 
	 * @param reason
	 * @param detailReason
	 */
	public void delete(ItemLogReason reason, String detailReason) {
		changeOverlap(0, reason, detailReason, "", true);
	}

	public Timestamp getCreateTime() {
		return createTime;
	}

	protected void setCreateTime(Timestamp createTime) {
		this.createTime = createTime;
	}

	@Override
	public String getGUID() {
		return "item#" + this.UUID;
	}

	public String getUUID() {
		return this.UUID;
	}

	private void setUUID(String uuid) {
		this.UUID = uuid;
	}

	public void setIndex(int index) {
		this.index = index;
		setModified();
	}

	public void setBagType(BagType bagType) {
		this.bagType = bagType;
		setModified();
	}

	public Catalogue getCatalogue() {
		return getItemType().getCatalogue();
	}

	public void setOwner(Human owner) {
		this.owner = owner;
		setModified();
	}

	public Human getOwner() {
		return owner;
	}

	public void setWearerId(long wearerId) {
		this.wearerId = wearerId;
		setModified();
	}

	public long getWearerId() {
		return this.wearerId;
	}

	public ItemFeature getFeature() {
		return feature;
	}

	public void setFeature(ItemFeature feature) {
		this.feature = feature;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	/**
	 * 是否是空物品
	 * 
	 * @return
	 */
	public boolean isEmpty() {
		return getTemplate() == null || getOverlap() == 0;
	}

	/**
	 * 获取还没转完的冷却时间
	 * 
	 * @return
	 */
	public long getLeftCD() {
		long leftCD = coolDownTimePoint - Globals.getTimeService().now();
		return leftCD > 0 ? leftCD : 0;
	}

	public long getCoolDownTimePoint() {
		return coolDownTimePoint;
	}

	/**
	 * 初始化冷却时间点
	 * 
	 * @param coolDownTimePoint
	 */
	public void initCoolDownTimePoint(long coolDownTimePoint) {
		this.coolDownTimePoint = coolDownTimePoint;
	}

	/**
	 * 检测是否处于可用状态
	 * 
	 * @return 如此物未激活、已过期、已销毁返回false 否则返回true
	 */
	public boolean checkAvailable() {
		if (!lifeCycle.isActive() || lifeCycle.isDestroyed()) {
			return false;
		} else {
			return true;
		}
	}

	/**
	 * 生成一个道具信息消息
	 * 
	 * @return
	 */
	public GCMessage getItemInfoMsg() {
		return ItemMessageBuilder.buildGCItemInfo(this);
	}

	/**
	 * 返回物品变化信息，并重置变化的状态，此方法需要在调用之前有对此Item的修改操作，否则将返回一个删除0号包（默认的NULL包）0号索引的删除消息
	 * 
	 * @return 更新道具信息的消息，可能是删除，也可能是更新个数等
	 */
	public GCMessage getUpdateMsgAndResetModify() {
		// 判断是需要更新还是删除物品
		if (needUpdate()) {
			// 如果是更新: 重置修改状态
			resetModified();
			return getItemInfoMsg();
		} else if (needDelete()) {
			// 如果是删除
			resetModified();
			return new GCRemoveItem(this.getWearerId(), this.UUID, (short) getBagType().index, (short) getIndex());
		} else {
			try {
				throw new RuntimeException();
			} catch (RuntimeException e) {
				Loggers.itemLogger.error("不需要更新时调用了此方法，请检查调用者的逻辑", e);
			}
			// 返回一个默认的操作
			return new GCRemoveItem(this.getWearerId(), this.UUID, (short) BagType.NULL.index, (short) 0);
		}
	}
	
	/**
	 * 道具更新使用缓存，替换上面{@link Item#getUpdateMsgAndResetModify}的方法
	 */
	public void updateItemWithCache() {
		// 判断是需要更新还是删除物品
		if (needUpdate()) {
			// 如果是更新: 重置修改状态
			resetModified();
			getOwner().getInventory().addCacheMsg(ItemMessageBuilder.createItemInfo(this));
		} else if (needDelete()) {
			// 如果是删除
			resetModified();
			getOwner().getInventory().addCacheMsg(buildDeleteCommonItem(this.getWearerId(), this.UUID, (short) getBagType().index, (short) getIndex()));
		} else {
			try {
				throw new RuntimeException();
			} catch (RuntimeException e) {
				Loggers.itemLogger.error("不需要更新时调用了此方法，请检查调用者的逻辑", e);
			}
			// 返回一个默认的操作
			getOwner().getInventory().addCacheMsg(buildDeleteCommonItem(this.getWearerId(), this.UUID, (short) BagType.NULL.index, (short) 0));
		}
	}
	
	private CommonItem buildDeleteCommonItem(long wearerId, String uuid, int bagId, int index) {
		CommonItem c = new CommonItem();
		//数量设置为-1表示删除道具
		c.setCount(-1);
		
		c.setWearerId(wearerId);
		c.setUuid(uuid);
		c.setBagId(bagId);
		c.setIndex(index);
		return c;
	}
	
	/**
	 * 获得基础属性的集合，这里返回的是已经经过强化修正的基础属性
	 * 
	 * @warning 不可修改返回的列表和其中的数据
	 * @return
	 */
	public List<AmendTriple> getBaseAmends() {
		// if (isEquipment()) {
		// List<AmendTriple> baseAmends = ((EquipItemTemplate)
		// template).getBaseAmends();
		//
		// // 基础属性可能被强化修正
		// EquipmentFeature feature = (EquipmentFeature) getFeature();
		// int enhanceLevel = feature.getEnhanceLevel();
		// if (enhanceLevel > ItemDef.INIT_ENHANCE_LEVEL) {
		//
		// List<AmendTriple> fixedBaseAmends = new ArrayList<AmendTriple>();
		// for (AmendTriple tuple : baseAmends) {
		// float var = tuple.getVariationValue();
		// int enhancePerLevel = tuple.getEnhancePerLevel();
		// //道具属性=道具属性初始属性值+升级每级增加的值*升级等级 + 宝石所对应属性加成
		// int fixedVar = MathUtils.float2Int(var + (enhanceLevel -
		// ItemDef.INIT_ENHANCE_LEVEL) * enhancePerLevel);
		// AmendTriple newTuple = new AmendTriple(tuple.getAmend(),
		// tuple.getMethod(), tuple.getBaseAmendValue(),
		// fixedVar,enhancePerLevel);
		// fixedBaseAmends.add(newTuple);
		// }
		// baseAmends = fixedBaseAmends;
		// }
		//
		// return baseAmends;
		// }
		// else if(isHunt())
		// {
		// List<AmendTriple> baseAmends = ((HuntItemTemplate)
		// template).getBaseAmends();
		//
		// // 基础属性可能被强化修正
		// HuntItemFeature feature = (HuntItemFeature) getFeature();
		// int enhanceLevel = feature.getLevel();
		// if (enhanceLevel > ItemDef.HUNT_ITEM_INIT_LEVEL) {
		//
		// List<AmendTriple> fixedBaseAmends = new ArrayList<AmendTriple>();
		// for (AmendTriple tuple : baseAmends) {
		// float var = tuple.getVariationValue();
		// int enhancePerLevel = tuple.getEnhancePerLevel();
		// //道具属性=道具属性初始属性值+升级每级增加的值*升级等级
		// int fixedVar = MathUtils.float2Int(var + (enhanceLevel -
		// ItemDef.HUNT_ITEM_INIT_LEVEL) * enhancePerLevel);
		// AmendTriple newTuple = new AmendTriple(tuple.getAmend(),
		// tuple.getMethod(), tuple.getBaseAmendValue(),
		// fixedVar,enhancePerLevel);
		// fixedBaseAmends.add(newTuple);
		// }
		// baseAmends = fixedBaseAmends;
		//
		// //天命命格过滤
		// baseAmends = getDistnyFilter(baseAmends);
		// }
		//
		// return baseAmends;
		// }
		// else {
		return Collections.emptyList();
		// }
	}
	
	/**
	 * 是否能使用
	 */
	public boolean isCanShowed() {
		if(this.feature != null){
			return this.feature.isCanShowed();
		}
		return false;
	}
	
	/**
	 * 能否出售此物品
	 */
	public boolean isCanSelled() {
		if(this.feature != null){
			return this.feature.isCanSelled(true);
		}
		owner.sendSystemMessage(LangConstants.INVAILD_SELL_ITEM);
		return false;
	}

	/**
	 * 能否使用此物品
	 */
	public boolean isCanUsed() {
		if(this.feature != null){
			return this.feature.isCanUsed();
		}
		return false;
	}
	
	/**
	 * 是否能丢弃
	 */
	public boolean isCanThrowed() {
		if(this.feature != null){
			return this.feature.isCanThrowed();
		}
		return false;
	}

	/**
	 * 克隆道具
	 * 
	 * @param from
	 */
	public void cloneItem(Item from) {
		this.template = from.template;
		this.overlap = from.overlap;
		this.feature = from.feature;
		feature.bindItem(this);
	}

	/* ============== 业务方法END ============== */

	private int normalizeOverlap(int overlap) {
		int normalized = 0;
		boolean ok = true;
		if (overlap < 0) {
			normalized = 0;
			ok = false;
		} else if (overlap > getMaxOverlap()) {
			normalized = getMaxOverlap();
			ok = false;
		} else {
			normalized = overlap;
		}
		if (!ok) {
			Loggers.itemLogger.error(String.format("非法的叠加数  overlap=%d itemUUID=%s", overlap, UUID));
		}
		return normalized;
	}

	/**
	 * 是否需要通知客户端更新了
	 * 
	 * @return
	 */
	private boolean needUpdate() {
		if (modified && overlap > 0) {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 是否需要通知客户端删除了
	 * 
	 * @return
	 */
	private boolean needDelete() {
		if (modified && overlap == 0) {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 物品实例被修改(新增加或者属性更新)时调用,触发更新机制
	 */
	private void onUpdate() {
		if (Loggers.itemLogger.isDebugEnabled()) {
			Loggers.itemLogger.debug(String.format("update item=%s bag=%s index=%s", this.toString(), getBagType(), getIndex()));
		}
		this.getOwner().getPlayer().getDataUpdater().addUpdate(this.getLifeCycle());
	}

	/**
	 * 物品被删除时调用,恢复默认值,并触发删除机制
	 * 
	 */
	private void onDelete() {
		modified = true;
		template = null;
		feature = null;
		overlap = 0;
		this.lifeCycle.destroy();
		getOwner().getInventory().resetAfterDel(getBagType(), getWearerId(), getIndex());
		if (Loggers.itemLogger.isDebugEnabled()) {
			Loggers.itemLogger.debug(String.format("delete item=%s bag=%s index=%s", this.toString(), getBagType(), getIndex()));
		}
		this.getOwner().getPlayer().getDataUpdater().addDelete(this.getLifeCycle());
	}

	private boolean isExpireDateExpired(long now) {
		long exprTime = getExpireTime();
		if (exprTime == 0 || exprTime == Expireable.CAN_USE_FOREVER) {
			return false;
		}
		return now >= exprTime;
	}
	
	/* -------------- 委托给template完成 ---------------- */
	public Timestamp getDeadline() {
		return deadline;
	}
	
	public long getDeadlineTime(){
		return this.deadline == null ? 0L : this.deadline.getTime();
	}

	public void setDeadline(Timestamp deadline) {
		this.deadline = deadline;
	}

	/**
	 * 获得道具模版ID
	 * 
	 * @return
	 */
	public ItemTemplate getTemplate() {
		return template;
	}

	/**
	 * 道具模板ID
	 * 
	 * @return 如果此道具已经绑定了模板，返回模板id，否则返回-1
	 */
	public int getTemplateId() {
		return template != null ? template.getId() : -1;
	}

	/**
	 * 此道具的位置，当此道具会被放在一个固定的位置上时有效
	 * 
	 * @return
	 */
	public Position getPosition() {
		return template != null ? template.getPosition() : Position.NULL;
	}

	public String getName() {
		return template == null ? "" : template.getName();
	}

	public ItemType getItemType() {
		return template != null ? template.getItemType() : ItemType.NULL;
	}

	public int getLevel() {
		return template != null ? template.getLevel() : 0;
	}

	/**
	 * 判断一个道具是否为装备，装备是指武器和防具，在添加新的装备大类时需要修改此方法，此方法应该定义装备这个概念的唯一方法。
	 * 
	 * @return
	 */
	public boolean isEquipment() {
		return template == null ? false : template.isEquipment();
	}
	
	/**
	 * 判断一个道具是否为宝石。
	 * 
	 * @return
	 */
	public boolean isGem() {
		return template == null ? false : template.isGem();
	}
	
	/**
	 * 是否为消耗物
	 *
	 * @return
	 */
	public boolean isConsumable(){
		return template == null ? false : template.isConsumable();
	}
	
	/**
	 * 是否可以叠加
	 * 
	 * @return
	 */
	public boolean canOverlap() {
		if (template != null) {
			return template.canOverlap();
		} else {
			return false;
		}
	}

	public boolean isSee() {
		return see;
	}

	public void setSee(boolean see) {
		this.see = see;
	}

	public JSONObject toJsonObject(){
		JSONObject json = new JSONObject();
		if(!Item.isEmpty(this)){
			json.put("bagType", this.getBagType().index);
			json.put("index", this.getIndex());
			json.put("overlap", this.getOverlap());
			json.put("tempalteId", this.getTemplateId());
		}
		return json;
	}

	@Override
	public String toString() {
		return "Item [UUID=" + UUID + ", template=" + template + ", overlap=" + overlap + ", bagType=" + bagType + ", index=" + index + ", modified="
				+ modified + ", coolDownTimePoint=" + coolDownTimePoint + ", lifeCycle=" + lifeCycle + ", isInDb=" + isInDb + ", feature=" + feature
				+ ", owner=" + owner + ", wearerId=" + wearerId + ", createTime=" + createTime + ", deadline=" + deadline + "]";
	}

	@Override
	public ICommodity<Item> toCommodity() {
		TradeItem ti = new TradeItem(this.getUUID(),this.getFeature(),this.getOverlap(),this.getTemplateId());
		return ti;
	}

	@Override
	public boolean removeCommodityFromSeller(Integer commodityNum) {
		return this.getOwner().getInventory().removeItemByIndex(this.getBagType(), this.getIndex(), commodityNum, LogReasons.ItemLogReason.COST_ITEM_FOR_TRADE, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_TRADE,this.getUUID()));
	}

	@Override
	public void initByCommodity(ICommodity<?> commodity) {
		// TODO 自动生成的方法存根
	}
}
