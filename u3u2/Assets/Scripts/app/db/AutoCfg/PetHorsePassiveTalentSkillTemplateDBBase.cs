using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠被动天赋技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorsePassiveTalentSkillTemplateDBBase : TemplateDBBase<PetHorsePassiveTalentSkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorsePassiveTalentSkillTemplate> idKeyDic = new Dictionary<int, PetHorsePassiveTalentSkillTemplate>();
        
		protected static PetHorsePassiveTalentSkillTemplateDB _ins;
        public static PetHorsePassiveTalentSkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorsePassiveTalentSkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorsePassiveTalentSkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorsePassiveTalentSkillTemplate pethorsepassivetalentskilltemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsepassivetalentskilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsepassivetalentskilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsepassivetalentskilltemplate.Id, pethorsepassivetalentskilltemplate);
            return true;
        }

        public override PetHorsePassiveTalentSkillTemplate getTemplate(int id)
        {
            PetHorsePassiveTalentSkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorsePassiveTalentSkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorsePassiveTalentSkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorsePassiveTalentSkillTemplate pethorsepassivetalentskilltemplate = new PetHorsePassiveTalentSkillTemplate();
				//id，每个表都有
				pethorsepassivetalentskilltemplate.Id = reader.GetInt32(startIndex++);
		
				pethorsepassivetalentskilltemplate.name = reader.GetString(startIndex++);
	
		        pethorsepassivetalentskilltemplate.propList = new List<PassiveTalentPropItem>(2);
		        for (int i = 0; i < 2; i++)
		        {
		            pethorsepassivetalentskilltemplate.propList.Add(new PassiveTalentPropItem(reader, startIndex));
		            startIndex += 3;
		        }
	
				PetHorsePassiveTalentSkillTemplateDB.Instance.addTemplate(pethorsepassivetalentskilltemplate);
				}
			}
		}

}
}