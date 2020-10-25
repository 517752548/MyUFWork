package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class TaskLog extends BaseLogMessage{
       private int task_id;
    
    public TaskLog() {    	
    }

    public TaskLog(
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
			int task_id            ) {
        super(MessageType.LOG_TASK_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.task_id =  task_id;
    }

       public int getTask_id() {
	       return task_id;
       }
        
       public void setTask_id(int task_id) {
	       this.task_id = task_id;
       }
    
    @Override
    protected boolean readLogContent() {
	        task_id =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(task_id);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_TASK_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_TASK_RECORD";
    }
}