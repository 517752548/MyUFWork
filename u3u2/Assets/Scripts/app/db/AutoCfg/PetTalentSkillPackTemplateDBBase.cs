using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物天赋技能包
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetTalentSkillPackTemplateDBBase : TemplateDBBase<PetTalentSkillPackTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetTalentSkillPackTemplate> idKeyDic = new Dictionary<int, PetTalentSkillPackTemplate>();
        
		protected static PetTalentSkillPackTemplateDB _ins;
        public static PetTalentSkillPackTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetTalentSkillPackTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetTalentSkillPackTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetTalentSkillPackTemplate pettalentskillpacktemplate)
        {
            if (this.idKeyDic.ContainsKey(pettalentskillpacktemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pettalentskillpacktemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pettalentskillpacktemplate.Id, pettalentskillpacktemplate);
            return true;
        }

        public override PetTalentSkillPackTemplate getTemplate(int id)
        {
            PetTalentSkillPackTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetTalentSkillPackTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetTalentSkillPackTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetTalentSkillPackTemplate pettalentskillpacktemplate = new PetTalentSkillPackTemplate();
				//id，每个表都有
				pettalentskillpacktemplate.Id = reader.GetInt32(startIndex++);
		
		        pettalentskillpacktemplate.talentSkillList = new List<TalentSkillItem>(15);
		        for (int i = 0; i < 15; i++)
		        {
		            pettalentskillpacktemplate.talentSkillList.Add(new TalentSkillItem(reader, startIndex));
		            startIndex += 2;
		        }
	
				PetTalentSkillPackTemplateDB.Instance.addTemplate(pettalentskillpacktemplate);
				}
			}
		}

}
}