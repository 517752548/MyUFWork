package com.imop.lj.db.dao;

import java.util.List;

import org.hibernate.type.BagType;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.ItemEntity;

/**
 * 物品相关的Dao实现
 * 
 */
public class ItemDao extends BaseDao<ItemEntity> {
	private static final String GET_ITEMS_BY_CHARID = "queryPlayerItem";
	public static final String GET_EQUIP_BY_CHARID = "queryPlayerEquip";
	public static final String DEL_ITEM_BY_ITEMID_CHARID = "delItem";
	private static final String[] GET_ITEMS_BY_CHARID_PARAMS = new String[] { "charId" };
	private static final String[] GET_EQUIPS_BY_CHARID_PARAMS = new String[] { "charId"};
	public static final String[] DEL_ITEM_BY_ITEMID_CHARID_PARAMS = new String[]{"itemId", "charId"};
	
	
//	private static final String GET_ITEMS_BY_WEARERID = "queryPetItemsByWearerId";
//	private static final String[] GET_ITEMS_BY_WEARERID_PARAMS = new String[] { "wearerId" };

	public ItemDao(DBService dbService) {
		super(dbService);
	}

	@SuppressWarnings("unchecked")
	public List<ItemEntity> getItemsByCharId(long characterId) { 
		return this.dbService.findByNamedQueryAndNamedParam(GET_ITEMS_BY_CHARID, GET_ITEMS_BY_CHARID_PARAMS,
				new Object[] { characterId });
	}
	
	@SuppressWarnings("unchecked")
	public List<ItemEntity> getEquipByCharId(long characterId){
		return this.dbService.findByNamedQueryAndNamedParam(GET_EQUIP_BY_CHARID, GET_EQUIPS_BY_CHARID_PARAMS, new Object[] { characterId});
	}
	
	public void delItem(String itemId, long charId) {
		dbService.queryForUpdate(DEL_ITEM_BY_ITEMID_CHARID,	DEL_ITEM_BY_ITEMID_CHARID_PARAMS, new Object[] {itemId, charId });
	}
	
//	@SuppressWarnings("unchecked")
//	public List<ItemEntity> getItemsByWearerId(long wearerId) {
//		return this.dbService.findByNamedQueryAndNamedParam(GET_ITEMS_BY_WEARERID, GET_ITEMS_BY_WEARERID_PARAMS,
//				new Object[] { wearerId });
//	}

	@Override
	protected Class<ItemEntity> getEntityClass() {
		return ItemEntity.class;
	}
}
