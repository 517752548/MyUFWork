package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class FormationLog extends BaseLogMessage{
       private String result;
    
    public FormationLog() {    	
    }

    public FormationLog(
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
			String result            ) {
        super(MessageType.LOG_FORMATION_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.result =  result;
    }

       public String getResult() {
	       return result;
       }
        
       public void setResult(String result) {
	       this.result = result;
       }
    
    @Override
    protected boolean readLogContent() {
	        result =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(result);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_FORMATION_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_FORMATION_RECORD";
    }
}