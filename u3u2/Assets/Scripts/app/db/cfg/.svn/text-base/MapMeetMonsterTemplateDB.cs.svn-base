using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class MapMeetMonsterTemplateDB : MapMeetMonsterTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        public List<MapMeetMonsterTemplate> GetTemplatesByPlanId(int planId)
        {
            List<MapMeetMonsterTemplate> res = new List<MapMeetMonsterTemplate>();
            foreach (var item in idKeyDic)
            {
                if (planId == item.Value.meetMonsterPlanId)
                res.Add(item.Value);
            }
            return res;
        }
    }
}
