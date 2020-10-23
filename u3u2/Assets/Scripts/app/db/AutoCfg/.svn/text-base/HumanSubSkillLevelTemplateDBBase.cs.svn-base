using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 人物技能等级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class HumanSubSkillLevelTemplateDBBase : TemplateDBBase<HumanSubSkillLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, HumanSubSkillLevelTemplate> idKeyDic = new Dictionary<int, HumanSubSkillLevelTemplate>();
        
		protected static HumanSubSkillLevelTemplateDB _ins;
        public static HumanSubSkillLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new HumanSubSkillLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, HumanSubSkillLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(HumanSubSkillLevelTemplate humansubskillleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(humansubskillleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + humansubskillleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(humansubskillleveltemplate.Id, humansubskillleveltemplate);
            return true;
        }

        public override HumanSubSkillLevelTemplate getTemplate(int id)
        {
            HumanSubSkillLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get HumanSubSkillLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_HumanSubSkillLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				HumanSubSkillLevelTemplate humansubskillleveltemplate = new HumanSubSkillLevelTemplate();
				//id，每个表都有
				humansubskillleveltemplate.Id = reader.GetInt32(startIndex++);
		
				humansubskillleveltemplate.subSkillId = reader.GetInt32(startIndex++);
	
				humansubskillleveltemplate.name = reader.GetString(startIndex++);
	
				humansubskillleveltemplate.subSkillLevel = reader.GetInt32(startIndex++);
	
				humansubskillleveltemplate.needMainSkillLevel = reader.GetInt32(startIndex++);
	
				humansubskillleveltemplate.needHumanLevel = reader.GetInt32(startIndex++);
	
		        humansubskillleveltemplate.humanSubSkillCostList = new List<HumanSubSkillCost>(10);
		        for (int i = 0; i < 10; i++)
		        {
		            humansubskillleveltemplate.humanSubSkillCostList.Add(new HumanSubSkillCost(reader, startIndex));
		            startIndex += 1;
		        }
	
				humansubskillleveltemplate.subSkillBookId = reader.GetInt32(startIndex++);
	
				HumanSubSkillLevelTemplateDB.Instance.addTemplate(humansubskillleveltemplate);
				}
			}
		}

}
}