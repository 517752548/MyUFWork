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
	public abstract class PetHorseArtificeTemplateDBBase : TemplateDBBase<PetHorseArtificeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorseArtificeTemplate> idKeyDic = new Dictionary<int, PetHorseArtificeTemplate>();
        
		protected static PetHorseArtificeTemplateDB _ins;
        public static PetHorseArtificeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorseArtificeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorseArtificeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorseArtificeTemplate pethorseartificetemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorseartificetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorseartificetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorseartificetemplate.Id, pethorseartificetemplate);
            return true;
        }

        public override PetHorseArtificeTemplate getTemplate(int id)
        {
            PetHorseArtificeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorseArtificeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorseArtificeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorseArtificeTemplate pethorseartificetemplate = new PetHorseArtificeTemplate();
				//id，每个表都有
				pethorseartificetemplate.Id = reader.GetInt32(startIndex++);
		
				pethorseartificetemplate.itemId = reader.GetInt32(startIndex++);
	
				pethorseartificetemplate.itemNum = reader.GetInt32(startIndex++);
	
				pethorseartificetemplate.currencyNum = reader.GetInt32(startIndex++);
	
				pethorseartificetemplate.currencyType = reader.GetInt32(startIndex++);
	
				pethorseartificetemplate.perceptionLevel = reader.GetInt32(startIndex++);
	
				pethorseartificetemplate.minQuality = reader.GetInt32(startIndex++);
	
				pethorseartificetemplate.maxQuality = reader.GetInt32(startIndex++);
	
				pethorseartificetemplate.name = reader.GetString(startIndex++);
	
				PetHorseArtificeTemplateDB.Instance.addTemplate(pethorseartificetemplate);
				}
			}
		}

}
}