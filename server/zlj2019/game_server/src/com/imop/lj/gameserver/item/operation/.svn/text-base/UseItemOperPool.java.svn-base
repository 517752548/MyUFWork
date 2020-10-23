package com.imop.lj.gameserver.item.operation;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.operation.impl.CostKeyUseItem;
import com.imop.lj.gameserver.item.operation.impl.PropPoolAdd;
import com.imop.lj.gameserver.item.operation.impl.QuestAtPlaceUsed;
import com.imop.lj.gameserver.item.operation.impl.UseAsMove;
import com.imop.lj.gameserver.item.operation.impl.UseGiftPack;
import com.imop.lj.gameserver.item.operation.impl.UseGiveExp;
import com.imop.lj.gameserver.item.operation.impl.UseGiveMoney;
import com.imop.lj.gameserver.item.operation.impl.UseGivePetHorseProp;
import com.imop.lj.gameserver.item.operation.impl.UseGiveTitle;
import com.imop.lj.gameserver.item.operation.impl.UseGiveWing;
import com.imop.lj.gameserver.item.operation.impl.UseHirePet;
import com.imop.lj.gameserver.item.operation.impl.UseHirePetHorse;
import com.imop.lj.gameserver.item.operation.impl.UseTreasureMap;
import com.imop.lj.gameserver.role.Role;

/**
 * 道具使用支持类，单实例，用于为UseItemAction提供合适的UseItemOperation
 * 
 * 
 */
public enum UseItemOperPool {

	instance;

	private final List<UseItemOperation> operations;

	private UseItemOperPool() {
		// 将实现了的service都在这里加入services，把最常用的放在上面，提高查找效率
		this.operations = new ArrayList<UseItemOperation>();
		this.operations.add(new UseAsMove());
		this.operations.add(new UseGiveMoney());
		this.operations.add(new UseHirePet());
		this.operations.add(new UseHirePetHorse());
		this.operations.add(new UseGiftPack());
//		this.operations.add(new AddExpForMainPet());
//		this.operations.add(new AddExpForOtherPet());
//		this.operations.add(new UseVipCard());
//		this.operations.add(new GiveActivityHorse());
//		this.operations.add(new UseLevelMaterialPack());
//		this.operations.add(new UseBankItem());
		this.operations.add(new CostKeyUseItem());
		this.operations.add(new UseTreasureMap());
		this.operations.add(new PropPoolAdd());
		this.operations.add(new QuestAtPlaceUsed());
		this.operations.add(new UseGiveWing());
		this.operations.add(new UseGiveTitle());
		this.operations.add(new UseGivePetHorseProp());
		this.operations.add(new UseGiveExp());
	}

	/**
	 * 获取所有合适使用关系[user,item,target]的UseItemOperation，一个道具只能对应一个Operation
	 * 
	 * @return
	 */
	public <T extends Role> UseItemOperation getSuitableOperation(Human user, Item item, int count, T role) {
		for (UseItemOperation operation : operations) {
			if (operation.isSuitable(user, item, count, role)) {
				return operation;
			}
		}
		return null;
	}
}
