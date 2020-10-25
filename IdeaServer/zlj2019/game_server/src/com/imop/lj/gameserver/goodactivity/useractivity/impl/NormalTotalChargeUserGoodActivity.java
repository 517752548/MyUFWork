package com.imop.lj.gameserver.goodactivity.useractivity.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.NormalTotalChargeActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.NormalTotalChargeUserDataModel;

public class NormalTotalChargeUserGoodActivity extends AbstractUserGoodActivity {

	public NormalTotalChargeUserGoodActivity(long charId, NormalTotalChargeActivity activity) {
		super(charId, activity);
		
	}
	
	protected NormalTotalChargeUserDataModel buildUserDataModel() {
		return new NormalTotalChargeUserDataModel(this);
	}
	
}
