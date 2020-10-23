package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class ItemCostRecordLog extends BaseLogMessage{
       private long originalFreeNum;
       private long originalItemNum;
       private long originalTotalCost;
       private long originalActualCost;
       private long freeNum;
       private long itemNum;
       private long totalCost;
       private long actualCost;
    
    public ItemCostRecordLog() {    	
    }

    public ItemCostRecordLog(
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
			long originalFreeNum,			long originalItemNum,			long originalTotalCost,			long originalActualCost,			long freeNum,			long itemNum,			long totalCost,			long actualCost            ) {
        super(MessageType.LOG_ITEMCOSTRECORD_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.originalFreeNum =  originalFreeNum;
            this.originalItemNum =  originalItemNum;
            this.originalTotalCost =  originalTotalCost;
            this.originalActualCost =  originalActualCost;
            this.freeNum =  freeNum;
            this.itemNum =  itemNum;
            this.totalCost =  totalCost;
            this.actualCost =  actualCost;
    }

       public long getOriginalFreeNum() {
	       return originalFreeNum;
       }
       public long getOriginalItemNum() {
	       return originalItemNum;
       }
       public long getOriginalTotalCost() {
	       return originalTotalCost;
       }
       public long getOriginalActualCost() {
	       return originalActualCost;
       }
       public long getFreeNum() {
	       return freeNum;
       }
       public long getItemNum() {
	       return itemNum;
       }
       public long getTotalCost() {
	       return totalCost;
       }
       public long getActualCost() {
	       return actualCost;
       }
        
       public void setOriginalFreeNum(long originalFreeNum) {
	       this.originalFreeNum = originalFreeNum;
       }
       public void setOriginalItemNum(long originalItemNum) {
	       this.originalItemNum = originalItemNum;
       }
       public void setOriginalTotalCost(long originalTotalCost) {
	       this.originalTotalCost = originalTotalCost;
       }
       public void setOriginalActualCost(long originalActualCost) {
	       this.originalActualCost = originalActualCost;
       }
       public void setFreeNum(long freeNum) {
	       this.freeNum = freeNum;
       }
       public void setItemNum(long itemNum) {
	       this.itemNum = itemNum;
       }
       public void setTotalCost(long totalCost) {
	       this.totalCost = totalCost;
       }
       public void setActualCost(long actualCost) {
	       this.actualCost = actualCost;
       }
    
    @Override
    protected boolean readLogContent() {
	        originalFreeNum =  readLong();
	        originalItemNum =  readLong();
	        originalTotalCost =  readLong();
	        originalActualCost =  readLong();
	        freeNum =  readLong();
	        itemNum =  readLong();
	        totalCost =  readLong();
	        actualCost =  readLong();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeLong(originalFreeNum);
	        writeLong(originalItemNum);
	        writeLong(originalTotalCost);
	        writeLong(originalActualCost);
	        writeLong(freeNum);
	        writeLong(itemNum);
	        writeLong(totalCost);
	        writeLong(actualCost);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_ITEMCOSTRECORD_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_ITEMCOSTRECORD_RECORD";
    }
}