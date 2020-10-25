package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class CorpsBossLog extends BaseLog{

	//当前玩家的帮派boss进度
    private int curCorpsBossLevel;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(curCorpsBossLevel);
		return list;
	}
	
	public int getCurCorpsBossLevel() {
		return curCorpsBossLevel;
	}
        
	public void setCurCorpsBossLevel(int curCorpsBossLevel) {
		this.curCorpsBossLevel = curCorpsBossLevel;
	}

}