package com.imop.lj.gameserver.player.async;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.LoginTypeEnum;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.collector.util.data.DataUtil;
import com.imop.platform.local.bean.ReportForDGBean;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2013年12月13日 下午2:06:50
 * @version 1.0
 */

public class PlayerLocalHelper {

	/**
	 * log 版本号
	 */
	private final static String LOG_VERSION = "1.1";

	public static ReportForDGBean createGameLoginReportLoginIn(Player player) {
		return buildGameLoginReport(player, "login");
	}

	public static ReportForDGBean createGameLoginReportLoginOut(Player player) {
		return buildGameLoginReport(player, "logout");
	}

	protected static ReportForDGBean buildGameLoginReport(Player player,
			String loginAction) {
		ReportForDGBean reportForDGBean = new ReportForDGBean();
		try {
			// 日志协议版本号
			String log_version = LOG_VERSION;
			// 系统时间
			long log_timestamp = System.currentTimeMillis();
			// UTC标准时间
			String log_utctime = DataUtil.getUTCTimeStrAsDate();
			// 服务器所在地域时间（即当地时间）
			String log_localtime = DataUtil.getLocalTimeStrAsDate();
			// 服务器主机名
			String log_hostname = Globals.getServerConfig().getServerName();
			// 服务器IP地址
			String log_server_ip = Globals.getServerConfig().getServerHost();
			// 客户端IP地址
			String log_client_ip = player.getClientIp();
			if(!StringUtils.isEmpty(log_client_ip) && log_client_ip.contains(":")) {
				log_client_ip = log_client_ip.split(":")[0];
			}
			// 日志类型
			String log_type = "data.game.login";
			// 可选 日志记录的唯一编号
			// int log_serial_no = "";
			// 可选， 缺省为空串，可以随意记录任何数据
			String log_note = "";
			// 汇报代理
			String log_agent = player.getLogAgent();
//			if(player.getCurrTerminalType() == TerminalTypeEnum.WEB) {
//				log_agent = "game-server-" + Globals.getServerConfig().getGameId();
//			}
			// 游戏id
			String game_id = Globals.getServerConfig().getGameId();
			// 运营平台id
			String platform_id = Globals.getServerConfig().getPlatformName();
			// 运营大区id
			String region_id = Globals.getServerConfig().getRegionId();
			// 服务器id
			String server_id = Globals.getServerConfig().getServerId();
			// 服务器名
			String server_name = Globals.getServerConfig().getServerName();
			// 服务器域名
			String server_domain = Globals.getServerConfig().getServerDomain();
			// 账号id
			String account_id = player.getPassportId();
			// 账号名称
			String account_name = player.getPassportName();
			// 终端设备 "pc, ios, android";
			String device = player.getDeviceID();
			if (player.getCurrTerminalType() == TerminalTypeEnum.WEB) {
				device = "pc";
			}
			// 终端分类
			String device_type = player.getDeviceType();
			if (player.getCurrTerminalType() == TerminalTypeEnum.WEB) {
				device_type = "-1";
			}
			// 操作系统版本，IOS和Android的版本，PC类型此项设置为-1
			String device_version = player.getDeviceVersion();
			if (player.getCurrTerminalType() == TerminalTypeEnum.WEB) {
				device_version = -1 + "";
			}
			// 设备唯一识别id
			String device_guid = player.getDeviceGuid();
			if (player.getCurrTerminalType() == TerminalTypeEnum.WEB) {
				device_guid = -1 + "";
			}
			// MAC地址
			String device_mac = player.getDeviceMac().replace(":", "");
			// IMEI串号
			String device_imei = player.getDeviceImei();
			// UDID
			String device_udid = player.getDeviceUdid();
			// ISO IDFA
			String device_idfa = player.getDeviceIdfa();
			// ISO IDFV
			String device_idfv = player.getDeviceIdfv();
			// 客户端代理串
			String device_user_agent = player.getDeviceUserAgent();
			// 接入网络方式 wifi/3g/2g/wwan 无法获取网络环境写 -1；
			String device_connect_type = player.getDeviceConnectType();
			// 是否越狱
			int device_jailbroken = player.getDeviceJailbroken();
			if(player.getCurrTerminalType() == TerminalTypeEnum.WEB 
					&& -1 != device_jailbroken) {
				device_jailbroken = -1;
			}
			// 登录行为 1 = login；2 = logout
			String login_action = loginAction;
			// 登录方式
			LoginTypeEnum loginTypeEnum =  player.getLoginType();
			String login_type = loginTypeEnum != null ? loginTypeEnum.getLoginTypeName() : "";
			/**
			 *  TODO 渠道编号, 如果是渠道用户登陆，记录对应的渠道编号。（即u.channeluserlogin.php的 channelcode参数）
			 */
			String channel_code = "";
			if(null != loginTypeEnum && loginTypeEnum == LoginTypeEnum.COMMONCHANNEL) {
				channel_code = "";
			}
			/**
			 *  TODO 渠道账号id, login_type 等于3或4时需要填写
			 *  如果是ios快客登陆，记录对应的渠道用户id，即u.quicklogin.php的uuid
			 *  如果是渠道用户登陆，记录对应的渠道用户id，即u.channeluserlogin.php的channeluserid参数
			 */
			String channel_userid = "";
			if(null != loginTypeEnum &&(loginTypeEnum == LoginTypeEnum.IOSQUICKLOGIN 
					|| loginTypeEnum == LoginTypeEnum.COMMONCHANNEL) ) {
				channel_userid = "";
			}
			// 推广/f码
			String promotion_code = player.getfValue();

			reportForDGBean.setLog_version(log_version);
			reportForDGBean.setLog_timestamp(log_timestamp);
			reportForDGBean.setLog_utctime(log_utctime);
			reportForDGBean.setLog_localtime(log_localtime);
			reportForDGBean.setLog_hostname(log_hostname);
			reportForDGBean.setLog_server_ip(log_server_ip);
			reportForDGBean.setLog_client_ip(log_client_ip);
			reportForDGBean.setLog_type(log_type);
			// 可以不传 日志记录唯一标示
			// reportForDGBean.setLog_serial_no(log_serial_no);
			reportForDGBean.setLog_note(log_note);
			reportForDGBean.setLog_agent(log_agent);
			reportForDGBean.setGame_id(game_id);
			reportForDGBean.setPlatform_id(platform_id);
			reportForDGBean.setRegion_id(region_id);
			reportForDGBean.setServer_id(server_id);
			reportForDGBean.setServer_name(server_name);
			reportForDGBean.setServer_domain(server_domain);
			reportForDGBean.setAccount_id(account_id);
			reportForDGBean.setAccount_name(account_name);
			reportForDGBean.setDevice(device);
			reportForDGBean.setDevice_type(device_type);
			reportForDGBean.setDevice_version(device_version);
			reportForDGBean.setDevice_guid(device_guid);
			reportForDGBean.setDevice_mac(device_mac);
			reportForDGBean.setDevice_imei(device_imei);
			reportForDGBean.setDevice_udid(device_udid);
			reportForDGBean.setDevice_idfa(device_idfa);
			reportForDGBean.setDevice_idfv(device_idfv);
			reportForDGBean.setDevice_user_agent(device_user_agent);
			reportForDGBean.setDevice_connect_type(device_connect_type);
			reportForDGBean.setDevice_jailbroken(device_jailbroken);
			reportForDGBean.setLogin_action(login_action);
			reportForDGBean.setLogin_type(login_type);
			reportForDGBean.setChannel_code(channel_code);
			reportForDGBean.setChannel_userid(channel_userid);
			reportForDGBean.setPromotion_code(promotion_code);
		} catch (Exception ex) {
			ex.printStackTrace();
			Loggers.loginLogger
					.error("PlayerLocalHelper#buildGameLoginReport error : "
							+ ex);
		}

		return reportForDGBean;
	}
	
//	public static void main(String args[]) {
//		String mac = "22:32:44:3d:19";
//		System.out.println(mac.replace(":", ""));
//	}
}
