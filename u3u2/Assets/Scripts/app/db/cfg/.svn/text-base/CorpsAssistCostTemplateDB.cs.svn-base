
namespace app.db
{
    public class CorpsAssistCostTemplateDB : CorpsAssistCostTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        public CorpsAssistCostTemplate GetTplByLevel(int level)
        {
            foreach (var item in idKeyDic)
            {
                if (item.Value.assistLevel == level)
                {
                    return item.Value;
                }
            }
            return null;
        }
        
    }
}
