package com.imop.lj.gameserver.item.operation;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.role.Role;

/**
 * 
 * 使用道具的策略接口，实现此接口的对象应该无状态可以被公用
 * 
 */
public interface UseItemOperation {

	/**
	 * 此service是否适合处理user向target使用item<br />
	 * 一般是一个{@link ItemDef.ConsumableFunc}
	 * 对应一个operation，如果这个规律不变，可以采用效率更高的表驱动方式查询使用道具的operation
	 * 
	 * @param user
	 * @param item
	 * @param target
	 * @return 如果可以用此service处理，返回true，否则返回false
	 */
	<T extends Role> boolean isSuitable(Human user, Item item, int count, T pet);

	/**
	 * 检查是否可以使用
	 * 
	 * @param user
	 * @param item
	 * @param target
	 * @return
	 */
	<T extends Role> boolean canUse(Human user, Item item, int count, T pet);

	/**
	 * 消耗指定物品或货币，并返回结果
	 * @param user
	 * @param item
	 * @param count
	 * @param pet
	 * @return
	 */
	<T extends Role> boolean cost(Human user, Item item, int count, T pet);
	
	
	/**
	 * 执行一次使用操作，在使用道具时，如果是一次性使用完的，只调用一次此方法，如果是引导使用的，会调用多次，调用的次数和时间间隔有道具的属性指定
	 * 
	 * @param user
	 *            使用者
	 * @param itemInfo
	 *            在扣减前收集的道具信息，道具的使用效果等信息需要在这个参数中获得
	 * @param target
	 * @return 如果使用成功返回true，否则返回false
	 */
	<T extends Role> boolean use(Human user, Item item, int count, T pet);

	// /**
	// * 在不同的operation里面对应的target可能是不同的，有的是专门对角色本身使用的，也可能是对其它目标使用的，<br/>
	// * 消息里面传递过来的是玩家当前所选择的目标，并不一定是物品使用的目标<br/>
	// * 如：使用生命池，目标对象一定是玩家自己，不需要根据消息里面的信息解析目标
	// *
	// * @param user
	// * @param msg
	// * @return
	// */
	// Pet getTarget(USER user, CGUseItem msg);
}
