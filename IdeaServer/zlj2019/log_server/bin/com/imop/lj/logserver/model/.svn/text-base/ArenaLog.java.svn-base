package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class ArenaLog extends BaseLogMessage{
       private String battleResult;
       private long attackerId;
       private int attackerBeforeCwinTimes;
       private int attackerAfterCwinTimes;
       private int attackerBeforeRank;
       private int attackerAfterRank;
       private long defenderId;
       private int defenderBeforeCwinTimes;
       private int defenderAfterCwinTimes;
       private int defenderBeforeRank;
       private int defenderAfterRank;
    
    public ArenaLog() {    	
    }

    public ArenaLog(
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
			String battleResult,			long attackerId,			int attackerBeforeCwinTimes,			int attackerAfterCwinTimes,			int attackerBeforeRank,			int attackerAfterRank,			long defenderId,			int defenderBeforeCwinTimes,			int defenderAfterCwinTimes,			int defenderBeforeRank,			int defenderAfterRank            ) {
        super(MessageType.LOG_ARENA_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.battleResult =  battleResult;
            this.attackerId =  attackerId;
            this.attackerBeforeCwinTimes =  attackerBeforeCwinTimes;
            this.attackerAfterCwinTimes =  attackerAfterCwinTimes;
            this.attackerBeforeRank =  attackerBeforeRank;
            this.attackerAfterRank =  attackerAfterRank;
            this.defenderId =  defenderId;
            this.defenderBeforeCwinTimes =  defenderBeforeCwinTimes;
            this.defenderAfterCwinTimes =  defenderAfterCwinTimes;
            this.defenderBeforeRank =  defenderBeforeRank;
            this.defenderAfterRank =  defenderAfterRank;
    }

       public String getBattleResult() {
	       return battleResult;
       }
       public long getAttackerId() {
	       return attackerId;
       }
       public int getAttackerBeforeCwinTimes() {
	       return attackerBeforeCwinTimes;
       }
       public int getAttackerAfterCwinTimes() {
	       return attackerAfterCwinTimes;
       }
       public int getAttackerBeforeRank() {
	       return attackerBeforeRank;
       }
       public int getAttackerAfterRank() {
	       return attackerAfterRank;
       }
       public long getDefenderId() {
	       return defenderId;
       }
       public int getDefenderBeforeCwinTimes() {
	       return defenderBeforeCwinTimes;
       }
       public int getDefenderAfterCwinTimes() {
	       return defenderAfterCwinTimes;
       }
       public int getDefenderBeforeRank() {
	       return defenderBeforeRank;
       }
       public int getDefenderAfterRank() {
	       return defenderAfterRank;
       }
        
       public void setBattleResult(String battleResult) {
	       this.battleResult = battleResult;
       }
       public void setAttackerId(long attackerId) {
	       this.attackerId = attackerId;
       }
       public void setAttackerBeforeCwinTimes(int attackerBeforeCwinTimes) {
	       this.attackerBeforeCwinTimes = attackerBeforeCwinTimes;
       }
       public void setAttackerAfterCwinTimes(int attackerAfterCwinTimes) {
	       this.attackerAfterCwinTimes = attackerAfterCwinTimes;
       }
       public void setAttackerBeforeRank(int attackerBeforeRank) {
	       this.attackerBeforeRank = attackerBeforeRank;
       }
       public void setAttackerAfterRank(int attackerAfterRank) {
	       this.attackerAfterRank = attackerAfterRank;
       }
       public void setDefenderId(long defenderId) {
	       this.defenderId = defenderId;
       }
       public void setDefenderBeforeCwinTimes(int defenderBeforeCwinTimes) {
	       this.defenderBeforeCwinTimes = defenderBeforeCwinTimes;
       }
       public void setDefenderAfterCwinTimes(int defenderAfterCwinTimes) {
	       this.defenderAfterCwinTimes = defenderAfterCwinTimes;
       }
       public void setDefenderBeforeRank(int defenderBeforeRank) {
	       this.defenderBeforeRank = defenderBeforeRank;
       }
       public void setDefenderAfterRank(int defenderAfterRank) {
	       this.defenderAfterRank = defenderAfterRank;
       }
    
    @Override
    protected boolean readLogContent() {
	        battleResult =  readString();
	        attackerId =  readLong();
	        attackerBeforeCwinTimes =  readInt();
	        attackerAfterCwinTimes =  readInt();
	        attackerBeforeRank =  readInt();
	        attackerAfterRank =  readInt();
	        defenderId =  readLong();
	        defenderBeforeCwinTimes =  readInt();
	        defenderAfterCwinTimes =  readInt();
	        defenderBeforeRank =  readInt();
	        defenderAfterRank =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeString(battleResult);
	        writeLong(attackerId);
	        writeInt(attackerBeforeCwinTimes);
	        writeInt(attackerAfterCwinTimes);
	        writeInt(attackerBeforeRank);
	        writeInt(attackerAfterRank);
	        writeLong(defenderId);
	        writeInt(defenderBeforeCwinTimes);
	        writeInt(defenderAfterCwinTimes);
	        writeInt(defenderBeforeRank);
	        writeInt(defenderAfterRank);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_ARENA_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_ARENA_RECORD";
    }
}