package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class TimeLimitMonsterLog extends BaseLogMessage{
       private int curQuestId;
       private int curQuestStatus;
    
    public TimeLimitMonsterLog() {    	
    }

    public TimeLimitMonsterLog(
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
			int curQuestId,			int curQuestStatus            ) {
        super(MessageType.LOG_TIMELIMITMONSTER_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.curQuestId =  curQuestId;
            this.curQuestStatus =  curQuestStatus;
    }

       public int getCurQuestId() {
	       return curQuestId;
       }
       public int getCurQuestStatus() {
	       return curQuestStatus;
       }
        
       public void setCurQuestId(int curQuestId) {
	       this.curQuestId = curQuestId;
       }
       public void setCurQuestStatus(int curQuestStatus) {
	       this.curQuestStatus = curQuestStatus;
       }
    
    @Override
    protected boolean readLogContent() {
	        curQuestId =  readInt();
	        curQuestStatus =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(curQuestId);
	        writeInt(curQuestStatus);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_TIMELIMITMONSTER_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_TIMELIMITMONSTER_RECORD";
    }
}