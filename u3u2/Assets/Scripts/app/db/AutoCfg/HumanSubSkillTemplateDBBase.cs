using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 人物技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class HumanSubSkillTemplateDBBase : TemplateDBBase<HumanSubSkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, HumanSubSkillTemplate> idKeyDic = new Dictionary<int, HumanSubSkillTemplate>();
        
		protected static HumanSubSkillTemplateDB _ins;
        public static HumanSubSkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new HumanSubSkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, HumanSubSkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(HumanSubSkillTemplate humansubskilltemplate)
        {
            if (this.idKeyDic.ContainsKey(humansubskilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + humansubskilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(humansubskilltemplate.Id, humansubskilltemplate);
            return true;
        }

        public override HumanSubSkillTemplate getTemplate(int id)
        {
            HumanSubSkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get HumanSubSkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_HumanSubSkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				HumanSubSkillTemplate humansubskilltemplate = new HumanSubSkillTemplate();
				//id，每个表都有
				humansubskilltemplate.Id = reader.GetInt32(startIndex++);
		
				humansubskilltemplate.name = reader.GetString(startIndex++);
	
				humansubskilltemplate.needHumanLevel = reader.GetInt32(startIndex++);
	
				humansubskilltemplate.needMainSkillLevel = reader.GetInt32(startIndex++);
	
				humansubskilltemplate.subSkillPosition = reader.GetInt32(startIndex++);
	
				HumanSubSkillTemplateDB.Instance.addTemplate(humansubskilltemplate);
				}
			}
		}

}
}