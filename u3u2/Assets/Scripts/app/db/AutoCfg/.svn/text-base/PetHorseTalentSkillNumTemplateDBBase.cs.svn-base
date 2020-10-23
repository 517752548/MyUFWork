using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠天赋技能数量
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorseTalentSkillNumTemplateDBBase : TemplateDBBase<PetHorseTalentSkillNumTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorseTalentSkillNumTemplate> idKeyDic = new Dictionary<int, PetHorseTalentSkillNumTemplate>();
        
		protected static PetHorseTalentSkillNumTemplateDB _ins;
        public static PetHorseTalentSkillNumTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorseTalentSkillNumTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorseTalentSkillNumTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorseTalentSkillNumTemplate pethorsetalentskillnumtemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsetalentskillnumtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsetalentskillnumtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsetalentskillnumtemplate.Id, pethorsetalentskillnumtemplate);
            return true;
        }

        public override PetHorseTalentSkillNumTemplate getTemplate(int id)
        {
            PetHorseTalentSkillNumTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorseTalentSkillNumTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorseTalentSkillNumTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorseTalentSkillNumTemplate pethorsetalentskillnumtemplate = new PetHorseTalentSkillNumTemplate();
				//id，每个表都有
				pethorsetalentskillnumtemplate.Id = reader.GetInt32(startIndex++);
		
				pethorsetalentskillnumtemplate.affiMinNum = reader.GetInt32(startIndex++);
	
				pethorsetalentskillnumtemplate.affiMaxNum = reader.GetInt32(startIndex++);
	
				pethorsetalentskillnumtemplate.talentSkillNum = reader.GetInt32(startIndex++);
	
				pethorsetalentskillnumtemplate.weight = reader.GetInt32(startIndex++);
	
				pethorsetalentskillnumtemplate.talentSkill1Flag = reader.GetInt32(startIndex++);
	
				pethorsetalentskillnumtemplate.variationFlag = reader.GetInt32(startIndex++);
	
				pethorsetalentskillnumtemplate.growthFlag = reader.GetInt32(startIndex++);
	
				PetHorseTalentSkillNumTemplateDB.Instance.addTemplate(pethorsetalentskillnumtemplate);
				}
			}
		}

}
}