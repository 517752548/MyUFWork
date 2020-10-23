using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 技能配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillTemplateDBBase : TemplateDBBase<SkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillTemplate> idKeyDic = new Dictionary<int, SkillTemplate>();
        
		protected static SkillTemplateDB _ins;
        public static SkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillTemplate skilltemplate)
        {
            if (this.idKeyDic.ContainsKey(skilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skilltemplate.Id, skilltemplate);
            return true;
        }

        public override SkillTemplate getTemplate(int id)
        {
            SkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillTemplate skilltemplate = new SkillTemplate();
				//id，每个表都有
				skilltemplate.Id = reader.GetInt32(startIndex++);
		
				skilltemplate.nameLangId = reader.GetInt64(startIndex++);
	
				skilltemplate.name = reader.GetString(startIndex++);
	
				skilltemplate.descLangId = reader.GetInt64(startIndex++);
	
				skilltemplate.descInfo = reader.GetString(startIndex++);
	
				skilltemplate.embedEffect = reader.GetInt32(startIndex++);
	
				skilltemplate.isPassive = reader.GetInt32(startIndex++);
	
				skilltemplate.skillTypeId = reader.GetInt32(startIndex++);
	
				skilltemplate.bubble = reader.GetString(startIndex++);
	
				skilltemplate.icon = reader.GetString(startIndex++);
	
				skilltemplate.notNeedShow = reader.GetInt32(startIndex++);
	
				skilltemplate.needShowOnRelease = reader.GetInt32(startIndex++);
	
				skilltemplate.costTypeId = reader.GetInt32(startIndex++);
	
				skilltemplate.costBase = reader.GetInt32(startIndex++);
	
				skilltemplate.costAdd = reader.GetInt32(startIndex++);
	
				skilltemplate.skillScore = reader.GetInt32(startIndex++);
	
				skilltemplate.upgradeCostPos = reader.GetInt32(startIndex++);
	
				skilltemplate.upgradeCostCoef = reader.GetInt32(startIndex++);
	
				SkillTemplateDB.Instance.addTemplate(skilltemplate);
				}
			}
		}

}
}