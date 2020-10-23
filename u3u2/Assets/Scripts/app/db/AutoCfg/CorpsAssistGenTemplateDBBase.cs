using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 辅助技能产出配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsAssistGenTemplateDBBase : TemplateDBBase<CorpsAssistGenTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsAssistGenTemplate> idKeyDic = new Dictionary<int, CorpsAssistGenTemplate>();
        
		protected static CorpsAssistGenTemplateDB _ins;
        public static CorpsAssistGenTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsAssistGenTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsAssistGenTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsAssistGenTemplate corpsassistgentemplate)
        {
            if (this.idKeyDic.ContainsKey(corpsassistgentemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpsassistgentemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpsassistgentemplate.Id, corpsassistgentemplate);
            return true;
        }

        public override CorpsAssistGenTemplate getTemplate(int id)
        {
            CorpsAssistGenTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsAssistGenTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsAssistGenTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsAssistGenTemplate corpsassistgentemplate = new CorpsAssistGenTemplate();
				//id，每个表都有
				corpsassistgentemplate.Id = reader.GetInt32(startIndex++);
		
				corpsassistgentemplate.assistId = reader.GetInt32(startIndex++);
	
				corpsassistgentemplate.assistLevel = reader.GetInt32(startIndex++);
	
				corpsassistgentemplate.costEnergy = reader.GetInt32(startIndex++);
	
				corpsassistgentemplate.rewardId = reader.GetInt32(startIndex++);
	
				corpsassistgentemplate.itemId = reader.GetInt32(startIndex++);
	
				corpsassistgentemplate.genDesc = reader.GetString(startIndex++);
	
				CorpsAssistGenTemplateDB.Instance.addTemplate(corpsassistgentemplate);
				}
			}
		}

}
}