using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 炼化
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetArtificeTemplateDBBase : TemplateDBBase<PetArtificeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetArtificeTemplate> idKeyDic = new Dictionary<int, PetArtificeTemplate>();
        
		protected static PetArtificeTemplateDB _ins;
        public static PetArtificeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetArtificeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetArtificeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetArtificeTemplate petartificetemplate)
        {
            if (this.idKeyDic.ContainsKey(petartificetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petartificetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petartificetemplate.Id, petartificetemplate);
            return true;
        }

        public override PetArtificeTemplate getTemplate(int id)
        {
            PetArtificeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetArtificeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetArtificeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetArtificeTemplate petartificetemplate = new PetArtificeTemplate();
				//id，每个表都有
				petartificetemplate.Id = reader.GetInt32(startIndex++);
		
				petartificetemplate.itemId = reader.GetInt32(startIndex++);
	
				petartificetemplate.itemNum = reader.GetInt32(startIndex++);
	
				petartificetemplate.currencyNum = reader.GetInt32(startIndex++);
	
				petartificetemplate.currencyType = reader.GetInt32(startIndex++);
	
				petartificetemplate.perceptionLevel = reader.GetInt32(startIndex++);
	
				petartificetemplate.minQuality = reader.GetInt32(startIndex++);
	
				petartificetemplate.maxQuality = reader.GetInt32(startIndex++);
	
				petartificetemplate.name = reader.GetString(startIndex++);
	
				PetArtificeTemplateDB.Instance.addTemplate(petartificetemplate);
				}
			}
		}

}
}