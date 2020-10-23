using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * npc模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class NpcTemplateVO : TemplateObject
	{
	/// <summary>
    /// npc类型
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int type;

	/// <summary>
    /// 是否不显示对话面板，0显示，1不显示
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int notShowPanelInt;

	/// <summary>
    /// NPC名字多语言Id
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public long nameLangId;

	/// <summary>
    /// npc名字
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public string name;

	/// <summary>
    /// NPC对话多语言Id
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public long talkLangId;

	/// <summary>
    /// npc常规对话内容
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public string talk;

	/// <summary>
    /// 3D模型
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public string model3DId;

	/// <summary>
    /// 2D模型
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public string model2DId;

	/// <summary>
    /// 方向
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int direction;

	/// <summary>
    /// 功能Id列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "10;11;12;13;14")
	public List<int> fuctionIdList;

	/// <summary>
    /// 目标地图Id
    /// </summary>
	//@ExcelCellBinding(offset = 15)
	public int targetMapId;

	/// <summary>
    /// 战斗敌人组Id
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public int enemyGroupId;

	/// <summary>
    /// 音乐Id
    /// </summary>
	//@ExcelCellBinding(offset = 17)
	public string musicId;

	/// <summary>
    /// 任务限制（多个分号隔开，只有有这个任务的时候，才显示）
    /// </summary>
	//@ExcelCellBinding(offset = 18)
	public string questLimit;

	/// <summary>
    /// NPC循环播放文字列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.npc.template.npcGetLoopStrTemplate.class, collectionNumber = "19,20;21,22;23,24")
	public List<npcGetLoopStrTemplate> loopStrList;


}
}