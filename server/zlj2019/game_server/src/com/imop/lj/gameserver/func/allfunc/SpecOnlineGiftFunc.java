package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.onlinegift.template.SpecOnlineGiftTemplate;

public class SpecOnlineGiftFunc extends AbstractFunc {

	public SpecOnlineGiftFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}

	@Override
	public boolean canOpen() {
		return false;//getOwner().getSpecOnlineGiftManager().isOpening();
	}

	@Override
	public boolean canShowEffect() {
		return getCountDownTime() <= 0;
	}

	@Override
	public int getShowNum() {
		return 0;
	}

	@Override
	public long getCountDownTime() {
		return 0;
//		if(getOwner().getSpecOnlineGiftManager().isOpening()){
//			return getOwner().getSpecOnlineGiftManager().getCd();
//		}else{
//			return 0;
//		}
	}

	@Override
	public String getIcon() {
		return "";
//		SpecOnlineGiftTemplate tmpl = getOwner().getSpecOnlineGiftManager().getCurrReceiveOnlineGiftTemplate();
//		if(tmpl == null){
//			return "";
//		}else{
//			return tmpl.getIconId();
//		}
	}

	@Override
	public long getMaxCountDownTime() {
		return 0;
//		SpecOnlineGiftTemplate tmpl = getOwner().getSpecOnlineGiftManager().getCurrReceiveOnlineGiftTemplate();
//		if(tmpl == null){
//			return 1L;
//		}else{
//			return tmpl.getCd();
//		}
	}

	@Override
	public String getMenuDesc() {
		return "";
//		SpecOnlineGiftTemplate tmpl = getOwner().getSpecOnlineGiftManager().getCurrReceiveOnlineGiftTemplate();
//		if(tmpl == null){
//			return "";
//		}else{
//			return tmpl.getMenuDesc();
//		}
	}

	
}
