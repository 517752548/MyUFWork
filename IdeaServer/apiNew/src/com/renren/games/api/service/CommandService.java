package com.renren.games.api.service;

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

import org.slf4j.Logger;

import com.renren.games.api.core.Loggers;

public class CommandService {
	Logger logger = Loggers.platformlocalLogger;
	
	public static String BEGIN_INFO = "begin";
	
	public static String END_INFO = "end";
	
	public static String UNKOWN_INFO = "Unknown command";
	
	public static String ERROR_INFO = "error";
	
	public static String OK_INFO = "ok";
	
	/**
	 * 过期时间
	 */
	public static int CONNECT_TIME_OUT = 1 * 1000;
	
	/**
	 * 
	 * @param loginCommand
	 * @param cmd
	 * @param info
	 * @param name
	 * @param password
	 * @return
	 */
	protected List<String> sendCmd(String loginCommand,String cmd, GameServerInfo info,String name,String password){
		System.out.println("------******************---------" + cmd.toString() + "-------********************-------");
		logger.info("[GM admin]:" + "api" + "-- send GM Cmd:" + cmd + "  on GameServer:" + info);
		List<String> commandList = new ArrayList<String>();
		List<String> resultList = new ArrayList<String>();

		String ip = info.getTelnetIp();
		Socket clientSocket = new Socket();
		try {
			InetSocketAddress address = new InetSocketAddress(ip, Integer.valueOf(info.getTelnetPort()));
			commandList.add( loginCommand + " name=" + name + " password=" + password);
			commandList.add(cmd);
			commandList.add("Quit");
			clientSocket.connect(address, CommandService.CONNECT_TIME_OUT);
			BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream(), Charset.forName("UTF-8")));
			PrintWriter out = new PrintWriter(new OutputStreamWriter(clientSocket.getOutputStream(), Charset.forName("UTF-8")));
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
					if (result.endsWith(CommandService.BEGIN_INFO)) {
						continue;
					} else if (result.startsWith(CommandService.UNKOWN_INFO)) {
						resultList.add(CommandService.UNKOWN_INFO);
						break;
					} else if (result.endsWith(CommandService.END_INFO)) {
						break;
					} else {
						resultList.add(result);
					}
				}
			}

		} catch (Exception e) {
			logger.error("GameServer:" + info, e);
			resultList.add(CommandService.ERROR_INFO);
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

		return resultList;
	}

	/**
	 * 
	 * @param cmd
	 * @param info
	 * @param name
	 * @param password
	 * @return
	 */
	public List<String> sendQQCmd(String cmd, GameServerInfo info,String name,String password) {
		return this.sendCmd("QQLOGIN", cmd, info, name, password);
	}
	
	
}
