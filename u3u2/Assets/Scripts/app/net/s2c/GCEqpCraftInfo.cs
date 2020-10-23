
using System;
namespace app.net
{
/**
 * 打造信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpCraftInfo :BaseMessage
{
	/** 打造花费模板Id */
	private int costTplId;
	/** 阶数 */
	private int gradeId;
	/** 打造数据 */
	private CraftInfoData craftInfo;

	public GCEqpCraftInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 打造花费模板Id
	int _costTplId = ReadInt();
	// 阶数
	int _gradeId = ReadInt();
	// 打造数据
	CraftInfoData _craftInfo = new CraftInfoData();
	// 基础属性key
	int _craftInfo_baseAttrKey = ReadInt();	_craftInfo.baseAttrKey = _craftInfo_baseAttrKey;
	// 基础属性数值
	int _craftInfo_baseAttrValue = ReadInt();	_craftInfo.baseAttrValue = _craftInfo_baseAttrValue;
	// 最大孔数
	int _craftInfo_holeMaxNum = ReadInt();	_craftInfo.holeMaxNum = _craftInfo_holeMaxNum;

	// 大概率属性列表
	int craftInfo_craftAttrInfosSize = ReadShort();
	CraftAttrInfoData[] _craftInfo_craftAttrInfos = new CraftAttrInfoData[craftInfo_craftAttrInfosSize];
	int craftInfo_craftAttrInfosIndex = 0;
	CraftAttrInfoData _craftInfo_craftAttrInfosTmp = null;
	for(craftInfo_craftAttrInfosIndex=0; craftInfo_craftAttrInfosIndex<craftInfo_craftAttrInfosSize; craftInfo_craftAttrInfosIndex++){
		_craftInfo_craftAttrInfosTmp = new CraftAttrInfoData();
		_craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex] = _craftInfo_craftAttrInfosTmp;
	// 属性key
	int _craftInfo_craftAttrInfos_attrKey = ReadInt();	_craftInfo_craftAttrInfosTmp.attrKey = _craftInfo_craftAttrInfos_attrKey;
		// 属性最小值
	int _craftInfo_craftAttrInfos_min = ReadInt();	_craftInfo_craftAttrInfosTmp.min = _craftInfo_craftAttrInfos_min;
		// 属性最大值
	int _craftInfo_craftAttrInfos_max = ReadInt();	_craftInfo_craftAttrInfosTmp.max = _craftInfo_craftAttrInfos_max;
		// 属性概率*100
	int _craftInfo_craftAttrInfos_prob = ReadInt();	_craftInfo_craftAttrInfosTmp.prob = _craftInfo_craftAttrInfos_prob;
		}
	//end
	_craftInfo.craftAttrInfos = _craftInfo_craftAttrInfos;

	// 属性条数列表
	int craftInfo_craftAttrNumInfosSize = ReadShort();
	CraftAttrNumInfoData[] _craftInfo_craftAttrNumInfos = new CraftAttrNumInfoData[craftInfo_craftAttrNumInfosSize];
	int craftInfo_craftAttrNumInfosIndex = 0;
	CraftAttrNumInfoData _craftInfo_craftAttrNumInfosTmp = null;
	for(craftInfo_craftAttrNumInfosIndex=0; craftInfo_craftAttrNumInfosIndex<craftInfo_craftAttrNumInfosSize; craftInfo_craftAttrNumInfosIndex++){
		_craftInfo_craftAttrNumInfosTmp = new CraftAttrNumInfoData();
		_craftInfo_craftAttrNumInfos[craftInfo_craftAttrNumInfosIndex] = _craftInfo_craftAttrNumInfosTmp;
	// 属性个数
	int _craftInfo_craftAttrNumInfos_num = ReadInt();	_craftInfo_craftAttrNumInfosTmp.num = _craftInfo_craftAttrNumInfos_num;
		// 概率*100
	int _craftInfo_craftAttrNumInfos_prob = ReadInt();	_craftInfo_craftAttrNumInfosTmp.prob = _craftInfo_craftAttrNumInfos_prob;
		}
	//end
	_craftInfo.craftAttrNumInfos = _craftInfo_craftAttrNumInfos;



		this.costTplId = _costTplId;
		this.gradeId = _gradeId;
		this.craftInfo = _craftInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_EQP_CRAFT_INFO;
	}
	
	public override string getEventType()
	{
		return EquipGCHandler.GCEqpCraftInfoEvent;
	}
	

	public int getCostTplId(){
		return costTplId;
	}
		

	public int getGradeId(){
		return gradeId;
	}
		

	public CraftInfoData getCraftInfo(){
		return craftInfo;
	}
		

}
}