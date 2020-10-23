package com.imop.lj.gm.utils;

import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.transaction.interceptor.TransactionProxyFactoryBean;

/**
 * GM 游戏后台管理系统<br>
 * Spring容器类
 *
 * @author lin fan
 */
public class SpringContext {

	private static SpringContext m_instance;

	private static String[] contextFiles = new String[] { "applicationContext.xml" };

	private ApplicationContext ctx;

	public SpringContext() {
		ctx = new ClassPathXmlApplicationContext(contextFiles);
	}

	public SpringContext(String[] setting) {
		ctx = new ClassPathXmlApplicationContext(setting);
	}

	/**
	 * 获取容器实例
	 *
	 * @return 容器实例
	 */
	public synchronized static SpringContext getInstance() {
		if (m_instance == null) {
			m_instance = new SpringContext(contextFiles);
		}
		return m_instance;
	}

	/**
	 * 从容器中获取Bean实例
	 *
	 * @param beanId
	 *            Bean id
	 * @return Bean实例
	 */
	public Object getBean(String beanId) {
		Object o = ctx.getBean(beanId);
		if (o instanceof TransactionProxyFactoryBean) {
			TransactionProxyFactoryBean factoryBean = (TransactionProxyFactoryBean) o;
			o = factoryBean.getObject();
		}
		return o;
	}

}
