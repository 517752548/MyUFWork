using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 七日目标
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class Day7TargetTemplateDBBase : TemplateDBBase<Day7TargetTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, Day7TargetTemplate> idKeyDic = new Dictionary<int, Day7TargetTemplate>();
        
		protected static Day7TargetTemplateDB _ins;
        public static Day7TargetTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new Day7TargetTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, Day7TargetTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(Day7TargetTemplate day7targettemplate)
        {
            if (this.idKeyDic.ContainsKey(day7targettemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + day7targettemplate.Id);
                return false;
            }
            this.idKeyDic.Add(day7targettemplate.Id, day7targettemplate);
            return true;
        }

        public override Day7TargetTemplate getTemplate(int id)
        {
            Day7TargetTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get Day7TargetTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_Day7TargetTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				Day7TargetTemplate day7targettemplate = new Day7TargetTemplate();
				//id，每个表都有
				day7targettemplate.Id = reader.GetInt32(startIndex++);
		
				day7targettemplate.day = reader.GetInt32(startIndex++);
	
				day7targettemplate.questId = reader.GetInt32(startIndex++);
	
				Day7TargetTemplateDB.Instance.addTemplate(day7targettemplate);
				}
			}
		}

}
}