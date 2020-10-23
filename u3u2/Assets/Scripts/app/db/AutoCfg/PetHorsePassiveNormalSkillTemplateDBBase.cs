using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠被动普通技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorsePassiveNormalSkillTemplateDBBase : TemplateDBBase<PetHorsePassiveNormalSkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorsePassiveNormalSkillTemplate> idKeyDic = new Dictionary<int, PetHorsePassiveNormalSkillTemplate>();
        
		protected static PetHorsePassiveNormalSkillTemplateDB _ins;
        public static PetHorsePassiveNormalSkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorsePassiveNormalSkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorsePassiveNormalSkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorsePassiveNormalSkillTemplate pethorsepassivenormalskilltemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsepassivenormalskilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsepassivenormalskilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsepassivenormalskilltemplate.Id, pethorsepassivenormalskilltemplate);
            return true;
        }

        public override PetHorsePassiveNormalSkillTemplate getTemplate(int id)
        {
            PetHorsePassiveNormalSkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorsePassiveNormalSkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorsePassiveNormalSkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorsePassiveNormalSkillTemplate pethorsepassivenormalskilltemplate = new PetHorsePassiveNormalSkillTemplate();
				//id，每个表都有
				pethorsepassivenormalskilltemplate.Id = reader.GetInt32(startIndex++);
		
				pethorsepassivenormalskilltemplate.name = reader.GetString(startIndex++);
	
		        pethorsepassivenormalskilltemplate.propList = new List<PassiveTalentPropItem>(2);
		        for (int i = 0; i < 2; i++)
		        {
		            pethorsepassivenormalskilltemplate.propList.Add(new PassiveTalentPropItem(reader, startIndex));
		            startIndex += 3;
		        }
	
				PetHorsePassiveNormalSkillTemplateDB.Instance.addTemplate(pethorsepassivenormalskilltemplate);
				}
			}
		}

}
}