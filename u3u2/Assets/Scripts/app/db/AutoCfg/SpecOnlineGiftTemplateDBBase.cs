using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 特殊在线礼包
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SpecOnlineGiftTemplateDBBase : TemplateDBBase<SpecOnlineGiftTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SpecOnlineGiftTemplate> idKeyDic = new Dictionary<int, SpecOnlineGiftTemplate>();
        
		protected static SpecOnlineGiftTemplateDB _ins;
        public static SpecOnlineGiftTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SpecOnlineGiftTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SpecOnlineGiftTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SpecOnlineGiftTemplate speconlinegifttemplate)
        {
            if (this.idKeyDic.ContainsKey(speconlinegifttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + speconlinegifttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(speconlinegifttemplate.Id, speconlinegifttemplate);
            return true;
        }

        public override SpecOnlineGiftTemplate getTemplate(int id)
        {
            SpecOnlineGiftTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SpecOnlineGiftTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SpecOnlineGiftTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SpecOnlineGiftTemplate speconlinegifttemplate = new SpecOnlineGiftTemplate();
				//id，每个表都有
				speconlinegifttemplate.Id = reader.GetInt32(startIndex++);
		
				speconlinegifttemplate.cd = reader.GetInt64(startIndex++);
	
				speconlinegifttemplate.rewardId = reader.GetInt32(startIndex++);
	
				speconlinegifttemplate.iconId = reader.GetString(startIndex++);
	
				speconlinegifttemplate.resType = reader.GetInt32(startIndex++);
	
				speconlinegifttemplate.resId = reader.GetString(startIndex++);
	
				speconlinegifttemplate.offsetX = reader.GetInt32(startIndex++);
	
				speconlinegifttemplate.offsetY = reader.GetInt32(startIndex++);
	
				speconlinegifttemplate.artFontId = reader.GetInt32(startIndex++);
	
				speconlinegifttemplate.menuDescLangId = reader.GetInt32(startIndex++);
	
				speconlinegifttemplate.menuDesc = reader.GetString(startIndex++);
	
				speconlinegifttemplate.rewardDescLangId = reader.GetInt32(startIndex++);
	
				speconlinegifttemplate.rewardDesc = reader.GetString(startIndex++);
	
				speconlinegifttemplate.receiveDescLangId = reader.GetInt32(startIndex++);
	
				speconlinegifttemplate.receiveDesc = reader.GetString(startIndex++);
	
				SpecOnlineGiftTemplateDB.Instance.addTemplate(speconlinegifttemplate);
				}
			}
		}

}
}