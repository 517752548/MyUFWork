using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 神秘商店
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MysteryShopItemTemplateDBBase : TemplateDBBase<MysteryShopItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MysteryShopItemTemplate> idKeyDic = new Dictionary<int, MysteryShopItemTemplate>();
        
		protected static MysteryShopItemTemplateDB _ins;
        public static MysteryShopItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MysteryShopItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MysteryShopItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MysteryShopItemTemplate mysteryshopitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(mysteryshopitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + mysteryshopitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(mysteryshopitemtemplate.Id, mysteryshopitemtemplate);
            return true;
        }

        public override MysteryShopItemTemplate getTemplate(int id)
        {
            MysteryShopItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MysteryShopItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MysteryShopItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MysteryShopItemTemplate mysteryshopitemtemplate = new MysteryShopItemTemplate();
				//id，每个表都有
				mysteryshopitemtemplate.Id = reader.GetInt32(startIndex++);
		
				mysteryshopitemtemplate.lowerLimit = reader.GetInt32(startIndex++);
	
				mysteryshopitemtemplate.upperLimit = reader.GetInt32(startIndex++);
	
				mysteryshopitemtemplate.tempId = reader.GetInt32(startIndex++);
	
				mysteryshopitemtemplate.num = reader.GetInt32(startIndex++);
	
		        mysteryshopitemtemplate.priceList = new List<CurrencyTemplate>(1);
		        for (int i = 0; i < 1; i++)
		        {
		            mysteryshopitemtemplate.priceList.Add(new CurrencyTemplate(reader, startIndex));
		            startIndex += 2;
		        }
	
				mysteryshopitemtemplate.discount = reader.GetInt32(startIndex++);
	
				mysteryshopitemtemplate.weight = reader.GetInt32(startIndex++);
	
				MysteryShopItemTemplateDB.Instance.addTemplate(mysteryshopitemtemplate);
				}
			}
		}

}
}