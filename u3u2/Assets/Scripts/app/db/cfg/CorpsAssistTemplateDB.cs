using System.Collections.Generic;
namespace app.db
{
    public class CorpsAssistTemplateDB : CorpsAssistTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        public Dictionary<int, CorpsAssistTemplate> GetSkillIdkeyDic()
        {
            Dictionary<int, CorpsAssistTemplate> result = new Dictionary<int, CorpsAssistTemplate>();
            foreach (var item in idKeyDic)
            {
                result.Add(item.Value.assistId, item.Value);
            }
            return result;
        }
        
    }
}
