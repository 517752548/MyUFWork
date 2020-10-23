using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 商品主标签
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TradeMainTagTemplateDBBase : TemplateDBBase<TradeMainTagTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TradeMainTagTemplate> idKeyDic = new Dictionary<int, TradeMainTagTemplate>();
        
		protected static TradeMainTagTemplateDB _ins;
        public static TradeMainTagTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TradeMainTagTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TradeMainTagTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TradeMainTagTemplate trademaintagtemplate)
        {
            if (this.idKeyDic.ContainsKey(trademaintagtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + trademaintagtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(trademaintagtemplate.Id, trademaintagtemplate);
            return true;
        }

        public override TradeMainTagTemplate getTemplate(int id)
        {
            TradeMainTagTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TradeMainTagTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TradeMainTagTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TradeMainTagTemplate trademaintagtemplate = new TradeMainTagTemplate();
				//id，每个表都有
				trademaintagtemplate.Id = reader.GetInt32(startIndex++);
		
				trademaintagtemplate.name = reader.GetString(startIndex++);
	
				trademaintagtemplate.commodityType = reader.GetInt32(startIndex++);
	
				trademaintagtemplate.displayIndex = reader.GetInt32(startIndex++);
	
				TradeMainTagTemplateDB.Instance.addTemplate(trademaintagtemplate);
				}
			}
		}

}
}