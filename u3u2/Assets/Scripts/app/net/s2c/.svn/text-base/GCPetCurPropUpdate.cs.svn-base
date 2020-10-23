
using System;
namespace app.net
{
/**
 * 武将hp、mp、life、sp当前值更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetCurPropUpdate :BaseMessage
{
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

	public GCPetCurPropUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 武将唯一Id
	long _petId = ReadLong();
	// 当前血
	int _hp = ReadInt();
	// 当前蓝
	int _mp = ReadInt();
	// 当前寿命
	int _life = ReadInt();
	// 当前怒气
	int _sp = ReadInt();


		this.petId = _petId;
		this.hp = _hp;
		this.mp = _mp;
		this.life = _life;
		this.sp = _sp;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_CUR_PROP_UPDATE;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetCurPropUpdateEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getHp(){
		return hp;
	}
		

	public int getMp(){
		return mp;
	}
		

	public int getLife(){
		return life;
	}
		

	public int getSp(){
		return sp;
	}
		

}
}