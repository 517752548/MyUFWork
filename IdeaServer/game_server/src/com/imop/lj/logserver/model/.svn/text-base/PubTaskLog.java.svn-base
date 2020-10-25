package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PubTaskLog extends BaseLogMessage{
       private String backupMap;
       private int curQuestId;
       private int curQuestStatus;
    
    public PubTaskLog() {    	
    }

    public PubTaskLog(
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
			String backupMap,			int curQuestId,			int curQuestStatus            ) {
        super(MessageType.LOG_PUBTASK_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.backupMap =  backupMap;
            this.curQuestId =  curQuestId;
            this.curQuestStatus =  curQuestStatus;
    }

       public String getBackupMap() {
	       return backupMap;
       }
       public int getCurQuestId() {
	       return curQuestId;
       }
       public int getCurQuestStatus() {
	       return curQuestStatus;
       }
        
       public void setBackupMap(String backupMap) {
	       this.backupMap = backupMap;
       }
       public void setCurQuestId(int curQuestId) {
	       this.curQuestId = curQuestId;
       }
       public void setCurQuestStatus(int curQuestStatus) {
	       this.curQuestStatus = curQuestStatus;
       }
    
    @Override
    protected boolean readLogContent() {
	        backupMap =  readString();
	        curQuestId =  readInt();
	        curQuestStatus =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(backupMap);
	        writeInt(curQuestId);
	        writeInt(curQuestStatus);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_PUBTASK_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_PUBTASK_RECORD";
    }
}