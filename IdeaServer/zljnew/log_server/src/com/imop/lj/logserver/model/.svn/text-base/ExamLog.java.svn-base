package com.imop.lj.logserver.model;
import com.imop.lj.logserver.MessageType;
import com.imop.lj.logserver.BaseLogMessage;

/**
 * This is an auto generated source,please don't modify it.
 */
 
public class ExamLog extends BaseLogMessage{
       private int examId;
       private int indexE;
       private int resultE;
    
    public ExamLog() {    	
    }

    public ExamLog(
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
			int examId,			int indexE,			int resultE            ) {
        super(MessageType.LOG_EXAM_RECORD,logTime,regionId,serverId,accountId,accountName,charId,charName,level,countryId,vipLevel,totalCharge,deviceId,deviceType,deviceVersion,clientVersion,clientLanguage,appid,fValue,reason,param);
            this.examId =  examId;
            this.indexE =  indexE;
            this.resultE =  resultE;
    }

       public int getExamId() {
	       return examId;
       }
       public int getIndexE() {
	       return indexE;
       }
       public int getResultE() {
	       return resultE;
       }
        
       public void setExamId(int examId) {
	       this.examId = examId;
       }
       public void setIndexE(int indexE) {
	       this.indexE = indexE;
       }
       public void setResultE(int resultE) {
	       this.resultE = resultE;
       }
    
    @Override
    protected boolean readLogContent() {
	        examId =  readInt();
	        indexE =  readInt();
	        resultE =  readInt();
        return true;
    }

    @Override
    protected boolean writeLogContent() {
	        writeInt(examId);
	        writeInt(indexE);
	        writeInt(resultE);
        return true;
    }
    
    @Override
    public short getType() {
        return MessageType.LOG_EXAM_RECORD;
    }

    @Override
    public String getTypeName() {
        return "LOG_EXAM_RECORD";
    }
}