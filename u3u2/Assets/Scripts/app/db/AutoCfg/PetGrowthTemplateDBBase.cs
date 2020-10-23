using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物成长率
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetGrowthTemplateDBBase : TemplateDBBase<PetGrowthTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetGrowthTemplate> idKeyDic = new Dictionary<int, PetGrowthTemplate>();
        
		protected static PetGrowthTemplateDB _ins;
        public static PetGrowthTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetGrowthTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetGrowthTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetGrowthTemplate petgrowthtemplate)
        {
            if (this.idKeyDic.ContainsKey(petgrowthtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petgrowthtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petgrowthtemplate.Id, petgrowthtemplate);
            return true;
        }

        public override PetGrowthTemplate getTemplate(int id)
        {
            PetGrowthTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetGrowthTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetGrowthTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetGrowthTemplate petgrowthtemplate = new PetGrowthTemplate();
				//id，每个表都有
				petgrowthtemplate.Id = reader.GetInt32(startIndex++);
		
				petgrowthtemplate.normalWeight = reader.GetInt32(startIndex++);
	
				petgrowthtemplate.rubbishyWeight = reader.GetInt32(startIndex++);
	
				petgrowthtemplate.transformWeight = reader.GetInt32(startIndex++);
	
				petgrowthtemplate.add = reader.GetInt32(startIndex++);
	
				petgrowthtemplate.nameLangId = reader.GetInt64(startIndex++);
	
				petgrowthtemplate.name = reader.GetString(startIndex++);
	
				petgrowthtemplate.petScore = reader.GetInt32(startIndex++);
	
				PetGrowthTemplateDB.Instance.addTemplate(petgrowthtemplate);
				}
			}
		}

}
}