using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 绿野仙踪-怪物位置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class WizardRaidPositionTemplateDBBase : TemplateDBBase<WizardRaidPositionTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, WizardRaidPositionTemplate> idKeyDic = new Dictionary<int, WizardRaidPositionTemplate>();
        
		protected static WizardRaidPositionTemplateDB _ins;
        public static WizardRaidPositionTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new WizardRaidPositionTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, WizardRaidPositionTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(WizardRaidPositionTemplate wizardraidpositiontemplate)
        {
            if (this.idKeyDic.ContainsKey(wizardraidpositiontemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + wizardraidpositiontemplate.Id);
                return false;
            }
            this.idKeyDic.Add(wizardraidpositiontemplate.Id, wizardraidpositiontemplate);
            return true;
        }

        public override WizardRaidPositionTemplate getTemplate(int id)
        {
            WizardRaidPositionTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get WizardRaidPositionTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_WizardRaidPositionTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				WizardRaidPositionTemplate wizardraidpositiontemplate = new WizardRaidPositionTemplate();
				//id，每个表都有
				wizardraidpositiontemplate.Id = reader.GetInt32(startIndex++);
		
				wizardraidpositiontemplate.x = reader.GetInt32(startIndex++);
	
				wizardraidpositiontemplate.y = reader.GetInt32(startIndex++);
	
				WizardRaidPositionTemplateDB.Instance.addTemplate(wizardraidpositiontemplate);
				}
			}
		}

}
}