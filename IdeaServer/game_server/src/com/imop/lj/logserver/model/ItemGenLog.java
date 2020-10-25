package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class ItemGenLog extends BaseLogMessage{
       private int templateId;
       private String itemName;
       private int count;
       private long deadline;
       private String properties;
       private String itemGenId;
    
    public ItemGenLog() {    	
    }

    public ItemGenLog(
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
			int templateId,			String itemName,			int count,			long deadline,			String properties,			String itemGenId            ) {
        super(MessageType.LOG_ITEMGEN_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.templateId =  templateId;
            this.itemName =  itemName;
            this.count =  count;
            this.deadline =  deadline;
            this.properties =  properties;
            this.itemGenId =  itemGenId;
    }

       public int getTemplateId() {
	       return templateId;
       }
       public String getItemName() {
	       return itemName;
       }
       public int getCount() {
	       return count;
       }
       public long getDeadline() {
	       return deadline;
       }
       public String getProperties() {
	       return properties;
       }
       public String getItemGenId() {
	       return itemGenId;
       }
        
       public void setTemplateId(int templateId) {
	       this.templateId = templateId;
       }
       public void setItemName(String itemName) {
	       this.itemName = itemName;
       }
       public void setCount(int count) {
	       this.count = count;
       }
       public void setDeadline(long deadline) {
	       this.deadline = deadline;
       }
       public void setProperties(String properties) {
	       this.properties = properties;
       }
       public void setItemGenId(String itemGenId) {
	       this.itemGenId = itemGenId;
       }
    
    @Override
    protected boolean readLogContent() {
	        templateId =  readInt();
	        itemName =  readString();
	        count =  readInt();
	        deadline =  readLong();
	        properties =  readString();
	        itemGenId =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(templateId);
	        writeString(itemName);
	        writeInt(count);
	        writeLong(deadline);
	        writeString(properties);
	        writeString(itemGenId);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_ITEMGEN_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_ITEMGEN_RECORD";
    }
}