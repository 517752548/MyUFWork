package com.imop.lj.gameserver.player.async;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.db.model.UserPrize;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.prize.PlatformPrizeHolder;
import com.imop.lj.gameserver.prize.PrizeDef;
import com.imop.lj.gameserver.prize.UserPrizeInfo;
import com.imop.platform.local.response.GoodsInfo;
import com.imop.platform.local.response.QueryGoodsResponse;

/**
 * 查询平台奖励列表和gm补偿列表
 * 
 * 
 * 经讨论:查询gm补偿和平台奖励任何一个操作成功,这个操作就算成功;
 * 只有两个操作都失败了,才算这个操作失败
 */
public class PlayerQueryPrizes implements LocalBindUUIDIoOperation {

	private final static Logger logger = Loggers.prizeLogger;

	private Player player;
	/** 调用平台查询返回的结果 */
	private volatile QueryGoodsResponse response;
	/** GM补偿列表 */
	private List<UserPrizeInfo> userPrizes;
	/** 平台奖励列表 */
	private List<PlatformPrizeHolder> platformPrizeHolders;
//	/** 平台奖励列表 转换成userPrizeInfo */
//	private List<PlatformPrizeHolder> platformPrizeTranster;
	private boolean platFormQuery = true;
	
	private boolean userPrizeQuery = true;
	
	private PlayerQueryPrizesCallback callback;

	public PlayerQueryPrizes(Player player,PlayerQueryPrizesCallback callback) {
		this.player = player;
		this.callback = callback;
	}

	@Override
	public int doIo() {
		// 查询平台的奖励
		if (Globals.getServerConfig().isTurnOnLocalInterface()) {
			//TODO FIXME 暂时注掉平台奖励
//			queryPlatFormPrize();
		}
		// 查询gm补偿的奖励
		queryUserPrizes();

		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		// 为了通用成功和失败之后的具体操作交给callback处理
		callback.afterQueryComplete(player, platFormQuery, platformPrizeHolders, userPrizeQuery, userPrizes);

		return IIoOperation.STAGE_STOP_DONE;
	}
	
	private void queryPlatFormPrize(){
		// 调用接口
		try {
			response = Globals.getSynLocalService().queryGoods(
					player.getPassportId(), player.getRoleUUID() + "",
					player.getClientIp());
		} catch (Exception ex) {
			logger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", "玩家在查询平台奖励时出错"), ex);
			platFormQuery = false;
		}

		if (response != null && response.isSuccess() && platFormQuery) {
			platformPrizeHolders = new ArrayList<PlatformPrizeHolder>();

			// 检查奖励是否存在
			List<GoodsInfo> goods = response.getGoodsInfoList();
			for (GoodsInfo gi : goods) {
				try {
					PlatformPrizeHolder holder = Globals.getPrizeService().fetchPlatformPrizeByPrizeId(gi.getId(), gi.getGoodsId());
					if (holder == null) {
						logger.error("平台奖励不存在，prizeId : " + gi.getGoodsId());
						continue;
					}
					platformPrizeHolders.add(holder);
				} catch (IllegalArgumentException ex) {
					logger.error("奖励配置错误，prizeId : " + gi.getGoodsId(), ex);
					platFormQuery = false;
					break;
				} catch (Exception ex) {
					logger.error("查询平台奖励时，从本地数据库中查询出错，prizeId : "
							+ gi.getGoodsId(), ex);
					platFormQuery = false;
					break;
				}
			}
		}
		else{
			platFormQuery = false;
		}
	}
	
	private void queryUserPrizes() {
		try {
			// 查询数据库
			Human human = player.getHuman();
			if(human == null){
				return;
			}
			List<UserPrize> prizeList = Globals.getPrizeService().fetchUserPrizeNameListByPassportId(human.getUUID());
			if(prizeList != null
					&& prizeList.size() > 0){
				userPrizes = UserPrizeInfo.getFromUserPrizes(prizeList);
				for(UserPrizeInfo info : userPrizes){
					info.setPrizeType(PrizeDef.PRIZE_TYPE_GM);
				}
			}
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", "访问奖励数据库异常，PlayerQueryUserPrizes.doIo，passportId = "
								+ player.getPassportId()));
			}
			userPrizeQuery = false;
		}
	}

	@Override
	public long getBindUUID() {
		return this.player.getRoleUUID();
	}

}