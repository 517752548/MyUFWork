package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PetExpLog extends BaseLogMessage{
       private int templateId;
       private long instUUID;
       private long addExp;
       private int petLevel;
       private long petExp;
    
    public PetExpLog() {    	
    }

    public PetExpLog(
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
			int templateId,			long instUUID,			long addExp,			int petLevel,			long petExp            ) {
        super(MessageType.LOG_PETEXP_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.templateId =  templateId;
            this.instUUID =  instUUID;
            this.addExp =  addExp;
            this.petLevel =  petLevel;
            this.petExp =  petExp;
    }

       public int getTemplateId() {
	       return templateId;
       }
       public long getInstUUID() {
	       return instUUID;
       }
       public long getAddExp() {
	       return addExp;
       }
       public int getPetLevel() {
	       return petLevel;
       }
       public long getPetExp() {
	       return petExp;
       }
        
       public void setTemplateId(int templateId) {
	       this.templateId = templateId;
       }
       public void setInstUUID(long instUUID) {
	       this.instUUID = instUUID;
       }
       public void setAddExp(long addExp) {
	       this.addExp = addExp;
       }
       public void setPetLevel(int petLevel) {
	       this.petLevel = petLevel;
       }
       public void setPetExp(long petExp) {
	       this.petExp = petExp;
       }
    
    @Override
    protected boolean readLogContent() {
	        templateId =  readInt();
	        instUUID =  readLong();
	        addExp =  readLong();
	        petLevel =  readInt();
	        petExp =  readLong();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(templateId);
	        writeLong(instUUID);
	        writeLong(addExp);
	        writeInt(petLevel);
	        writeLong(petExp);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_PETEXP_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_PETEXP_RECORD";
    }
}