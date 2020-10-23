using System.Collections.Generic;

namespace app.db
{
    public class LifeSkillMapTemplateDB : LifeSkillMapTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        // TODO 可能会自定义一些属性或方法
        /// <summary>
        /// 数据结构：<int mapid,<int Resid,LifeSkillMapTemplate Res>>
        /// </summary>
        public Dictionary<int, Dictionary<int, LifeSkillMapTemplate>> mapResDic;

        public void initMapResDic()
        {
            if (mapResDic == null)
            {
                mapResDic = new Dictionary<int, Dictionary<int, LifeSkillMapTemplate>>();
            }

            foreach (KeyValuePair<int, LifeSkillMapTemplate> pair in idKeyDic)
            {
                Dictionary<int, LifeSkillMapTemplate> mapResTmpDic;
                mapResDic.TryGetValue(pair.Value.mapId, out mapResTmpDic);
                if (mapResTmpDic == null)
                {
                    mapResTmpDic = new Dictionary<int, LifeSkillMapTemplate>();
                    mapResDic.Add(pair.Value.mapId, mapResTmpDic);
                }
                LifeSkillMapTemplate mapResTmp;
                mapResTmpDic.TryGetValue(pair.Value.resourceId, out mapResTmp);
                if (mapResTmp == null)
                {
                    mapResTmpDic.Add(pair.Value.resourceId, pair.Value);
                }
            }
        }

        /// <summary>
        /// 根据mapId获得地图上的所有Res的字典
        /// </summary>
        /// <param name="mapId"></param>
        /// <returns></returns>
        public Dictionary<int, LifeSkillMapTemplate> GetMapResDicByMapId(int mapId)
        {
            Dictionary<int, LifeSkillMapTemplate> mapResTmpDic;
            mapResDic.TryGetValue(mapId, out mapResTmpDic);
            return mapResTmpDic;
        }

        /// <summary>
        /// 获取资源类型
        /// </summary>
        /// <param name="mapid"></param>
        /// <param name="npcid"></param>
        /// <returns></returns>
        public LifeSkillMapTemplate GetMapResByMapidAndNpcid(int mapid, int npcid)
        {
            foreach (KeyValuePair<int, LifeSkillMapTemplate> pair in GetMapResDicByMapId(mapid))
            {
                if (pair.Value.resourceId == npcid)
                {
                    return pair.Value;
                }
            }
            return null;
        }
    }
}
