using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 帮派任务模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsTaskTemplateDBBase : TemplateDBBase<CorpsTaskTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsTaskTemplate> idKeyDic = new Dictionary<int, CorpsTaskTemplate>();
        
		protected static CorpsTaskTemplateDB _ins;
        public static CorpsTaskTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsTaskTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsTaskTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsTaskTemplate corpstasktemplate)
        {
            if (this.idKeyDic.ContainsKey(corpstasktemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpstasktemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpstasktemplate.Id, corpstasktemplate);
            return true;
        }

        public override CorpsTaskTemplate getTemplate(int id)
        {
            CorpsTaskTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsTaskTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsTaskTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsTaskTemplate corpstasktemplate = new CorpsTaskTemplate();
				//id，每个表都有
				corpstasktemplate.Id = reader.GetInt32(startIndex++);
		
				corpstasktemplate.corpsLevel = reader.GetInt32(startIndex++);
	
				corpstasktemplate.questId = reader.GetInt32(startIndex++);
	
				CorpsTaskTemplateDB.Instance.addTemplate(corpstasktemplate);
				}
			}
		}

}
}