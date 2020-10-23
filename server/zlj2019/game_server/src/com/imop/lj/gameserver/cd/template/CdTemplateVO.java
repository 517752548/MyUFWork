package com.imop.lj.gameserver.cd.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 冷却队列配置模版
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CdTemplateVO extends TemplateObject {

	/**  冷却类型名称多语言 Id */
	@ExcelCellBinding(offset = 1)
	protected long cdTypeNameLangId;

	/**  冷却类型名称 */
	@ExcelCellBinding(offset = 2)
	protected String cdTypeName;

	/**  冷却队列图标 */
	@ExcelCellBinding(offset = 3)
	protected String icon;

	/**  冷却队列最大数量 */
	@ExcelCellBinding(offset = 4)
	protected int cdQueueMax;

	/**  默认开启数量 */
	@ExcelCellBinding(offset = 5)
	protected int cdQueueDefault;

	/**  冷却时间阈值 */
	@ExcelCellBinding(offset = 6)
	protected long cdTimeThreshold;

	/**  清除 Cd 间隔时间(毫秒) */
	@ExcelCellBinding(offset = 7)
	protected long killCdSpaceTime;

	/**  清除 Cd 所需金币 */
	@ExcelCellBinding(offset = 8)
	protected int killCdNeedGold;

	/** cd所需功能模块 */
	@ExcelCellBinding(offset = 9)
	protected int gameFuncType;

	/** 是否可以清除冷却队列0不可以,1可以 */
	@ExcelCellBinding(offset = 10)
	protected int gameIsKillType;


	public long getCdTypeNameLangId() {
		return this.cdTypeNameLangId;
	}

	public void setCdTypeNameLangId(long cdTypeNameLangId) {
		if (cdTypeNameLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 冷却类型名称多语言 Id]cdTypeNameLangId的值不得小于0");
		}
		this.cdTypeNameLangId = cdTypeNameLangId;
	}
	
	public String getCdTypeName() {
		return this.cdTypeName;
	}

	public void setCdTypeName(String cdTypeName) {
		if (StringUtils.isEmpty(cdTypeName)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[ 冷却类型名称]cdTypeName不可以为空");
		}
		if (cdTypeName != null) {
			this.cdTypeName = cdTypeName.trim();
		}else{
			this.cdTypeName = cdTypeName;
		}
	}
	
	public String getIcon() {
		return this.icon;
	}

	public void setIcon(String icon) {
		if (StringUtils.isEmpty(icon)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[ 冷却队列图标]icon不可以为空");
		}
		if (icon != null) {
			this.icon = icon.trim();
		}else{
			this.icon = icon;
		}
	}
	
	public int getCdQueueMax() {
		return this.cdQueueMax;
	}

	public void setCdQueueMax(int cdQueueMax) {
		if (cdQueueMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[ 冷却队列最大数量]cdQueueMax的值不得小于1");
		}
		this.cdQueueMax = cdQueueMax;
	}
	
	public int getCdQueueDefault() {
		return this.cdQueueDefault;
	}

	public void setCdQueueDefault(int cdQueueDefault) {
		if (cdQueueDefault < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[ 默认开启数量]cdQueueDefault的值不得小于1");
		}
		this.cdQueueDefault = cdQueueDefault;
	}
	
	public long getCdTimeThreshold() {
		return this.cdTimeThreshold;
	}

	public void setCdTimeThreshold(long cdTimeThreshold) {
		if (cdTimeThreshold < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[ 冷却时间阈值]cdTimeThreshold的值不得小于1");
		}
		this.cdTimeThreshold = cdTimeThreshold;
	}
	
	public long getKillCdSpaceTime() {
		return this.killCdSpaceTime;
	}

	public void setKillCdSpaceTime(long killCdSpaceTime) {
		if (killCdSpaceTime < 1000) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[ 清除 Cd 间隔时间(毫秒)]killCdSpaceTime的值不得小于1000");
		}
		this.killCdSpaceTime = killCdSpaceTime;
	}
	
	public int getKillCdNeedGold() {
		return this.killCdNeedGold;
	}

	public void setKillCdNeedGold(int killCdNeedGold) {
		if (killCdNeedGold == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[ 清除 Cd 所需金币]killCdNeedGold不可以为0");
		}
		if (killCdNeedGold < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[ 清除 Cd 所需金币]killCdNeedGold的值不得小于1");
		}
		this.killCdNeedGold = killCdNeedGold;
	}
	
	public int getGameFuncType() {
		return this.gameFuncType;
	}

	public void setGameFuncType(int gameFuncType) {
		if (gameFuncType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[cd所需功能模块]gameFuncType的值不得小于0");
		}
		this.gameFuncType = gameFuncType;
	}
	
	public int getGameIsKillType() {
		return this.gameIsKillType;
	}

	public void setGameIsKillType(int gameIsKillType) {
		if (gameIsKillType > 1 || gameIsKillType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[是否可以清除冷却队列0不可以,1可以]gameIsKillType的值不合法，应为0至1之间");
		}
		this.gameIsKillType = gameIsKillType;
	}
	

	@Override
	public String toString() {
		return "CdTemplateVO[cdTypeNameLangId=" + cdTypeNameLangId + ",cdTypeName=" + cdTypeName + ",icon=" + icon + ",cdQueueMax=" + cdQueueMax + ",cdQueueDefault=" + cdQueueDefault + ",cdTimeThreshold=" + cdTimeThreshold + ",killCdSpaceTime=" + killCdSpaceTime + ",killCdNeedGold=" + killCdNeedGold + ",gameFuncType=" + gameFuncType + ",gameIsKillType=" + gameIsKillType + ",]";

	}
}