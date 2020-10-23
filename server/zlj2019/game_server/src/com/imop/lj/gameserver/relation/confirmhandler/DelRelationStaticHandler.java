package com.imop.lj.gameserver.relation.confirmhandler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;
import com.imop.lj.gameserver.relation.RelationTypeEnum;

/**
 * 删除关系二次确认
 * 
 */
public class DelRelationStaticHandler extends IStaticHandler {

	private RelationTypeEnum relationType;
	private long targetCharId;
	private String targetName;
	
	public DelRelationStaticHandler(RelationTypeEnum relationType, long targetCharId, String targetName) {
		this.relationType = relationType;
		this.targetCharId = targetCharId;
		this.targetName = targetName;
		
	}

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			// 确认删除
			Globals.getRelationService().delRelationConfirm(human, relationType, targetCharId, targetName);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.RELATION_REMOVE_RELATION;
	}
}
