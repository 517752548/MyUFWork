using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠资质丹
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorsePropItemTemplateDBBase : TemplateDBBase<PetHorsePropItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorsePropItemTemplate> idKeyDic = new Dictionary<int, PetHorsePropItemTemplate>();
        
		protected static PetHorsePropItemTemplateDB _ins;
        public static PetHorsePropItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorsePropItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorsePropItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorsePropItemTemplate pethorsepropitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsepropitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsepropitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsepropitemtemplate.Id, pethorsepropitemtemplate);
            return true;
        }

        public override PetHorsePropItemTemplate getTemplate(int id)
        {
            PetHorsePropItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorsePropItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorsePropItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorsePropItemTemplate pethorsepropitemtemplate = new PetHorsePropItemTemplate();
				//id，每个表都有
				pethorsepropitemtemplate.Id = reader.GetInt32(startIndex++);
		
				pethorsepropitemtemplate.propIndex = reader.GetInt32(startIndex++);
	
				pethorsepropitemtemplate.propItemIndex = reader.GetInt32(startIndex++);
	
				pethorsepropitemtemplate.itemId = reader.GetInt32(startIndex++);
	
				PetHorsePropItemTemplateDB.Instance.addTemplate(pethorsepropitemtemplate);
				}
			}
		}

}
}