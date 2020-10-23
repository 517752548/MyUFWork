using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 仓库开格花费
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class StoreOpenTemplateDBBase : TemplateDBBase<StoreOpenTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, StoreOpenTemplate> idKeyDic = new Dictionary<int, StoreOpenTemplate>();
        
		protected static StoreOpenTemplateDB _ins;
        public static StoreOpenTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new StoreOpenTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, StoreOpenTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(StoreOpenTemplate storeopentemplate)
        {
            if (this.idKeyDic.ContainsKey(storeopentemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + storeopentemplate.Id);
                return false;
            }
            this.idKeyDic.Add(storeopentemplate.Id, storeopentemplate);
            return true;
        }

        public override StoreOpenTemplate getTemplate(int id)
        {
            StoreOpenTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get StoreOpenTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_StoreOpenTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				StoreOpenTemplate storeopentemplate = new StoreOpenTemplate();
				//id，每个表都有
				storeopentemplate.Id = reader.GetInt32(startIndex++);
		
				storeopentemplate.itemTplId = reader.GetInt32(startIndex++);
	
				storeopentemplate.itemNum = reader.GetInt32(startIndex++);
	
				StoreOpenTemplateDB.Instance.addTemplate(storeopentemplate);
				}
			}
		}

}
}