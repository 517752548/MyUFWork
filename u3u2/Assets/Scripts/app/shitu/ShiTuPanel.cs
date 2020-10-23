using System.Collections.Generic;
using app.db;
using app.human;
using app.net;
using app.pet;
using UnityEngine;

namespace app.shitu
{
    public class ShiTuPanel:BaseWnd
    {
        //[Inject(ui = "ShiTuPanelUI")]
        //public GameObject ui;

        public ShiTuPanelUI UI;

        /// <summary>
        /// 服务器数据对象
        /// </summary>
        public ShiTuModel shituModel;
        
        private List<ShiTuChengJiuItemUI> itemList = new List<ShiTuChengJiuItemUI>();
        private List<OvermanTemplate> rewardList;

        //我的徒弟 的信息,如果有数据，说明我是师傅，否则我是徒弟
        private LowermanInfo tudiInfo;
        private int tudiLevel = 0;
        private OvermanRewardInfo[] rewardStatusList = new OvermanRewardInfo[0];
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(uilayer);
        }
        */
        
        public ShiTuPanel()
        {
            uiName = "ShiTuPanelUI";
        }
        
        public override void initWnd()
        {
            base.initWnd();
            
            shituModel = ShiTuModel.Ins;
            shituModel.addChangeEvent(ShiTuModel.UPDATE_REWARD_INFO, UpdateRewardInfo);
            
            UI = ui.AddComponent<ShiTuPanelUI>();
            UI.Init();
            
            UI.closeBtn.SetClickCallBack(closewnd);
            UI.defaultItem.gameObject.SetActive(false);
        }

        private void closewnd()
        {
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UpdateRewardInfo(e);
            app.main.GameClient.ins.OnBigWndShown();
        }
        
        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
        }

        /// <summary>
        /// 获得奖励的状态
        /// </summary>
        /// <param name="tplId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private int getRewardStatus(int tplId,OvermanRewardInfo[] list)
        {
            for (int i=0;i<list.Length;i++)
            {
                if (list[i].index==tplId)
                {
                    return list[i].hadget;
                }
            }
            return -1;
        }

        private void clickLingQu(GameObject go)
        {
            for (int i=0;i<itemList.Count;i++)
            {
                if (itemList[i].lingqu.gameObject==go)
                {
                    if (tudiInfo != null)
                    {
                        OvermanCGHandler.sendCGAddOvermanReward(rewardList[i].Id, tudiInfo.uuid);
                    }
                    else
                    {
                        OvermanCGHandler.sendCGAddLowermanReward(rewardList[i].Id);
                    }
                    break;
                }
            }
        }

        public void UpdateRewardInfo(RMetaEvent e)
        {
            if (!(e != null && e.data != null))
            {
                return;
            }
            tudiInfo = null;
            tudiLevel = 0;
            rewardStatusList = new OvermanRewardInfo[0];
            GCGetOvermanReward overmanReward = e.data as GCGetOvermanReward;
            if (overmanReward != null)
            {
                //我是师傅，在这个徒弟身上的奖励状态
                tudiInfo = shituModel.GetTuDiInfoByUUID(overmanReward.getLowermanCharId());
                //徒弟头像
                //PathUtil.Ins.SetPetIconSource(UI.tudiIcon, tudiInfo.templateId);
                PathUtil.Ins.SetHeadIcon(UI.tudiIcon, tudiInfo.templateId);
                //徒弟名字
                UI.tudiName.text = tudiInfo.humanName;
                //徒弟等级
                UI.tudiLevel.text = "Lv." + tudiInfo.level;
                //职业 性别
                PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(tudiInfo.templateId);
                if (petTpl != null)
                {
                    UI.tudiJob.text = PetJobType.GetJobLimitDesc(petTpl.jobId, petTpl.sexId);
                }
                //战斗力
                UI.tudiFightPower.text = tudiInfo.fightPower.ToString();

                tudiLevel = tudiInfo.level;
                rewardStatusList = overmanReward.getRewardInfo();
            }
            GCGetLowermanReward lowermanReward = e.data as GCGetLowermanReward;
            if (lowermanReward != null)
            {
                //我是徒弟，我的奖励状态

                //徒弟头像
                //PathUtil.Ins.SetPetIconSource(UI.tudiIcon, Human.Instance.PetModel.getLeader().getTplId());
                PathUtil.Ins.SetHeadIcon(UI.tudiIcon, Human.Instance.PetModel.getLeader().getTplId());
                //徒弟名字
                UI.tudiName.text = Human.Instance.getName();
                //徒弟等级
                UI.tudiLevel.text = "Lv." + Human.Instance.PetModel.getLeader().getLevel();
                //职业 性别
                PetTemplate petTpl = Human.Instance.PetModel.getLeader().getTpl();
                if (petTpl != null)
                {
                    UI.tudiJob.text = PetJobType.GetJobLimitDesc(petTpl.jobId, petTpl.sexId);
                }
                //战斗力
                UI.tudiFightPower.text = Human.Instance.PetModel.getLeader().getFightPower().ToString();

                tudiLevel = Human.Instance.PetModel.getLeader().getLevel();
                rewardStatusList = lowermanReward.getRewardInfo();
            }

            int i = 0;
            Dictionary<int, OvermanTemplate> dic = OvermanTemplateDB.Instance.getIdKeyDic();
            rewardList = new List<OvermanTemplate>();
            foreach (KeyValuePair<int, OvermanTemplate> pair in dic)
            {
                if (i >= itemList.Count)
                {
                    ShiTuChengJiuItemUI ui = GameObject.Instantiate(UI.defaultItem);
                    itemList.Add(ui);
                    ui.transform.SetParent(UI.listgrid.transform);
                    ui.transform.SetAsLastSibling();
                    ui.transform.localScale = Vector3.one;
                    ui.lingqu.SetClickCallBack(clickLingQu);
                }
                rewardList.Add(pair.Value);

                itemList[i].gameObject.SetActive(true);
                if (tudiLevel >= pair.Value.level)
                {
                    //等级达到
                    itemList[i].desc.text = pair.Value.desc;
                    itemList[i].dengjiyaoqiu.gameObject.SetActive(false);
                    itemList[i].yitongguo.gameObject.SetActive(true);

                    int status = getRewardStatus(pair.Value.Id, rewardStatusList);
                    if (status == -1)
                    {
                        itemList[i].yilingqu.gameObject.SetActive(false);
                        itemList[i].lingqu.gameObject.SetActive(false);
                    }
                    else if (status == 1)
                    {
                        itemList[i].yilingqu.gameObject.SetActive(true);
                        itemList[i].lingqu.gameObject.SetActive(false);
                    }
                    else if (status == 0)
                    {
                        itemList[i].yilingqu.gameObject.SetActive(false);
                        itemList[i].lingqu.gameObject.SetActive(true);
                    }
                }
                else
                {
                    //没达到要求的等级
                    itemList[i].desc.text = pair.Value.desc;
                    itemList[i].dengjiyaoqiu.gameObject.SetActive(true);
                    itemList[i].dengjiyaoqiu.text = tudiLevel + "/" + pair.Value.level;

                    itemList[i].yitongguo.gameObject.SetActive(false);
                    itemList[i].yilingqu.gameObject.SetActive(false);
                    itemList[i].lingqu.gameObject.SetActive(false);
                }
                i++;
            }
            for (; i < itemList.Count; i++)
            {
                itemList[i].gameObject.SetActive(false);
            }
        }
        
        public override void Destroy()
        {
            shituModel.removeChangeEvent(ShiTuModel.UPDATE_REWARD_INFO, UpdateRewardInfo);
            base.Destroy();
            UI = null;
        }
    }
}
