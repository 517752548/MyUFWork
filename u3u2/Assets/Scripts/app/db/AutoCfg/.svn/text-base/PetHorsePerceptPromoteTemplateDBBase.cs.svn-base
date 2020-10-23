using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠悟性提升经验
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorsePerceptPromoteTemplateDBBase : TemplateDBBase<PetHorsePerceptPromoteTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorsePerceptPromoteTemplate> idKeyDic = new Dictionary<int, PetHorsePerceptPromoteTemplate>();
        
		protected static PetHorsePerceptPromoteTemplateDB _ins;
        public static PetHorsePerceptPromoteTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorsePerceptPromoteTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorsePerceptPromoteTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorsePerceptPromoteTemplate pethorseperceptpromotetemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorseperceptpromotetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorseperceptpromotetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorseperceptpromotetemplate.Id, pethorseperceptpromotetemplate);
            return true;
        }

        public override PetHorsePerceptPromoteTemplate getTemplate(int id)
        {
            PetHorsePerceptPromoteTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorsePerceptPromoteTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorsePerceptPromoteTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorsePerceptPromoteTemplate pethorseperceptpromotetemplate = new PetHorsePerceptPromoteTemplate();
				//id，每个表都有
				pethorseperceptpromotetemplate.Id = reader.GetInt32(startIndex++);
		
				pethorseperceptpromotetemplate.promoteType = reader.GetInt32(startIndex++);
	
				pethorseperceptpromotetemplate.perceptLevel = reader.GetInt32(startIndex++);
	
				pethorseperceptpromotetemplate.singleExp = reader.GetInt32(startIndex++);
	
				pethorseperceptpromotetemplate.singleSmallCritProp = reader.GetInt32(startIndex++);
	
				pethorseperceptpromotetemplate.singleBigCritProp = reader.GetInt32(startIndex++);
	
				pethorseperceptpromotetemplate.batchSmallCritProp = reader.GetInt32(startIndex++);
	
				pethorseperceptpromotetemplate.batchBigCritProp = reader.GetInt32(startIndex++);
	
				PetHorsePerceptPromoteTemplateDB.Instance.addTemplate(pethorseperceptpromotetemplate);
				}
			}
		}

}
}