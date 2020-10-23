using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * buff配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillBuffTemplateDBBase : TemplateDBBase<SkillBuffTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillBuffTemplate> idKeyDic = new Dictionary<int, SkillBuffTemplate>();
        
		protected static SkillBuffTemplateDB _ins;
        public static SkillBuffTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillBuffTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillBuffTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillBuffTemplate skillbufftemplate)
        {
            if (this.idKeyDic.ContainsKey(skillbufftemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skillbufftemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skillbufftemplate.Id, skillbufftemplate);
            return true;
        }

        public override SkillBuffTemplate getTemplate(int id)
        {
            SkillBuffTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillBuffTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillBuffTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillBuffTemplate skillbufftemplate = new SkillBuffTemplate();
				//id，每个表都有
				skillbufftemplate.Id = reader.GetInt32(startIndex++);
		
				skillbufftemplate.nameLangId = reader.GetInt64(startIndex++);
	
				skillbufftemplate.name = reader.GetString(startIndex++);
	
				skillbufftemplate.effect = reader.GetString(startIndex++);
	
				skillbufftemplate.effectShowType = reader.GetInt32(startIndex++);
	
				skillbufftemplate.buffCatalogId = reader.GetInt32(startIndex++);
	
				SkillBuffTemplateDB.Instance.addTemplate(skillbufftemplate);
				}
			}
		}

}
}