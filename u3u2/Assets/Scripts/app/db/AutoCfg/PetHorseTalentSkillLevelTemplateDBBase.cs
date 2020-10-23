using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠天赋技能升级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorseTalentSkillLevelTemplateDBBase : TemplateDBBase<PetHorseTalentSkillLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorseTalentSkillLevelTemplate> idKeyDic = new Dictionary<int, PetHorseTalentSkillLevelTemplate>();
        
		protected static PetHorseTalentSkillLevelTemplateDB _ins;
        public static PetHorseTalentSkillLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorseTalentSkillLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorseTalentSkillLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorseTalentSkillLevelTemplate pethorsetalentskillleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsetalentskillleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsetalentskillleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsetalentskillleveltemplate.Id, pethorsetalentskillleveltemplate);
            return true;
        }

        public override PetHorseTalentSkillLevelTemplate getTemplate(int id)
        {
            PetHorseTalentSkillLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorseTalentSkillLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorseTalentSkillLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorseTalentSkillLevelTemplate pethorsetalentskillleveltemplate = new PetHorseTalentSkillLevelTemplate();
				//id，每个表都有
				pethorsetalentskillleveltemplate.Id = reader.GetInt32(startIndex++);
		
				pethorsetalentskillleveltemplate.talentSkillId = reader.GetInt32(startIndex++);
	
				pethorsetalentskillleveltemplate.skillLevel = reader.GetInt32(startIndex++);
	
				pethorsetalentskillleveltemplate.needPetLevel = reader.GetInt32(startIndex++);
	
				PetHorseTalentSkillLevelTemplateDB.Instance.addTemplate(pethorsetalentskillleveltemplate);
				}
			}
		}

}
}