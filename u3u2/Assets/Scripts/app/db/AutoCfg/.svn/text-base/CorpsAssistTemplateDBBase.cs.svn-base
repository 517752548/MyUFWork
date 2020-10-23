using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 辅助技能配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsAssistTemplateDBBase : TemplateDBBase<CorpsAssistTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsAssistTemplate> idKeyDic = new Dictionary<int, CorpsAssistTemplate>();
        
		protected static CorpsAssistTemplateDB _ins;
        public static CorpsAssistTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsAssistTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsAssistTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsAssistTemplate corpsassisttemplate)
        {
            if (this.idKeyDic.ContainsKey(corpsassisttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpsassisttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpsassisttemplate.Id, corpsassisttemplate);
            return true;
        }

        public override CorpsAssistTemplate getTemplate(int id)
        {
            CorpsAssistTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsAssistTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsAssistTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsAssistTemplate corpsassisttemplate = new CorpsAssistTemplate();
				//id，每个表都有
				corpsassisttemplate.Id = reader.GetInt32(startIndex++);
		
				corpsassisttemplate.assistId = reader.GetInt32(startIndex++);
	
				corpsassisttemplate.icon = reader.GetString(startIndex++);
	
				corpsassisttemplate.assistName = reader.GetString(startIndex++);
	
				corpsassisttemplate.assistDesc = reader.GetString(startIndex++);
	
				corpsassisttemplate.isCrit = reader.GetInt32(startIndex++);
	
				corpsassisttemplate.genType = reader.GetInt32(startIndex++);
	
				CorpsAssistTemplateDB.Instance.addTemplate(corpsassisttemplate);
				}
			}
		}

}
}