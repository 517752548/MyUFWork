using System.Collections;
using System.Collections.Generic;
using app.zone;

namespace app.db
{
    public class MapTemplateDB : MapTemplateDBBase {

        /// <summary>
        /// 根据地图类型 获得地图列表
        /// </summary>
        /// <param name="maptype"></param>
        /// <returns></returns>
        public List<MapTemplate> GetMapListByMapType(MapType maptype)
        {
            List<MapTemplate> list = new List<MapTemplate>();
            foreach (KeyValuePair<int, MapTemplate> pair in idKeyDic)
            {
                if (pair.Value.mapTypeId == (int)maptype)
                {
                    list.Add(pair.Value);
                }
            }
            return list;
        }
    }
}

