package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class CommoditySellLog extends BaseLogMessage{
       private String sellInfo;
    
    public CommoditySellLog() {    	
    }

    public CommoditySellLog(
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
			String sellInfo            ) {
        super(MessageType.LOG_COMMODITYSELL_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.sellInfo =  sellInfo;
    }

       public String getSellInfo() {
	       return sellInfo;
       }
        
       public void setSellInfo(String sellInfo) {
	       this.sellInfo = sellInfo;
       }
    
    @Override
    protected boolean readLogContent() {
	        sellInfo =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(sellInfo);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_COMMODITYSELL_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_COMMODITYSELL_RECORD";
    }
}