using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 辅助技能消耗配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsAssistCostTemplateDBBase : TemplateDBBase<CorpsAssistCostTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsAssistCostTemplate> idKeyDic = new Dictionary<int, CorpsAssistCostTemplate>();
        
		protected static CorpsAssistCostTemplateDB _ins;
        public static CorpsAssistCostTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsAssistCostTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsAssistCostTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsAssistCostTemplate corpsassistcosttemplate)
        {
            if (this.idKeyDic.ContainsKey(corpsassistcosttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpsassistcosttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpsassistcosttemplate.Id, corpsassistcosttemplate);
            return true;
        }

        public override CorpsAssistCostTemplate getTemplate(int id)
        {
            CorpsAssistCostTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsAssistCostTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsAssistCostTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsAssistCostTemplate corpsassistcosttemplate = new CorpsAssistCostTemplate();
				//id，每个表都有
				corpsassistcosttemplate.Id = reader.GetInt32(startIndex++);
		
				corpsassistcosttemplate.assistLevel = reader.GetInt32(startIndex++);
	
				corpsassistcosttemplate.playerLevel = reader.GetInt32(startIndex++);
	
				corpsassistcosttemplate.corpsLevel = reader.GetInt32(startIndex++);
	
				corpsassistcosttemplate.sjLevel = reader.GetInt32(startIndex++);
	
				corpsassistcosttemplate.costCurrency = reader.GetInt32(startIndex++);
	
				corpsassistcosttemplate.costContri = reader.GetInt32(startIndex++);
	
				CorpsAssistCostTemplateDB.Instance.addTemplate(corpsassistcosttemplate);
				}
			}
		}

}
}