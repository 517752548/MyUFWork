using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 可交易的物品
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TradeSaleableTemplateDBBase : TemplateDBBase<TradeSaleableTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TradeSaleableTemplate> idKeyDic = new Dictionary<int, TradeSaleableTemplate>();
        
		protected static TradeSaleableTemplateDB _ins;
        public static TradeSaleableTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TradeSaleableTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TradeSaleableTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TradeSaleableTemplate tradesaleabletemplate)
        {
            if (this.idKeyDic.ContainsKey(tradesaleabletemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + tradesaleabletemplate.Id);
                return false;
            }
            this.idKeyDic.Add(tradesaleabletemplate.Id, tradesaleabletemplate);
            return true;
        }

        public override TradeSaleableTemplate getTemplate(int id)
        {
            TradeSaleableTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TradeSaleableTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TradeSaleableTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TradeSaleableTemplate tradesaleabletemplate = new TradeSaleableTemplate();
				//id，每个表都有
				tradesaleabletemplate.Id = reader.GetInt32(startIndex++);
		
				tradesaleabletemplate.templateId = reader.GetInt32(startIndex++);
	
				tradesaleabletemplate.commodityType = reader.GetInt32(startIndex++);
	
				tradesaleabletemplate.subTagId = reader.GetInt32(startIndex++);
	
				tradesaleabletemplate.isAvailable = reader.GetInt32(startIndex++);
	
				TradeSaleableTemplateDB.Instance.addTemplate(tradesaleabletemplate);
				}
			}
		}

}
}