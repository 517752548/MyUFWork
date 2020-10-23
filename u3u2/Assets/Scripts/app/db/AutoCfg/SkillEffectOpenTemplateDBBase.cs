using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 技能开格子
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillEffectOpenTemplateDBBase : TemplateDBBase<SkillEffectOpenTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillEffectOpenTemplate> idKeyDic = new Dictionary<int, SkillEffectOpenTemplate>();
        
		protected static SkillEffectOpenTemplateDB _ins;
        public static SkillEffectOpenTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillEffectOpenTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillEffectOpenTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillEffectOpenTemplate skilleffectopentemplate)
        {
            if (this.idKeyDic.ContainsKey(skilleffectopentemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skilleffectopentemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skilleffectopentemplate.Id, skilleffectopentemplate);
            return true;
        }

        public override SkillEffectOpenTemplate getTemplate(int id)
        {
            SkillEffectOpenTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillEffectOpenTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillEffectOpenTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillEffectOpenTemplate skilleffectopentemplate = new SkillEffectOpenTemplate();
				//id，每个表都有
				skilleffectopentemplate.Id = reader.GetInt32(startIndex++);
		
				skilleffectopentemplate.itemTplId = reader.GetInt32(startIndex++);
	
				skilleffectopentemplate.itemNum = reader.GetInt32(startIndex++);
	
				SkillEffectOpenTemplateDB.Instance.addTemplate(skilleffectopentemplate);
				}
			}
		}

}
}