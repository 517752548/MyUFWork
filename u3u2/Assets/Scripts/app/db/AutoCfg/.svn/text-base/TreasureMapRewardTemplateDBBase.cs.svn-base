using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 藏宝图奖励模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TreasureMapRewardTemplateDBBase : TemplateDBBase<TreasureMapRewardTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TreasureMapRewardTemplate> idKeyDic = new Dictionary<int, TreasureMapRewardTemplate>();
        
		protected static TreasureMapRewardTemplateDB _ins;
        public static TreasureMapRewardTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TreasureMapRewardTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TreasureMapRewardTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TreasureMapRewardTemplate treasuremaprewardtemplate)
        {
            if (this.idKeyDic.ContainsKey(treasuremaprewardtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + treasuremaprewardtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(treasuremaprewardtemplate.Id, treasuremaprewardtemplate);
            return true;
        }

        public override TreasureMapRewardTemplate getTemplate(int id)
        {
            TreasureMapRewardTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TreasureMapRewardTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TreasureMapRewardTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TreasureMapRewardTemplate treasuremaprewardtemplate = new TreasureMapRewardTemplate();
				//id，每个表都有
				treasuremaprewardtemplate.Id = reader.GetInt32(startIndex++);
		
				treasuremaprewardtemplate.itemId = reader.GetInt32(startIndex++);
	
				treasuremaprewardtemplate.triggerType = reader.GetInt32(startIndex++);
	
				treasuremaprewardtemplate.param = reader.GetInt32(startIndex++);
	
				treasuremaprewardtemplate.weight = reader.GetInt32(startIndex++);
	
				treasuremaprewardtemplate.loseReward = reader.GetInt32(startIndex++);
	
				TreasureMapRewardTemplateDB.Instance.addTemplate(treasuremaprewardtemplate);
				}
			}
		}

}
}