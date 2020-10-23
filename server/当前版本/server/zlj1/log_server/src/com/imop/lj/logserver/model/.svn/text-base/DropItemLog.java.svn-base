package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class DropItemLog extends BaseLogMessage{
       private int fromReason;
       private int dropId;
       private int templateId;
       private String itemName;
       private String fromDetailReason;
    
    public DropItemLog() {    	
    }

    public DropItemLog(
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
			int fromReason,			int dropId,			int templateId,			String itemName,			String fromDetailReason            ) {
        super(MessageType.LOG_DROPITEM_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.fromReason =  fromReason;
            this.dropId =  dropId;
            this.templateId =  templateId;
            this.itemName =  itemName;
            this.fromDetailReason =  fromDetailReason;
    }

       public int getFromReason() {
	       return fromReason;
       }
       public int getDropId() {
	       return dropId;
       }
       public int getTemplateId() {
	       return templateId;
       }
       public String getItemName() {
	       return itemName;
       }
       public String getFromDetailReason() {
	       return fromDetailReason;
       }
        
       public void setFromReason(int fromReason) {
	       this.fromReason = fromReason;
       }
       public void setDropId(int dropId) {
	       this.dropId = dropId;
       }
       public void setTemplateId(int templateId) {
	       this.templateId = templateId;
       }
       public void setItemName(String itemName) {
	       this.itemName = itemName;
       }
       public void setFromDetailReason(String fromDetailReason) {
	       this.fromDetailReason = fromDetailReason;
       }
    
    @Override
    protected boolean readLogContent() {
	        fromReason =  readInt();
	        dropId =  readInt();
	        templateId =  readInt();
	        itemName =  readString();
	        fromDetailReason =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(fromReason);
	        writeInt(dropId);
	        writeInt(templateId);
	        writeString(itemName);
	        writeString(fromDetailReason);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_DROPITEM_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_DROPITEM_RECORD";
    }
}