using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 剧情战报配置表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class StoryBattleTemplateDBBase : TemplateDBBase<StoryBattleTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, StoryBattleTemplate> idKeyDic = new Dictionary<int, StoryBattleTemplate>();
        
		protected static StoryBattleTemplateDB _ins;
        public static StoryBattleTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new StoryBattleTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, StoryBattleTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(StoryBattleTemplate storybattletemplate)
        {
            if (this.idKeyDic.ContainsKey(storybattletemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + storybattletemplate.Id);
                return false;
            }
            this.idKeyDic.Add(storybattletemplate.Id, storybattletemplate);
            return true;
        }

        public override StoryBattleTemplate getTemplate(int id)
        {
            StoryBattleTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get StoryBattleTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_StoryBattleTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				StoryBattleTemplate storybattletemplate = new StoryBattleTemplate();
				//id，每个表都有
				storybattletemplate.Id = reader.GetInt32(startIndex++);
		
				storybattletemplate.storyId = reader.GetInt32(startIndex++);
	
				storybattletemplate.time = reader.GetInt32(startIndex++);
	
				storybattletemplate.round = reader.GetInt32(startIndex++);
	
				storybattletemplate.eventType = reader.GetInt32(startIndex++);
	
				storybattletemplate.status = reader.GetInt32(startIndex++);
	
				storybattletemplate.targetType = reader.GetInt32(startIndex++);
	
				storybattletemplate.targetId = reader.GetString(startIndex++);
	
				storybattletemplate.targetName = reader.GetString(startIndex++);
	
				storybattletemplate.modelName = reader.GetString(startIndex++);
	
				storybattletemplate.skillId = reader.GetInt32(startIndex++);
	
				storybattletemplate.skillTargets = reader.GetString(startIndex++);
	
				storybattletemplate.posX = reader.GetInt32(startIndex++);
	
				storybattletemplate.posY = reader.GetInt32(startIndex++);
	
				storybattletemplate.hp = reader.GetInt32(startIndex++);
	
				storybattletemplate.action = reader.GetString(startIndex++);
	
				storybattletemplate.direction = reader.GetInt32(startIndex++);
	
				storybattletemplate.speak = reader.GetString(startIndex++);
	
				StoryBattleTemplateDB.Instance.addTemplate(storybattletemplate);
				}
			}
		}

}
}