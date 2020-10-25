package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 武将hp、mp、life、sp当前值更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetCurPropUpdate extends GCMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 当前血 */
	private int hp;
	/** 当前蓝 */
	private int mp;
	/** 当前寿命 */
	private int life;
	/** 当前怒气 */
	private int sp;

	public GCPetCurPropUpdate (){
	}
	
	public GCPetCurPropUpdate (
			long petId,
			int hp,
			int mp,
			int life,
			int sp ){
			this.petId = petId;
			this.hp = hp;
			this.mp = mp;
			this.life = life;
			this.sp = sp;
	}

	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 当前血
	int _hp = readInteger();
	//end


	// 当前蓝
	int _mp = readInteger();
	//end


	// 当前寿命
	int _life = readInteger();
	//end


	// 当前怒气
	int _sp = readInteger();
	//end



		this.petId = _petId;
		this.hp = _hp;
		this.mp = _mp;
		this.life = _life;
		this.sp = _sp;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 当前血
	writeInteger(hp);


	// 当前蓝
	writeInteger(mp);


	// 当前寿命
	writeInteger(life);


	// 当前怒气
	writeInteger(sp);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_CUR_PROP_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_CUR_PROP_UPDATE";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getHp(){
		return hp;
	}
		
	public void setHp(int hp){
		this.hp = hp;
	}

	public int getMp(){
		return mp;
	}
		
	public void setMp(int mp){
		this.mp = mp;
	}

	public int getLife(){
		return life;
	}
		
	public void setLife(int life){
		this.life = life;
	}

	public int getSp(){
		return sp;
	}
		
	public void setSp(int sp){
		this.sp = sp;
	}
}