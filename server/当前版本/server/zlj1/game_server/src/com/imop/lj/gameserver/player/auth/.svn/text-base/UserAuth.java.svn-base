package com.imop.lj.gameserver.player.auth;

import com.imop.lj.gameserver.player.Player;

/**
 * 用户认证接口
 *
 */
public interface UserAuth {
	/**
	 * 验证用户名和密码
	 *
	 * @param userName
	 * @param password
	 * @param ip
	 * @param loginType
	 * @return
	 */
	public AuthResult auth(Player player, String userName, String password, String ip,String source);

	/**
	 * 用cookie进行验证
	 *
	 * @param cookieValue
	 * @param ip
	 * @return
	 */
	public AuthResult auth(Player player, String cookieValue, String ip);

	/**
	 * 快速登陆
	 * @param udid
	 * @param fValue
	 * @param source
	 * @return
	 */
	public AuthResult quickAuth(String ip,String udid,String fValue,String source);
	
	/**
	 * token登录
	 * @param player
	 * @param token
	 * @param pid
	 * @param rid
	 * @return
	 */
	public AuthResult auth(Player player, String token, String pid, long rid);
}
