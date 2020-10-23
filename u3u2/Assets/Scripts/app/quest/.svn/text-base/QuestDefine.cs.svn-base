using app.db;

public class QuestDefine
{
    public enum QuestType
    {
        NONE,
        MAIN,//1主线任务
        SUBMAIN,//2支线任务
        JIUGUAN,//3酒馆任务
        TEAMQUEST,//4依赖队伍存在的任务
        CHUBAOANLIANG,//5除暴安良任务
        BAOTU,//6宝图任务
        YUNLIANG,//7送粮
        BANGPAI,//8帮派
        XIANSHISHAGUAI, //9限时杀怪
        XIANSHINPC,//10限时npc
        QIRIMUBIAO,//11七日目标任务
        PUTONGMOZU,//12普通魔族副本任务
        KUNNANMOZU,//13困难魔族副本任务
        HUAN//环任务
    }

    public static string GetQuestTypeName(int questtype)
    {
        string str="任务类型";
        switch (questtype)
        {
            case (int)QuestType.MAIN:
                str = "主线任务";
                break;
            case (int)QuestType.SUBMAIN:
                str = "支线任务";
                break;
            case (int)QuestType.JIUGUAN:
                str = "酒馆";
                break;
            case (int)QuestType.TEAMQUEST:
                str = "依赖队伍的任务";
                break;
            case (int)QuestType.CHUBAOANLIANG:
                str = "除暴安良";
                break;
            case (int)QuestType.BAOTU:
                str = "宝图任务";
                break;
            case (int)QuestType.YUNLIANG:
                str = "护送粮草";
                break;
            case (int)QuestType.BANGPAI:
                str = "帮派任务";
                break;
            case (int)QuestType.XIANSHISHAGUAI:
            case (int)QuestType.XIANSHINPC:
                str = "限时任务";
                break;
            case (int)QuestType.QIRIMUBIAO:
                str = "七日目标";
                break;
            case (int)QuestType.PUTONGMOZU:
                str = "魔族副本-普通";
                break;
            case (int)QuestType.KUNNANMOZU:
                str = "魔族副本-困难";
                break;
            case (int)QuestType.HUAN:
                str = "环任务";
                break;
        }
        return str;
    }
    
    /// <summary>
    /// 任务状态
    /// </summary>
    public enum QuestStatus
    {
        /** 0初始默认状态 */
		INIT,
        /** 1可完成状态，但未领取奖励 */
        CAN_FINISH,
        /** 2已经接受任务，但没有达到完成条件或没有完成任务 */
		ACCEPTED,
        /** 3可接，但未接 */
        CAN_ACCEPT,
        /** 4可见，但不可接 */
		CAN_NOT_ACCEPT,
        /** 5已完成，领取了奖励 */
		FINISHED,
        /** 6已放弃 */
		GIVEUP

        ///** 初始默认状态 */
        //INIT(0, 0),
        ///** 已经接受任务，但没有达到完成条件或没有完成任务 */
        //ACCEPTED(1, 2),
        ///** 可完成状态，但未领取奖励 */
        //CAN_FINISH(2, 1),
        ///** 已完成，领取了奖励 */
        //FINISHED(3, 5),

        ///** 可接，但未接 */
        //CAN_ACCEPT(4, 3),
        ///** 可见，但不可接 */
        //CAN_NOT_ACCEPT(5, 4),
        ///** 已放弃 */
		//GIVEUP(6, 6),

        ///** 无效任务 */
        //INVALID(9, 9),

    }

    public static string GetQuestStatusName(int questStatus)
    {
        string str="任务状态";
        switch (questStatus)
        {
            case (int)QuestDefine.QuestStatus.ACCEPTED:
                str = "(已接)";
                break;
            case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                str = "(可接)";
                break;
            case (int)QuestDefine.QuestStatus.CAN_FINISH:
                str = "(可交付)";
                break;
            case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                str = "(不可接)";
                break;
        }
        return str;
    }

    /// <summary>
    /// 任务目标类型
    /// </summary>
    public enum QuestTargetType
    {
        CHAT,//0对话
        COUNT,//1计数(杀怪，掉落)
        PLAYERLEVEL,//2主将达到一定等级
    }
    /// <summary>
    /// 计数类型 任务的分类
    /// </summary>
    public enum QuestTargetCountType
    {
        NONE,
        KILLMONSTER,//a 1 杀怪计数 ; b 怪物ID（非怪物组，单个怪物）; c:次数/数量
        FIGHTNPC,//a 2 战胜指定的NPC ; b NPC的ID ; c:次数/数量
        COLLECTITEM,//a 3 收集指定的物品 ; b 物品ID ; c:次数/数量
        USEITEM//a 4 使用物品  ; b 物品ID ; c：次数/数量
    }

    /// <summary>
    /// 获取任务是否需要战斗
    /// </summary>
    /// <param name="questTarget"></param>
    /// <returns></returns>
    public static bool IsFightQuest(SpecialDestination questTarget)
    {
        if (questTarget!=null&&questTarget.type == (int)QuestTargetType.COUNT)
        {
            if (questTarget.param1st==QuestTargetCountType.KILLMONSTER.ToString()
                || questTarget.param1st == QuestTargetCountType.FIGHTNPC.ToString()
                || questTarget.param1st == QuestTargetCountType.COLLECTITEM.ToString())
            {
                return true;
            }
        }
        return false;
    }
}
