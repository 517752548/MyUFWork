package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class MailLog extends BaseLogMessage{
       private String uuid;
       private String senderId;
       private String senderName;
       private String recieverId;
       private String recieverName;
       private String title;
       private int readStatus;
       private long sendTime;
    
    public MailLog() {    	
    }

    public MailLog(
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
			String uuid,			String senderId,			String senderName,			String recieverId,			String recieverName,			String title,			int readStatus,			long sendTime            ) {
        super(MessageType.LOG_MAIL_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.uuid =  uuid;
            this.senderId =  senderId;
            this.senderName =  senderName;
            this.recieverId =  recieverId;
            this.recieverName =  recieverName;
            this.title =  title;
            this.readStatus =  readStatus;
            this.sendTime =  sendTime;
    }

       public String getUuid() {
	       return uuid;
       }
       public String getSenderId() {
	       return senderId;
       }
       public String getSenderName() {
	       return senderName;
       }
       public String getRecieverId() {
	       return recieverId;
       }
       public String getRecieverName() {
	       return recieverName;
       }
       public String getTitle() {
	       return title;
       }
       public int getReadStatus() {
	       return readStatus;
       }
       public long getSendTime() {
	       return sendTime;
       }
        
       public void setUuid(String uuid) {
	       this.uuid = uuid;
       }
       public void setSenderId(String senderId) {
	       this.senderId = senderId;
       }
       public void setSenderName(String senderName) {
	       this.senderName = senderName;
       }
       public void setRecieverId(String recieverId) {
	       this.recieverId = recieverId;
       }
       public void setRecieverName(String recieverName) {
	       this.recieverName = recieverName;
       }
       public void setTitle(String title) {
	       this.title = title;
       }
       public void setReadStatus(int readStatus) {
	       this.readStatus = readStatus;
       }
       public void setSendTime(long sendTime) {
	       this.sendTime = sendTime;
       }
    
    @Override
    protected boolean readLogContent() {
	        uuid =  readString();
	        senderId =  readString();
	        senderName =  readString();
	        recieverId =  readString();
	        recieverName =  readString();
	        title =  readString();
	        readStatus =  readInt();
	        sendTime =  readLong();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(uuid);
	        writeString(senderId);
	        writeString(senderName);
	        writeString(recieverId);
	        writeString(recieverName);
	        writeString(title);
	        writeInt(readStatus);
	        writeLong(sendTime);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_MAIL_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_MAIL_RECORD";
    }
}