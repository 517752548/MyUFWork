using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 商品类别
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TradeCommodityTypeTemplateDBBase : TemplateDBBase<TradeCommodityTypeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TradeCommodityTypeTemplate> idKeyDic = new Dictionary<int, TradeCommodityTypeTemplate>();
        
		protected static TradeCommodityTypeTemplateDB _ins;
        public static TradeCommodityTypeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TradeCommodityTypeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TradeCommodityTypeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TradeCommodityTypeTemplate tradecommoditytypetemplate)
        {
            if (this.idKeyDic.ContainsKey(tradecommoditytypetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + tradecommoditytypetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(tradecommoditytypetemplate.Id, tradecommoditytypetemplate);
            return true;
        }

        public override TradeCommodityTypeTemplate getTemplate(int id)
        {
            TradeCommodityTypeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TradeCommodityTypeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TradeCommodityTypeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TradeCommodityTypeTemplate tradecommoditytypetemplate = new TradeCommodityTypeTemplate();
				//id，每个表都有
				tradecommoditytypetemplate.Id = reader.GetInt32(startIndex++);
		
				tradecommoditytypetemplate.name = reader.GetString(startIndex++);
	
				TradeCommodityTypeTemplateDB.Instance.addTemplate(tradecommoditytypetemplate);
				}
			}
		}

}
}