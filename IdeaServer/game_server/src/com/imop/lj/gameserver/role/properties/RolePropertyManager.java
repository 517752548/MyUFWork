package com.imop.lj.gameserver.role.properties;

import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.gameserver.role.Role;

import java.util.BitSet;

public abstract class RolePropertyManager<T extends Role, V> {

    /** 影响属性值的影响器标志 */
    /**
     * ALL
     */
    public static final int PROP_FROM_MARK_ALL = 0xFFFFFFFF;

    /**
     * 初始
     */
    public static final int PROP_FROM_MARK_INIT = 0x0001;
    /**
     * 升级后分配点数
     */
    public static final int PROP_FROM_MARK_LEVEL_ADD_POINT = 0x0002;
    /**
     * 装备
     */
    public static final int PROP_FROM_MARK_EQUIP = 0x0004;
    /**
     * 成长率相关
     */
    public static final int PROP_FROM_MARK_GROWTH = 0x0008;
    /**
     * 培养
     */
    public static final int PROP_FROM_MARK_TRAIN = 0x0010;
    /**
     * 一级属性
     */
    public static final int PROP_FROM_MARK_APROPERTY = 0x0020;
//    /**
//     * 宝石
//     */
//    public static final int PROP_FROM_MARK_GEM = 0x0040;
    /**
     * 技能
     */
    public static final int PROP_FROM_MARK_SKILL = 0x0080;

    /**
     * 称号
     */
    public static final int PROP_FROM_MARK_TITLE = 0x00100;
    
    /**
     * 翅膀
     */
    public static final int PROP_FROM_MARK_WING = 0x0200;
    /**
     * 骑宠
     */
    public static final int PROP_FROM_MARK_HORSE = 0x0400;
    /**
     * 帮派修炼技能
     */
    public static final int PROP_FROM_MARK_CORPS_CULTIVATE = 0x0800;


//    /**
//     * 战斗属性变化
//     */
//    public static final int PROP_FROM_MARK_BATTLE_CHANGE = 0x0100;
//    /**
//     * 最终属性一级属性变化
//     */
//    public static final int PROP_FROM_MARK_FINAL_APROPERTY = 0x0200;
//    /**
//     * 军衔
//     */
//    public static final int PROP_FROM_MARK_ARMY_TITLE = 0x0400;
//    /**
//     * 战甲
//     */
//    public static final int PROP_FROM_MARK_ARMOUR = 0x0800;
//    /**
//     * 剑气
//     */
//    public static final int PROP_FROM_MARK_SWORD_SOUL = 0x1000;
    // 内部标志
    /**
     * 一级属性
     */
    protected static final int CHANGE_INDEX_APROP = 0;
    /**
     * 二级属性
     */
    protected static final int CHANGE_INDEX_BPROP = 1;

    protected T owner;

    /**
     * 一级、二级、抗性改变标志
     */
    protected BitSet propChangeSet;


    public RolePropertyManager(T role, int bitSetSize) {
        Assert.notNull(role);
        owner = role;
        propChangeSet = new BitSet(bitSetSize);
    }


    /**
     * 按指定的影响标识，更新一级属性
     *
     * @param role
     * @return
     */
    abstract protected boolean updateAProperty(T role, int effectMask);

    /**
     * 按指定的影响标识，更新二级属性
     *
     * @param role
     * @return
     */
    abstract protected boolean updateBProperty(T role, int effectMask);

    /**
     * 按标识更新属性
     *
     * @param effectMask
     */
    abstract public void updateProperty(int effectMask);


    /**
     * 获取所有改变
     *
     * @return
     */
    abstract public KeyValuePair<Integer, V>[] getChanged();

    /**
     * 一、二级或抗性是否有改变
     *
     * @return
     */
    public boolean isChanged() {
        return !propChangeSet.isEmpty();
    }

    /**
     * 重置属性修改标识
     */
    public void resetChanged() {
        propChangeSet.clear();
    }

    public void change() {
        propChangeSet.set(CHANGE_INDEX_APROP);
        propChangeSet.set(CHANGE_INDEX_BPROP);
    }
}
