package com.imop.lj.gameserver.scene.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.scene.handler.SceneHandlerFactory;

/**
 * 场景移除的玩家
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGScenePlayerMove extends CGMessage{
	
	/** x坐标 */
	private int x;
	/** y坐标 */
	private int y;
	
	public CGScenePlayerMove (){
	}
	
	public CGScenePlayerMove (
			int x,
			int y ){
			this.x = x;
			this.y = y;
	}
	
	@Override
	protected boolean readImpl() {

	// x坐标
	int _x = readInteger();
	//end


	// y坐标
	int _y = readInteger();
	//end



			this.x = _x;
			this.y = _y;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// x坐标
	writeInteger(x);


	// y坐标
	writeInteger(y);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SCENE_PLAYER_MOVE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SCENE_PLAYER_MOVE";
	}

	public int getX(){
		return x;
	}
		
	public void setX(int x){
		this.x = x;
	}

	public int getY(){
		return y;
	}
		
	public void setY(int y){
		this.y = y;
	}


	@Override
	public void execute() {
		SceneHandlerFactory.getHandler().handleScenePlayerMove(this.getSession().getPlayer(), this);
	}
}