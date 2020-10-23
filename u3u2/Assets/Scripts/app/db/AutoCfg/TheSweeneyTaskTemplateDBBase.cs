using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 除暴安良任务模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TheSweeneyTaskTemplateDBBase : TemplateDBBase<TheSweeneyTaskTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TheSweeneyTaskTemplate> idKeyDic = new Dictionary<int, TheSweeneyTaskTemplate>();
        
		protected static TheSweeneyTaskTemplateDB _ins;
        public static TheSweeneyTaskTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TheSweeneyTaskTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TheSweeneyTaskTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TheSweeneyTaskTemplate thesweeneytasktemplate)
        {
            if (this.idKeyDic.ContainsKey(thesweeneytasktemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + thesweeneytasktemplate.Id);
                return false;
            }
            this.idKeyDic.Add(thesweeneytasktemplate.Id, thesweeneytasktemplate);
            return true;
        }

        public override TheSweeneyTaskTemplate getTemplate(int id)
        {
            TheSweeneyTaskTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TheSweeneyTaskTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TheSweeneyTaskTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TheSweeneyTaskTemplate thesweeneytasktemplate = new TheSweeneyTaskTemplate();
				//id，每个表都有
				thesweeneytasktemplate.Id = reader.GetInt32(startIndex++);
		
				thesweeneytasktemplate.levelMin = reader.GetInt32(startIndex++);
	
				thesweeneytasktemplate.levelMax = reader.GetInt32(startIndex++);
	
				thesweeneytasktemplate.questGroupId = reader.GetInt32(startIndex++);
	
				thesweeneytasktemplate.specialAwards = reader.GetInt32(startIndex++);
	
				TheSweeneyTaskTemplateDB.Instance.addTemplate(thesweeneytasktemplate);
				}
			}
		}

}
}