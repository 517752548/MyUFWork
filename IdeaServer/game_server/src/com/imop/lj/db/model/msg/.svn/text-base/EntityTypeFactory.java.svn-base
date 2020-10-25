package com.imop.lj.db.model.msg;

import com.imop.lj.core.msg.BaseEntityMsg;
import com.imop.lj.core.msg.EntityType;
import com.imop.lj.core.msg.EntityType.EntityCreator;
import com.imop.lj.db.model.ItemEntity;

public class EntityTypeFactory {
	
	public static final EntityType<ItemEntity> ITEMINFO = new EntityType<ItemEntity>(
			ItemEntity.class, 
			EntityMessageType.ItemEntityMsg,
			new EntityCreator<ItemEntity>() {
				@Override
				public BaseEntityMsg<ItemEntity> creageEntityMessage() {
					return new ItemEntityMsg();
				}

				@Override
				public ItemEntity createEntity() {
					return new ItemEntity();
				}
			}
	);
	
	

}
