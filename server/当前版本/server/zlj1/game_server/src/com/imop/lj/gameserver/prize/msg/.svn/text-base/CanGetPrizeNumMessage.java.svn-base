package com.imop.lj.gameserver.prize.msg;

import java.util.List;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.async.PlayerQueryPrizes;
import com.imop.lj.gameserver.player.async.PlayerQueryPrizesCallback;
import com.imop.lj.gameserver.prize.PlatformPrizeHolder;
import com.imop.lj.gameserver.prize.UserPrizeInfo;
/**
 * 获取玩家可领取礼包数量，并发消息给前台
 * 此消息要put到玩家消息队列中
 * @author yu.zhao
 *
 */
public class CanGetPrizeNumMessage extends SysInternalMessage {
	
	private Player player;
	
	public CanGetPrizeNumMessage(Player player) {
		super();
		this.player = player;
	}

	@Override
	public void execute() {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		// 查询local和gm奖励
		PlayerQueryPrizes operation = new PlayerQueryPrizes(player, new PlayerQueryPrizesCallback() {
			/**
			 * 查询完奖励后，通知前台玩家可领取礼包数量
			 */
			@Override
			public void afterQueryComplete(Player player, boolean platFormQuery,
					List<PlatformPrizeHolder> platformPrizeHolders,
					boolean userPrizeQuery, List<UserPrizeInfo> userPrizes) {

				int num = 0;
				// 如果local或gm奖励任意一个有数据
				if(platFormQuery || userPrizeQuery) {
					// local的奖励数据
					if (platformPrizeHolders != null) {
						num += platformPrizeHolders.size();
					}
					// gm的奖励数据
					if (userPrizes != null) {
						num += userPrizes.size();
					}
				}
				// 给玩家发消息
				if (player != null) {
					Human human = player.getHuman();
					if(human != null){
						human.setPrizeNum(num);
						Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.USER_PRIZE);
					}
				}
			}
			
		});
		Globals.getAsyncService().createOperationAndExecuteAtOnce(operation, player.getRoleUUID());
	}
	
}
