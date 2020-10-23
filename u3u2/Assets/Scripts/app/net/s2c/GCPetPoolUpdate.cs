
using System;
namespace app.net
{
/**
 * 武将池数值更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetPoolUpdate :BaseMessage
{
	/** 当前血池 */
	private long hpPool;
	/** 当前蓝池 */
	private long mpPool;
	/** 当前寿命池 */
	private long lifePool;

	public GCPetPoolUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 当前血池
	long _hpPool = ReadLong();
	// 当前蓝池
	long _mpPool = ReadLong();
	// 当前寿命池
	long _lifePool = ReadLong();


		this.hpPool = _hpPool;
		this.mpPool = _mpPool;
		this.lifePool = _lifePool;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_POOL_UPDATE;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetPoolUpdateEvent;
	}
	

	public long getHpPool(){
		return hpPool;
	}
		

	public long getMpPool(){
		return mpPool;
	}
		

	public long getLifePool(){
		return lifePool;
	}
		

}
}