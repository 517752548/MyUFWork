package com.imop.lj.gameserver.item.feature;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.role.Role;

/**
 * 抽象feature
 * 
 * @author xiaowei.liu
 * 
 */
public abstract class AbstractFeature implements ItemFeature {
	protected Item item;
	public AbstractFeature(Item item){
		this.item = item;
	}
	
	
	@Override
	public void bindItem(Item item) {
		this.item = item;
	}

	@Override
	public String toProps(boolean isShow) {
		return "";
	}

	@Override
	public void fromPros(String props) {

	}

	@Override
	public long getPrice() {
//		int overlap = this.item.getOverlap();
//		int singlePrise = this.item.getTemplate().getSellPrice();
		return this.item.getTemplate().getSellPrice();
	}

	@Override
	public boolean isCanSelled(boolean notify) {
		boolean result = this.isCanShowSelled();
		if(result){
			return true;
		}else{
			if(notify){
				this.item.getOwner().sendSystemMessage(LangConstants.INVAILD_SELL_ITEM);
			}
			return false;
		}
	}
	
	@Override
	public boolean isCanShowSelled() {
		if (this.item != null && this.item.getOwner() != null
				&& this.item.getTemplate() != null
				&& this.item.getTemplate().getSellCurrency() != null
				&& this.item.getTemplate().getSellCurrency() != Currency.NULL
				&& this.item.getOverlap() > 0) {
			return this.item.getTemplate().isCanSelled();
		}
		return false;
	}


	@Override
	public boolean isCanUsed() {
		if (this.item != null && this.item.getOwner() != null
				&& this.item.getTemplate() != null) {
			return this.item.getTemplate().isCanUsed();
		}
		return false;
	}

	@Override
	public boolean isCanShowed() {
//		if (this.item != null && this.item.getOwner() != null && this.item.getTemplate() != null) {
//			return this.item.getTemplate().isCanShowed();
//		}
		return false;
	}

	@Override
	public boolean isCanThrowed() {
//		if (this.item != null && this.item.getOwner() != null
//				&& this.item.getTemplate() != null) {
//			return this.item.getTemplate().isCanThrowed();
//		}
		return false;
	}
	
	@Override
	public AttrDesc[] getAllAttrDesc() {
		return new AttrDesc[0];
	}

	@Override
	public void onCreate() {

	}
	
	/** GM创建物品  */
	@Override
	public void onGMCreate(int[] attrA, int[] attrB, int...param) {
		
	}
	
	@Override
	public void onCreateByParams(int[] attrA, int[] attrB, int...param) {
		
	}

	public Item getItem() {
		return item;
	}


	@Override
	public <T extends Role> boolean canPuton(T pet, boolean notify) {
		return false;
	}
}
