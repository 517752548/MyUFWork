package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class MissionLog extends BaseLogMessage{
       private int missionEnemyId;
       private int enemyArmyIndex;
       private int enemyArmyId;
       private int totalRround;
       private int leftRound;
    
    public MissionLog() {    	
    }

    public MissionLog(
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
			int missionEnemyId,			int enemyArmyIndex,			int enemyArmyId,			int totalRround,			int leftRound            ) {
        super(MessageType.LOG_MISSION_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.missionEnemyId =  missionEnemyId;
            this.enemyArmyIndex =  enemyArmyIndex;
            this.enemyArmyId =  enemyArmyId;
            this.totalRround =  totalRround;
            this.leftRound =  leftRound;
    }

       public int getMissionEnemyId() {
	       return missionEnemyId;
       }
       public int getEnemyArmyIndex() {
	       return enemyArmyIndex;
       }
       public int getEnemyArmyId() {
	       return enemyArmyId;
       }
       public int getTotalRround() {
	       return totalRround;
       }
       public int getLeftRound() {
	       return leftRound;
       }
        
       public void setMissionEnemyId(int missionEnemyId) {
	       this.missionEnemyId = missionEnemyId;
       }
       public void setEnemyArmyIndex(int enemyArmyIndex) {
	       this.enemyArmyIndex = enemyArmyIndex;
       }
       public void setEnemyArmyId(int enemyArmyId) {
	       this.enemyArmyId = enemyArmyId;
       }
       public void setTotalRround(int totalRround) {
	       this.totalRround = totalRround;
       }
       public void setLeftRound(int leftRound) {
	       this.leftRound = leftRound;
       }
    
    @Override
    protected boolean readLogContent() {
	        missionEnemyId =  readInt();
	        enemyArmyIndex =  readInt();
	        enemyArmyId =  readInt();
	        totalRround =  readInt();
	        leftRound =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(missionEnemyId);
	        writeInt(enemyArmyIndex);
	        writeInt(enemyArmyId);
	        writeInt(totalRround);
	        writeInt(leftRound);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_MISSION_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_MISSION_RECORD";
    }
}