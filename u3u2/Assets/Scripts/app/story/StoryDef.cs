using System.Collections.Generic;
using app.db;
using UnityEngine;

namespace app.story
{
    /// <summary>
    /// 特殊事件类型
    /// </summary>
    public enum StoryEventType
    {
        //其他：0 或 不填
        NONE=0,
        //1:开场文字（黑屏白字）
        EntryText,
        //2:震屏,只需设置震屏持续时间,填在 位置x 处        
        ShakeCamera,
        //3:技能,需指定技能id和目标对象编号        
        Skill,
        //4:闪避        
        Dodgy,
        //5:击飞        
        Fly,
        //6:逃跑        
        RunAway,
        //7:音乐，需设置音乐类型、名称,依次填在 位置x 位置y 处        
        Music
    }
    /// <summary>
    /// 事件类型1：创建；2：更新；3：消失（销毁）
    /// </summary>
    public enum StoryStatusType
    {
        Appear = 1,
        Update,
        DisAppear
    }

    /// <summary>
    /// 创建对象类型1：主角；2：非主角；3：特效；4：中心点；5：震屏
    /// </summary>
    public enum StoryObjectType
    {
        Player = 1,
        OhterModel,
        Effect,
        MapCenter,
        Vibrate,
        Music
    }

    public class StoryDef
    {
        public static bool isWidePos
        {
            get
            {
                if (UGUIConfig.ScreenWidth / UGUIConfig.ScreenHeight >= 16 / 9)
                {
                    return true;
                }
                return false;
            }
        }

        public static readonly Vector3 midPos = new Vector3(-0.2f, 0, -1f + 0.5f - 2f);
        /// <summary>
        /// 1~5号位，在后排
        /// 6～10号位，在前排
        /// </summary>
        private static readonly List<Vector3> atkWidePosList =
            new List<Vector3>
            {
                //右下角前排
                new Vector3(4.5f+1f, 0, 2f),
                new Vector3(3.5f+1f, 0, 0.5f-1f),
                new Vector3(2.5f+1f, 0, -1f-2f),
                new Vector3(1.5f+1f, 0, -2.5f-3f),
                new Vector3(0.5f+1f, 0, -4f-4f),
                //右下角后排
                new Vector3(6+1f, 0, 2f),
                new Vector3(5+1f, 0, 0.5f-1f),
                new Vector3(4+1f, 0, -1f-2f),
                new Vector3(3+1f, 0, -2.5f-3f),
                new Vector3(2+1f, 0, -4f-4f)
            };

        /// <summary>
        /// 1~5号位，在后排
        /// 6～10号位，在前排
        /// </summary>
        private static readonly List<Vector3> defWidePosList =
            new List<Vector3>
            {
                //左上角前排
                new Vector3(-2.8f+1f, 0, 2 + 0.5f),
                new Vector3(-3.8f+1f, 0, 0.5f + 0.5f-1f),
                new Vector3(-4.8f+1f, 0, -1f + 0.5f-2f),
                new Vector3(-5.8f+1f, 0, -2.5f + 0.5f-3f),
                new Vector3(-6.8f+1f, 0, -4f + 0.5f-4f),
                //左上角后排
                new Vector3(-4.3f+1f, 0, 2f + 0.5f+1f),
                new Vector3(-5.3f+1f, 0, 0.5f + 0.5f-1f+1f),
                new Vector3(-6.3f+1f, 0, -1f + 0.5f-2f+1f),
                new Vector3(-7.3f+1f, 0, -2.5f + 0.5f-3f+1f),
                new Vector3(-8.3f+1f, 0, -4f + 0.5f-4f+1f)
            };

        /// <summary>
        /// 1~5号位，在后排
        /// 6～10号位，在前排
        /// </summary>
        private static readonly List<Vector3> atkPosList =
            new List<Vector3>
            {
                //右下角前排
                new Vector3(4.5f, 0, 2f),
                new Vector3(3.5f, 0, 0.5f-1f),
                new Vector3(2.5f, 0, -1f-2f),
                new Vector3(1.5f, 0, -2.5f-3f),
                new Vector3(0.5f, 0, -4f-4f),
                //右下角后排
                new Vector3(6, 0, 2f),
                new Vector3(5, 0, 0.5f-1f),
                new Vector3(4, 0, -1f-2f),
                new Vector3(3, 0, -2.5f-3f),
                new Vector3(2, 0, -4f-4f)
            };

        /// <summary>
        /// 1~5号位，在后排
        /// 6～10号位，在前排
        /// </summary>
        private static readonly List<Vector3> defPosList =
            new List<Vector3>
            {
                //左上角前排
                new Vector3(-2.8f+2f, 0, 2.5f),
                new Vector3(-3.8f+2f, 0, 0f),
                new Vector3(-4.8f+2f, 0, -2.5f),
                new Vector3(-5.8f+2f, 0, -5f),
                new Vector3(-6.8f+2f, 0, -7.5f),
                //左上角后排
                new Vector3(-4.3f+2f, 0, 3.5f),
                new Vector3(-5.3f+2f, 0, 1f),
                new Vector3(-6.3f+2f, 0, -1.5f),
                new Vector3(-7.3f+2f, 0, -4f),
                new Vector3(-8.3f+2f, 0, -6.5f)
            };

        public static Vector3 getPos(StoryBattleTemplate da)
        {
            if (da.posY <= 0 || da.posY > 10)
            {
                return midPos;
            }
            if (da.posX == 1)
            {
                if ((UGUIConfig.ScreenWidth*1.0f/UGUIConfig.ScreenHeight) >= (16f/9f))
                {
                    return atkWidePosList[da.posY - 1];
                }
                else
                {
                    return atkPosList[da.posY - 1];
                }
            }
            else if (da.posX == 2)
            {
                if ((UGUIConfig.ScreenWidth*1.0f/UGUIConfig.ScreenHeight) >= (16f/9f))
                {
                    return defWidePosList[da.posY - 1];
                }
                else
                {
                    return defPosList[da.posY - 1];
                }
            }
            return midPos;
        }

        public static List<StoryBattleTemplate> GetStoryBattleList()
        {
            List<StoryBattleTemplate> getdata = new List<StoryBattleTemplate>();
            int index = 0;
            StoryBattleTemplate t1 = newStoryBattleTemplate(index++, 00000, 0, 1, 0, 1, "", "", "", 0, "", 0, 0, 0, "", 0, "四十年前，一介布衣的永祥帝，");
            StoryBattleTemplate t2 = newStoryBattleTemplate(index++, 00000, 0, 1, 0, 1, "", "", "", 0, "", 0, 0, 0, "", 0, "于草莽之中，拔剑而起。");
            StoryBattleTemplate t3 = newStoryBattleTemplate(index++, 00000, 0, 1, 0, 1, "", "", "", 0, "", 0, 0, 0, "", 0, "诛杀了荼毒生灵的天妖穷奇，");
            StoryBattleTemplate t4 = newStoryBattleTemplate(index++, 00000, 0, 1, 0, 1, "", "", "", 0, "", 0, 0, 0, "", 0, "放逐了穷兵黩武的暴君重黎,");
            StoryBattleTemplate t5 = newStoryBattleTemplate(index++, 00000, 0, 1, 0, 1, "", "", "", 0, "", 0, 0, 0, "", 0, "建立了朝云一朝。");
            StoryBattleTemplate t6 = newStoryBattleTemplate(index++, 00000, 0, 1, 0, 1, "", "", "", 0, "", 0, 0, 0, "", 0, "然而造化弄人，治世四十年的朝云，");
            StoryBattleTemplate t7 = newStoryBattleTemplate(index++, 00000, 0, 1, 0, 1, "", "", "", 0, "", 0, 0, 0, "", 0, "王气，很快就衰败了下去，");
            StoryBattleTemplate t8 = newStoryBattleTemplate(index++, 00000, 0, 1, 0, 1, "", "", "", 0, "", 0, 0, 0, "", 0, "这一切，都要从那一天说起……");
            int txttime = 0;
            txttime += 12000;
            StoryBattleTemplate r0 = newStoryBattleTemplate(index++, txttime+01000, 1, 0, 0, 0, "", "", "", 0, "", 0, 0, 0, "", 0, "");
            txttime += 3000;
            StoryBattleTemplate d1 = newStoryBattleTemplate(index++, txttime + 02000, 0, 0, 1, 1, "d1", "", "", 0, "", 2, 1, 100000, "", 0, "");
            StoryBattleTemplate d2 = newStoryBattleTemplate(index++, txttime + 03000, 0, 0, 1, 2, "d2", "d2", "nanxiake", 0, "", 2, 2, 100000, "", 0, "");
            //StoryBattleTemplate r1 = newStoryBattleTemplate(index++, txttime + 04000, 2, 0, 0, 0, "", "", "", 0, "", 0, 0, 0, "", 0, "");
            //txttime += 3000;
            StoryBattleTemplate d3 = newStoryBattleTemplate(index++, txttime + 06000, 0, 0, 1, 3, "d3", "d3", "chongwu_lei", 0, "", 2, 1, 0, "", 0, "");
            //StoryBattleTemplate d4 = newStoryBattleTemplate(index++, txttime + 06000, 0, 0, 1, 2, "d4", "d4", "nancike", 0, "", 2, 4, 100000, "", 0, "");
            //StoryBattleTemplate d5 = newStoryBattleTemplate(index++, txttime + 07000, 0, 0, 1, 2, "d5", "d5", "nvcike", 0, "", 2, 5, 100000, "", 0, "");
            //StoryBattleTemplate d6 = newStoryBattleTemplate(index++, txttime + 08000, 0, 0, 1, 2, "d6", "d6", "nanshushi", 0, "", 2, 6, 100000, "", 0, "");
            //StoryBattleTemplate d7 = newStoryBattleTemplate(index++, txttime + 09000, 0, 0, 1, 2, "d7", "d7", "nvshushi", 0, "", 2, 7, 100000, "", 0, "");
            //StoryBattleTemplate d8 = newStoryBattleTemplate(index++, txttime + 10000, 0, 0, 1, 2, "d8", "d8", "nanxiuzhen", 0, "", 2, 8, 100000, "", 0, "");
            //StoryBattleTemplate d9 = newStoryBattleTemplate(index++, txttime + 11000, 0, 0, 1, 2, "d9", "d9", "nvxiuzhen", 0, "", 2, 9, 100000, "", 0, "");
            //StoryBattleTemplate d10 = newStoryBattleTemplate(index++, txttime + 12000, 0, 0, 1, 2, "d10", "d10", "nvcike", 0, "", 2, 10, 100000, "", 0, "");
            //StoryBattleTemplate r2 = newStoryBattleTemplate(index++, txttime + 13000, 3, 0, 0, 0, "", "", "", 0, "", 0, 0, 0, "", 0, "");
            //txttime += 3000;
            StoryBattleTemplate a1 = newStoryBattleTemplate(index++, txttime + 4000, 0, 0, 1, 2, "a1", "a1", "nvxiake", 0, "", 1, 1, 100000, "", 0, "我是第二主角");
            //StoryBattleTemplate a2 = newStoryBattleTemplate(index++, txttime + 15000, 0, 0, 1, 2, "a2", "a2", "nanxiake", 0, "", 1, 2, 100000, "", 0, "");
            //StoryBattleTemplate a3 = newStoryBattleTemplate(index++, txttime + 16000, 0, 0, 1, 2, "a3", "a3", "nvxiake", 0, "", 1, 3, 100000, "", 0, "");
            //StoryBattleTemplate a4 = newStoryBattleTemplate(index++, txttime + 17000, 0, 0, 1, 2, "a4", "a4", "nancike", 0, "", 1, 4, 100000, "", 0, "");
            //StoryBattleTemplate a5 = newStoryBattleTemplate(index++, txttime + 18000, 0, 0, 1, 2, "a5", "a5", "nvcike", 0, "", 1, 5, 100000, "", 0, "");
            //StoryBattleTemplate a6 = newStoryBattleTemplate(index++, txttime + 19000, 0, 0, 1, 2, "a6", "a6", "nanshushi", 0, "", 1, 6, 100000, "", 0, "");
            //StoryBattleTemplate a7 = newStoryBattleTemplate(index++, txttime + 20000, 0, 0, 1, 2, "a7", "a7", "nvshushi", 0, "", 1, 7, 100000, "", 0, "");
            //StoryBattleTemplate a8 = newStoryBattleTemplate(index++, txttime + 21000, 0, 0, 1, 2, "a8", "a8", "nanxiuzhen", 0, "", 1, 8, 100000, "", 0, "");
            //StoryBattleTemplate a9 = newStoryBattleTemplate(index++, txttime + 22000, 0, 0, 1, 2, "a9", "a9", "nvxiuzhen", 0, "", 1, 9, 100000, "", 0, "");
            //StoryBattleTemplate a10 = newStoryBattleTemplate(index++, txttime + 23000, 0, 0, 1, 2, "a10", "a10", "nvcike", 0, "", 1, 10, 100000, "", 0, "");

            //技能攻击
            StoryBattleTemplate s1 = newStoryBattleTemplate(index++, txttime + 5000, 0, 3, 0, 0, "a1","a01", "", 11001, "d1", 0, 0, -100000, "", 0, "");
            StoryBattleTemplate s2 = newStoryBattleTemplate(index++, txttime + 10000, 0, 0, 2, 0, "a1", "a01", "", 11001, "d1", 0, 0, 1000, "", 0, "");
            //屏幕震动
            //StoryBattleTemplate s1 = newStoryBattleTemplate(index++, txttime + 5000, 0, 2,0,0,"","","",0,"",1000);
            //闪避
            //StoryBattleTemplate s1 = newStoryBattleTemplate(index++, txttime + 5000, 0, 4, 0, 0, "d1", "", "", 0, "", 0);
            //击飞
            //StoryBattleTemplate s1 = newStoryBattleTemplate(index++, txttime + 5000, 0, 5, 0, 0, "d1", "", "", 0, "", 0);
            //逃跑
            //StoryBattleTemplate s1 = newStoryBattleTemplate(index++, txttime + 5000, 0, 6, 0, 0, "d2", "", "", 0, "", 0);
            //音乐
            //StoryBattleTemplate s1 = newStoryBattleTemplate(index++, txttime + 5000, 0, 7, 0, 0, "", "", "skill_guiji3", 0, "", (int)AudioEnumType.Skill);
            //位移,转向
            //StoryBattleTemplate s1 = newStoryBattleTemplate(index++, txttime + 5000, 0, 3, 0, 0, "a1", "", "", 11002, "d1", 2,3,0,"",0);

            StoryBattleTemplate z0 = newStoryBattleTemplate(index++, txttime + 990000, 4, 0, 0, 0, "", "", "", 0, "", 0, 0, 0, "", 0, "");

            getdata.Add(t1);
            getdata.Add(t2);
            getdata.Add(t3);
            getdata.Add(t4);
            getdata.Add(t5);
            getdata.Add(t6);
            getdata.Add(t7);
            getdata.Add(t8);

            getdata.Add(r0);

            getdata.Add(d1);
            getdata.Add(d2);
            //getdata.Add(r1);

            getdata.Add(d3);
            //getdata.Add(d4);
            //getdata.Add(d5);
            //getdata.Add(d6);
            //getdata.Add(d7);
            //getdata.Add(d8);
            //getdata.Add(d9);
            //getdata.Add(d10);
            //getdata.Add(r2);

            getdata.Add(a1);
            //getdata.Add(a2);
            //getdata.Add(a3);
            //getdata.Add(a4);
            //getdata.Add(a5);
            //getdata.Add(a6);
            //getdata.Add(a7);
            //getdata.Add(a8);
            //getdata.Add(a9);
            //getdata.Add(a10);
            getdata.Add(s1);
            getdata.Add(s2);
            getdata.Add(z0);
            return getdata;
        }
        
        public static StoryBattleTemplate cloneTpl(StoryBattleTemplate tpl)
        {
            StoryBattleTemplate sbt = new StoryBattleTemplate();
            sbt.Id = tpl.Id;
            sbt.storyId = tpl.storyId;
            sbt.time = tpl.time;
            sbt.round = tpl.round;
            sbt.eventType = tpl.eventType;
            sbt.status = tpl.status;
            sbt.targetType = tpl.targetType;
            sbt.targetId = tpl.targetId;
            sbt.targetName = tpl.targetName;
            sbt.modelName = tpl.modelName;
            sbt.skillId = tpl.skillId;
            sbt.skillTargets = tpl.skillTargets;
            sbt.posX = tpl.posX;
            sbt.posY = tpl.posY;
            sbt.hp = tpl.hp;
            sbt.action = tpl.action;
            sbt.direction = tpl.direction;
            sbt.speak = tpl.speak;
            return sbt;
        }

        private static StoryBattleTemplate newStoryBattleTemplate(
                int storyId,
                int time,
                int round = 0,
                int eventType = 0,
                int status = 0,
                int targetType = 0,
                string targetId = "",
                string targetName = "",
                string modelName = "",
                int skillId = 0,
                string skillTargets = "",
                int posX = 0,
                int posY = 0,
                int hp = 0,
                string action = "",
                int direction = 0,
                string speak = ""
            )
        {
            StoryBattleTemplate sbt = new StoryBattleTemplate();
            sbt.storyId = storyId;
            sbt.time = time;
            sbt.round = round;
            sbt.eventType = eventType;
            sbt.status = status;
            sbt.targetType = targetType;
            sbt.targetId = targetId;
            sbt.targetName = targetName;
            sbt.modelName = modelName;
            sbt.skillId = skillId;
            sbt.skillTargets = skillTargets;
            sbt.posX = posX;
            sbt.posY = posY;
            sbt.hp = hp;
            sbt.action = action;
            sbt.direction = direction;
            sbt.speak = speak;
            return sbt;
        }
    }
}
