package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.model.RelationInfo;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.relation.RelationTypeEnum;
import com.imop.lj.gameserver.relation.msg.CGAddRelationBatch;
import com.imop.lj.gameserver.relation.msg.CGShowRecommendFriendList;
import com.imop.lj.gameserver.relation.msg.GCShowRecommendFriendList;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class RelationTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public RelationTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		CGShowRecommendFriendList cgShowRecommendFriendList = new CGShowRecommendFriendList();
		sendMessage(cgShowRecommendFriendList);
	}

	@Override
	public void onResponse(IMessage msg) {
		System.out.println("Robot onResponse");
		if (msg instanceof GCShowRecommendFriendList) {
			GCShowRecommendFriendList gcShowRecommendFriendList = (GCShowRecommendFriendList)msg;
			RelationInfo[] relationInfoArr = gcShowRecommendFriendList.getRelationInfoList();
			int len = relationInfoArr.length;
			if (len > 0) {
				long[] idArr = new long[len];
				for (int i = 0; i < len; i++) {
					idArr[i] = relationInfoArr[i].getUuid();
				}
				// 批量加好友
				CGAddRelationBatch cgAddRelationBatch = new CGAddRelationBatch(RelationTypeEnum.FRIEND.getIndex(), idArr);
				sendMessage(cgAddRelationBatch);
			}
			
			
		}
	}
}
