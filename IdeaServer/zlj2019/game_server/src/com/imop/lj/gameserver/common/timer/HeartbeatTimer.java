package com.imop.lj.gameserver.common.timer;

/**
 * 用于控制心跳频率的计时器
 *
 * @author li.liu
 * @since 2010-8-11
 */
public interface HeartbeatTimer {

	/**
	 * 是否已经到时
	 *
	 * @return
	 */
	boolean isTimeUp();

	/**
	 * 重置，开始下一轮计时
	 */
	void nextRound();
}
