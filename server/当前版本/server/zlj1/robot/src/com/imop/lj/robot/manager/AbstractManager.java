package com.imop.lj.robot.manager;

import com.imop.lj.robot.Robot;

public class AbstractManager implements IManager{

	private Robot owner = null;

	public AbstractManager(Robot owner)
	{
		this.owner = owner;
	}

	@Override
	public Robot getOwner() {
		return owner;
	}
}
