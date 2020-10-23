package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class WingLog extends BaseLogMessage{
       private int tempId;
       private int wingLevel;
       private int wingBless;
       private int wingPower;
    
    public WingLog() {    	
    }

    public WingLog(
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
			int tempId,			int wingLevel,			int wingBless,			int wingPower            ) {
        super(MessageType.LOG_WING_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.tempId =  tempId;
            this.wingLevel =  wingLevel;
            this.wingBless =  wingBless;
            this.wingPower =  wingPower;
    }

       public int getTempId() {
	       return tempId;
       }
       public int getWingLevel() {
	       return wingLevel;
       }
       public int getWingBless() {
	       return wingBless;
       }
       public int getWingPower() {
	       return wingPower;
       }
        
       public void setTempId(int tempId) {
	       this.tempId = tempId;
       }
       public void setWingLevel(int wingLevel) {
	       this.wingLevel = wingLevel;
       }
       public void setWingBless(int wingBless) {
	       this.wingBless = wingBless;
       }
       public void setWingPower(int wingPower) {
	       this.wingPower = wingPower;
       }
    
    @Override
    protected boolean readLogContent() {
	        tempId =  readInt();
	        wingLevel =  readInt();
	        wingBless =  readInt();
	        wingPower =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(tempId);
	        writeInt(wingLevel);
	        writeInt(wingBless);
	        writeInt(wingPower);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_WING_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_WING_RECORD";
    }
}