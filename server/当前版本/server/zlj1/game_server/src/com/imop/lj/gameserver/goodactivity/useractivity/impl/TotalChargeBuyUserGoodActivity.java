package com.imop.lj.gameserver.goodactivity.useractivity.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.TotalChargeBuyActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.TotalChargeBuyUserDataModel;

public class TotalChargeBuyUserGoodActivity extends AbstractUserGoodActivity {

	public TotalChargeBuyUserGoodActivity(long charId, TotalChargeBuyActivity activity) {
		super(charId, activity);
		
	}
	
	protected TotalChargeBuyUserDataModel buildUserDataModel() {
		return new TotalChargeBuyUserDataModel(this);
	}
	
}
