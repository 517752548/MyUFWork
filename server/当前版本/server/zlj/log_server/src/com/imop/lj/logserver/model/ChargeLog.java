package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class ChargeLog extends BaseLogMessage{
       private int moneyType;
       private int currencyBefore;
       private int currencyAfter;
       private int mmCost;
       private String result;
       private String transfer;
    
    public ChargeLog() {    	
    }

    public ChargeLog(
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
			int moneyType,			int currencyBefore,			int currencyAfter,			int mmCost,			String result,			String transfer            ) {
        super(MessageType.LOG_CHARGE_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.moneyType =  moneyType;
            this.currencyBefore =  currencyBefore;
            this.currencyAfter =  currencyAfter;
            this.mmCost =  mmCost;
            this.result =  result;
            this.transfer =  transfer;
    }

       public int getMoneyType() {
	       return moneyType;
       }
       public int getCurrencyBefore() {
	       return currencyBefore;
       }
       public int getCurrencyAfter() {
	       return currencyAfter;
       }
       public int getMmCost() {
	       return mmCost;
       }
       public String getResult() {
	       return result;
       }
       public String getTransfer() {
	       return transfer;
       }
        
       public void setMoneyType(int moneyType) {
	       this.moneyType = moneyType;
       }
       public void setCurrencyBefore(int currencyBefore) {
	       this.currencyBefore = currencyBefore;
       }
       public void setCurrencyAfter(int currencyAfter) {
	       this.currencyAfter = currencyAfter;
       }
       public void setMmCost(int mmCost) {
	       this.mmCost = mmCost;
       }
       public void setResult(String result) {
	       this.result = result;
       }
       public void setTransfer(String transfer) {
	       this.transfer = transfer;
       }
    
    @Override
    protected boolean readLogContent() {
	        moneyType =  readInt();
	        currencyBefore =  readInt();
	        currencyAfter =  readInt();
	        mmCost =  readInt();
	        result =  readString();
	        transfer =  readString();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(moneyType);
	        writeInt(currencyBefore);
	        writeInt(currencyAfter);
	        writeInt(mmCost);
	        writeString(result);
	        writeString(transfer);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_CHARGE_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_CHARGE_RECORD";
    }
}