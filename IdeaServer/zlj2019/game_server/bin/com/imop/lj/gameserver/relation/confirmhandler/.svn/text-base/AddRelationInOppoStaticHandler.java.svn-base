package com.imop.lj.gameserver.relation.confirmhandler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;
import com.imop.lj.gameserver.relation.RelationTypeEnum;

/**
 * 添加已在另一个名单中的玩家确认框
 * 
 */
public class AddRelationInOppoStaticHandler extends IStaticHandler {

	private RelationTypeEnum relationType;
	private long targetCharId;
	private String targetName;
	
	public AddRelationInOppoStaticHandler(RelationTypeEnum relationType, long targetCharId, String targetName) {
		this.relationType = relationType;
		this.targetCharId = targetCharId;
		this.targetName = targetName;
	}

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			// 确认添加
			Globals.getRelationService().addRelationInOppoConfirm(human, relationType, targetCharId, targetName);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.RELATION_ADD_EXIST_IN_OPPO;
	}
}
