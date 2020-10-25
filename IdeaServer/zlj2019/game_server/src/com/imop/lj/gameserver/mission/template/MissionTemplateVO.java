package com.imop.lj.gameserver.mission.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 关卡配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MissionTemplateVO extends TemplateObject {

	/** 地形Id */
	@ExcelCellBinding(offset = 2)
	protected String mapId;

	/** 出生点 */
	@ExcelCellBinding(offset = 3)
	protected String bornPos;

	/** 背景音乐 */
	@ExcelCellBinding(offset = 4)
	protected String music;

	/** 是否boss */
	@ExcelCellBinding(offset = 5)
	protected int isBoss;

	/** 奖励Id */
	@ExcelCellBinding(offset = 6)
	protected int missionPrizeId;

	/** 敌人组id、位置、出场顺序、出场延迟（秒）的列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.mission.template.MissionUnitTemplate.class, collectionNumber = "7,8,9,10;11,12,13,14;15,16,17,18;19,20,21,22;23,24,25,26")
	protected List<com.imop.lj.gameserver.mission.template.MissionUnitTemplate> enemyGroupList;


	public String getMapId() {
		return this.mapId;
	}

	public void setMapId(String mapId) {
		if (mapId != null) {
			this.mapId = mapId.trim();
		}else{
			this.mapId = mapId;
		}
	}
	
	public String getBornPos() {
		return this.bornPos;
	}

	public void setBornPos(String bornPos) {
		if (bornPos != null) {
			this.bornPos = bornPos.trim();
		}else{
			this.bornPos = bornPos;
		}
	}
	
	public String getMusic() {
		return this.music;
	}

	public void setMusic(String music) {
		if (music != null) {
			this.music = music.trim();
		}else{
			this.music = music;
		}
	}
	
	public int getIsBoss() {
		return this.isBoss;
	}

	public void setIsBoss(int isBoss) {
		this.isBoss = isBoss;
	}
	
	public int getMissionPrizeId() {
		return this.missionPrizeId;
	}

	public void setMissionPrizeId(int missionPrizeId) {
		this.missionPrizeId = missionPrizeId;
	}
	
	public List<com.imop.lj.gameserver.mission.template.MissionUnitTemplate> getEnemyGroupList() {
		return this.enemyGroupList;
	}

	public void setEnemyGroupList(List<com.imop.lj.gameserver.mission.template.MissionUnitTemplate> enemyGroupList) {
		if (enemyGroupList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[敌人组id、位置、出场顺序、出场延迟（秒）的列表]enemyGroupList不可以为空");
		}	
		this.enemyGroupList = enemyGroupList;
	}
	

	@Override
	public String toString() {
		return "MissionTemplateVO[mapId=" + mapId + ",bornPos=" + bornPos + ",music=" + music + ",isBoss=" + isBoss + ",missionPrizeId=" + missionPrizeId + ",enemyGroupList=" + enemyGroupList + ",]";

	}
}