using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠天赋技能包
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorseTalentSkillPackTemplateDBBase : TemplateDBBase<PetHorseTalentSkillPackTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorseTalentSkillPackTemplate> idKeyDic = new Dictionary<int, PetHorseTalentSkillPackTemplate>();
        
		protected static PetHorseTalentSkillPackTemplateDB _ins;
        public static PetHorseTalentSkillPackTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorseTalentSkillPackTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorseTalentSkillPackTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorseTalentSkillPackTemplate pethorsetalentskillpacktemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsetalentskillpacktemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsetalentskillpacktemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsetalentskillpacktemplate.Id, pethorsetalentskillpacktemplate);
            return true;
        }

        public override PetHorseTalentSkillPackTemplate getTemplate(int id)
        {
            PetHorseTalentSkillPackTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorseTalentSkillPackTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorseTalentSkillPackTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorseTalentSkillPackTemplate pethorsetalentskillpacktemplate = new PetHorseTalentSkillPackTemplate();
				//id，每个表都有
				pethorsetalentskillpacktemplate.Id = reader.GetInt32(startIndex++);
		
		        pethorsetalentskillpacktemplate.talentSkillList = new List<TalentSkillItem>(15);
		        for (int i = 0; i < 15; i++)
		        {
		            pethorsetalentskillpacktemplate.talentSkillList.Add(new TalentSkillItem(reader, startIndex));
		            startIndex += 2;
		        }
	
				PetHorseTalentSkillPackTemplateDB.Instance.addTemplate(pethorsetalentskillpacktemplate);
				}
			}
		}

}
}