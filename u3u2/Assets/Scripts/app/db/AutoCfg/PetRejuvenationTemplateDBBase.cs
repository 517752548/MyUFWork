using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 还童
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetRejuvenationTemplateDBBase : TemplateDBBase<PetRejuvenationTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetRejuvenationTemplate> idKeyDic = new Dictionary<int, PetRejuvenationTemplate>();
        
		protected static PetRejuvenationTemplateDB _ins;
        public static PetRejuvenationTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetRejuvenationTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetRejuvenationTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetRejuvenationTemplate petrejuvenationtemplate)
        {
            if (this.idKeyDic.ContainsKey(petrejuvenationtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petrejuvenationtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petrejuvenationtemplate.Id, petrejuvenationtemplate);
            return true;
        }

        public override PetRejuvenationTemplate getTemplate(int id)
        {
            PetRejuvenationTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetRejuvenationTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetRejuvenationTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetRejuvenationTemplate petrejuvenationtemplate = new PetRejuvenationTemplate();
				//id，每个表都有
				petrejuvenationtemplate.Id = reader.GetInt32(startIndex++);
		
				petrejuvenationtemplate.petpetTypeId = reader.GetInt32(startIndex++);
	
				petrejuvenationtemplate.itemId = reader.GetInt32(startIndex++);
	
				petrejuvenationtemplate.itemNum = reader.GetInt32(startIndex++);
	
				petrejuvenationtemplate.currencyNum = reader.GetInt32(startIndex++);
	
				petrejuvenationtemplate.currencyType = reader.GetInt32(startIndex++);
	
				petrejuvenationtemplate.name = reader.GetString(startIndex++);
	
				PetRejuvenationTemplateDB.Instance.addTemplate(petrejuvenationtemplate);
				}
			}
		}

}
}