using app.utils;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class MissionUnitTemplate
    {
        /** 敌人组Id */
	    //@BeanFieldNumber(number = 1)
	    public int enemyGroupId;
	    /** 敌人组位置 */
	    //@BeanFieldNumber(number = 2)
        public String enemyGroupPos;
        /** 敌人组出场顺序 */
        //@BeanFieldNumber(number = 3)
        public int enemyGroupBornIndex;
        /** 敌人组出场延迟（秒） */
        //@BeanFieldNumber(number = 4)
        public float enemyGroupBornDelay;
        /// <summary>
        /// 敌人组位置对应的Vector3对象
        /// </summary>
        private Vector3? enemyGroupPosV3;

        public MissionUnitTemplate(SqliteDataReader reader, int startIndex)
        {
            this.enemyGroupId = reader.GetInt32(startIndex++);
            this.enemyGroupPos = reader.GetString(startIndex++);
            this.enemyGroupBornIndex = reader.GetInt32(startIndex++);
            this.enemyGroupBornDelay = reader.GetFloat(startIndex++);
        }

        /// <summary>
        /// 获取队伍出生点对应的Vector3对象
        /// </summary>
        /// <returns></returns>
        public Vector3 GetEnemyGroupPosV3()
        {
            if (this.enemyGroupPosV3 == null)
            {
                this.enemyGroupPosV3 = PropertyUtil.StringToVector3(enemyGroupPos);
            }
            return this.enemyGroupPosV3.GetValueOrDefault();
        }
    }
}
