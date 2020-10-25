package com.imop.lj.gameserver.item.msg;

import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年4月8日 下午2:52:50
 * @version 1.0
 */

public class CommonItemHelper {
	
	/**
	 * 创建通用物品对象 默认数量是1
	 * @param itemTplId
	 * @return
	 */
	public static CommonItem createCommonItem(int itemTplId) {
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemTplId, ItemTemplate.class);
		return CommonItemHelper.createCommonItem(itemTpl);
	}
	public static CommonItem createCommonItem(ItemTemplate itemTpl) {
		return CommonItemHelper.createCommonItem(itemTpl, 1);
	}
	/**
	 * 创建通用物品对象
	 * @param itemTplId	模板id
	 * @param num	模板数量
	 * @return
	 */
	public static CommonItem createCommonItem(int itemTplId, int num) {
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemTplId, ItemTemplate.class);
		return CommonItemHelper.createCommonItem(itemTpl, num);
	}
	
	public static CommonItem createCommonItem(ItemTemplate itemTpl, int num) {
		CommonItemBuilder builder = new CommonItemBuilder(itemTpl, num);
		return builder.buildCommonItem();
	}

}
