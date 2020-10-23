using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠成长率
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorseGrowthTemplateDBBase : TemplateDBBase<PetHorseGrowthTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorseGrowthTemplate> idKeyDic = new Dictionary<int, PetHorseGrowthTemplate>();
        
		protected static PetHorseGrowthTemplateDB _ins;
        public static PetHorseGrowthTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorseGrowthTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorseGrowthTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorseGrowthTemplate pethorsegrowthtemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsegrowthtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsegrowthtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsegrowthtemplate.Id, pethorsegrowthtemplate);
            return true;
        }

        public override PetHorseGrowthTemplate getTemplate(int id)
        {
            PetHorseGrowthTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorseGrowthTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorseGrowthTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorseGrowthTemplate pethorsegrowthtemplate = new PetHorseGrowthTemplate();
				//id，每个表都有
				pethorsegrowthtemplate.Id = reader.GetInt32(startIndex++);
		
				pethorsegrowthtemplate.normalWeight = reader.GetInt32(startIndex++);
	
				pethorsegrowthtemplate.rubbishyWeight = reader.GetInt32(startIndex++);
	
				pethorsegrowthtemplate.transformWeight = reader.GetInt32(startIndex++);
	
				pethorsegrowthtemplate.add = reader.GetInt32(startIndex++);
	
				pethorsegrowthtemplate.nameLangId = reader.GetInt64(startIndex++);
	
				pethorsegrowthtemplate.name = reader.GetString(startIndex++);
	
				pethorsegrowthtemplate.petScore = reader.GetInt32(startIndex++);
	
				PetHorseGrowthTemplateDB.Instance.addTemplate(pethorsegrowthtemplate);
				}
			}
		}

}
}