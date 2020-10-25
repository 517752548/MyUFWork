package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class TitleLog extends BaseLog{

	//称号id
    private String titleid;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(titleid);
		return list;
	}
	
	public String getTitleid() {
		return titleid;
	}
        
	public void setTitleid(String titleid) {
		this.titleid = titleid;
	}

}