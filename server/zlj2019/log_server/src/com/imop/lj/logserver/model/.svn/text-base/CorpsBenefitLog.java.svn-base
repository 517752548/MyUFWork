package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class CorpsBenefitLog extends BaseLogMessage{
       private long corpsId;
       private String corpsName;
       private int corpsLevel;
       private int memberNum;
       private long operatorId;
       private int operatorJob;
       private long benefitCount;
    
    public CorpsBenefitLog() {    	
    }

    public CorpsBenefitLog(
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
			long corpsId,			String corpsName,			int corpsLevel,			int memberNum,			long operatorId,			int operatorJob,			long benefitCount            ) {
        super(MessageType.LOG_CORPSBENEFIT_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.corpsId =  corpsId;
            this.corpsName =  corpsName;
            this.corpsLevel =  corpsLevel;
            this.memberNum =  memberNum;
            this.operatorId =  operatorId;
            this.operatorJob =  operatorJob;
            this.benefitCount =  benefitCount;
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
       public long getOperatorId() {
	       return operatorId;
       }
       public int getOperatorJob() {
	       return operatorJob;
       }
       public long getBenefitCount() {
	       return benefitCount;
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
       public void setOperatorId(long operatorId) {
	       this.operatorId = operatorId;
       }
       public void setOperatorJob(int operatorJob) {
	       this.operatorJob = operatorJob;
       }
       public void setBenefitCount(long benefitCount) {
	       this.benefitCount = benefitCount;
       }
    
    @Override
    protected boolean readLogContent() {
	        corpsId =  readLong();
	        corpsName =  readString();
	        corpsLevel =  readInt();
	        memberNum =  readInt();
	        operatorId =  readLong();
	        operatorJob =  readInt();
	        benefitCount =  readLong();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(corpsId);
	        writeString(corpsName);
	        writeInt(corpsLevel);
	        writeInt(memberNum);
	        writeLong(operatorId);
	        writeInt(operatorJob);
	        writeLong(benefitCount);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_CORPSBENEFIT_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_CORPSBENEFIT_RECORD";
    }
}