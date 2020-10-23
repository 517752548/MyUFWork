package com.imop.lj.gm.service.maintenance;

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

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.lj.gm.utils.SpringContext;

/**
 * 命令管理 Service
 *
 * @author lin fan
 *
 */
public class CmdManageService {

	/** CmdManageService LOG */
	private static final Logger logger = LoggerFactory.getLogger("telnet");

	private static SpringContext wac = SpringContext.getInstance();

	private static ExcelLangManagerService lang = (ExcelLangManagerService) (wac
			.getBean("excelLangManagerService"));



	/**
	 * 发送命令
	 *
	 * @param cmd
	 * @param svr
	 * @return 命令结果
	 */
	public List<String> sendCmd(String cmd, DBServer svr,boolean unmodified) {
		long begin = System.currentTimeMillis();
		String uuid = UUID.randomUUID().toString();
		System.out.println("------******************---------"+cmd.toString()+"-------********************-------");
		LoginUser u =  LoginUserService.getLoginUser();
		String name ="";
		if(u!=null){
			name = u.getUsername();
		}
		logger.info(uuid + ":" + "[GM admin]:" + name + "-- send GM Cmd:" + cmd
				+ "  on DBServer:" + svr.getDbServerName()+"   Region ID:" +svr.getRegionId());
		List<String> commandList = new ArrayList<String>();
		List<String> resultList = new ArrayList<String>();
		if(unmodified==false && (!SystemConstants.DB_TYPE.equals(LangUtils.getDBType()))){
			logger.error("DBServer:" + svr.getDbServerName()
					+ lang.readGm(GMLangConstants.TELNET_SLAVE_DB));
			resultList.add("slave");
			return resultList;
		}
		String ip = svr.getTelnetIp();
		Socket clientSocket = new Socket();
		try {
			InetSocketAddress address = new InetSocketAddress(ip,
					Integer.valueOf(svr.getTelnetPort()));
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
			logger.error("DBServer:" + svr.getDbServerName() + "--"
					+ lang.readGm(GMLangConstants.ERR_TELNET_AS_DISCON), e);
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




	/**
	 * 命令窗口发送命令,返回影响结果
	 *
	 * @param cmd
	 *            命令
	 * @param svr
	 *            服务器
	 * @return msg
	 */
	public String sendCmdResult(String cmd, DBServer svr) {
		List<String> resultList = sendCmd(cmd, svr,false);
		return resultList.toString();

//		if (resultList.toString().indexOf("slave") != -1) {
//			return "slave";
//		}
//		if (resultList.toString().indexOf("result=error") != -1) {
//			logger.info("DBServer:" + svr.getDbServerName() + "--"
//					+ lang.readGm(GMLangConstants.CMDFAILED));
//			return "error";
//		} else if (resultList.toString().indexOf("unknown") != -1) {
//			logger.info("DBServer:" + svr.getDbServerName() + "--"
//					+ lang.readGm(GMLangConstants.UNKNOWNCMD));
//			return "unknown";
//		} else if (resultList.toString().indexOf("connect error") != -1) {
//			logger.info("DBServer:" + svr.getDbServerName() + "--"
//					+ lang.readGm(GMLangConstants.UNKNOWNCMD));
//			return "unknown";
//		} else {
//			logger.info("DBServer:" + svr.getDbServerName() + "--"
//					+ lang.readGm(GMLangConstants.CMDSUCCESS));
//			return "ok";
//		}
	}


	/**
	 * 判断某玩家是否在线
	 */
	public boolean isOnline(String id, DBServer svr) {
		boolean result = false;

		JSONObject _o = new JSONObject();
		_o.put("id", id);
		String cmd = "char_status "+_o.toString();
		List<String> resultList = sendCmd(cmd, svr,true);

		if (resultList != null && resultList.toString().indexOf("online") != -1) {
			result = true;
		} else {
			result = false;
		}

		return result;
	}

	/**
	 * 服务器简单列表id
	 *
	 * @return
	 */
	public List<String> getServerIds(DBServer dbsvr) {
		List<String> svrIds = new ArrayList<String>();
		String result = sendCmd("gs_list", dbsvr,true).toString();
		result = result.substring(1, result.length()-1);
		if(result.startsWith("[")){
			JSONArray _arrays = JSONArray.fromObject(result);
			for(int i=0;i<_arrays.size();i++){
				JSONObject _jo = (JSONObject) _arrays.get(i);
				svrIds.add(_jo.getString("id"));
			}
		}
		return svrIds;
	}
}
