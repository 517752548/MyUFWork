package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class MallLog extends BaseLogMessage{
       private String currQueueConfig;
       private String currQueueUUID;
       private int currQueueId;
       private long currStartTime;
       private String stock;
    
    public MallLog() {    	
    }

    public MallLog(
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
			String currQueueConfig,			String currQueueUUID,			int currQueueId,			long currStartTime,			String stock            ) {
        super(MessageType.LOG_MALL_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.currQueueConfig =  currQueueConfig;
            this.currQueueUUID =  currQueueUUID;
            this.currQueueId =  currQueueId;
            this.currStartTime =  currStartTime;
            this.stock =  stock;
    }

       public String getCurrQueueConfig() {
	       return currQueueConfig;
       }
       public String getCurrQueueUUID() {
	       return currQueueUUID;
       }
       public int getCurrQueueId() {
	       return currQueueId;
       }
       public long getCurrStartTime() {
	       return currStartTime;
       }
       public String getStock() {
	       return stock;
       }
        
       public void setCurrQueueConfig(String currQueueConfig) {
	       this.currQueueConfig = currQueueConfig;
       }
       public void setCurrQueueUUID(String currQueueUUID) {
	       this.currQueueUUID = currQueueUUID;
       }
       public void setCurrQueueId(int currQueueId) {
	       this.currQueueId = currQueueId;
       }
       public void setCurrStartTime(long currStartTime) {
	       this.currStartTime = currStartTime;
       }
       public void setStock(String stock) {
	       this.stock = stock;
       }
    
    @Override
    protected boolean readLogContent() {
	        currQueueConfig =  readString();
	        currQueueUUID =  readString();
	        currQueueId =  readInt();
	        currStartTime =  readLong();
	        stock =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(currQueueConfig);
	        writeString(currQueueUUID);
	        writeInt(currQueueId);
	        writeLong(currStartTime);
	        writeString(stock);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_MALL_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_MALL_RECORD";
    }
}