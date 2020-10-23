using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 可消耗物品模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ConsumeItemTemplateDBBase : TemplateDBBase<ConsumeItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ConsumeItemTemplate> idKeyDic = new Dictionary<int, ConsumeItemTemplate>();
        
		protected static ConsumeItemTemplateDB _ins;
        public static ConsumeItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ConsumeItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ConsumeItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ConsumeItemTemplate consumeitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(consumeitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + consumeitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(consumeitemtemplate.Id, consumeitemtemplate);
            return true;
        }

        public override ConsumeItemTemplate getTemplate(int id)
        {
            ConsumeItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ConsumeItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ConsumeItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ConsumeItemTemplate consumeitemtemplate = new ConsumeItemTemplate();
				//id，每个表都有
				consumeitemtemplate.Id = reader.GetInt32(startIndex++);
		
				consumeitemtemplate.nameLangId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.name = reader.GetString(startIndex++);
	
				consumeitemtemplate.descLangId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.desc = reader.GetString(startIndex++);
	
				consumeitemtemplate.icon = reader.GetString(startIndex++);
	
				consumeitemtemplate.bindTypeId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.identityTypeId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.itemTypeId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.bagId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.rarityId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.level = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.maxOverlap = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.pageId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.orderId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.canUsed = reader.GetBoolean(startIndex++);
	
				consumeitemtemplate.canSelled = reader.GetBoolean(startIndex++);
	
				consumeitemtemplate.sellCurrencyId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.sellPrice = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.modelId = reader.GetString(startIndex++);
	
				consumeitemtemplate.canCompose = reader.GetBoolean(startIndex++);
	
				consumeitemtemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.listingFee = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.tradeBasePriceType = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.tradeBasePrice = reader.GetInt32(startIndex++);
	
		        consumeitemtemplate.wayList = new List<ItemGetWayTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            consumeitemtemplate.wayList.Add(new ItemGetWayTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				consumeitemtemplate.expiredHour = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.composeNum = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.composeItemId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.composeGold = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.fightUseFlag = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.costTypeId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.costArgA = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.costArgB = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.useTargetId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.fastUseTip = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.functionId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.argA = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.argB = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.argC = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.argD = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.argE = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.argF = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.mapId = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.tileX = reader.GetInt32(startIndex++);
	
				consumeitemtemplate.tileY = reader.GetInt32(startIndex++);
	
				ConsumeItemTemplateDB.Instance.addTemplate(consumeitemtemplate);
				}
			}
		}

}
}