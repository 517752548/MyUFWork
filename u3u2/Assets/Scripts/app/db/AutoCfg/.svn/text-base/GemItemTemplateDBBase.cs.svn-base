using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物技能书
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemItemTemplateDBBase : TemplateDBBase<GemItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, GemItemTemplate> idKeyDic = new Dictionary<int, GemItemTemplate>();
        
		protected static GemItemTemplateDB _ins;
        public static GemItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new GemItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, GemItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(GemItemTemplate gemitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(gemitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + gemitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(gemitemtemplate.Id, gemitemtemplate);
            return true;
        }

        public override GemItemTemplate getTemplate(int id)
        {
            GemItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get GemItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_GemItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				GemItemTemplate gemitemtemplate = new GemItemTemplate();
				//id，每个表都有
				gemitemtemplate.Id = reader.GetInt32(startIndex++);
		
				gemitemtemplate.nameLangId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.name = reader.GetString(startIndex++);
	
				gemitemtemplate.descLangId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.desc = reader.GetString(startIndex++);
	
				gemitemtemplate.icon = reader.GetString(startIndex++);
	
				gemitemtemplate.bindTypeId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.identityTypeId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.itemTypeId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.bagId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.rarityId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.level = reader.GetInt32(startIndex++);
	
				gemitemtemplate.maxOverlap = reader.GetInt32(startIndex++);
	
				gemitemtemplate.pageId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.orderId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.canUsed = reader.GetBoolean(startIndex++);
	
				gemitemtemplate.canSelled = reader.GetBoolean(startIndex++);
	
				gemitemtemplate.sellCurrencyId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.sellPrice = reader.GetInt32(startIndex++);
	
				gemitemtemplate.modelId = reader.GetString(startIndex++);
	
				gemitemtemplate.canCompose = reader.GetBoolean(startIndex++);
	
				gemitemtemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				gemitemtemplate.listingFee = reader.GetInt32(startIndex++);
	
				gemitemtemplate.tradeBasePriceType = reader.GetInt32(startIndex++);
	
				gemitemtemplate.tradeBasePrice = reader.GetInt32(startIndex++);
	
		        gemitemtemplate.wayList = new List<ItemGetWayTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            gemitemtemplate.wayList.Add(new ItemGetWayTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				gemitemtemplate.expiredHour = reader.GetInt32(startIndex++);
	
				gemitemtemplate.composeNum = reader.GetInt32(startIndex++);
	
				gemitemtemplate.composeItemId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.composeGold = reader.GetInt32(startIndex++);
	
				gemitemtemplate.propKey = reader.GetInt32(startIndex++);
	
				gemitemtemplate.propValue = reader.GetInt32(startIndex++);
	
				gemitemtemplate.gemTypeId = reader.GetInt32(startIndex++);
	
				gemitemtemplate.gemLevel = reader.GetInt32(startIndex++);
	
				gemitemtemplate.gemGroup = reader.GetInt32(startIndex++);
	
				GemItemTemplateDB.Instance.addTemplate(gemitemtemplate);
				}
			}
		}

}
}