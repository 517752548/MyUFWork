package com.imop.lj.gameserver.player.async;

import java.util.List;

import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.prize.PlatformPrizeHolder;
import com.imop.lj.gameserver.prize.UserPrizeInfo;


/**
 * 查询玩家的平台奖励和gm补偿奖励的callback
 * 
 * @author fanghua.cui
 *
 */
public interface PlayerQueryPrizesCallback {
	
	public void afterQueryComplete(Player player,boolean platFormQuery,List<PlatformPrizeHolder> platformPrizeHolders,boolean userPrizeQuery,List<UserPrizeInfo> userPrizes);

}
