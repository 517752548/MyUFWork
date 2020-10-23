
using System.Collections.Generic;

namespace app.db
{
    public class StoryBattleTemplateDB : StoryBattleTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        /// <summary>
        /// 根据 剧情Id获得 剧情战报模板列表
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public List<StoryBattleTemplate> GetTplByStoryId(int storyId)
        {
            List<StoryBattleTemplate> list = new List<StoryBattleTemplate>();
            foreach (KeyValuePair<int, StoryBattleTemplate> pair in idKeyDic)
            {
                if (pair.Value.storyId == storyId)
                {
                    list.Add(pair.Value);
                }
            }
            return list;
        }
    }
}
