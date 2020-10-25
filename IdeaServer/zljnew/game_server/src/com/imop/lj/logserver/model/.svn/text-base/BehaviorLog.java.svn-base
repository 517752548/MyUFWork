package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class BehaviorLog extends BaseLogMessage{
       private int behaviorType;
       private int oldOpCount;
       private int newOpCount;
       private int oldAddCount;
       private int newAddCount;
    
    public BehaviorLog() {    	
    }

    public BehaviorLog(
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
			int behaviorType,			int oldOpCount,			int newOpCount,			int oldAddCount,			int newAddCount            ) {
        super(MessageType.LOG_BEHAVIOR_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.behaviorType =  behaviorType;
            this.oldOpCount =  oldOpCount;
            this.newOpCount =  newOpCount;
            this.oldAddCount =  oldAddCount;
            this.newAddCount =  newAddCount;
    }

       public int getBehaviorType() {
	       return behaviorType;
       }
       public int getOldOpCount() {
	       return oldOpCount;
       }
       public int getNewOpCount() {
	       return newOpCount;
       }
       public int getOldAddCount() {
	       return oldAddCount;
       }
       public int getNewAddCount() {
	       return newAddCount;
       }
        
       public void setBehaviorType(int behaviorType) {
	       this.behaviorType = behaviorType;
       }
       public void setOldOpCount(int oldOpCount) {
	       this.oldOpCount = oldOpCount;
       }
       public void setNewOpCount(int newOpCount) {
	       this.newOpCount = newOpCount;
       }
       public void setOldAddCount(int oldAddCount) {
	       this.oldAddCount = oldAddCount;
       }
       public void setNewAddCount(int newAddCount) {
	       this.newAddCount = newAddCount;
       }
    
    @Override
    protected boolean readLogContent() {
	        behaviorType =  readInt();
	        oldOpCount =  readInt();
	        newOpCount =  readInt();
	        oldAddCount =  readInt();
	        newAddCount =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(behaviorType);
	        writeInt(oldOpCount);
	        writeInt(newOpCount);
	        writeInt(oldAddCount);
	        writeInt(newAddCount);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_BEHAVIOR_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_BEHAVIOR_RECORD";
    }
}