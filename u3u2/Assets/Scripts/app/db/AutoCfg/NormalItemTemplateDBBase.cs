using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 普通道具配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class NormalItemTemplateDBBase : TemplateDBBase<NormalItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, NormalItemTemplate> idKeyDic = new Dictionary<int, NormalItemTemplate>();
        
		protected static NormalItemTemplateDB _ins;
        public static NormalItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new NormalItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, NormalItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(NormalItemTemplate normalitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(normalitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + normalitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(normalitemtemplate.Id, normalitemtemplate);
            return true;
        }

        public override NormalItemTemplate getTemplate(int id)
        {
            NormalItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get NormalItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_NormalItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				NormalItemTemplate normalitemtemplate = new NormalItemTemplate();
				//id，每个表都有
				normalitemtemplate.Id = reader.GetInt32(startIndex++);
		
				normalitemtemplate.nameLangId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.name = reader.GetString(startIndex++);
	
				normalitemtemplate.descLangId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.desc = reader.GetString(startIndex++);
	
				normalitemtemplate.icon = reader.GetString(startIndex++);
	
				normalitemtemplate.bindTypeId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.identityTypeId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.itemTypeId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.bagId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.rarityId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.level = reader.GetInt32(startIndex++);
	
				normalitemtemplate.maxOverlap = reader.GetInt32(startIndex++);
	
				normalitemtemplate.pageId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.orderId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.canUsed = reader.GetBoolean(startIndex++);
	
				normalitemtemplate.canSelled = reader.GetBoolean(startIndex++);
	
				normalitemtemplate.sellCurrencyId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.sellPrice = reader.GetInt32(startIndex++);
	
				normalitemtemplate.modelId = reader.GetString(startIndex++);
	
				normalitemtemplate.canCompose = reader.GetBoolean(startIndex++);
	
				normalitemtemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				normalitemtemplate.listingFee = reader.GetInt32(startIndex++);
	
				normalitemtemplate.tradeBasePriceType = reader.GetInt32(startIndex++);
	
				normalitemtemplate.tradeBasePrice = reader.GetInt32(startIndex++);
	
		        normalitemtemplate.wayList = new List<ItemGetWayTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            normalitemtemplate.wayList.Add(new ItemGetWayTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				normalitemtemplate.expiredHour = reader.GetInt32(startIndex++);
	
				normalitemtemplate.composeNum = reader.GetInt32(startIndex++);
	
				normalitemtemplate.composeItemId = reader.GetInt32(startIndex++);
	
				normalitemtemplate.composeGold = reader.GetInt32(startIndex++);
	
				NormalItemTemplateDB.Instance.addTemplate(normalitemtemplate);
				}
			}
		}

}
}