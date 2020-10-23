using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 一二级属性关系
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPropTemplateDBBase : TemplateDBBase<PetPropTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetPropTemplate> idKeyDic = new Dictionary<int, PetPropTemplate>();
        
		protected static PetPropTemplateDB _ins;
        public static PetPropTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetPropTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetPropTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetPropTemplate petproptemplate)
        {
            if (this.idKeyDic.ContainsKey(petproptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petproptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petproptemplate.Id, petproptemplate);
            return true;
        }

        public override PetPropTemplate getTemplate(int id)
        {
            PetPropTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetPropTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetPropTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetPropTemplate petproptemplate = new PetPropTemplate();
				//id，每个表都有
				petproptemplate.Id = reader.GetInt32(startIndex++);
		
				petproptemplate.strength = reader.GetInt32(startIndex++);
	
				petproptemplate.agility = reader.GetInt32(startIndex++);
	
				petproptemplate.intellect = reader.GetInt32(startIndex++);
	
				petproptemplate.faith = reader.GetInt32(startIndex++);
	
				petproptemplate.stamina = reader.GetInt32(startIndex++);
	
				petproptemplate.leaderCoef = reader.GetInt32(startIndex++);
	
				petproptemplate.xiakeCoef = reader.GetInt32(startIndex++);
	
				petproptemplate.cikeCoef = reader.GetInt32(startIndex++);
	
				petproptemplate.shushiCoef = reader.GetInt32(startIndex++);
	
				petproptemplate.xiuzhenCoef = reader.GetInt32(startIndex++);
	
				PetPropTemplateDB.Instance.addTemplate(petproptemplate);
				}
			}
		}

}
}