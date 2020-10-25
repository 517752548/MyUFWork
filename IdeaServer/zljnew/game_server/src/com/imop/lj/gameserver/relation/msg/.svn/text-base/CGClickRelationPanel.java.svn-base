package com.imop.lj.gameserver.relation.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.relation.handler.RelationHandlerFactory;

/**
 * 打开好友面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickRelationPanel extends CGMessage{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 页码 */
	private int page;
	
	public CGClickRelationPanel (){
	}
	
	public CGClickRelationPanel (
			int relationType,
			int page ){
			this.relationType = relationType;
			this.page = page;
	}
	
	@Override
	protected boolean readImpl() {

	// 1好友，2黑名单
	int _relationType = readInteger();
	//end


	// 页码
	int _page = readInteger();
	//end



			this.relationType = _relationType;
			this.page = _page;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1好友，2黑名单
	writeInteger(relationType);


	// 页码
	writeInteger(page);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CLICK_RELATION_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CLICK_RELATION_PANEL";
	}

	public int getRelationType(){
		return relationType;
	}
		
	public void setRelationType(int relationType){
		this.relationType = relationType;
	}

	public int getPage(){
		return page;
	}
		
	public void setPage(int page){
		this.page = page;
	}


	@Override
	public void execute() {
		RelationHandlerFactory.getHandler().handleClickRelationPanel(this.getSession().getPlayer(), this);
	}
}