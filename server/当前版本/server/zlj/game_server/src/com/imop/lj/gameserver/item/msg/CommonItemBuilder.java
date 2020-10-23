package com.imop.lj.gameserver.item.msg;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.i18n.LangService;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.BindType;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 
 * 单个道具信息，需要显示道具信息的地方公用的一个数据对象，提供了显示道具信息所需的所有get方法，各消息可根据需要引用其中的字段
 * 
 */
public final class CommonItemBuilder {

	/** 道具个数 */
	private int count;
	/** 绑定的道具模板，如果绑定了Item此模板即为Item的模板，在显示任务奖励等只有模板的地方可直接绑定模板 */
	private ItemTemplate template;
	/** 绑定的道具实例 */
	private Item item;
	/** 需要填充内容的CommonItem，如果没提供这个，会new一个新的 */
	private CommonItem commonItem;

	public CommonItemBuilder() {
		reset();
	}

	/**
	 * 直接绑定模板和数量
	 * 
	 * @param template
	 * @param count
	 */
	public CommonItemBuilder(ItemTemplate template, int count) {
		bindItemTemplate(template, count);
	}

	/**
	 * 绑定一个道具实例
	 * 
	 * @param item
	 */
	public CommonItemBuilder(Item item) {
		bindItem(item);
	}

	public void bindItem(Item item) {
		reset();
		this.item = item;
		this.template = item.getTemplate();
		this.count = item.getOverlap();
	}

	public void bindItemTemplate(ItemTemplate template, int count) {
		reset();
		this.template = template;
		this.count = count;
	}

	/**
	 * 将该对象转换为CommonItem对象
	 * 
	 * @return
	 */
	public CommonItem buildCommonItem() {
		if (commonItem == null) {
			commonItem = new CommonItem();
		}
		
		commonItem.setUuid(getUuid());
		commonItem.setBagId(getBagId());
		commonItem.setTplId(getTemplateId());
		commonItem.setCount(getCount());
		commonItem.setIndex(getIndex());
		commonItem.setWearerId(getWearerId());
		commonItem.setLastUpdateTime(getLastUpdateTime());
		commonItem.setExpireDesc(getExpireDesc());
		commonItem.setProps(getProps());
		commonItem.setBind(getBind());
		return commonItem;
	}
	
	private void reset() {
		this.count = 0;
		this.item = null;
		this.template = null;
		this.commonItem = null;
	}

	public Item getItem() {
		return item;
	}

	/**
	 * 设置common item 方便builder子类
	 * 
	 * @param commenItem
	 */
	public void setCommonItem(CommonItem commenItem) {
		this.commonItem = commenItem;
	}

	/**
	 * 道具实例的UUID
	 * 
	 * @return
	 */
	public String getUuid() {
		if (item == null) {
			return "";
		} else {
			return item.getUUID();
		}
	}

	public String getName() {
		return template.getName();
	}

	public int getCount() {
		return count;
	}

	public ItemTemplate getTemplate() {
		return template;
	}

	public int getTemplateId() {
		return template.getId();
	}

	public int getBagId() {
		if (item != null) {
			return item.getBagType().index;
		} else {
			return 0;
		}
	}

	public int getIndex() {
		if (item != null) {
			return item.getIndex();
		} else {
			return 0;
		}
	}
	
	public long getLastUpdateTime() {
		if (item != null) {
			return item.getLastUpdateTime();
		} else {
			return 0;
		}
	}

	public short getItemCatalogue() {
		return template.getItemType().getCatalogue().index;
	}

	public short getItmeType() {
		return (short) template.getItemType().index;
	}

	/**
	 * 等级，装备和非装备显示格式不一样
	 * 
	 * @return
	 */
	public int getLevel() {
		return template.getLevel();
	}

	/**
	 * 生成道具剩余使用时限，显示“还可以使用xx天”或“还可以使用不足一天”或“该道具已经过期”
	 * 
	 * @return
	 */
	public String getExpireDesc() {
		int expireHour =  template.getExpiredHour();
		String desc = "";
		LangService ls = Globals.getLangService();
		if (expireHour > 0) {
			desc = ls.readSysLang(LangConstants.ITEM_EXPIRED_DEADLINE,TimeUtils.formatYMDHMTime(
					TimeUtils.getDeadLine(item.getCreateTime(),expireHour, TimeUtils.HOUR)));
		} else if (expireHour == 0) {
			//可以永久使用
			desc = "";
		}
		return desc;
	}

	public int getRarity() {
		return template.getRarity().index;
	}

	private long getWearerId() {
		long wearerId = 0L;
		if (null != item) {
			wearerId = item.getWearerId();
		}
		return wearerId;
	}
	
	public String getProps() {
		String props = "";
		if (item != null && item.getFeature() != null) {
			props = item.getFeature().toProps(true);
		}
		return props;
	}
	
	public int getBind() {
		boolean isBind = true;
		if (item != null) {
			isBind = item.isBind();
		}
		return isBind ? BindType.BIND.getIndex() : BindType.NOT_BIND.getIndex();
	}

	@Override
	public String toString() {
		return "CommonItemBuilder [count=" + count + ", template=" + template + ", item=" + item + ", commonItem=" + commonItem + "]";
	}

}
