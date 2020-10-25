package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PrizeLog extends BaseLogMessage{
       private long loginTime;
       private int prizeType;
       private int drawCount;
    
    public PrizeLog() {    	
    }

    public PrizeLog(
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
			long loginTime,			int prizeType,			int drawCount            ) {
        super(MessageType.LOG_PRIZE_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.loginTime =  loginTime;
            this.prizeType =  prizeType;
            this.drawCount =  drawCount;
    }

       public long getLoginTime() {
	       return loginTime;
       }
       public int getPrizeType() {
	       return prizeType;
       }
       public int getDrawCount() {
	       return drawCount;
       }
        
       public void setLoginTime(long loginTime) {
	       this.loginTime = loginTime;
       }
       public void setPrizeType(int prizeType) {
	       this.prizeType = prizeType;
       }
       public void setDrawCount(int drawCount) {
	       this.drawCount = drawCount;
       }
    
    @Override
    protected boolean readLogContent() {
	        loginTime =  readLong();
	        prizeType =  readInt();
	        drawCount =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(loginTime);
	        writeInt(prizeType);
	        writeInt(drawCount);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_PRIZE_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_PRIZE_RECORD";
    }
}