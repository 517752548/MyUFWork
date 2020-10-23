using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 地图基础模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MapTemplateDBBase : TemplateDBBase<MapTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MapTemplate> idKeyDic = new Dictionary<int, MapTemplate>();
        
		protected static MapTemplateDB _ins;
        public static MapTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MapTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MapTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MapTemplate maptemplate)
        {
            if (this.idKeyDic.ContainsKey(maptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + maptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(maptemplate.Id, maptemplate);
            return true;
        }

        public override MapTemplate getTemplate(int id)
        {
            MapTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MapTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MapTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MapTemplate maptemplate = new MapTemplate();
				//id，每个表都有
				maptemplate.Id = reader.GetInt32(startIndex++);
		
				maptemplate.nameLangId = reader.GetInt32(startIndex++);
	
				maptemplate.name = reader.GetString(startIndex++);
	
				maptemplate.mapTypeId = reader.GetInt32(startIndex++);
	
				maptemplate.mapLevel = reader.GetInt32(startIndex++);
	
				maptemplate.openLevel = reader.GetInt32(startIndex++);
	
				maptemplate.icon = reader.GetString(startIndex++);
	
				maptemplate.music = reader.GetString(startIndex++);
	
				maptemplate.width = reader.GetInt32(startIndex++);
	
				maptemplate.height = reader.GetInt32(startIndex++);
	
				maptemplate.initX = reader.GetInt32(startIndex++);
	
				maptemplate.initY = reader.GetInt32(startIndex++);
	
				maptemplate.meetMonsterPlanId = reader.GetInt32(startIndex++);
	
				maptemplate.meetMonsterAddProb = reader.GetInt32(startIndex++);
	
				maptemplate.pvpFlag = reader.GetInt32(startIndex++);
	
				maptemplate.treasureMap = reader.GetInt32(startIndex++);
	
				maptemplate.guajiFlag = reader.GetInt32(startIndex++);
	
				maptemplate.desc = reader.GetString(startIndex++);
	
				MapTemplateDB.Instance.addTemplate(maptemplate);
				}
			}
		}

}
}