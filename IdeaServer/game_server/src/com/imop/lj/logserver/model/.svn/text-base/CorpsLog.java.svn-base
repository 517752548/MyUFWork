package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class CorpsLog extends BaseLogMessage{
       private long corpsId;
       private String corpsName;
       private int corpsLevel;
       private int memberNum;
       private int operatorJob;
       private long targetId;
       private String targetName;
       private int targetJob;
    
    public CorpsLog() {    	
    }

    public CorpsLog(
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
			long corpsId,			String corpsName,			int corpsLevel,			int memberNum,			int operatorJob,			long targetId,			String targetName,			int targetJob            ) {
        super(MessageType.LOG_CORPS_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.corpsId =  corpsId;
            this.corpsName =  corpsName;
            this.corpsLevel =  corpsLevel;
            this.memberNum =  memberNum;
            this.operatorJob =  operatorJob;
            this.targetId =  targetId;
            this.targetName =  targetName;
            this.targetJob =  targetJob;
    }

       public long getCorpsId() {
	       return corpsId;
       }
       public String getCorpsName() {
	       return corpsName;
       }
       public int getCorpsLevel() {
	       return corpsLevel;
       }
       public int getMemberNum() {
	       return memberNum;
       }
       public int getOperatorJob() {
	       return operatorJob;
       }
       public long getTargetId() {
	       return targetId;
       }
       public String getTargetName() {
	       return targetName;
       }
       public int getTargetJob() {
	       return targetJob;
       }
        
       public void setCorpsId(long corpsId) {
	       this.corpsId = corpsId;
       }
       public void setCorpsName(String corpsName) {
	       this.corpsName = corpsName;
       }
       public void setCorpsLevel(int corpsLevel) {
	       this.corpsLevel = corpsLevel;
       }
       public void setMemberNum(int memberNum) {
	       this.memberNum = memberNum;
       }
       public void setOperatorJob(int operatorJob) {
	       this.operatorJob = operatorJob;
       }
       public void setTargetId(long targetId) {
	       this.targetId = targetId;
       }
       public void setTargetName(String targetName) {
	       this.targetName = targetName;
       }
       public void setTargetJob(int targetJob) {
	       this.targetJob = targetJob;
       }
    
    @Override
    protected boolean readLogContent() {
	        corpsId =  readLong();
	        corpsName =  readString();
	        corpsLevel =  readInt();
	        memberNum =  readInt();
	        operatorJob =  readInt();
	        targetId =  readLong();
	        targetName =  readString();
	        targetJob =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(corpsId);
	        writeString(corpsName);
	        writeInt(corpsLevel);
	        writeInt(memberNum);
	        writeInt(operatorJob);
	        writeLong(targetId);
	        writeString(targetName);
	        writeInt(targetJob);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_CORPS_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_CORPS_RECORD";
    }
}