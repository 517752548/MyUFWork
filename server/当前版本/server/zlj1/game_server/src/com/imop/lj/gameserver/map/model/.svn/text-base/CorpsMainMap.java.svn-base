package com.imop.lj.gameserver.map.model;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.map.MapDef.MapType;

/**
 * 军团主城地图对象
 * @author yu.zhao
 *
 */
public class CorpsMainMap extends DynamicGameMapBase {
	/** 地图所属的军团Id */
	private long corpsId;

	public CorpsMainMap(long corpsId) {
		super(Globals.getTemplateCacheService().getMapTemplateCache().getCorpsMainMapId(), MapType.CORPS_MAIN);
		this.corpsId = corpsId;
	}

	@Override
	public boolean canUserEnterMap(long roleId, boolean isClient) {
		boolean sFlag = super.canUserEnterMap(roleId, isClient);
		if (!sFlag) {
			return false;
		}
		
		//非本军团的不能进入
		long humanCorpsId = Globals.getCorpsService().getUserCorpsId(roleId);
		if (getCorpsId() != humanCorpsId) {
			return false;
		}
		
		return super.canUserEnterMap(roleId, isClient);
	}
	
	public long getCorpsId() {
		return corpsId;
	}
	
}
