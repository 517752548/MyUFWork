using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 人物心法对应人物技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class HumanMainSkillToSubSkillTemplateDBBase : TemplateDBBase<HumanMainSkillToSubSkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, HumanMainSkillToSubSkillTemplate> idKeyDic = new Dictionary<int, HumanMainSkillToSubSkillTemplate>();
        
		protected static HumanMainSkillToSubSkillTemplateDB _ins;
        public static HumanMainSkillToSubSkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new HumanMainSkillToSubSkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, HumanMainSkillToSubSkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(HumanMainSkillToSubSkillTemplate humanmainskilltosubskilltemplate)
        {
            if (this.idKeyDic.ContainsKey(humanmainskilltosubskilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + humanmainskilltosubskilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(humanmainskilltosubskilltemplate.Id, humanmainskilltosubskilltemplate);
            return true;
        }

        public override HumanMainSkillToSubSkillTemplate getTemplate(int id)
        {
            HumanMainSkillToSubSkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get HumanMainSkillToSubSkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_HumanMainSkillToSubSkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				HumanMainSkillToSubSkillTemplate humanmainskilltosubskilltemplate = new HumanMainSkillToSubSkillTemplate();
				//id，每个表都有
				humanmainskilltosubskilltemplate.Id = reader.GetInt32(startIndex++);
		
				humanmainskilltosubskilltemplate.name = reader.GetString(startIndex++);
	
				humanmainskilltosubskilltemplate.mainSkillId = reader.GetInt32(startIndex++);
	
				humanmainskilltosubskilltemplate.subSkillId = reader.GetInt32(startIndex++);
	
				humanmainskilltosubskilltemplate.descInfo = reader.GetString(startIndex++);
	
				humanmainskilltosubskilltemplate.mindCoefDesc = reader.GetFloat(startIndex++);
	
				humanmainskilltosubskilltemplate.skillCoefDesc = reader.GetFloat(startIndex++);
	
				humanmainskilltosubskilltemplate.coef1Desc = reader.GetFloat(startIndex++);
	
				humanmainskilltosubskilltemplate.coef2Desc = reader.GetFloat(startIndex++);
	
				HumanMainSkillToSubSkillTemplateDB.Instance.addTemplate(humanmainskilltosubskilltemplate);
				}
			}
		}

}
}