using System;
using Mono.Data.Sqlite;

namespace app.db
{
    public class CraftEquipCostItem
    {
        /** 材料组Id */
	    //@BeanFieldNumber(number = 1)
	    public int groupId;
	    /** 数量 */
	    //@BeanFieldNumber(number = 2)
	    public int num;

        public CraftEquipCostItem(SqliteDataReader reader, int startIndex)
        {
            this.groupId = reader.GetInt32(startIndex++);
            this.num = reader.GetInt32(startIndex++);
        }
    }
}
