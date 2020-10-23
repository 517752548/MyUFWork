package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class TitleLog extends BaseLogMessage{
       private String titleid;
    
    public TitleLog() {    	
    }

    public TitleLog(
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
			String titleid            ) {
        super(MessageType.LOG_TITLE_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.titleid =  titleid;
    }

       public String getTitleid() {
	       return titleid;
       }
        
       public void setTitleid(String titleid) {
	       this.titleid = titleid;
       }
    
    @Override
    protected boolean readLogContent() {
	        titleid =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(titleid);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_TITLE_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_TITLE_RECORD";
    }
}