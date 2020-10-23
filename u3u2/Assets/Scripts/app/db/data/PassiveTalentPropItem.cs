using System;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class PassiveTalentPropItem
    {
       /** 属性key */
	//@BeanFieldNumber(number = 1)
	public int propKey;
	/** 属性初始值 */
	//@BeanFieldNumber(number = 2)
	public int propValue;
	/** 属性每级增加属性 */
	//@BeanFieldNumber(number = 3)
	public int propLevelAdd;


    public PassiveTalentPropItem(SqliteDataReader reader, int startIndex)
        {
            this.propKey = reader.GetInt32(startIndex++);
            this.propValue = reader.GetInt32(startIndex++);
            this.propLevelAdd = reader.GetInt32(startIndex++);
        }
    }
}
