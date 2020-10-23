using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 除暴安良任务组模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TheSweeneyTaskGroupTemplateDBBase : TemplateDBBase<TheSweeneyTaskGroupTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TheSweeneyTaskGroupTemplate> idKeyDic = new Dictionary<int, TheSweeneyTaskGroupTemplate>();
        
		protected static TheSweeneyTaskGroupTemplateDB _ins;
        public static TheSweeneyTaskGroupTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TheSweeneyTaskGroupTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TheSweeneyTaskGroupTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TheSweeneyTaskGroupTemplate thesweeneytaskgrouptemplate)
        {
            if (this.idKeyDic.ContainsKey(thesweeneytaskgrouptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + thesweeneytaskgrouptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(thesweeneytaskgrouptemplate.Id, thesweeneytaskgrouptemplate);
            return true;
        }

        public override TheSweeneyTaskGroupTemplate getTemplate(int id)
        {
            TheSweeneyTaskGroupTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TheSweeneyTaskGroupTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TheSweeneyTaskGroupTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TheSweeneyTaskGroupTemplate thesweeneytaskgrouptemplate = new TheSweeneyTaskGroupTemplate();
				//id，每个表都有
				thesweeneytaskgrouptemplate.Id = reader.GetInt32(startIndex++);
		
				thesweeneytaskgrouptemplate.questGroupId = reader.GetInt32(startIndex++);
	
				thesweeneytaskgrouptemplate.questId = reader.GetInt32(startIndex++);
	
				thesweeneytaskgrouptemplate.weight = reader.GetInt32(startIndex++);
	
				TheSweeneyTaskGroupTemplateDB.Instance.addTemplate(thesweeneytaskgrouptemplate);
				}
			}
		}

}
}