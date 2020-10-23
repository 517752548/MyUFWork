
namespace app.db
{
    public class CorpsCultivateCostTemplateDB : CorpsCultivateCostTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        public CorpsCultivateCostTemplate GetTemplateByLevel(int level)
        {
            foreach (var item in idKeyDic)
            {
                if (item.Value.cultivateLevel == level)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public long GetUpgradeExp(int level)
        {
            long needExp = 0;
            CorpsCultivateCostTemplate tpl;
            for (int i = 0; i <= level; i++)
            {
                tpl = GetTemplateByLevel(i);
                if (tpl != null)
                {
                    needExp += tpl.costExp;
                }
            }
            return needExp;
        }
        
    }
}
