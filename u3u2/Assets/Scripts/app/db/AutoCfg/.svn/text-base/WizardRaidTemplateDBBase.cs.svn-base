using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 绿野仙踪-副本配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class WizardRaidTemplateDBBase : TemplateDBBase<WizardRaidTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, WizardRaidTemplate> idKeyDic = new Dictionary<int, WizardRaidTemplate>();
        
		protected static WizardRaidTemplateDB _ins;
        public static WizardRaidTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new WizardRaidTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, WizardRaidTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(WizardRaidTemplate wizardraidtemplate)
        {
            if (this.idKeyDic.ContainsKey(wizardraidtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + wizardraidtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(wizardraidtemplate.Id, wizardraidtemplate);
            return true;
        }

        public override WizardRaidTemplate getTemplate(int id)
        {
            WizardRaidTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get WizardRaidTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_WizardRaidTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				WizardRaidTemplate wizardraidtemplate = new WizardRaidTemplate();
				//id，每个表都有
				wizardraidtemplate.Id = reader.GetInt32(startIndex++);
		
				wizardraidtemplate.raidTypeId = reader.GetInt32(startIndex++);
	
				wizardraidtemplate.levelMin = reader.GetInt32(startIndex++);
	
				wizardraidtemplate.levelMax = reader.GetInt32(startIndex++);
	
				wizardraidtemplate.pumpkinNpcId = reader.GetInt32(startIndex++);
	
				wizardraidtemplate.bossNpcIdList = new List<int>(3);
				for (int i = 0; i < 3; i++)
		        {
		            wizardraidtemplate.bossNpcIdList.Add(reader.GetInt32(startIndex++));
		        }
	
				wizardraidtemplate.bossRewardIdList = new List<int>(3);
				for (int i = 0; i < 3; i++)
		        {
		            wizardraidtemplate.bossRewardIdList.Add(reader.GetInt32(startIndex++));
		        }
	
				wizardraidtemplate.rewardId = reader.GetInt32(startIndex++);
	
				WizardRaidTemplateDB.Instance.addTemplate(wizardraidtemplate);
				}
			}
		}

}
}