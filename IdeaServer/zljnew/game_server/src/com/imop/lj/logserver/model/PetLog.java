package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PetLog extends BaseLogMessage{
       private int templateId;
       private long instUUID;
       private String init;
    
    public PetLog() {    	
    }

    public PetLog(
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
			int templateId,			long instUUID,			String init            ) {
        super(MessageType.LOG_PET_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.templateId =  templateId;
            this.instUUID =  instUUID;
            this.init =  init;
    }

       public int getTemplateId() {
	       return templateId;
       }
       public long getInstUUID() {
	       return instUUID;
       }
       public String getInit() {
	       return init;
       }
        
       public void setTemplateId(int templateId) {
	       this.templateId = templateId;
       }
       public void setInstUUID(long instUUID) {
	       this.instUUID = instUUID;
       }
       public void setInit(String init) {
	       this.init = init;
       }
    
    @Override
    protected boolean readLogContent() {
	        templateId =  readInt();
	        instUUID =  readLong();
	        init =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(templateId);
	        writeLong(instUUID);
	        writeString(init);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_PET_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_PET_RECORD";
    }
}