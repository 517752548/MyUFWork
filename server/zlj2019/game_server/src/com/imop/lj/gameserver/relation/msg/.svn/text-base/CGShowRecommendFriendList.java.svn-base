package com.imop.lj.gameserver.relation.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.relation.handler.RelationHandlerFactory;

/**
 * 显示好友推荐面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGShowRecommendFriendList extends CGMessage{
	
	
	public CGShowRecommendFriendList (){
	}
	
	
	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SHOW_RECOMMEND_FRIEND_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SHOW_RECOMMEND_FRIEND_LIST";
	}


	@Override
	public void execute() {
		RelationHandlerFactory.getHandler().handleShowRecommendFriendList(this.getSession().getPlayer(), this);
	}
}