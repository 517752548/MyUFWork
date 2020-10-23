using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 装备位升星
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class UpgradeEquipStarTemplateDBBase : TemplateDBBase<UpgradeEquipStarTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, UpgradeEquipStarTemplate> idKeyDic = new Dictionary<int, UpgradeEquipStarTemplate>();
        
		protected static UpgradeEquipStarTemplateDB _ins;
        public static UpgradeEquipStarTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new UpgradeEquipStarTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, UpgradeEquipStarTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(UpgradeEquipStarTemplate upgradeequipstartemplate)
        {
            if (this.idKeyDic.ContainsKey(upgradeequipstartemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + upgradeequipstartemplate.Id);
                return false;
            }
            this.idKeyDic.Add(upgradeequipstartemplate.Id, upgradeequipstartemplate);
            return true;
        }

        public override UpgradeEquipStarTemplate getTemplate(int id)
        {
            UpgradeEquipStarTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get UpgradeEquipStarTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_UpgradeEquipStarTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				UpgradeEquipStarTemplate upgradeequipstartemplate = new UpgradeEquipStarTemplate();
				//id，每个表都有
				upgradeequipstartemplate.Id = reader.GetInt32(startIndex++);
		
				upgradeequipstartemplate.baseItemId = reader.GetInt32(startIndex++);
	
				upgradeequipstartemplate.baseItemNum = reader.GetInt32(startIndex++);
	
				upgradeequipstartemplate.baseProb = reader.GetInt32(startIndex++);
	
				upgradeequipstartemplate.extraItemId = reader.GetInt32(startIndex++);
	
				upgradeequipstartemplate.extraItemNum = reader.GetInt32(startIndex++);
	
				upgradeequipstartemplate.extraItemProb = reader.GetInt32(startIndex++);
	
				upgradeequipstartemplate.scale = reader.GetInt32(startIndex++);
	
				upgradeequipstartemplate.level = reader.GetInt32(startIndex++);
	
				upgradeequipstartemplate.coins = reader.GetInt32(startIndex++);
	
				UpgradeEquipStarTemplateDB.Instance.addTemplate(upgradeequipstartemplate);
				}
			}
		}

}
}