package com.imop.lj.gameserver.goodactivity.useractivity.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.VipLevelActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.VipLevelUserDataModel;

public class VipLevelUserGoodActivity extends AbstractUserGoodActivity {

	public VipLevelUserGoodActivity(long charId, VipLevelActivity activity) {
		super(charId, activity);
	}
	
	protected VipLevelUserDataModel buildUserDataModel() {
		return new VipLevelUserDataModel(this);
	}

}
