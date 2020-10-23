using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 人物心法等级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class HumanMainSkillLevelTemplateDBBase : TemplateDBBase<HumanMainSkillLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, HumanMainSkillLevelTemplate> idKeyDic = new Dictionary<int, HumanMainSkillLevelTemplate>();
        
		protected static HumanMainSkillLevelTemplateDB _ins;
        public static HumanMainSkillLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new HumanMainSkillLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, HumanMainSkillLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(HumanMainSkillLevelTemplate humanmainskillleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(humanmainskillleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + humanmainskillleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(humanmainskillleveltemplate.Id, humanmainskillleveltemplate);
            return true;
        }

        public override HumanMainSkillLevelTemplate getTemplate(int id)
        {
            HumanMainSkillLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get HumanMainSkillLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_HumanMainSkillLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				HumanMainSkillLevelTemplate humanmainskillleveltemplate = new HumanMainSkillLevelTemplate();
				//id，每个表都有
				humanmainskillleveltemplate.Id = reader.GetInt32(startIndex++);
		
				humanmainskillleveltemplate.currencyType1 = reader.GetInt32(startIndex++);
	
				humanmainskillleveltemplate.currencyNum1 = reader.GetInt32(startIndex++);
	
				humanmainskillleveltemplate.currencyType2 = reader.GetInt32(startIndex++);
	
				humanmainskillleveltemplate.currencyNum2 = reader.GetInt32(startIndex++);
	
				HumanMainSkillLevelTemplateDB.Instance.addTemplate(humanmainskillleveltemplate);
				}
			}
		}

}
}