using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class MapNpcTemplateDB : MapNpcTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        /// <summary>
        /// 数据结构：<int mapid,<int npcid,MapNpcTemplate npc>>
        /// </summary>
        public Dictionary<int, Dictionary<int,MapNpcTemplate>> mapNpcDic;

        public void initMapNpcDic()
        {
            if (mapNpcDic==null)
            {
                mapNpcDic = new Dictionary<int, Dictionary<int, MapNpcTemplate>>();
            }

            foreach (KeyValuePair<int, MapNpcTemplate> pair in idKeyDic)
            {
                Dictionary<int, MapNpcTemplate> mapNpcTmpDic;
                mapNpcDic.TryGetValue(pair.Value.mapId, out mapNpcTmpDic);
                if (mapNpcTmpDic == null)
                {
                    mapNpcTmpDic = new Dictionary<int, MapNpcTemplate>();
                    mapNpcDic.Add(pair.Value.mapId,mapNpcTmpDic);
                }
                MapNpcTemplate mapNpcTmp;
                mapNpcTmpDic.TryGetValue(pair.Value.npcId, out mapNpcTmp);
                if (mapNpcTmp==null)
                {
                    mapNpcTmpDic.Add(pair.Value.npcId, pair.Value);
                }
            }
        }

        /// <summary>
        /// 根据mapId获得地图上的所有npc的字典
        /// </summary>
        /// <param name="mapId"></param>
        /// <returns></returns>
        public Dictionary<int, MapNpcTemplate> GetMapNpcDicByMapId(int mapId)
        {
            Dictionary<int, MapNpcTemplate> mapNpcTmpDic;
            mapNpcDic.TryGetValue(mapId, out mapNpcTmpDic);
            return mapNpcTmpDic;
        }

        /// <summary>
        /// 根据mapId,npcId,获得地图上的一个npc数据
        /// </summary>
        /// <param name="mapId"></param>
        /// <returns></returns>
        public MapNpcTemplate GetMapNpcTmpByMapIdNpcId(int mapId,int npcId)
        {
            Dictionary<int, MapNpcTemplate> mapNpcTmpDic;
            mapNpcDic.TryGetValue(mapId, out mapNpcTmpDic);
            if (mapNpcTmpDic!=null)
            {
                MapNpcTemplate mapNpcTmp;
                mapNpcTmpDic.TryGetValue(npcId, out mapNpcTmp);
                return mapNpcTmp;
            }
            else
            {
                return null;
            }
        }
    }
}
