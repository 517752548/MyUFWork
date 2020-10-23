using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 剧情配置表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class StoryTemplateDBBase : TemplateDBBase<StoryTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, StoryTemplate> idKeyDic = new Dictionary<int, StoryTemplate>();
        
		protected static StoryTemplateDB _ins;
        public static StoryTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new StoryTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, StoryTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(StoryTemplate storytemplate)
        {
            if (this.idKeyDic.ContainsKey(storytemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + storytemplate.Id);
                return false;
            }
            this.idKeyDic.Add(storytemplate.Id, storytemplate);
            return true;
        }

        public override StoryTemplate getTemplate(int id)
        {
            StoryTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get StoryTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_StoryTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				StoryTemplate storytemplate = new StoryTemplate();
				//id，每个表都有
				storytemplate.Id = reader.GetInt32(startIndex++);
		
				storytemplate.storyId = reader.GetInt32(startIndex++);
	
				storytemplate.storyType = reader.GetInt32(startIndex++);
	
				storytemplate.content = reader.GetString(startIndex++);
	
				storytemplate.isNpc = reader.GetInt32(startIndex++);
	
				StoryTemplateDB.Instance.addTemplate(storytemplate);
				}
			}
		}

}
}