using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 升级经验
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorseLevelTemplateDBBase : TemplateDBBase<PetHorseLevelTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorseLevelTemplate> idKeyDic = new Dictionary<int, PetHorseLevelTemplate>();
        
		protected static PetHorseLevelTemplateDB _ins;
        public static PetHorseLevelTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorseLevelTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorseLevelTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorseLevelTemplate pethorseleveltemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorseleveltemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorseleveltemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorseleveltemplate.Id, pethorseleveltemplate);
            return true;
        }

        public override PetHorseLevelTemplate getTemplate(int id)
        {
            PetHorseLevelTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorseLevelTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorseLevelTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorseLevelTemplate pethorseleveltemplate = new PetHorseLevelTemplate();
				//id，每个表都有
				pethorseleveltemplate.Id = reader.GetInt32(startIndex++);
		
				pethorseleveltemplate.petHorseExp = reader.GetInt64(startIndex++);
	
				PetHorseLevelTemplateDB.Instance.addTemplate(pethorseleveltemplate);
				}
			}
		}

}
}