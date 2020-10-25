package com.imop.lj.gm.model.log;

import java.util.List;

import com.imop.lj.gm.utils.DateUtil;

public class MailLog extends BaseLog {
    private String senderId;
    private String senderName;
    private String recieverId;
    private String recieverName;
    private String title;
    private int readStatus;
    private long sendTime;
//    sender_id
//    sender_name
//    reciever_id
//    reciever_name
//    title
//    read_status
//    send_time



	public String getSenderId() {
		return senderId;
	}



	public void setSenderId(String senderId) {
		this.senderId = senderId;
	}



	public String getSenderName() {
		return senderName;
	}



	public void setSenderName(String senderName) {
		this.senderName = senderName;
	}



	public String getRecieverId() {
		return recieverId;
	}



	public void setRecieverId(String recieverId) {
		this.recieverId = recieverId;
	}



	public String getRecieverName() {
		return recieverName;
	}



	public void setRecieverName(String recieverName) {
		this.recieverName = recieverName;
	}



	public String getTitle() {
		return title;
	}



	public void setTitle(String title) {
		this.title = title;
	}



	public int getReadStatus() {
		return readStatus;
	}



	public void setReadStatus(int readStatus) {
		this.readStatus = readStatus;
	}



	public long getSendTime() {
		return sendTime;
	}



	public void setSendTime(long sendTime) {
		this.sendTime = sendTime;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(senderId);
		list.add(senderName);
		list.add(recieverId);
		list.add(recieverName);
		list.add(title);
		list.add(readStatus);
		list.add(DateUtil.formateDateLong(sendTime));
		return list;
	}
}
