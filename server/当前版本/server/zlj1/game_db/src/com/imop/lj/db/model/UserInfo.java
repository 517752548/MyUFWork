package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.Transient;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 用户信息
 *
 */
@Entity
@Table(name = "t_user_info")
@Comment(content="数据库实体类：用户信息")
public class UserInfo implements BaseEntity<String> {

	private static final long serialVersionUID = -6420558996304842663L;

	/** 登陆标识 */
	@Comment(content="登陆标识 ")
	private String passportId;
	/** 用户名 */
	@Comment(content="用户名")
	private String name;
	/** 密码 */
	@Comment(content="密码")
	private String password;
	/** 邮箱 */
	@Comment(content="邮箱")
	private String email;
	/** 安全问题 */
	@Comment(content="安全问题")
	private String question;
	/** 安全问题答案 */
	@Comment(content="安全问题答案")
	private String answer;
	/** 帐号创建时间 */
	@Comment(content="帐号创建时间")
	private Timestamp joinTime;
	/** 上次登陆时间 */
	@Comment(content="上次登陆时间")
	private Timestamp lastLoginTime;
	/** 上次登陆退出时间 */
	@Comment(content="上次登陆退出时间")
	private Timestamp lastLogoutTime;
	/** 当天在线时长 */
	@Comment(content="当天在线时长")
	private Integer todayOnlineTime = 0;
	/** 今日累计在线时长更新时间 */
	@Comment(content="今日累计在线时长更新时间")
	private Timestamp todayOnlineUpdateTime;
	/** 登陆失败次数 */
	@Comment(content="登陆失败次数")
	private int failedLogins;
	/** 上次登陆IP */
	@Comment(content="上次登陆IP")
	private String lastLoginIp;
	/** 上次登陆的地域 */
	@Comment(content="上次登陆的地域")
	private String locale;
	/** 上次登陆的游戏版本 */
	@Comment(content="上次登陆的游戏版本")
	private String version;
	
	@Comment(content="是否已激活，1：已激活，0：未激活")
	private int activity;


	/** 权限 */
	@Comment(content="权限")
	private int role;
	/** 锁定状态 */
	@Comment(content="锁定状态")
	private int lockStatus;
	/** 锁定时间 */
	@Comment(content="锁定时间")
	private int muteTime;
	/** 锁定原因 */
	@Comment(content="锁定原因")
	private String props;

	/** 防沉迷标记 */
	@Comment(content="防沉迷标记")
	private Integer wallowFlag = 0;

	private String source;
	/**禁言时间
	 */
	@Comment(content="禁言时间")
	private long foribedTalkTime;

	private String cookieValue ;
	
	@Comment(content="玩家qq数据")
	private String qqData;
	
	@Id
	public String getId() {
		return passportId;
	}

	@Column(nullable = false, length = 255, unique = true)
	public String getName() {
		return name;
	}

	@Column(nullable = true, length = 50)
	public String getPassword() {
		return password;
	}

	@Column(nullable = true, length = 50)
	public String getEmail() {
		return email;
	}

	@Column(nullable = true, length = 50)
	public String getQuestion() {
		return question;
	}
	@Column(columnDefinition = " bigint default 0", nullable = false)
	public long getForibedTalkTime() {
		return foribedTalkTime;
	}

	@Column(nullable = true, length = 50)
	public String getAnswer() {
		return answer;
	}

	@Column
	public Timestamp getLastLoginTime() {
		return lastLoginTime;
	}


	@Column
	public Timestamp getLastLogoutTime() {
		return lastLogoutTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public Integer getTodayOnlineTime() {
		return todayOnlineTime;
	}


	@Column
	public Timestamp getJoinTime() {
		return joinTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getFailedLogins() {
		return failedLogins;
	}

	@Column(nullable = true, length = 50)
	public String getLastLoginIp() {
		return lastLoginIp;
	}

	@Column(nullable = true, length = 50)
	public String getLocale() {
		return locale;
	}

	@Column(nullable = true, length = 50)
	public String getVersion() {
		return version;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getRole() {
		return role;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLockStatus() {
		return lockStatus;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getMuteTime() {
		return muteTime;
	}

	@Column(nullable = true, length = 256)
	public String getProps() {
		return props;
	}

	@Column
	public Timestamp getTodayOnlineUpdateTime() {
		return todayOnlineUpdateTime;
	}

	public void setTodayOnlineUpdateTime(Timestamp todayOnlineUpdateTime) {
		this.todayOnlineUpdateTime = todayOnlineUpdateTime;
	}

	public void setForibedTalkTime(long foribedTalkTime) {
		this.foribedTalkTime = foribedTalkTime;
	}

	public void setId(String passportId) {
		this.passportId = passportId;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public void setQuestion(String question) {
		this.question = question;
	}

	public void setAnswer(String answer) {
		this.answer = answer;
	}

	public void setLastLoginIp(String lastLoginIp) {
		this.lastLoginIp = lastLoginIp;
	}

	public void setLastLoginTime(Timestamp lastLoginTime) {
		this.lastLoginTime = lastLoginTime;
	}

	public void setLastLogoutTime(Timestamp lastLogoutTime) {
		this.lastLogoutTime = lastLogoutTime;
	}

	public void setTodayOnlineTime(Integer todayOnlineTime) {
		this.todayOnlineTime = todayOnlineTime;
	}

	public void setRole(int role) {
		this.role = role;
	}

	public void setProps(String props) {
		this.props = props;
	}

	public void setJoinTime(Timestamp joinTime) {
		this.joinTime = joinTime;
	}

	public void setFailedLogins(int failedLogins) {
		this.failedLogins = failedLogins;
	}

	public void setLockStatus(int lockStatus) {
		this.lockStatus = lockStatus;
	}

	public void setMuteTime(int muteTime) {
		this.muteTime = muteTime;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public void setVersion(String version) {
		this.version = version;
	}

	@Transient
	public Integer getWallowFlag() {
		return wallowFlag;
	}

	public void setWallowFlag(Integer wallowFlag) {
		this.wallowFlag = wallowFlag;
	}

	/**
	 * 得到一个默认的userinfo,平台passportID第一进入时创建的
	 *
	 *
	 */


	public static UserInfo getDefaultUserInfo(){
		UserInfo userInfo = new UserInfo();
		userInfo.setQuestion("");
		userInfo.setAnswer("");
		userInfo.setLastLoginTime(new Timestamp(System.currentTimeMillis()));
		userInfo.setLastLoginIp("127.0.0.1");
		userInfo.setPassword("");
		return userInfo;
	}

	public String getSource() {
		return source;
	}

	public void setSource(String source) {
		this.source = source;
	}

//	public boolean isQuickLogin() {
//		return isQuickLogin;
//	}
//
//	public void setQuickLogin(boolean isQuickLogin) {
//		this.isQuickLogin = isQuickLogin;
//	}

//	@Column(columnDefinition = " int default 0", nullable = false)
//	public boolean isReadyBandQuickLogin() {
//		return isReadyBandQuickLogin;
//	}
//
//	public void setReadyBandQuickLogin(boolean isReadyBandQuickLogin) {
//		this.isReadyBandQuickLogin = isReadyBandQuickLogin;
//	}
//
//	@Column(columnDefinition = " int default 0", nullable = false)
//	public boolean isQuickLoginAccount() {
//		return isQuickLoginAccount;
//	}
//
//	public void setQuickLoginAccount(boolean isQuickLoginAccount) {
//		this.isQuickLoginAccount = isQuickLoginAccount;
//	}
//
//	@Column(columnDefinition = " int default 0", nullable = false)
//	public boolean isQuickLogin() {
//		return isQuickLogin;
//	}
//
//	public void setQuickLogin(boolean isQuickLogin) {
//		this.isQuickLogin = isQuickLogin;
//	}
//
//	@Column(columnDefinition = " bigint(20) default -1", nullable = false)
//	public long getBandPassportId() {
//		return bandPassportId;
//	}
//
//	public void setBandPassportId(long bandPassportId) {
//		this.bandPassportId = bandPassportId;
//	}

	public String getCookieValue() {
		return cookieValue;
	}

	public void setCookieValue(String cookieValue) {
		this.cookieValue = cookieValue;
	}

	@Override
	public String toString() {
		return "UserInfo [passportId=" + passportId + ", name=" + name + "]";
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getActivity() {
		return activity;
	}

	public void setActivity(int activity) {
		this.activity = activity;
	}
	
	@Column(columnDefinition = "TEXT")
	public String getQqData() {
		return qqData;
	}

	public void setQqData(String qqData) {
		this.qqData = qqData;
	}

}
