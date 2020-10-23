using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 地图遇怪方案
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MapMeetMonsterTemplateDBBase : TemplateDBBase<MapMeetMonsterTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MapMeetMonsterTemplate> idKeyDic = new Dictionary<int, MapMeetMonsterTemplate>();
        
		protected static MapMeetMonsterTemplateDB _ins;
        public static MapMeetMonsterTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MapMeetMonsterTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MapMeetMonsterTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MapMeetMonsterTemplate mapmeetmonstertemplate)
        {
            if (this.idKeyDic.ContainsKey(mapmeetmonstertemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + mapmeetmonstertemplate.Id);
                return false;
            }
            this.idKeyDic.Add(mapmeetmonstertemplate.Id, mapmeetmonstertemplate);
            return true;
        }

        public override MapMeetMonsterTemplate getTemplate(int id)
        {
            MapMeetMonsterTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MapMeetMonsterTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MapMeetMonsterTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MapMeetMonsterTemplate mapmeetmonstertemplate = new MapMeetMonsterTemplate();
				//id，每个表都有
				mapmeetmonstertemplate.Id = reader.GetInt32(startIndex++);
		
				mapmeetmonstertemplate.meetMonsterPlanId = reader.GetInt32(startIndex++);
	
				mapmeetmonstertemplate.enemyArmyId = reader.GetInt32(startIndex++);
	
				mapmeetmonstertemplate.weight = reader.GetInt32(startIndex++);
	
				MapMeetMonsterTemplateDB.Instance.addTemplate(mapmeetmonstertemplate);
				}
			}
		}

}
}