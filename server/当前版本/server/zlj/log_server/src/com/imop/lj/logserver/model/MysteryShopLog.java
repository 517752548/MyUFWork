package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class MysteryShopLog extends BaseLogMessage{
       private String text;
    
    public MysteryShopLog() {    	
    }

    public MysteryShopLog(
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
			String text            ) {
        super(MessageType.LOG_MYSTERYSHOP_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.text =  text;
    }

       public String getText() {
	       return text;
       }
        
       public void setText(String text) {
	       this.text = text;
       }
    
    @Override
    protected boolean readLogContent() {
	        text =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(text);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_MYSTERYSHOP_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_MYSTERYSHOP_RECORD";
    }
}