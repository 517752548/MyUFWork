
using System;
namespace app.net
{
/**
 * 骑宠忠诚度,亲密度,生命值当前值更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseCurPropUpdate :BaseMessage
{
	/** 骑宠唯一Id */
	private long petId;
	/** 当前忠诚度 */
	private int loy;
	/** 当前亲密度 */
	private int clo;
	/** 当前生命 */
	private int life;
	/** 到期时间 */
	private long deadline;

	public GCPetHorseCurPropUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 骑宠唯一Id
	long _petId = ReadLong();
	// 当前忠诚度
	int _loy = ReadInt();
	// 当前亲密度
	int _clo = ReadInt();
	// 当前生命
	int _life = ReadInt();
	// 到期时间
	long _deadline = ReadLong();


		this.petId = _petId;
		this.loy = _loy;
		this.clo = _clo;
		this.life = _life;
		this.deadline = _deadline;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_HORSE_CUR_PROP_UPDATE;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetHorseCurPropUpdateEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getLoy(){
		return loy;
	}
		

	public int getClo(){
		return clo;
	}
		

	public int getLife(){
		return life;
	}
		

	public long getDeadline(){
		return deadline;
	}
		

}
}