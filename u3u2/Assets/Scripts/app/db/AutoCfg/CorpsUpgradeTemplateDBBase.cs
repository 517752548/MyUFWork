using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 军团升级模版
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsUpgradeTemplateDBBase : TemplateDBBase<CorpsUpgradeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsUpgradeTemplate> idKeyDic = new Dictionary<int, CorpsUpgradeTemplate>();
        
		protected static CorpsUpgradeTemplateDB _ins;
        public static CorpsUpgradeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsUpgradeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsUpgradeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsUpgradeTemplate corpsupgradetemplate)
        {
            if (this.idKeyDic.ContainsKey(corpsupgradetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpsupgradetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpsupgradetemplate.Id, corpsupgradetemplate);
            return true;
        }

        public override CorpsUpgradeTemplate getTemplate(int id)
        {
            CorpsUpgradeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsUpgradeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsUpgradeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsUpgradeTemplate corpsupgradetemplate = new CorpsUpgradeTemplate();
				//id，每个表都有
				corpsupgradetemplate.Id = reader.GetInt32(startIndex++);
		
				corpsupgradetemplate.corpsLevel = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.corpsBldgLevel = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.maxMemberNum = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.viceChairmanNum = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.hallmanNum = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.viceHallmanNum = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.hallsNum = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.eliteNum = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.upgradeExp = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.upgradeFund = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.upgradeTime = reader.GetInt32(startIndex++);
	
				corpsupgradetemplate.coprsMaintenanceCost = reader.GetInt32(startIndex++);
	
				CorpsUpgradeTemplateDB.Instance.addTemplate(corpsupgradetemplate);
				}
			}
		}

}
}