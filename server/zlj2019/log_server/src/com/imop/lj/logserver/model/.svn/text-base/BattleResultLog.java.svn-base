package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class BattleResultLog extends BaseLogMessage{
       private String battleResult;
       private int battleType;
       private String target;
    
    public BattleResultLog() {    	
    }

    public BattleResultLog(
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
			String battleResult,			int battleType,			String target            ) {
        super(MessageType.LOG_BATTLERESULT_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.battleResult =  battleResult;
            this.battleType =  battleType;
            this.target =  target;
    }

       public String getBattleResult() {
	       return battleResult;
       }
       public int getBattleType() {
	       return battleType;
       }
       public String getTarget() {
	       return target;
       }
        
       public void setBattleResult(String battleResult) {
	       this.battleResult = battleResult;
       }
       public void setBattleType(int battleType) {
	       this.battleType = battleType;
       }
       public void setTarget(String target) {
	       this.target = target;
       }
    
    @Override
    protected boolean readLogContent() {
	        battleResult =  readString();
	        battleType =  readInt();
	        target =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(battleResult);
	        writeInt(battleType);
	        writeString(target);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_BATTLERESULT_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_BATTLERESULT_RECORD";
    }
}