package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PlayerLoginLog extends BaseLogMessage{
       private String device;
       private long playerLoginTime;
       private String source;
    
    public PlayerLoginLog() {    	
    }

    public PlayerLoginLog(
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
			String device,			long playerLoginTime,			String source            ) {
        super(MessageType.LOG_PLAYERLOGIN_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.device =  device;
            this.playerLoginTime =  playerLoginTime;
            this.source =  source;
    }

       public String getDevice() {
	       return device;
       }
       public long getPlayerLoginTime() {
	       return playerLoginTime;
       }
       public String getSource() {
	       return source;
       }
        
       public void setDevice(String device) {
	       this.device = device;
       }
       public void setPlayerLoginTime(long playerLoginTime) {
	       this.playerLoginTime = playerLoginTime;
       }
       public void setSource(String source) {
	       this.source = source;
       }
    
    @Override
    protected boolean readLogContent() {
	        device =  readString();
	        playerLoginTime =  readLong();
	        source =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(device);
	        writeLong(playerLoginTime);
	        writeString(source);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_PLAYERLOGIN_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_PLAYERLOGIN_RECORD";
    }
}