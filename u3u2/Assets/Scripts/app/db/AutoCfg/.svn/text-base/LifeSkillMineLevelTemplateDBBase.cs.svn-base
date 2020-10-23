using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 生活技能-采矿-等级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillMineLevelTemplateDBBase : TemplateDBBase<LifeSkillMineLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LifeSkillMineLevelTemplate> idKeyDic = new Dictionary<int, LifeSkillMineLevelTemplate>();
        
		protected static LifeSkillMineLevelTemplateDB _ins;
        public static LifeSkillMineLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LifeSkillMineLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LifeSkillMineLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LifeSkillMineLevelTemplate lifeskillmineleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(lifeskillmineleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + lifeskillmineleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(lifeskillmineleveltemplate.Id, lifeskillmineleveltemplate);
            return true;
        }

        public override LifeSkillMineLevelTemplate getTemplate(int id)
        {
            LifeSkillMineLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LifeSkillMineLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LifeSkillMineLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LifeSkillMineLevelTemplate lifeskillmineleveltemplate = new LifeSkillMineLevelTemplate();
				//id，每个表都有
				lifeskillmineleveltemplate.Id = reader.GetInt32(startIndex++);
		
				lifeskillmineleveltemplate.currencyType = reader.GetInt32(startIndex++);
	
				lifeskillmineleveltemplate.currencyNum = reader.GetInt32(startIndex++);
	
				LifeSkillMineLevelTemplateDB.Instance.addTemplate(lifeskillmineleveltemplate);
				}
			}
		}

}
}