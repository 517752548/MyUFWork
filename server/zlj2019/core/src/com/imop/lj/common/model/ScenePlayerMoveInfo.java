package com.imop.lj.common.model;

public class ScenePlayerMoveInfo {
	/** 角色id */
	private long uuid;
	/** x坐标 */
	private int x;
	/** y坐标 */
	private int y;
	/** 是否瞬移 */
	private int instantFlag;
	
	public ScenePlayerMoveInfo() {
		
	}
	
	public ScenePlayerMoveInfo(long uuid, int x, int y) {
		this.uuid = uuid;
		this.x = x;
		this.y = y;
	}
	
	public ScenePlayerMoveInfo(long uuid, int x, int y, int instantFlag) {
		this.uuid = uuid;
		this.x = x;
		this.y = y;
		this.instantFlag = instantFlag;
	}
	
	public long getUuid() {
		return uuid;
	}

	public void setUuid(long uuid) {
		this.uuid = uuid;
	}

	public int getX() {
		return x;
	}

	public void setX(int x) {
		this.x = x;
	}

	public int getY() {
		return y;
	}

	public void setY(int y) {
		this.y = y;
	}

	public int getInstantFlag() {
		return instantFlag;
	}

	public void setInstantFlag(int instantFlag) {
		this.instantFlag = instantFlag;
	}

}
