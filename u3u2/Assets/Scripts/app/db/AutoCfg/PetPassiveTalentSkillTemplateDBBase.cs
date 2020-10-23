using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物被动天赋技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPassiveTalentSkillTemplateDBBase : TemplateDBBase<PetPassiveTalentSkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetPassiveTalentSkillTemplate> idKeyDic = new Dictionary<int, PetPassiveTalentSkillTemplate>();
        
		protected static PetPassiveTalentSkillTemplateDB _ins;
        public static PetPassiveTalentSkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetPassiveTalentSkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetPassiveTalentSkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetPassiveTalentSkillTemplate petpassivetalentskilltemplate)
        {
            if (this.idKeyDic.ContainsKey(petpassivetalentskilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petpassivetalentskilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petpassivetalentskilltemplate.Id, petpassivetalentskilltemplate);
            return true;
        }

        public override PetPassiveTalentSkillTemplate getTemplate(int id)
        {
            PetPassiveTalentSkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetPassiveTalentSkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetPassiveTalentSkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetPassiveTalentSkillTemplate petpassivetalentskilltemplate = new PetPassiveTalentSkillTemplate();
				//id，每个表都有
				petpassivetalentskilltemplate.Id = reader.GetInt32(startIndex++);
		
				petpassivetalentskilltemplate.name = reader.GetString(startIndex++);
	
		        petpassivetalentskilltemplate.propList = new List<PassiveTalentPropItem>(2);
		        for (int i = 0; i < 2; i++)
		        {
		            petpassivetalentskilltemplate.propList.Add(new PassiveTalentPropItem(reader, startIndex));
		            startIndex += 3;
		        }
	
				PetPassiveTalentSkillTemplateDB.Instance.addTemplate(petpassivetalentskilltemplate);
				}
			}
		}

}
}