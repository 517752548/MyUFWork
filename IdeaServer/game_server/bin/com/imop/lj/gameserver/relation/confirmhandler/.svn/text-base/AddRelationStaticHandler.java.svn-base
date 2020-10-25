package com.imop.lj.gameserver.relation.confirmhandler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;
import com.imop.lj.gameserver.relation.RelationTypeEnum;

/**
 * 添加关系二次确认，目前只有添加黑名单时才需要二次确认
 * 
 */
public class AddRelationStaticHandler extends IStaticHandler {

	private RelationTypeEnum relationType;
	private long targetCharId;
	private String targetName;
	
	public AddRelationStaticHandler(RelationTypeEnum relationType, long targetCharId, String targetName) {
		this.relationType = relationType;
		this.targetCharId = targetCharId;
		this.targetName = targetName;
	}

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			// 确认删除
			Globals.getRelationService().addRelationConfirm(human, relationType, targetCharId, targetName, true);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.RELATION_ADD_BLACK_LIST;
	}
}
