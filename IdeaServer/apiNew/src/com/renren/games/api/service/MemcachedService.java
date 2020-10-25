package com.renren.games.api.service;

import java.util.concurrent.TimeoutException;

import net.rubyeye.xmemcached.MemcachedClient;
import net.rubyeye.xmemcached.MemcachedClientBuilder;
import net.rubyeye.xmemcached.XMemcachedClientBuilder;
import net.rubyeye.xmemcached.exception.MemcachedException;
import net.rubyeye.xmemcached.utils.AddrUtil;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;

public class MemcachedService {
	protected MemcachedClient memCachedClient;

	public MemcachedService(ApiConfig cfg) throws Exception {
		String ip = cfg.getMemcachedIp();
		int port = cfg.getMemcachedPort();
		String address = ip + ":" + port;
		MemcachedClientBuilder builder = new XMemcachedClientBuilder(AddrUtil.getAddresses(address));
		memCachedClient = builder.build();
		Loggers.platformlocalLogger.info("[Memcached] "+ address + " started ");
	}

	public void test() throws TimeoutException, InterruptedException, MemcachedException {
		long begin = System.currentTimeMillis();

		memCachedClient.set("hello", 0, "Hello,xmemcached");

		String value = memCachedClient.get("hello");

		Loggers.platformlocalLogger.info("hello=" + value);

		memCachedClient.delete("hello");

		// Object value =
		// memCachedClient.get("SESSION_CCECE95B6A7C726924073F1E0FA23B8B");
		// memCachedClient.gets
		// memCachedClient.cas
		System.out.println("hello=" + value);

		// System.out.println("platformLocalConfig=" +
		// platformLocalConfig.getMutexExp());
		long end = System.currentTimeMillis();
		Loggers.platformlocalLogger.info("[MemcachedService.test] execute" + (end - begin) + "ms");
	}
	
	@SuppressWarnings("unchecked")
	public <T> T getObject(String key, Class<T> clazz) {
		try {
			return (T) this.memCachedClient.get(key);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

	/**
	 * 冲突判定
	 * 
	 * @param key
	 */
	public boolean isMutex(String key) {
		return isMutex(key, Globals.getConfig().getMutexExp());
	}

	/**
	 * 冲突判定
	 * 
	 * @param key
	 * @param exp
	 * @return true 冲突
	 */
	public boolean isMutex(String key, int exp) {
		boolean status = true;
		try {
			if (memCachedClient.add(Globals.getConfig().getMutexKeyPrefix() + key, exp, "true")) {
				status = false;
			}
		} catch (Exception e) {
			Loggers.platformlocalLogger.error(e.getMessage(), e);
		}
		return status;
	}
	
	public boolean saveObject(String key, int exptime, Object object) {

		// TODO 加入负载判断
		// if(this.isMutex(key)){
		// return false;
		// }

		boolean flag = false;
		try {
			flag = memCachedClient.set(key, exptime, object);
		} catch (Exception e) {
			Loggers.platformlocalLogger.error(e.getMessage(), e);
		}
		return flag;
	}
}
