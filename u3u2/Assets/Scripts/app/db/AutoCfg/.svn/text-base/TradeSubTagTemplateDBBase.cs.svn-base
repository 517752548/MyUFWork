using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 商品子标签
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TradeSubTagTemplateDBBase : TemplateDBBase<TradeSubTagTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TradeSubTagTemplate> idKeyDic = new Dictionary<int, TradeSubTagTemplate>();
        
		protected static TradeSubTagTemplateDB _ins;
        public static TradeSubTagTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TradeSubTagTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TradeSubTagTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TradeSubTagTemplate tradesubtagtemplate)
        {
            if (this.idKeyDic.ContainsKey(tradesubtagtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + tradesubtagtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(tradesubtagtemplate.Id, tradesubtagtemplate);
            return true;
        }

        public override TradeSubTagTemplate getTemplate(int id)
        {
            TradeSubTagTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TradeSubTagTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TradeSubTagTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TradeSubTagTemplate tradesubtagtemplate = new TradeSubTagTemplate();
				//id，每个表都有
				tradesubtagtemplate.Id = reader.GetInt32(startIndex++);
		
				tradesubtagtemplate.name = reader.GetString(startIndex++);
	
				tradesubtagtemplate.mainTagId = reader.GetInt32(startIndex++);
	
				tradesubtagtemplate.displayIndex = reader.GetInt32(startIndex++);
	
				tradesubtagtemplate.displayIcon = reader.GetString(startIndex++);
	
				tradesubtagtemplate.jobType = reader.GetInt32(startIndex++);
	
				tradesubtagtemplate.sex = reader.GetInt32(startIndex++);
	
				TradeSubTagTemplateDB.Instance.addTemplate(tradesubtagtemplate);
				}
			}
		}

}
}