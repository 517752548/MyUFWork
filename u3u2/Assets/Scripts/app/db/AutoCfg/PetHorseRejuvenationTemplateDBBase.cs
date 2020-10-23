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
	public abstract class PetHorseRejuvenationTemplateDBBase : TemplateDBBase<PetHorseRejuvenationTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorseRejuvenationTemplate> idKeyDic = new Dictionary<int, PetHorseRejuvenationTemplate>();
        
		protected static PetHorseRejuvenationTemplateDB _ins;
        public static PetHorseRejuvenationTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorseRejuvenationTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorseRejuvenationTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorseRejuvenationTemplate pethorserejuvenationtemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorserejuvenationtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorserejuvenationtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorserejuvenationtemplate.Id, pethorserejuvenationtemplate);
            return true;
        }

        public override PetHorseRejuvenationTemplate getTemplate(int id)
        {
            PetHorseRejuvenationTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorseRejuvenationTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorseRejuvenationTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorseRejuvenationTemplate pethorserejuvenationtemplate = new PetHorseRejuvenationTemplate();
				//id，每个表都有
				pethorserejuvenationtemplate.Id = reader.GetInt32(startIndex++);
		
				pethorserejuvenationtemplate.petpetTypeId = reader.GetInt32(startIndex++);
	
				pethorserejuvenationtemplate.itemId = reader.GetInt32(startIndex++);
	
				pethorserejuvenationtemplate.itemNum = reader.GetInt32(startIndex++);
	
				pethorserejuvenationtemplate.currencyNum = reader.GetInt32(startIndex++);
	
				pethorserejuvenationtemplate.currencyType = reader.GetInt32(startIndex++);
	
				pethorserejuvenationtemplate.name = reader.GetString(startIndex++);
	
				PetHorseRejuvenationTemplateDB.Instance.addTemplate(pethorserejuvenationtemplate);
				}
			}
		}

}
}