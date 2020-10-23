using System;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class npcGetLoopStrTemplate
    {
        //NPC循环播放文字1
	    //@BeanFieldNumber(number = 1)
        public String content1;
        //@BeanFieldNumber(number = 2)
        public String content2;

        public npcGetLoopStrTemplate(SqliteDataReader reader, int startIndex)
        {
            this.content1 = reader.GetString(startIndex++);
            this.content2 = reader.GetString(startIndex++);
        }
    }
}
