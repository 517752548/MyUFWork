package com.renren.games.api.service;

import java.io.*;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.renren.games.api.db.model.QueryOrderEntity;
import net.sf.json.JSONObject;

import org.dom4j.Attribute;
import org.dom4j.Document;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;

@SuppressWarnings("rawtypes")
public class TelnetService {
	protected Map<String, GameServerInfo> gameServerInfos = new HashMap<String, GameServerInfo>();

	protected String gameServerInfoPath;

	public TelnetService(ApiConfig config) {
		this.gameServerInfoPath = config.getGameServerInfopath();
	}

	public void init() throws Exception {
		this.gameServerInfos = this.getGameInfos();
	}

	public void reload() {
		try {
			Map<String,GameServerInfo> _gameServerInfos = this.getGameInfos();
			Loggers.platformlocalLogger.info("Reload Game Server Info: from " + this.gameServerInfos + " to " +_gameServerInfos );
			this.gameServerInfos = _gameServerInfos;
		} catch (Exception e) {
			Loggers.platformlocalLogger.error("reload is failed",e);
			e.printStackTrace();
		}
	}
	
	
	
	public Map<String,GameServerInfo> getGameInfos() throws Exception {
		List<File> fileList = new ArrayList<File>();
		File baseDir = new File(this.gameServerInfoPath);
		File[] files = baseDir.listFiles();
		for (File file : files) {
			fileList.add(file);
		}
		
		Map<String, GameServerInfo> _gameServerInfos = new HashMap<String, GameServerInfo>();
		SAXReader reader = new SAXReader();
		for(File file : fileList){
			Document document = reader.read(file);
			// Element e = document.getRootElement();

			List list = document.selectNodes("/databases/database");
			
			//XXX 游戏服配置与gm一致，第一配置为gameserver的，第二配置为logserver，取xml第一个配置是gameserver配置
			Element element = (Element)list.get(0);
			GameServerInfo info = new GameServerInfo();
			String name = ((Attribute)element.attribute("dbSrvName")).getValue();
			int serverId = Integer.parseInt(((Attribute)element.attribute("svrId")).getValue());
			String telIp = ((Attribute)element.attribute("telIp")).getValue();
			int telnetPort = Integer.parseInt(((Attribute)element.attribute("telPort")).getValue());;
			
			info.setServerId(serverId);
			info.setTelnetIp(telIp);
			info.setTelnetPort(telnetPort);
			info.validate();
			
			_gameServerInfos.put(name, info);
		}
		
		return _gameServerInfos;
	}
	
	public GameServerInfo getGameServerInfoByServerName(String name){
		return this.gameServerInfos.get(name);
	}
	public GameServerInfo getGameServerInfoByServerId(int serverid){
		for (GameServerInfo value : this.gameServerInfos.values()){
			if(value.getServerId()==serverid){
				return value;
			}


			}
		return null;
	}
	/**
	 * 
	 * @param gameServerName
	 * @param params
	 * @return 返回结果
	 */
	public JSONObject sendOrder(String gameServerName,Map<String,String> params){
		JSONObject resultJo = new JSONObject();
//		Map<String,String> resultJo = new HashMap<String,String>();
		GameServerInfo info = this.getGameServerInfoByServerName(gameServerName);
		if(info == null){
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_RET, 9999);
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_MSG, "GameServer not found");
			return resultJo;
		}
		
		JSONObject jo = new JSONObject();
		jo.putAll(params);
		String cmd = "qqcharge content=" + jo.toString();
		List<String> cmdResults = Globals.getCommandService().sendQQCmd(cmd, info, Globals.getQqConfig().getTelnetUserName(), Globals.getQqConfig().getTelnetPassword());
		if(cmdResults == null || cmdResults.size() == 0){
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_RET, 9999);
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_MSG, "cmdResult return null");
			return resultJo;
		}
		
		//获取第一行结果
		String cmdResult = cmdResults.get(0);
		if(CommandService.OK_INFO.equalsIgnoreCase(cmdResult)){
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_RET, 0);
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_MSG, "OK");
			return resultJo;
		}else{
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_RET, 9999);
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_MSG, "cmdResult return null");
			return resultJo;
		}
	}
	public void sendCmd(String cmd,GameServerInfo info){
		if(info == null){
			return;
		}
		String ip = info.getTelnetIp();
		int port = info.getTelnetPort();

		ip = "123.56.177.215";
		port = 7000;
		System.out.println("now order user:"+cmd);
		sendCmd(cmd,ip,port);
	}
	public void sendCmd(String cmd,String ip,int port){
		Socket clientSocket = new Socket();
		List<String> commandList = new ArrayList<String>();
		List<String> resultList = new ArrayList<String>();
		try{
			InetSocketAddress address = new InetSocketAddress(ip,port);
			commandList.add("LOGIN name=test password=test");
			commandList.add(cmd);
			commandList.add("QUIT");
			clientSocket.connect(address,5000);
			BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream(), Charset.forName("UTF-8")));
			PrintWriter out = new PrintWriter(new OutputStreamWriter(clientSocket.getOutputStream(),Charset.forName("UTF-8")));
			while(true){
				if(commandList.size()>0){
					out.println(commandList.get(0));
					System.out.println(commandList.get(0));
					out.flush();
					commandList.remove(0);
				}else{
					break;
				}
				String result = "";
				while((result = in.readLine())!=null){
					if(result.endsWith("begin")){
						continue;
					}else if(result.startsWith("Unknown command")){
						resultList.add("Unknown");
						break;
					}else if(result.endsWith("end")){
						break;
					}resultList.add(result);
				}
			}
		}catch(Exception e){
			Loggers.platformlocalLogger.error(e.toString());

		}finally {
			try{
				clientSocket.close();
			}catch(Exception e){
				e.printStackTrace();
			}finally {
				clientSocket = null;
			}
		}
	}

	public void sendPayBack(String userid,String serverid) {
		String cmd = "PAYBACK "+userid;
		GameServerInfo gameinfo = this.getGameServerInfoByServerId(Integer.parseInt(serverid));
		sendCmd(cmd,gameinfo);
	}

	public void sendPayBack(QueryOrderEntity c){
		String userid = c.getChar_id();
		String serverid = c.getGame_server_domain();
		sendPayBack(userid,serverid);
	}


}
