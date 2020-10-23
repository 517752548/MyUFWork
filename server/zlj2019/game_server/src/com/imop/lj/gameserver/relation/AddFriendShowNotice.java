package com.imop.lj.gameserver.relation;

import com.imop.lj.common.constants.GameConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.INoticeTipsHandler;
import com.imop.lj.gameserver.player.Player;

public class AddFriendShowNotice implements INoticeTipsHandler {
	// 玩家的角色id
	private long charId;
	// 被加的角色名。
	private String targetName;

	public AddFriendShowNotice(long charId, String targetName) {
		super();
		this.charId = charId;
		this.targetName = targetName;
	}

	@Override
	public void exec(String value) {
		if (GameConstants.OPTION_OK.equals(value)) {
			Player player = Globals.getOnlinePlayerService().getPlayer(charId);
			Globals.getRelationService().addRelation(player.getHuman(), targetName, RelationTypeEnum.FRIEND);
		}
	}
}
