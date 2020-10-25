package com.imop.lj.common.model.human;


public class NoticeTipsInfo {

	/** 窗口内容 **/
	private String content;
	/** 操作标识 **/
	private String tag;
	/** 小信封1无选择项2有选择框 **/
	private int type;
	/** 小信封icon **/
	private int icon;
	/** 点完确定之后播放的动画类型，暂留 **/
	private int showAnimation;
	
	private long fromRoleId;
	
	private String fromRoleName;
	
	private int fromRoleLevel;
	
	private int fromRoleJobType;
	
	private int fromRoleTplId;
	
	private Long chatTime ;

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getTag() {
		return tag;
	}

	public void setTag(String tag) {
		this.tag = tag;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public int getIcon() {
		return icon;
	}

	public void setIcon(int icon) {
		this.icon = icon;
	}

	public int getShowAnimation() {
		return showAnimation;
	}

	public void setShowAnimation(int showAnimation) {
		this.showAnimation = showAnimation;
	}

	@Override
	public String toString() {
		return "NoticeTipsInfo [" + "content=" + content + "," + "tag=" + tag + "," + "type=" + type + "," + "icon=" + icon + "," + "showAnimation="
				+ showAnimation + "]";
	}

	public long getFromRoleId() {
		return fromRoleId;
	}

	public void setFromRoleId(long fromRoleId) {
		this.fromRoleId = fromRoleId;
	}

	public String getFromRoleName() {
		return fromRoleName;
	}

	public void setFromRoleName(String fromRoleName) {
		this.fromRoleName = fromRoleName;
	}

	public int getFromRoleLevel() {
		return fromRoleLevel;
	}

	public void setFromRoleLevel(int fromRoleLevel) {
		this.fromRoleLevel = fromRoleLevel;
	}

	public int getFromRoleJobType() {
		return fromRoleJobType;
	}

	public void setFromRoleJobType(int fromRoleJobType) {
		this.fromRoleJobType = fromRoleJobType;
	}

	public int getFromRoleTplId() {
		return fromRoleTplId;
	}

	public void setFromRoleTplId(int fromRoleTplId) {
		this.fromRoleTplId = fromRoleTplId;
	}

	public Long getChatTime() {
		return chatTime;
	}

	public void setChatTime(Long chatTime) {
		this.chatTime = chatTime;
	}



}
