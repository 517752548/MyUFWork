using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 生活技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillTemplateDBBase : TemplateDBBase<LifeSkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LifeSkillTemplate> idKeyDic = new Dictionary<int, LifeSkillTemplate>();
        
		protected static LifeSkillTemplateDB _ins;
        public static LifeSkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LifeSkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LifeSkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LifeSkillTemplate lifeskilltemplate)
        {
            if (this.idKeyDic.ContainsKey(lifeskilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + lifeskilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(lifeskilltemplate.Id, lifeskilltemplate);
            return true;
        }

        public override LifeSkillTemplate getTemplate(int id)
        {
            LifeSkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LifeSkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LifeSkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LifeSkillTemplate lifeskilltemplate = new LifeSkillTemplate();
				//id，每个表都有
				lifeskilltemplate.Id = reader.GetInt32(startIndex++);
		
				lifeskilltemplate.resourceType = reader.GetInt32(startIndex++);
	
				lifeskilltemplate.name = reader.GetString(startIndex++);
	
				LifeSkillTemplateDB.Instance.addTemplate(lifeskilltemplate);
				}
			}
		}

}
}