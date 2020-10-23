using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 绿野仙踪-波数配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class WizardRaidWaveTemplateDBBase : TemplateDBBase<WizardRaidWaveTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, WizardRaidWaveTemplate> idKeyDic = new Dictionary<int, WizardRaidWaveTemplate>();
        
		protected static WizardRaidWaveTemplateDB _ins;
        public static WizardRaidWaveTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new WizardRaidWaveTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, WizardRaidWaveTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(WizardRaidWaveTemplate wizardraidwavetemplate)
        {
            if (this.idKeyDic.ContainsKey(wizardraidwavetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + wizardraidwavetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(wizardraidwavetemplate.Id, wizardraidwavetemplate);
            return true;
        }

        public override WizardRaidWaveTemplate getTemplate(int id)
        {
            WizardRaidWaveTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get WizardRaidWaveTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_WizardRaidWaveTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				WizardRaidWaveTemplate wizardraidwavetemplate = new WizardRaidWaveTemplate();
				//id，每个表都有
				wizardraidwavetemplate.Id = reader.GetInt32(startIndex++);
		
				wizardraidwavetemplate.startTime = reader.GetInt32(startIndex++);
	
				WizardRaidWaveTemplateDB.Instance.addTemplate(wizardraidwavetemplate);
				}
			}
		}

}
}