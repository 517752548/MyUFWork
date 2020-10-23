using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 单个怪物表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EnemyTemplateVO : TemplateObject
	{
	/// <summary>
    /// 名称多语言Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public long nameLangId;

	/// <summary>
    /// 名称
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string name;

	/// <summary>
    /// 攻击类型Id
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int attackTypeId;

	/// <summary>
    /// 性别
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int sexId;

	/// <summary>
    /// 职业
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int jobId;

	/// <summary>
    /// 美术Id
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public string modelId;

	/// <summary>
    /// 音乐Id串
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public string musicIds;

	/// <summary>
    /// 模型高度
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public float modelHeight;

	/// <summary>
    /// 等级
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int level;

	/// <summary>
    /// 宠物Id（武将表Id）
    /// </summary>
	//@ExcelCellBinding(offset = 10)
	public int petTplId;

	/// <summary>
    /// 生命
    /// </summary>
	//@ExcelCellBinding(offset = 11)
	public long hp;

	/// <summary>
    /// 法力
    /// </summary>
	//@ExcelCellBinding(offset = 12)
	public int mp;

	/// <summary>
    /// 速度
    /// </summary>
	//@ExcelCellBinding(offset = 13)
	public int speed;

	/// <summary>
    /// 物理攻击
    /// </summary>
	//@ExcelCellBinding(offset = 14)
	public int physicalAttack;

	/// <summary>
    /// 物理护甲
    /// </summary>
	//@ExcelCellBinding(offset = 15)
	public int physicalArmor;

	/// <summary>
    /// 物理命中
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public int physicalHit;

	/// <summary>
    /// 物理闪避
    /// </summary>
	//@ExcelCellBinding(offset = 17)
	public int physicalDodgy;

	/// <summary>
    /// 物理暴击
    /// </summary>
	//@ExcelCellBinding(offset = 18)
	public int physicalCrit;

	/// <summary>
    /// 物理抗暴
    /// </summary>
	//@ExcelCellBinding(offset = 19)
	public int phsicalAntiCrit;

	/// <summary>
    /// 法术强度
    /// </summary>
	//@ExcelCellBinding(offset = 20)
	public int magicAttack;

	/// <summary>
    /// 法术抗性
    /// </summary>
	//@ExcelCellBinding(offset = 21)
	public int magicArmor;

	/// <summary>
    /// 法术命中
    /// </summary>
	//@ExcelCellBinding(offset = 22)
	public int magicHit;

	/// <summary>
    /// 法术抵抗
    /// </summary>
	//@ExcelCellBinding(offset = 23)
	public int magicDodgy;

	/// <summary>
    /// 法术暴击
    /// </summary>
	//@ExcelCellBinding(offset = 24)
	public int magicCrit;

	/// <summary>
    /// 法术抗暴
    /// </summary>
	//@ExcelCellBinding(offset = 25)
	public int magicAntiCrit;

	/// <summary>
    /// 怒气
    /// </summary>
	//@ExcelCellBinding(offset = 26)
	public int sp;

	/// <summary>
    /// 修为
    /// </summary>
	//@ExcelCellBinding(offset = 27)
	public int xw;

	/// <summary>
    /// 寿命
    /// </summary>
	//@ExcelCellBinding(offset = 28)
	public int life;

	/// <summary>
    /// 强壮成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 29)
	public int strengthGrowth;

	/// <summary>
    /// 敏捷成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 30)
	public int agilityGrowth;

	/// <summary>
    /// 智力成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 31)
	public int intellectGrowth;

	/// <summary>
    /// 信仰成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 32)
	public int faithGrowth;

	/// <summary>
    /// 耐力成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 33)
	public int staminaGrowth;

	/// <summary>
    /// 技能列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.enemy.template.SkillItem.class, collectionNumber = "34,35,36;37,38,39;40,41,42;43,44,45;46,47,48")
	public List<SkillItem> skillList;

	/// <summary>
    /// 说话列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = String.class, collectionNumber = "49;50;51")
	public List<string> speakList;


}
}