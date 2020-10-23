using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 通天塔地图对应关系
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TowerMapTemplateDBBase : TemplateDBBase<TowerMapTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TowerMapTemplate> idKeyDic = new Dictionary<int, TowerMapTemplate>();
        
		protected static TowerMapTemplateDB _ins;
        public static TowerMapTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TowerMapTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TowerMapTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TowerMapTemplate towermaptemplate)
        {
            if (this.idKeyDic.ContainsKey(towermaptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + towermaptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(towermaptemplate.Id, towermaptemplate);
            return true;
        }

        public override TowerMapTemplate getTemplate(int id)
        {
            TowerMapTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TowerMapTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TowerMapTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TowerMapTemplate towermaptemplate = new TowerMapTemplate();
				//id，每个表都有
				towermaptemplate.Id = reader.GetInt32(startIndex++);
		
				towermaptemplate.towerLevelId = reader.GetInt32(startIndex++);
	
				towermaptemplate.mapId = reader.GetInt32(startIndex++);
	
				towermaptemplate.rewardId = reader.GetInt32(startIndex++);
	
				towermaptemplate.showRewardName = reader.GetString(startIndex++);
	
				towermaptemplate.showRewardId = reader.GetInt32(startIndex++);
	
				towermaptemplate.model3DId = reader.GetString(startIndex++);
	
				towermaptemplate.recommendLevel = reader.GetString(startIndex++);
	
				TowerMapTemplateDB.Instance.addTemplate(towermaptemplate);
				}
			}
		}

}
}