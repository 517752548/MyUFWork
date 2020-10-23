using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物悟性等级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPerceptLevelTemplateDBBase : TemplateDBBase<PetPerceptLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetPerceptLevelTemplate> idKeyDic = new Dictionary<int, PetPerceptLevelTemplate>();
        
		protected static PetPerceptLevelTemplateDB _ins;
        public static PetPerceptLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetPerceptLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetPerceptLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetPerceptLevelTemplate petperceptleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(petperceptleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petperceptleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petperceptleveltemplate.Id, petperceptleveltemplate);
            return true;
        }

        public override PetPerceptLevelTemplate getTemplate(int id)
        {
            PetPerceptLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetPerceptLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetPerceptLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetPerceptLevelTemplate petperceptleveltemplate = new PetPerceptLevelTemplate();
				//id，每个表都有
				petperceptleveltemplate.Id = reader.GetInt32(startIndex++);
		
				petperceptleveltemplate.perceptExp = reader.GetInt64(startIndex++);
	
				petperceptleveltemplate.addtionAttr = reader.GetInt32(startIndex++);
	
				petperceptleveltemplate.addtionLevel = reader.GetInt32(startIndex++);
	
				petperceptleveltemplate.petScore = reader.GetInt32(startIndex++);
	
				PetPerceptLevelTemplateDB.Instance.addTemplate(petperceptleveltemplate);
				}
			}
		}

}
}