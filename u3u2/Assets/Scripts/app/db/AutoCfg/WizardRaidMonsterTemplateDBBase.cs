using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 绿野仙踪-刷怪配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class WizardRaidMonsterTemplateDBBase : TemplateDBBase<WizardRaidMonsterTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, WizardRaidMonsterTemplate> idKeyDic = new Dictionary<int, WizardRaidMonsterTemplate>();
        
		protected static WizardRaidMonsterTemplateDB _ins;
        public static WizardRaidMonsterTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new WizardRaidMonsterTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, WizardRaidMonsterTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(WizardRaidMonsterTemplate wizardraidmonstertemplate)
        {
            if (this.idKeyDic.ContainsKey(wizardraidmonstertemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + wizardraidmonstertemplate.Id);
                return false;
            }
            this.idKeyDic.Add(wizardraidmonstertemplate.Id, wizardraidmonstertemplate);
            return true;
        }

        public override WizardRaidMonsterTemplate getTemplate(int id)
        {
            WizardRaidMonsterTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get WizardRaidMonsterTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_WizardRaidMonsterTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				WizardRaidMonsterTemplate wizardraidmonstertemplate = new WizardRaidMonsterTemplate();
				//id，每个表都有
				wizardraidmonstertemplate.Id = reader.GetInt32(startIndex++);
		
				wizardraidmonstertemplate.raidId = reader.GetInt32(startIndex++);
	
				wizardraidmonstertemplate.raidType = reader.GetInt32(startIndex++);
	
				wizardraidmonstertemplate.monsterNpcId = reader.GetInt32(startIndex++);
	
				wizardraidmonstertemplate.startTime = reader.GetInt32(startIndex++);
	
				WizardRaidMonsterTemplateDB.Instance.addTemplate(wizardraidmonstertemplate);
				}
			}
		}

}
}