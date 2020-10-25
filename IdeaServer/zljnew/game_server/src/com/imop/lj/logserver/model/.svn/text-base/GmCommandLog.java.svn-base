package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class GmCommandLog extends BaseLogMessage{
       private String operatorName;
       private String targetIp;
       private String command;
       private String commandDesc;
       private String commandDetail;
       private String returnResult;
    
    public GmCommandLog() {    	
    }

    public GmCommandLog(
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
			String operatorName,			String targetIp,			String command,			String commandDesc,			String commandDetail,			String returnResult            ) {
        super(MessageType.LOG_GMCOMMAND_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.operatorName =  operatorName;
            this.targetIp =  targetIp;
            this.command =  command;
            this.commandDesc =  commandDesc;
            this.commandDetail =  commandDetail;
            this.returnResult =  returnResult;
    }

       public String getOperatorName() {
	       return operatorName;
       }
       public String getTargetIp() {
	       return targetIp;
       }
       public String getCommand() {
	       return command;
       }
       public String getCommandDesc() {
	       return commandDesc;
       }
       public String getCommandDetail() {
	       return commandDetail;
       }
       public String getReturnResult() {
	       return returnResult;
       }
        
       public void setOperatorName(String operatorName) {
	       this.operatorName = operatorName;
       }
       public void setTargetIp(String targetIp) {
	       this.targetIp = targetIp;
       }
       public void setCommand(String command) {
	       this.command = command;
       }
       public void setCommandDesc(String commandDesc) {
	       this.commandDesc = commandDesc;
       }
       public void setCommandDetail(String commandDetail) {
	       this.commandDetail = commandDetail;
       }
       public void setReturnResult(String returnResult) {
	       this.returnResult = returnResult;
       }
    
    @Override
    protected boolean readLogContent() {
	        operatorName =  readString();
	        targetIp =  readString();
	        command =  readString();
	        commandDesc =  readString();
	        commandDetail =  readString();
	        returnResult =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(operatorName);
	        writeString(targetIp);
	        writeString(command);
	        writeString(commandDesc);
	        writeString(commandDetail);
	        writeString(returnResult);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_GMCOMMAND_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_GMCOMMAND_RECORD";
    }
}