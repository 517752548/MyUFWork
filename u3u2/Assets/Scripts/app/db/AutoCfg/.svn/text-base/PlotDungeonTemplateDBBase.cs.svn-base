using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 剧情副本
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PlotDungeonTemplateDBBase : TemplateDBBase<PlotDungeonTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PlotDungeonTemplate> idKeyDic = new Dictionary<int, PlotDungeonTemplate>();
        
		protected static PlotDungeonTemplateDB _ins;
        public static PlotDungeonTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PlotDungeonTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PlotDungeonTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PlotDungeonTemplate plotdungeontemplate)
        {
            if (this.idKeyDic.ContainsKey(plotdungeontemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + plotdungeontemplate.Id);
                return false;
            }
            this.idKeyDic.Add(plotdungeontemplate.Id, plotdungeontemplate);
            return true;
        }

        public override PlotDungeonTemplate getTemplate(int id)
        {
            PlotDungeonTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PlotDungeonTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PlotDungeonTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PlotDungeonTemplate plotdungeontemplate = new PlotDungeonTemplate();
				//id，每个表都有
				plotdungeontemplate.Id = reader.GetInt32(startIndex++);
		
				plotdungeontemplate.plotDungeonLevel = reader.GetInt32(startIndex++);
	
				plotdungeontemplate.hardFlag = reader.GetInt32(startIndex++);
	
				plotdungeontemplate.triggerQuestId = reader.GetInt32(startIndex++);
	
				plotdungeontemplate.enemyArmyId = reader.GetInt32(startIndex++);
	
				plotdungeontemplate.showEnemyRewardId = reader.GetInt32(startIndex++);
	
				plotdungeontemplate.model3DId = reader.GetString(startIndex++);
	
				plotdungeontemplate.showRewardName = reader.GetString(startIndex++);
	
				plotdungeontemplate.chapterName = reader.GetString(startIndex++);
	
				plotdungeontemplate.dailyRewardId = reader.GetInt32(startIndex++);
	
				plotdungeontemplate.showDailyRewardId = reader.GetInt32(startIndex++);
	
				PlotDungeonTemplateDB.Instance.addTemplate(plotdungeontemplate);
				}
			}
		}

}
}