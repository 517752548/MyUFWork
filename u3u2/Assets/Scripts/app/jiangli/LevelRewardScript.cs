using System.Collections;
using System.Collections.Generic;
using app.net;
using UnityEngine;


namespace app.jiangli
{
    class LevelRewardScript
    {
        private List<GoodActivityRewardInfos> rewardInfos;

        private List<LevelRewardItemScript> rewardItemScsripts = new List<LevelRewardItemScript>();

        private LevelRewardUI rewardUI;

        private Coroutine mSetDataCoroutine = null;
        
        private bool isFirstSetData = false;

        public LevelRewardScript(LevelRewardUI rewardUI)
        {
            this.rewardUI = rewardUI;
            isFirstSetData = true;
        }

        public void HandlLevelRewardInfo(GoodActivityInfo goodActivityInfo)
        {
            rewardInfos = GoodActivityRewardInfos.GetRewardItems(goodActivityInfo);
            /*
            if (!isInit)
            {
                isInit = true;
                CreateCompnents();
            }
            SetData();
            */
            if (mSetDataCoroutine != null)
            {
                rewardUI.StopCoroutine(mSetDataCoroutine);
                mSetDataCoroutine = null;
            }
            if (rewardUI.isActiveAndEnabled)
            {
                mSetDataCoroutine = rewardUI.StartCoroutine(SetData());
            }
            else
            {
                SetData();
            }
        }

        public void showLevelRewardGuide()
        {
            if (rewardItemScsripts != null && rewardItemScsripts.Count > 0 && rewardItemScsripts[0].itemUI != null)
            {
                if (GuideManager.Ins.CurrentGuideId == GuideIdDef.LevelReward)
                {
                    if (rewardItemScsripts[0].itemUI.buttonReceive.gameObject.activeInHierarchy)
                    {
                        rewardUI.grid.transform.localPosition = Vector3.zero;
                        GuideManager.Ins.ShowGuide(GuideIdDef.LevelReward, 3, rewardItemScsripts[0].itemUI.buttonReceive.gameObject);
                    }
                    else
                    {
                        GuideManager.Ins.RemoveGuide(GuideIdDef.LevelReward);
                    }
                }

            }
        }

        private IEnumerator SetData()
        {
            int rewardCount = rewardInfos.Count;

            for (int i = 0; i < rewardCount; i++)
            {
                if (i >= rewardItemScsripts.Count)
                {
                    if (i == 0)
                    {
                        LevelRewardItemScript itemScript = new LevelRewardItemScript(rewardUI.itemUI);
                        rewardItemScsripts.Add(itemScript);
                    }
                    else
                    {
                        GameObject obj = GameObject.Instantiate(rewardUI.itemUI.gameObject);
                        LevelRewardItemUI ui = obj.GetComponent<LevelRewardItemUI>();
                        obj.transform.SetParent(rewardUI.grid.transform);
                        obj.transform.localScale = Vector3.one;
                        rewardItemScsripts.Add(new LevelRewardItemScript(ui));
                    }
                }
                rewardItemScsripts[i].SetData(rewardInfos[i]);
                yield return 0;
            }
            mSetDataCoroutine = null;
            
            if (isFirstSetData)
            {
                showLevelRewardGuide();
                isFirstSetData = false;
            }
        }

        public void Destroy()
        {
            if (rewardUI != null) GameObject.DestroyImmediate(rewardUI.gameObject, true);
            rewardUI = null;
        }
    }
}
