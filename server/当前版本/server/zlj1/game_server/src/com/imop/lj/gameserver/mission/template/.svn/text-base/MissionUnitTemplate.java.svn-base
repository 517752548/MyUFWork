package com.imop.lj.gameserver.mission.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

/**
 * 关卡每个敌人组的数据
 * @author Administrator
 *
 */
@ExcelRowBinding
public class MissionUnitTemplate {
	/** 敌人组Id */
	@BeanFieldNumber(number = 1)
	private int enemyGroupId;
	/** 敌人组位置 */
	@BeanFieldNumber(number = 2)
	private String enemyGroupPos;
	/** 敌人组出场顺序 */
	@BeanFieldNumber(number = 3)
	private int enemyGroupBornIndex;
	/** 敌人组出场延迟（秒） */
	@BeanFieldNumber(number = 4)
	private float enemyGroupBornDelay;
	
	public int getEnemyGroupId() {
		return enemyGroupId;
	}
	public void setEnemyGroupId(int enemyGroupId) {
		this.enemyGroupId = enemyGroupId;
	}
	public String getEnemyGroupPos() {
		return enemyGroupPos;
	}
	public void setEnemyGroupPos(String enemyGroupPos) {
		this.enemyGroupPos = enemyGroupPos;
	}
	public int getEnemyGroupBornIndex() {
		return enemyGroupBornIndex;
	}
	public void setEnemyGroupBornIndex(int enemyBornIndex) {
		this.enemyGroupBornIndex = enemyBornIndex;
	}
	public float getEnemyGroupBornDelay() {
		return enemyGroupBornDelay;
	}
	public void setEnemyGroupBornDelay(float enemyGroupBornDelay) {
		this.enemyGroupBornDelay = enemyGroupBornDelay;
	}
	
	@Override
	public String toString() {
		return "MissionUnitTemplate [enemyGroupId=" + enemyGroupId
				+ ", enemyGroupPos=" + enemyGroupPos + "enemyGroupBornIndex=" + enemyGroupBornIndex + "]";
	}
	
	
}
