package com.imop.lj.common;

import java.lang.annotation.*;

/**
 * 日志系统的日志原因定义
 */
public interface LogReasons {

    @Documented
    @Retention(RetentionPolicy.RUNTIME)
    @Target({ElementType.FIELD, ElementType.TYPE})
    public @interface ReasonDesc {
        /**
         * 原因的文字描述
         *
         * @return
         */
        String value();
    }

    @Documented
    @Retention(RetentionPolicy.RUNTIME)
    @Target({ElementType.FIELD, ElementType.TYPE})
    public @interface LogDesc {
        /**
         * 日志描述
         *
         * @return
         */
        String desc();
    }

    /**
     * LogReason的通用接口
     */
    public static interface ILogReason {
        /**
         * 取得原因的序号
         *
         * @return
         */
        public int getReason();

        /**
         * 获取原因的文本
         *
         * @return
         */
        public String getReasonText();
    }

    /**
     * 经验的原因接口
     *
     * @param <E> 枚举类型
     */
    public static interface IItemLogReason<E extends Enum<E>> extends ILogReason {
        public E getReasonEnum();
    }

    /**
     * 发送用户登陆日志
     *
     * @param logTime         日志产生时间
     * @param accountId       玩家账号Id
     * @param accountName     玩家的账号名
     * @param charId          角色ID
     * @param charName        玩家的角色名
     * @param level           玩家等级
     * @param alliance        玩家阵营
     * @param vipLevel        玩家VIP等级
     * @param reason          原因
     * @param param           其他参数
     * @param device          登陆终端
     * @param playerLoginTime 登陆时间
     * @param source          登陆信息--设备来源|终端id|设备类型|设备版本号|客户端版本号|客户端语言类型
     */
    @LogDesc(desc = "发送用户登陆日志")
    public enum PlayerLoginLogReason implements ILogReason {
        /**
         * 从商店购买
         */
        @ReasonDesc("用户登陆")
        PLAYER_LOGIN(0, "用户登陆"),
        @ReasonDesc("用户登出")
        PLAYER_LOGOUT(1, "用户登出"),
        @ReasonDesc("强制踢出下线")
        PLAYER_LOGOUT_TICK(2, "强制踢出下线"),
        @ReasonDesc("用户主动登出")
        PLAYER_LOGOUT_INITIATIVE(3, "用户主动登出"),
        @ReasonDesc("重复登录踢出下线")
        PLAYER_LOGOUT_EXIST_KICK(4, "重复登录踢出下线"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private PlayerLoginLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }
    }

    /**
     * 物品产生日志的原因
     */
    @LogDesc(desc = "物品产生")
    public enum ItemGenLogReason implements ILogReason {
        /**
         * 从商店购买
         */
        @ReasonDesc("debug测试")
        DEBUG_GIVE(1, "debug测试"),
        @ReasonDesc("拆分物品")
        SPLIT(2, "拆分物品"),
        @ReasonDesc("临时背包放入主背包")
        TEMP2PRIM(3, "临时背包放入主背包"),

        /**
         * 校场系统
         */
        @ReasonDesc("通过校场系统购买物品")
        BUY_ITEM_FROM_DG(4, "通过校场系统购买物品itemId = {0}|num = {1}"),

        @ReasonDesc("副本奖励")
        RAID(5, "副本奖励"),
        @ReasonDesc("副本通关宝箱奖励")
        RAID_BOX(6, "副本通关宝箱奖励"),
        @ReasonDesc("礼包奖励")
        GIFT_PECK_GEN(7, "礼包奖励"),

        @ReasonDesc("金券套餐直购道具")
        CHARGE_ITEM_COST(9, "金券套餐直购道具"),
        
        @ReasonDesc("仓库背包放入主背包")
        STORE2PRIM(10, "仓库背包放入主背包"),
        @ReasonDesc("主背包放入仓库背包")
        PRIM2STORE(11, "主背包放入仓库背包"),
        
        @ReasonDesc("背包已满转发邮件奖励")
        BAG_FULL_SEND_MAIL(12, "背包已满reward转发邮件奖励"),
        @ReasonDesc("背包已满转发邮件奖励")
        BAG_FULL_SEND_MAIL_REWARD(13, "背包已满reward转发邮件奖励"),

        /**
         * 关卡系统
         */
        @ReasonDesc("关卡产生物品")
        MISSION_ITEM_GEN_REWARD(201, "关卡产生物品"),
        @ReasonDesc("关卡宝箱产生物品")
        MISSION_TREASURE_BOX_GEN_REWARD(202, "关卡宝箱产生物品"),

        /**
         * 任务奖励
         */
        @ReasonDesc("任务奖励产生物品")
        QUEST_ITEM_GEN_REWARD(300, "任务奖励产生物品"),

        /**
         * 国家奖励
         */
        @ReasonDesc("推荐国家奖励产生物品")
        RECOMMEND_COUNTRY_ITEM_GEN_REWARD(301, "任务奖励产生物品"),

        @ReasonDesc("竞技场排名奖励")
        ARENA_RANK_REWARD(302, "竞技场排名奖励"),

        @ReasonDesc("军团战玩家报名奖励")
        CORPSWAR_USER_JOIN(303, "军团战玩家报名奖励"),
        @ReasonDesc("军团战玩家战斗奖励")
        CORPSWAR_USER_FIGHT(304, "军团战玩家战斗奖励"),
        @ReasonDesc("军团战军团奖励")
        CORPSWAR_CORPS(305, "军团战军团奖励"),

        @ReasonDesc("世界boss战攻击奖励")
        WORLD_BOSSWAR_ATTACK(306, "世界boss战攻击奖励"),
        @ReasonDesc("世界boss战击杀奖励")
        WORLD_BOSSWAR_KILL(307, "世界boss战击杀奖励"),
        @ReasonDesc("世界boss战排名奖励 ")
        WORLD_BOSSWAR_RANK(308, "世界boss战排名奖励"),

        @ReasonDesc("竞技场攻击奖励")
        AREAN_ATTACK_REWARD(309, "竞技场攻击奖励"),

        /**
         * 装备相关
         */
        @ReasonDesc("装备打造生成 ")
        EQUIP_BUILD_GEN(350, "装备打造生成"),
        @ReasonDesc("装备宝石移除添加 ")
        EQUIP_GEM_REMOVE_GEN(351, "装备宝石移除添加"),
        @ReasonDesc("宝石合成生成")
        GEM_COMPOSITE_GEN(352, "宝石合成生成"),
        @ReasonDesc("批量宝石合成生成")
        BATCH_GEM_COMPOSITE_GEN(353, "批量宝石合成生成"),
        @ReasonDesc("宝物转换生成")
        TREASURE_CONVERT_GEN(354, "宝物转换生成"),
        @ReasonDesc("宝物升阶生成")
        TREASURE_UPGRADE_GEN(355, "宝物升阶生成"),

        @ReasonDesc("过关斩将奖励")
        HERO_MISSION(401, "过关斩将奖励"),

        @ReasonDesc("领地生产获得")
        LAND_GIVE_PRODUCT(411, "领地生产获得|领地Id={0}|品阶={1}|倍数={2}"),

        /**
         * 坐骑相关
         */
        @ReasonDesc("技能书移除")
        SKILL_BOOK_REMOVE(450, "技能书移除"),
        @ReasonDesc("技能书合成")
        SKILL_BOOK_COMPOSITE(451, "技能书合成"),

        @ReasonDesc("首充奖励")
        FIRST_CHARGE_REWARD(460, "首充奖励"),
        @ReasonDesc("七日签到奖励")
        SEVEN_SIGNIN_REWARD(461, "七日签到奖励"),

        @ReasonDesc("目标系统任务奖励")
        STEPTASK_TASK_REWARD(462, "目标系统任务奖励"),
        @ReasonDesc("目标系统阶段奖励")
        STEPTASK_STEP_REWARD(463, "目标系统阶段奖励"),
        @ReasonDesc("内政系统任务奖励")
        PASSTASK_TASK_REWARD(464, "内政系统任务奖励"),
        @ReasonDesc("内政系统阶段奖励")
        PASSTASK_STEP_REWARD(465, "内政系统阶段奖励"),

        @ReasonDesc("收将")
        COLLECT_GOD_HERO(480, "收将 godHeroList = {0}"),
        @ReasonDesc("神将商店购买")
        BUY_FROM_GOD_HERO_SHOP(481, "神将商店购买"),

        @ReasonDesc("女神宝藏兑换")
        LUCKYDRAW_EXCHANGE(490, "女神宝藏兑换|exchangeTplId={0}|cost={1}"),
        @ReasonDesc("女神宝藏显示奖励")
        LUCKYDRAW_SHOW_REWARD(500, "女神宝藏显示奖励"),
        @ReasonDesc("女神宝藏实际奖励")
        LUCKYDRAW_GIVE_REWARD(501, "女神宝藏实际奖励"),

        @ReasonDesc("VIP每日领取")
        VIP_ONCE_DAY_REWARD(510, "VIP每日领取"),

        @ReasonDesc("在线礼包奖励")
        ONLINE_GIFT_REWARD(520, "在线礼包奖励"),

        @ReasonDesc("等级礼包")
        LEVEL_GIFT_PACK_REWARD(521, "等级礼包"),

        @ReasonDesc("神秘商店购买物品")
        MS_BUY_ITEM(530, "神秘商店购买物品"),

        @ReasonDesc("商城购买")
        MALL_BUY_ITEM(531, "商城购买"),

        @ReasonDesc("快捷购买")
        QUICK_BUY_ITEM(535, "快捷购买 funcId = {0} count = {1}"),

        /**
         * 领取平台奖励
         */
        @ReasonDesc("领取平台奖励")
        PLATFORM_PRIZE(540, "奖励ID={0,number,#}"),

        @ReasonDesc("军团分配物品")
        CORPS_ITEM_ALLOCATION_REWARD(550, "军团分配物品"),

        @ReasonDesc("军衔激活奖励")
        ARMY_TITLE_REWARD(560, "军衔激活奖励"),
        @ReasonDesc("军衔俸禄奖励")
        ARMY_TITLE_SALARY_REWARD(561, "军衔俸禄奖励"),

        @ReasonDesc("精彩活动奖励")
        GOOD_ACTIVITY_REWARD(562, "精彩活动奖励"),

        @ReasonDesc("领地献计奖励")
        LAND_OFFER_ADVICE_REWARD(563, "领地献计奖励"),

        @ReasonDesc("领地献计奖励")
        BUN_ROLL_REWARD(564, "领地献计奖励"),

        @ReasonDesc("手机验证奖励")
        SMS_CHECKCODE_REWARD(565, "手机验证奖励"),

        @ReasonDesc("GM奖励")
        GM_CREATE_REWARD(566, "GM奖励"),

        @ReasonDesc("游戏内产生带参数奖励")
        GAME_CREATE_REWARD(567, "游戏内产生带参数奖励"),

        @ReasonDesc("南蛮入侵攻击奖励")
        MONSTER_WAR_ATTACK(570, "南蛮入侵攻击奖励"),
        @ReasonDesc("南蛮入侵击杀奖励")
        MONSTER_WAR_KILL(571, "南蛮入侵击杀奖励"),
        @ReasonDesc("南蛮入侵boss战排名奖励 ")
        MONSTER_WAR_RANK(572, "南蛮入侵排名奖励"),
        @ReasonDesc("南蛮入侵下注奖励 ")
        MONSTER_WAR_BET(573, "南蛮入侵下注奖励"),

        @ReasonDesc("卡牌购买 ")
        CARD_BUY(580, "卡牌购买|购买参数={0}"),

        @ReasonDesc("卡牌-抽卡奖励 ")
        CARD_DRAW_REWARD(581, "卡牌-抽卡奖励"),
        @ReasonDesc("卡牌-日排名普通奖励")
        CARD_DAY_RANK_NORMAL(582, "卡牌-日排名普通奖励"),
        @ReasonDesc("卡牌-日排名超级奖励 ")
        CARD_DAY_RANK_SUPER(583, "卡牌-日排名超级奖励"),
        @ReasonDesc("卡牌-累计排名普通奖励 ")
        CARD_FINAL_RANK_NORMAL(584, "卡牌-累计排名普通奖励"),
        @ReasonDesc("卡牌-累计排名超级奖励")
        CARD_FINAL_RANK_SUPER(585, "卡牌-累计排名超级奖励"),
        @ReasonDesc("卡牌-奖励兑换")
        CARD_EXCHANGE_REWARD(586, "卡牌-奖励兑换"),

        @ReasonDesc("幸运转盘抽奖奖励")
        TURNTABLE_DRAW_REWARD(587, "幸运转盘抽奖奖励"),

        @ReasonDesc("宝石迷阵奖励")
        GEM_MAZE_REWARD(588, "宝石迷阵奖励"),

        @ReasonDesc("兑换商城奖励")
        CONVERT_MALL_REWARD(589, "兑换商城奖励"),
        @ReasonDesc("兑换商城奖励")
        CONVERT_MALL_BUY(590, "兑换商城兑换"),

        @ReasonDesc("qq-黄钻新手奖励")
        QQ_VIP_NEWER(600, "qq-黄钻新手奖励"),
        @ReasonDesc("qq-黄钻每日奖励")
        QQ_VIP_DAY(601, "qq-黄钻每日奖励"),
        @ReasonDesc("qq-豪华黄钻每日额外奖励")
        QQ_VIP_HIGH_DAY(602, "qq-豪华黄钻每日额外奖励"),
        @ReasonDesc("qq-年费黄钻每日额外奖励")
        QQ_VIP_YEAR_DAY(603, "qq-年费黄钻每日额外奖励"),
        @ReasonDesc("qq-黄钻升级奖励")
        QQ_VIP_LEVEL(604, "qq-黄钻升级奖励"),

        @ReasonDesc("qq-充值赠送奖励")
        QQ_CHARGE(605, "qq-充值赠送奖励"),

        @ReasonDesc("环任务单环奖励")
        LOOP_TASK_LOOP_REWARD(606, "环任务单环奖励"),

        @ReasonDesc("环任务总奖励")
        LOOP_TASK_TOTAL_REWARD(607, "环任务总奖励"),

        @ReasonDesc("qq-被邀请者n天奖励")
        QQ_BEINVITED_DAY_REWARD(610, "qq-被邀请者n天奖励 "),
        @ReasonDesc("qq-充值返利奖励")
        QQ_CHARGE_RETURN_REWARD(611, "qq-充值返利奖励"),
        @ReasonDesc("qq-邀请好友次数奖励")
        QQ_INVITE_COUNT_REWARD(612, "qq-邀请好友次数奖励"),
        @ReasonDesc("qq-历程分享奖励")
        QQ_SHARE_BYFUNC_REWARD(613, "qq-历程分享奖励"),
        @ReasonDesc("qq-每日邀请好友奖励")
        QQ_INVITE_DAY_REWARD(614, "qq-每日邀请好友奖励"),
        @ReasonDesc("qq-app评分奖励")
        QQ_APP_SCORE_REWARD(615, "qq-app评分奖励"),
        @ReasonDesc("qq-集市任务奖励")
        QQ_MARKET_TASK_REWARD(616, "qq-集市任务奖励"),

        @ReasonDesc("每日首充奖励")
        EVERYDAY_CHARGE_GIFT(617, "每日首充奖励"),

        @ReasonDesc("渡江单次攻击")
        ESCORT_SINGLE_ATTACK(618, "渡江单次攻击"),
        @ReasonDesc("渡江完成")
        ESCORT_COMPLETE(619, "渡江完成"),
        @ReasonDesc("借东风开启奖励")
        ESCORT_GLOBAL_ENCOURAGE_OPEN(620, "借东风开启奖励"),
        @ReasonDesc("借东风结束奖励")
        ESCORT_GLOBAL_ENCOURAGE_COMPLETE(621, "借东风结束奖励"),
        @ReasonDesc("抢夺收益排名奖励")
        ESCORT_INCOME_RANK(622, "抢夺收益排名奖励"),
        @ReasonDesc("抢夺收益排名超级奖励")
        ESCORT_INCOME_RANK_SUPER(623, "抢夺收益排名超级奖励"),
        @ReasonDesc("渡江护送完成 ")
        ESCORT_HELP_COMPLETE(624, "渡江护送完成"),

        @ReasonDesc("领取CDKEY礼包 ")
        CDKEY_REWARD(625, "领取CDKEY礼包 "),

        @ReasonDesc("试剑塔关卡敌人奖励")
        SWORD_TOWER_MISSION(626, "试剑塔关卡敌人奖励"),


        @ReasonDesc("经典战役通关奖励 ")
        CLASSIC_BATTLE_BOX_REWARD(627, "经典战役通关奖励 "),
        @ReasonDesc("经典战役事件奖励")
        CLASSIC_BATTLE_PASS_REWARD(628, "经典战役事件奖励"),
        @ReasonDesc("经典战役自动通关奖励")
        CLASSIC_BATTLE_PASS_AUTO_REWARD(629, "经典战役自动通关奖励"),

        @ReasonDesc("特殊在线礼包")
        SPEC_ONLINE_GIFT(630, "特殊在线礼包"),

        @ReasonDesc("演武离线打坐获得经验")
        PRACTICE_OFFLINE_ADD_EXP(631, "演武离线打坐获得经验"),

        @ReasonDesc("累积消耗")
        ACCU_COST_ACTIVITY(635, "累积消耗"),

        @ReasonDesc("消耗钥匙使用礼包")
        COST_KEY_USE_ITEM_GIVE(640, "消耗钥匙使用礼包"),

        @ReasonDesc("装备打造给装备")
        CRAFT_EQUIP_GIVE(650, "装备打造给装备|颜色={0}|品质={1}"),

        @ReasonDesc("宝石卸下时，给朱背包添加一块宝石")
        GEM_TAKE_OFF(660, "宝石卸下|宝石模板ID={0}"),

        @ReasonDesc("宝石镶嵌时，在宝石包中添加一块宝石")
        GEM_SET(661, "宝石卸下|宝石模板ID={0}"),

        @ReasonDesc("在交易行购买商品")
        TRADE_BUY(662, "在交易行购买商品"),

        @ReasonDesc("交易行卖出获得")
        TRADE_REWARD(663, "交易行卖出获得"),

        @ReasonDesc("在交易行下架商品")
        TRADE_TAKE_DOWN(664, "在交易行下架商品"),

        @ReasonDesc("合成宝石")
        SYNTHESIS_GEM(665, "合成宝石"),

        @ReasonDesc("接受任务给道具")
        QUEST_ACCEPT_GIVE_ITEM(670, "接受任务给道具|任务Id={0}"),

        @ReasonDesc("藏宝图任务完成后生成道具")
        TREASURE_MAP_GENERATE_PROP(671, "藏宝图任务完成后生成道具"),
        
        @ReasonDesc("平台兑换码奖励")
		LOCAL_CODE_REWARD(680, "平台兑换码奖励"),
		
		@ReasonDesc("酒馆任务奖励")
        PUB_TASK_REWARD(690, "酒馆任务奖励"),
        @ReasonDesc("除暴任务奖励")
		SWEENEY_TASK_REWARD(691, "除暴任务奖励"),
		@ReasonDesc("藏宝图任务奖励")
		TREASURE_MAP_TASK_REWARD(692, "藏宝图任务奖励"),
		@ReasonDesc("护送粮草任务奖励")
		FORAGE_TASK_REWARD(693, "护送粮草任务奖励"),
		@ReasonDesc("帮派任务奖励")
		CORPS_TASK_REWARD(694, "帮派任务奖励"),
		@ReasonDesc("宝石合成失败奖励")
        GEM_SYN_FAIL_REWARD(695, "宝石合成失败奖励"),
        @ReasonDesc("七日登录奖励")
		GA_SEVEN_LOGIN_REWARD(696, "七日登录奖励"),
		@ReasonDesc("等级奖励")
		GA_LEVEL_UP_REWARD(697, "等级奖励"),
		@ReasonDesc("vip每日礼包")
        VIP_DAY_REWARD(698, "vip每日礼包"),
        @ReasonDesc("通天塔奖励")
        TOWER_REWARD(699, "通天塔奖励"),
        @ReasonDesc("vip等级奖励")
        VIP_LEVEL_REWARD(700, "vip等级奖励"),
        
        @ReasonDesc("签到奖励")
        MONTH_SIGN_REWARD(701, "签到奖励"),
        @ReasonDesc("装备分解")
        EQUIP_DECOMPOSE_REWARD(702, "装备分解"),
        @ReasonDesc("科举答题")
        EXAM_REWARD(703, "科举答题"),
        @ReasonDesc("采矿奖励")
        MINE_REWARD(704, "采矿奖励"),
        @ReasonDesc("邮件附件")
        MAIL_ATTACHMENT_REWARD(705, "邮件附件"),
        @ReasonDesc("活跃度奖励")
        ACTIVITYUI_REWARD(706, "活跃度奖励"),
        @ReasonDesc("竞技场攻击奖励")
        ARENA_ATTACK(707, "竞技场攻击奖励"),
        @ReasonDesc("竞技场排名奖励")
        ARENA_RANK(708, "竞技场排名奖励"),
        @ReasonDesc("任务奖励")
        QUEST_REWARD(710, "任务奖励"),
        @ReasonDesc("帮派竞赛奖励")
        CORPS_WAR_REWARD(711, "帮派竞赛奖励"),
        @ReasonDesc("绿野仙踪奖励")
        WIZARD_RAID_REWARD(712, "绿野仙踪奖励"),
        @ReasonDesc("打怪胜利奖励")
        WIN_ENEMY_REWARD(714, "打怪胜利奖励"),
        @ReasonDesc("除暴安良特殊奖励")
        SWEENEY_TASK_SPECIAL(715, "除暴安良特殊奖励"),
        @ReasonDesc("NVN月度排名奖励")
        NVN_RANK(716, "NVN月度排名奖励"),
        @ReasonDesc("结婚奖励")
        MARRY_REWARD(717, "结婚奖励"),
        @ReasonDesc("师徒奖励")
        OVERMAN_REWARD(718, "师徒奖励"),
        @ReasonDesc("藏宝图奖励")
        TREASURE_MAP_REWARD(719, "藏宝图奖励"),
        @ReasonDesc("使用礼包道具奖励")
        GIFT_PACK(720, "使用礼包道具奖励"),
        @ReasonDesc("帮派boss奖励")
        CORPS_BOSS_REWARD(721, "帮派boss奖励"),
        @ReasonDesc("帮派boss排行榜奖励")
        CORPS_BOSS_RANK_REWARD(722, "帮派boss排行榜奖励"),
        @ReasonDesc("帮派boss挑战次数排行榜奖励")
        CORPS_BOSS_COUNT_RANK_REWARD(723, "帮派boss挑战次数排行榜奖励"),
        @ReasonDesc("野外封妖榜奖励")
        SEAL_DEMON_REWARD(724, "野外封妖榜奖励"),
        @ReasonDesc("野外魔王奖励")
        SEAL_DEMON_KING_REWARD(725, "野外魔王奖励"),
        @ReasonDesc("混世魔王奖励")
        DEVIL_INCARNATE_REWARD(726, "混世魔王奖励"),
        @ReasonDesc("限时杀怪奖励")
        TIME_LIMIT_MONSTER_REWARD(727, "限时杀怪奖励"),
        @ReasonDesc("限时挑战npc奖励")
        TIME_LIMIT_NPC_REWARD(728, "限时挑战npc奖励"),
        @ReasonDesc("绿野仙踪BOSS奖励")
        WIZARD_RAID_BOSS_REWARD(729, "绿野仙踪BOSS奖励"),
        @ReasonDesc("七日目标任务奖励")
        DAY7_TARGET_REWARD(730, "七日目标任务奖励"),
        @ReasonDesc("帮派辅助技能奖励")
        CORPS_ASSIST_REWARD(731, "帮派辅助技能奖励"),
        @ReasonDesc("帮派红包奖励")
        CORPS_RED_ENVELOPE_REWARD(732, "帮派红包奖励"),
        @ReasonDesc("剧情副本奖励")
        PLOT_DUNGEON_REWARD(733, "剧情副本奖励"),
        @ReasonDesc("招财进宝奖励")
		GA_BUY_MONEY_REWARD(734, "招财进宝奖励"),
		@ReasonDesc("开服基金奖励")
		GA_LEVEL_MONEY_REWARD(735, "开服基金奖励"),
		@ReasonDesc("限时累计充值奖励（精彩活动）")
        GA_NORMAL_TOTAL_CHARGE(736, "限时累计充值奖励（精彩活动）"),
        @ReasonDesc("每日累计充值奖励（精彩活动）")
		GA_DAY_TOTAL_CHARGE(737, "每日累计充值奖励（精彩活动）"),
        @ReasonDesc("一元购类型奖励（精彩活动）")
		GA_TOTAL_CHARGE_BUY(738, "一元购类型奖励（精彩活动）"),
		@ReasonDesc("围剿魔族普通奖励")
        SIEGE_DEMON_NORMAL_REWARD(739, "围剿魔族普通奖励"),
        @ReasonDesc("围剿魔族困难奖励")
        SIEGE_DEMON_HARD_REWARD(740, "围剿魔族困难奖励"),
        
        @ReasonDesc("技能镶嵌仙符返还道具")
        LEADER_EMBED_SKILL_EFFECT_ADD(800, "技能镶嵌仙符返还道具|技能Id={0}|位置Id={1}|仙符等级={2}|仙符经验={3}"),
        
        ;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ItemGenLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }
    }

    /**
     * 武将变更
     *
     * @author xiaowei.liu
     */
    @LogDesc(desc = "武将更新")
    public enum PetLogReason implements ILogReason {
        @ReasonDesc("召唤武将")
        DRILL_GROUND_HIRE(1, "召唤武将"),
        @ReasonDesc("武将招募卡")
        PET_HIRE_CARD(2, "武将招募卡"),
        @ReasonDesc("武将解雇")
        PET_FIRE(3, "武将解雇"),
        @ReasonDesc("武将解雇转换装备失败")
        PET_FIRE_SWAP_EQUIP_FAIL(4, "武将解雇转换装备失败 item uuid = {0}"),
        @ReasonDesc("特殊任务完成后直接给武将")
        AFTER_FINISH_QUEST_GIVE(5, "特殊任务完成后直接给武将|任务Id={0}|武将Id={1}"),
        @ReasonDesc("gm命令给")
        GM_CMD_GIVE(9, "gm命令给"),
        

        @ReasonDesc("武将加点")
        PET_ADD_POINT(100, "武将加点|原剩余点数={0}|现剩余点数={1}|原分配点数={2}|现分配点数={3}"),
        @ReasonDesc("抓捕宠物")
        PET_CATCH_PET(101, "抓捕宠物|一级属性增加={0}|变异类型={1}|成长率资质={2}|天赋技能={3}"),
        @ReasonDesc("宠物改变出战状态")
        PET_CHANGE_FIGHT_STATE(102, "宠物改变出战状态|isFight={0}"),
        @ReasonDesc("武将改名")
        PET_CHANGE_NAME(103, "武将改名|oldName={0}|newName={1}"),

        @ReasonDesc("宠物战斗后扣除寿命")
        PET_BATTLE_COST_LIFE(104, "宠物战斗后扣除寿命|oldLife={0}|newLife={1}|oldFightState={2}|newFightState={3}"),

        @ReasonDesc("宠物学习普通技能")
        PET_STUDY_NORMAL_SKILL(105, "宠物学习普通技能|是否已有技能={0}|学习技能Id={1}|技能等级old={2}|技能等级new={3}|删除技能Id={4}|删除技能等级={5}"),
        @ReasonDesc("宠物战斗后状态更新")
        PET_CHANGE_FIGHT_STATE_AFTER_BATTLE(106, "宠物战斗后状态更新|isFight={0}"),
        @ReasonDesc("武将洗点")
        PET_RESET_POINT(107, "武将洗点|已加总点数={0}|剩余点数={1}|现分配点数={2}|现剩余点数={3}"),

        @ReasonDesc("GM给宠物")
        GM_PET_CATCH_PET(110, "GM给宠物|一级属性增加={0}|变异类型={1}|成长率资质={2}|天赋技能={3}"),

        @ReasonDesc("交易行下架宠物")
        TRADE_PET_TAKE_DOWN(111, "交易行下架宠物"),
        @ReasonDesc("交易行交易宠物")
        TRADE_PET_TO_BUYER(112, "交易行交易宠物"),

        @ReasonDesc("宠物培养")
        PET_TRAIN_TMP(120, "宠物培养|培养方式={0}|培养数值={1}"),
        @ReasonDesc("宠物培养替换")
        PET_TRAIN_UPDATE(121, "宠物培养替换|培养数值={0}|培养总值={1}"),
        
        @ReasonDesc("宠物炼化")
        PET_ARTIFICE(122, "宠物炼化|炼化后成长率growthColor={0}"),
        
        @ReasonDesc("宠物变异")
        PET_VARIATION(123, "宠物变异|是否批量isBatch={0}|是否变异={1}"),
        
        @ReasonDesc("宠物还童")
        PET_REJUVENATION(124, "宠物还童|成长资质={0}"),
        
        @ReasonDesc("宠物洗天赋技能")
        PET_REFRESH_TALENT_SKILL(125, "宠物洗天赋技能|技能id集合={0}"),
        
        @ReasonDesc("宠物悟性提升")
        PET_PERCEPT_ADDEXP(126, "宠物悟性提升|提升方式={0}|是否批量={1}|提升前等级={2}|提升前经验={3}|提升后等级={4}|提升后经验={5}"),
        
        @ReasonDesc("伙伴解锁")
        PET_FRIEND_UNLOCK(130, "伙伴解锁|伙伴id={0}"),
        
        /**
         * 骑宠相关
         */
        @ReasonDesc("骑宠改变骑乘状态")
        PET_HORSE_RIDE(113, "骑宠改变骑乘状态|isRiding={0}"),
        @ReasonDesc("骑宠改名")
        PET_HORSE_CHANGE_NAME(140, "骑宠改名|oldName={0}|newName={1}"),
        @ReasonDesc("骑宠放生")
        PET_HORSE_FIRE(141, "骑宠放生"),
        @ReasonDesc("骑宠学习普通技能")
        PET_HORSE_STUDY_NORMAL_SKILL(142, "骑宠学习普通技能|是否已有技能={0}|学习技能Id={1}|技能等级old={2}|技能等级new={3}|删除技能Id={4}|删除技能等级={5}"),
        @ReasonDesc("骑宠战斗后状态更新")
        PET_HORSE_CHANGE_FIGHT_STATE_AFTER_BATTLE(143, "骑宠战斗后状态更新|isFight={0}"),
        @ReasonDesc("交易行下架骑宠")
        TRADE_PET_HORSE_TAKE_DOWN(144, "交易行下架骑宠"),
        @ReasonDesc("交易行交易骑宠")
        TRADE_PET_HORSE_TO_BUYER(145, "交易行交易骑宠"),
        @ReasonDesc("骑宠培养")
        PET_HORSE_TRAIN_TMP(146, "骑宠培养|培养方式={0}|培养数值={1}"),
        @ReasonDesc("骑宠培养替换")
        PET_HORSE_TRAIN_UPDATE(147, "骑宠培养替换|培养数值={0}|培养总值={1}"),
        @ReasonDesc("骑宠炼化")
        PET_HORSE_ARTIFICE(148, "骑宠炼化|炼化后成长率growthColor={0}"),
        @ReasonDesc("骑宠还童")
        PET_HORSE_REJUVENATION(149, "骑宠还童|成长资质={0}"), 
        @ReasonDesc("骑宠洗天赋技能")
        PET_HORSE_REFRESH_TALENT_SKILL(150, "骑宠洗天赋技能|技能id集合={0}"),
        @ReasonDesc("骑宠悟性提升")
        PET_HORSE_PERCEPT_ADDEXP(151, "骑宠悟性提升|提升方式={0}|是否批量={1}|提升前等级={2}|提升前经验={3}|提升后等级={4}|提升后经验={5}"),
        @ReasonDesc("骑宠招募卡")
        PET_HORSE_HIRE_CARD(152, "骑宠招募卡"),
        @ReasonDesc("GM给骑宠")
        GM_PET_HORSE_HIRE(154, "GM给骑宠"),
        
        @ReasonDesc("主将学习技能")
        PET_LEADER_STUDY_SKILL(201, "主将学习技能|技能Id={0}|技能等级={1}"),
        @ReasonDesc("主将技能开启仙符格子")
        PET_LEADER_OPEN_SKILL_EFFECT(202, "主将开启技能仙符格子|技能Id={0}|位置Id={1}"),
        @ReasonDesc("主将技能镶嵌仙符")
        PET_LEADER_EMBED_SKILL_EFFECT(203, "主将技能镶嵌仙符|技能Id={0}|仙符Id={1}|仙符等级={2}|仙符经验={3}"),
        @ReasonDesc("主将技能仙符升级")
        PET_LEADER_SKILL_EFFECT_UP(204, "主将技能仙符升级|技能Id={0}|仙符Id={1}|等级old={2}|经验old={3}|增加经验={4}|等级new={5}|经验new={6}"),
        @ReasonDesc("主将技能卸下仙符")
        PET_LEADER_UNEMBED_SKILL_EFFECT(205, "主将技能卸下仙符|技能Id={0}|仙符Id={1}|仙符等级={2}|仙符经验={3}"),
        ;

        public final int reason;
        public final String reasonText;

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

        private PetLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

    }

    /**
     * 物品变更原因
     */
    @LogDesc(desc = "物品更新")
    public enum ItemLogReason implements ILogReason {
        /**
         * 物品数量增加 (具体增加原因，见param)
         */
        @ReasonDesc("物品数量增加")
        COUNT_ADD(1, "物品数量增加"),
        /**
         * 使用后减少 参数0:templateId;参数1:数量;参数2:函数类型
         */
        @ReasonDesc("使用后减少")
        USED(2, "{0}|{1}|{2}"),
        /**
         * 玩家丢弃
         */
        @ReasonDesc("玩家丢弃")
        PLAYER_DROP(3, "玩家丢弃"),
        /**
         * 卖出道具
         */
        @ReasonDesc("卖出道具")
        SELL_COST(4, "卖出道具"),
        /**
         * 背包中移动：在更新时该不处理，删除时处理
         */
        @ReasonDesc("背包中移动")
        SHOULDERBAG2ITSELF(5, "背包中移动：在更新时该不处理，删除时处理"),
        /**
         * 加载角色物品时数据错误
         */
        @ReasonDesc("加载角色物品时数据错误")
        LOAD_VALID_ERR(6, "加载角色物品时数据错误"),
        /**
         * 拆分后减少
         */
        @ReasonDesc("拆分后减少")
        SPLITTED(7, "拆分后减少"),
        /**
         * 整理背包改变数量
         */
        @ReasonDesc("整理背包改变数量")
        TIDY_UP(8, "整理背包改变数量"),
        @ReasonDesc("超过使用期限")
        EXPIRED(9, "超过使用期限"),
        @ReasonDesc("临时背包放入主背包")
        TEMP2PRIM(10, "临时背包放入主背包"),
        @ReasonDesc("开格工具")
        OPEN_BAG(11, "开格工具"),
        @ReasonDesc("临时背包物品失效")
        EXPIRED_IN_TEMP_BAG(12, "临时背包物品失效"),
        /**
         * 领取平台奖励
         */
        @ReasonDesc("领取平台奖励")
        PLATFORM_PRIZE(13, "奖励ID={0,number,#}"),
        /**
         * 军团系统
         */
        @ReasonDesc("军团分配物品")
        CORPS_ITEM_ALLOCATION_REWARD(14, "军团分配物品"),
        /**
         * 任务系统
         */
        @ReasonDesc("任务奖励物品")
        QUEST_ITEM_REWARD(15, "任务奖励物品"),

        @ReasonDesc("完成任务扣除道具")
        QUEST_FINISH_REMOVE_ITEM(16, "完成任务扣除道具|任务Id={0}"),
        
        @ReasonDesc("仓库背包放入主背包")
        STORE2PRIM(17, "仓库背包放入主背包"),
        @ReasonDesc("主背包放入仓库背包")
        PRIM2STORE(18, "主背包放入仓库背包"),
        
        @ReasonDesc("背包已满转发邮件奖励")
        BAG_FULL_SEND_MAIL(19, "背包已满转发邮件奖励"),
        @ReasonDesc("背包已满reward转发邮件奖励")
        BAG_FULL_SEND_MAIL_REWARD(20, "背包已满reward转发邮件奖励"),

        @ReasonDesc("副本奖励")
        RAID(32, "副本奖励"),
        @ReasonDesc("副本通关宝箱奖励")
        RAID_BOX(33, "副本通关宝箱奖励"),

        /**
         * 消耗品相关
         */
        @ReasonDesc("武将招募卡消耗")
        PET_HIRE_CARD_COST(37, "武将招募卡消耗"),
        @ReasonDesc("礼盒消耗")
        GIFT_PECK_COST(38, "礼盒消耗"),
        @ReasonDesc("主将经验卡消耗")
        MAIN_PET_EXP_CARD_COST(39, "主将经验卡消耗"),
        @ReasonDesc("副将经验卡消耗")
        OTHER_PET_EXP_CARD_COST(40, "副将经验卡消耗"),

        @ReasonDesc("竞技场攻击奖励")
        AREAN_ATTACK_REWARD(41, "竞技场攻击奖励"),
        @ReasonDesc("等级礼包")
        LEVEL_GIFT_PACK_COST(42, ""),

        @ReasonDesc("加池子数值")
        PROP_POOL_ADD(43, "加池子数值"),
        @ReasonDesc("翅膀卡卡扣除")
        WING_CARD_COST(44, "翅膀卡消耗"),
        @ReasonDesc("骑宠招募卡消耗")
        PET_HORSE_HIRE_CARD_COST(45, "骑宠招募卡消耗"),
        @ReasonDesc("称号卡扣除")
        TITLE_CARD_COST(46, "称号卡扣除|称号Id={0}"),
        @ReasonDesc("双倍经验丹扣除")
        DOUBLE_POINT_COST(47, "双倍经验丹消耗"),
        
        @ReasonDesc("首充奖励")
        FIRST_CHARGE_REWARD(130, "首充奖励"),
        @ReasonDesc("七日签到奖励")
        SEVEN_SIGNIN_REWARD(131, "七日签到奖励"),

        @ReasonDesc("在线礼包奖励")
        ONLINE_GIFT_REWARD(200, "在线礼包奖励"),

        @ReasonDesc("等级礼包")
        LEVEL_GIFT_PACK_REWARD(201, "等级礼包"),

        @ReasonDesc("精彩活动奖励")
        GOOD_ACTIVITY_REWARD(232, "精彩活动奖励"),

        @ReasonDesc("手机验证奖励")
        SMS_CHECKCODE_REWARD(235, "手机验证奖励"),

        @ReasonDesc("GM命令奖励")
        GM_CREATE_REWARD(236, "GM命令奖励"),

        @ReasonDesc("游戏内带参数奖励")
        GAME_CREATE_REWARD(237, "游戏内带参数奖励"),

        @ReasonDesc("GM命令删除道具")
        GM_DEL_ITEM(253, "GM命令删除道具"),

        @ReasonDesc("特殊在线礼包")
        SPEC_ONLINE_GIFT(347, "特殊在线礼包"),

        @ReasonDesc("累积消耗")
        ACCU_COST_ACTIVITY(350, "累积消耗"),

        @ReasonDesc("消耗钥匙使用物品扣除【物品】")
        COST_KEY_USE_ITEM(355, "消耗钥匙使用物品扣除【物品】, itemId = {0} count={1}"),

        @ReasonDesc("消耗钥匙使用礼包")
        COST_KEY_USE_ITEM_GIVE(356, "消耗钥匙使用礼包"),

        @ReasonDesc("消耗钥匙使用礼包扣除自己")
        COST_KEY_USE_ITEM_DEL(357, "消耗钥匙使用礼包扣除自己"),

        @ReasonDesc("GM命令删除所有道具")
        DEBUG_REMOVE_ALL_ITEM(9999, "GM命令删除所有道具"),


        @ReasonDesc("武将升星消耗灵魂石")
        PET_UP_STAR_COST(10001, "武将升星消耗灵魂石toStar={0}"),
        @ReasonDesc("召唤武将消耗灵魂石")
        PET_SUMMON_COST(10002, "召唤武将消耗灵魂石petTplId={0}"),

        @ReasonDesc("武将穿装备-主背包扣除")
        PET_PUTON_EQUIP_REMOVE(10003, "武将穿装备-主背包扣除,petId={0}"),

        @ReasonDesc("武将进阶清除装备")
        PET_UP_COLOR_CLEAR(10004, "武将进阶清除装备,petId={0},colorId={1}"),

        @ReasonDesc("打造装备扣除材料")
        COST_ITEM_FOR_CRAFT_EQUIP(11001, "装备ID={0}"),

        @ReasonDesc("装备打造给装备")
        CRAFT_EQUIP_GIVE(11002, "装备打造给装备"),

        @ReasonDesc("装备升星扣除基本材料")
        COST_BASE_ITEM_FOR_UPSTAR_EQUIP(11003, "装备位={0}"),

        @ReasonDesc("装备升星扣除附加材料")
        COST_EXTRA_ITEM_FOR_UPSTAR_EQUIP(11004, "装备位={0}"),

        @ReasonDesc("还童扣除材料")
        COST_ITEM_FOR_REJUVEN(11005, "还童扣除材料|宠物Id={0}"),

        @ReasonDesc("变异扣除材料")
        COST_ITEM_FOR_VARIATION(11006, "变异扣除材料|宠物Id={0}|预计次数={1}|实际次数={2}"),

        @ReasonDesc("炼化或提升扣除材料")
        COST_ITEM_FOR_ARTIFICE(11007, "炼化或提升扣除材料|宠物Id={0}"),

        @ReasonDesc("悟性提升扣除材料")
        COST_ITEM_FOR_PERCEPT(11008, "悟性提升扣除材料|宠物Id={0}"),

        @ReasonDesc("重铸装备扣除材料")
        COST_ITEM_FOR_RECAST_EQUIP(11009, "装备ID={0}"),

        @ReasonDesc("装备分解，删除装备")
        COST_ITEM_FOR_DECOMPOSE(11010, "装备ID={0}"),

        @ReasonDesc("宠物洗天赋技能扣除道具")
        PET_RESET_TALENT_SKILL_COST(12001, "宠物洗天赋技能扣除道具|宠物Id={0}"),
        @ReasonDesc("宠物学习普通技能扣技能书")
        PET_NORMAL_SKILL_STUDY_COST(12002, "宠物学习普通技能扣技能书|宠物Id={0}|技能Id={1}"),

        @ReasonDesc("洗点消耗道具")
        PET_RESET_POINT_COST(12003, "洗点消耗道具|petId={0}|petType={1}"),

        @ReasonDesc("科举特殊道具使用消耗")
        COST_ITEM_FOR_EXAM(13001, "科举特殊道具使用消耗|特殊道具Id={0}"),

        @ReasonDesc("镶嵌宝石时，消耗一块在主背包内的相应宝石")
        COST_ITEM_FOR_SET_GEM(13501, "镶嵌宝石时，消耗一块在主背包内的相应宝石|宝石模板Id={0}"),

        @ReasonDesc("卸下宝石时，将宝石包内的宝石删除")
        COST_ITEM_FOR_TAKE_OFF_GEM(13502, "卸下宝石时，将宝石包内的宝石删除|宝石模板Id={0}"),

        @ReasonDesc("合成宝石时，扣除材料")
        COST_ITEM_FOR_SYNTHESIS_GEM(13503, "被扣除的宝石类别={0}|被扣除的宝石等级={1}"),

        @ReasonDesc("将物品放入交易行")
        COST_ITEM_FOR_TRADE(13401, "将物品放入交易行时，消耗在主背包内的相应物品|物品UUID={0}"),

        @ReasonDesc("交易行卖出获得")
        TRADE_REWARD(13402, "交易行卖出获得"),
        @ReasonDesc("在交易行购买商品")
        TRADE_BUY(13403, "在交易行购买商品"),
        @ReasonDesc("在交易行下架商品")
        TRADE_TAKE_DOWN(13404, "在交易行下架商品"),
        
        @ReasonDesc("平台兑换码奖励")
		LOCAL_CODE_REWARD(13500, "平台兑换码奖励"),
		
		@ReasonDesc("酒馆任务奖励")
        PUB_TASK_REWARD(13600, "酒馆任务奖励"),
        @ReasonDesc("除暴任务奖励")
		SWEENEY_TASK_REWARD(13601, "除暴任务奖励"),
		@ReasonDesc("藏宝图任务奖励")
		TREASURE_MAP_TASK_REWARD(13602, "藏宝图任务奖励"),
		@ReasonDesc("护送粮草任务奖励")
		FORAGE_TASK_REWARD(13603, "护送粮草任务奖励"),
		@ReasonDesc("帮派任务奖励")
		CORPS_TASK_REWARD(13604, "帮派任务奖励"),
		@ReasonDesc("宝石合成失败奖励")
        GEM_SYN_FAIL_REWARD(13605, "宝石合成失败奖励"),
        @ReasonDesc("七日登录奖励")
		GA_SEVEN_LOGIN_REWARD(13606, "七日登录奖励"),
		@ReasonDesc("等级奖励")
		GA_LEVEL_UP_REWARD(13607, "等级奖励"),
		@ReasonDesc("vip每日礼包")
        VIP_DAY_REWARD(13608, "vip每日礼包"),
        @ReasonDesc("通天塔奖励")
        TOWER_REWARD(13609, "通天塔奖励"),
        @ReasonDesc("vip等级奖励")
        VIP_LEVEL_REWARD(13610, "vip等级奖励"),
        @ReasonDesc("帮派boss奖励")
        CORPS_BOSS_REWARD(13611, "帮派boss奖励"),
        @ReasonDesc("帮派boss排行榜奖励")
        CORPS_BOSS_RANK_REWARD(13612, "帮派boss排行榜奖励"),
        @ReasonDesc("帮派boss挑战次数排行榜奖励")
        CORPS_BOSS_COUNT_RANK_REWARD(13613, "帮派boss挑战次数排行榜奖励"),
        @ReasonDesc("野外封妖榜奖励")
        SEAL_DEMON_REWARD(13614, "野外封妖榜奖励"),
        @ReasonDesc("野外魔王奖励")
        SEAL_DEMON_KING_REWARD(13615, "野外魔王奖励"),
        @ReasonDesc("混世魔王奖励")
        DEVIL_INCARNATE_REWARD(13616, "混世魔王奖励"),
        @ReasonDesc("限时杀怪奖励")
        TIME_LIMIT_MONSTER_REWARD(13617, "限时杀怪奖励"),
        @ReasonDesc("限时挑战npc奖励")
        TIME_LIMIT_NPC_REWARD(13618, "限时挑战npc奖励"),
        @ReasonDesc("绿野仙踪BOSS奖励")
        WIZARD_RAID_BOSS_REWARD(13619, "绿野仙踪BOSS奖励"),
        @ReasonDesc("七日目标任务奖励")
        DAY7_TARGET_REWARD(13620, "七日目标任务奖励"),
        @ReasonDesc("帮派辅助技能奖励")
        CORPS_ASSIST_REWARD(13621, "帮派辅助技能奖励"),
        @ReasonDesc("帮派红包奖励")
        CORPS_RED_ENVELOPE_REWARD(13622, "帮派红包奖励"),
        @ReasonDesc("剧情副本奖励")
        PLOT_DUNGEON_REWARD(13623, "剧情副本奖励"),
        @ReasonDesc("招财进宝奖励")
		GA_BUY_MONEY_REWARD(13624, "招财进宝奖励"),
		@ReasonDesc("开服基金奖励")
		GA_LEVEL_MONEY_REWARD(13625, "开服基金奖励"),
		@ReasonDesc("限时累计充值奖励（精彩活动）")
        GA_NORMAL_TOTAL_CHARGE(13626, "限时累计充值奖励（精彩活动）"),
        @ReasonDesc("每日累计充值奖励（精彩活动）")
		GA_DAY_TOTAL_CHARGE(13627, "每日累计充值奖励（精彩活动）"),
        @ReasonDesc("一元购类型奖励（精彩活动）")
		GA_TOTAL_CHARGE_BUY(13628, "一元购类型奖励（精彩活动）"),
		@ReasonDesc("围剿魔族普通奖励")
        SIEGE_DEMON_NORMAL_REWARD(13629, "围剿魔族普通奖励"),
        @ReasonDesc("围剿魔族困难奖励")
        SIEGE_DEMON_HARD_REWARD(13630, "围剿魔族困难奖励"),
		
        
        @ReasonDesc("捕捉宠物扣除道具")
        CATCH_PET_COST(14001, "捕捉宠物扣除道具|宠物模板Id={0}|怪物组Id={1}"),
        @ReasonDesc("战斗内嗑药扣除道具")
        FIGHT_USE_COST(14002, "战斗内嗑药扣除道具|petUUId={0}|petTypeId={1}"),

        @ReasonDesc("酒馆任务刷新扣除道具")
        PUBTASK_REFRESH_COST(15001, "酒馆任务刷新扣除道具"),

        @ReasonDesc("装备洗炼扣除洗练石")
        MATERIAL_GOLD_BY_REFINERY_EQUIP(15002, "装备ID={0}"),

        @ReasonDesc("打造装备材料不足时扣除金票")
        MATERIAL_LACK_COST_ITEM_FOR_CRAFT_EQUIP(15003, "装备ID={0}"),

        @ReasonDesc("绿野仙踪单人进入扣道具")
        WIZARD_RAID_SINGLE_ENTER_COST(16001, "绿野仙踪单人进入扣道具"),

        @ReasonDesc("藏宝图任务完成后生成道具")
        TREASURE_MAP_GENERATE_PROP(16002, "藏宝图任务完成后生成道具"),

        @ReasonDesc("护送粮草任务刷新扣除道具")
        FORAGETASK_REFRESH_COST(17001, "护送粮草任务刷新扣除道具"),

        @ReasonDesc("升阶翅膀扣除道具")
        WING_UPGRADE_COST(18001, "护送粮草任务刷新扣除道具"),
        
        @ReasonDesc("签到奖励")
        MONTH_SIGN_REWARD(19001, "签到奖励"),
        @ReasonDesc("装备分解")
        EQUIP_DECOMPOSE_REWARD(19002, "装备分解"),
        @ReasonDesc("科举答题")
        EXAM_REWARD(19003, "科举答题"),
        @ReasonDesc("采矿奖励")
        MINE_REWARD(19004, "采矿奖励"),
        @ReasonDesc("邮件附件")
        MAIL_ATTACHMENT_REWARD(19005, "邮件附件"),
        @ReasonDesc("活跃度奖励")
        ACTIVITYUI_REWARD(19006, "活跃度奖励"),
        @ReasonDesc("竞技场攻击奖励")
        ARENA_ATTACK(19007, "竞技场攻击奖励"),
        @ReasonDesc("竞技场排名奖励")
        ARENA_RANK(19008, "竞技场排名奖励"),
        @ReasonDesc("任务奖励")
        QUEST_REWARD(19010, "任务奖励"),
        @ReasonDesc("帮派竞赛奖励")
        CORPS_WAR_REWARD(19011, "帮派竞赛奖励"),
        @ReasonDesc("绿野仙踪奖励")
        WIZARD_RAID_REWARD(19012, "绿野仙踪奖励"),
        @ReasonDesc("打怪胜利奖励")
        WIN_ENEMY_REWARD(19014, "打怪胜利奖励"),
        @ReasonDesc("除暴安良特殊奖励")
        SWEENEY_TASK_SPECIAL(19015, "除暴安良特殊奖励"),
        @ReasonDesc("NVN月度排名奖励")
        NVN_RANK(19016, "NVN月度排名奖励"),
        @ReasonDesc("结婚奖励")
        MARRY_REWARD(19017, "结婚奖励"),
        @ReasonDesc("师徒奖励")
        OVERMAN_REWARD(19018, "师徒奖励"),
        @ReasonDesc("藏宝图奖励")
        TREASURE_MAP_REWARD(19019, "藏宝图奖励"),
        @ReasonDesc("使用礼包道具奖励")
        GIFT_PACK(19020, "使用礼包道具奖励"),
        
        @ReasonDesc("人物学习技能扣道具")
        LEADER_STUDY_SKILL(20001, "人物学习技能扣道具"),
        @ReasonDesc("开启技能仙符位置")
        LEADER_OPEN_SKILL_EFFECT_POS(20002, "开启技能仙符位置|技能Id={0}|位置Id={1}"),
        @ReasonDesc("技能镶嵌仙符扣除道具")
        LEADER_EMBED_SKILL_EFFECT_DEL(20003, "技能镶嵌仙符扣除道具|技能Id={0}|位置Id={1}|仙符等级={2}|仙符经验={3}"),
        @ReasonDesc("技能镶嵌仙符返还道具")
        LEADER_EMBED_SKILL_EFFECT_ADD(2004, "技能镶嵌仙符返还道具|技能Id={0}|位置Id={1}"),
        @ReasonDesc("技能仙符升级消耗")
        LEADER_EMBED_SKILL_EFFECT_UP_DEL(2005, "技能仙符升级消耗|技能Id={0}|位置Id={1}|仙符Id={2}|仙符等级={3}|仙符经验={4}"),
        
        ;
        
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ItemLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "金钱改变")
    public enum MoneyLogReason implements ILogReason {
        /**
         * 玩家充值
         */
        @ReasonDesc("玩家充值获得钻石")
        REASON_MONEY_CHARGE_DIAMOND(1, "兑换的平台币数量={0}"),
        @ReasonDesc("IOS直冲")
        IOS_RECHARGE(2, ""),
        @ReasonDesc("Android直冲")
        ANDROID_RECHARGE(3, ""),
        @ReasonDesc("PC直冲")
        PC_RECHARGE(4, ""),
        @ReasonDesc("其他直冲")
        OTHER_RECHARGE(5, ""),

        @ReasonDesc("副本奖励")
        RAID(6, "副本奖励"),
        @ReasonDesc("副本通关宝箱奖励")
        RAID_BOX(7, "副本通关宝箱奖励"),
        @ReasonDesc("礼包奖励")
        GIFT_PECK_REWARD(8, "礼包奖励"),

        @ReasonDesc("金券套餐直购道具")
        CHARGE_ITEM_COST(9, "金券套餐直购道具"),

        /**
         * 背包卖出道具
         */
        @ReasonDesc("背包卖出道具")
        SELL_TO_SHOP(10, "背包卖出道具"),
        
        @ReasonDesc("充值获得首充额外金子")
        CHARGE_FIRST_GIVE(11, "充值获得首充额外金子"),
        @ReasonDesc("充值获得赠送金子")
        CHARGE_GIFT_GIVE(12, "充值获得赠送金子"),
        
        /**
         * 使用金银卡 参数0金银卡tempalteId; 参数1使用金银卡数量; 参数2获得货币类型; 参数3获得货币数量
         */
        @ReasonDesc("使用金银卡")
        OPEN_CONSUMABLE_GIVE_MONEY_ITEM(14, "{0}|{1}|{2}|{3}"),
        @ReasonDesc("每日充值奖励")
        TODAY_CHARGE_PRIZE(15, "当天充值金额={0}|当次充值金额={1}"),

        /**
         * 增加冷却队列
         */
        @ReasonDesc("增加冷却队列")
        CD_ADD(21, "Cd类型={0}|Cd名称={1}"),
        @ReasonDesc("清除冷却队列")
        CD_KILL(22, "Cd类型={0}|Cd名称={1}|Cd索引位置={2}"),

        /**
         * 体力相关
         */
        @ReasonDesc("系统恢复军令")
        RECOVER_POWER(34, "系统恢复军令={0}"),

        /**
         * 打关卡扣除军令
         */
        @ReasonDesc("打关卡扣除军令")
        ATTACK_MISSION_ENEMY_COST(35, "关卡Id={0}"),

        /**
         * 用餐获得体力
         */
        @ReasonDesc("用餐获得体力")
        BUN_ACTIVITY_GET_POWER(36, "用餐获得体力={0}"),

        /**
         * 关卡获得
         */
        @ReasonDesc("关卡获得")
        MISSION_CURRENCY_REWARD(101, ""),
        @ReasonDesc("关卡宝箱获得")
        MISSION_TREASURE_BOX_REWARD(102, ""),

        /**
         * 关卡挂机消耗军令
         */
        @ReasonDesc("关卡挂机消耗军令")
        CLEAN_MISSION_COST_POWER(201, "关卡Id={0}|挂机完成轮数={1}"),

        /**
         * 关卡挂机立即完成
         */
        @ReasonDesc("关卡挂机立即完成消耗货币")
        CLEAN_MISSION_FINISH(202, "关卡Id={0}|剩余轮数={1}"),

        /**
         * 副本挂机立即完成
         */
        @ReasonDesc("副本挂机立即完成消耗货币")
        CLEAN_RAID_FINISH(203, "副本Id={0}|剩余轮数={1}"),

        /**
         * 副本购买次数
         */
        @ReasonDesc("副本购买次数")
        RAID_BUY_TIMES(204, "副本组Id={0}"),

        /**
         * 竞技场购买次数
         */
        @ReasonDesc("竞技场购买次数")
        ARENA_BUY_TIMES(205, "购买时的已操作次数={0}|购买时的总次数={1}"),
        @ReasonDesc("竞技场清除冷却时间")
        ARENA_KILL_CD(206, "竞技场清除冷却时间"),

        /**
         * 任务奖励
         */
        @ReasonDesc("任务奖励")
        QUEST_REWARD(300, "任务奖励"),

        /**
         * 国家
         */
        @ReasonDesc("推荐国家奖励")
        RECOMMEND_COUNTRY_REWARD(306, "任务奖励"),

        /**
         * 竞技场排名
         */
        @ReasonDesc("竞技场排名奖励")
        ARENA_RANK_REWARD(307, "竞技场排名奖励"),

        @ReasonDesc("竞技场攻击奖励")
        AREAN_ATTACK_REWARD(373, "竞技场攻击奖励"),


        @ReasonDesc("VIP每日领取")
        VIP_ONCE_DAY_REWARD(820, "VIP每日领取"),
        @ReasonDesc("购买VIP卡消耗")
        BUY_VIP_CARD_COST(821, "购买VIP卡消耗"),

        @ReasonDesc("在线礼包奖励")
        ONLINE_GIFT_REWARD(831, "在线礼包奖励"),

        /**
         * 领取平台奖励
         */
        @ReasonDesc("领取平台奖励")
        PLATFORM_PRIZE(841, "奖励ID={0,number,#}"),

        @ReasonDesc("神秘商店元宝刷新")
        MS_BOND_FLUSH_COST(850, "神秘商店元宝刷新"),
        @ReasonDesc("神秘商店高级刷新")
        MS_HIGH_LEVEL_FLUSH_COST(851, "神秘商店高级刷新"),
        @ReasonDesc("神秘商店购买物品")
        MS_BUY_ITEM_COST(852, "神秘商店购买物品"),

        @ReasonDesc("等级礼包")
        LEVEL_GIFT_PACK_REWARD(861, "等级礼包"),

        @ReasonDesc("购买体力扣钱")
        BUY_POWER_NUM(871, "购买体力扣钱|次数={0}|增加体力={1}"),
        @ReasonDesc("购买体力给体力")
        BUY_POWER_NUM_GIVE(872, "购买体力给体力|次数={0}|增加体力={1}"),

        @ReasonDesc("商城购买消耗")
        MALL_BUY_ITEM_COST(881, "商城购买消耗"),

        @ReasonDesc("快捷购买物品消耗")
        QUICK_BUY_ITEM_COST(882, "快捷购买物品消耗  功能ID = {0}, 购买数量 = {1}"),
        @ReasonDesc("快捷购买消耗")
        QUICK_BUY_COST(883, "快捷购买消耗  功能ID = {0}, 购买数量 = {1}"),

        @ReasonDesc("精彩活动奖励")
        GOOD_ACTIVITY_REWARD(893, "精彩活动奖励"),

        @ReasonDesc("每日首充奖励")
        EVERYDAY_CHARGE_GIFT(997, "每日首充奖励"),

        @ReasonDesc("领取CDKEY礼包 ")
        CDKEY_REWARD(1016, "领取CDKEY礼包 "),

        @ReasonDesc("特殊在线礼包")
        SPEC_ONLINE_GIFT(1215, "特殊在线礼包"),

        @ReasonDesc("演武离线打坐获得经验")
        PRACTICE_OFFLINE_ADD_EXP(1216, "演武离线打坐获得经验"),

        @ReasonDesc("累积消耗")
        ACCU_COST_ACTIVITY(1220, "累积消耗"),
        @ReasonDesc("购买累积消耗活动物品")
        ACCU_COST_ACTIVITY_BUY_ITEM(1221, "购买累积消耗活动物品, 类型{0}"),

        @ReasonDesc("消耗钥匙使用物品扣除【货币】")
        COST_KEY_USE_ITEM_COST(1225, "消耗钥匙使用物品扣除【货币】, itemId = {0} count={1}"),

        @ReasonDesc("消耗钥匙使用礼包")
        COST_KEY_USE_ITEM_GIVE(92, "消耗钥匙使用礼包"),

        @ReasonDesc("武将技能升级消耗技能点")
        PET_UP_SKILL_COST_POINT(10001, "武将技能升级消耗技能点,skillLevel={0}"),
        @ReasonDesc("武将技能升级消耗金币")
        PET_UP_SKILL_COST_CURRENCY(10002, "武将技能升级消耗金币,skillLevel={0}"),
        @ReasonDesc("武将升星消耗金币")
        PET_UP_STAR_COST_CURRENCY(10003, "武将技能升星消耗金币,toStar={0}"),
        @ReasonDesc("系统恢复技能点")
        RECOVER_SKILL_POINT(10004, "系统恢复技能点={0}"),
        @ReasonDesc("购买技能点扣钱")
        BUY_SKILL_POINT(10005, "购买技能点扣钱|次数={0}|增加技能点={1}"),
        @ReasonDesc("购买技能点给技能点")
        BUY_SKILL_POINT_GIVE(10006, "购买技能点给技能点|次数={0}|增加技能点={1}"),

        /**
         * 武器打造消耗
         */
        @ReasonDesc("装备打造消耗游戏币")
        COST_GOLD_BY_CRAFT_EQUIP(11001, "打造装备消耗游戏币|装备ID={0}"),

        @ReasonDesc("装备位升星消耗游戏币")
        COST_GOLD_BY_UPSTAR_EQUIP(11002, "装备位升星消耗游戏币|装备位={0}"),

        @ReasonDesc("还童消耗游戏币")
        COST_GOLD_BY_REJUVEN(11003, "还童消耗游戏币|宠物ID={0}"),

        @ReasonDesc("变异消耗游戏币")
        COST_GOLD_BY_VARIATION(11004, "变异消耗游戏币|宠物ID={0}|预计次数={1}|实际次数={2}"),

        @ReasonDesc("炼化或提升消耗游戏币")
        COST_GOLD_BY_ARTIFICE(11005, "炼化或提升消耗游戏币|宠物ID={0}"),

        @ReasonDesc("宠物悟性提升消耗货币")
        COST_GOLD_BY_PERCEPT_UPGRADE(11006, "宠物悟性提升消耗游戏币|宠物ID={0}"),

        @ReasonDesc("宠物培养消耗货币")
        PET_TRAIN_COST(11010, "宠物培养消耗货币|宠物Id={0}|培养方式={1}"),

        @ReasonDesc("伙伴解锁消耗货币")
        PET_FRIEND_UNLOCK(11011, "伙伴解锁消耗货币|伙伴Id={0}|解锁方式={1}"),

        @ReasonDesc("提升心法等级消耗货币")
        COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL(11020, "宠物培养消耗货币|角色Id={0}"),

        @ReasonDesc("装备位镶嵌宝石消耗货币")
        COST_CURRENCY_BY_SET_GEM(11030, "装备位镶嵌宝石消耗货币 装备位={0}|宝石位={1}|"),

        @ReasonDesc("宝石合成消耗货币")
        COST_CURRENCY_BY_SYNTHESIS_GEM(11031, "宝石合成消耗货币 宝石类别={0}|宝石等级={1}|"),

        @ReasonDesc("交易行扣除手续费")
        COST_CURRENCY_BY_LISTING_COMMODITY_ON_TRADE(11040, "交易行扣除手续费  商品类型={0}|商品ID={1}|"),

        @ReasonDesc("交易行扣除手续费")
        COST_CURRENCY_BY_BUY_COMMODITY_ON_TRADE(11041, "交易行扣除商品费用  商品类型={0}|商品ID={1}|"),

        @ReasonDesc("交易行卖出物品获得")
        TRADE_REWARD(11042, "交易行卖出物品获得"),

        @ReasonDesc("装备重铸消耗游戏币")
        COST_GOLD_BY_RECAST_EQUIP(11043, "重铸装备消耗游戏币|装备ID={0}"),

        @ReasonDesc("装备分解消耗货币")
        COST_GOLD_BY_DECOMPOSE_EQUIP(11044, "分解装备消耗游戏币"),

        @ReasonDesc("装备洗炼消耗银票")
        COST_GOLD_BY_REFINERY_EQUIP(11045, "洗炼装备消耗游戏币|装备ID={0}"),

        @ReasonDesc("装备打造消耗游戏币")
        COST_GIFT_BOND_BY_CRAFT_EQUIP(11046, "打造装备材料不足时需消耗金票|装备ID={0}"),
        @ReasonDesc("骑宠还童消耗游戏币")
        COST_GOLD_BY_REJUVEN_PET_HORSE(11047, "还童消耗游戏币|骑宠ID={0}"),

        @ReasonDesc("骑宠炼化或提升消耗游戏币")
        COST_GOLD_BY_ARTIFICE_PET_HORSE(11048, "炼化或提升消耗游戏币|骑宠ID={0}"),

        @ReasonDesc("骑宠悟性提升消耗货币")
        COST_GOLD_BY_PERCEPT_UPGRADE_PET_HORSE(11049, "骑宠悟性提升消耗游戏币|骑宠ID={0}"),

        @ReasonDesc("骑宠培养消耗货币")
        PET_HORSE_TRAIN_COST(11050, "骑宠培养消耗货币|骑宠Id={0}|培养方式={1}"),
        
        @ReasonDesc("平台兑换码奖励")
		LOCAL_CODE_REWARD(11051, "平台兑换码奖励"),
		
		@ReasonDesc("酒馆任务奖励")
        PUB_TASK_REWARD(11060, "酒馆任务奖励"),
        @ReasonDesc("除暴任务奖励")
		SWEENEY_TASK_REWARD(11061, "除暴任务奖励"),
		@ReasonDesc("藏宝图任务奖励")
		TREASURE_MAP_TASK_REWARD(11062, "藏宝图任务奖励"),
		@ReasonDesc("护送粮草任务奖励")
		FORAGE_TASK_REWARD(11063, "护送粮草任务奖励"),
		@ReasonDesc("帮派任务奖励")
		CORPS_TASK_REWARD(11064, "帮派任务奖励"),
		@ReasonDesc("宝石合成失败奖励")
        GEM_SYN_FAIL_REWARD(11065, "宝石合成失败奖励"),
        @ReasonDesc("七日登录奖励")
		GA_SEVEN_LOGIN_REWARD(11066, "七日登录奖励"),
		@ReasonDesc("等级奖励")
		GA_LEVEL_UP_REWARD(11067, "等级奖励"),
		@ReasonDesc("vip每日礼包")
        VIP_DAY_REWARD(11068, "vip每日礼包"),
        @ReasonDesc("通天塔奖励")
        TOWER_REWARD(11069, "通天塔奖励"),
        @ReasonDesc("vip等级奖励")
        VIP_LEVEL_REWARD(11070, "vip等级奖励"),
        @ReasonDesc("帮派boss奖励")
        CORPS_BOSS_REWARD(11071, "帮派boss奖励"),
        @ReasonDesc("帮派boss排行榜奖励")
        CORPS_BOSS_RANK_REWARD(11072, "帮派boss排行榜奖励"),
        @ReasonDesc("帮派boss挑战次数排行榜奖励")
        CORPS_BOSS_COUNT_RANK_REWARD(11073, "帮派boss挑战次数排行榜奖励"),
        @ReasonDesc("野外封妖榜奖励")
        SEAL_DEMON_REWARD(11074, "野外封妖榜奖励"),
        @ReasonDesc("野外魔王奖励")
        SEAL_DEMON_KING_REWARD(11075, "野外魔王奖励"),
        @ReasonDesc("混世魔王奖励")
        DEVIL_INCARNATE_REWARD(11076, "混世魔王奖励"),
        @ReasonDesc("限时杀怪奖励 ")
        TIME_LIMIT_MONSTER_REWARD(11077, "限时杀怪奖励 "),
        @ReasonDesc("限时挑战npc奖励")
        TIME_LIMIT_NPC_REWARD(11078, "限时挑战npc奖励"),
        @ReasonDesc("绿野仙踪BOSS奖励")
        WIZARD_RAID_BOSS_REWARD(11079, "绿野仙踪BOSS奖励"),
        @ReasonDesc("七日目标任务奖励")
        DAY7_TARGET_REWARD(11080, "七日目标任务奖励"),
        @ReasonDesc("帮派辅助技能奖励")
        CORPS_ASSIST_REWARD(11081, "帮派辅助技能奖励"),
        @ReasonDesc("帮派修炼技能扣除货币")
        COST_GOLD_BY_CORPS_CULTIVATE(11082, "帮派辅助技能奖励|技能Id={0}"),
        @ReasonDesc("帮派学习辅助技能扣除货币")
        COST_GOLD_BY_CORPS_ASSIST(11083, "帮派学习辅助技能奖励|技能Id={0}"),
        @ReasonDesc("帮派红包奖励")
        CORPS_RED_ENVELOPE_REWARD(11084, "帮派红包奖励"),
        @ReasonDesc("剧情副本奖励")
        PLOT_DUNGEON_REWARD(11085, "剧情副本奖励"),
        @ReasonDesc("活力值奖励")
        ENERGY_REWARD(11086, "活力值奖励"),
        @ReasonDesc("招财进宝奖励")
		GA_BUY_MONEY_REWARD(11087, "招财进宝奖励"),
		@ReasonDesc("招财进宝奖励花费")
		GA_BUY_MONEY_COST(11088, "招财进宝奖励花费"),
		@ReasonDesc("开服基金奖励")
		GA_LEVEL_MONEY_REWARD(11089, "开服基金奖励"),
		@ReasonDesc("开服基金奖励花费")
		GA_LEVEL_MONEY_COST(11090, "开服基金奖励花费"),
		@ReasonDesc("一元购奖励花费")
		GA_TOTOAL_CHARGE_BUY_COST(11091, "一元购奖励花费"),
		@ReasonDesc("限时累计充值奖励（精彩活动）")
        GA_NORMAL_TOTAL_CHARGE(11092, "限时累计充值奖励（精彩活动）"),
        @ReasonDesc("每日累计充值奖励（精彩活动）")
		GA_DAY_TOTAL_CHARGE(11093, "每日累计充值奖励（精彩活动）"),
        @ReasonDesc("一元购类型奖励（精彩活动）")
		GA_TOTAL_CHARGE_BUY(11094, "一元购类型奖励（精彩活动）"),
		@ReasonDesc("围剿魔族普通奖励")
        SIEGE_DEMON_NORMAL_REWARD(11095, "围剿魔族普通奖励"),
        @ReasonDesc("围剿魔族困难奖励")
        SIEGE_DEMON_HARD_REWARD(11096, "围剿魔族困难奖励"),
        
        /**
         * 军团
         */
        @ReasonDesc("创建军团")
        CREATE_CORPS_COST_GOLD(12000, "创建军团扣金币"),
        @ReasonDesc("军团捐献")
        CORPS_DONATE(12001, "军团捐献扣除金币"),
        @ReasonDesc("领取帮派福利")
        GET_BENIFIT(12002, "领取帮派福利"),

        /**
         * 生活技能
         */
        @ReasonDesc("采矿扣除货币")
        MINING_COST_VITALITY(13000, "采矿扣除货币"),
        @ReasonDesc("帮派辅助技能扣除货币")
        CORPS_ASSIST_COST_VITALITY(13001, "帮派辅助技能扣除货币"),

        @ReasonDesc("酒馆任务刷新扣钱")
        PUBTASK_REFRESH_COST(13100, "酒馆任务刷新扣钱"),

        @ReasonDesc("护送粮草任务押金扣钱")
        FORAGETASK_REFRESH_COST(14000, "护送粮草任务刷新扣钱"),

        @ReasonDesc("护送粮草任务完成获得奖励")
        FORAGETASK_MONEY_REWARD(14100, "护送粮草任务完成获得奖励"),

        @ReasonDesc("强制解除师徒关系")
        FORCE_FIRE_OVERMAN(15000, "强制解除师徒关系"),

        @ReasonDesc("结婚扣除费用")
        MARRY_COST(15001, "结婚扣除费用"),

        @ReasonDesc("强制解除夫妻关系")
        FORCE_FIRE_MARRY_COST(15002, "强制解除夫妻关系扣除费用"),
        
        @ReasonDesc("升阶翅膀")
        UPGRADE_WING_COST(16000, "升阶翅膀扣除费用"),

        @ReasonDesc("签到奖励")
        MONTH_SIGN_REWARD(17001, "签到奖励"),
        @ReasonDesc("装备分解")
        EQUIP_DECOMPOSE_REWARD(17002, "装备分解"),
        @ReasonDesc("科举答题")
        EXAM_REWARD(17003, "科举答题"),
        @ReasonDesc("采矿奖励")
        MINE_REWARD(17004, "采矿奖励"),
        @ReasonDesc("邮件附件")
        MAIL_ATTACHMENT_REWARD(17005, "邮件附件"),
        @ReasonDesc("活跃度奖励")
        ACTIVITYUI_REWARD(17006, "活跃度奖励"),
        @ReasonDesc("竞技场攻击奖励")
        ARENA_ATTACK(17007, "竞技场攻击奖励"),
        @ReasonDesc("竞技场排名奖励")
        ARENA_RANK(17008, "竞技场排名奖励"),
        @ReasonDesc("帮派竞赛奖励")
        CORPS_WAR_REWARD(17011, "帮派竞赛奖励"),
        @ReasonDesc("绿野仙踪奖励")
        WIZARD_RAID_REWARD(17012, "绿野仙踪奖励"),
        @ReasonDesc("打怪胜利奖励")
        WIN_ENEMY_REWARD(17014, "打怪胜利奖励"),
        @ReasonDesc("除暴安良特殊奖励")
        SWEENEY_TASK_SPECIAL(17015, "除暴安良特殊奖励"),
        @ReasonDesc("NVN月度排名奖励")
        NVN_RANK(17016, "NVN月度排名奖励"),
        @ReasonDesc("结婚奖励")
        MARRY_REWARD(17017, "结婚奖励"),
        @ReasonDesc("师徒奖励")
        OVERMAN_REWARD(17018, "师徒奖励"),
        @ReasonDesc("藏宝图奖励")
        TREASURE_MAP_REWARD(17019, "藏宝图奖励"),
        @ReasonDesc("使用礼包道具奖励")
        GIFT_PACK(17020, "使用礼包道具奖励"),
        
        @ReasonDesc("充值获得红包钱")
        GIVE_RED_MONEY_ON_CHARGE(18000, "充值获得红包钱|充值元宝={0}|充值RMB分={1}"),

        /**
         * 命令
         */
        @ReasonDesc("通过debug命令给金钱")
        DEBUG_CMD_GIVE(9999, "debug"),
        ;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private MoneyLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    /**
     * 作弊日志产生原因
     */
    @LogDesc(desc = "作弊")
    public enum CheatLogReason implements ILogReason {

        /**
         * 使用物品时作弊
         */
        @ReasonDesc("使用物品时作弊")
        USE_ITEM(11, "使用物品时作弊");

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private CheatLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    /**
     * 军团日志
     */
    @LogDesc(desc = "军团")
    public enum CorpsLogReason implements ILogReason {
        @ReasonDesc("服务器启动时，初始化军团仓库")
        CORPS_STARTUP_INIT_STORAGE(1, "仓库数据 |{0}"),
        @ReasonDesc("服务器启动时，加载军团成功")
        CORPS_STARTUP_INIT_SUCC(2, "加载军团成功"),
        @ReasonDesc("服务器启动时，加载军团失败")
        CORPS_STARTUP_INIT_FAIL(3, "加载军团失败，原因|{0}"),
        @ReasonDesc("忽略所有申请")
        CORPS_INGORE_ALL_APPLY(4, "忽略所有申请"),
        @ReasonDesc("军团申请,军团人数已满")
        CORPS_APPLY_CORPS_ENOUGH(5, "军团申请，军团人数已满"),
        @ReasonDesc("军团申请,本人申请数已达上限")
        CORPS_APPLY_LIST_ENOUGH(6, "军团申请,本人申请数已达上限"),
        @ReasonDesc("军团申请")
        CORPS_APPLY_SUCC(7, "军团申请"),
        @ReasonDesc("军团申请撤销")
        CORPS_APPLY_CANCEL(8, "军团申请撤销"),
        @ReasonDesc("创建军团,军团名称存在")
        CORPS_CREATE_NAME(9, "创建军团,{0}军团名称存在"),
        @ReasonDesc("创建军团,军团名称含有屏蔽字")
        CORPS_CREATE_DIRT_NAME(10, "创建军团,{0}军团名称含有屏蔽字"),
        @ReasonDesc("创建军团,金币不够")
        CORPS_CREATE_MONEY(11, "创建军团,金币不够"),
        @ReasonDesc("创建军团,扣钱失败")
        CORPS_CREATE_MONEY_FAILER(12, "创建军团,扣钱失败"),
        @ReasonDesc("创建军团成功")
        CORPS_CREATE_SUCC(13, "创建军团成功"),
        @ReasonDesc("军团事件")
        CORPS_EVENT(14, "军团事件|{0}"),
        @ReasonDesc("军团捐献")
        CORPS_DONATE(15, "军团捐献 num = {0}"),
        @ReasonDesc("修改军团公告")
        CORPS_NOTICE_UPDATE(16, "修改军团公告|{0}"),
        @ReasonDesc("退出军团")
        CORPS_EXIT(17, "退出军团"),
        @ReasonDesc("退出解散")
        CORPS_DISBAND(18, "退出解散"),
        @ReasonDesc("申请团长")
        CORPS_APPLY_PRESIDENT(19, "申请团长"),
        @ReasonDesc("待分配物品列表")
        CORPS_DISTRIBUTION_ITEM(20, "待分配物品列表|{0}"),
        @ReasonDesc("分配前物品列表")
        CORPS_PRE_DISTRIBUTION_ITEM(21, "分配前物品列表|{0}"),
        @ReasonDesc("分配后物品列表")
        CORPS_AFTER_DISTRIBUTION_ITEM(22, "分配前物品列表|{0}"),
        @ReasonDesc("通过申请")
        CORPS_PASS_APPLY(23, "通过申请"),
        @ReasonDesc("拒绝申请")
        CORPS_REFUSE_APPLY(24, "拒绝申请"),
        @ReasonDesc("开除成员")
        CORPS_FIRE_MEMBER(25, "开除成员"),
        @ReasonDesc("转让团长")
        CORPS_TRANSFER_PRESIDENT(26, "转让团长"),
        @ReasonDesc("GM解散")
        GM_CORPS_DISBAND(27, "GM解散"),
        @ReasonDesc("弹劾解散")
        CORPS_IMPEACH_DISBAND(28, "弹劾解散"),
        @ReasonDesc("增加帮派经验")
        CORPS_ADD_EXP(29,"增加帮派经验 exp = {0}"),
        @ReasonDesc("增加帮派资金")
        CORPS_ADD_FUND(30,"增加帮派资金 gold = {0}"),
        @ReasonDesc("增加帮贡")
        CORPS_ADD_CONTRIBUTION(31,"增加帮贡 contribution = {0}"),
        @ReasonDesc("帮派维护费用不足")
        CORPS_MAINTENANCE_COST_NOT_ENOUGH(32,"帮派维护费用不足 cost = {0}"),
        @ReasonDesc("扣除帮派维护费用")
        CORPS_MAINTENANCE_COST(33,"扣除帮派维护费用 cost = {0}"),
        @ReasonDesc("GM增加帮派经验")
        CORPS_ADD_EXP_GM(34,"增加帮派经验 exp = {0}"),
        @ReasonDesc("GM增加帮派资金")
        CORPS_ADD_FUND_GM(35,"增加帮派资金 gold = {0}"),
        @ReasonDesc("GM增加帮贡")
        CORPS_ADD_CONTRIBUTION_GM(36,"增加帮贡 contribution = {0}"),
        @ReasonDesc("清除周帮贡")
        CORPS_CLEAR_WEEK_CONTRIBUTION(37,"清除周帮贡"),
        @ReasonDesc("帮派boss进度榜奖励")
        BOSS_RANK_REWARD(38,"帮派boss进度榜奖励"),
        @ReasonDesc("帮派boss挑战次数榜奖励")
        BOSS_COUNT_RANK_REWARD(39,"帮派boss挑战次数榜奖励"),

        @ReasonDesc("签到奖励")
        MONTH_SIGN_REWARD(101, "签到奖励"),
        @ReasonDesc("装备分解")
        EQUIP_DECOMPOSE_REWARD(102, "装备分解"),
        @ReasonDesc("科举答题")
        EXAM_REWARD(103, "科举答题"),
        @ReasonDesc("采矿奖励")
        MINE_REWARD(104, "采矿奖励"),
        @ReasonDesc("邮件附件")
        MAIL_ATTACHMENT_REWARD(105, "邮件附件"),
        @ReasonDesc("活跃度奖励")
        ACTIVITYUI_REWARD(106, "活跃度奖励"),
        @ReasonDesc("竞技场攻击奖励")
        ARENA_ATTACK(107, "竞技场攻击奖励"),
        @ReasonDesc("竞技场排名奖励")
        ARENA_RANK(108, "竞技场排名奖励"),
        @ReasonDesc("精彩活动奖励")
        GOOD_ACTIVITY_REWARD(109, "精彩活动奖励"),
        @ReasonDesc("任务奖励")
        QUEST_REWARD(110, "任务奖励"),
        @ReasonDesc("帮派竞赛奖励")
        CORPS_WAR_REWARD(111, "帮派竞赛奖励"),
        @ReasonDesc("绿野仙踪奖励")
        WIZARD_RAID_REWARD(112, "绿野仙踪奖励"),
        @ReasonDesc("在线礼包奖励")
        ONLINE_GIFT_REWARD(113, "在线礼包奖励"),
        @ReasonDesc("打怪胜利奖励")
        WIN_ENEMY_REWARD(114, "打怪胜利奖励"),
        @ReasonDesc("除暴安良特殊奖励")
        SWEENEY_TASK_SPECIAL(115, "除暴安良特殊奖励"),
        @ReasonDesc("NVN月度排名奖励")
        NVN_RANK(116, "NVN月度排名奖励"),
        @ReasonDesc("结婚奖励")
        MARRY_REWARD(117, "结婚奖励"),
        @ReasonDesc("师徒奖励")
        OVERMAN_REWARD(118, "师徒奖励"),
        @ReasonDesc("藏宝图奖励")
        TREASURE_MAP_REWARD(119, "藏宝图奖励"),
        @ReasonDesc("使用礼包道具奖励")
        GIFT_PACK(120, "使用礼包道具奖励"),
        
        @ReasonDesc("酒馆任务奖励")
        PUB_TASK_REWARD(130, "酒馆任务奖励"),
        @ReasonDesc("除暴任务奖励")
		SWEENEY_TASK_REWARD(131, "除暴任务奖励"),
		@ReasonDesc("藏宝图任务奖励")
		TREASURE_MAP_TASK_REWARD(132, "藏宝图任务奖励"),
		@ReasonDesc("护送粮草任务奖励")
		FORAGE_TASK_REWARD(133, "护送粮草任务奖励"),
		@ReasonDesc("帮派任务奖励")
		CORPS_TASK_REWARD(134, "帮派任务奖励"),
		@ReasonDesc("七日登录奖励")
		GA_SEVEN_LOGIN_REWARD(136, "七日登录奖励"),
		@ReasonDesc("等级奖励")
		GA_LEVEL_UP_REWARD(137, "等级奖励"),
		@ReasonDesc("vip每日礼包")
        VIP_DAY_REWARD(138, "vip每日礼包"),
        @ReasonDesc("通天塔奖励")
        TOWER_REWARD(139, "通天塔奖励"),
        @ReasonDesc("vip等级奖励")
        VIP_LEVEL_REWARD(140, "vip等级奖励"),
        @ReasonDesc("帮派boss奖励")
        CORPS_BOSS_REWARD(141, "帮派boss奖励"),
        @ReasonDesc("帮派boss排行榜奖励")
        CORPS_BOSS_RANK_REWARD(142, "帮派boss排行榜奖励"),
        @ReasonDesc("帮派boss挑战次数排行榜奖励")
        CORPS_BOSS_COUNT_RANK_REWARD(143, "帮派boss挑战次数排行榜奖励"),
        @ReasonDesc("野外封妖榜奖励")
        SEAL_DEMON_REWARD(144, "野外封妖榜奖励"),
        @ReasonDesc("野外魔王奖励")
        SEAL_DEMON_KING_REWARD(145, "野外魔王奖励"),
        @ReasonDesc("混世魔王奖励")
        DEVIL_INCARNATE_REWARD(146, "混世魔王奖励"),
        @ReasonDesc("限时杀怪奖励 ")
        TIME_LIMIT_MONSTER_REWARD(147, "限时杀怪奖励 "),
        @ReasonDesc("限时挑战npc奖励")
        TIME_LIMIT_NPC_REWARD(148, "限时挑战npc奖励"),
        @ReasonDesc("绿野仙踪BOSS奖励")
        WIZARD_RAID_BOSS_REWARD(149, "绿野仙踪BOSS奖励"),
        @ReasonDesc("七日目标任务奖励")
        DAY7_TARGET_REWARD(150, "七日目标任务奖励"),
        @ReasonDesc("帮派辅助技能奖励")
        CORPS_ASSIST_REWARD(151, "帮派辅助技能奖励"),
        @ReasonDesc("帮派红包奖励")
        CORPS_RED_ENVELOPE_REWARD(152, "帮派红包奖励"),
        @ReasonDesc("剧情副本奖励")
        PLOT_DUNGEON_REWARD(153, "剧情副本奖励"),
        ;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private CorpsLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }

    /**
     * 作弊日志产生原因
     */
    @LogDesc(desc = "奖励日志")
    public enum RewardLogReason implements ILogReason {

        /**
         * 使用物品时作弊
         */
        @ReasonDesc("通过rewardId生成的奖励")
        CREATE_REWARD(1, "通过rewardId生成的奖励"),

        @ReasonDesc("通过合并奖励生成的奖励")
        MERGE_REWARD(2, "通过合并奖励生成的奖励"),

        @ReasonDesc("通过军团分配生成的奖励")
        CORPS_ALLOCATION(3, "通过军团分配生成的奖励"),;


        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private RewardLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    /**
     * 经验的原因接口
     *
     * @param <E> 枚举类型
     */
    public static interface IExpLogReason<E extends Enum<E>> extends ILogReason {
        public E getReasonEnum();
    }

    /**
     * 经验的原因接口
     *
     * @param <E> 枚举类型
     */
    public static interface ILevelLogReason<E extends Enum<E>> extends ILogReason {
        public E getReasonEnum();
    }

    /**
     * 聊天日志产生原因
     */
    @LogDesc(desc = "聊天")
    public enum ChatLogReason implements ILogReason {
        /**
         * 包含不良信息
         */
        @ReasonDesc("包含不良信息")
        REASON_CHAT_DIRTY_WORD(0, ""),
        /**
         * 普通聊天信息
         */
        @ReasonDesc("普通聊天信息")
        REASON_CHAT_COMMON(1, ""),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ChatLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    /**
     * 经验日志产生原因
     */
    @LogDesc(desc = "经验")
    public enum PetExpLogReason implements ILogReason {
        /**
         * 关卡获得经验
         */
        @ReasonDesc("关卡获得经验")
        MISSION_EXP_REWARD(1, "关卡获得经验"),
        /**
         * 任务经验奖励
         */
        @ReasonDesc("任务获得经验")
        QUEST_EXP_REWARD(2, "任务获得经验"),
        @ReasonDesc("关卡获得经验")
        MISSION_TREASURE_BOX_EXP_REWARD(3, "关卡获得经验"),
        @ReasonDesc("推荐国家获得经验")
        RECOMMEND_COUNTRY_REWARD(4, "推荐国家获得经验"),
        @ReasonDesc("竞技场排名奖励")
        ARENA_RANK_REWARD(5, "竞技场排名奖励"),

        @ReasonDesc("军团战玩家报名奖励")
        CORPSWAR_USER_JOIN(6, "军团战玩家报名奖励"),
        @ReasonDesc("军团战玩家战斗奖励")
        CORPSWAR_USER_FIGHT(7, "军团战玩家战斗奖励"),

        @ReasonDesc("世界boss战攻击奖励")
        WORLD_BOSSWAR_ATTACK(8, "世界boss战攻击奖励"),
        @ReasonDesc("世界boss战击杀奖励")
        WORLD_BOSSWAR_KILL(9, "世界boss战击杀奖励"),
        @ReasonDesc("世界boss战排名奖励 ")
        WORLD_BOSSWAR_RANK(10, "世界boss战排名奖励"),

        @ReasonDesc("斗地主互动增加经验")
        LANDLORD_INTERACTION(11, "斗地主互动增加经验|targetId={0}|targetLevel={1}|actionId={2}"),

        @ReasonDesc("斗地主从苦工获取经验")
        LANDLORD_FROM_SLAVER(12, "斗地主从苦工获取经验|masterId={0}"),

        @ReasonDesc("斗地主玩家离线时从苦工获取经验")
        LANDLORD_FROM_SLAVER_OFFLINE(13, "斗地主玩家离线时从苦工获取经验"),

        @ReasonDesc("GM命令增加经验")
        GM_CMD(14, "GM命令增加经验"),

        @ReasonDesc("副本奖励")
        RAID(15, "副本奖励"),
        @ReasonDesc("副本通关宝箱奖励")
        RAID_BOX(16, "副本通关宝箱奖励"),

        @ReasonDesc("过关斩将奖励")
        HERO_MISSION(17, "过关斩将奖励"),

        @ReasonDesc("主将经验卡")
        MAIN_PET_EXP_CARD_ADD(18, "主将经验卡"),
        @ReasonDesc("副将经验卡")
        OTHER_PET_EXP_CARD_ADD(45, "副将经验卡"),
        @ReasonDesc("礼包奖励")
        GIFT_PECK_ADD(19, "礼包奖励"),

        @ReasonDesc("领地给主将经验")
        LAND_ADD_EXP(20, "领地给主将经验|地块Id={0}|品阶={1}|倍数={2}"),

        @ReasonDesc("竞技场攻击奖励")
        AREAN_ATTACK_REWARD(21, "竞技场攻击奖励"),

        @ReasonDesc("首充奖励")
        FIRST_CHARGE_REWARD(22, "首充奖励"),

        @ReasonDesc("七日签到奖励")
        SEVEN_SIGNIN_REWARD(23, "七日签到奖励"),

        @ReasonDesc("目标系统任务奖励")
        STEPTASK_TASK_REWARD(24, "目标系统任务奖励"),
        @ReasonDesc("目标系统阶段奖励")
        STEPTASK_STEP_REWARD(25, "目标系统阶段奖励"),

        @ReasonDesc("内政系统任务奖励")
        PASSTASK_TASK_REWARD(26, "内政系统任务奖励"),
        @ReasonDesc("内政系统阶段奖励")
        PASSTASK_STEP_REWARD(27, "内政系统阶段奖励"),

        @ReasonDesc("女神宝藏显示奖励")
        LUCKYDRAW_SHOW_REWARD(28, "女神宝藏显示奖励"),
        @ReasonDesc("女神宝藏实际奖励")
        LUCKYDRAW_GIVE_REWARD(29, "女神宝藏实际奖励"),

        @ReasonDesc("VIP每日领取")
        VIP_ONCE_DAY_REWARD(30, "VIP每日领取"),

        @ReasonDesc("在线礼包")
        ONLINE_GIFT_REWARD(46, "在线礼包"),
        @ReasonDesc("等级礼包")
        LEVEL_GIFT_PACK_REWARD(31, "等级礼包"),

        @ReasonDesc("军衔激活奖励")
        ARMY_TITLE_REWARD(32, "军衔激活奖励"),
        @ReasonDesc("军衔俸禄奖励")
        ARMY_TITLE_SALARY_REWARD(33, "军衔俸禄奖励"),

        @ReasonDesc("精彩活动奖励")
        GOOD_ACTIVITY_REWARD(34, "精彩活动奖励"),

        @ReasonDesc("领地献计奖励")
        LAND_OFFER_ADVICE_REWARD(35, "领地献计奖励"),


        @ReasonDesc("用餐御射奖励")
        BUN_ROLL_REWARD(36, "用餐御射奖励"),

        @ReasonDesc("手机验证奖励")
        SMS_CHECKCODE_REWARD(37, "手机验证奖励"),

        @ReasonDesc("每日活跃奖励")
        EVERY_DAY_TARGET_REWARD(38, "每日活跃奖励"),

        @ReasonDesc("南蛮入侵攻击奖励")
        MONSTER_WAR_ATTACK(39, "南蛮入侵攻击奖励"),
        @ReasonDesc("南蛮入侵击杀奖励")
        MONSTER_WAR_KILL(40, "南蛮入侵击杀奖励"),
        @ReasonDesc("南蛮入侵排名奖励 ")
        MONSTER_WAR_RANK(41, "南蛮入侵排名奖励"),
        @ReasonDesc("南蛮入侵下注奖励 ")
        MONSTER_WAR_BET(42, "南蛮入侵下注奖励"),

        @ReasonDesc("卡牌-抽卡奖励 ")
        CARD_DRAW_REWARD(50, "卡牌-抽卡奖励"),
        @ReasonDesc("卡牌-日排名普通奖励")
        CARD_DAY_RANK_NORMAL(51, "卡牌-日排名普通奖励"),
        @ReasonDesc("卡牌-日排名超级奖励 ")
        CARD_DAY_RANK_SUPER(52, "卡牌-日排名超级奖励"),
        @ReasonDesc("卡牌-累计排名普通奖励 ")
        CARD_FINAL_RANK_NORMAL(53, "卡牌-累计排名普通奖励"),
        @ReasonDesc("卡牌-累计排名超级奖励")
        CARD_FINAL_RANK_SUPER(54, "卡牌-累计排名超级奖励"),
        @ReasonDesc("卡牌-奖励兑换")
        CARD_EXCHANGE_REWARD(55, "卡牌-奖励兑换"),

        @ReasonDesc("幸运转盘抽奖奖励")
        TURNTABLE_DRAW_REWARD(56, "幸运转盘抽奖奖励"),

        @ReasonDesc("宝石迷阵奖励")
        GEM_MAZE_REWARD(57, "宝石迷阵奖励"),

        @ReasonDesc("兑换商城奖励")
        CONVERT_MAILL(58, "兑换商城奖励"),

        @ReasonDesc("qq-黄钻新手奖励")
        QQ_VIP_NEWER(60, "qq-黄钻新手奖励"),
        @ReasonDesc("qq-黄钻每日奖励")
        QQ_VIP_DAY(61, "qq-黄钻每日奖励"),
        @ReasonDesc("qq-豪华黄钻每日额外奖励")
        QQ_VIP_HIGH_DAY(62, "qq-豪华黄钻每日额外奖励"),
        @ReasonDesc("qq-年费黄钻每日额外奖励")
        QQ_VIP_YEAR_DAY(63, "qq-年费黄钻每日额外奖励"),
        @ReasonDesc("qq-黄钻升级奖励")
        QQ_VIP_LEVEL(64, "qq-黄钻升级奖励"),

        @ReasonDesc("qq-充值赠送奖励")
        QQ_CHARGE(65, "qq-充值赠送奖励"),

        @ReasonDesc("环任务单环奖励")
        LOOP_TASK_LOOP_REWARD(66, "环任务单环奖励"),

        @ReasonDesc("环任务总奖励")
        LOOP_TASK_TOTAL_REWARD(67, "环任务总奖励"),

        @ReasonDesc("qq-被邀请者n天奖励")
        QQ_BEINVITED_DAY_REWARD(68, "qq-被邀请者n天奖励 "),
        @ReasonDesc("qq-充值返利奖励")
        QQ_CHARGE_RETURN_REWARD(69, "qq-充值返利奖励"),
        @ReasonDesc("qq-邀请好友次数奖励")
        QQ_INVITE_COUNT_REWARD(70, "qq-邀请好友次数奖励"),
        @ReasonDesc("qq-历程分享奖励")
        QQ_SHARE_BYFUNC_REWARD(71, "qq-历程分享奖励"),
        @ReasonDesc("qq-每日邀请好友奖励")
        QQ_INVITE_DAY_REWARD(72, "qq-每日邀请好友奖励"),
        @ReasonDesc("qq-app评分奖励")
        QQ_APP_SCORE_REWARD(73, "qq-app评分奖励"),
        @ReasonDesc("qq-集市任务奖励")
        QQ_MARKET_TASK_REWARD(74, "qq-集市任务奖励"),

        @ReasonDesc("每日首充奖励")
        EVERYDAY_CHARGE_GIFT(75, "每日首充奖励"),

        @ReasonDesc("渡江单次攻击")
        ESCORT_SINGLE_ATTACK(76, "渡江单次攻击"),
        @ReasonDesc("渡江完成")
        ESCORT_COMPLETE(77, "渡江完成"),
        @ReasonDesc("借东风开启奖励")
        ESCORT_GLOBAL_ENCOURAGE_OPEN(78, "借东风开启奖励"),
        @ReasonDesc("借东风结束奖励")
        ESCORT_GLOBAL_ENCOURAGE_COMPLETE(79, "借东风结束奖励"),
        @ReasonDesc("抢夺收益排名奖励")
        ESCORT_INCOME_RANK(80, "抢夺收益排名奖励"),
        @ReasonDesc("抢夺收益排名超级奖励")
        ESCORT_INCOME_RANK_SUPER(81, "抢夺收益排名超级奖励"),
        @ReasonDesc("渡江护送完成 ")
        ESCORT_HELP_COMPLETE(82, "渡江护送完成"),

        @ReasonDesc("领取CDKEY礼包 ")
        CDKEY_REWARD(83, "领取CDKEY礼包 "),

        @ReasonDesc("试剑塔关卡敌人奖励")
        SWORD_TOWER_MISSION(84, "试剑塔关卡敌人奖励"),

        @ReasonDesc("经典战役通关奖励")
        CLASSIC_BATTLE_BOX_REWARD(85, "经典战役通关奖励"),
        @ReasonDesc("经典战役事件奖励")
        CLASSIC_BATTLE_PASS_REWARD(86, "经典战役事件奖励"),
        @ReasonDesc("经典战役自动通关奖励")
        CLASSIC_BATTLE_PASS_AUTO_REWARD(87, "经典战役自动通关奖励"),

        @ReasonDesc("特殊在线礼包")
        SPEC_ONLINE_GIFT(88, "特殊在线礼包"),

        @ReasonDesc("演武在线打坐获得经验")
        PRACTICE_ONLINE_ADD_EXP(89, "演武在线打坐获得经验"),

        @ReasonDesc("演武离线打坐获得经验")
        PRACTICE_OFFLINE_ADD_EXP(90, "演武离线打坐获得经验"),

        @ReasonDesc("累积消耗")
        ACCU_COST_ACTIVITY(91, "累积消耗"),

        @ReasonDesc("消耗钥匙使用礼包")
        COST_KEY_USE_ITEM_GIVE(92, "消耗钥匙使用礼包"),

        @ReasonDesc("交易行卖出物品获得")
        TRADE_REWARD(93, "交易行卖出物品获得"),
        
        @ReasonDesc("酒馆任务奖励")
        PUB_TASK_REWARD(94, "酒馆任务奖励"),
        @ReasonDesc("除暴任务奖励")
		SWEENEY_TASK_REWARD(95, "除暴任务奖励"),
		@ReasonDesc("藏宝图任务奖励")
		TREASURE_MAP_TASK_REWARD(96, "藏宝图任务奖励"),
		@ReasonDesc("护送粮草任务奖励")
		FORAGE_TASK_REWARD(97, "护送粮草任务奖励"),
		@ReasonDesc("帮派任务奖励")
		CORPS_TASK_REWARD(98, "帮派任务奖励"),
		@ReasonDesc("宝石合成失败奖励")
        GEM_SYN_FAIL_REWARD(99, "宝石合成失败奖励"),
        @ReasonDesc("七日登录奖励")
		GA_SEVEN_LOGIN_REWARD(100, "七日登录奖励"),
		@ReasonDesc("等级奖励")
		GA_LEVEL_UP_REWARD(101, "等级奖励"),
				
        @ReasonDesc("签到奖励")
        MONTH_SIGN_REWARD(102, "签到奖励"),
        @ReasonDesc("科举答题")
        EXAM_REWARD(103, "科举答题"),
        @ReasonDesc("采矿奖励")
        MINE_REWARD(104, "采矿奖励"),
        @ReasonDesc("邮件附件")
        MAIL_ATTACHMENT_REWARD(105, "邮件附件"),
        @ReasonDesc("活跃度奖励")
        ACTIVITYUI_REWARD(106, "活跃度奖励"),
        @ReasonDesc("竞技场攻击奖励")
        ARENA_ATTACK(107, "竞技场攻击奖励"),
        @ReasonDesc("竞技场排名奖励")
        ARENA_RANK(108, "竞技场排名奖励"),
        @ReasonDesc("任务奖励")
        QUEST_REWARD(110, "任务奖励"),
        @ReasonDesc("帮派竞赛奖励")
        CORPS_WAR_REWARD(111, "帮派竞赛奖励"),
        @ReasonDesc("绿野仙踪奖励")
        WIZARD_RAID_REWARD(112, "绿野仙踪奖励"),
        @ReasonDesc("打怪胜利奖励")
        WIN_ENEMY_REWARD(114, "打怪胜利奖励"),
        @ReasonDesc("除暴安良特殊奖励")
        SWEENEY_TASK_SPECIAL(115, "除暴安良特殊奖励"),
        @ReasonDesc("NVN月度排名奖励")
        NVN_RANK(116, "NVN月度排名奖励"),
        @ReasonDesc("结婚奖励")
        MARRY_REWARD(117, "结婚奖励"),
        @ReasonDesc("师徒奖励")
        OVERMAN_REWARD(118, "师徒奖励"),
        @ReasonDesc("藏宝图奖励")
        TREASURE_MAP_REWARD(119, "藏宝图奖励"),
        @ReasonDesc("使用礼包道具奖励")
        GIFT_PACK(120, "使用礼包道具奖励"),
        
        @ReasonDesc("vip每日礼包")
        VIP_DAY_REWARD(121, "vip每日礼包"),
        @ReasonDesc("通天塔奖励")
        TOWER_REWARD(122, "通天塔奖励"),
        @ReasonDesc("vip等级奖励")
        VIP_LEVEL_REWARD(123, "vip等级奖励"),
        @ReasonDesc("帮派boss奖励")
        CORPS_BOSS_REWARD(124, "帮派boss奖励"),
        @ReasonDesc("帮派boss排行榜奖励")
        CORPS_BOSS_RANK_REWARD(125, "帮派boss排行榜奖励"),
        @ReasonDesc("帮派boss挑战次数排行榜奖励")
        CORPS_BOSS_COUNT_RANK_REWARD(126, "帮派boss挑战次数排行榜奖励"),
        @ReasonDesc("野外封妖榜奖励")
        SEAL_DEMON_REWARD(127, "野外封妖榜奖励"),
        @ReasonDesc("野外魔王奖励")
        SEAL_DEMON_KING_REWARD(128, "野外魔王奖励"),
        @ReasonDesc("混世魔王奖励")
        DEVIL_INCARNATE_REWARD(129, "混世魔王奖励"),
        @ReasonDesc("限时杀怪奖励")
        TIME_LIMIT_MONSTER_REWARD(130, "限时杀怪奖励"),
        @ReasonDesc("限时挑战npc奖励")
        TIME_LIMIT_NPC_REWARD(131, "限时挑战npc奖励"),
        @ReasonDesc("绿野仙踪BOSS奖励")
        WIZARD_RAID_BOSS_REWARD(132, "绿野仙踪BOSS奖励"),
        @ReasonDesc("七日目标任务奖励")
        DAY7_TARGET_REWARD(133, "七日目标任务奖励"),
        @ReasonDesc("帮派辅助技能奖励")
        CORPS_ASSIST_REWARD(134, "帮派辅助技能奖励"),
        @ReasonDesc("帮派红包奖励")
        CORPS_RED_ENVELOPE_REWARD(135, "帮派红包奖励"),
        @ReasonDesc("剧情副本奖励")
        PLOT_DUNGEON_REWARD(136, "剧情副本奖励"),
        @ReasonDesc("招财进宝奖励")
		GA_BUY_MONEY_REWARD(137, "招财进宝奖励"),
		@ReasonDesc("开服基金奖励")
		GA_LEVEL_MONEY_REWARD(138, "开服基金奖励"),
		@ReasonDesc("限时累计充值奖励（精彩活动）")
        GA_NORMAL_TOTAL_CHARGE(139, "限时累计充值奖励（精彩活动）"),
        @ReasonDesc("每日累计充值奖励（精彩活动）")
		GA_DAY_TOTAL_CHARGE(140, "每日累计充值奖励（精彩活动）"),
        @ReasonDesc("一元购类型奖励（精彩活动）")
		GA_TOTAL_CHARGE_BUY(141, "一元购类型奖励（精彩活动）"),
		@ReasonDesc("围剿魔族普通奖励")
        SIEGE_DEMON_NORMAL_REWARD(142, "围剿魔族普通奖励"),
        @ReasonDesc("围剿魔族困难奖励")
        SIEGE_DEMON_HARD_REWARD(143, "围剿魔族困难奖励"),
		
		
        ;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private PetExpLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    /**
     * Gm命令日志原因
     */
    @LogDesc(desc = "使用GM命令")
    public enum GmCommandLogReason implements ILogReason {
        /**
         * 非法使用GM命令
         */
        @ReasonDesc("非法使用GM命令")
        REASON_INVALID_USE_GMCMD(0, ""),
        /**
         * 合法使用GM命令
         */
        @ReasonDesc("合法使用GM命令")
        REASON_VALID_USE_GMCMD(1, ""),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private GmCommandLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    /**
     * 在线日志原因
     */
    @LogDesc(desc = "玩家在线时长")
    public enum OnlineTimeLogReason implements ILogReason {
        /**
         * 无意义
         */
        @ReasonDesc("无意义")
        DEFAULT(0, ""),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private OnlineTimeLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    /**
     * 充值日志产生原因
     */
    @LogDesc(desc = "充值")
    public enum ChargeLogReason implements ILogReason {

        @ReasonDesc("充值成功")
        CHARGE_DIAMOND_SUCCESS(1, ""),
        @ReasonDesc("IPHONE直冲成功,使用直冲接口")
        CHARGE_IPHONE_DIAMOND_SUCCESS(2, ""),
        @ReasonDesc("IPAD直冲成功,使用直冲接口")
        CHARGE_IPAD_DIAMOND_SUCCESS(3, ""),
        //XXX 直冲接口
        @ReasonDesc("Android直冲")
        ANDROID_RECHARGE_SUCCESS(4, ""),
        @ReasonDesc("IOS直冲")
        IOS_RECHARGE_SUCCESS(5, ""),
        @ReasonDesc("PC直冲")
        PC_RECHARGE_SUCCESS(6, ""),
        @ReasonDesc("其他直冲")
        OTHER_RECHARGE_SUCCESS(7, ""),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ChargeLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    @LogDesc(desc = "发送邮件")
    public enum MailLogReason implements ILogReason {
        @ReasonDesc("收件箱邮件到期删除")
        INBOX_EXPIRED_DELETE(1, "收件箱邮件到期删除"),
        @ReasonDesc("发件箱邮件到期删除")
        SENDEDBOX_EXPIRED_DELETE(2, "发件箱邮件到期删除"),
        @ReasonDesc("收件箱已满时删除最早的没有附件的邮件")
        INBOX_DELETE_ON_FULL(3, "收件箱已满时删除最早的没有附件的邮件"),
        @ReasonDesc("收件箱全都有附件时本封邮件没有附件被删除")
        INBOX_DELETE_ON_FULL_ALL_HAS_ATTACHMENT(4, "收件箱全都有附件时本封邮件没有附件被删除"),
        @ReasonDesc("收件箱全都有附件时删除最早的一封")
        INBOX_DELETE_BY_TIME_ON_FULL(5, "收件箱全都有附件时删除最早的一封"),
        @ReasonDesc("发件箱已满时删除最早的一封")
        SENDEDBOX_DELETE_BY_TIME_ON_FULL(6, "发件箱已满时删除最早的一封"),
        @ReasonDesc("保存箱已满时删除最早的一封")
        SAVEBOX_DELETE_BY_TIME_ON_FULL(7, "保存箱已满时删除最早的一封"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private MailLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    @LogDesc(desc = "vip")
    public enum VipLogReason implements ILogReason {
        @ReasonDesc("玩家登陆")
        LOGIN(0, "玩家登陆"),
        @ReasonDesc("玩家充值")
        CHARGE(1, "玩家充值"),
        @ReasonDesc("心跳检测状态改变")
        HEAR_BEAT(2, "心跳检测状态改变"),
        @ReasonDesc("零点刷新状态改变")
        FLUSH_ON_ZERO(3, "零点刷新状态改变"),
        @ReasonDesc("领取每日奖励")
        RECEIVE_ONCE_REWARD(4, "领取每日奖励"),
        @ReasonDesc("使用或购买VIP卡")
        USE_CARD(5, "使用或购买VIP卡"),
        @ReasonDesc("首次领取")
        FIRST_RECEIVE(6, "首次领取"),
        @ReasonDesc("GM增加经验")
        GM_CHARGE(7, "GM增加经验"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private VipLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "行为日志")
    public enum BehaviorLogReason implements ILogReason {
        @ReasonDesc("用户执行操作")
        DO_BEHAVIOR(0, "用户执行操作"),
        @ReasonDesc("增加附加操作次数")
        ADD_OP_ADD_COUNT(1, "增加附加操作次数"),
        @ReasonDesc("qq数据变更")
        QQ_DATA_CHANG(2, "qq数据变更"),
        @ReasonDesc("被邀请登录")
        QQ_BEINVITED_LOGIN(3, "被邀请登录"),
        @ReasonDesc("用户执行操作")
        DO_BEHAVIOR_MULTIPLE(4, "用户执行多次重复操作"),;


        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private BehaviorLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "掉落")
    public enum DropItemLogReason implements ILogReason {
        @ReasonDesc("掉落道具")
        GET_DROP_ITEM(0, "掉落道具"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private DropItemLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }
    }

    /**
     * 系统错误（Exception）日志产生原因
     * <p>
     * iTermiantor 2011-10-02
     */
    @LogDesc(desc = "Exception")
    public enum ExceptionLogReason implements ILogReason {

        @ReasonDesc("系统忽略错误")
        DEFAULT_EXCEPTION(1, ""), @ReasonDesc("系统不可忽略错误")
        DEFAULT_ERROR(2, "");

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ExceptionLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    @LogDesc(desc = "竞技场")
    public enum ArenaLogReason implements ILogReason {
        /**
         * 名次改变
         */
        @ReasonDesc("竞技场挑战")
        RANK_CHANGE(1, "竞技场挑战"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ArenaLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "战斗结果日志")
    public enum BattleResultLogReason implements ILogReason {
        /**
         * 记录战斗情况
         */
        @ReasonDesc("记录战斗结果")
        BATTLE_RESULT(1, "记录战斗结果"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private BattleResultLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }
    }

    /**
     * 任务日志产生原因
     */
    @LogDesc(desc = "任务")
    public enum TaskLogReason implements ILogReason {
        /**
         * 领取任务
         */
        @ReasonDesc("领取任务")
        REASON_TASK_ACCEPT(0, "任务Id={0,number,#}|任务名称={1}|最低接受等级={2}"),
        /**
         * 放弃任务
         */
        @ReasonDesc("放弃任务")
        REASON_TASK_GIVEUP(1, "任务Id={0,number,#}|任务名称={1}|最低接受等级={2}"),
        /**
         * 完成任务
         */
        @ReasonDesc("完成任务")
        REASON_TASK_FINISH(2, "任务Id={0,number,#}|任务名称={1}|最低接受等级={2}"),
        /**
         * 删除已完成任务
         */
        @ReasonDesc("删除已完成任务")
        REASON_TASK_FINISH_DELETE(3, ""),
        /**
         * 删除正执行任务
         */
        @ReasonDesc("删除正执行任务")
        REASON_TASK_DOING_DELETE(4, "");

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private TaskLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    @LogDesc(desc = "校场")
    public enum DrillGroundLogReason implements ILogReason {
        @ReasonDesc("校场购买物品")
        DG_BUY_ITEM(1, "校场购买物品,pageId = {0}, itemTempId = {1}, num = {2}, cost = {3}"),
        @ReasonDesc("领取完胜奖励")
        RECEIVE_PERFECT_REWARD(2, "领取首次完胜奖励, petTempId = {0}, currencyType = {1}, num = {2}"),
        @ReasonDesc("武将招募")
        HIRE_PET(3, "武将招募， 消耗currencyType = {0}, num = {1}, petTempId = {2}, petId = {3}"),
        @ReasonDesc("普通挑战")
        NORMAL_CHALLENGE(4, "普通挑战, 消耗 currencyType = {0}, num = {1}, petTempId = {2}"),
        @ReasonDesc("高级挑战")
        HIGH_LEVEL_CHALLENGE(5, "高级挑战, 消耗 currencyType = {0}, num = {1}, petTempId = {2}"),
        @ReasonDesc("一键高级挑战")
        AOTU_HIGH_LEVEL_CHALLENGE(6, "一键高级挑战，消耗 currencyType = {0}, num = {1}；奖励  = {2}"),
        @ReasonDesc("一键必胜高级挑战")
        AOTU_WIN_HIGH_LEVEL_CHALLENGE(7, "一键必胜高级挑战，点将消耗 currencyType = {0}, num = {1}；奖励 = {4}"),
        @ReasonDesc("进行游戏")
        START_GAME(8, "进行游戏, 玩家战术选择 = {0}, 游戏结果  = {1}, 奖励 = {2}"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private DrillGroundLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "布阵")
    public enum FormationLogReason implements ILogReason {
        @ReasonDesc("武将下阵")
        PET_XIAOZHEN(1, "武将下阵，PetID = {0}"),
        @ReasonDesc("武将上阵")
        PET_SHANGZHEN(2, "武将上阵，上阵petId = {0}，目标位置petId = {1}"),
        @ReasonDesc("阵内交换")
        PET_EXCHANGE(3, "阵内交换，源petId = {0}, position = {1}, 目标  position = {2}"),
        @ReasonDesc("阵内交换")
        PET_FIRE(4, "武将解雇，petId = {0}"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private FormationLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "关卡")
    public enum MissionLogReason implements ILogReason {
        @ReasonDesc("进入关卡")
        ENTER_MISSION(1, "进入关卡"),
        @ReasonDesc("离开关卡")
        LEAVE_MISSION(2, "离开关卡"),
        @ReasonDesc("攻击关卡敌人")
        ATTACK_ENEMY_ARMY(3, "攻击关卡敌人"),
        @ReasonDesc("领取关卡通关奖励")
        GET_MISSION_REWARD(4, "领取关卡通关奖励"),
        @ReasonDesc("攻击关卡敌人结果")
        ATTACK_ENEMY_ARMY_RESULT(5, "攻击关卡敌人结果"),

        @ReasonDesc("关卡开始挂机")
        START_CLEAN_MISSION(10, "关卡开始挂机"),
        @ReasonDesc("关卡立即完成挂机")
        FINISH_CLEAN_MISSION(11, "关卡立即完成挂机"),
        @ReasonDesc("关卡停止挂机")
        STOP_CLEAN_MISSION(12, "关卡停止挂机"),
        @ReasonDesc("检查需要完成的挂机")
        CHECK_CLEAN_MISSION(13, "检查需要完成的挂机"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private MissionLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "副本")
    public enum RaidLogReason implements ILogReason {
        @ReasonDesc("进入副本")
        ENTER_RAID(1, "进入副本"),
        @ReasonDesc("离开副本")
        LEAVE_RAID(2, "离开副本"),
        @ReasonDesc("攻击副本敌人")
        ATTACK_ENEMY_ARMY(3, "攻击副本敌人"),
        @ReasonDesc("领取副本通关奖励")
        GET_RAID_REWARD(4, "领取副本通关奖励"),
        @ReasonDesc("攻击副本敌人结果")
        ATTACK_ENEMY_ARMY_RESULT(5, "攻击副本敌人结果"),
        @ReasonDesc("重置副本增加次数")
        RAID_ADD_ENTER_TIMES(6, "重置副本增加次数"),
        @ReasonDesc("查看副本宝箱")
        RAID_WATCH_BONUS_BOX(7, "查看副本宝箱"),
        @ReasonDesc("击败副本中的敌人")
        RAID_DEFEATE_ENEMY(8, "击败副本中的敌人"),

        @ReasonDesc("副本开始挂机")
        START_CLEAN_RAID(10, "副本开始挂机"),
        @ReasonDesc("副本立即完成挂机")
        FINISH_CLEAN_RAID(11, "副本立即完成挂机"),
        @ReasonDesc("副本停止挂机")
        STOP_CLEAN_RAID(12, "副本停止挂机"),
        @ReasonDesc("检查需要完成的挂机")
        CHECK_CLEAN_RAID(13, "检查需要完成的挂机"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private RaidLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "摇钱树日志")
    public enum MoneyTreeLogReason implements ILogReason {
        @ReasonDesc("给自己浇水")
        WATER_SELF(1, "给自己浇水"),
        @ReasonDesc("给好友浇水")
        WATER_FRIEND(2, "给好友浇水"),
        @ReasonDesc("批量给好友浇水")
        WATER_FRIEND_BATCH(3, "批量给好友浇水"),
        @ReasonDesc("摇钱树增加经验")
        ADD_EXP(4, "摇钱树增加经验"),
        @ReasonDesc("摇钱树增加金钱果")
        ADD_LEVELUP_BONUS(5, "摇钱树增加金钱果"),
        @ReasonDesc("摇钱树拾取金钱果")
        GIVE_LEVELUP_BONUS(6, "摇钱树拾取金钱果"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private MoneyTreeLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "斗地主日志")
    public enum LandlordLogReason implements ILogReason {
        @ReasonDesc("斗地主抓捕进行战斗")
        GO_CATCH(1, "斗地主抓捕进行战斗"),
        @ReasonDesc("斗地主抓捕战斗结束")
        CATCH_FIGHT_END(2, "斗地主抓捕战斗结束"),
        @ReasonDesc("地主奴隶被抢")
        MASTER_LOST_SLVAER_CATCH(3, "地主奴隶被抢"),
        @ReasonDesc("解救奴隶")
        HELP_FREE_SLAVER(4, "解救奴隶"),
        @ReasonDesc("解救奴隶战斗结束")
        HELP_FREE_SLAVER_FIGHT_END(5, "解救奴隶战斗结束"),
        @ReasonDesc("互动")
        INTERACTION(6, "互动"),
        @ReasonDesc("压榨")
        SQUEEZE(7, "压榨"),
        @ReasonDesc("玩家主动提取经验")
        WITHDRAW(8, "玩家主动提取经验"),
        @ReasonDesc("提取经验")
        WITHDRAW_EXP(9, "提取经验"),
        @ReasonDesc("奴隶反抗")
        RESIST(10, "奴隶反抗"),
        @ReasonDesc("奴隶反抗战斗结束")
        RESIST_FIGHT_END(11, "奴隶反抗战斗结束"),
        @ReasonDesc("奴隶求救")
        HELPME(12, "奴隶求救"),
        @ReasonDesc("奴隶求救战斗结束")
        HELPME_FIGHT_END(13, "奴隶求救战斗结束"),
        @ReasonDesc("释放奴隶")
        FREE_SLAVER(14, "释放奴隶"),
        @ReasonDesc("到时间自动释放奴隶")
        FREE_SLAVER_AUTO(15, "到时间自动释放奴隶"),
        @ReasonDesc("失去奴隶")
        LOST_SLAVER(16, "失去奴隶"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private LandlordLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "过关斩将")
    public enum HeroMissionLogReason implements ILogReason {
        @ReasonDesc("进入关卡")
        ENTER_MISSION(1, "进入关卡"),
        @ReasonDesc("离开关卡")
        LEAVE_MISSION(2, "离开关卡"),
        @ReasonDesc("攻击关卡")
        ATTACK_MISSION(3, "攻击关卡"),
        @ReasonDesc("攻击关卡结果")
        ATTACK_MISSION_RESULT(5, "攻击关卡结果"),

        @ReasonDesc("重置关卡")
        RESET_MISSION(6, "重置关卡"),
        @ReasonDesc("重置章节")
        RESET_STAGE(7, "重置章节"),

        @ReasonDesc("攻击试剑塔")
        SWORD_TOWER_ATTACK(10, "攻击试剑塔"),
        @ReasonDesc("攻击试剑塔结果")
        SWORD_TOWER_ATTACK_RESULT(11, "攻击试剑塔结果"),


        @ReasonDesc("经典战役打怪物")
        CLASSIC_BATTLE_ATTACK(12, "攻击试剑塔"),
        @ReasonDesc("攻击试剑塔结果")
        CLASSIC_BATTLE_ATTACK_RESULT(13, "攻击试剑塔结果"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private HeroMissionLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "装备日志")
    public enum EquipLogReason implements ILogReason {
        @ReasonDesc("装备位升星")
        STAR_UP(1, "装备位升星"),
        @ReasonDesc("装备重铸")
        EQUIP_RECAST(2, "装备重铸"),
        @ReasonDesc("装备洗练")
        EQUIP_REFINERY(3, "装备洗练"),

        ;
        
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private EquipLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "宝石日志")
    public enum GemLogReason implements ILogReason {
        @ReasonDesc("进入关卡")
        ENTER_MISSION(1, "进入关卡"),
        @ReasonDesc("离开关卡")
        LEAVE_MISSION(2, "离开关卡"),
        @ReasonDesc("攻击关卡")
        ATTACK_MISSION(3, "攻击关卡"),
        @ReasonDesc("攻击关卡结果")
        ATTACK_MISSION_RESULT(5, "攻击关卡结果"),

        @ReasonDesc("重置关卡")
        RESET_MISSION(6, "重置关卡"),
        @ReasonDesc("重置章节")
        RESET_STAGE(7, "重置章节"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private GemLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "宝物日志")
    public enum TreasureLogReason implements ILogReason {
        @ReasonDesc("宝物升星扣除物品失败")
        UPSTAR_COST_ITEM_FAIL(1, "宝物升星扣除物品失败, 是否金币升星 = {0}, itemId = {1}, num = {2}"),
        @ReasonDesc("宝物升星扣除升星符失败")
        UPSTAR_COST_RUNIC_FAIL(2, "宝物升星扣除物品失败， 是否金币升星 = {0}, 已扣除物品 itemId = {1}, num = {2}， 扣除失败 itemId = {3}, num = {4}"),
        @ReasonDesc("宝物升星扣除货币失败")
        UPSTAR_COST_CURRENCY_FAIL(3, "宝物升星扣除物品失败， 是否金币升星 = {0}, 已扣除物品 itemId = {1}, num = {2}| itemId = {3}, num = {4}, 扣除失败 currtypeId = {5}, num = {6}"),
        @ReasonDesc("普通宝物升星成功")
        NORMAL_UPSTAR_SUCC(4, "普通宝物升星成功"),
        @ReasonDesc("普通升星成功")
        GOLD_UPSTAR_SUCC(5, "金币升星成功"),
        @ReasonDesc("宝物转换扣除原始物品失败")
        CONVERT_COST_ITEM_FAIL(6, "扣除原始物品失败 ,已扣除 itemId = {0}, num = {1} 扣除失败 itemid = {2}, num = {3}"),
        @ReasonDesc("宝物转换成功")
        CONVERT_SUCC(7, "宝物转换成功 ，转换后tempId = {0}"),
        @ReasonDesc("宝物升阶扣除原始物品失败")
        UPGRADE_COST_ITEM_FAIL(8, "扣除物品失败 itemId = {0}, num = {1}"),
        @ReasonDesc("宝物升阶扣除货币失败")
        UPGRADE_COST_CURRENCY_FAIL(9, "扣除货币失败 currencyId = {0}, num = {1}"),
        @ReasonDesc("宝物升阶后物品不为宝物")
        UPGRADE_ITEM_IS_NOT_TREASURE(10, "宝物升阶后物品不为宝物, itemId = {0}"),
        @ReasonDesc("宝物升阶成功")
        UPGRADE_SUCC(11, "宝物升阶成功, 升阶后id = {0}"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private TreasureLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "领地日志")
    public enum LandLogReason implements ILogReason {
        @ReasonDesc("开始生产")
        GEN_PRODUCT(1, "开始生产"),
        @ReasonDesc("领取生产奖励")
        GIVE_PRODUCT(2, "领取生产奖励"),
        @ReasonDesc("刷新品阶")
        REFRESH_STEP(3, "刷新品阶"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private LandLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "目标任务日志")
    public enum StepTaskLogReason implements ILogReason {
        @ReasonDesc("领取任务奖励")
        GIVE_TASK_REWARD(1, "领取任务奖励"),
        @ReasonDesc("领取阶段奖励")
        GIVE_STEP_REWARD(2, "领取阶段奖励"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private StepTaskLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "内政任务日志")
    public enum PassTaskLogReason implements ILogReason {
        @ReasonDesc("接受任务-旧任务数据记录")
        ACCEPT_TASK_OLD_INFO(1, "接受任务-旧任务数据记录"),
        @ReasonDesc("投掷骰子")
        ROLL_DICE(2, "投掷骰子"),
        @ReasonDesc("放弃任务")
        GIVEUP(3, "放弃任务"),
        @ReasonDesc("完成任务")
        FINISH(4, "完成任务"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private PassTaskLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "奖励")
    public enum PrizeLogReason implements ILogReason {
        /**
         * 奖励成功
         */
        @ReasonDesc("奖励成功")
        PRIZE_SUCCESS(0, ""),
        /**
         * 奖励失败,取平台后奖励条件不满足
         */
        @ReasonDesc("奖励失败,取平台后奖励条件不满足")
        PRIZE_FAIL_CONDITION_AFTER_UNMEET(1, ""),
        /**
         * 补偿失败,奖励条件不满足,已扣取
         */
        @ReasonDesc("补偿失败,奖励条件不满足,已扣取")
        PRIZE_FAIL_USER_PRIZE_AFTER_UNMEET(2, ""),
        /**
         * 奖励失败,状态被打断
         */
        @ReasonDesc("奖励失败,状态被打断")
        PRIZE_FAIL_GET_PRIZE_STATE_EXIT(3, ""),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private PrizeLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    @LogDesc(desc = "内政任务日志")
    public enum GodHeroLogReason implements ILogReason {
        @ReasonDesc("神将移动")
        MOVE(1, "fromUUID = {0}, fromBagId = {1}, fromIndex = {2}, toBagId = {3}, toIndex = {4}"),
        @ReasonDesc("吞噬")
        TRAIN(2, "吞噬者 UUID = {0}， 吞噬者品质 = {1}, 被吞噬者UUID = {2}， 被吞噬者品质= {3}"),
        @ReasonDesc("吞噬")
        AOTU_TRAIN(3, "吞噬者 UUID = {0}，被吞噬列表 = {1}"),
        @ReasonDesc("点将")
        ROLL_GOD_HERO(4, "点将类型 = {0}, 点将结果 = {1}"),
        @ReasonDesc("收将")
        COLLECT_GOD_HERO(5, "收将列表 = {0}"),
        @ReasonDesc("元宝培养")
        BOND_TRAIN(6, "元宝培养 UUID = {0}, 培养前级别 = {1}, 培养前经验 = {2}, 升级所需经验 = {3}, 元宝消耗 = {4}"),
        @ReasonDesc("购买神将")
        BUY_GOD_HERO(7, "购买神将 godHeroId = {0}, currencyType = {1}, num = {2}"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private GodHeroLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "神秘商店日志")
    public enum MysteryShopLogReason implements ILogReason {
        @ReasonDesc("神秘商店功能开启")
        FUNC_OPEN(1, "神秘商店功能开启"),
        @ReasonDesc("免费刷新")
        FREE_FLUSH(2, "免费刷新"),
        @ReasonDesc("珍宝票刷新")
        TREASURE_NOTE_FLUSH(3, "珍宝票刷新，itemId = {0}, num = {1}"),
        @ReasonDesc("元宝刷新")
        BOND_FLUSH(4, "元宝刷新, num = {0}"),
        @ReasonDesc("VIP刷新")
        VIP_FLUSH(5, "VIP刷新 num = {0}"),
        @ReasonDesc("购买神秘商店物品")
        BUY_ITEM(6, "购买神秘商店物品 currencyTypeId = {0}, currencyNum = {1}, msItemId = {2}, itemid = {3}, itemNum = {4}"),
        @ReasonDesc("过时刷新")
        FLUSH_CD_OVER(7, "过时刷新"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private MysteryShopLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "坐骑日志")
    public enum HorseLogReason implements ILogReason {
        @ReasonDesc("单次培养")
        SINGLE_TRAIN(1, "单次培养，暴击情况 ：{0}"),
        @ReasonDesc("批量培养")
        BATCH_TRAIN(2, "总次数 = {0},总经验 = {1} 大暴击 = {2}, 小暴击 = {3}"),
        @ReasonDesc("清除摇动技能室盒CD")
        KILL_ROLL_SKILL_CD(3, "清除摇动技能室盒CD"),
        @ReasonDesc("普通拉杆")
        NORMAL_DRAW_BAR(4, "普通拉杆，暴击情况{0}"),
        @ReasonDesc("幸运连珠")
        LUCKY_LIANZHU(5, "幸运连珠"),
        @ReasonDesc("技能升级按钮状态刷新")
        FLUSH_MENU_STATE(6, "技能升级按钮状态刷新,技能升级次数重置, 触发原因 = {0}"),
        @ReasonDesc("骑乘")
        RIDING(7, "骑乘"),
        @ReasonDesc("休息")
        REST(8, "休息"),
        @ReasonDesc("获取活动马")
        HORSE_GIVE_ACTIVITY(9, "获取活动马  id = {0}"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private HorseLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "商城日志")
    public enum MallLogReason implements ILogReason {
        @ReasonDesc("GM 修改初始数据")
        GM_CHANGE_INIT(1, "GM 修改初始数据"),
        @ReasonDesc("GM 修改，刷新后数据")
        GM_CHANGE_AFTER_FLUSH(2, "GM 修改，刷新后数据"),
        @ReasonDesc("购买普通物品")
        BUY_NORMAL_ITEM(3, "购买普通物品,currencyType = {0} , currencyNum = {1} , suitNum = {2}, mallItemId = {3}, itemId = {4}, itemNum = {5}"),
        @ReasonDesc("购买限时物品")
        BUY_TIME_LIMIT_ITEM(4, "购买限时物品, currencyType = {0} , currencyNum = {1} , suitNum = {2}, mallItemId = {3}, itemId = {4}, itemNum = {5}， 玩家购买情况 = {6}"),
        @ReasonDesc("商城状态刷新")
        FLUSH_MALL(5, "商城状态刷新"),
        @ReasonDesc("服务器启动后")
        SERVER_INIT(6, "服务器启动后"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private MallLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    /**
     * 财务汇报record修改log
     */
    @LogDesc(desc = "财务汇报record修改log")
    public enum ItemCostRecordLogReason implements ILogReason {
        @ReasonDesc("财务汇报record增加记录")
        MODIFY_ADD_RECORD(1, "财务汇报增加记录"),
        @ReasonDesc("财务汇报record减少记录")
        MODIFY_REDUCE_RECORD(2, "财务汇报增加记录"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ItemCostRecordLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    @LogDesc(desc = "军衔log")
    public enum ArmyTitleLogReason implements ILogReason {

        @ReasonDesc("军衔增加记录")
        MODIFY_ARMY_TITLE_RECORD(1, "军衔增加记录"),
        @ReasonDesc("军衔天赋升级记录")
        MODIFY_ARMY_TITLE_TALENT_RECORD(2, "军衔天赋升级记录"),
        @ReasonDesc("领取军衔俸禄记录")
        MODIFY_ARMY_TITLE_TAKE_SALARY_RECORD(3, "领取军衔俸禄记录"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ArmyTitleLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    @LogDesc(desc = "小助手log")
    public enum PopTipsLogReason implements ILogReason {

        @ReasonDesc("武将技能记录")
        MODIFY_POP_TIP_PET_SKILL_CHANGE(1, "武将技能记录"),
        @ReasonDesc("武将上阵记录")
        MODIFY_POP_TIP_PET_ON_BATTLE_CHANGE(2, "武将上阵记录"),
        @ReasonDesc("心法升级记录")
        MODIFY_POP_TIP_MIND_UPGRADE_CHANGE(3, "心法升级记录"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private PopTipsLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return this.reason;
        }

        @Override
        public String getReasonText() {
            return this.reasonText;
        }
    }

    @LogDesc(desc = "精彩活动日志")
    public enum GoodActivityLogReason implements ILogReason {
        @ReasonDesc("玩家领取奖励")
        GIVE_BONUS(1, "玩家领取奖励"),
        @ReasonDesc("玩家活动数据删除")
        USER_DATE_DEL(2, "玩家活动数据删除"),

        @ReasonDesc("活动结束，从map中删除")
        ACTIVITY_END(3, "活动结束，从map中删除"),

        @ReasonDesc("给奖励")
        GIVE_REWARD(4, "给奖励"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private GoodActivityLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "献计日志")
    public enum LandOfferAdviceLogReason implements ILogReason {
        @ReasonDesc("玩家献计")
        OFFER_ADVICE(1, "玩家献计"),
        @ReasonDesc("主人领取献计奖励")
        OWNER_GET_REWARD(2, "主人领取献计奖励"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private LandOfferAdviceLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "用餐日志")
    public enum BunLogReason implements ILogReason {
        @ReasonDesc("用餐奖励体力")
        BUN_EAT_REWARD_POWER(1, "用餐奖励体力"),
        @ReasonDesc("用餐御射奖励")
        BUN_ROLL_REWARD_POWER(2, "用餐御射奖励"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private BunLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "每日必做日志")
    public enum EveryDayTargetLogReason implements ILogReason {
        @ReasonDesc("每日必做完成目标日志")
        EVERY_DAY_TARGET_DO_TARGET(1, "每日必做完成目标日志"),
        @ReasonDesc("每日必做领取活跃奖励")
        EVERY_DAY_TARGET_TAKE_TARGET(2, "每日必做领取活跃奖励"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private EveryDayTargetLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "钱庄日志")
    public enum BankLogReason implements ILogReason {
        @ReasonDesc("钱庄周卡购买日志")
        BANK_WEEK_BUY(1, "钱庄开始周卡购买日志"),
        @ReasonDesc("钱庄周卡领取日志")
        BANK_WEEK_TAKEN(2, "钱庄开始周卡领取日志"),
        @ReasonDesc("钱庄升级购买日志")
        BANK_LEVEL_UP_BUY(3, "钱庄升级购买日志"),
        @ReasonDesc("钱庄升级领取日志")
        BANK_LEVEL_UP_TAKEN(4, "钱庄升级领取日志"),
        @ReasonDesc("钱庄再次升级购买日志")
        BANK_LEVEL_UP_SECOND_BUY(5, "钱庄再次升级购买日志"),
        @ReasonDesc("钱庄升级不领日志")
        BANK_LEVEL_UP_SECOND_TAKEN(6, "钱庄升级不领日志"),
        @ReasonDesc("周卡钱庄过期日志")
        BANK_WEEK_OVERDUE_TAKEN(7, "周卡钱庄过期日志"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private BankLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "战甲日志")
    public enum ArmourLogReason implements ILogReason {
        @ReasonDesc("战甲强化日志")
        ARMOUR_ENHANCE_LEVEL(1, "战甲强化日志"),
        @ReasonDesc("战甲套装日志")
        ARMOUR_SUIT(2, "战甲套装日志"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ArmourLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "卡牌活动日志")
    public enum CardLogReason implements ILogReason {

        @ReasonDesc("卡牌-兑换奖励")
        EXCHANGE(1, "卡牌-兑换奖励"),

        @ReasonDesc("卡牌-抽卡")
        DRAW(2, "卡牌-抽卡"),

        @ReasonDesc("卡牌-用点数买卡")
        BUY(3, "卡牌-用点数买卡"),

        @ReasonDesc("卡牌-卖卡")
        SELL(4, "卡牌-卖卡"),

        @ReasonDesc("卡牌-领取排行奖励")
        GIVE_RANK_REWARD(5, "卡牌-领取排行奖励"),

        @ReasonDesc("卡牌-发邮件奖励")
        SEND_MAIL_RANK_REWARD(6, "卡牌-发邮件奖励"),

        @ReasonDesc("卡牌-产生日排行")
        GEN_DAY_RANK(10, "卡牌-产生日排行"),

        @ReasonDesc("卡牌-产生累计排行")
        GEN_FINAL_RANK(11, "卡牌-产生累计排行"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private CardLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "宝石迷阵日志")
    public enum GemMazeLogReason implements ILogReason {

        @ReasonDesc("零点恢复宝石迷阵精力")
        GEM_MAZE_0_CLOCK_RECOVER_ENERGY(1, "零点恢复宝石迷阵精力"),

        @ReasonDesc("移动宝石消耗精力")
        GEM_MAZE_MOVE_CONSUME_ENERGY(2, "移动宝石消耗精力"),

        @ReasonDesc("购买宝石精力")
        GEM_MAZE_BUY_ENERGY(3, "购买宝石精力"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private GemMazeLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "兑换商城日志")
    public enum ConvertMallLogReason implements ILogReason {

        @ReasonDesc("兑换商城购买消耗")
        CONVERT_MALL_BUY_CONSUME(1, "兑换商城购买消耗"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ConvertMallLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "登陆日志")
    public enum LoginLogReason implements ILogReason {
        @ReasonDesc("登陆")
        LOGIN(1, "登陆"),
        @ReasonDesc("登出")
        LOGOUT(2, "登出"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private LoginLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }

    }


    @LogDesc(desc = "环任务日志")
    public enum LoopTaskLogReason implements ILogReason {

        @ReasonDesc("环任务接取")
        LOOP_TASK_ACCEPT(1, "环任务接取"),

        @ReasonDesc("环任务完成")
        LOOP_TASK_FINISH(2, "环任务完成"),

        @ReasonDesc("立即完成单环任务")
        LOOP_TASK_FINISH_ONE(3, "立即完成单环任务"),

        @ReasonDesc("完成所有剩余环任务")
        LOOP_TASK_FINISH_ALL(4, "完成所有剩余环任务"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private LoopTaskLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "每日首充日志")
    public enum EverydayChargeLogReason implements ILogReason {

        @ReasonDesc("领取每日首充奖励")
        EVERYDAY_CHARGE_GIFT_TAKE(1, "领取每日首充奖励"),

        @ReasonDesc("每日首充过期发邮件")
        EVERYDAY_CHARGE_GIFT_MAIL(2, "每日首充过期发邮件"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private EverydayChargeLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "赤壁渡江日志")
    public enum EscortLogReason implements ILogReason {
        @ReasonDesc("开始渡江")
        START_ESCORT(1, "开始渡江"),
        @ReasonDesc("免费刷新船只")
        FLUSH_SHIP(2, "免费刷新船只"),
        @ReasonDesc("物品刷新船只")
        ITEM_FLUSH_SHIP(3, "物品刷新船只"),
        @ReasonDesc("付费刷新船只")
        BOND_FLUSH_SHIP(4, "付费刷新船只"),
        @ReasonDesc("元宝鼓舞")
        BOND_ENCOURAGE(5, "元宝鼓舞"),
        @ReasonDesc("免费占卜")
        FREE_DEVINE(6, "免费占卜"),
        @ReasonDesc("付费占卜")
        BOND_DEVINE(7, "付费占卜"),
        @ReasonDesc("直接购买")
        DIRECT_BUY(8, "直接购买"),
        @ReasonDesc("物品直接购买")
        ITEM_DIRECT_BUY(9, "物品直接购买"),
        @ReasonDesc("取消所有邀请")
        CANCEL_ALL_INVITE(10, "取消所有邀请"),
        @ReasonDesc("借东风: 开启者ID = {0}")
        GLOBAL_ENCOURAGE(11, "借东风: 开启者ID = {0}"),
        @ReasonDesc("清除抢夺CD")
        KILL_ATTACK_CD(12, "清除抢夺CD"),
        @ReasonDesc("冲刺十分钟")
        SPRINT(13, "冲刺十分钟"),
        @ReasonDesc("立即结束")
        IMME_COMPLETE(14, "立即结束"),
        @ReasonDesc("领取排行奖励")
        RECEIVE_RANK_REWARD(15, "领取排行奖励"),
        @ReasonDesc("购买抢夺次数")
        BUY_ATTACK_NUM(16, "购买抢夺次数"),
        @ReasonDesc("抢夺船只")
        ATTACK(17, "抢夺船只:攻击者={0}, 被攻击者={1}, 结果={2}"),
        @ReasonDesc("邀请好友")
        INVITE(18, "邀请好友"),
        @ReasonDesc("邀请结果")
        INVITE_RESULT(19, "邀请结果:邀请人={0}, 结果={2}"),
        @ReasonDesc("零点排行")
        FLUSH_RANK_ZERO(20, "零点排行"),
        @ReasonDesc("航行结束")
        END(21, "航行结束"),
        @ReasonDesc("借东风结束")
        GLOBAL_ENCOURAGE_END(22, "借东风结束"),
        @ReasonDesc("抢夺收益 ")
        ATTACK_INCOME(23, "抢夺收益 : attackId = {0}, targetId = {1}, income = {2}"),
        @ReasonDesc("抢夺损失")
        ATTACKED_LOSE(24, "抢夺损失 : attackId = {0}, targetId = {1}, lose income = {2}"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private EscortLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "饰品日志")
    public enum AccessoryLogReason implements ILogReason {
        @ReasonDesc("立即强化")
        IMME_ENHANCE(1, "立即强化：物品：{0}, 消耗货币：{1}, 替代货币：类型 = {2}, 数量 = {3}"),
        @ReasonDesc("普通强化")
        NORMAL_ENHANCE(2, "普通强化：物品：{0}， 消耗货币：{0}"),
        @ReasonDesc("饰品升阶")
        UPGRADE(3, "饰品升阶：升阶前 = {0}，升阶后 = {1}"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private AccessoryLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "经典战役日志")
    public enum ClassicBattleLogReason implements ILogReason {

        @ReasonDesc("创建经典战役大地图关卡")
        CLASSIC_BATTLE_CREATE(1, "创建经典战役大地图关卡"),

        @ReasonDesc("进入经典战役大地图关卡")
        CLASSIC_BATTLE_ENTER(2, "进入经典战役大地图关卡"),

        @ReasonDesc("离开经典战役大地图关卡")
        CLASSIC_BATTLE_LEAVE(3, "离开经典战役大地图关卡"),

        @ReasonDesc("攻击关卡")
        CLASSIC_BATTLE_FIGHT_PASS(4, "攻击关卡"),

        @ReasonDesc("查看奖励")
        CLASSIC_BATTLE_WATCH_BOX(5, "查看奖励"),

        @ReasonDesc("打开宝箱")
        CLASSIC_BATTLE_OPEN_BOX(6, "打开宝箱"),

        @ReasonDesc("购买进入次数")
        CLASSIC_BATTLE_BUY_ENTER_NUM(7, "购买进入次数"),

        @ReasonDesc("购买行动力")
        CLASSIC_BATTLE_BUY_ACTION_POWER(8, "购买行动力"),

        @ReasonDesc("攻击关卡怪物结果")
        CLASSIC_BATTLE_FIGHT_ENEMY_ARMY_RESULT(9, "攻击关卡怪物结果"),

        @ReasonDesc("经典战役通关")
        CLASSIC_BATTLE_PASS(10, "经典战役通关"),;
        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ClassicBattleLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        public int getReason() {
            return reason;
        }

        public String getReasonText() {
            return reasonText;
        }
    }

    @LogDesc(desc = "剑气日志")
    public enum SwordSoulLogReason implements ILogReason {
        @ReasonDesc("剑气激活")
        SWORD_SOUL_ACTIVATE(1, "剑气激活：武将ID = {0}， 大剑ID = {1}， 小剑ID = {2}"),
        @ReasonDesc("剑气互换")
        SWORD_SOUL_EXCHANGE(2, "剑气互换：武将一ID = {0}， 武将二ID = {1}, 互换前 进度 = {2}, 互换后进度 = {3}");
        ;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private SwordSoulLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "演武日志")
    public enum PracticeLogReason implements ILogReason {
        @ReasonDesc("在线演武开始")
        PRACTICE_ON_LINE_START(1, "在线演武开始"),
        @ReasonDesc("在线演武结束")
        PRACTICE_ON_LINE_STOP(2, "在线演武结束"),
        @ReasonDesc("离线演武经验")
        PRACTICE_OFF_LINE(3, "离线演武经验"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private PracticeLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "酒馆任务日志")
    public enum PubTaskLogReason implements ILogReason {
        @ReasonDesc("接受任务")
        ACCEPT_TASK(1, "接受任务"),
        @ReasonDesc("完成任务")
        FINISH_TASK(2, "完成任务"),
        @ReasonDesc("放弃任务")
        GIVEUP_TASK(3, "放弃任务"),

        @ReasonDesc("刷新任务")
        REFRESH_TASK(4, "刷新任务"),
        
        @ReasonDesc("完成七日目标任务")
        FINISH_DAY7_TASK(5, "完成七日目标任务"),
        
        ;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private PubTaskLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "酒馆经验日志")
    public enum PubExpLogReason implements ILogReason {
        @ReasonDesc("酒馆任务奖励")
        PUBTASK_REWARD(1, "酒馆任务奖励"),
        @ReasonDesc("GM给奖励")
        GM_GIVE(2, "GM给奖励"),
        
        @ReasonDesc("邮件附件")
        MAIL_ATTACHMENT_REWARD(105, "邮件附件"),
        @ReasonDesc("活跃度奖励")
        ACTIVITYUI_REWARD(106, "活跃度奖励"),
        @ReasonDesc("精彩活动奖励")
        GOOD_ACTIVITY_REWARD(109, "精彩活动奖励"),
        @ReasonDesc("任务奖励")
        QUEST_REWARD(110, "任务奖励"),
        @ReasonDesc("打怪胜利奖励")
        WIN_ENEMY_REWARD(114, "打怪胜利奖励"),
        @ReasonDesc("除暴安良特殊奖励")
        SWEENEY_TASK_SPECIAL(115, "除暴安良特殊奖励"),
        @ReasonDesc("NVN月度排名奖励")
        NVN_RANK(116, "NVN月度排名奖励"),
        @ReasonDesc("结婚奖励")
        MARRY_REWARD(117, "结婚奖励"),
        @ReasonDesc("师徒奖励")
        OVERMAN_REWARD(118, "师徒奖励"),
        @ReasonDesc("藏宝图奖励")
        TREASURE_MAP_REWARD(119, "藏宝图奖励"),
        @ReasonDesc("使用礼包道具奖励")
        GIFT_PACK(120, "使用礼包道具奖励"),
        
        @ReasonDesc("酒馆任务奖励")
        PUB_TASK_REWARD(130, "酒馆任务奖励"),
        @ReasonDesc("除暴任务奖励")
		SWEENEY_TASK_REWARD(131, "除暴任务奖励"),
		@ReasonDesc("藏宝图任务奖励")
		TREASURE_MAP_TASK_REWARD(132, "藏宝图任务奖励"),
		@ReasonDesc("护送粮草任务奖励")
		FORAGE_TASK_REWARD(133, "护送粮草任务奖励"),
		@ReasonDesc("帮派任务奖励")
		CORPS_TASK_REWARD(134, "帮派任务奖励"),
		@ReasonDesc("宝石合成失败奖励")
        GEM_SYN_FAIL_REWARD(135, "宝石合成失败奖励"),
        @ReasonDesc("七日登录奖励")
		GA_SEVEN_LOGIN_REWARD(136, "七日登录奖励"),
		@ReasonDesc("等级奖励")
		GA_LEVEL_UP_REWARD(137, "等级奖励"),
		@ReasonDesc("vip每日礼包")
        VIP_DAY_REWARD(138, "vip每日礼包"),
        @ReasonDesc("通天塔奖励")
        TOWER_REWARD(139, "通天塔奖励"),
        @ReasonDesc("vip等级奖励")
        VIP_LEVEL_REWARD(140, "vip等级奖励"),
        @ReasonDesc("帮派boss奖励")
        CORPS_BOSS_REWARD(141, "帮派boss奖励"),
        @ReasonDesc("帮派boss排行榜奖励")
        CORPS_BOSS_RANK_REWARD(142, "帮派boss排行榜奖励"),
        @ReasonDesc("帮派boss挑战次数排行榜奖励")
        CORPS_BOSS_COUNT_RANK_REWARD(143, "帮派boss挑战次数排行榜奖励"),
        @ReasonDesc("野外封妖榜奖励")
        SEAL_DEMON_REWARD(144, "野外封妖榜奖励"),
        @ReasonDesc("野外魔王奖励")
        SEAL_DEMON_KING_REWARD(145, "野外魔王奖励"),
        @ReasonDesc("混世魔王奖励")
        DEVIL_INCARNATE_REWARD(146, "混世魔王奖励"),
        @ReasonDesc("限时杀怪奖励 ")
        TIME_LIMIT_MONSTER_REWARD(147, "限时杀怪奖励 "),
        @ReasonDesc("限时挑战npc奖励")
        TIME_LIMIT_NPC_REWARD(148, "限时挑战npc奖励"),
        @ReasonDesc("七日目标任务奖励")
        DAY7_TARGET_REWARD(149, "七日目标任务奖励"),
        ;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private PubExpLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }
    
    @LogDesc(desc = "帮派任务日志")
    public enum CorpsTaskLogReason implements ILogReason {
        @ReasonDesc("接受任务")
        ACCEPT_TASK(1, "接受任务"),
        @ReasonDesc("完成任务")
        FINISH_TASK(2, "完成任务"),
        @ReasonDesc("放弃任务")
        GIVEUP_TASK(3, "放弃任务"),

        @ReasonDesc("刷新任务")
        REFRESH_TASK(4, "刷新任务"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private CorpsTaskLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }
    
    @LogDesc(desc = "围剿魔族任务日志")
    public enum SiegeDemonTaskLogReason implements ILogReason {
    	@ReasonDesc("接受任务")
    	ACCEPT_TASK(1, "接受任务"),
    	@ReasonDesc("完成任务")
    	FINISH_TASK(2, "完成任务"),
    	@ReasonDesc("放弃任务")
    	GIVEUP_TASK(3, "放弃任务"),
    	
    	@ReasonDesc("刷新任务")
    	REFRESH_TASK(4, "刷新任务"),;
    	
    	/**
    	 * 原因序号
    	 */
    	public final int reason;
    	/**
    	 * 原因文本
    	 */
    	public final String reasonText;
    	
    	private SiegeDemonTaskLogReason(int reason, String reasonText) {
    		this.reason = reason;
    		this.reasonText = reasonText;
    	}
    	
    	@Override
    	public int getReason() {
    		return reason;
    	}
    	
    	@Override
    	public String getReasonText() {
    		return reasonText;
    	}
    	
    }
    
    @LogDesc(desc = "限时刷怪日志")
    public enum TimeLimitMonsterLogReason implements ILogReason {
    	@ReasonDesc("接受任务")
    	ACCEPT_TASK(1, "接受任务"),
    	@ReasonDesc("完成任务")
    	FINISH_TASK(2, "完成任务"),
    	@ReasonDesc("放弃任务")
    	GIVEUP_TASK(3, "放弃任务"),
    	
    	@ReasonDesc("刷新任务")
    	REFRESH_TASK(4, "刷新任务"),;
    	
    	/**
    	 * 原因序号
    	 */
    	public final int reason;
    	/**
    	 * 原因文本
    	 */
    	public final String reasonText;
    	
    	private TimeLimitMonsterLogReason(int reason, String reasonText) {
    		this.reason = reason;
    		this.reasonText = reasonText;
    	}
    	
    	@Override
    	public int getReason() {
    		return reason;
    	}
    	
    	@Override
    	public String getReasonText() {
    		return reasonText;
    	}
    	
    }
    
    @LogDesc(desc = "限时挑战Npc日志")
    public enum TimeLimitNpcLogReason implements ILogReason {
    	@ReasonDesc("接受任务")
    	ACCEPT_TASK(1, "接受任务"),
    	@ReasonDesc("完成任务")
    	FINISH_TASK(2, "完成任务"),
    	@ReasonDesc("放弃任务")
    	GIVEUP_TASK(3, "放弃任务"),
    	
    	@ReasonDesc("刷新任务")
    	REFRESH_TASK(4, "刷新任务"),;
    	
    	/**
    	 * 原因序号
    	 */
    	public final int reason;
    	/**
    	 * 原因文本
    	 */
    	public final String reasonText;
    	
    	private TimeLimitNpcLogReason(int reason, String reasonText) {
    		this.reason = reason;
    		this.reasonText = reasonText;
    	}
    	
    	@Override
    	public int getReason() {
    		return reason;
    	}
    	
    	@Override
    	public String getReasonText() {
    		return reasonText;
    	}
    	
    }
    
    @LogDesc(desc = "帮派建设日志")
    public enum CorpsBuildLogReason implements ILogReason {
    	@ReasonDesc("帮派升级")
    	CORPS_UPGRADE(1, "帮派升级"),
    	;
    	
    	/**
    	 * 原因序号
    	 */
    	public final int reason;
    	/**
    	 * 原因文本
    	 */
    	public final String reasonText;
    	
    	private CorpsBuildLogReason(int reason, String reasonText) {
    		this.reason = reason;
    		this.reasonText = reasonText;
    	}
    	
    	@Override
    	public int getReason() {
    		return reason;
    	}
    	
    	@Override
    	public String getReasonText() {
    		return reasonText;
    	}
    	
    }
    
    @LogDesc(desc = "帮派福利日志")
    public enum CorpsBenefitLogReason implements ILogReason {
    	@ReasonDesc("领取帮派福利")
    	Get_CORPS_BENEFIT(1, "领取帮派福利"),
    	;
    	
    	/**
    	 * 原因序号
    	 */
    	public final int reason;
    	/**
    	 * 原因文本
    	 */
    	public final String reasonText;
    	
    	private CorpsBenefitLogReason(int reason, String reasonText) {
    		this.reason = reason;
    		this.reasonText = reasonText;
    	}
    	
    	@Override
    	public int getReason() {
    		return reason;
    	}
    	
    	@Override
    	public String getReasonText() {
    		return reasonText;
    	}
    	
    }
    
    @LogDesc(desc = "通天塔日志")
    public enum TowerLogReason implements ILogReason {
    	@ReasonDesc("使用双倍经验丹")
    	USE_DOUBLE_POINT(1, "使用双倍经验丹"),
    	@ReasonDesc("系统给双倍经验丹")
    	SYS_GIVE_DOUBLE_POINT(2, "系统给双倍经验丹"),
    	;
    	
    	/**
    	 * 原因序号
    	 */
    	public final int reason;
    	/**
    	 * 原因文本
    	 */
    	public final String reasonText;
    	
    	private TowerLogReason(int reason, String reasonText) {
    		this.reason = reason;
    		this.reasonText = reasonText;
    	}
    	
    	@Override
    	public int getReason() {
    		return reason;
    	}
    	
    	@Override
    	public String getReasonText() {
    		return reasonText;
    	}
    	
    }
    
    @LogDesc(desc = "帮派boss日志")
    public enum CorpsBossLogReason implements ILogReason {
    	@ReasonDesc("闯关成功")
    	CORPS_BOSS_OK(1, "闯关成功|boss进度={0}"),
    	@ReasonDesc("闯关失败")
    	CORPS_BOSS_FAIL(2, "闯关失败|boss进度={0}"),
    	;
    	
    	/**
    	 * 原因序号
    	 */
    	public final int reason;
    	/**
    	 * 原因文本
    	 */
    	public final String reasonText;
    	
    	private CorpsBossLogReason(int reason, String reasonText) {
    		this.reason = reason;
    		this.reasonText = reasonText;
    	}
    	
    	@Override
    	public int getReason() {
    		return reason;
    	}
    	
    	@Override
    	public String getReasonText() {
    		return reasonText;
    	}
    	
    }

    @LogDesc(desc = "科举日志")
    public enum ExamLogReason implements ILogReason {
        @ReasonDesc("科举答题记录")
        EXAM_ANSWER(1, "科举答题记录"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ExamLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "除暴安良任务日志")
    public enum TheSweeneyTaskLogReason implements ILogReason {
        @ReasonDesc("接受任务")
        ACCEPT_TASK(1, "接受任务"),
        @ReasonDesc("完成任务")
        FINISH_TASK(2, "完成任务"),
        @ReasonDesc("放弃任务")
        GIVEUP_TASK(3, "放弃任务"),

        @ReasonDesc("刷新任务")
        REFRESH_TASK(4, "刷新任务"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private TheSweeneyTaskLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "藏宝图任务日志")
    public enum TreasureMapLogReason implements ILogReason {
        @ReasonDesc("接受任务")
        ACCEPT_TASK(1, "接受任务"),
        @ReasonDesc("完成任务")
        FINISH_TASK(2, "完成任务"),
        @ReasonDesc("放弃任务")
        GIVEUP_TASK(3, "放弃任务"),

        @ReasonDesc("刷新任务")
        REFRESH_TASK(4, "刷新任务"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private TreasureMapLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "称号日志")
    public enum TitleLogReason implements ILogReason {

        @ReasonDesc("修改称号")
        CHANGE_TITLE(1, "修改称号"),

        @ReasonDesc("增加称号使用时间")
        ADD_LOSTTIME_TITLE(2, "增加称号使用时间"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private TitleLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "护送粮草任务日志")
    public enum ForageTaskLogReason implements ILogReason {
        @ReasonDesc("接受任务")
        ACCEPT_TASK(1, "接受任务"),
        @ReasonDesc("完成任务")
        FINISH_TASK(2, "完成任务"),
        @ReasonDesc("放弃任务")
        GIVEUP_TASK(3, "放弃任务"),

        @ReasonDesc("刷新任务")
        REFRESH_TASK(4, "刷新任务"),;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private ForageTaskLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }

    @LogDesc(desc = "师徒日志")
    public enum OvermanLogReason implements ILogReason {
        @ReasonDesc("申请拜师")
        WANT_OVERMAN(1, "申请拜师"),
        @ReasonDesc("拜师")
        OVERMAN(2, "拜师"),
        @ReasonDesc("师傅强制解除")
        FORCE_FIRE_OVERMAN(3,"师傅强制解除"),
        @ReasonDesc("徒弟强制解除")
        FORCE_FIRE_LOWERMAN(4,"徒弟强制解除"),
        @ReasonDesc("组队解除")
        FORCE_FIRE_TEMA(5,"组队解除"),
        @ReasonDesc("出师")
        FIRE_OVERMAN(6,"出师"),
        ;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private OvermanLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }
    
    @LogDesc(desc = "翅膀日志")
    public enum WingLogReason implements ILogReason {
        @ReasonDesc("召唤翅膀消耗翅膀卡")
        USE_WING_CARD(1, "召唤翅膀消耗翅膀卡itemId={0}"),
        @ReasonDesc("装备翅膀")
        SET_WING(2, "装备翅膀wingTplId={0}"),
        @ReasonDesc("升阶翅膀")
        UPGRADE_WING(3, "升阶翅膀wingTplId={0}|升阶方式={1}"),
        @ReasonDesc("卸下翅膀")
        TAKEDOWN_WING(4, "卸下翅膀wingTplId={0}"),
        ;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private WingLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }
    
    
    @LogDesc(desc = "出售商品日志")
    public enum CommoditySellLogReason implements ILogReason {
        @ReasonDesc("出售商品")
        SELL_COMMODITY(1, "出售商品"),
        @ReasonDesc("下架商品")
        TAKE_DOWN_COMMODITY(2,"下架商品"),
        ;

        /**
         * 原因序号
         */
        public final int reason;
        /**
         * 原因文本
         */
        public final String reasonText;

        private CommoditySellLogReason(int reason, String reasonText) {
            this.reason = reason;
            this.reasonText = reasonText;
        }

        @Override
        public int getReason() {
            return reason;
        }

        @Override
        public String getReasonText() {
            return reasonText;
        }

    }
    
    @LogDesc(desc = "购买商品日志")
    public enum CommodityBuyLogReason implements ILogReason {
    	@ReasonDesc("购买商品")
    	BUY_COMMODITY(1, "购买商品"),
    	
    	;
    	
    	/**
    	 * 原因序号
    	 */
    	public final int reason;
    	/**
    	 * 原因文本
    	 */
    	public final String reasonText;
    	
    	private CommodityBuyLogReason(int reason, String reasonText) {
    		this.reason = reason;
    		this.reasonText = reasonText;
    	}
    	
    	@Override
    	public int getReason() {
    		return reason;
    	}
    	
    	@Override
    	public String getReasonText() {
    		return reasonText;
    	}
    	
    }
}

