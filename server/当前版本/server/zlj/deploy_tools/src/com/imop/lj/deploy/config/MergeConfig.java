package com.imop.lj.deploy.config;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "merge_config")
@XmlAccessorType(XmlAccessType.PROPERTY)
public class MergeConfig {

	private int insertNumOnce=1000;

	private String fromDbSuffix="";

	/** 表示被合并的服务器 */
	private DBConfig fromDbConfig;

	/** 表示合并的数据库 */
	private DBConfig toDbConfig;

	/** 表示合并后新的数据库 */
	private DBConfig newDbConfig;

	public DBConfig getFromDbConfig() {
		return fromDbConfig;
	}

	@XmlElement(name = "from_db", required = true, nillable = false)
	public void setFromDbConfig(DBConfig fromDbConfig) {
		this.fromDbConfig = fromDbConfig;
	}

	@XmlElement(name = "to_db", required = true, nillable = false)
	public DBConfig getToDbConfig() {
		return toDbConfig;
	}

	public void setToDbConfig(DBConfig toDbConfig) {
		this.toDbConfig = toDbConfig;
	}

	@XmlElement(name = "new_db", required = true, nillable = false)
	public DBConfig getNewDbConfig() {
		return newDbConfig;
	}

	public void setNewDbConfig(DBConfig newDbConfig) {
		this.newDbConfig = newDbConfig;
	}

	@XmlAttribute()
	public int getInsertNumOnce() {
		return insertNumOnce;
	}

	public void setInsertNumOnce(int insertNumOnce) {
		this.insertNumOnce = insertNumOnce;
	}

	@XmlAttribute()
	public String getFromDbSuffix() {
		return fromDbSuffix;
	}

	public void setFromDbSuffix(String fromDbSuffix) {
		this.fromDbSuffix = fromDbSuffix;
	}

	@Override
	public String toString() {
		return "MergeConfig [insertNumOnce=" + insertNumOnce + ", fromDbSuffix=" + fromDbSuffix + ", fromDbConfig=" + fromDbConfig + ", toDbConfig="
				+ toDbConfig + ", newDbConfig=" + newDbConfig + "]";
	}
}
