using UnityEngine;
using app.utils;

namespace app.db
{
    public class MissionTemplate : MissionTemplateVO
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 队伍出生点对应的Vector3对象
        /// </summary>
        private Vector3? bornPosV3;

        /// <summary>
        /// 获取队伍出生点对应的Vector3对象
        /// </summary>
        /// <returns></returns>
        public Vector3 GetBornPosV3()
        {
            if (this.bornPosV3 == null)
            {
                this.bornPosV3 = PropertyUtil.StringToVector3(this.bornPos);
            }
            return this.bornPosV3.GetValueOrDefault();
        }

        public bool isBossMission()
        {
            return isBoss == 1;
        }
    }
}
