package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class TowerLog extends BaseLog{

	//当前玩家的通天塔层数
    private int curTowerLevel;
	//当前双倍点数
    private int curDoublePoint;
	//是否开启双倍,1:是,0:否
    private int isOpenDouble;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(curTowerLevel);
		list.add(curDoublePoint);
		list.add(isOpenDouble);
		return list;
	}
	
	public int getCurTowerLevel() {
		return curTowerLevel;
	}
	public int getCurDoublePoint() {
		return curDoublePoint;
	}
	public int getIsOpenDouble() {
		return isOpenDouble;
	}
        
	public void setCurTowerLevel(int curTowerLevel) {
		this.curTowerLevel = curTowerLevel;
	}
	public void setCurDoublePoint(int curDoublePoint) {
		this.curDoublePoint = curDoublePoint;
	}
	public void setIsOpenDouble(int isOpenDouble) {
		this.isOpenDouble = isOpenDouble;
	}

}