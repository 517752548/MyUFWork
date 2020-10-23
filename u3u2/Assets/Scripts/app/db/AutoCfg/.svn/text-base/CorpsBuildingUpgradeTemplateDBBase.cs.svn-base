using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 帮派建筑升级配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsBuildingUpgradeTemplateDBBase : TemplateDBBase<CorpsBuildingUpgradeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CorpsBuildingUpgradeTemplate> idKeyDic = new Dictionary<int, CorpsBuildingUpgradeTemplate>();
        
		protected static CorpsBuildingUpgradeTemplateDB _ins;
        public static CorpsBuildingUpgradeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CorpsBuildingUpgradeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CorpsBuildingUpgradeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CorpsBuildingUpgradeTemplate corpsbuildingupgradetemplate)
        {
            if (this.idKeyDic.ContainsKey(corpsbuildingupgradetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + corpsbuildingupgradetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(corpsbuildingupgradetemplate.Id, corpsbuildingupgradetemplate);
            return true;
        }

        public override CorpsBuildingUpgradeTemplate getTemplate(int id)
        {
            CorpsBuildingUpgradeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CorpsBuildingUpgradeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CorpsBuildingUpgradeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CorpsBuildingUpgradeTemplate corpsbuildingupgradetemplate = new CorpsBuildingUpgradeTemplate();
				//id，每个表都有
				corpsbuildingupgradetemplate.Id = reader.GetInt32(startIndex++);
		
				corpsbuildingupgradetemplate.buildType = reader.GetInt32(startIndex++);
	
				corpsbuildingupgradetemplate.corpsBldgLevel = reader.GetInt32(startIndex++);
	
				corpsbuildingupgradetemplate.upgradeExp = reader.GetInt32(startIndex++);
	
				corpsbuildingupgradetemplate.upgradeFund = reader.GetInt32(startIndex++);
	
				corpsbuildingupgradetemplate.upgradeTime = reader.GetInt32(startIndex++);
	
				CorpsBuildingUpgradeTemplateDB.Instance.addTemplate(corpsbuildingupgradetemplate);
				}
			}
		}

}
}