package com.imop.lj.gameserver.role.properties;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.annotation.Type;

import java.util.BitSet;

/**
 * 基础角色属性（人物角色，宠物公用）: 数值型 ， 统一作为Integer处理
 * 
 */
public class RoleBaseIntProperties extends GenericPropertyObject<Integer> {

	/** 基础整型属性索引开始值 */
	public static int _BEGIN = 0;

	/** 基础整型属性索引结束值 */
	public static int _END = _BEGIN;

	/* 公用 */
	@Comment(content = "等级")
	@Type(Integer.class)
	public static final int LEVEL = ++_END;// 501

	@Comment(content = "武将类型")
	@Type(Integer.class)
	public static final int PET_TYPE = ++_END;// 502

	@Comment(content = "PET模板ID")
	@Type(Integer.class)
	public static final int TEMPLET_ID = ++_END;// 503

	@Comment(content = "HUMAN的VIP等级")
	@Type(Integer.class)
	public static final int VIP_LEVEL = ++_END;//504
	
	@Comment(content = "HUMAN头像")
	@Type(Integer.class)
	public static final int PHOTO = ++_END;//505
	
	@Comment(content = "HUMAN场景Id")
	@Type(Integer.class)
	public static final int SCENE_ID = ++_END;//506
	
	@Comment(content = "HUMAN国家ID")
	@Type(Integer.class)
	public static final int COUNTRY_ID = ++_END;//507
	
	@Comment(content = "开启的背包个数")
	@Type(Integer.class)
	public static final int HAD_OPEN_PRIM_BAG_NUM = ++_END;//508
	
	@Comment(content = "主背包总数")
	@Type(Integer.class)
	public static final int PRIM_BAG_NUM = ++_END;//509
	
	@Comment(content = "临时背包总数")
	@Type(Integer.class)
	public static final int TEMP_BAG_NUM = ++_END;//510

	@Comment(content = "vip经验")
	@Type(Integer.class)
	public static final int VIP_EXP = ++_END;//511
	
	@Comment(content = "最近一次场景Id")
	@Type(Integer.class)
	public static final int LAST_CITY_SCENE_ID = ++_END;//512
	
	@Comment(content = "战斗力")
	@Type(Integer.class)
	public static final int FIGHT_POWER = ++_END;//513
	
	@Comment(content = "性别")
	@Type(Integer.class)
	public static final int SEX = ++_END;//514
	
	@Comment(content = "职业")
	@Type(Integer.class)
	public static final int JOB_TYPE = ++_END;//515
	
	@Comment(content = "VIP状态")
	@Type(Integer.class)
	public static final int VIP_STATE = ++_END;//516
	
	@Comment(content="当前可拥有武将数量")
	@Type(Integer.class)
	public static final int FORMATION_OWN_PET_NUM = ++_END; //517
	
	@Comment(content="武将星级")
	@Type(Integer.class)
	public static final int STAR = ++_END; //518
	
	@Comment(content="武将品质（阶数）")
	@Type(Integer.class)
	public static final int COLOR = ++_END; //519
	
	@Comment(content="地图Id")
	@Type(Integer.class)
	public static final int MAP_ID = ++_END; //520
	
	@Comment(content="坐标X，像素位置")
	@Type(Integer.class)
	public static final int X = ++_END; //521
	
	@Comment(content="坐标Y，像素位置")
	@Type(Integer.class)
	public static final int Y = ++_END; //522
	
	@Comment(content="自动战斗默认行为")
	@Type(Integer.class)
	public static final int AUTO_FIGHT_ACTION = ++_END; //523
	
	@Comment(content="自动战斗宠物默认行为")
	@Type(Integer.class)
	public static final int PET_AUTO_FIGHT_ACTION = ++_END; //524
	
	@Comment(content="一级属性可分配点数")
	@Type(Integer.class)
	public static final int LEFT_POINT = ++_END; //525
	
	@Comment(content="成长率品质，宠物")
	@Type(Integer.class)
	public static final int GROWTH_COLOR = ++_END; //526
	
	@Comment(content="是否出战中，宠物")
	@Type(Integer.class)
	public static final int IS_FIGHT = ++_END; //527
	
	@Comment(content="变异类型，宠物")
	@Type(Integer.class)
	public static final int GENE_TYPE = ++_END; //528
	
	@Comment(content="寿命，宠物")
	@Type(Integer.class)
	public static final int LIFE = ++_END; //529
	
	@Comment(content = "悟性等级")
	@Type(Integer.class)
	public static final int PERCEPT_LEVEL = ++_END;// 530
	
	@Comment(content = "酒馆等级")
	@Type(Integer.class)
	public static final int PUB_LEVEL = ++_END;// 531
	
	@Comment(content = "心法等级")
	@Type(Integer.class)
	public static final int MAINSKILL_LEVEL = ++_END;// 532
	
	@Comment(content = "当前心法类型")
	@Type(Integer.class)
	public static final int MAINSKILL_TYPE = ++_END;// 533
	
	@Comment(content="是否有军团")
	@Type(Integer.class)
	public static final int HAS_CORPS = ++_END; //534
	
	@Comment(content = "军团经验Buff")
	@Type(Integer.class)
	public static final int CORPS_EXP_BUFF = ++_END;//535
	
	@Comment(content = "军团金币Buff")
	@Type(Integer.class)
	public static final int CORPS_GOLD_BUFF = ++_END;//536
	
	@Comment(content = "帮贡")
	@Type(Integer.class)
	public static final int CURRENT_CORPS_CONTRIBUTION = ++_END;//537
	
	@Comment(content = "人员历史总帮贡")
	@Type(Integer.class)
	public static final int TOTAL_CORPS_CONTRIBUTION = ++_END;//538
	
	@Comment(content = "宠物评分")
	@Type(Integer.class)
	public static final int PET_SCORE = ++_END;//539
	
	@Comment(content = "采矿等级")
	@Type(Integer.class)
	public static final int MINE_LEVEL = ++_END;//540

	@Comment(content="是否显示title")
	@Type(Integer.class)
	public static final int DIS_TITLE= ++_END; //541

	@Comment(content="title的模版id")
	@Type(Integer.class)
	public static final int TITLE= ++_END; //542
	
	@Comment(content = "骑宠悟性等级")
	@Type(Integer.class)
	public static final int PET_HORSE_PERCEPT_LEVEL = ++_END;// 543
	
	@Comment(content="成长率品质，骑宠")
	@Type(Integer.class)
	public static final int PET_HORSE_GROWTH_COLOR = ++_END; //544
	
	@Comment(content = "仓库开启格子次数（页数）")
	@Type(Integer.class)
	public static final int STORE_OPEN_NUM = ++_END;//545
	
	@Comment(content="帮派等级")
	@Type(Integer.class)
	public static final int CORPS_LEVEL = ++_END; //546
	@Comment(content="帮派朱雀堂等级")
	@Type(Integer.class)
	public static final int CORPS_BUILDING_ZQ_LEVEL = ++_END; //547
	@Comment(content="帮派侍剑堂等级")
	@Type(Integer.class)
	public static final int CORPS_BUILDING_SJ_LEVEL = ++_END; //548
	
	@Comment(content = "武将技能栏数量")
	@Type(Integer.class)
	public static final int PET_SKILL_BAR_NUM = ++_END;//549
	
	@Comment(content = "绑定状态，0绑定，1非绑定")
	@Type(Integer.class)
	public static final int PET_BIND = ++_END;//550
	
	@Comment(content="骑宠变异类型")
	@Type(Integer.class)
	public static final int PET_HORSE_GENE_TYPE = ++_END; //551
	
	/** 基础整型属性的个数 */
	public static final int _SIZE = _END - _BEGIN + 1;

	public static final int TYPE = PropertyType.BASE_ROLE_PROPS_INT;

	/** 数值是否修改的副本标识 */
	private final BitSet shadowBitSet;

	public RoleBaseIntProperties() {
		super(Integer.class, _SIZE, TYPE);
		this.shadowBitSet = new BitSet(this.size());
	}

	/**
	 * 重载{@link #resetChanged()},在重置前将props的修改记录下来
	 */
	@Override
	public void resetChanged() {
		this.props.fillChangedBit(this.shadowBitSet);
		super.resetChanged();
	}

	public void change(){
		this.props.change();
	}
	
	/**
	 * 是否有副本属性的修改
	 * 
	 * @return ture,有修改
	 */
	public boolean isShadowChanged() {
		return this.props.isChanged() || (!this.shadowBitSet.isEmpty());
	}

	/**
	 * 检查指定的副本属性索引是否有修改
	 * 
	 * @param index
	 * @return true,有修改;false,无修改
	 */
	public boolean isShadowChanged(final int index) {
		return this.props.isChanged(index) || this.shadowBitSet.get(index);
	}

	/**
	 *
	 */
	public void resetShadowChanged() {
		this.shadowBitSet.clear();
	}

	/**
	 * 判定指定的属性索引是否有修改
	 * 
	 * @param index
	 * @return
	 */
	public boolean isChanged(int index) {
		return this.props.isChanged(index);
	}

	/**
	 * 获取属性值
	 * 
	 * @param index
	 * @return
	 */
	@Override
	public Integer getPropertyValue(int index) {
		Integer value = props.get(index);
		if (value != null) {
			return value;
		} else {
			return 0;
		}
	}

	public static void main(String[] args) {
		System.out.println(_SIZE);
	}
	
}
