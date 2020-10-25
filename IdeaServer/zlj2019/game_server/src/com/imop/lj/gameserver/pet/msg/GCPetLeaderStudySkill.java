package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 主将学习技能结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetLeaderStudySkill extends GCMessage{
	
	/** 技能书道具Id */
	private int itemTplId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetLeaderStudySkill (){
	}
	
	public GCPetLeaderStudySkill (
			int itemTplId,
			int result ){
			this.itemTplId = itemTplId;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 技能书道具Id
	int _itemTplId = readInteger();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.itemTplId = _itemTplId;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能书道具Id
	writeInteger(itemTplId);


	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_LEADER_STUDY_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_LEADER_STUDY_SKILL";
	}

	public int getItemTplId(){
		return itemTplId;
	}
		
	public void setItemTplId(int itemTplId){
		this.itemTplId = itemTplId;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}