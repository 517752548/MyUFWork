package com.imop.lj.gameserver.func;

import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public abstract class AbstractFunc implements IFunc {
	/** 所属玩家 */
	private Human owner;
	/** 功能类型，功能的唯一标识 */
	private FuncTypeEnum funcType;
	
	/** 状态变化需要的属性 */
	private boolean isOpening;
	private boolean isShowingEffect;
	private boolean isCountingDown;
	private int showNum;
	
	public AbstractFunc(Human human, FuncTypeEnum funcType) {
		this.owner = human;
		this.funcType = funcType;
		init();
	}
	
	public void init() {
		this.isOpening = false;
		this.isShowingEffect = false;
		this.isCountingDown = false;
		this.showNum = 0;
	}
	
	public Human getOwner() {
		return owner;
	}
	
	@Override
	public FuncTypeEnum getFuncType() {
		return funcType;
	}
	
	@Override
	public boolean onChanged() {
		boolean isChanged = false;
		// 需要开启
		if (canOpen()) {
			// 由关到开
			if (!isOpening) {
				isChanged = true;
				isOpening = true;
			}
			
			// 特效
			if (canShowEffect()) {
				if (!isShowingEffect) {
					// 特效从无到有
					isChanged = true;
				}
				isShowingEffect = true;
			} else {
				// 特效从有到无
				if (isShowingEffect) {
					isChanged = true;
				}
				isShowingEffect = false;
			}
			
			// 倒计时
			if (getCountDownTime() > 0) {
				// 倒计时从无到有
				if (!isCountingDown) {
					isChanged = true;
				}
				isCountingDown = true;
			} else {
				if (isCountingDown) {
					// 倒计时从有到无
					isChanged = true;
				}
				isCountingDown = false;
			}
			
			// 角标
			int newShowNum = getShowNum();
			if (showNum != newShowNum) {
				// 角标变化
				isChanged = true;
				showNum = newShowNum;
			}
			
		} else {// 需要关闭
			// 由开到关
			if (isOpening) {
				isChanged = true;
				isOpening = false;
			}
		}
		return isChanged;
	}

	@Override
	public abstract boolean canOpen();

	@Override
	public abstract boolean canShowEffect();

	@Override
	public abstract int getShowNum();

	@Override
	public abstract long getCountDownTime();

	@Override
	public String getIcon() {
		return Integer.toString(funcType.getIndex());
	}

	@Override
	public long getMaxCountDownTime() {
		return 0;
	}

	@Override
	public String getMenuDesc() {
		return "";
	}
	
	
}
