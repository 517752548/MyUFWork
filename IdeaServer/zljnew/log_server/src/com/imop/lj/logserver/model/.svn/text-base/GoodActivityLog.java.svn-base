package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class GoodActivityLog extends BaseLogMessage{
       private long goodActivityId;
       private int tplId;
       private int rewardId;
       private int targetId;
    
    public GoodActivityLog() {    	
    }

    public GoodActivityLog(
					long logTime,
					int regionId,
					int serverId,
					String accountId,
					String accountName,
					long charId,
					String charName,
					int level,
					int countryId,
					int vipLevel,
					int totalCharge,
					String deviceId,
					String deviceType,
					String deviceVersion,
					String clientVersion,
					String clientLanguage,
					String appid,
					String fValue,
					int reason,
                   String param,
			long goodActivityId,			int tplId,			int rewardId,			int targetId            ) {
        super(MessageType.LOG_GOODACTIVITY_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.goodActivityId =  goodActivityId;
            this.tplId =  tplId;
            this.rewardId =  rewardId;
            this.targetId =  targetId;
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
    
    @Override
    protected boolean readLogContent() {
	        goodActivityId =  readLong();
	        tplId =  readInt();
	        rewardId =  readInt();
	        targetId =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(goodActivityId);
	        writeInt(tplId);
	        writeInt(rewardId);
	        writeInt(targetId);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_GOODACTIVITY_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_GOODACTIVITY_RECORD";
    }
}