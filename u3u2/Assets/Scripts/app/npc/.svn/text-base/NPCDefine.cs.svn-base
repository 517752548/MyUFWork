using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// NPC 类型
/// </summary>

namespace app.npc
{
    public class NPCDefine
    {
        /// <summary>
        /// 获得npc朝向的度数
        /// </summary>
        /// <param name="npcDirection"></param>
        /// <returns></returns>
        public static int GetNpcDirectionById(int npcDirection)
        {
            int direction = 0;
            switch (npcDirection)
            {
                case 1:
                    direction = 0;break;
                case 2:
                    direction = 45; break;
                case 3:
                    direction = 90; break;
                case 4:
                    direction = 135; break;
                case 5:
                    direction = 180; break;
                case 6:
                    direction = 225; break;
                case 7:
                    direction = 270; break;
                case 8:
                    direction = 360; break;
            }
            return direction;
        }
    }

    public enum NPCType
    {
        zero,
        NORMAL,//1 普通
        TRANSFER_POINT,//2 传送点
        TASKTARGET_BATTLE,//3 任务目标，战斗,受任务限制，任务指定打这个npc，并且npc为3 才显示进入战斗按钮
        FUBEN_BATTLE,//4 副本战斗npc，绿野仙踪、宠物岛等，需要显示进入战斗按钮或者直接打
        MAP_EFFECT,//5 地图特效
        RESOURCE_POINT//6 资源点
    }

    public enum ZoneNpcType
    {
        Normal,//普通的NPC（配置表中配的，客户端独自控制的）列表
        QuestNpc,//任务控制的NPC列表
        NpcMonster//NPC怪列表
    }
}