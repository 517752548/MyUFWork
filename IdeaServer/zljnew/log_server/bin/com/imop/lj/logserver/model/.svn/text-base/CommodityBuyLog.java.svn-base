package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class CommodityBuyLog extends BaseLogMessage{
       private String buyInfo;
    
    public CommodityBuyLog() {    	
    }

    public CommodityBuyLog(
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
			String buyInfo            ) {
        super(MessageType.LOG_COMMODITYBUY_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.buyInfo =  buyInfo;
    }

       public String getBuyInfo() {
	       return buyInfo;
       }
        
       public void setBuyInfo(String buyInfo) {
	       this.buyInfo = buyInfo;
       }
    
    @Override
    protected boolean readLogContent() {
	        buyInfo =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(buyInfo);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_COMMODITYBUY_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_COMMODITYBUY_RECORD";
    }
}