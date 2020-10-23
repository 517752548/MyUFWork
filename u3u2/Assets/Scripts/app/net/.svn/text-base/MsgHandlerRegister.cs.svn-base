using System.Collections.Generic;

namespace app.net 
{
    /// <summary>
    /// GC消息处理注册管理，负责注册所有handler，每个handler自己注册自己的消息处理
    /// </summary>
    public class MsgHandlerRegister
    {
        private static List<IGCHandler> allHandler = null;

        public MsgHandlerRegister()
        {
            
        }

        public static void Init()
        {
            if (allHandler == null)
            {
                allHandler = new List<IGCHandler>();
                allHandler.Add(new PlayerGCHandler());
                allHandler.Add(new HumanGCHandler());
                allHandler.Add(new PetGCHandler());
                allHandler.Add(new CommonGCHandler());
                allHandler.Add(new ItemGCHandler());
                allHandler.Add(new MapGCHandler());
                allHandler.Add(new BattleGCHandler());
                allHandler.Add(new QuestGCHandler());
                allHandler.Add(new EquipGCHandler());
                allHandler.Add(new ExamGCHandler());
                allHandler.Add(new PubtaskGCHandler());
                allHandler.Add(new HumanskillGCHandler());
                allHandler.Add(new TradeGCHandler());
                allHandler.Add(new ActivityuiGCHandler());
                allHandler.Add(new ChatGCHandler());
                allHandler.Add(new RelationGCHandler());
                allHandler.Add(new MailGCHandler());
                allHandler.Add(new CorpsGCHandler());
                allHandler.Add(new RankGCHandler());
                allHandler.Add(new TeamGCHandler());
                allHandler.Add(new OnlinegiftGCHandler());
                allHandler.Add(new LifeskillGCHandler());
                allHandler.Add(new WizardraidGCHandler());
                allHandler.Add(new ThesweeneytaskGCHandler());
                allHandler.Add(new TreasuremapGCHandler());
                allHandler.Add(new TitleGCHandler());
                allHandler.Add(new ForagetaskGCHandler());
                allHandler.Add(new OvermanGCHandler());
                allHandler.Add(new MarryGCHandler());
                allHandler.Add(new NvnGCHandler());
                allHandler.Add(new ArenaGCHandler());
                allHandler.Add(new GoodactivityGCHandler());
                allHandler.Add(new WingGCHandler());
                allHandler.Add(new CorpstaskGCHandler());
                allHandler.Add(new PromoteGCHandler());
                allHandler.Add(new GuideGCHandler());
                allHandler.Add(new MysteryshopGCHandler());
                allHandler.Add(new TowerGCHandler());
                allHandler.Add(new CorpsbossGCHandler());
                allHandler.Add(new TimelimitGCHandler());
                allHandler.Add(new PlotdungeonGCHandler());
                allHandler.Add(new SiegedemonGCHandler());
                allHandler.Add(new GuajiGCHandler());
                allHandler.Add(new RingtaskGCHandler());
            }
        }
        
        public static void Clear()
        {
            if (allHandler != null)
            {
                allHandler.Clear();
                allHandler = null;
            }
        }
    }
}
