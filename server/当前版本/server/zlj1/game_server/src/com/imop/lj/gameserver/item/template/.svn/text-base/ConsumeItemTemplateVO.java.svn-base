package com.imop.lj.gameserver.item.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 可消耗物品模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ConsumeItemTemplateVO extends ItemTemplate {

	/** 战斗内可使用，0不可以，1可以 */
	@ExcelCellBinding(offset = 34)
	protected int fightUseFlag;

	/** 消耗类型 */
	@ExcelCellBinding(offset = 35)
	protected int costTypeId;

	/** 消耗参数A */
	@ExcelCellBinding(offset = 36)
	protected int costArgA;

	/** 消耗参数B */
	@ExcelCellBinding(offset = 37)
	protected int costArgB;

	/** 使用对象1使用时没有使用对象，对象是角色本身2只能对除主将以外武将使用3只能对主将使用4所有武将都可以用 */
	@ExcelCellBinding(offset = 38)
	protected int useTargetId;

	/** 是否弹快捷使用，0否，1是 */
	@ExcelCellBinding(offset = 39)
	protected int fastUseTip;

	/** 函数功能 */
	@ExcelCellBinding(offset = 40)
	protected int functionId;

	/** 参数a */
	@ExcelCellBinding(offset = 41)
	protected int argA;

	/** 参数b */
	@ExcelCellBinding(offset = 42)
	protected int argB;

	/** 参数c */
	@ExcelCellBinding(offset = 43)
	protected int argC;

	/** 参数d */
	@ExcelCellBinding(offset = 44)
	protected int argD;

	/** 参数e */
	@ExcelCellBinding(offset = 45)
	protected int argE;

	/** 参数f */
	@ExcelCellBinding(offset = 46)
	protected int argF;

	/** 地图ID */
	@ExcelCellBinding(offset = 47)
	protected int mapId;

	/** x坐标点 */
	@ExcelCellBinding(offset = 48)
	protected int tileX;

	/** y坐标点 */
	@ExcelCellBinding(offset = 49)
	protected int tileY;


	public int getFightUseFlag() {
		return this.fightUseFlag;
	}

	public void setFightUseFlag(int fightUseFlag) {
		if (fightUseFlag > 1 || fightUseFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					35, "[战斗内可使用，0不可以，1可以]fightUseFlag的值不合法，应为0至1之间");
		}
		this.fightUseFlag = fightUseFlag;
	}
	
	public int getCostTypeId() {
		return this.costTypeId;
	}

	public void setCostTypeId(int costTypeId) {
		if (costTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					36, "[消耗类型]costTypeId的值不得小于0");
		}
		this.costTypeId = costTypeId;
	}
	
	public int getCostArgA() {
		return this.costArgA;
	}

	public void setCostArgA(int costArgA) {
		if (costArgA < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					37, "[消耗参数A]costArgA的值不得小于0");
		}
		this.costArgA = costArgA;
	}
	
	public int getCostArgB() {
		return this.costArgB;
	}

	public void setCostArgB(int costArgB) {
		if (costArgB < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					38, "[消耗参数B]costArgB的值不得小于0");
		}
		this.costArgB = costArgB;
	}
	
	public int getUseTargetId() {
		return this.useTargetId;
	}

	public void setUseTargetId(int useTargetId) {
		this.useTargetId = useTargetId;
	}
	
	public int getFastUseTip() {
		return this.fastUseTip;
	}

	public void setFastUseTip(int fastUseTip) {
		if (fastUseTip > 1 || fastUseTip < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					40, "[是否弹快捷使用，0否，1是]fastUseTip的值不合法，应为0至1之间");
		}
		this.fastUseTip = fastUseTip;
	}
	
	public int getFunctionId() {
		return this.functionId;
	}

	public void setFunctionId(int functionId) {
		this.functionId = functionId;
	}
	
	public int getArgA() {
		return this.argA;
	}

	public void setArgA(int argA) {
		if (argA < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					42, "[参数a]argA的值不得小于0");
		}
		this.argA = argA;
	}
	
	public int getArgB() {
		return this.argB;
	}

	public void setArgB(int argB) {
		if (argB < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					43, "[参数b]argB的值不得小于0");
		}
		this.argB = argB;
	}
	
	public int getArgC() {
		return this.argC;
	}

	public void setArgC(int argC) {
		if (argC < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					44, "[参数c]argC的值不得小于0");
		}
		this.argC = argC;
	}
	
	public int getArgD() {
		return this.argD;
	}

	public void setArgD(int argD) {
		if (argD < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					45, "[参数d]argD的值不得小于0");
		}
		this.argD = argD;
	}
	
	public int getArgE() {
		return this.argE;
	}

	public void setArgE(int argE) {
		if (argE < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					46, "[参数e]argE的值不得小于0");
		}
		this.argE = argE;
	}
	
	public int getArgF() {
		return this.argF;
	}

	public void setArgF(int argF) {
		if (argF < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					47, "[参数f]argF的值不得小于0");
		}
		this.argF = argF;
	}
	
	public int getMapId() {
		return this.mapId;
	}

	public void setMapId(int mapId) {
		if (mapId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					48, "[地图ID]mapId的值不得小于0");
		}
		this.mapId = mapId;
	}
	
	public int getTileX() {
		return this.tileX;
	}

	public void setTileX(int tileX) {
		if (tileX < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					49, "[x坐标点]tileX的值不得小于0");
		}
		this.tileX = tileX;
	}
	
	public int getTileY() {
		return this.tileY;
	}

	public void setTileY(int tileY) {
		if (tileY < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					50, "[y坐标点]tileY的值不得小于0");
		}
		this.tileY = tileY;
	}
	

	@Override
	public String toString() {
		return "ConsumeItemTemplateVO[fightUseFlag=" + fightUseFlag + ",costTypeId=" + costTypeId + ",costArgA=" + costArgA + ",costArgB=" + costArgB + ",useTargetId=" + useTargetId + ",fastUseTip=" + fastUseTip + ",functionId=" + functionId + ",argA=" + argA + ",argB=" + argB + ",argC=" + argC + ",argD=" + argD + ",argE=" + argE + ",argF=" + argF + ",mapId=" + mapId + ",tileX=" + tileX + ",tileY=" + tileY + ",]";

	}
}