using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 护送粮草任务组模版
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ForageTaskGroupTemplateDBBase : TemplateDBBase<ForageTaskGroupTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ForageTaskGroupTemplate> idKeyDic = new Dictionary<int, ForageTaskGroupTemplate>();
        
		protected static ForageTaskGroupTemplateDB _ins;
        public static ForageTaskGroupTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ForageTaskGroupTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ForageTaskGroupTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ForageTaskGroupTemplate foragetaskgrouptemplate)
        {
            if (this.idKeyDic.ContainsKey(foragetaskgrouptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + foragetaskgrouptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(foragetaskgrouptemplate.Id, foragetaskgrouptemplate);
            return true;
        }

        public override ForageTaskGroupTemplate getTemplate(int id)
        {
            ForageTaskGroupTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ForageTaskGroupTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ForageTaskGroupTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ForageTaskGroupTemplate foragetaskgrouptemplate = new ForageTaskGroupTemplate();
				//id，每个表都有
				foragetaskgrouptemplate.Id = reader.GetInt32(startIndex++);
		
				foragetaskgrouptemplate.questGroupId = reader.GetInt32(startIndex++);
	
				foragetaskgrouptemplate.questId = reader.GetInt32(startIndex++);
	
				foragetaskgrouptemplate.forageStar = reader.GetInt32(startIndex++);
	
				foragetaskgrouptemplate.weight = reader.GetInt32(startIndex++);
	
				ForageTaskGroupTemplateDB.Instance.addTemplate(foragetaskgrouptemplate);
				}
			}
		}

}
}