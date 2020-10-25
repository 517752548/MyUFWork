package com.imop.lj.gameserver.map.model;

import java.util.List;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.map.MapDef.MapType;

/**
 * 动态创建地图的基类，重写格子相关的方法
 * 主要是为了复用格子相关的数据，不用每个地图都有一份格子数据
 * @author yu.zhao
 *
 */
public class DynamicGameMapBase extends AbstractGameMap {

	public DynamicGameMapBase(int id, MapType type) {
		super(id, type);
	}
	
	@Override
	public boolean isEternal() {
		return false;
	}

	@Override
	public short[][] getMapData() {
		return Globals.getMapService().getGameMap(getId()).getMapData();
	}

	@Override
	public int getTileRows() {
		return Globals.getMapService().getGameMap(getId()).getTileRows();
	}

	@Override
	public int getTileCols() {
		return Globals.getMapService().getGameMap(getId()).getTileCols();
	}
	
	@Override
	public List<Integer> getCanUsePoint() {
		return Globals.getMapService().getGameMap(getId()).getCanUsePoint();
	}
}
