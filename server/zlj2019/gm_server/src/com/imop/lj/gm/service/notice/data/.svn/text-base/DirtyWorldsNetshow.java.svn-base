package com.imop.lj.gm.service.notice.data;

import com.imop.lj.db.model.DirtyWordsTypeEntity;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.DateUtil;

public class DirtyWorldsNetshow {
	private int id ;
	private String showDataType;
	private String updateTimeStr;
	private int showTypes;
	public DirtyWorldsNetshow(){}
	public DirtyWorldsNetshow(DirtyWordsTypeEntity entity,ExcelLangManagerService lang){
		this.setId(entity.getId());
		this.setUpdateTimeStr(DateUtil.formatDateHour(entity.getUpdateTime().getTime()));
		String str = lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_GAMESERVER);
		if(DirtyWorldsTypeEnum.GAMESERVER.getIndex() == entity.getDirtyWordsType()){
			str = lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_GAMESERVER);
		}else if(DirtyWorldsTypeEnum.PART.getIndex() == entity.getDirtyWordsType()){
			str = lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_PART);
		}else if(DirtyWorldsTypeEnum.FULL.getIndex() == entity.getDirtyWordsType()){
			str = lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_FULL);
		}
		this.setShowDataType(str);
		this.setShowTypes(entity.getDirtyWordsType());
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getShowDataType() {
		return showDataType;
	}
	public void setShowDataType(String showDataType) {
		this.showDataType = showDataType;
	}
	public String getUpdateTimeStr() {
		return updateTimeStr;
	}
	public void setUpdateTimeStr(String updateTimeStr) {
		this.updateTimeStr = updateTimeStr;
	}
	public int getShowTypes() {
		return showTypes;
	}
	public void setShowTypes(int showTypes) {
		this.showTypes = showTypes;
	}
	
}
