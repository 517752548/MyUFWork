package com.imop.lj.gameserver.title;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.title.template.TitleTemplate;
import net.sf.json.JSONObject;

/**
 * Created by zhangzhe on 15/12/16.
 */
public class TitleInfo {
    public static String TEMPLATEID = "a";
    public static String ENDTIME = "b";
    public static String TITLENAME = "c";
    private Integer templateId; //模版id
    private long titleEndTime; //结束时间
    private  String titleName ; //处理以后的名字

    public TitleInfo(Integer templateId, long titleEndTime) {
        this.templateId = templateId;
        this.titleEndTime = titleEndTime;
    }

    public TitleInfo(Integer templateId) {
        this.templateId = templateId;
        TitleTemplate template = Globals.getTemplateCacheService().get(templateId,TitleTemplate.class);
        if(template.getDeadtime()==0){
            this.titleEndTime = 0;
        }else{
            this.titleEndTime = Globals.getTimeService().now()+template.getDeadtime()*3600*1000;
        }

    }

    public TitleInfo() {

    }

    public void fromJson(JSONObject json) {
        this.templateId = json.getInt(TEMPLATEID);
        this.titleEndTime = json.getLong(ENDTIME);
        this.titleName = json.getString(TITLENAME);
    }

    public Integer getTemplateId() {
        return templateId;
    }

    public void setTemplateId(Integer templateId) {
        this.templateId = templateId;
    }

    public long getTitleEndTime() {
        return titleEndTime;
    }

    public void setTitleEndTime(long titleEndTime) {
        this.titleEndTime = titleEndTime;
    }

    public JSONObject toJson() {
        JSONObject jsonObject = new JSONObject();
        jsonObject.put(TEMPLATEID, templateId);
        jsonObject.put(ENDTIME, titleEndTime);
        jsonObject.put(TITLENAME,titleName);
        return jsonObject;
    }

    public String getTitleName() {
        return titleName;
    }

    public void setTitleName(String titleName) {
        this.titleName = titleName;
    }

	@Override
	public String toString() {
		return "TitleInfo [templateId=" + templateId + ", titleEndTime=" + titleEndTime + ", titleName=" + titleName
				+ "]";
	}
}
