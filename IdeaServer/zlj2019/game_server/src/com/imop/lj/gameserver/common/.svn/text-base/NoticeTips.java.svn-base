package com.imop.lj.gameserver.common;

import com.imop.lj.common.model.human.NoticeTipsInfo;
import com.imop.lj.gameserver.common.NoticeTipsDef.NoticeState;
import com.imop.lj.gameserver.common.NoticeTipsDef.NoticeType;

public class NoticeTips {

	private String content;

	private long createTime;

	private NoticeType type = NoticeType.NOTICE;

	private NoticeState state;

	private int icon;

	private int showAnimation;
	
	private long fromRoleId;
	
	private String fromRoleName;
	
	private int fromRoleLevel;
	
	private int fromRoleJobType;
	
	private int fromRoleTplId;

	INoticeTipsHandler handler ;

	public NoticeTips() {
		createTime = System.currentTimeMillis();
		type = NoticeType.NOTICE;
		state = NoticeState.NOT_SEND;
	}

	public String getTag() {
		return this.createTime + "";
	}

	public long getCreateTime() {
		return createTime;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public NoticeType getType() {
		return type;
	}

	public void setType(NoticeType type) {
		this.type = type;
	}

	public NoticeState getState() {
		return state;
	}

	public void setState(NoticeState state) {
		this.state = state;
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

	public INoticeTipsHandler getHandler() {
		return handler;
	}

	public void setHandler(INoticeTipsHandler handler) {
		this.handler = handler;
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

	public NoticeTipsInfo buildNoticTipsInfo(){
		NoticeTipsInfo noticeTipsInfo = new NoticeTipsInfo();
		noticeTipsInfo.setContent(this.content);
		noticeTipsInfo.setIcon(this.icon);
		noticeTipsInfo.setType(this.type.index);
		noticeTipsInfo.setTag(getTag());
		
		noticeTipsInfo.setFromRoleId(fromRoleId);
		noticeTipsInfo.setFromRoleJobType(fromRoleJobType);
		noticeTipsInfo.setFromRoleLevel(fromRoleLevel);
		noticeTipsInfo.setFromRoleName(fromRoleName);
		noticeTipsInfo.setFromRoleTplId(fromRoleTplId);
		noticeTipsInfo.setChatTime(createTime);
		//TODO 修改
		noticeTipsInfo.setShowAnimation(this.getShowAnimation());
		return noticeTipsInfo;
	}

	public int getFromRoleTplId() {
		return fromRoleTplId;
	}

	public void setFromRoleTplId(int fromRoleTplId) {
		this.fromRoleTplId = fromRoleTplId;
	}

	
}
