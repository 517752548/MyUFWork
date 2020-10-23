using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 技能效果配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillAddTemplateDBBase : TemplateDBBase<SkillAddTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillAddTemplate> idKeyDic = new Dictionary<int, SkillAddTemplate>();
        
		protected static SkillAddTemplateDB _ins;
        public static SkillAddTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillAddTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillAddTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillAddTemplate skilladdtemplate)
        {
            if (this.idKeyDic.ContainsKey(skilladdtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skilladdtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skilladdtemplate.Id, skilladdtemplate);
            return true;
        }

        public override SkillAddTemplate getTemplate(int id)
        {
            SkillAddTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillAddTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillAddTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillAddTemplate skilladdtemplate = new SkillAddTemplate();
				//id，每个表都有
				skilladdtemplate.Id = reader.GetInt32(startIndex++);
		
				skilladdtemplate.skillId = reader.GetInt32(startIndex++);
	
				skilladdtemplate.mindId = reader.GetInt32(startIndex++);
	
				skilladdtemplate.mindLevelMin = reader.GetInt32(startIndex++);
	
				skilladdtemplate.mindLevelMax = reader.GetInt32(startIndex++);
	
				skilladdtemplate.skillLevelMin = reader.GetInt32(startIndex++);
	
				skilladdtemplate.skillLevelMax = reader.GetInt32(startIndex++);
	
				skilladdtemplate.effectIdList = new List<int>(5);
				for (int i = 0; i < 5; i++)
		        {
		            skilladdtemplate.effectIdList.Add(reader.GetInt32(startIndex++));
		        }
	
				SkillAddTemplateDB.Instance.addTemplate(skilladdtemplate);
				}
			}
		}

}
}