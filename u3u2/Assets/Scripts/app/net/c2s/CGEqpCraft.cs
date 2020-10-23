using System;
using System.IO;
namespace app.net
{

/**
 * 打造装备
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpCraft :BaseMessage
{
	
	/** 打造花费模板Id */
	private int costTplId;
	/** 阶数 */
	private int gradeId;
	/** 材料数量列表 */
	private int[] itemNumList;
	/** 是否模拟，0否，1是 */
	private int isSimulate;
	
	public CGEqpCraft ()
	{
	}
	
	public CGEqpCraft (
			int costTplId,
			int gradeId,
			int[] itemNumList,
			int isSimulate )
	{
			this.costTplId = costTplId;
			this.gradeId = gradeId;
			this.itemNumList = itemNumList;
			this.isSimulate = isSimulate;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 打造花费模板Id
	WriteInt(costTplId);
	// 阶数
	WriteInt(gradeId);
	// 材料数量列表
	WriteShort((short)itemNumList.Length);
	int itemNumListSize = itemNumList.Length;
	int itemNumListIndex = 0;
	for(itemNumListIndex=0; itemNumListIndex<itemNumListSize; itemNumListIndex++){
		WriteInt(itemNumList [ itemNumListIndex ]);
	}//end
	
	// 是否模拟，0否，1是
	WriteInt(isSimulate);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EQP_CRAFT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public int[] getItemNumList()
	{
		return itemNumList;
	}

	public void setItemNumList(int[] itemNumList)
	{
		this.itemNumList = itemNumList;
	}
	}
}