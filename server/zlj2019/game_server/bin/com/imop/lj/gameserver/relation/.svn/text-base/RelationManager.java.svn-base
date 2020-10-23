package com.imop.lj.gameserver.relation;

import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.human.Human;

/**
 * 玩家关系数据管理
 * @author yu.zhao
 *
 */
public class RelationManager {
	/** 主人 */
	private Human owner;
	
	/** 好友关系映射表；对应的键值为对方玩家ID，方便查找 */
	private Map<Long, Relation> friendRelationList;
	/** 黑名单关系映射表；对应的键值为对方玩家ID，方便查找 */
	private Map<Long, Relation> blackListRelationList;
	
	public RelationManager(Human owner) {
		this.owner = owner;
		friendRelationList = new LinkedHashMap<Long, Relation>();
		blackListRelationList = new LinkedHashMap<Long, Relation>();
	}
	
	/**
	 * 加载武将列表并进行初始化
	 * 进入游戏时调用
	 */
	public void load() {
		// 初始化玩家关系系统列表
		List<Relation> list = RelationDbManager.getInstance().loadAllRelationFromDB(owner);
		for (Relation relation : list) {
			addRelation(relation);
		}
		
		// 激活
		activeAllRelations();
	}
	
	/**
	 * 激活
	 */
	private void activeAllRelations() {
		// 好友列表激活
		for (Map.Entry<Long, Relation> entry : friendRelationList.entrySet()) {
			Relation relation = entry.getValue();
			relation.active();
		}
		
		// 关注好友列表激活
		for (Map.Entry<Long, Relation> entry : blackListRelationList.entrySet()) {
			Relation relation = entry.getValue();
			relation.active();
		}
	}
	
	/**
	 * 获取玩家当前好友关系个数
	 * @return
	 */
	public int getFriendRelationNumber() {
		return friendRelationList.size();
	}

	/**
	 * 获取玩家当前黑名单玩家关系个数
	 * @return
	 */
	public int getBlackListRelationNumber() {
		return blackListRelationList.size();
	}
	
	/**
	 * 获取好友关系列表
	 * @return
	 */
	public Map<Long, Relation> getFriendRelationList() {
		return friendRelationList;
	}
	
	/**
	 * 获取黑名单好友关系列表
	 * @return
	 */
	public Map<Long, Relation> getBlackListRelationList() {
		return blackListRelationList;
	}
	
	/**
	 * 获取两人的关系类型
	 * @param targetCharId
	 * @return
	 */
	public RelationTypeEnum getRelationType(long targetCharId) {
		RelationTypeEnum relationType = RelationTypeEnum.NONE;
		if (hasRelation(RelationTypeEnum.FRIEND, targetCharId)) {
			relationType = RelationTypeEnum.FRIEND;
		} else if (hasRelation(RelationTypeEnum.BLACK_LIST, targetCharId)) {
			relationType = RelationTypeEnum.BLACK_LIST;
		}
		return relationType;
	}
	
	/**
	 * 查询与目标玩家是否有任意关系
	 * @param targetCharId
	 * @return
	 */
	public boolean hasAnyRelation(long targetCharId) {
		if (getRelationType(targetCharId) != RelationTypeEnum.NONE) {
			return true;
		}
		return false;
	}

	/**
	 * 查询玩家是否有指定关系
	 * @param relationType 关系类型
	 * @param targetCharId 目标玩家角色Id
	 * @return
	 */
	public boolean hasRelation(RelationTypeEnum relationType, long targetCharId) {
		boolean flag = false;
		switch (relationType) {
		case FRIEND:
			flag = friendRelationList.containsKey(targetCharId);
			break;
		case BLACK_LIST:
			flag = blackListRelationList.containsKey(targetCharId);
			break;

		default:
			break;
		}
		return flag;
	}
	
	/**
	 * 获取指定类型的某玩家关系
	 * @param relationType
	 * @param targetCharId
	 * @return
	 */
	public Relation getRelation(RelationTypeEnum relationType, long targetCharId) {
		Relation relation = null;
		switch (relationType) {
		case FRIEND:
			relation = friendRelationList.get(targetCharId);
			break;
		case BLACK_LIST:
			relation = blackListRelationList.get(targetCharId);
			break;

		default:
			break;
		}
		return relation;
	}
	
	/**
	 * 从指定关系类型中删除目标玩家
	 * @param relationType
	 * @param targetCharId
	 */
	public void removeRelation(Relation relation) {
		RelationTypeEnum relationType = relation.getRelationType();
		long targetId = relation.getTargetCharId();
		switch (relationType) {
		case FRIEND:
			friendRelationList.remove(targetId);
			break;
		case BLACK_LIST:
			blackListRelationList.remove(targetId);
			break;

		default:
			break;
		}
	}
	
	/**
	 * 在指定关系类型中增加关系
	 * @param relationType
	 * @param relation
	 */
	public void addRelation(Relation relation) {
		RelationTypeEnum relationType = relation.getRelationType();
		switch (relationType) {
		case FRIEND:
			friendRelationList.put(relation.getTargetCharId(), relation);
			break;
		case BLACK_LIST:
			blackListRelationList.put(relation.getTargetCharId(), relation);
			break;
		default:
			break;
		}
	}
	
	/**
	 * 从db中删除指定的关系数据
	 * @param relation
	 */
	public void delRelation(Relation relation) {
		relation.onDelete();
	}
}
