using UnityEngine;

namespace app.battle
{
    public class BattleDef
    {
        /// <summary>
        /// 手动战斗回合倒计时。
        /// </summary>
        public const float MANUAL_ROUND_CD_SECONDS = 30.0f;

        /// <summary>
        /// 自动战斗回合倒计时。
        /// </summary>
        public const float AUTO_ROUND_CD_SECONDS = 3.0f;

        public const float SKILL_START_DELAY = 0.0f;

        public const float BULLET_THROW_SPEED = 0.5f;
        public const float BULLET_THROW_ANGLE = 20f;
        public const float BULLET_SHOT_SPEED = 1f;

        public const float CHARACTER_MOVE_SPEED = 25f;

        public const float IMPACT_EFFECT_MAX_AGE = 1.0f;

        public const float DEFAULT_SKILL_SECONDS_COST = 3.0f;

        //public static readonly int PLAY_REPORT_FAST_SPEED = 3;

        public const int PLAY_REPORT_NOR_SPEED = 1;

        /// <summary>
        /// 1~5号位站人，在后排，[4,2,1,3,5]；
        /// 6～10号位站宠物，在前排，[9,7,6,8,10]
        /// </summary>
        private static readonly Vector3[] mAtkerPoses = {
            new Vector3(5.63f, 0.00f, -0.13f),
            new Vector3(5.93f, 0.00f, -1.80f),
            new Vector3(5.33f, 0.00f, 1.54f),
            new Vector3(6.22f, 0.00f, -3.48f),
            new Vector3(5.04f, 0.00f, 3.22f),

            new Vector3(3.79f, 0.00f, -0.13f),
            new Vector3(4.09f, 0.00f, -1.80f),
            new Vector3(3.49f, 0.00f, 1.54f),
            new Vector3(4.38f, 0.00f, -3.48f),
            new Vector3(3.20f, 0.00f, 3.22f)
        };

        private static readonly Vector3[] mAtkerPosesWide = {
            new Vector3(5.32f, 0.00f, 1.41f),
            new Vector3(5.62f, 0.00f, -0.26f),
            new Vector3(5.02f, 0.00f, 3.08f),
            new Vector3(5.91f, 0.00f, -1.94f),
            new Vector3(4.73f, 0.00f, 4.76f),

            new Vector3(3.48f, 0.00f, 1.41f),
            new Vector3(3.78f, 0.00f, -0.26f),
            new Vector3(3.18f, 0.00f, 3.08f),
            new Vector3(4.07f, 0.00f, -1.94f),
            new Vector3(2.89f, 0.00f, 4.76f)
        };

        /// <summary>
        /// 1~5号位站人，在后排，[4,2,1,3,5]；
        /// 6～10号位站宠物，在前排，[9,7,6,8,10]
        /// </summary>
        private static readonly Vector3[] mDefPoses = {
            new Vector3(-4.70f, 0.00f, -1.94f),
            new Vector3(-4.40f, 0.00f, -3.61f),
            new Vector3(-5.00f, 0.00f, -0.27f),
            new Vector3(-4.11f, 0.00f, -5.29f),
            new Vector3(-5.29f, 0.00f, 1.41f),

            new Vector3(-2.86f, 0.00f, -1.94f),
            new Vector3(-2.56f, 0.00f, -3.61f),
            new Vector3(-3.16f, 0.00f, -0.27f),
            new Vector3(-2.27f, 0.00f, -5.29f),
            new Vector3(-3.45f, 0.00f, 1.41f)
        };

        private static readonly Vector3[] mDefPosesWide = {
            new Vector3(-4.46f, 0.00f, -2.21f),
            new Vector3(-4.16f, 0.00f, -3.88f),
            new Vector3(-4.76f, 0.00f, -0.54f),
            new Vector3(-3.87f, 0.00f, -5.56f),
            new Vector3(-5.05f, 0.00f, 1.14f),

            new Vector3(-2.62f, 0.00f, -2.21f),
            new Vector3(-2.32f, 0.00f, -3.88f),
            new Vector3(-2.92f, 0.00f, -0.54f),
            new Vector3(-2.03f, 0.00f, -5.56f),
            new Vector3(-3.21f, 0.00f, 1.14f)
        };

        public static Vector3[] ATTACKER_POSES
        {
            get
            {
                if (UGUIConfig.ScreenWidth / UGUIConfig.ScreenHeight >= 16 / 9)
                {
                    return mAtkerPosesWide;
                }
                return mAtkerPoses;
            }
        }

        public static Vector3[] DEFENDER_POSES
        {
            get
            {
                if (UGUIConfig.ScreenWidth / UGUIConfig.ScreenHeight >= 16 / 9)
                {
                    return mDefPosesWide;
                }
                return mDefPoses;
            }
        }
    }

    public enum BattleType
    {
        NONE,
        PLAY_BATTLE_REPORT,
        PVE,
        PVP,
        TEAM_PVE,
        TEAM_PVP
    }

    public enum BattleSubType
    {
        NONE,
        AUTO,
        MANUAL
    }

    public enum BattleRoundStatusType
    {
        NONE,
        ROUND_REQUESTING,
        ROUND_INIT_START,
        ROUND_INIT_PROGRESS,
        ROUND_INIT_FINISH,
        ROUND_START_START,
        ROUND_START_PROGRESS,
        ROUND_START_FINISH,
        ROUND_PROGRESS_START,
        ROUND_PROGRESS_PROGRESS,
        ROUND_PROGRESS_FINISH,
        ROUND_END_START,
        ROUND_END_PROGRESS,
        ROUND_END_FINISH
    }

    public enum BattleBehavStatusType
    {
        NONE,
        BEHAV_START,
        BEHAV_EXECUTE,
        BEHAV_DEFENCE,
        BEHAV_ADJUST,
        BEHAV_END
    }

    public enum BattleRoundBehavType
    {
        NONE,
        SKILL,
        BUFF
    }

    public struct BatCharacterStatus
    {
        /** 正常状态*/
        public const int NORMAL = 0;
        /** 死亡*/
        public const int DEAD = 1;
        /** 被控制（被眩晕）*/
        public const int DISABLE = 2;
        /** 禁止普通攻击*/
        public const int FORBID_NORMAL = 4;
        /** 禁止技能攻击（被沉默）*/
        public const int FORBID_SKILL = 8;
        /** 被捕捉了 */
        public const int BE_CAUGHT = 16;
        /** 防御 */
        public const int DEFENSE = 32;
        /** 无敌 */
        public const int NBDZT = 64;
        /** 混乱 */
        public const int CHAOS = 128;
        /** 逃跑 */
        public const int ESCAPE = 256;
        /** 被击飞 */
        public const int DEAD_FLY = 512;
    }

    /// <summary>
    /// 武将战斗类型，区分攻击方式。
    /// </summary>
    public enum BatCharacterAttackType
    {
        NONE,

        /// <summary>
        /// 力量型（物理攻击）(1)。
        /// </summary>
        STRENGTH,

        /// <summary>
        /// 智力型（法术攻击）(2)。
        /// </summary>
        INTELLECT
    }

    public enum BatCharacterSiteType
    {
        NONE,
        ATTACKER,
        DEFENDER
    }

    /// <summary>
    /// 特效出现的位置类型。
    /// </summary>
    public enum SkillEffectPosType
    {
        /// <summary>
        /// 无(0)。
        /// </summary>
        NONE,
        /// <summary>
        /// 脚下的地面(1)。
        /// </summary>
        GROUND,
        /// <summary>
        /// 周身(2)。
        /// </summary>
        BODY,
        /// <summary>
        /// 左手(3)。
        /// </summary>
        LEFT_HAND,
        /// <summary>
        /// 右手(4)。
        /// </summary>
        RIGHT_HAND,
        /// <summary>
        /// 头顶(5)。
        /// </summary>
        HEAD_TOP,
        /// <summary>
        /// 子弹发射点(6)。
        /// </summary>
        FIRE_ROOT
    }

    /// <summary>
    /// 特效类型。
    /// </summary>
    public enum SkillEffectType
    {
        /// <summary>
        /// 无(0)。
        /// </summary>
        NONE,
        /// <summary>
        /// 地面特效(1)。
        /// </summary>
        GROUND,
        /// <summary>
        /// 身体特效(2)。
        /// </summary>
        BODY,
        /// <summary>
        /// 子弹(3)。
        /// </summary>
        BULLET
    }

    /// <summary>
    /// 特效出现目标。
    /// </summary>
    public enum SkillEffectShowTarget
    {
        /// <summary>
        /// 无(0)。
        /// </summary>
        NONE,
        /// <summary>
        /// 自己(1)。
        /// </summary>
        SELF,
        /// <summary>
        /// 敌方技能目标(2)。
        /// </summary>
        ENEMY_SKILL_TARGET,
        /// <summary>
        /// 己方技能目标(3)。
        /// </summary>
        SELF_SKILL_TARGET,
        /// <summary>
        /// 全屏(4)。
        /// </summary>
        FULL_SCREEN,
        /// <summary>
        /// 所有目标（包括敌方和己方）。
        /// </summary>
        ALL_TARGETS
    }

    /// <summary>
    /// 技能动作类型。
    /// </summary>
    public enum SkillActionType
    {
        /// <summary>
        /// 无(0)。
        /// </summary>
        NONE,
        /// <summary>
        /// 投掷(1)。
        /// </summary>
        THROW,
        /// <summary>
        /// 射击(2)。
        /// </summary>
        SHOT,
        /// <summary>
        /// 其它(3)。
        /// </summary>
        OTHERS
    }

    /// <summary>
    /// 技能特效影响目标类型。
    /// </summary>
    public enum SkillEffectImpactTargetType
    {
        /// <summary>
        /// 无(0)。
        /// </summary>
        NONE,
        /// <summary>
        /// 单个目标(1)。
        /// </summary>
        EACH,
        /// <summary>
        /// 所有目标(2)。
        /// </summary>
        ALL
    }

    public enum SkillImpactEffectPosType
    {
        /// <summary>
        /// 无(0)。
        /// </summary>
        NONE,
        /// <summary>
        /// 头顶(1)。
        /// </summary>
        HEAD_TOP,
        /// <summary>
        /// 胸口(2)。
        /// </summary>
        CHEST,
        /// <summary>
        /// 脚下(3)。
        /// </summary>
        FOOT
    }

    public enum SkillBuffPosType
    {
        /// <summary>
        /// 无(0)。
        /// </summary>
        NONE,
        /// <summary>
        /// 头顶(1)。
        /// </summary>
        HEAD_TOP,
        /// <summary>
        /// 脚下(2)。
        /// </summary>
        FOOT,
        /// <summary>
        /// 周身(3)。
        /// </summary>
        BODY
    }

    public enum SkillBuffStateType
    {
        NONE,
        /// <summary>
        /// 添加(1)。
        /// </summary>
        ADD,
        /// <summary>
        /// 执行中(2)。
        /// </summary>
        ING,
        /// <summary>
        /// 删除(3)。
        /// </summary>
        REMOVE
    }

    public enum SkillTargetType
    {
        NONE,
        /// <summary>
        /// 敌方。
        /// </summary>
        ENEMY,
        /// <summary>
        /// 己方。
        /// </summary>
        OUR,
        /// <summary>
        /// 自己。
        /// </summary>
        MYSELF,
        /// <summary>
        /// 主将。
        /// </summary>
        LEADER,
        /// <summary>
        /// 宠物。
        /// </summary>
        PET,
        /// <summary>
        /// 敌方可捕捉单位。
        /// </summary>
        ENEMY_CAN_CATCH,
        /// <summary>
        /// 己方死亡单位。
        /// </summary>
        OUR_DEAD,
        /// <summary>
        /// 己方含死亡单位。
        /// </summary>
        OUR_ALL,
        /// <summary>
        /// 属于自己的所有单位。
        /// </summary>
        MY_OWN_ALL,
        /// <summary>
        /// 己方宠物。
        /// </summary>
        MY_OWN_PET,
        /// <summary>
        /// 敌方宠物。
        /// </summary>
        ENEMY_PET,
        /// <summary>
        /// 全体活的单位。
        /// </summary>
        ALL_NOT_DEAD
    }

    public enum SkillTargetRangeType
    {
        NONE,
        RANDOM,
        SINGLE,
        ALL,
        CROSS
    }

    public struct BatSkillID
    {
        public const int NORMAL_ATTACK = 1;
        public const int CATCH = 2;
        public const int DEFENSE = 3;
        public const int ESCAPE = 4;
        public const int USE_ITEM = 5;
        public const int SUMMON = 6;

        public static bool HasValue(int id)
        {
            return id == NORMAL_ATTACK ||
            id == CATCH ||
            id == DEFENSE || id == ESCAPE || id == USE_ITEM || id == SUMMON;
        }
    }

    public struct BatBuffID
    {
        /// <summary>
        /// 防御。
        /// </summary>
        public const int DEFENSE = 3;
        /// <summary>
        /// 混乱。
        /// </summary>
        public const int CHAOS = 18;
    }

    public enum BatRoundStageType
    {
        NONE,
        START,
        PROGRESS,
        END
    }
}
