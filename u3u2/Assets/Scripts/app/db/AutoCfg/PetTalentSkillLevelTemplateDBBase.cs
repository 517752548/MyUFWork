using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物天赋技能升级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetTalentSkillLevelTemplateDBBase : TemplateDBBase<PetTalentSkillLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetTalentSkillLevelTemplate> idKeyDic = new Dictionary<int, PetTalentSkillLevelTemplate>();
        
		protected static PetTalentSkillLevelTemplateDB _ins;
        public static PetTalentSkillLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetTalentSkillLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetTalentSkillLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetTalentSkillLevelTemplate pettalentskillleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(pettalentskillleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pettalentskillleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pettalentskillleveltemplate.Id, pettalentskillleveltemplate);
            return true;
        }

        public override PetTalentSkillLevelTemplate getTemplate(int id)
        {
            PetTalentSkillLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetTalentSkillLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetTalentSkillLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetTalentSkillLevelTemplate pettalentskillleveltemplate = new PetTalentSkillLevelTemplate();
				//id，每个表都有
				pettalentskillleveltemplate.Id = reader.GetInt32(startIndex++);
		
				pettalentskillleveltemplate.talentSkillId = reader.GetInt32(startIndex++);
	
				pettalentskillleveltemplate.skillLevel = reader.GetInt32(startIndex++);
	
				pettalentskillleveltemplate.needPetLevel = reader.GetInt32(startIndex++);
	
				PetTalentSkillLevelTemplateDB.Instance.addTemplate(pettalentskillleveltemplate);
				}
			}
		}

}
}