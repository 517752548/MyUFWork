package com.imop.lj.gameserver.goodactivity.useractivity.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.LevelUpActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.impl.LevelUpUserDataModel;

public class LevelUpUserGoodActivity extends AbstractUserGoodActivity {

	public LevelUpUserGoodActivity(long charId, LevelUpActivity activity) {
		super(charId, activity);
	}
	
	protected LevelUpUserDataModel buildUserDataModel() {
		return new LevelUpUserDataModel(this);
	}

}
