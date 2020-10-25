package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class RewardLog extends BaseLogMessage{
       private long createRewardCharId;
       private String rewardUuid;
       private int exp;
       private String currencyInfos;
       private String itemInfos;
       private String otherInfos;
    
    public RewardLog() {    	
    }

    public RewardLog(
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
			long createRewardCharId,			String rewardUuid,			int exp,			String currencyInfos,			String itemInfos,			String otherInfos            ) {
        super(MessageType.LOG_REWARD_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.createRewardCharId =  createRewardCharId;
            this.rewardUuid =  rewardUuid;
            this.exp =  exp;
            this.currencyInfos =  currencyInfos;
            this.itemInfos =  itemInfos;
            this.otherInfos =  otherInfos;
    }

       public long getCreateRewardCharId() {
	       return createRewardCharId;
       }
       public String getRewardUuid() {
	       return rewardUuid;
       }
       public int getExp() {
	       return exp;
       }
       public String getCurrencyInfos() {
	       return currencyInfos;
       }
       public String getItemInfos() {
	       return itemInfos;
       }
       public String getOtherInfos() {
	       return otherInfos;
       }
        
       public void setCreateRewardCharId(long createRewardCharId) {
	       this.createRewardCharId = createRewardCharId;
       }
       public void setRewardUuid(String rewardUuid) {
	       this.rewardUuid = rewardUuid;
       }
       public void setExp(int exp) {
	       this.exp = exp;
       }
       public void setCurrencyInfos(String currencyInfos) {
	       this.currencyInfos = currencyInfos;
       }
       public void setItemInfos(String itemInfos) {
	       this.itemInfos = itemInfos;
       }
       public void setOtherInfos(String otherInfos) {
	       this.otherInfos = otherInfos;
       }
    
    @Override
    protected boolean readLogContent() {
	        createRewardCharId =  readLong();
	        rewardUuid =  readString();
	        exp =  readInt();
	        currencyInfos =  readString();
	        itemInfos =  readString();
	        otherInfos =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(createRewardCharId);
	        writeString(rewardUuid);
	        writeInt(exp);
	        writeString(currencyInfos);
	        writeString(itemInfos);
	        writeString(otherInfos);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_REWARD_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_REWARD_RECORD";
    }
}