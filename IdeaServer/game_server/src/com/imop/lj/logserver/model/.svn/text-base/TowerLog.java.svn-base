package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class TowerLog extends BaseLogMessage{
       private int curTowerLevel;
       private int curDoublePoint;
       private int isOpenDouble;
    
    public TowerLog() {    	
    }

    public TowerLog(
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
			int curTowerLevel,			int curDoublePoint,			int isOpenDouble            ) {
        super(MessageType.LOG_TOWER_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.curTowerLevel =  curTowerLevel;
            this.curDoublePoint =  curDoublePoint;
            this.isOpenDouble =  isOpenDouble;
    }

       public int getCurTowerLevel() {
	       return curTowerLevel;
       }
       public int getCurDoublePoint() {
	       return curDoublePoint;
       }
       public int getIsOpenDouble() {
	       return isOpenDouble;
       }
        
       public void setCurTowerLevel(int curTowerLevel) {
	       this.curTowerLevel = curTowerLevel;
       }
       public void setCurDoublePoint(int curDoublePoint) {
	       this.curDoublePoint = curDoublePoint;
       }
       public void setIsOpenDouble(int isOpenDouble) {
	       this.isOpenDouble = isOpenDouble;
       }
    
    @Override
    protected boolean readLogContent() {
	        curTowerLevel =  readInt();
	        curDoublePoint =  readInt();
	        isOpenDouble =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(curTowerLevel);
	        writeInt(curDoublePoint);
	        writeInt(isOpenDouble);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_TOWER_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_TOWER_RECORD";
    }
}