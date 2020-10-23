using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 商城普通物品配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MallNormalItemTemplateDBBase : TemplateDBBase<MallNormalItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MallNormalItemTemplate> idKeyDic = new Dictionary<int, MallNormalItemTemplate>();
        
		protected static MallNormalItemTemplateDB _ins;
        public static MallNormalItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MallNormalItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MallNormalItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MallNormalItemTemplate mallnormalitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(mallnormalitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + mallnormalitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(mallnormalitemtemplate.Id, mallnormalitemtemplate);
            return true;
        }

        public override MallNormalItemTemplate getTemplate(int id)
        {
            MallNormalItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MallNormalItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MallNormalItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MallNormalItemTemplate mallnormalitemtemplate = new MallNormalItemTemplate();
				//id，每个表都有
				mallnormalitemtemplate.Id = reader.GetInt32(startIndex++);
		
				mallnormalitemtemplate.notSale = reader.GetInt32(startIndex++);
	
				mallnormalitemtemplate.sortId = reader.GetInt32(startIndex++);
	
		        mallnormalitemtemplate.normalItemList = new List<ItemCostTemplate>(1);
		        for (int i = 0; i < 1; i++)
		        {
		            mallnormalitemtemplate.normalItemList.Add(new ItemCostTemplate(reader, startIndex));
		            startIndex += 2;
		        }
	
				mallnormalitemtemplate.catalogId = reader.GetInt32(startIndex++);
	
				mallnormalitemtemplate.sellWell = reader.GetBoolean(startIndex++);
	
		        mallnormalitemtemplate.priceList = new List<CurrencyTemplate>(2);
		        for (int i = 0; i < 2; i++)
		        {
		            mallnormalitemtemplate.priceList.Add(new CurrencyTemplate(reader, startIndex));
		            startIndex += 2;
		        }
	
		        mallnormalitemtemplate.exchangeItemList = new List<ItemCostTemplate>(2);
		        for (int i = 0; i < 2; i++)
		        {
		            mallnormalitemtemplate.exchangeItemList.Add(new ItemCostTemplate(reader, startIndex));
		            startIndex += 2;
		        }
	
				mallnormalitemtemplate.marks = reader.GetString(startIndex++);
	
				mallnormalitemtemplate.subTag = reader.GetInt32(startIndex++);
	
				MallNormalItemTemplateDB.Instance.addTemplate(mallnormalitemtemplate);
				}
			}
		}

}
}