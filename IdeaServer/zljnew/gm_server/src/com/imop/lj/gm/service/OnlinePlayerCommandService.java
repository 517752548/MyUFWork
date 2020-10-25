package com.imop.lj.gm.service;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.slf4j.Logger;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsSecretaryLoadService;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.lj.gm.utils.SpringContext;
import com.imop.lj.gm.web.activity.service.GMGlobals;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月11日 下午12:24:59
 * @version 1.0
 */
@Deprecated
public class OnlinePlayerCommandService {

	/**db log */
	private Logger logger = GMGlobals.logger;
	
	private static SpringContext wac = SpringContext.getInstance();
	private static ExcelLangManagerService lang = (ExcelLangManagerService) (wac
			.getBean("excelLangManagerService"));
	
	private XlsSecretaryLoadService xlsSecretaryLoadService;
	private ExcelLangManagerService excelLangManagerService;

	public XlsSecretaryLoadService getXlsSecretaryLoadService() {
		return xlsSecretaryLoadService;
	}
	public void setXlsSecretaryLoadService(
			XlsSecretaryLoadService xlsSecretaryLoadService) {
		this.xlsSecretaryLoadService = xlsSecretaryLoadService;
	}
	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}
	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}
	
	
	//发送到gameserver
	public String sendCommandStrToGameServer(DBServer dBServer,String cmdstr) {
		List<String> result = new ArrayList<String>();
		try{
			 result = sendCmd(cmdstr, dBServer, true);
		}catch(Exception e){
			logger.info("OnlinePlayerCommandService.sendCommandStrToGameServer() ExceptionName=" + e.getClass().getName()
					+ " Exception =" + e.getMessage()
					+ " serverName=" + dBServer.getDbServerName()
					+ " servicerId="	+ dBServer.getServerId()
					+ " regionId="+ dBServer.getRegionId()+" cmd="+cmdstr);
		}
		return result.toString();
	}
	
	
	public List<String> sendCmd(String cmd, DBServer svr, boolean unmodified) {
		long begin = System.currentTimeMillis();
		String uuid = UUID.randomUUID().toString();
		logger.info("OnlinePlayerCommand#start-----******************---------"+cmd.toString()+"-------********************-------");
		LoginUser u =  LoginUserService.getLoginUser();
		String name ="";
		if(u!=null){
			name = u.getUsername();
		}
		List<String> commandList = new ArrayList<String>();
		List<String> resultList = new ArrayList<String>();
		if(unmodified==false && (!SystemConstants.DB_TYPE.equals(LangUtils.getDBType()))){
			logger.error("DBServer:" + svr.getDbServerName() + lang.readGm(GMLangConstants.TELNET_SLAVE_DB));
			resultList.add("save");
			logger.info("OnlinePlayerCommand#return!unmodified = " + unmodified + ", SystemConstants.DB_TYPE=" + SystemConstants.DB_TYPE);
			return resultList;
		}
		logger.info("OnlinePlayerCommand#uuid =" + uuid + ":" + "[GM admin]:" + name + "-- send GM Cmd:" + cmd
				+ "  on DBServer:" + svr.getDbServerName()+"   Region ID:" +svr.getRegionId());
		String ip = svr.getTelnetIp();
		Socket clientSocket = new Socket();
		try {
			InetSocketAddress address = new InetSocketAddress(ip, Integer.valueOf(svr.getTelnetPort()));
			commandList.add("LOGIN name=test password=test");
			commandList.add(cmd);
			commandList.add("Quit");
			clientSocket.connect(address, 5000);
			BufferedReader in = new BufferedReader(new InputStreamReader(
					clientSocket.getInputStream(),Charset.forName("UTF-8")));
			PrintWriter out = new PrintWriter(new OutputStreamWriter(clientSocket.getOutputStream(),Charset.forName("UTF-8")));
			while (true) {
				if (commandList.size() > 0) {
					out.println(commandList.get(0));
					out.flush();
					commandList.remove(0);
				} else {
					break;
				}
				String result = null;
				while ((result = in.readLine()) != null) {
					if (result.endsWith("begin")) {
						continue;
					} else if (result.startsWith("Unknown command")) {
						resultList.add("unknown");
						break;
					} else if (result.endsWith("end")) {
						break;
					} else {
						resultList.add(result);
					}
				}
			}
		} catch (Exception e) {
			logger.error("DBServer:" + svr.getDbServerName() + "--"	+ lang.readGm(GMLangConstants.ERR_TELNET_AS_DISCON), e);
			resultList.add("connect error");
			return resultList;

		} finally {
			try {
				clientSocket.close();
			} catch (IOException e) {
				logger.error("IOException", e.getMessage());
			} finally {
				clientSocket = null;
			}
		}
		long end = System.currentTimeMillis();
		logger.info(uuid + ":" + (end-begin) + "ms");
		return resultList;

	}
}
