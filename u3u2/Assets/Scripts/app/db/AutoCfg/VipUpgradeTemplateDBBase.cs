using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * VIP权限配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class VipUpgradeTemplateDBBase : TemplateDBBase<VipUpgradeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, VipUpgradeTemplate> idKeyDic = new Dictionary<int, VipUpgradeTemplate>();
        
		protected static VipUpgradeTemplateDB _ins;
        public static VipUpgradeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new VipUpgradeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, VipUpgradeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(VipUpgradeTemplate vipupgradetemplate)
        {
            if (this.idKeyDic.ContainsKey(vipupgradetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + vipupgradetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(vipupgradetemplate.Id, vipupgradetemplate);
            return true;
        }

        public override VipUpgradeTemplate getTemplate(int id)
        {
            VipUpgradeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get VipUpgradeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_VipUpgradeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				VipUpgradeTemplate vipupgradetemplate = new VipUpgradeTemplate();
				//id，每个表都有
				vipupgradetemplate.Id = reader.GetInt32(startIndex++);
		
				vipupgradetemplate.requireExp = reader.GetInt64(startIndex++);
	
				vipupgradetemplate.dayRewardId = reader.GetInt32(startIndex++);
	
				VipUpgradeTemplateDB.Instance.addTemplate(vipupgradetemplate);
				}
			}
		}

}
}