package com.imop.lj.deploy.config;

/**
 * 版本号配置
 *
 *
 */
public class VersionConfig {
	/**
	 * 数据库版本号
	 */
	private String dbVersion;
	/**
	 * 服务器版本号
	 */
	private String serverVersion;
	/**
	 * 资源版本号
	 */
	private String resourceVersion;
	/**
	 * 客户端版本号
	 */
	private String clientVersion;
	
	/**
	 * 是否加密配置文件,true加密false不加密
	 */
	private boolean encryptResource;

	/**
	 * @return the dbVersion
	 */
	public String getDbVersion() {
		return dbVersion;
	}

	/**
	 * @param dbVersion
	 *            the dbVersion to set
	 */
	public void setDbVersion(String dbVersion) {
		this.dbVersion = dbVersion;
	}

	/**
	 * @return the serverVersion
	 */
	public String getServerVersion() {
		return serverVersion;
	}

	/**
	 * @param serverVersion
	 *            the serverVersion to set
	 */
	public void setServerVersion(String serverVersion) {
		this.serverVersion = serverVersion;
	}

	/**
	 * @return the resourceVersion
	 */
	public String getResourceVersion() {
		return resourceVersion;
	}

	/**
	 * @param resourceVersion
	 *            the resourceVersion to set
	 */
	public void setResourceVersion(String resourceVersion) {
		this.resourceVersion = resourceVersion;
	}

	/**
	 * @return the clientVersion
	 */
	public String getClientVersion() {
		return clientVersion;
	}

	/**
	 * @param clientVersion
	 *            the clientVersion to set
	 */
	public void setClientVersion(String clientVersion) {
		this.clientVersion = clientVersion;
	}
	
	public boolean isEncryptResource() {
		return encryptResource;
	}

	public void setEncryptResource(boolean encryptResource) {
		this.encryptResource = encryptResource;
	}

	/**
	 * 校验配置是否正常
	 */
	public void validate() {
		this.dbVersion = this.dbVersion.trim();
		this.serverVersion = this.serverVersion.trim();
		this.resourceVersion = this.resourceVersion.trim();
		this.clientVersion = this.clientVersion.trim();
		if (this.dbVersion.length() == 0 || this.serverVersion.length() == 0 || this.resourceVersion.length() == 0
				|| this.clientVersion.length() == 0) {
			throw new RuntimeException(
					"All the dbVersion,serverVersion,resourceVersion and the clientVersion must be set.");

		}
	}
}
