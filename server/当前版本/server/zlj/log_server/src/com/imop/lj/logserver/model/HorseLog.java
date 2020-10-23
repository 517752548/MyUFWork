package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class HorseLog extends BaseLogMessage{
       private int preTrainStar;
       private long preTrainExp;
       private int afterTrainStar;
       private long afterTrainExp;
       private String preDrawSkill;
       private String afterDrawSkill;
    
    public HorseLog() {    	
    }

    public HorseLog(
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
			int preTrainStar,			long preTrainExp,			int afterTrainStar,			long afterTrainExp,			String preDrawSkill,			String afterDrawSkill            ) {
        super(MessageType.LOG_HORSE_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.preTrainStar =  preTrainStar;
            this.preTrainExp =  preTrainExp;
            this.afterTrainStar =  afterTrainStar;
            this.afterTrainExp =  afterTrainExp;
            this.preDrawSkill =  preDrawSkill;
            this.afterDrawSkill =  afterDrawSkill;
    }

       public int getPreTrainStar() {
	       return preTrainStar;
       }
       public long getPreTrainExp() {
	       return preTrainExp;
       }
       public int getAfterTrainStar() {
	       return afterTrainStar;
       }
       public long getAfterTrainExp() {
	       return afterTrainExp;
       }
       public String getPreDrawSkill() {
	       return preDrawSkill;
       }
       public String getAfterDrawSkill() {
	       return afterDrawSkill;
       }
        
       public void setPreTrainStar(int preTrainStar) {
	       this.preTrainStar = preTrainStar;
       }
       public void setPreTrainExp(long preTrainExp) {
	       this.preTrainExp = preTrainExp;
       }
       public void setAfterTrainStar(int afterTrainStar) {
	       this.afterTrainStar = afterTrainStar;
       }
       public void setAfterTrainExp(long afterTrainExp) {
	       this.afterTrainExp = afterTrainExp;
       }
       public void setPreDrawSkill(String preDrawSkill) {
	       this.preDrawSkill = preDrawSkill;
       }
       public void setAfterDrawSkill(String afterDrawSkill) {
	       this.afterDrawSkill = afterDrawSkill;
       }
    
    @Override
    protected boolean readLogContent() {
	        preTrainStar =  readInt();
	        preTrainExp =  readLong();
	        afterTrainStar =  readInt();
	        afterTrainExp =  readLong();
	        preDrawSkill =  readString();
	        afterDrawSkill =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(preTrainStar);
	        writeLong(preTrainExp);
	        writeInt(afterTrainStar);
	        writeLong(afterTrainExp);
	        writeString(preDrawSkill);
	        writeString(afterDrawSkill);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_HORSE_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_HORSE_RECORD";
    }
}