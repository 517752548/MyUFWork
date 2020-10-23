package com.imop.scribe.receiver;

import org.apache.commons.mail.DefaultAuthenticator;
import org.apache.commons.mail.Email;
import org.apache.commons.mail.EmailException;
import org.apache.commons.mail.SimpleEmail;

/**
 * @author wenping.jiang
 *	用于进行cpu和fullGC的邮件报警
 */
public class Alarm implements Runnable{

	/**
	 * full_gc警报
	 */
	public static final byte FULL_GC = 1;
	
	/**
	 * cpu警报
	 */
	public static final byte CPU = 2;
	
	/**
	 * cpu平均负载
	 */
	public static float cpu_aver;
	/**
	 * fullGC数量
	 */
	public static long fullgc_count;
	
	/**
	 * 邮箱地址
	 */
	public static String[] mailAddress;
	
	/**
	 * 邮箱的smtp服务器
	 */
	public static String mailSmtp;
	
	/**
	 * 邮箱用户名
	 */
	public static String mailName;
	
	/**
	 * 邮箱密码
	 */
	public static String mailPassworld;
	
	/**
	 * 邮件标题
	 */
	private String mailTitle;
	
	/**
	 * 邮件内容
	 */
	private String mailMessage;
	
	/**
	 * 警报类型
	 */
	private byte type;
	
	public Alarm(byte type, String mailTitle, String mailMessage){
		this.type = type;
		this.mailTitle = mailTitle;
		this.mailMessage = mailMessage;
	}
	
	@Override
	public void run() {
		Email email = new SimpleEmail();
		email.setHostName(mailSmtp);
		email.setSmtpPort(25);
		DefaultAuthenticator authenticator = new DefaultAuthenticator(mailName, mailPassworld);
		email.setAuthenticator(authenticator);
		try {
			email.setFrom(mailName + "@renren-inc.com");
			email.setSubject(mailTitle);
			email.setMsg(mailMessage);
			for(int i = 0; i < mailAddress.length; i++){
				email.addTo(mailAddress[i]);
			}
			email.send();
		} catch (EmailException e) {
			e.printStackTrace();
		}
	}

	/**
	 * @param maillAdress
	 * @param mailSmtp
	 * @param mailName
	 * @param mailPassword
	 * 初始化邮件配置
	 */
	public static void initMailConfig(String[] maillAddress, String mailSmtp, String mailName, String mailPassword
			, Float cpu_aver, long fullgc_count){
		Alarm.mailAddress  = maillAddress;
		Alarm.mailSmtp = mailSmtp;
		Alarm.mailName = mailName;
		Alarm.mailPassworld = mailPassword;
		Alarm.cpu_aver = cpu_aver;
		Alarm.fullgc_count = fullgc_count;
	}
	
	public byte getType() {
		return type;
	}

	public void setType(byte type) {
		this.type = type;
	}
}
