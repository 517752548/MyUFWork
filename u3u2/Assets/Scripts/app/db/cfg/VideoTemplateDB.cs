using System.Collections.Generic;

namespace app.db
{
    public class VideoTemplateDB : VideoTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public List<VideoTemplate> GetVideoData(int storyid)
        {
            List<VideoTemplate> result = new List<VideoTemplate>();
            foreach (KeyValuePair<int, VideoTemplate> pair in idKeyDic)
            {
                if (pair.Value.videoId == storyid)
                {
                    result.Add(pair.Value);
                }
            }

            return result;
        }
    }
}
