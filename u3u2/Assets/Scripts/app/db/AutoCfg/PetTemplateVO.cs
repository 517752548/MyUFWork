using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 英雄模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetTemplateVO : TemplateObject
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
    /// 类型
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int typeId;

	/// <summary>
    /// 攻击类型（1物理，2法术）
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int attackTypeId;

	/// <summary>
    /// 性别
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int sexId;

	/// <summary>
    /// 职业
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int jobId;

	/// <summary>
    /// 美术Id
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public string modelId;

	/// <summary>
    /// 音乐Id串
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public string musicIds;

	/// <summary>
    /// 模型缩放系数
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public string modelScale;

	/// <summary>
    /// 携带等级【宠物】
    /// </summary>
	//@ExcelCellBinding(offset = 10)
	public int fightLevel;

	/// <summary>
    /// 宠物类型（0普通，1高级宠，2神兽）
    /// </summary>
	//@ExcelCellBinding(offset = 11)
	public int petpetTypeId;

	/// <summary>
    /// 宠物类别（野兽、妖怪、精灵和人形）
    /// </summary>
	//@ExcelCellBinding(offset = 12)
	public int petpetKindId;

	/// <summary>
    /// 宠物捕捉成功率*十万
    /// </summary>
	//@ExcelCellBinding(offset = 13)
	public int catchProb;

	/// <summary>
    /// 捕捉道具ID
    /// </summary>
	//@ExcelCellBinding(offset = 14)
	public int catchItemId;

	/// <summary>
    /// 捕捉道具数量
    /// </summary>
	//@ExcelCellBinding(offset = 15)
	public int catchItemNum;

	/// <summary>
    /// 宠物变异颜色值
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public string petTransColor;

	/// <summary>
    /// 是否初始化变异,0-不变异,1-变异
    /// </summary>
	//@ExcelCellBinding(offset = 17)
	public int initGene;

	/// <summary>
    /// 初始成长率,0-默认随机
    /// </summary>
	//@ExcelCellBinding(offset = 18)
	public int initGrowth;

	/// <summary>
    /// 租借期,单位小时
    /// </summary>
	//@ExcelCellBinding(offset = 19)
	public int leasehold;

	/// <summary>
    /// 租借货币类型
    /// </summary>
	//@ExcelCellBinding(offset = 20)
	public int leaseCurrencyType;

	/// <summary>
    /// 租借货币数量
    /// </summary>
	//@ExcelCellBinding(offset = 21)
	public int leaseCurrencyCount;

	/// <summary>
    /// 续租道具Id
    /// </summary>
	//@ExcelCellBinding(offset = 22)
	public int leaseItemId;

	/// <summary>
    /// 图鉴排序Id
    /// </summary>
	//@ExcelCellBinding(offset = 23)
	public int sortId;

	/// <summary>
    /// 图鉴获取途径描述
    /// </summary>
	//@ExcelCellBinding(offset = 24)
	public string gotDesc;

	/// <summary>
    /// 强壮
    /// </summary>
	//@ExcelCellBinding(offset = 25)
	public int strength;

	/// <summary>
    /// 敏捷
    /// </summary>
	//@ExcelCellBinding(offset = 26)
	public int agility;

	/// <summary>
    /// 智力
    /// </summary>
	//@ExcelCellBinding(offset = 27)
	public int intellect;

	/// <summary>
    /// 信仰
    /// </summary>
	//@ExcelCellBinding(offset = 28)
	public int faith;

	/// <summary>
    /// 耐力
    /// </summary>
	//@ExcelCellBinding(offset = 29)
	public int stamina;

	/// <summary>
    /// 生命
    /// </summary>
	//@ExcelCellBinding(offset = 30)
	public long hp;

	/// <summary>
    /// 法力
    /// </summary>
	//@ExcelCellBinding(offset = 31)
	public int mp;

	/// <summary>
    /// 速度
    /// </summary>
	//@ExcelCellBinding(offset = 32)
	public int speed;

	/// <summary>
    /// 物理攻击
    /// </summary>
	//@ExcelCellBinding(offset = 33)
	public int physicalAttack;

	/// <summary>
    /// 物理护甲
    /// </summary>
	//@ExcelCellBinding(offset = 34)
	public int physicalArmor;

	/// <summary>
    /// 物理命中
    /// </summary>
	//@ExcelCellBinding(offset = 35)
	public int physicalHit;

	/// <summary>
    /// 物理闪避
    /// </summary>
	//@ExcelCellBinding(offset = 36)
	public int physicalDodgy;

	/// <summary>
    /// 物理暴击
    /// </summary>
	//@ExcelCellBinding(offset = 37)
	public int physicalCrit;

	/// <summary>
    /// 物理抗暴
    /// </summary>
	//@ExcelCellBinding(offset = 38)
	public int phsicalAntiCrit;

	/// <summary>
    /// 法术强度
    /// </summary>
	//@ExcelCellBinding(offset = 39)
	public int magicAttack;

	/// <summary>
    /// 法术抗性
    /// </summary>
	//@ExcelCellBinding(offset = 40)
	public int magicArmor;

	/// <summary>
    /// 法术命中
    /// </summary>
	//@ExcelCellBinding(offset = 41)
	public int magicHit;

	/// <summary>
    /// 法术抵抗
    /// </summary>
	//@ExcelCellBinding(offset = 42)
	public int magicDodgy;

	/// <summary>
    /// 法术暴击
    /// </summary>
	//@ExcelCellBinding(offset = 43)
	public int magicCrit;

	/// <summary>
    /// 法术抗暴
    /// </summary>
	//@ExcelCellBinding(offset = 44)
	public int magicAntiCrit;

	/// <summary>
    /// 怒气
    /// </summary>
	//@ExcelCellBinding(offset = 45)
	public int sp;

	/// <summary>
    /// 修为
    /// </summary>
	//@ExcelCellBinding(offset = 46)
	public int xw;

	/// <summary>
    /// 寿命
    /// </summary>
	//@ExcelCellBinding(offset = 47)
	public int life;

	/// <summary>
    /// 强壮成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 48)
	public int strengthGrowth;

	/// <summary>
    /// 敏捷成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 49)
	public int agilityGrowth;

	/// <summary>
    /// 智力成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 50)
	public int intellectGrowth;

	/// <summary>
    /// 信仰成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 51)
	public int faithGrowth;

	/// <summary>
    /// 耐力成长基础值
    /// </summary>
	//@ExcelCellBinding(offset = 52)
	public int staminaGrowth;

	/// <summary>
    /// 随机资质成长值
    /// </summary>
	//@ExcelCellBinding(offset = 53)
	public int randGrowth;

	/// <summary>
    /// 英雄介绍
    /// </summary>
	//@ExcelCellBinding(offset = 54)
	public string descInfo;

	/// <summary>
    /// 性格介绍
    /// </summary>
	//@ExcelCellBinding(offset = 55)
	public string charaInfo;

	/// <summary>
    /// 宠物天赋技能包Id
    /// </summary>
	//@ExcelCellBinding(offset = 56)
	public int petTalentSkillPackId;

	/// <summary>
    /// 宠物培养上限系数1
    /// </summary>
	//@ExcelCellBinding(offset = 57)
	public int petTrainCoef1;

	/// <summary>
    /// 宠物培养上限系数2
    /// </summary>
	//@ExcelCellBinding(offset = 58)
	public int petTrainCoef2;

	/// <summary>
    /// 技能列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.enemy.template.SkillItem.class, collectionNumber = "59,60,61;62,63,64;65,66,67;68,69,70;71,72,73")
	public List<SkillItem> skillList;

	/// <summary>
    /// 上架费用类型
    /// </summary>
	//@ExcelCellBinding(offset = 74)
	public int listingFeeType;

	/// <summary>
    /// 上架费用
    /// </summary>
	//@ExcelCellBinding(offset = 75)
	public int listingFee;

	/// <summary>
    /// 初始技能数量
    /// </summary>
	//@ExcelCellBinding(offset = 76)
	public int skillNum;

	/// <summary>
    /// 领悟天赋技能初始成功率,扩大1000倍
    /// </summary>
	//@ExcelCellBinding(offset = 77)
	public int senseTalentSkillRate;


}
}