using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 地图npc模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MapNpcTemplateDBBase : TemplateDBBase<MapNpcTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MapNpcTemplate> idKeyDic = new Dictionary<int, MapNpcTemplate>();
        
		protected static MapNpcTemplateDB _ins;
        public static MapNpcTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MapNpcTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MapNpcTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MapNpcTemplate mapnpctemplate)
        {
            if (this.idKeyDic.ContainsKey(mapnpctemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + mapnpctemplate.Id);
                return false;
            }
            this.idKeyDic.Add(mapnpctemplate.Id, mapnpctemplate);
            return true;
        }

        public override MapNpcTemplate getTemplate(int id)
        {
            MapNpcTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MapNpcTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MapNpcTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MapNpcTemplate mapnpctemplate = new MapNpcTemplate();
				//id，每个表都有
				mapnpctemplate.Id = reader.GetInt32(startIndex++);
		
				mapnpctemplate.mapId = reader.GetInt32(startIndex++);
	
				mapnpctemplate.npcId = reader.GetInt32(startIndex++);
	
				mapnpctemplate.pixelFlag = reader.GetInt32(startIndex++);
	
				mapnpctemplate.x = reader.GetInt32(startIndex++);
	
				mapnpctemplate.y = reader.GetInt32(startIndex++);
	
				MapNpcTemplateDB.Instance.addTemplate(mapnpctemplate);
				}
			}
		}

}
}