using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 兑换模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ExchangeTemplateDBBase : TemplateDBBase<ExchangeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ExchangeTemplate> idKeyDic = new Dictionary<int, ExchangeTemplate>();
        
		protected static ExchangeTemplateDB _ins;
        public static ExchangeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ExchangeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ExchangeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ExchangeTemplate exchangetemplate)
        {
            if (this.idKeyDic.ContainsKey(exchangetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + exchangetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(exchangetemplate.Id, exchangetemplate);
            return true;
        }

        public override ExchangeTemplate getTemplate(int id)
        {
            ExchangeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ExchangeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ExchangeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ExchangeTemplate exchangetemplate = new ExchangeTemplate();
				//id，每个表都有
				exchangetemplate.Id = reader.GetInt32(startIndex++);
		
				exchangetemplate.costId = reader.GetInt32(startIndex++);
	
				exchangetemplate.exchangeId = reader.GetInt32(startIndex++);
	
				exchangetemplate.scale = reader.GetInt32(startIndex++);
	
				ExchangeTemplateDB.Instance.addTemplate(exchangetemplate);
				}
			}
		}

}
}