package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PopTipsLog extends BaseLogMessage{
       private long humanUuid;
       private int poptipLintType;
       private int poptipsLinkId;
       private int humanOrignalValue;
       private int humanAfterOperatorValue;
    
    public PopTipsLog() {    	
    }

    public PopTipsLog(
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
			long humanUuid,			int poptipLintType,			int poptipsLinkId,			int humanOrignalValue,			int humanAfterOperatorValue            ) {
        super(MessageType.LOG_POPTIPS_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.humanUuid =  humanUuid;
            this.poptipLintType =  poptipLintType;
            this.poptipsLinkId =  poptipsLinkId;
            this.humanOrignalValue =  humanOrignalValue;
            this.humanAfterOperatorValue =  humanAfterOperatorValue;
    }

       public long getHumanUuid() {
	       return humanUuid;
       }
       public int getPoptipLintType() {
	       return poptipLintType;
       }
       public int getPoptipsLinkId() {
	       return poptipsLinkId;
       }
       public int getHumanOrignalValue() {
	       return humanOrignalValue;
       }
       public int getHumanAfterOperatorValue() {
	       return humanAfterOperatorValue;
       }
        
       public void setHumanUuid(long humanUuid) {
	       this.humanUuid = humanUuid;
       }
       public void setPoptipLintType(int poptipLintType) {
	       this.poptipLintType = poptipLintType;
       }
       public void setPoptipsLinkId(int poptipsLinkId) {
	       this.poptipsLinkId = poptipsLinkId;
       }
       public void setHumanOrignalValue(int humanOrignalValue) {
	       this.humanOrignalValue = humanOrignalValue;
       }
       public void setHumanAfterOperatorValue(int humanAfterOperatorValue) {
	       this.humanAfterOperatorValue = humanAfterOperatorValue;
       }
    
    @Override
    protected boolean readLogContent() {
	        humanUuid =  readLong();
	        poptipLintType =  readInt();
	        poptipsLinkId =  readInt();
	        humanOrignalValue =  readInt();
	        humanAfterOperatorValue =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(humanUuid);
	        writeInt(poptipLintType);
	        writeInt(poptipsLinkId);
	        writeInt(humanOrignalValue);
	        writeInt(humanAfterOperatorValue);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_POPTIPS_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_POPTIPS_RECORD";
    }
}