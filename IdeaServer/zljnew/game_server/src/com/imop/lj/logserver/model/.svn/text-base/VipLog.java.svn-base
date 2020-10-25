package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class VipLog extends BaseLogMessage{
       private long vipUuid;
       private long chargeDiamond;
       private int cardId;
       private long receiveOnceRewardId;
       private String oldVipData;
       private String newVipData;
    
    public VipLog() {    	
    }

    public VipLog(
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
			long vipUuid,			long chargeDiamond,			int cardId,			long receiveOnceRewardId,			String oldVipData,			String newVipData            ) {
        super(MessageType.LOG_VIP_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.vipUuid =  vipUuid;
            this.chargeDiamond =  chargeDiamond;
            this.cardId =  cardId;
            this.receiveOnceRewardId =  receiveOnceRewardId;
            this.oldVipData =  oldVipData;
            this.newVipData =  newVipData;
    }

       public long getVipUuid() {
	       return vipUuid;
       }
       public long getChargeDiamond() {
	       return chargeDiamond;
       }
       public int getCardId() {
	       return cardId;
       }
       public long getReceiveOnceRewardId() {
	       return receiveOnceRewardId;
       }
       public String getOldVipData() {
	       return oldVipData;
       }
       public String getNewVipData() {
	       return newVipData;
       }
        
       public void setVipUuid(long vipUuid) {
	       this.vipUuid = vipUuid;
       }
       public void setChargeDiamond(long chargeDiamond) {
	       this.chargeDiamond = chargeDiamond;
       }
       public void setCardId(int cardId) {
	       this.cardId = cardId;
       }
       public void setReceiveOnceRewardId(long receiveOnceRewardId) {
	       this.receiveOnceRewardId = receiveOnceRewardId;
       }
       public void setOldVipData(String oldVipData) {
	       this.oldVipData = oldVipData;
       }
       public void setNewVipData(String newVipData) {
	       this.newVipData = newVipData;
       }
    
    @Override
    protected boolean readLogContent() {
	        vipUuid =  readLong();
	        chargeDiamond =  readLong();
	        cardId =  readInt();
	        receiveOnceRewardId =  readLong();
	        oldVipData =  readString();
	        newVipData =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(vipUuid);
	        writeLong(chargeDiamond);
	        writeInt(cardId);
	        writeLong(receiveOnceRewardId);
	        writeString(oldVipData);
	        writeString(newVipData);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_VIP_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_VIP_RECORD";
    }
}