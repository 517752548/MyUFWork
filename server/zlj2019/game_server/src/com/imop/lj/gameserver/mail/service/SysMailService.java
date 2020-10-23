package com.imop.lj.gameserver.mail.service;

import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.SysMailEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.mail.MailDef;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.mail.SysMailInstance;
import com.imop.lj.gameserver.mail.msg.SendUserSysMailMsg;
import com.imop.lj.gameserver.reward.Reward;

/**
 * 全服邮件服务
 * @author yu.zhao
 *
 */
public class SysMailService implements InitializeRequired {

	/** 全服邮件Map<邮件Id，邮件对象> */
	protected Map<Long, SysMailInstance> allSysMailMap = new HashMap<Long, SysMailInstance>();
	
	public SysMailService() {
		
	}
	
	@Override
	public void init() {
		// 从db中加载所有的未删除的邮件
		List<SysMailEntity> entityList = Globals.getDaoService().getSysMailDao().loadAllSysMailEntity();
		if (null == entityList || entityList.isEmpty()) {
			return;
		}
		
		for (SysMailEntity entity : entityList) {
			SysMailInstance instance = new SysMailInstance();
			instance.fromEntity(entity);
			// 检查邮件的过期时间，如果已过期，就不再加载
			if (isSysMailExpired(instance)) {
				continue;
			}
			// 激活
			instance.active();
			// 加入map
			addToMap(instance);
		}
	}
	
	protected SysMailInstance getSysMailInstance(long id) {
		return allSysMailMap.get(id);
	}
	
	protected void addToMap(SysMailInstance instance) {
		// 加入map
		allSysMailMap.put(instance.getId(), instance);
	}
	
	protected void removeFromMap(SysMailInstance instance) {
		allSysMailMap.remove(instance);
	}
	
	protected Map<Long, SysMailInstance> getAllSysMail() {
		return allSysMailMap;
	}
	
	/**
	 * 删除一个系统邮件
	 * @param instance
	 */
	protected void delSysMailInstance(SysMailInstance instance) {
		// 邮件本身删除
		instance.onDelete();
		// 从map中删除
		removeFromMap(instance);
	}
	
	/**
	 * 邮件是否已过期
	 * @param instance
	 * @return
	 */
	protected boolean isSysMailExpired(SysMailInstance instance) {
		if (null == instance) {
			return false;
		}
		if (instance.getExpiredTime() <= Globals.getTimeService().now()) {
			return true;
		}
		return false;
	}
	
	/**
	 * 构建系统邮件对象
	 * @param title
	 * @param content
	 * @param reward
	 * @param expiredTime
	 * @return
	 */
	protected SysMailInstance buildInitSysMail(String title, String content, Reward reward, long expiredTime) {
		SysMailInstance instance = new SysMailInstance();
		instance.setId(Globals.getUUIDService().getNextUUID(UUIDType.SYSMAIL));
		instance.setTitle(title);
		instance.setContent(content);
		instance.setCreateTime(Globals.getTimeService().now());
		instance.setExpiredTime(expiredTime);
		instance.setAttachmentReward(reward);
		// 激活
		instance.active();
		return instance;
	}
	
	/**
	 * 给在线玩家发系统邮件
	 * @param instance
	 */
	protected void onAddSysMail(SysMailInstance instance) {
		Collection<Long> onlinePlayerIds = Globals.getOnlinePlayerService().getAllOnlinePlayerRoleUUIDs();
		for (Long uuid : onlinePlayerIds) {
			// 给在线玩家发邮件
			giveUserSysMail(uuid, instance);
		}
	}
	
	/**
	 * 给玩家发系统邮件，不做过期检查
	 * @param uuid
	 * @param instance
	 */
	protected void giveUserSysMail(long uuid, SysMailInstance instance) {
		// 加入已发送列表
		instance.addSendUser(uuid);
		// 给在线玩家发邮件
		Globals.getMailService().sendSysMail(uuid, MailType.SYSTEM, 
				instance.getTitle(), instance.getContent(), instance.getAttachmentReward());
		// 更新
		instance.setModified();
	}
	
	/**
	 * 检查所有的全服邮件是否有过期的，如果有则删除（软删除）
	 */
	public void checkAllSysMailExpired() {
		Iterator<SysMailInstance> it = getAllSysMail().values().iterator();
		for (;it.hasNext();) {
			SysMailInstance instance = it.next();
			// 检查系统邮件是否已过期
			if (isSysMailExpired(instance)) {
				it.remove();
				delSysMailInstance(instance);
				continue;
			}
		}
	}
	
	/**
	 * 添加系统邮件
	 * @param title
	 * @param content
	 * @param reward
	 * @param expiredTime
	 * @return
	 */
	public boolean addSysMail(String title, String content, Reward reward, long expiredTime) {
		long now = Globals.getTimeService().now();
		// 检查时间
		if (expiredTime <= now) {
			return false;
		}
		// 标题和内容不能为空
		if (null == title || null == content) {
			return false;
		}
		// XXX 系统邮件暂时不做内容检查，发什么就是什么
		
		// 设置过期时间，最长为30天
		expiredTime = Math.min(now + MailDef.SYS_MAIL_MAX_TIME, expiredTime);
		
		// 创建邮件对象
		SysMailInstance instance = buildInitSysMail(title, content, reward, expiredTime);
		// 将邮件加入map
		addToMap(instance);
		
		// 给在线玩家发邮件
		onAddSysMail(instance);
		
		return true;
	}
	
	/**
	 * 删除系统邮件
	 * @param id
	 * @return
	 */
	public boolean delSysMail(long id) {
		// 删除系统邮件
		SysMailInstance instance = getSysMailInstance(id);
		if (null == instance) {
			return false;
		}
		// 删除邮件
		delSysMailInstance(instance);
		return true;
	}
	
	/**
	 * 玩家登陆时，给玩家发系统邮件
	 * 这里先往公共场景put消息，再给玩家发
	 * @param uuid
	 */
	public void sendSysMailOnLogin(long uuid) {
		if (uuid <= 0) {
			return;
		}
		SendUserSysMailMsg msg = new SendUserSysMailMsg(uuid);
		Globals.getSceneService().getCommonScene().putMessage(msg);
	}
	
	/**
	 * 内部的给玩家发系统邮件的方法，只在{@link SendUserSysMailMsg}中调用
	 * @param uuid
	 */
	public void sendUserSysMail(long uuid) {
		if (uuid <= 0) {
			return;
		}
		for (SysMailInstance instance : getAllSysMail().values()) {
			// 如果邮件已经过期了，就不给玩家发了
			if (isSysMailExpired(instance)) {
				continue;
			}
			// 如果已经发给玩家了，就不能再发了
			if (instance.hasSendUser(uuid)) {
				continue;
			}
			
			// 给玩家发系统邮件
			giveUserSysMail(uuid, instance);
		}
	}
	
}
