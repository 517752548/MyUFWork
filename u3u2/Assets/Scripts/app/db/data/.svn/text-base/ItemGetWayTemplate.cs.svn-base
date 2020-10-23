using System;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class ItemGetWayTemplate
    {
        //途径图标
	    //@BeanFieldNumber(number = 1)
        public String icon;
	    //途径文字
	    //@BeanFieldNumber(number = 2)
        public String desc;
	    //途径寻路
	    //@BeanFieldNumber(number = 3)
        public String path;

        public ItemGetWayTemplate(SqliteDataReader reader, int startIndex)
        {
            this.icon = reader.GetString(startIndex++);
            this.desc = reader.GetString(startIndex++);
            this.path = reader.GetString(startIndex++);
        }
    }
}
