using System;
using System.Collections;
using System.Collections.Generic;
using app.net;
using minijson;

namespace app.jiangli
{
    public class GoodActivityRewardInfos
    {
        public const string REWARD_TARGETID_KEY = "1";
        public const string REWARD_KEY = "2";

        /// <summary>
        /// 目标1描述
        /// </summary>
        public const string DESC_KEY = "3";
        /// <summary>
        /// 目标2描述
        /// </summary>
        public const string SECOND_DESC_KEY = "4";

        public const string CAN_GIVE_KEY = "7";
        public const string HAS_GIVE_KEY = "8";
        
        /** 不能领奖时是否显示按钮 */
        public const string SHOW_BTN_KEY = "9";
        /** 目标1分子 */
        public const string CURR_NUM_KEY = "10";
        /** 目标2分子 */
        public const string CURR_NUM_SECOND_KEY = "11";
        /** 目标1分母 */
        public const string NEED_NUM_KEY = "12";
        /** 目标2分母 */
        public const string NEED_NUM_SECOND_KEY = "13";
        /** 分组Id */
        public const string TARGET_GROUP_KEY = "14";
        /** 目标面板类型 */
        public const string PANEL_LINK_TYPE_KEY = "15";
        /// <summary>
        /// 奖励信息
        /// </summary>
        public IDictionary rewardData;
        /// <summary>
        /// 奖励id，领取奖励时使用
        /// </summary>
        public int targetId;

        public string desc;
        public string secondDesc;
        public bool canGiveKey;
        public bool hasGiveKey;
        public long activityId;

        public int currNum;
        public int currNumSecond;
        public int needNum;
        public int needNumSecond;
        public int targetGroup;
        public int panelLinkType;


        public static List<GoodActivityRewardInfos> GetRewardItems(GoodActivityInfo activityInfo)
        {
            List<GoodActivityRewardInfos> rewardInfos = new List<GoodActivityRewardInfos>();
            if (activityInfo != null && activityInfo.targetInfo != null)
            {
                IList list = (IList)Json.Deserialize(activityInfo.targetInfo);

                for (int i = 0; i < list.Count; i++)
                {
                    GoodActivityRewardInfos rewardInfo = new GoodActivityRewardInfos();
                    object targetDes = list[i];
                    IDictionary dic = (IDictionary)targetDes;
                    if (dic[REWARD_KEY] is IDictionary)
                    {
                        object reward = dic[REWARD_KEY];
                        rewardInfo.rewardData = (IDictionary) reward;
                    }
                    rewardInfo.desc = (string)dic[DESC_KEY];

                    if (dic.Contains(SECOND_DESC_KEY))
                    {
                        rewardInfo.secondDesc = (string)dic[SECOND_DESC_KEY];
                    }

                    rewardInfo.hasGiveKey = (long)dic[HAS_GIVE_KEY] == 1;
                    rewardInfo.canGiveKey = (long)dic[CAN_GIVE_KEY] == 1;

                    rewardInfo.activityId = activityInfo.activityId;
                    rewardInfo.currNum = (int)(long)dic[CURR_NUM_KEY];
                    rewardInfo.currNumSecond = (int)(long)dic[CURR_NUM_SECOND_KEY];
                    rewardInfo.needNum = (int)(long)dic[NEED_NUM_KEY];
                    rewardInfo.needNumSecond = (int)(long)dic[NEED_NUM_SECOND_KEY];
                    rewardInfo.targetGroup = (int)(long)dic[TARGET_GROUP_KEY];
                    rewardInfo.panelLinkType = int.Parse((string)dic[PANEL_LINK_TYPE_KEY]);

                    rewardInfo.targetId = Convert.ToInt32(dic[REWARD_TARGETID_KEY]);

                    rewardInfos.Add(rewardInfo);
                }
            }

            return rewardInfos;
        }

    }
}
