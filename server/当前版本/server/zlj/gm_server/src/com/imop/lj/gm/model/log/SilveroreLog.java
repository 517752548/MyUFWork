package com.imop.lj.gm.model.log;

import java.util.List;

public class SilveroreLog extends BaseLog {

    private String enemyUUID;
    private String enemyName;
    private String cityId;
    private String pageIndex;
    private String silverIndex;
    private String result;



	public String getEnemyUUID() {
		return enemyUUID;
	}



	public void setEnemyUUID(String enemyUUID) {
		this.enemyUUID = enemyUUID;
	}



	public String getEnemyName() {
		return enemyName;
	}



	public void setEnemyName(String enemyName) {
		this.enemyName = enemyName;
	}



	public String getCityId() {
		return cityId;
	}



	public void setCityId(String cityId) {
		this.cityId = cityId;
	}



	public String getPageIndex() {
		return pageIndex;
	}



	public void setPageIndex(String pageIndex) {
		this.pageIndex = pageIndex;
	}



	public String getSilverIndex() {
		return silverIndex;
	}



	public void setSilverIndex(String silverIndex) {
		this.silverIndex = silverIndex;
	}



	public String getResult() {
		return result;
	}



	public void setResult(String result) {
		this.result = result;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(this.enemyUUID);
		list.add(this.enemyName);
		list.add(this.cityId);
		list.add(this.pageIndex);
		list.add(this.silverIndex);
		list.add(this.result);
		return list;
	}
}
