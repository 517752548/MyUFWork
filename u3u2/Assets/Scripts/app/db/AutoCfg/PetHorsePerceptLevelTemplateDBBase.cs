using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠悟性等级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorsePerceptLevelTemplateDBBase : TemplateDBBase<PetHorsePerceptLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorsePerceptLevelTemplate> idKeyDic = new Dictionary<int, PetHorsePerceptLevelTemplate>();
        
		protected static PetHorsePerceptLevelTemplateDB _ins;
        public static PetHorsePerceptLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorsePerceptLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorsePerceptLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorsePerceptLevelTemplate pethorseperceptleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorseperceptleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorseperceptleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorseperceptleveltemplate.Id, pethorseperceptleveltemplate);
            return true;
        }

        public override PetHorsePerceptLevelTemplate getTemplate(int id)
        {
            PetHorsePerceptLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorsePerceptLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorsePerceptLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorsePerceptLevelTemplate pethorseperceptleveltemplate = new PetHorsePerceptLevelTemplate();
				//id，每个表都有
				pethorseperceptleveltemplate.Id = reader.GetInt32(startIndex++);
		
				pethorseperceptleveltemplate.perceptExp = reader.GetInt64(startIndex++);
	
				pethorseperceptleveltemplate.addtionAttr = reader.GetInt32(startIndex++);
	
				pethorseperceptleveltemplate.addtionLevel = reader.GetInt32(startIndex++);
	
				pethorseperceptleveltemplate.petHorseScore = reader.GetInt32(startIndex++);
	
				PetHorsePerceptLevelTemplateDB.Instance.addTemplate(pethorseperceptleveltemplate);
				}
			}
		}

}
}