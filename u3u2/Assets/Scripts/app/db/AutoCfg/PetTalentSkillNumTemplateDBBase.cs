using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物天赋技能数量
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetTalentSkillNumTemplateDBBase : TemplateDBBase<PetTalentSkillNumTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetTalentSkillNumTemplate> idKeyDic = new Dictionary<int, PetTalentSkillNumTemplate>();
        
		protected static PetTalentSkillNumTemplateDB _ins;
        public static PetTalentSkillNumTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetTalentSkillNumTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetTalentSkillNumTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetTalentSkillNumTemplate pettalentskillnumtemplate)
        {
            if (this.idKeyDic.ContainsKey(pettalentskillnumtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pettalentskillnumtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pettalentskillnumtemplate.Id, pettalentskillnumtemplate);
            return true;
        }

        public override PetTalentSkillNumTemplate getTemplate(int id)
        {
            PetTalentSkillNumTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetTalentSkillNumTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetTalentSkillNumTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetTalentSkillNumTemplate pettalentskillnumtemplate = new PetTalentSkillNumTemplate();
				//id，每个表都有
				pettalentskillnumtemplate.Id = reader.GetInt32(startIndex++);
		
				pettalentskillnumtemplate.affiMinNum = reader.GetInt32(startIndex++);
	
				pettalentskillnumtemplate.affiMaxNum = reader.GetInt32(startIndex++);
	
				pettalentskillnumtemplate.talentSkillNum = reader.GetInt32(startIndex++);
	
				pettalentskillnumtemplate.weight = reader.GetInt32(startIndex++);
	
				pettalentskillnumtemplate.talentSkill1Flag = reader.GetInt32(startIndex++);
	
				pettalentskillnumtemplate.variationFlag = reader.GetInt32(startIndex++);
	
				pettalentskillnumtemplate.growthFlag = reader.GetInt32(startIndex++);
	
				PetTalentSkillNumTemplateDB.Instance.addTemplate(pettalentskillnumtemplate);
				}
			}
		}

}
}