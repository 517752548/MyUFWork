package com.imop.lj.gameserver.goodactivity.useractivity.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.TotalCostActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.TotalCostUserDataModel;

public class TotalCostUserGoodActivity extends AbstractUserGoodActivity {

	public TotalCostUserGoodActivity(long charId, TotalCostActivity activity) {
		super(charId, activity);
		
	}
	
	protected TotalCostUserDataModel buildUserDataModel() {
		return new TotalCostUserDataModel(this);
	}
	
}
