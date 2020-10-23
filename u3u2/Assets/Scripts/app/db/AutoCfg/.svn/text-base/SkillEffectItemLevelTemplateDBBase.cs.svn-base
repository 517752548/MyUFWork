using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 仙符升级配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillEffectItemLevelTemplateDBBase : TemplateDBBase<SkillEffectItemLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillEffectItemLevelTemplate> idKeyDic = new Dictionary<int, SkillEffectItemLevelTemplate>();
        
		protected static SkillEffectItemLevelTemplateDB _ins;
        public static SkillEffectItemLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillEffectItemLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillEffectItemLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillEffectItemLevelTemplate skilleffectitemleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(skilleffectitemleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skilleffectitemleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skilleffectitemleveltemplate.Id, skilleffectitemleveltemplate);
            return true;
        }

        public override SkillEffectItemLevelTemplate getTemplate(int id)
        {
            SkillEffectItemLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillEffectItemLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillEffectItemLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillEffectItemLevelTemplate skilleffectitemleveltemplate = new SkillEffectItemLevelTemplate();
				//id，每个表都有
				skilleffectitemleveltemplate.Id = reader.GetInt32(startIndex++);
		
				skilleffectitemleveltemplate.exp = reader.GetInt32(startIndex++);
	
				SkillEffectItemLevelTemplateDB.Instance.addTemplate(skilleffectitemleveltemplate);
				}
			}
		}

}
}