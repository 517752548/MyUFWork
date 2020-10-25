package com.imop.lj.gameserver.relation.msg;

import java.util.List;

import com.imop.lj.common.model.RelationInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.PageUtil.PageResult;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.relation.RelationTypeEnum;

public class RelationMsgBuilder {
	
	/**
	 * 构建关系列表消息
	 * @param human
	 * @param relationType
	 * @param page
	 * @return
	 */
	public static GCClickRelationPanel buildGCClickRelationPanelMsg(Human human, RelationTypeEnum relationType, int page) {
		GCClickRelationPanel gcClickRelationPanel = new GCClickRelationPanel();
		gcClickRelationPanel.setRelationType(relationType.getIndex());
		PageResult<RelationInfo> pageResult = Globals.getRelationService().getRelationInfoListPage(human, relationType, page);
		List<RelationInfo> relationInfoList = pageResult.getResultList();
		gcClickRelationPanel.setRelationInfoList(relationInfoList.toArray(new RelationInfo[0]));
		gcClickRelationPanel.setCurPage(pageResult.getCurrPage());
		gcClickRelationPanel.setMaxPage(pageResult.getMaxPage());
		return gcClickRelationPanel;
	}

	/**
	 * 构建添加关系成功的消息
	 * @param relationType
	 * @param targetCharId
	 * @return
	 */
	public static GCAddRelation buildGCAddRelation(RelationTypeEnum relationType, long targetCharId) {
		GCAddRelation gcAddRelation = new GCAddRelation();
		gcAddRelation.setRelationType(relationType.getIndex());
		gcAddRelation.setTargetCharId(targetCharId);
		gcAddRelation.setRelationInfoData(Globals.getRelationService().buildRelationInfo(targetCharId));
		return gcAddRelation;
	}
	
	/**
	 * 构建删除关系成功的消息
	 * @param relationType
	 * @param targetCharId
	 * @return
	 */
	public static GCDelRelation buildGCDelRelation(RelationTypeEnum relationType, long targetCharId) {
		GCDelRelation gcDelRelation = new GCDelRelation();
		gcDelRelation.setRelationType(relationType.getIndex());
		gcDelRelation.setTargetCharId(targetCharId);
		return gcDelRelation;
	}
	
	/**
	 * 构建推荐好友列表消息
	 * @param relationList
	 * @return
	 */
	public static GCShowRecommendFriendList buildGCShowRecommendFriendList(List<RelationInfo> relationList) {
		GCShowRecommendFriendList gcShowRecommendFriendList = new GCShowRecommendFriendList();
		gcShowRecommendFriendList.setRelationInfoList(relationList.toArray(new RelationInfo[0]));
		return gcShowRecommendFriendList;
	}
}
