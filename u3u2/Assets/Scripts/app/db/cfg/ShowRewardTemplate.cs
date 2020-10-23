
namespace app.db
{
    public class ShowRewardTemplate : ShowRewardTemplateVO
    {
        // TODO 可能会自定义一些属性或方法

        public int GetRewardCount()
        {
            int count = 0;
            for (int i = 0; i < rewardTempalteSet.Count; ++i)
            {
                if (rewardTempalteSet[i].rewardTypeId > 0)
                {
                    ++count;
                }
            }
            return count;
        }
    }
}
