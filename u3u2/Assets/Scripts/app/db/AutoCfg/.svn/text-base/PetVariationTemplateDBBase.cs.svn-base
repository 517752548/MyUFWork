using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 变异
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetVariationTemplateDBBase : TemplateDBBase<PetVariationTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetVariationTemplate> idKeyDic = new Dictionary<int, PetVariationTemplate>();
        
		protected static PetVariationTemplateDB _ins;
        public static PetVariationTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetVariationTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetVariationTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetVariationTemplate petvariationtemplate)
        {
            if (this.idKeyDic.ContainsKey(petvariationtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petvariationtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petvariationtemplate.Id, petvariationtemplate);
            return true;
        }

        public override PetVariationTemplate getTemplate(int id)
        {
            PetVariationTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetVariationTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetVariationTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetVariationTemplate petvariationtemplate = new PetVariationTemplate();
				//id，每个表都有
				petvariationtemplate.Id = reader.GetInt32(startIndex++);
		
				petvariationtemplate.itemId = reader.GetInt32(startIndex++);
	
				petvariationtemplate.itemNum = reader.GetInt32(startIndex++);
	
				petvariationtemplate.currencyNum = reader.GetInt32(startIndex++);
	
				petvariationtemplate.currencyType = reader.GetInt32(startIndex++);
	
				petvariationtemplate.name = reader.GetString(startIndex++);
	
				PetVariationTemplateDB.Instance.addTemplate(petvariationtemplate);
				}
			}
		}

}
}