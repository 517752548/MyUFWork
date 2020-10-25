package com.imop.lj.gameserver.mall.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.CurrencyTemplate;
import com.imop.lj.common.model.template.ItemCostTemplate;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 商城限时商品配置
 * 
 * @author xiaowei.liu
 * 
 */
@ExcelRowBinding
public class MallTimeLimitItemTemplate extends MallTimeLimitItemTemplateVO implements Comparable<MallTimeLimitItemTemplate>{
	// 限时队列
	private MallTimeLimitQueueTemplate timeLimitQueue;
	// 出售物品
	private ItemTemplate sellItem;
	// 出售物品数量
	private int sellItemNum;

	// 价格
	private CurrencyTemplate price;

	@Override
	public void check() throws TemplateConfigException {
		// 检查限时队列
		timeLimitQueue = this.templateService.get(this.queueId,
				MallTimeLimitQueueTemplate.class);
		if (timeLimitQueue == null) {
			throw new TemplateConfigException(sheetName, this.id, "限时队列为空");
		}

		// 物品检查
		ItemCostTemplate ict = this.normalItemList.get(0);
		sellItem = this.templateService.get(ict.getItemTempId(), ItemTemplate.class);
		sellItemNum = ict.getNum();

		if (sellItem == null) {
			throw new TemplateConfigException(sheetName, this.id, "配置物品不存在");
		}

		if (sellItemNum > sellItem.getMaxOverlap() || sellItemNum <= 0) {
			throw new TemplateConfigException(sheetName, this.id, "配置数量不正确");
		}

		// 检查货币
		price = this.priceList.get(0);
//		TemplateValidator.checkCurrencyTemplate(price, this);
		
		//增加礼券标识
		if(this.price.getCurrencyType() == Currency.GIFT_BOND.getIndex()){
			if(!this.marks.contains("2")){
				this.marks = this.marks + ",2";
			}
		}
	}

	public MallTimeLimitQueueTemplate getTimeLimitQueue() {
		return timeLimitQueue;
	}

	public void setTimeLimitQueue(MallTimeLimitQueueTemplate timeLimitQueue) {
		this.timeLimitQueue = timeLimitQueue;
	}

	public ItemTemplate getSellItem() {
		return sellItem;
	}

	public void setSellItem(ItemTemplate sellItem) {
		this.sellItem = sellItem;
	}

	public int getSellItemNum() {
		return sellItemNum;
	}

	public void setSellItemNum(int sellItemNum) {
		this.sellItemNum = sellItemNum;
	}

	public CurrencyTemplate getPrice() {
		return price;
	}

	public void setPrice(CurrencyTemplate price) {
		this.price = price;
	}

	@Override
	public int compareTo(MallTimeLimitItemTemplate o) {
		return this.sortId - o.getSortId();
	}

}
