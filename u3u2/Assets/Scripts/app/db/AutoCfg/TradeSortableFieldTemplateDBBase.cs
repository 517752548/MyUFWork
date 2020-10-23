using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 可排序字段
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TradeSortableFieldTemplateDBBase : TemplateDBBase<TradeSortableFieldTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TradeSortableFieldTemplate> idKeyDic = new Dictionary<int, TradeSortableFieldTemplate>();
        
		protected static TradeSortableFieldTemplateDB _ins;
        public static TradeSortableFieldTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TradeSortableFieldTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TradeSortableFieldTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TradeSortableFieldTemplate tradesortablefieldtemplate)
        {
            if (this.idKeyDic.ContainsKey(tradesortablefieldtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + tradesortablefieldtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(tradesortablefieldtemplate.Id, tradesortablefieldtemplate);
            return true;
        }

        public override TradeSortableFieldTemplate getTemplate(int id)
        {
            TradeSortableFieldTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TradeSortableFieldTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TradeSortableFieldTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TradeSortableFieldTemplate tradesortablefieldtemplate = new TradeSortableFieldTemplate();
				//id，每个表都有
				tradesortablefieldtemplate.Id = reader.GetInt32(startIndex++);
		
				tradesortablefieldtemplate.name = reader.GetString(startIndex++);
	
				TradeSortableFieldTemplateDB.Instance.addTemplate(tradesortablefieldtemplate);
				}
			}
		}

}
}