using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物资质丹
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPropItemTemplateDBBase : TemplateDBBase<PetPropItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetPropItemTemplate> idKeyDic = new Dictionary<int, PetPropItemTemplate>();
        
		protected static PetPropItemTemplateDB _ins;
        public static PetPropItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetPropItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetPropItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetPropItemTemplate petpropitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(petpropitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petpropitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petpropitemtemplate.Id, petpropitemtemplate);
            return true;
        }

        public override PetPropItemTemplate getTemplate(int id)
        {
            PetPropItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetPropItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetPropItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetPropItemTemplate petpropitemtemplate = new PetPropItemTemplate();
				//id，每个表都有
				petpropitemtemplate.Id = reader.GetInt32(startIndex++);
		
				petpropitemtemplate.propIndex = reader.GetInt32(startIndex++);
	
				petpropitemtemplate.propItemIndex = reader.GetInt32(startIndex++);
	
				petpropitemtemplate.itemId = reader.GetInt32(startIndex++);
	
				PetPropItemTemplateDB.Instance.addTemplate(petpropitemtemplate);
				}
			}
		}

}
}