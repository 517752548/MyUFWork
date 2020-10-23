using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物悟性提升经验
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPerceptPromoteTemplateDBBase : TemplateDBBase<PetPerceptPromoteTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetPerceptPromoteTemplate> idKeyDic = new Dictionary<int, PetPerceptPromoteTemplate>();
        
		protected static PetPerceptPromoteTemplateDB _ins;
        public static PetPerceptPromoteTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetPerceptPromoteTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetPerceptPromoteTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetPerceptPromoteTemplate petperceptpromotetemplate)
        {
            if (this.idKeyDic.ContainsKey(petperceptpromotetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petperceptpromotetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petperceptpromotetemplate.Id, petperceptpromotetemplate);
            return true;
        }

        public override PetPerceptPromoteTemplate getTemplate(int id)
        {
            PetPerceptPromoteTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetPerceptPromoteTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetPerceptPromoteTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetPerceptPromoteTemplate petperceptpromotetemplate = new PetPerceptPromoteTemplate();
				//id，每个表都有
				petperceptpromotetemplate.Id = reader.GetInt32(startIndex++);
		
				petperceptpromotetemplate.promoteType = reader.GetInt32(startIndex++);
	
				petperceptpromotetemplate.perceptLevel = reader.GetInt32(startIndex++);
	
				petperceptpromotetemplate.singleExp = reader.GetInt32(startIndex++);
	
				petperceptpromotetemplate.singleSmallCritProp = reader.GetInt32(startIndex++);
	
				petperceptpromotetemplate.singleBigCritProp = reader.GetInt32(startIndex++);
	
				petperceptpromotetemplate.batchSmallCritProp = reader.GetInt32(startIndex++);
	
				petperceptpromotetemplate.batchBigCritProp = reader.GetInt32(startIndex++);
	
				PetPerceptPromoteTemplateDB.Instance.addTemplate(petperceptpromotetemplate);
				}
			}
		}

}
}