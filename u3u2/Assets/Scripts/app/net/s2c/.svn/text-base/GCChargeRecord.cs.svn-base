
using System;
namespace app.net
{
/**
 * 充值记录
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChargeRecord :BaseMessage
{
	/** 已充值模板id */
	private int[] tplId;

	public GCChargeRecord ()
	{
	}

	protected override void ReadImpl()
	{
	// 已充值模板id
	int tplIdSize = ReadShort();
	int[] _tplId = new int[tplIdSize];
	int tplIdIndex = 0;
	for(tplIdIndex=0; tplIdIndex<tplIdSize; tplIdIndex++){
		_tplId[tplIdIndex] = ReadInt();
	}//end
	


		this.tplId = _tplId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CHARGE_RECORD;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCChargeRecordEvent;
	}
	

	public int[] getTplId(){
		return tplId;
	}


}
}