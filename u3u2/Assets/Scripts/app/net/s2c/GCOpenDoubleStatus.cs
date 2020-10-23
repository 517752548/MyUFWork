
using System;
namespace app.net
{
/**
 * 返回结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenDoubleStatus :BaseMessage
{
	/** 操作结果，1成功，2失败 */
	private int result;
	/** 剩余双倍点数 */
	private int curDoublePoint;

	public GCOpenDoubleStatus ()
	{
	}

	protected override void ReadImpl()
	{
	// 操作结果，1成功，2失败
	int _result = ReadInt();
	// 剩余双倍点数
	int _curDoublePoint = ReadInt();


		this.result = _result;
		this.curDoublePoint = _curDoublePoint;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_DOUBLE_STATUS;
	}
	
	public override string getEventType()
	{
		return TowerGCHandler.GCOpenDoubleStatusEvent;
	}
	

	public int getResult(){
		return result;
	}
		

	public int getCurDoublePoint(){
		return curDoublePoint;
	}
		

}
}