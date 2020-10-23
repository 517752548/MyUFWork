package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PubExpLog extends BaseLogMessage{
       private long addExp;
       private int pubLevel;
       private long pubExp;
    
    public PubExpLog() {    	
    }

    public PubExpLog(
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
			long addExp,			int pubLevel,			long pubExp            ) {
        super(MessageType.LOG_PUBEXP_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.addExp =  addExp;
            this.pubLevel =  pubLevel;
            this.pubExp =  pubExp;
    }

       public long getAddExp() {
	       return addExp;
       }
       public int getPubLevel() {
	       return pubLevel;
       }
       public long getPubExp() {
	       return pubExp;
       }
        
       public void setAddExp(long addExp) {
	       this.addExp = addExp;
       }
       public void setPubLevel(int pubLevel) {
	       this.pubLevel = pubLevel;
       }
       public void setPubExp(long pubExp) {
	       this.pubExp = pubExp;
       }
    
    @Override
    protected boolean readLogContent() {
	        addExp =  readLong();
	        pubLevel =  readInt();
	        pubExp =  readLong();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(addExp);
	        writeInt(pubLevel);
	        writeLong(pubExp);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_PUBEXP_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_PUBEXP_RECORD";
    }
}