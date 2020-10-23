using System;
using System.IO;
namespace app.net
{

/**
 * 主将技能仙符升级
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetSkillEffectUplevel :BaseMessage
{
	
	/** 技能Id */
	private int skillId;
	/** 要升级的位置，从1开始计数 */
	private int posId;
	/** 选择的技能书道具索引列表 */
	private int[] itemIndexList;
	
	public CGPetSkillEffectUplevel ()
	{
	}
	
	public CGPetSkillEffectUplevel (
			int skillId,
			int posId,
			int[] itemIndexList )
	{
			this.skillId = skillId;
			this.posId = posId;
			this.itemIndexList = itemIndexList;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 技能Id
	WriteInt(skillId);
	// 要升级的位置，从1开始计数
	WriteInt(posId);
	// 选择的技能书道具索引列表
	WriteShort((short)itemIndexList.Length);
	int itemIndexListSize = itemIndexList.Length;
	int itemIndexListIndex = 0;
	for(itemIndexListIndex=0; itemIndexListIndex<itemIndexListSize; itemIndexListIndex++){
		WriteInt(itemIndexList [ itemIndexListIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_SKILL_EFFECT_UPLEVEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public int[] getItemIndexList()
	{
		return itemIndexList;
	}

	public void setItemIndexList(int[] itemIndexList)
	{
		this.itemIndexList = itemIndexList;
	}
	}
}