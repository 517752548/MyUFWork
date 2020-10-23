using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物悟性类别
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPerceptTypeTemplateDBBase : TemplateDBBase<PetPerceptTypeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetPerceptTypeTemplate> idKeyDic = new Dictionary<int, PetPerceptTypeTemplate>();
        
		protected static PetPerceptTypeTemplateDB _ins;
        public static PetPerceptTypeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetPerceptTypeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetPerceptTypeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetPerceptTypeTemplate petpercepttypetemplate)
        {
            if (this.idKeyDic.ContainsKey(petpercepttypetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petpercepttypetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petpercepttypetemplate.Id, petpercepttypetemplate);
            return true;
        }

        public override PetPerceptTypeTemplate getTemplate(int id)
        {
            PetPerceptTypeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetPerceptTypeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetPerceptTypeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetPerceptTypeTemplate petpercepttypetemplate = new PetPerceptTypeTemplate();
				//id，每个表都有
				petpercepttypetemplate.Id = reader.GetInt32(startIndex++);
		
				petpercepttypetemplate.itemId = reader.GetInt32(startIndex++);
	
				petpercepttypetemplate.itemNum = reader.GetInt32(startIndex++);
	
				petpercepttypetemplate.currencyType = reader.GetInt32(startIndex++);
	
				petpercepttypetemplate.currencyNum = reader.GetInt32(startIndex++);
	
				petpercepttypetemplate.vipFuncId = reader.GetInt32(startIndex++);
	
				PetPerceptTypeTemplateDB.Instance.addTemplate(petpercepttypetemplate);
				}
			}
		}

}
}