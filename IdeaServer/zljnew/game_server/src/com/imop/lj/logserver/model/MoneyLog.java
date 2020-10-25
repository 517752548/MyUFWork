package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class MoneyLog extends BaseLogMessage{
       private int mainCurrency;
       private long mainDelta;
       private long mainCurrLeft;
       private int altCurrency;
       private long altDelta;
       private long altCurrLeft;
       private int thirdCurrency;
       private long thirdDelta;
       private long thirdCurrLeft;
    
    public MoneyLog() {    	
    }

    public MoneyLog(
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
			int mainCurrency,			long mainDelta,			long mainCurrLeft,			int altCurrency,			long altDelta,			long altCurrLeft,			int thirdCurrency,			long thirdDelta,			long thirdCurrLeft            ) {
        super(MessageType.LOG_MONEY_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.mainCurrency =  mainCurrency;
            this.mainDelta =  mainDelta;
            this.mainCurrLeft =  mainCurrLeft;
            this.altCurrency =  altCurrency;
            this.altDelta =  altDelta;
            this.altCurrLeft =  altCurrLeft;
            this.thirdCurrency =  thirdCurrency;
            this.thirdDelta =  thirdDelta;
            this.thirdCurrLeft =  thirdCurrLeft;
    }

       public int getMainCurrency() {
	       return mainCurrency;
       }
       public long getMainDelta() {
	       return mainDelta;
       }
       public long getMainCurrLeft() {
	       return mainCurrLeft;
       }
       public int getAltCurrency() {
	       return altCurrency;
       }
       public long getAltDelta() {
	       return altDelta;
       }
       public long getAltCurrLeft() {
	       return altCurrLeft;
       }
       public int getThirdCurrency() {
	       return thirdCurrency;
       }
       public long getThirdDelta() {
	       return thirdDelta;
       }
       public long getThirdCurrLeft() {
	       return thirdCurrLeft;
       }
        
       public void setMainCurrency(int mainCurrency) {
	       this.mainCurrency = mainCurrency;
       }
       public void setMainDelta(long mainDelta) {
	       this.mainDelta = mainDelta;
       }
       public void setMainCurrLeft(long mainCurrLeft) {
	       this.mainCurrLeft = mainCurrLeft;
       }
       public void setAltCurrency(int altCurrency) {
	       this.altCurrency = altCurrency;
       }
       public void setAltDelta(long altDelta) {
	       this.altDelta = altDelta;
       }
       public void setAltCurrLeft(long altCurrLeft) {
	       this.altCurrLeft = altCurrLeft;
       }
       public void setThirdCurrency(int thirdCurrency) {
	       this.thirdCurrency = thirdCurrency;
       }
       public void setThirdDelta(long thirdDelta) {
	       this.thirdDelta = thirdDelta;
       }
       public void setThirdCurrLeft(long thirdCurrLeft) {
	       this.thirdCurrLeft = thirdCurrLeft;
       }
    
    @Override
    protected boolean readLogContent() {
	        mainCurrency =  readInt();
	        mainDelta =  readLong();
	        mainCurrLeft =  readLong();
	        altCurrency =  readInt();
	        altDelta =  readLong();
	        altCurrLeft =  readLong();
	        thirdCurrency =  readInt();
	        thirdDelta =  readLong();
	        thirdCurrLeft =  readLong();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(mainCurrency);
	        writeLong(mainDelta);
	        writeLong(mainCurrLeft);
	        writeInt(altCurrency);
	        writeLong(altDelta);
	        writeLong(altCurrLeft);
	        writeInt(thirdCurrency);
	        writeLong(thirdDelta);
	        writeLong(thirdCurrLeft);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_MONEY_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_MONEY_RECORD";
    }
}