using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 翅膀升阶消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class WingUpgradeTemplateDBBase : TemplateDBBase<WingUpgradeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, WingUpgradeTemplate> idKeyDic = new Dictionary<int, WingUpgradeTemplate>();
        
		protected static WingUpgradeTemplateDB _ins;
        public static WingUpgradeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new WingUpgradeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, WingUpgradeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(WingUpgradeTemplate wingupgradetemplate)
        {
            if (this.idKeyDic.ContainsKey(wingupgradetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + wingupgradetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(wingupgradetemplate.Id, wingupgradetemplate);
            return true;
        }

        public override WingUpgradeTemplate getTemplate(int id)
        {
            WingUpgradeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get WingUpgradeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_WingUpgradeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				WingUpgradeTemplate wingupgradetemplate = new WingUpgradeTemplate();
				//id，每个表都有
				wingupgradetemplate.Id = reader.GetInt32(startIndex++);
		
				wingupgradetemplate.wingTplId = reader.GetInt32(startIndex++);
	
				wingupgradetemplate.wingLevel = reader.GetInt32(startIndex++);
	
				wingupgradetemplate.itemId = reader.GetInt32(startIndex++);
	
				wingupgradetemplate.itemNum = reader.GetInt32(startIndex++);
	
				wingupgradetemplate.currencyType = reader.GetInt32(startIndex++);
	
				wingupgradetemplate.currencyNum = reader.GetInt32(startIndex++);
	
				wingupgradetemplate.upgradeProp = reader.GetInt32(startIndex++);
	
				wingupgradetemplate.blessMaxValue = reader.GetInt32(startIndex++);
	
				WingUpgradeTemplateDB.Instance.addTemplate(wingupgradetemplate);
				}
			}
		}

}
}