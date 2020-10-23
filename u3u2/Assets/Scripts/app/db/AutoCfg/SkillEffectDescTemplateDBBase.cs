using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 效果描述
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillEffectDescTemplateDBBase : TemplateDBBase<SkillEffectDescTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillEffectDescTemplate> idKeyDic = new Dictionary<int, SkillEffectDescTemplate>();
        
		protected static SkillEffectDescTemplateDB _ins;
        public static SkillEffectDescTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillEffectDescTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillEffectDescTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillEffectDescTemplate skilleffectdesctemplate)
        {
            if (this.idKeyDic.ContainsKey(skilleffectdesctemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skilleffectdesctemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skilleffectdesctemplate.Id, skilleffectdesctemplate);
            return true;
        }

        public override SkillEffectDescTemplate getTemplate(int id)
        {
            SkillEffectDescTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillEffectDescTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillEffectDescTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillEffectDescTemplate skilleffectdesctemplate = new SkillEffectDescTemplate();
				//id，每个表都有
				skilleffectdesctemplate.Id = reader.GetInt32(startIndex++);
		
				skilleffectdesctemplate.name = reader.GetString(startIndex++);
	
				skilleffectdesctemplate.bubble = reader.GetString(startIndex++);
	
				skilleffectdesctemplate.descInfo = reader.GetString(startIndex++);
	
				skilleffectdesctemplate.coef1Desc = reader.GetFloat(startIndex++);
	
				skilleffectdesctemplate.coef2Desc = reader.GetFloat(startIndex++);
	
				skilleffectdesctemplate.coef3Desc = reader.GetFloat(startIndex++);
	
				SkillEffectDescTemplateDB.Instance.addTemplate(skilleffectdesctemplate);
				}
			}
		}

}
}