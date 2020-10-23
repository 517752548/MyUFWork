using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 商城标签配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MallCatalogTemplateDBBase : TemplateDBBase<MallCatalogTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MallCatalogTemplate> idKeyDic = new Dictionary<int, MallCatalogTemplate>();
        
		protected static MallCatalogTemplateDB _ins;
        public static MallCatalogTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MallCatalogTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MallCatalogTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MallCatalogTemplate mallcatalogtemplate)
        {
            if (this.idKeyDic.ContainsKey(mallcatalogtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + mallcatalogtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(mallcatalogtemplate.Id, mallcatalogtemplate);
            return true;
        }

        public override MallCatalogTemplate getTemplate(int id)
        {
            MallCatalogTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MallCatalogTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MallCatalogTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MallCatalogTemplate mallcatalogtemplate = new MallCatalogTemplate();
				//id，每个表都有
				mallcatalogtemplate.Id = reader.GetInt32(startIndex++);
		
				mallcatalogtemplate.sortId = reader.GetInt32(startIndex++);
	
				mallcatalogtemplate.nameLangId = reader.GetInt64(startIndex++);
	
				mallcatalogtemplate.name = reader.GetString(startIndex++);
	
				mallcatalogtemplate.catalogTypeId = reader.GetInt32(startIndex++);
	
				MallCatalogTemplateDB.Instance.addTemplate(mallcatalogtemplate);
				}
			}
		}

}
}