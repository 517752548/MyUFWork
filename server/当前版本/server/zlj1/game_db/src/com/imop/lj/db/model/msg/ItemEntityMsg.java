package com.imop.lj.db.model.msg;

import com.imop.lj.core.msg.BaseEntityMsg;
import com.imop.lj.db.model.ItemEntity;

/**
 * This is an auto generated source,please don't modify it.
 * 
 * @author com.imop.ceo.tools.msg.EntityMsgGenerator
 */
public final class ItemEntityMsg extends BaseEntityMsg<ItemEntity> {
	private ItemEntity _entity;

	@Override
	@SuppressWarnings("unchecked")
	public Class getEntityClass() {
		return ItemEntity.class;
	}

	@Override
	public ItemEntity getEntity() {
		return _entity;
	}

	@Override
	public void setEntity(ItemEntity entity) {
		this._entity = entity;
	}

	@Override
	public void initEntity() {
		if (this._entity == null) {
			this._entity = new ItemEntity();
		} else {
			throw new IllegalStateException("The entity is set.");
		}
	}

	@Override
	protected final boolean _read(final byte sequence) {
		switch (sequence) {

		case 1: {
			_entity.setProperties(_readString());
			return true;
		}
		case 2: {
			_entity.setId(_readString());
			return true;
		}
		case 3: {
			long _time = _readLong();
			if (_time > 0) {
				_entity.setCreateTime(new java.sql.Timestamp(_time));
			}
			return true;
		}
		case 4: {
			_entity.setCharId(_readLong());
			return true;
		}
		case 6: {
			_entity.setBagId(_readInt());
			return true;
		}
		case 7: {
			_entity.setBagIndex(_readInt());
			return true;
		}
		case 8: {
			_entity.setTemplateId(_readInt());
			return true;
		}
		case 9: {
			_entity.setOverlap(_readInt());
			return true;
		}
		case 10: {
			long _time = _readLong();
			if (_time > 0) {
				_entity.setDeadline(new java.sql.Timestamp(_time));
			}
			return true;
		}
		case 11: {
			_entity.setDeleted(_readInt());
			return true;
		}
		case 12: {
			long _time = _readLong();
			if (_time > 0) {
				_entity.setDeleteDate(new java.sql.Timestamp(_time));
			}
			return true;
		}
		}
		return false;
	}

	@Override
	protected final boolean _write() {

		_writeString(1, _entity.getProperties());
		_writeString(2, _entity.getId());
		if (_entity.getCreateTime() != null) {
			_writeLong(3, _entity.getCreateTime().getTime());
		} else {
			_writeLong(3, 0);
		}
		_writeLong(4, _entity.getCharId());
		_writeInt(6, _entity.getBagId());
		_writeInt(7, _entity.getBagIndex());
		_writeInt(8, _entity.getTemplateId());
		_writeInt(9, _entity.getOverlap());
		if (_entity.getDeadline() != null) {
			_writeLong(10, _entity.getDeadline().getTime());
		} else {
			_writeLong(10, 0);
		}
		_writeInt(11, _entity.getDeleted());
		if (_entity.getDeleteDate() != null) {
			_writeLong(12, _entity.getDeleteDate().getTime());
		} else {
			_writeLong(12, 0);
		}
		return true;
	}

	@Override
	public final short getType() {
		return EntityMessageType.ItemEntityMsg;
	}

	@Override
	public final String getTypeName() {
		return "ItemEntityMsg";
	}
}