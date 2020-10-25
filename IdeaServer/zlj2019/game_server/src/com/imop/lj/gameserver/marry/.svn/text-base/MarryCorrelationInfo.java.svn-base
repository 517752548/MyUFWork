package com.imop.lj.gameserver.marry;

import net.sf.json.JSONObject;

/**
 * Created by fengmaogen on 15/12/30.
 */
public class MarryCorrelationInfo {
    private final static String MARRY_CREATETIME = "cr";
    private final static String MARRY_FIRETIME="cf";

    //结婚时间
    private long createTime;
    //强制离婚时间
    private long firetime =0;

    public long getFiretime() {
        return firetime;
    }

    public void setFiretime(long firetime) {
        this.firetime = firetime;
    }

    public long getCreateTime() {
		return createTime;
	}
	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}
	public String toJson() {
        JSONObject obj = new JSONObject();
        obj.put(MARRY_CREATETIME, this.createTime);
        obj.put(MARRY_FIRETIME,this.firetime);
        return obj.toString();
    }
    public void initFromJson(String json){
        JSONObject obj = JSONObject.fromObject(json);
        this.createTime = obj.getLong(MARRY_CREATETIME);
        this.firetime = obj.getLong(MARRY_FIRETIME);
    }
}

