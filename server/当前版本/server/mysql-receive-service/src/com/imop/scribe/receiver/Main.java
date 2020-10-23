package com.imop.scribe.receiver;

import java.io.IOException;
import java.io.InputStream;
import java.net.InetSocketAddress;
import java.text.ParseException;
import java.util.Properties;

import org.apache.thrift.server.THsHaServer;
import org.apache.thrift.server.THsHaServer.Options;
import org.apache.thrift.server.TServer;
import org.apache.thrift.transport.TNonblockingServerSocket;
import org.apache.thrift.transport.TNonblockingServerTransport;
import org.quartz.CronTrigger;
import org.quartz.JobDetail;
import org.quartz.Scheduler;
import org.quartz.SchedulerException;
import org.quartz.SchedulerFactory;
import org.quartz.impl.StdSchedulerFactory;

import scribe.thrift.scribe.Processor;

import com.imop.scribe.job.MsgJob;
import com.imop.scribe.receiver.category.Perf;
import com.imop.scribe.receiver.category.Perf2;
import com.imop.scribe.util.CalendarUtil;

/**
 * 
 * @author dongyong.wang
 * 
 */
public class Main {

	static final String CONFIG_NAME = "projects.cfg";
	
	/**
	 * @param args
	 */
	public static void main(String[] argv) {
//		if (argv.length < 3) {
//			System.err.println("Usage: java scribeHandler <host_ip> <port> <maxBufferReadMega>");
//			System.err.println("Eg: java scribeHandler 127.0.0.1 1464 5 ");
//			System.exit(1);
//		}
//		String hostIp = argv[0];
//		int port = Integer.parseInt(argv[1]);
//		int maxBufferReadMega = Integer.parseInt(argv[2]);
		
		String hostIp = "127.0.0.1";
		int port = 1463;
		int maxBufferReadMega = 5;
		
//		String hostIp = "192.168.129.180";
////		int port = 1463;
//		int port = 7890; 
		try {
			SVCList.getInstance();
			
			//自动建表初始化
			CreateTableAuto cta = new CreateTableAuto();
			cta.init();
			
			Processor processor = new Processor(new LogHandler());
			initConfig();
			InetSocketAddress addr = new InetSocketAddress(hostIp, port);
			TNonblockingServerTransport serverTransport = new TNonblockingServerSocket(addr);
			Options ops = new Options();
			
			// 设置readbuffer最大值为5M
			ops.maxReadBufferBytes = maxBufferReadMega * 1024 * 1024;
			
			TServer server = new THsHaServer(processor, serverTransport, ops);
			System.out.println("Starting the server,listen on " + hostIp + ":" + port);
			System.out.println("reading buffer max:" + maxBufferReadMega + " M ");
			server.serve();
		} catch (Exception x) {
			x.printStackTrace();
		}
		System.out.println("done.");
	}

	
	/**
	 * 加载一些工程配置
	 */
	public static void initConfig(){
		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		InputStream resourceAsStream = classLoader.getResourceAsStream(CONFIG_NAME);
		if (resourceAsStream == null) {
			throw new RuntimeException("Cant't find the " +   CONFIG_NAME + ",please put it at the classpath");
		}
		Properties props = new Properties();
		try {
			props.load(resourceAsStream);
			String filePath = props.getProperty("filepath");
			Perf2.filePath = filePath;
			String destFilePath = props.getProperty("destfilepath");
			Perf2.anaysisFilePath = destFilePath;
			String startTime = props.getProperty("msg_analysis_start_time");
			prepareStartMsgAnaysis(startTime);
			
			String mailAddress = props.getProperty("mailaddress");
			String mailSmtp = props.getProperty("smtp");
			String mailName = props.getProperty("mailname");
			String mailPassword = props.getProperty("mailpassword");
			String[] address = mailAddress.split(",");
			for(int i = 0; i < address.length; i++){
				address[i] = address[i].trim();
			}
			String cpuaver = props.getProperty("cpuaver");
			String fuccGCCount = props.getProperty("fullGCcount");
			Float cpu_aver = Float.parseFloat(cpuaver);
			long fullGCCount = Long.parseLong(fuccGCCount);
			Alarm.initMailConfig(address, mailSmtp, mailName, mailPassword,
					cpu_aver, fullGCCount);
			
			String backdoor = props.getProperty("backdoor");
			String[] backdoors = backdoor.split(",");
			Perf.addBackDoor(backdoors);
			Perf.sendMailFlag = props.getProperty("sendMailFlag").equals("true");
			String intervaltime = props.getProperty("mailwarnningIntervaltime");
			Perf.mailwarnningintervaltime = Integer.parseInt(intervaltime);
			
		} catch (IOException e) {
			throw new RuntimeException("load " + CONFIG_NAME + " fail.", e);
		} finally {
			try {
				resourceAsStream.close();
			} catch (IOException e) {
			}
		}
	}
	
	/**
	 * @param startTime
	 * 启动msg分析程序
	 */
	public static void prepareStartMsgAnaysis(String startTime){
		SchedulerFactory factory = new StdSchedulerFactory();
		try {
			Scheduler scheduler = factory.getScheduler();
			scheduler.start();
			JobDetail jobDetail = new JobDetail("Income Anaysis ",
					"Anaysic Generation", MsgJob.class);
			jobDetail.getJobDataMap().put("type", " FULL ");
			CronTrigger trigger = new CronTrigger( "Income Anaysis " ,
				"Anaysic Generation" );
			try {
				trigger.setCronExpression(startTime);
				trigger.setTimeZone(CalendarUtil.getGTMTimeZone());
				scheduler.scheduleJob(jobDetail, trigger);
				System.out.println("msg anaysis started");
			} catch (ParseException e) {
				e.printStackTrace();
			}
		} catch (SchedulerException e) {
			e.printStackTrace();
		} 
	}
}
