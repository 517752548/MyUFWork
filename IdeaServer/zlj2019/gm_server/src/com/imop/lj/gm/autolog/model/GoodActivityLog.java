package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class GoodActivityLog extends BaseLog{

	//活动唯一Id
    private long goodActivityId;
	//活动模板Id
    private int tplId;
	//奖励Id
    private int rewardId;
	//目标Id
    private int targetId;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(goodActivityId);
		list.add(tplId);
		list.add(rewardId);
		list.add(targetId);
		return list;
	}
	
	public long getGoodActivityId() {
		return goodActivityId;
	}
	public int getTplId() {
		return tplId;
	}
	public int getRewardId() {
		return rewardId;
	}
	public int getTargetId() {
		return targetId;
	}
        
	public void setGoodActivityId(long goodActivityId) {
		this.goodActivityId = goodActivityId;
	}
	public void setTplId(int tplId) {
		this.tplId = tplId;
	}
	public void setRewardId(int rewardId) {
		this.rewardId = rewardId;
	}
	public void setTargetId(int targetId) {
		this.targetId = targetId;
	}

}