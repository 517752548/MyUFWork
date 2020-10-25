package com.imop.lj.gm.service;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.utils.SpringContext;
/**
 * 处理LoginUser的信息,主要提供LoginServerId,供GenericDAO使用,
 * 不用每次操作都传递 LoginServerId
 * @author linfan
 *
 */
public class LoginUserService {

	/** 存放登陆用户信息*/
	private static final ThreadLocal<LoginUser> threadLocal = new ThreadLocal<LoginUser>();

	private static SpringContext wac = SpringContext.getInstance();

	private static DBFactoryService dbFactoryService = (DBFactoryService) (wac
			.getBean("dbFactoryService"));


    /**
     * 得到用户登录的LoginServerId
     * @return 有则返回LoginServerId,没有返回null
     */
	public static final String getLoginServerId() {
		LoginUser _user = threadLocal.get();
		if (_user != null) {
			return _user.getLoginServerId();
		} else {
			return null;
		}
	}

	/**
     * 得到用户登录的LoginServerId
     * @return 有则返回LoginServerId,没有返回null
     */
	public static final String getLoginRegionId() {
		LoginUser _user = threadLocal.get();
		if (_user != null) {
			return _user.getLoginRegionId();
		} else {
			return null;
		}
	}
    /**
     * 把LoginUser放入到ThreadLocal中
     * @param user
     */
	public static final void pushUser(LoginUser user) {
		threadLocal.set(user);
	}

	 /**
     * 从ThreadLocal中remove LoginUser
     * @param user
     */
	public static final void popUser() {
		threadLocal.remove();
	}

	 /**
     * 得到用户登录的DBServer
     * @return 有则返回DBServer,没有返回null
     */
	public static final DBServer getDBServer() {
		LoginUser _user = threadLocal.get();
		DBServer dBServer= dbFactoryService.getServer(_user.getLoginRegionId(),_user.getLoginServerId());
		if (dBServer != null) {
			return dBServer;
		} else {
			return null;
		}
	}

	 /**
     * 得到用户登录的LoginServerId
     * @return 有则返回LoginServerId,没有返回null
     */
	public static final LoginUser getLoginUser() {
		LoginUser _user = threadLocal.get();
		if (_user != null) {
			return _user;
		} else {
			return null;
		}
	}





}
