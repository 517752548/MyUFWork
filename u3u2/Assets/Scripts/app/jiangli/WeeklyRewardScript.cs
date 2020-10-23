using System.Collections;
using System.Collections.Generic;
using app.net;
using UnityEngine;

namespace app.jiangli
{
    class WeeklyRewardScript
    {
        private WeeklyRewardUI weeklyUI;

        private List<WeeklyRewardItemScript> mItemScripts;

        private List<GoodActivityRewardInfos> rewardInfos; 

        private Coroutine mSetDataCoroutine = null;

        public WeeklyRewardScript(WeeklyRewardUI weeklyUI)
        {
            this.weeklyUI = weeklyUI;
            mItemScripts = new List<WeeklyRewardItemScript>();
        }

        public void UpdateWeeklyReward(GoodActivityInfo activityInfo)
        {
            rewardInfos = GoodActivityRewardInfos.GetRewardItems(activityInfo);
            if (mSetDataCoroutine != null)
            {
                weeklyUI.StopCoroutine(mSetDataCoroutine);
                mSetDataCoroutine = null;
            }
            mSetDataCoroutine = weeklyUI.StartCoroutine(SetData());
        }

        private IEnumerator SetData()
        {
            int rewardCount = rewardInfos.Count;
            
            weeklyUI.itemUI.gameObject.SetActive(rewardCount > 0);
            bool firstDayHasReceive = false;
            bool secondDayHasReceive = false;

            for (int i = 0; i < rewardCount; i++)
            {
                if (i >= mItemScripts.Count)
                {
                    if (i == 0)
                    {
                        WeeklyRewardItemScript itemScript = new WeeklyRewardItemScript(0,weeklyUI.itemUI);
                        mItemScripts.Add(itemScript);
                    }
                    else
                    {
                        GameObject obj = GameObject.Instantiate(weeklyUI.itemUI.gameObject);
                        WeeklyRewardItemUI ui = obj.GetComponent<WeeklyRewardItemUI>();
                        obj.transform.SetParent(weeklyUI.grid.transform);
                        obj.transform.localScale = Vector3.one;
                        mItemScripts.Add(new WeeklyRewardItemScript(i,ui));
                    }
                }
                mItemScripts[i].SetData(i,rewardInfos[i]);
                if (i==0&&rewardInfos[i].hasGiveKey)
                {
                    firstDayHasReceive = true;
                }
                if (i == 1 && rewardInfos[i].hasGiveKey)
                {
                    secondDayHasReceive = true;
                }
                yield return 0;
            }
            if (firstDayHasReceive)
            {
                if (secondDayHasReceive)
                {
                    weeklyUI.grid.transform.localPosition = new Vector3(0, 130, 0);
                }
                else
                {
                    weeklyUI.grid.transform.localPosition = new Vector3(0, 90, 0);   
                }
            }
            mSetDataCoroutine = null;
        }
        
        public void Destroy()
        {
            GameObject.DestroyImmediate(weeklyUI.gameObject, true);
            weeklyUI = null;
        }

    }
}
