using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物被动普通技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPassiveNormalSkillTemplateDBBase : TemplateDBBase<PetPassiveNormalSkillTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetPassiveNormalSkillTemplate> idKeyDic = new Dictionary<int, PetPassiveNormalSkillTemplate>();
        
		protected static PetPassiveNormalSkillTemplateDB _ins;
        public static PetPassiveNormalSkillTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetPassiveNormalSkillTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetPassiveNormalSkillTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetPassiveNormalSkillTemplate petpassivenormalskilltemplate)
        {
            if (this.idKeyDic.ContainsKey(petpassivenormalskilltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petpassivenormalskilltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petpassivenormalskilltemplate.Id, petpassivenormalskilltemplate);
            return true;
        }

        public override PetPassiveNormalSkillTemplate getTemplate(int id)
        {
            PetPassiveNormalSkillTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetPassiveNormalSkillTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetPassiveNormalSkillTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetPassiveNormalSkillTemplate petpassivenormalskilltemplate = new PetPassiveNormalSkillTemplate();
				//id，每个表都有
				petpassivenormalskilltemplate.Id = reader.GetInt32(startIndex++);
		
				petpassivenormalskilltemplate.name = reader.GetString(startIndex++);
	
		        petpassivenormalskilltemplate.propList = new List<PassiveTalentPropItem>(2);
		        for (int i = 0; i < 2; i++)
		        {
		            petpassivenormalskilltemplate.propList.Add(new PassiveTalentPropItem(reader, startIndex));
		            startIndex += 3;
		        }
	
				PetPassiveNormalSkillTemplateDB.Instance.addTemplate(petpassivenormalskilltemplate);
				}
			}
		}

}
}