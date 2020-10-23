using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class SkillPerformTemplateDB : SkillPerformTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        public SkillPerformTemplate getTemplateByComposeId(string composeId)
        {
            SkillPerformTemplate data = null;
            data = this.idKeyDic.FirstOrDefault(q => q.Value.composeId == composeId).Value;
            if (data == null)
            {
                ClientLog.LogError("get SkillPerformTemplate error!data is null! composeId=" + composeId);
            }
            return data;
        }
        
        public SkillPerformTemplate getTemplateByComposeIdAndEffectId(string composeId, int effectId)
        {
            SkillPerformTemplate data = null;
            data = this.idKeyDic.FirstOrDefault(q => q.Value.composeId == composeId && q.Value.effectId == effectId).Value;
            /*
            if (data == null)
            {
                ClientLog.LogError("get SkillPerformTemplate error!data is null! composeId=" + composeId);
            }
            */
            return data;
        }
    }
}
