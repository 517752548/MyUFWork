package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class EquipLog extends BaseLogMessage{
       private String uuid;
       private int tempId;
       private int enhanceLevel;
       private int fumoLevel;
       private int weaponSkillId;
       private String additionAttrStr;
       private String gemStr;
       private String extraStr;
    
    public EquipLog() {    	
    }

    public EquipLog(
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
			String uuid,			int tempId,			int enhanceLevel,			int fumoLevel,			int weaponSkillId,			String additionAttrStr,			String gemStr,			String extraStr            ) {
        super(MessageType.LOG_EQUIP_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.uuid =  uuid;
            this.tempId =  tempId;
            this.enhanceLevel =  enhanceLevel;
            this.fumoLevel =  fumoLevel;
            this.weaponSkillId =  weaponSkillId;
            this.additionAttrStr =  additionAttrStr;
            this.gemStr =  gemStr;
            this.extraStr =  extraStr;
    }

       public String getUuid() {
	       return uuid;
       }
       public int getTempId() {
	       return tempId;
       }
       public int getEnhanceLevel() {
	       return enhanceLevel;
       }
       public int getFumoLevel() {
	       return fumoLevel;
       }
       public int getWeaponSkillId() {
	       return weaponSkillId;
       }
       public String getAdditionAttrStr() {
	       return additionAttrStr;
       }
       public String getGemStr() {
	       return gemStr;
       }
       public String getExtraStr() {
	       return extraStr;
       }
        
       public void setUuid(String uuid) {
	       this.uuid = uuid;
       }
       public void setTempId(int tempId) {
	       this.tempId = tempId;
       }
       public void setEnhanceLevel(int enhanceLevel) {
	       this.enhanceLevel = enhanceLevel;
       }
       public void setFumoLevel(int fumoLevel) {
	       this.fumoLevel = fumoLevel;
       }
       public void setWeaponSkillId(int weaponSkillId) {
	       this.weaponSkillId = weaponSkillId;
       }
       public void setAdditionAttrStr(String additionAttrStr) {
	       this.additionAttrStr = additionAttrStr;
       }
       public void setGemStr(String gemStr) {
	       this.gemStr = gemStr;
       }
       public void setExtraStr(String extraStr) {
	       this.extraStr = extraStr;
       }
    
    @Override
    protected boolean readLogContent() {
	        uuid =  readString();
	        tempId =  readInt();
	        enhanceLevel =  readInt();
	        fumoLevel =  readInt();
	        weaponSkillId =  readInt();
	        additionAttrStr =  readString();
	        gemStr =  readString();
	        extraStr =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(uuid);
	        writeInt(tempId);
	        writeInt(enhanceLevel);
	        writeInt(fumoLevel);
	        writeInt(weaponSkillId);
	        writeString(additionAttrStr);
	        writeString(gemStr);
	        writeString(extraStr);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_EQUIP_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_EQUIP_RECORD";
    }
}