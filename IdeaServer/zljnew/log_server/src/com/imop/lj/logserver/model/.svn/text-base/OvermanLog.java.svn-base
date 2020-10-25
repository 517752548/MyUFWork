package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class OvermanLog extends BaseLogMessage{
       private long overmancharid;
       private long lowermancharid;
       private int status;
    
    public OvermanLog() {    	
    }

    public OvermanLog(
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
			long overmancharid,			long lowermancharid,			int status            ) {
        super(MessageType.LOG_OVERMAN_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.overmancharid =  overmancharid;
            this.lowermancharid =  lowermancharid;
            this.status =  status;
    }

       public long getOvermancharid() {
	       return overmancharid;
       }
       public long getLowermancharid() {
	       return lowermancharid;
       }
       public int getStatus() {
	       return status;
       }
        
       public void setOvermancharid(long overmancharid) {
	       this.overmancharid = overmancharid;
       }
       public void setLowermancharid(long lowermancharid) {
	       this.lowermancharid = lowermancharid;
       }
       public void setStatus(int status) {
	       this.status = status;
       }
    
    @Override
    protected boolean readLogContent() {
	        overmancharid =  readLong();
	        lowermancharid =  readLong();
	        status =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(overmancharid);
	        writeLong(lowermancharid);
	        writeInt(status);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_OVERMAN_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_OVERMAN_RECORD";
    }
}