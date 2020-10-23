using System.Collections.Generic;
using System.Linq;
using app.reward;
using UnityEngine;

namespace app.jingjichang
{
    public class JingJiChangRewardView:BaseWnd
    {
        //[Inject(ui = "JingJiChangRewardUI")]
        //public GameObject ui;

        public JingJiChangRewardUI UI;

        public JingJiChangModel jingjichangModel;

        private List<JingJiChangRewardItemUI> zhanbaoList;
        private List<RewardItem> myrewardList;
        private List<List<RewardItem>> rewardList=new List<List<RewardItem>>();
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.PopWND);
        }
        */
        
        public JingJiChangRewardView()
        {
            uiName = "JingJiChangRewardUI";
        }
        
        public override void initWnd()
        {
            base.initWnd();
            jingjichangModel = JingJiChangModel.Ins;
            UI = ui.AddComponent<JingJiChangRewardUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickClose);
            myrewardList = new List<RewardItem>();
            for (int i=0;i<UI.myRewardItem.rewardList.Length;i++)
            {
                myrewardList.Add(new RewardItem(UI.myRewardItem.rewardList[i]));
            }
            UI.defaultItem.gameObject.SetActive(false);
        }

        private void clickClose()
        {
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);

            UpdatePanel();
        }

        private void UpdatePanel(RMetaEvent e=null)
        {
            UI.curPaiming.text = jingjichangModel.PanelInfo.getRank().ToString();
            UI.peimingduan.text = "保持当前排名(" + GetPaiMingRangeByPaiMing(jingjichangModel.PanelInfo.getRank(),
                jingjichangModel.RewardInfo.getRank().ToList())+ ")可领取奖励为";
            int mypaimingIndex = GetPaiMingRewardIndexByPaiMing(jingjichangModel.PanelInfo.getRank(),
                jingjichangModel.RewardInfo.getRank().ToList());
            string rewardstr = jingjichangModel.RewardInfo.getRewardInfoList()[mypaimingIndex];
            RewardData rewarddata = new RewardData();
            rewarddata.Parse(rewardstr, myrewardList);

            updateRewardList();
        }

        public void updateRewardList()
        {
            if (zhanbaoList == null)
            {
                zhanbaoList = new List<JingJiChangRewardItemUI>();
            }
            int zhanbaoLen = jingjichangModel.RewardInfo.getRank().Length;
            for (int i = 0; i < zhanbaoLen; i++)
            {
                if (i >= zhanbaoList.Count)
                {
                    JingJiChangRewardItemUI item = GameObject.Instantiate(UI.defaultItem);
                    item.name = "rewardItem_" + i;
                    item.gameObject.transform.SetParent(UI.rewardGrid.transform);
                    item.transform.localScale = Vector3.one;
                    zhanbaoList.Add(item);
                }
                zhanbaoList[i].gameObject.SetActive(true);
                if (i>=rewardList.Count)
                {
                    List<RewardItem> tmprewardList = new List<RewardItem>();
                    for (int j=0;j<zhanbaoList[i].rewardList.Length;j++)
                    {
                        tmprewardList.Add(new RewardItem(zhanbaoList[i].rewardList[j]));
                    }
                    rewardList.Add(tmprewardList);
                }
                string arenaData = jingjichangModel.RewardInfo.getRewardInfoList()[i];

                zhanbaoList[i].paimingText.text = GetPaiMingRangeByIndex(i,jingjichangModel.RewardInfo.getRank().ToList());
                RewardData rewarddata = new RewardData();
                rewarddata.Parse(arenaData,rewardList[i]);
            }
            //删除多余
            for (int i = zhanbaoLen; i < zhanbaoList.Count; i++)
            {
                GameObject.DestroyImmediate(zhanbaoList[i].gameObject, true);
                zhanbaoList[i] = null;
            }
            zhanbaoList.RemoveRange(zhanbaoLen, zhanbaoList.Count - zhanbaoLen);
        }
        /// <summary>
        /// 获得排名段 描述
        /// </summary>
        /// <param name="paiming"></param>
        /// <param name="paimingList"></param>
        /// <returns></returns>
        public string GetPaiMingRangeByPaiMing(int paiming,List<int>paimingList)
        {
            string str = "";
            bool hasPaiming = false;
            for (int i = 0; paimingList!=null&&i < paimingList.Count; i++)
            {
                if (paimingList[i]==paiming)
                {
                    hasPaiming = true;
                    break;
                }
            }
            if (hasPaiming)
            {
                str = "第" + paiming + "名";
                return str;
            }
            for (int i = 0; paimingList != null && i < paimingList.Count; i++)
            {
                if (paiming>=paimingList[i]&&((i != paimingList.Count - 1) && paiming < paimingList[i + 1]))
                {
                    str = "第" + paimingList[i] + "至" + (paimingList[i + 1]-1) + "名";
                    return str;
                }
                if (paiming>=paimingList[i]&&(i == paimingList.Count - 1))
                {
                    str = "第" + paimingList[i] + "名及以后";
                    return str;
                }
            }
            str = "第" + paiming + "名";
            return str;
        }

        /// <summary>
        /// 获得排名段 描述
        /// </summary>
        /// <param name="paiming"></param>
        /// <param name="paimingList"></param>
        /// <returns></returns>
        public string GetPaiMingRangeByIndex(int paimingIndex, List<int> paimingList)
        {
            string str = "";
            bool isOnlyPaiMing = false;
            if (paimingIndex==paimingList.Count-1)
            {
                return GetPaiMingRangeByPaiMing(paimingList[paimingIndex]+1,paimingList);
            }
            if (paimingList[paimingIndex+1]==paimingList[paimingIndex]+1)
            {
                isOnlyPaiMing = true;
                return GetPaiMingRangeByPaiMing(paimingList[paimingIndex],paimingList);
            }
            return GetPaiMingRangeByPaiMing((int)(paimingList[paimingIndex+1]+paimingList[paimingIndex])/2,paimingList);
        }

        /// <summary>
        /// 获得排名索引 
        /// </summary>
        /// <param name="paiming"></param>
        /// <param name="paimingList"></param>
        /// <returns></returns>
        public int GetPaiMingRewardIndexByPaiMing(int paiming, List<int> paimingList)
        {
            for (int i = 0; paimingList != null && i < paimingList.Count; i++)
            {
                if (paimingList[i] == paiming)
                {
                    return i;
                }
            }
            for (int i = 0; paimingList != null && i < paimingList.Count; i++)
            {
                if (paiming >= paimingList[i] && ((i != paimingList.Count - 1) && paiming < paimingList[i + 1]))
                {
                    //str = "第" + paimingList[i] + "名至第" + (paimingList[i + 1] - 1) + "名";
                    return i;
                }
                if (paiming >= paimingList[i] && (i == paimingList.Count - 1))
                {
                    //str = "第" + paimingList[i] + "名以后";
                    return i;
                }
            }
            //str = "第" + paiming + "名";
            return paimingList.Count - 1;
        }
    }
}
