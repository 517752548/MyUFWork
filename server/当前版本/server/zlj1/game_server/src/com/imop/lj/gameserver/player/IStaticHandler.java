package com.imop.lj.gameserver.player;

import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;

/**
 * 静态处理器，保存玩家临时操作，主要用于对话框确认操作
 *
 */
public abstract class IStaticHandler {
	/**
	 * 执行玩家的操作
	 *
	 * @param player
	 * @param value
	 */
	public abstract void exec(Human human, boolean isOk);
	
	public abstract ConsumeConfirm getConsumeConfirm();

	/**
	 * 设置提示
	 * @param isSelected
	 */
	public void setConfirm(Human human,int isSelected){
		human.setConsumeConfirm(getConsumeConfirm(), isSelected == 1 ? true : false);
	}
}
