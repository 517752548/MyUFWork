
namespace app.db
{
    public class CorpsBuildingUpgradeTemplateDB : CorpsBuildingUpgradeTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        public CorpsBuildingUpgradeTemplate GetTemplateByTL(int type,int level)
        {
            foreach (var item in idKeyDic)
            {
                if (item.Value.buildType == type && item.Value.corpsBldgLevel == level)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public CorpsBuildingUpgradeTemplate GetTopLevelTpl(int type)
        {
            CorpsBuildingUpgradeTemplate result = null;
            foreach (var item in idKeyDic)
            {
                if (result == null)
                {
                    result = item.Value;
                }
                else
                {
                    if (item.Value.corpsBldgLevel > result.corpsBldgLevel)
                    {
                        result = item.Value;
                    }                      
                }
            }
            return result;
        }
        
    }
}
