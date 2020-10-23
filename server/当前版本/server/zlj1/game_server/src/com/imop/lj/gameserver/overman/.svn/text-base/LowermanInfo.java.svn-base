package com.imop.lj.gameserver.overman;

import com.google.common.collect.Lists;
import com.imop.lj.core.util.JsonUtils;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import java.util.List;

/**
 * Created by zhangzhe on 15/12/24.
 */
public class LowermanInfo {
    private final static String LOWERMAN_CHARID = "a";
    private final static String LOWERMAN_ADDTIME = "b";
    private final static String OVERMAN_REWARD = "c";
    private final static String LOWERMAN_REWARD = "d";
    private final static String FORCE_TIME = "e";
    private final static String LOWERMAN_ISONLINE = "f";

    //徒弟的charid
    private long uuid;
    //接受时间
    private long createTime;

    private String humanName="";
    private Integer level;
    private Integer fightPower;
    private Integer templateId;
    //强制接触的时间
    private long deleteTime = 0;
    //师傅奖励领取
    private List<OvermanDef.OVERMAN_REWARD> overmanreward = Lists.newArrayList();
    //徒弟奖励领取
    private List<OvermanDef.OVERMAN_REWARD> lowermanreward = Lists.newArrayList();
    //徒弟是否在线,1是,0否
    private boolean isOnline;

    public long getUuid() {
        return uuid;
    }

    public void setUuid(Long uuid) {
        this.uuid = uuid;
    }

    public Long getCreateTime() {
        return createTime;
    }

    public void setCreateTime(Long createTime) {
        this.createTime = createTime;
    }

    /**
     * 获取已领取对师傅的奖励
     *
     * @return
     */
    public List<OvermanDef.OVERMAN_REWARD> getHadGetOvermanRewardList() {

        return this.overmanreward;
    }

    /**
     * 获取已领取的徒弟的奖励
     *
     * @return
     */
    public List<OvermanDef.OVERMAN_REWARD> getHadGetLowermanRewardList() {
        return this.lowermanreward;
    }

    public String toJson() {
        JSONObject obj = new JSONObject();
        obj.put(LOWERMAN_CHARID, this.uuid);
        obj.put(LOWERMAN_ADDTIME, this.createTime);
        JSONArray or = new JSONArray();
        for (OvermanDef.OVERMAN_REWARD r : overmanreward) {
            or.add(r.getIndex());
        }
        obj.put(OVERMAN_REWARD, or.toString());
        JSONArray lr = new JSONArray();
        for (OvermanDef.OVERMAN_REWARD r : lowermanreward) {
            lr.add(r.getIndex());
        }
        obj.put(LOWERMAN_REWARD, lr.toString());
        obj.put(FORCE_TIME,this.deleteTime);
        obj.put(LOWERMAN_ISONLINE, this.isOnline);
        return obj.toString();
    }
    public void initFromJson(String json){
        JSONObject obj = JSONObject.fromObject(json);
        this.uuid = JsonUtils.getLong(obj, LOWERMAN_CHARID);
        this.createTime = JsonUtils.getLong(obj, LOWERMAN_ADDTIME);
        JSONArray or = JSONArray.fromObject(JsonUtils.getJSONArray(obj, OVERMAN_REWARD));
        for (int i=0;i<or.size();i++){
            overmanreward.add(OvermanDef.OVERMAN_REWARD.indexOf(or.getInt(i)));
        }
        JSONArray lr = JSONArray.fromObject(JsonUtils.getJSONArray(obj,LOWERMAN_REWARD));
        for(int i=0;i<lr.size();i++){
            lowermanreward.add(OvermanDef.OVERMAN_REWARD.indexOf(lr.getInt(i)));
        }

        this.deleteTime = JsonUtils.getLong(obj, FORCE_TIME);
        
        this.isOnline = JsonUtils.getBoolean(obj, LOWERMAN_ISONLINE);
    }

    public void addOvermanReward(int rewardId) {
        this.overmanreward.add(OvermanDef.OVERMAN_REWARD.indexOf(rewardId));

    }
    public void addLowermanReward(int rewardId){
        this.lowermanreward.add(OvermanDef.OVERMAN_REWARD.indexOf(rewardId));
    }

    public long getDeleteTime() {
        return deleteTime;
    }

    public void setDeleteTime(long deleteTime) {
        this.deleteTime = deleteTime;
    }

    public String getHumanName() {
        return humanName;
    }

    public void setHumanName(String humanName) {
        this.humanName = humanName;
    }

    public Integer getLevel() {
        return level;
    }

    public void setLevel(Integer level) {
        this.level = level;
    }

    public Integer getFightPower() {
        return fightPower;
    }

    public void setFightPower(Integer fightPower) {
        this.fightPower = fightPower;
    }

    public Integer getTemplateId() {
        return templateId;
    }

    public void setTemplateId(Integer templateId) {
        this.templateId = templateId;
    }

	public boolean getIsOnline() {
		return isOnline;
	}

	public void setIsOnline(boolean isOnline) {
		this.isOnline = isOnline;
	}

	@Override
	public String toString() {
		return "LowermanInfo [uuid=" + uuid + ", createTime=" + createTime + ", humanName=" + humanName + ", level="
				+ level + ", fightPower=" + fightPower + ", templateId=" + templateId + ", deleteTime=" + deleteTime
				+ ", overmanreward=" + overmanreward + ", lowermanreward=" + lowermanreward + ", isOnline=" + isOnline
				+ "]";
	}
	
}

