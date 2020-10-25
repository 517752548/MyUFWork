package com.imop.lj.gameserver.onlinegift.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 特殊在线礼包
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SpecOnlineGiftTemplateVO extends TemplateObject {

	/** CD */
	@ExcelCellBinding(offset = 1)
	protected long cd;

	/** 奖励ID */
	@ExcelCellBinding(offset = 2)
	protected int rewardId;

	/** 头像ID */
	@ExcelCellBinding(offset = 3)
	protected String iconId;

	/**  资源类型 */
	@ExcelCellBinding(offset = 4)
	protected int resType;

	/** 资源ID */
	@ExcelCellBinding(offset = 5)
	protected String resId;

	/** X轴偏移量 */
	@ExcelCellBinding(offset = 6)
	protected int offsetX;

	/** Y轴偏移量 */
	@ExcelCellBinding(offset = 7)
	protected int offsetY;

	/** 美术字ID */
	@ExcelCellBinding(offset = 8)
	protected int artFontId;

	/**  按钮信息多语言ID */
	@ExcelCellBinding(offset = 9)
	protected int menuDescLangId;

	/** 按钮信息 */
	@ExcelCellBinding(offset = 10)
	protected String menuDesc;

	/** 奖励描述多语言ID */
	@ExcelCellBinding(offset = 11)
	protected int rewardDescLangId;

	/** 奖励描述 */
	@ExcelCellBinding(offset = 12)
	protected String rewardDesc;

	/** 领取描述多语言ID */
	@ExcelCellBinding(offset = 13)
	protected int receiveDescLangId;

	/** 领取描述 */
	@ExcelCellBinding(offset = 14)
	protected String receiveDesc;


	public long getCd() {
		return this.cd;
	}

	public void setCd(long cd) {
		if (cd < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[CD]cd的值不得小于1");
		}
		this.cd = cd;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[奖励ID]rewardId不可以为0");
		}
		this.rewardId = rewardId;
	}
	
	public String getIconId() {
		return this.iconId;
	}

	public void setIconId(String iconId) {
		if (StringUtils.isEmpty(iconId)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[头像ID]iconId不可以为空");
		}
		if (iconId != null) {
			this.iconId = iconId.trim();
		}else{
			this.iconId = iconId;
		}
	}
	
	public int getResType() {
		return this.resType;
	}

	public void setResType(int resType) {
		this.resType = resType;
	}
	
	public String getResId() {
		return this.resId;
	}

	public void setResId(String resId) {
		if (resId != null) {
			this.resId = resId.trim();
		}else{
			this.resId = resId;
		}
	}
	
	public int getOffsetX() {
		return this.offsetX;
	}

	public void setOffsetX(int offsetX) {
		this.offsetX = offsetX;
	}
	
	public int getOffsetY() {
		return this.offsetY;
	}

	public void setOffsetY(int offsetY) {
		this.offsetY = offsetY;
	}
	
	public int getArtFontId() {
		return this.artFontId;
	}

	public void setArtFontId(int artFontId) {
		this.artFontId = artFontId;
	}
	
	public int getMenuDescLangId() {
		return this.menuDescLangId;
	}

	public void setMenuDescLangId(int menuDescLangId) {
		this.menuDescLangId = menuDescLangId;
	}
	
	public String getMenuDesc() {
		return this.menuDesc;
	}

	public void setMenuDesc(String menuDesc) {
		if (StringUtils.isEmpty(menuDesc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[按钮信息]menuDesc不可以为空");
		}
		if (menuDesc != null) {
			this.menuDesc = menuDesc.trim();
		}else{
			this.menuDesc = menuDesc;
		}
	}
	
	public int getRewardDescLangId() {
		return this.rewardDescLangId;
	}

	public void setRewardDescLangId(int rewardDescLangId) {
		this.rewardDescLangId = rewardDescLangId;
	}
	
	public String getRewardDesc() {
		return this.rewardDesc;
	}

	public void setRewardDesc(String rewardDesc) {
		if (StringUtils.isEmpty(rewardDesc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[奖励描述]rewardDesc不可以为空");
		}
		if (rewardDesc != null) {
			this.rewardDesc = rewardDesc.trim();
		}else{
			this.rewardDesc = rewardDesc;
		}
	}
	
	public int getReceiveDescLangId() {
		return this.receiveDescLangId;
	}

	public void setReceiveDescLangId(int receiveDescLangId) {
		this.receiveDescLangId = receiveDescLangId;
	}
	
	public String getReceiveDesc() {
		return this.receiveDesc;
	}

	public void setReceiveDesc(String receiveDesc) {
		if (StringUtils.isEmpty(receiveDesc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[领取描述]receiveDesc不可以为空");
		}
		if (receiveDesc != null) {
			this.receiveDesc = receiveDesc.trim();
		}else{
			this.receiveDesc = receiveDesc;
		}
	}
	

	@Override
	public String toString() {
		return "SpecOnlineGiftTemplateVO[cd=" + cd + ",rewardId=" + rewardId + ",iconId=" + iconId + ",resType=" + resType + ",resId=" + resId + ",offsetX=" + offsetX + ",offsetY=" + offsetY + ",artFontId=" + artFontId + ",menuDescLangId=" + menuDescLangId + ",menuDesc=" + menuDesc + ",rewardDescLangId=" + rewardDescLangId + ",rewardDesc=" + rewardDesc + ",receiveDescLangId=" + receiveDescLangId + ",receiveDesc=" + receiveDesc + ",]";

	}
}