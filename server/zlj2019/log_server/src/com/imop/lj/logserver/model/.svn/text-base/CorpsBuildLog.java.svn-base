package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class CorpsBuildLog extends BaseLogMessage{
       private long corpsId;
       private String corpsName;
       private int corpsLevel;
       private int memberNum;
       private long currExp;
       private long curFund;
    
    public CorpsBuildLog() {    	
    }

    public CorpsBuildLog(
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
			long corpsId,			String corpsName,			int corpsLevel,			int memberNum,			long currExp,			long curFund            ) {
        super(MessageType.LOG_CORPSBUILD_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.corpsId =  corpsId;
            this.corpsName =  corpsName;
            this.corpsLevel =  corpsLevel;
            this.memberNum =  memberNum;
            this.currExp =  currExp;
            this.curFund =  curFund;
    }

       public long getCorpsId() {
	       return corpsId;
       }
       public String getCorpsName() {
	       return corpsName;
       }
       public int getCorpsLevel() {
	       return corpsLevel;
       }
       public int getMemberNum() {
	       return memberNum;
       }
       public long getCurrExp() {
	       return currExp;
       }
       public long getCurFund() {
	       return curFund;
       }
        
       public void setCorpsId(long corpsId) {
	       this.corpsId = corpsId;
       }
       public void setCorpsName(String corpsName) {
	       this.corpsName = corpsName;
       }
       public void setCorpsLevel(int corpsLevel) {
	       this.corpsLevel = corpsLevel;
       }
       public void setMemberNum(int memberNum) {
	       this.memberNum = memberNum;
       }
       public void setCurrExp(long currExp) {
	       this.currExp = currExp;
       }
       public void setCurFund(long curFund) {
	       this.curFund = curFund;
       }
    
    @Override
    protected boolean readLogContent() {
	        corpsId =  readLong();
	        corpsName =  readString();
	        corpsLevel =  readInt();
	        memberNum =  readInt();
	        currExp =  readLong();
	        curFund =  readLong();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(corpsId);
	        writeString(corpsName);
	        writeInt(corpsLevel);
	        writeInt(memberNum);
	        writeLong(currExp);
	        writeLong(curFund);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_CORPSBUILD_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_CORPSBUILD_RECORD";
    }
}