package com.imop.lj.gameserver.mail;

import java.util.HashSet;
import java.util.Set;

import net.sf.json.JSONArray;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.SysMailEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.scene.CommonScene;

/**
 * 全服邮件对象
 * @author yu.zhao
 *
 */
public class SysMailInstance implements PersistanceObject<Long, SysMailEntity> {

	/** 唯一Id */
	private Long id;

	/** 邮件标题 */
	private String title;

	/** 邮件内容 */
	private String content;

	/** 创建时间 */
	private long createTime;
	
	/** 过期时间 */
	private long expiredTime;

	/** 奖励附件 */
	private Reward attachmentReward;
	
	/** 已经获取邮件的玩家Id集合 */
	private Set<Long> sendUserSet;
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 邮件的生命期的状态 */
	private final LifeCycle lifeCycle;
	/** 公共场景 */
	private CommonScene commonScene;

	public SysMailInstance() {
		sendUserSet = new HashSet<Long>();
		attachmentReward = Globals.getRewardService().createEmptyReward();
		this.lifeCycle = new LifeCycleImpl(this);
		commonScene = Globals.getSceneService().getCommonScene();
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	public long getExpiredTime() {
		return expiredTime;
	}

	public void setExpiredTime(long expiredTime) {
		this.expiredTime = expiredTime;
	}

	public Set<Long> getSendUserSet() {
		return sendUserSet;
	}

	public boolean addSendUser(long uuid) {
		return sendUserSet.add(uuid);
	}
	
	public boolean hasSendUser(long uuid) {
		return sendUserSet.contains(uuid);
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
		setModified();
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
		setModified();
	}

	public boolean isHasAttachment() {
		if (attachmentReward == null || attachmentReward.isNull()) {
			return false;
		} 
		return true;
	}


	public Reward getAttachmentReward() {
		return attachmentReward;
	}

	public void setAttachmentReward(Reward attachmentReward) {
		this.attachmentReward = attachmentReward;
		this.setModified();
	}
	
	public boolean hasAttachment() {
		if (attachmentReward == null || attachmentReward.isNull()) {
			return false;
		}
		return true;
	}
	
	public JSONArray sendUserSetToJson() {
		JSONArray jsonArr = new JSONArray();
		for (Long uuid : sendUserSet) {
			jsonArr.add(uuid);
		}
		return jsonArr;
	}
	
	public void sendUserSetFromStr(String sendUsersStr) {
		if (null == sendUsersStr || sendUsersStr.equalsIgnoreCase("")) {
			return;
		}
		JSONArray jsonArr = JSONArray.fromObject(sendUsersStr);
		if (jsonArr.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < jsonArr.size(); i++) {
			long uuid = jsonArr.getLong(i);
			sendUserSet.add(uuid);
		}
	}

	@Override
	public void fromEntity(SysMailEntity entity) {
		this.setId(entity.getId());
		this.setTitle(entity.getTitle());
		this.setContent(entity.getContent());
		this.setCreateTime(entity.getCreateTime());
		this.setExpiredTime(entity.getExpiredTime());
		// 奖励附件
		String attachmentProps = entity.getAttachmentProps();
		if (attachmentProps != null && !attachmentProps.equalsIgnoreCase("")) {
			attachmentReward = Reward.fromJsonStr(attachmentProps);
		}
		// 已发玩家集合
		sendUserSetFromStr(entity.getSendUsers());
	}

	@Override
	public SysMailEntity toEntity() {
		SysMailEntity entity = new SysMailEntity();
		entity.setId(this.getId());
		entity.setTitle(this.getTitle());
		entity.setContent(this.getContent());
		entity.setCreateTime(this.getCreateTime());
		entity.setExpiredTime(this.getExpiredTime());
		// 奖励附件
		if (attachmentReward == null || attachmentReward.isNull()) {
			entity.setAttachmentProps("");
		} else {
			entity.setAttachmentProps(attachmentReward.toJsonObj().toString());
		}
		// 已发玩家集合
		entity.setSendUsers(sendUserSetToJson().toString());
		return entity;
	}

	@Override
	public long getCharId() {
		return id;
	}

	@Override
	public String getGUID() {
		return "SysMailEntity#" + this.id;
	}

	@Override
	public Long getDbId() {
		return this.id;
	}

	@Override
	public void setDbId(Long id) {
		this.id = id;
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public boolean isInDb() {
		return isInDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			commonScene.getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}
	
	/**
	 * 激活此对象，并初始化属性 此方法在玩家登录加载完数据
	 */
	public void active() {
		getLifeCycle().activate();
	}
	
	/**
	 * 邮件被删除时调用,恢复默认值,并触发删除机制
	 * 
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		commonScene.getCommonDataUpdater().addDelete(lifeCycle);
	}
	
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		SysMailInstance other = (SysMailInstance) obj;
		if (getId() != other.getId())
			return false;
		return true;
	}

}
