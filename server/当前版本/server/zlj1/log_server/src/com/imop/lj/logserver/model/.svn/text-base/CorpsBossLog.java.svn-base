package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class CorpsBossLog extends BaseLogMessage{
       private int curCorpsBossLevel;
    
    public CorpsBossLog() {    	
    }

    public CorpsBossLog(
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
			int curCorpsBossLevel            ) {
        super(MessageType.LOG_CORPSBOSS_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.curCorpsBossLevel =  curCorpsBossLevel;
    }

       public int getCurCorpsBossLevel() {
	       return curCorpsBossLevel;
       }
        
       public void setCurCorpsBossLevel(int curCorpsBossLevel) {
	       this.curCorpsBossLevel = curCorpsBossLevel;
       }
    
    @Override
    protected boolean readLogContent() {
	        curCorpsBossLevel =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(curCorpsBossLevel);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_CORPSBOSS_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_CORPSBOSS_RECORD";
    }
}