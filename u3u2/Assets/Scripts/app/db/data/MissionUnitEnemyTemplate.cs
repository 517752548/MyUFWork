using app.utils;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class MissionUnitEnemyTemplate
    {
        /** 敌人Id */
        //@BeanFieldNumber(number = 1)
        public int enemyId;
        /** 敌人是否会主动攻击 */
        //@BeanFieldNumber(number = 2)
        public int isInitiatives;

        public MissionUnitEnemyTemplate(SqliteDataReader reader, int startIndex)
        {
            this.enemyId = reader.GetInt32(startIndex++);
            this.isInitiatives = reader.GetInt32(startIndex++);
        }
    }
}
