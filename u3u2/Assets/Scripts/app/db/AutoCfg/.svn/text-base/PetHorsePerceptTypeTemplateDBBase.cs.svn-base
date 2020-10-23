using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠悟性类别
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorsePerceptTypeTemplateDBBase : TemplateDBBase<PetHorsePerceptTypeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorsePerceptTypeTemplate> idKeyDic = new Dictionary<int, PetHorsePerceptTypeTemplate>();
        
		protected static PetHorsePerceptTypeTemplateDB _ins;
        public static PetHorsePerceptTypeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorsePerceptTypeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorsePerceptTypeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorsePerceptTypeTemplate pethorsepercepttypetemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsepercepttypetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsepercepttypetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsepercepttypetemplate.Id, pethorsepercepttypetemplate);
            return true;
        }

        public override PetHorsePerceptTypeTemplate getTemplate(int id)
        {
            PetHorsePerceptTypeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorsePerceptTypeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorsePerceptTypeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorsePerceptTypeTemplate pethorsepercepttypetemplate = new PetHorsePerceptTypeTemplate();
				//id，每个表都有
				pethorsepercepttypetemplate.Id = reader.GetInt32(startIndex++);
		
				pethorsepercepttypetemplate.itemId = reader.GetInt32(startIndex++);
	
				pethorsepercepttypetemplate.itemNum = reader.GetInt32(startIndex++);
	
				pethorsepercepttypetemplate.currencyType = reader.GetInt32(startIndex++);
	
				pethorsepercepttypetemplate.currencyNum = reader.GetInt32(startIndex++);
	
				PetHorsePerceptTypeTemplateDB.Instance.addTemplate(pethorsepercepttypetemplate);
				}
			}
		}

}
}