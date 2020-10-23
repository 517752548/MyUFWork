using System.Collections.Generic;
using app.db;
using app.model;
using app.net;
using app.zone;
using app.relation;
using UnityEngine;
using app.utils;

/// <summary>
/// 矿点
/// </summary>
public class KuangDianScript
{
    private CaiKuangDianUI UI;
    public RelationModel relationModel;
    public ShengChanModel shengchanModel;

    private List<CaiKuangFriendItem> friendUIList;

    /// <summary>
    /// 当前矿点的信息
    /// </summary>
    private MinePitInfo kuangDianInfo;

    /// <summary>
    /// 倒计时 计时器
    /// </summary>
    private RTimer timer;

    private int selectedLeiBieId;
    private int selectedTimeId;
    private long selectedKuangGongId;

    private List<KuangGong> kuanggongList = new List<KuangGong>();

    public KuangDianScript(CaiKuangDianUI ui)
    {
        UI = ui;
        relationModel = RelationModel.Ins;
        shengchanModel = ShengChanModel.Ins;
        initWnd();
    }

    private void initWnd()
    {
        UI.leibieDropDownMenu.SelectDefault = false;
        UI.shijianDropDownMenu.SelectDefault = false;
        UpdateList();
        UI.leibieDropDownMenu.TabChangeHandler = selectLeiBie;
        UI.leibieDropDownMenu.mainToggle.AddValueChangedCallBack(clickLeibieToggle);
        UI.shijianDropDownMenu.TabChangeHandler = selectShiJian;
        UI.shijianDropDownMenu.mainToggle.AddValueChangedCallBack(clickShijianToggle);

        UI.xuanzekuanggongToggle.isOn = false;
        UI.xuanzekuanggongToggle.SetValueChangedCallBack(showKuangGong);

        UI.defaultKuanggongItem.gameObject.SetActive(false);

        UI.kuanggongTBG.TabChangeHandler = selectKuangGong;

        UI.kaishiCaiKuangBtn.SetClickCallBack(clickCaiKuang);
        UI.shouquBtn.SetClickCallBack(clickShouqu);
    }

    private void clickLeibieToggle(bool value)
    {
        if (value)
        {
            UI.shijianDropDownMenu.OnScreenTouchUp();
            UI.xuanzekuanggongToggle.isOn = false;
        }
    }

    private void clickShijianToggle(bool value)
    {
        if (value)
        {
            UI.leibieDropDownMenu.OnScreenTouchUp();
            UI.xuanzekuanggongToggle.isOn = false;
        }
    }

    private void clickCaiKuang()
    {
        if (selectedLeiBieId == 0)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请先选择要挖的矿石！");
            return;
        }
        if (selectedTimeId == 0)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请先选择挖矿时间！");
            return;
        }
        if (selectedKuangGongId == 0)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请先选择矿工！");
            return;
        }
        showKuangGong(false);
        shengchanModel.SaveKuangDianData(kuangDianInfo.id, selectedLeiBieId, selectedTimeId, selectedKuangGongId);
        //LifeskillCGHandler.sendCGLsMineStart(kuangDianInfo.id, selectedLeiBieId, selectedTimeId, selectedKuangGongId);
    }

    private void clickShouqu()
    {
        //LifeskillCGHandler.sendCGLsMineGain(kuangDianInfo.id);
    }

    private string getCacheData(int kuangdianid, string playerdatakey)
    {
        string datastr = null;
        PlayerData pd = shengchanModel.GetSavedKuangDianData(kuangdianid);
        if (pd != null)
        {
            datastr = pd.getData(playerdatakey);
            if (!string.IsNullOrEmpty(datastr))
            {
                return datastr;
            }
        }
        return datastr;
    }

    public void setKuangDianData(MinePitInfo kuangDianInfov)
    {
        kuangDianInfo = kuangDianInfov;
        UI.shijianDropDownMenu.dropDownTBG.setHasAwake();
        UI.leibieDropDownMenu.dropDownTBG.setHasAwake();
        UI.kuanggongTBG.setHasAwake();
        UpdateList();
        if (kuangDianInfo.endTime == 0)
        {
            //空闲的矿
            UI.huoliGo.SetActive(true);
            UI.daojishiGo.SetActive(false);
            UI.kaishiCaiKuangBtn.gameObject.SetActive(true);
            UI.shouquBtn.gameObject.SetActive(false);
            UI.leibieToggle.interactable = true;
            UI.shijianToggle.interactable = true;
            UI.xuanzekuanggongToggle.interactable = true;
            //矿工缓存
            string kuanggongCache = getCacheData(kuangDianInfo.id, PlayerDataKeyDef.KUANGDIAN_DATA_KUANGGONG);
            if (!string.IsNullOrEmpty(kuanggongCache))
            {
                List<LifeSkillMineMinerTemplate> AIList = shengchanModel.GetAIList();
                int AILen = AIList.Count;
                for (int i = 0; i < AILen; i++)
                {
                    if (AIList[i].Id.ToString() == kuanggongCache)
                    {
                        UI.kuanggongNameText.text = AIList[i].name;
                        UI.kuanggongIcon.gameObject.SetActive(true);
                        //PathUtil.Ins.SetPetIconSource(UI.kuanggongIcon, AIList[i].minerModelId);
                        PathUtil.Ins.SetHeadIcon(UI.kuanggongIcon, AIList[i].minerModelId);
                        selectedKuangGongId = AIList[i].Id;
                        setKuangGong(selectedKuangGongId.ToString());
                        break;
                    }
                }
            }
            else
            {
                UI.kuanggongIcon.gameObject.SetActive(false);
                UI.kuanggongNameText.text = "选择矿工";
            }
            //类别缓存
            string leibiestr = getCacheData(kuangDianInfo.id, PlayerDataKeyDef.KUANGDIAN_DATA_LEIBIE);
            if (!string.IsNullOrEmpty(leibiestr))
            {
                List<LifeSkillMineTemplate> myKuangs = shengchanModel.GetMyKuang();
                for (int i = 0; i < myKuangs.Count; i++)
                {
                    if (myKuangs[i].Id == int.Parse(leibiestr))
                    {
                        LifeSkillMineTemplate mineTpl = LifeSkillMineTemplateDB.Instance.getTemplate(int.Parse(leibiestr));
                        ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(mineTpl.mineItemId);
                        UI.leibieNameText.text = itemTpl.name;
                        selectedLeiBieId = mineTpl.Id;
                        setLeibie(selectedLeiBieId);
                        break;
                    }
                }
            }
            else
            {
                UI.leibieNameText.text = "选择矿";
            }
            //时间缓存
            string timestr = getCacheData(kuangDianInfo.id, PlayerDataKeyDef.KUANGDIAN_DATA_TIME);
            if (!string.IsNullOrEmpty(timestr))
            {
                selectedTimeId = int.Parse(timestr);

                List<LifeSkillMineCostTemplate> timeList = shengchanModel.GetTimeList();
                for (int i = 0; i < timeList.Count; i++)
                {
                    if (timeList[i].Id == selectedTimeId)
                    {
                        UI.shijianNameText.text = timeList[i].costTime + "小时";
                        setTime(selectedTimeId);
                        break;
                    }
                }
            }
            else
            {
                UI.shijianNameText.text = "开采时间";
            }
        }
        else if (kuangDianInfo.endTime <= shengchanModel.CurrentKuangs.getServerTime())
        {
            //已经结束，可以领取
            LifeSkillMineTemplate mineTpl = LifeSkillMineTemplateDB.Instance.getTemplate(kuangDianInfo.mineTypeId);
            ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(mineTpl.mineItemId);
            UI.leibieNameText.text = itemTpl.name;
            LifeSkillMineCostTemplate time = LifeSkillMineCostTemplateDB.Instance.getTemplate(kuangDianInfo.miningTypeId);
            UI.shijianNameText.text = time.costTime + "小时";
            UI.kuanggongNameText.text = kuangDianInfo.minerName;
            UI.kuanggongIcon.gameObject.SetActive(true);
            //PathUtil.Ins.SetPetIconSource(UI.kuanggongIcon, kuangDianInfo.minerTplId);
            PathUtil.Ins.SetHeadIcon(UI.kuanggongIcon, kuangDianInfo.minerTplId);
            UI.huoliGo.SetActive(false);
            UI.daojishiGo.SetActive(true);
            UI.daojishiText.text = "挖矿结束";
            UI.daojishiLabel.text = "可收取";
            UI.kaishiCaiKuangBtn.gameObject.SetActive(false);
            UI.shouquBtn.gameObject.SetActive(true);
            UI.leibieToggle.interactable = false;
            UI.shijianToggle.interactable = false;
            UI.xuanzekuanggongToggle.interactable = false;
            //PathUtil.Ins.SetRawImageSource(UI.kuanggongIcon, kuangDianInfo.minerTplId, PathUtil.TEXTUER_HEAD);
        }
        else
        {
            //还没结束，正在进行
            LifeSkillMineTemplate mineTpl = LifeSkillMineTemplateDB.Instance.getTemplate(kuangDianInfo.mineTypeId);
            ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(mineTpl.mineItemId);
            UI.leibieNameText.text = itemTpl.name;
            LifeSkillMineCostTemplate time = LifeSkillMineCostTemplateDB.Instance.getTemplate(kuangDianInfo.miningTypeId);
            UI.shijianNameText.text = time.costTime + "小时";
            UI.kuanggongNameText.text = kuangDianInfo.minerName;
            UI.kuanggongIcon.gameObject.SetActive(true);
            //PathUtil.Ins.SetPetIconSource(UI.kuanggongIcon, kuangDianInfo.minerTplId);
            PathUtil.Ins.SetHeadIcon(UI.kuanggongIcon, kuangDianInfo.minerTplId);
            UI.huoliGo.SetActive(false);
            UI.daojishiGo.SetActive(true);
            UI.daojishiLabel.text = "后可收取";
            int totalMSecond = (int)(kuangDianInfo.endTime - shengchanModel.CurrentKuangs.getServerTime());
            UI.daojishiText.text = TimeString.getTimeFormat(totalMSecond / 1000);
            if (timer != null)
            {
                timer.stop();
            }
            timer = TimerManager.Ins.createTimer(1000, totalMSecond, onTimer =>
            {
                UI.daojishiText.text = TimeString.getTimeFormat(timer.getLeftTime() / 1000);
            }, TimerEnd =>
            {
                timer.stop();
                //倒计时结束，请求界面
                //LifeskillCGHandler.sendCGLsMineGetPannel();
            });
            timer.start();
            UI.kaishiCaiKuangBtn.gameObject.SetActive(false);
            UI.shouquBtn.gameObject.SetActive(false);
            UI.leibieToggle.interactable = false;
            UI.shijianToggle.interactable = false;
            UI.xuanzekuanggongToggle.interactable = false;
            //PathUtil.Ins.SetRawImageSource(UI.kuanggongIcon, kuangDianInfo.minerTplId, PathUtil.TEXTUER_HEAD);
        }
    }

    /// <summary>
    /// 设置类别
    /// </summary>
    private void setLeibie(int leibieId)
    {
        List<LifeSkillMineTemplate> myKuangs = shengchanModel.GetMyKuang();
        for (int i = 0; i < myKuangs.Count; i++)
        {
            if (myKuangs[i].Id == leibieId)
            {
                UI.leibieDropDownMenu.setIndex(i);
                break;
            }
        }
    }

    /// <summary>
    /// 设置时间
    /// </summary>
    private void setTime(int timeid)
    {
        List<LifeSkillMineCostTemplate> timeList = shengchanModel.GetTimeList();
        for (int i = 0; i < timeList.Count; i++)
        {
            if (timeList[i].Id == timeid)
            {
                UI.shijianDropDownMenu.setIndex(i);
                break;
            }
        }
    }

    private void setKuangGong(string kuanggonguuid)
    {
        updateKuangGongList();
        for (int i = 0; i < kuanggongList.Count; i++)
        {
            if (kuanggongList[i].uuid.ToString() == kuanggonguuid)
            {
                UI.kuanggongTBG.SetIndexWithCallBack(i);
                break;
            }
        }
    }

    private void UpdateList()
    {
        //选择矿 列表
        List<string> leibieList = new List<string>();
        List<LifeSkillMineTemplate> myKuangs = shengchanModel.GetMyKuang();
        for (int i = 0; i < myKuangs.Count; i++)
        {
            int itemTplId = myKuangs[i].mineItemId;
            ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(itemTplId);
            if (itemTpl != null)
            {
                leibieList.Add(itemTpl.name);
            }
            else
            {
                ClientLog.LogError("矿点 配置的 物品不存在！itemTplId：" + itemTplId);
            }
        }
        UI.leibieDropDownMenu.updateDropDownList(leibieList);
        //选择时间 列表
        List<string> shijianList = new List<string>();
        List<LifeSkillMineCostTemplate> timeList = shengchanModel.GetTimeList();
        for (int i = 0; i < timeList.Count; i++)
        {
            shijianList.Add(timeList[i].costTime + "小时");
        }
        UI.shijianDropDownMenu.updateDropDownList(shijianList);
    }

    private void selectLeiBie(int tab)
    {
        List<LifeSkillMineTemplate> myKuangs = shengchanModel.GetMyKuang();
        if (tab < myKuangs.Count)
        {
            selectedLeiBieId = myKuangs[tab].Id;
        }
        else
        {
            ClientLog.LogError("选择的矿 索引错误！能开采的矿数：" + myKuangs.Count + " ，当前选中索引 ：" + tab);
        }
    }

    private void selectShiJian(int tab)
    {
        List<LifeSkillMineCostTemplate> timeList = shengchanModel.GetTimeList();
        if (tab < timeList.Count)
        {
            selectedTimeId = timeList[tab].Id;
           
            //UI.huolinameText.text = "需要"+"                "+CurrencyTypeDef.GetCurrencyName(timeList[tab].currencyType);
            UI.huolinameText.text = string.Format("需要{0}{1}", ColorUtil.getColorText(ColorUtil.GREEN_ID, timeList[tab].currencyNum.ToString()), CurrencyTypeDef.GetCurrencyName(timeList[tab].currencyType));
        }
        else
        {
            ClientLog.LogError("选择的采矿时间 索引错误！时间列表长度：" + timeList.Count + " ，当前选中索引 ：" + tab);
        }
    }

    private void selectKuangGong(int tab)
    {
        if (tab < kuanggongList.Count)
        {
            UI.kuanggongNameText.text = kuanggongList[tab].Name;
            UI.kuanggongIcon.gameObject.SetActive(true);
            //PathUtil.Ins.SetPetIconSource(UI.kuanggongIcon, kuanggongList[tab].petTplId);
            PathUtil.Ins.SetHeadIcon(UI.kuanggongIcon, kuanggongList[tab].petTplId);
            selectedKuangGongId = kuanggongList[tab].uuid;
        }
        UI.kuanggongListGo.gameObject.SetActive(false);
        UI.xuanzekuanggongToggle.isOn = false;
    }

    private void showKuangGong(bool state)
    {
        UI.leibieToggle.isOn = false;
        UI.shijianToggle.isOn = false;

        if (!state)
        {
            UI.kuanggongListGo.gameObject.SetActive(false);
            return;
        }
        
        UI.leibieDropDownMenu.OnScreenTouchUp();
        UI.shijianDropDownMenu.OnScreenTouchUp();

        UI.kuanggongListGo.gameObject.SetActive(true);
        if (selectedKuangGongId!=0)
        {
            //setKuangGong(selectedKuangGongId.ToString());
        }
        else
        {
            updateKuangGongList();
        }
    }

    private void updateKuangGongList()
    {
        if (friendUIList == null)
        {
            friendUIList = new List<CaiKuangFriendItem>();
        }
        //选择矿工 列表
        UI.kuanggongTBG.ClearToggleList();
        List<LifeSkillMineMinerTemplate> AIList = shengchanModel.GetAIList();
        int AILen = AIList.Count;
        //AI
        int AIIndex = 0;
        for (int i = 0; i < AILen; i++)
        {
            if (shengchanModel.IsKuangGongUsed(AIList[i].Id))
            {
                continue;
            }
            if (AIIndex >= friendUIList.Count)
            {
                CaiKuangFriendItem newui = GameObject.Instantiate(UI.defaultKuanggongItem);
                friendUIList.Add(newui);
                newui.gameObject.SetActive(true);
                newui.transform.SetParent(UI.kuanggongGrid.transform);
                newui.transform.localScale = Vector3.one;
            }
            PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(AIList[i].minerModelId);
            if (petTpl != null)
            {
                UI.kuanggongTBG.AddToggle(friendUIList[AIIndex].toggle);
                friendUIList[AIIndex].headIcon.gameObject.SetActive(true);
                //PathUtil.Ins.SetRawImageSource(friendUIList[AIIndex].headIcon, petTpl.modelId, PathUtil.TEXTUER_HEAD);
                PathUtil.Ins.SetHeadIcon(friendUIList[AIIndex].headIcon, petTpl.modelId);
                friendUIList[AIIndex].nameText.text = AIList[i].name;
                friendUIList[AIIndex].levelText.text = "";
                if (AIIndex >= kuanggongList.Count)
                {
                    KuangGong kuanggong = new KuangGong();
                    kuanggongList.Add(kuanggong);
                }
                kuanggongList[AIIndex].Name = AIList[i].name;
                kuanggongList[AIIndex].uuid = AIList[i].Id;
                kuanggongList[AIIndex].petTplId = AIList[i].minerModelId;
                AIIndex++;
            }
        }
        AILen = AIIndex;
        //好友
        int friendLen = relationModel.HaoyouList.Count;
        int friendIndex = 0;
        for (int i = 0; i < friendLen; i++)
        {
            if (shengchanModel.IsKuangGongUsed(relationModel.HaoyouList[i].uuid))
            {
                continue;
            }
            int finalIndex = friendIndex + AILen;
            if (finalIndex >= friendUIList.Count)
            {
                CaiKuangFriendItem newui = GameObject.Instantiate(UI.defaultKuanggongItem);
                friendUIList.Add(newui);
                newui.gameObject.SetActive(true);
                newui.transform.SetParent(UI.kuanggongGrid.transform);
                newui.transform.localScale = Vector3.one;
            }
            UI.kuanggongTBG.AddToggle(friendUIList[finalIndex].toggle);
            friendUIList[finalIndex].headIcon.gameObject.SetActive(true);
            //PathUtil.Ins.SetPetIconSource(friendUIList[finalIndex].headIcon, relationModel.HaoyouList[i].pic);
            PathUtil.Ins.SetHeadIcon(friendUIList[finalIndex].headIcon, relationModel.HaoyouList[i].pic);
            friendUIList[finalIndex].nameText.text = relationModel.HaoyouList[i].name;
            friendUIList[finalIndex].levelText.text = relationModel.HaoyouList[i].level.ToString();

            if (finalIndex >= kuanggongList.Count)
            {
                KuangGong kuanggong = new KuangGong();
                kuanggongList.Add(kuanggong);
            }
            kuanggongList[finalIndex].Name = relationModel.HaoyouList[i].name;
            kuanggongList[finalIndex].uuid = relationModel.HaoyouList[i].uuid;
            kuanggongList[finalIndex].petTplId = relationModel.HaoyouList[i].pic;
            friendIndex++;
        }
        //删除多余的
        int totalNum = AILen + friendIndex;
        for (int i = totalNum; i < friendUIList.Count; i++)
        {
            friendUIList[i].gameObject.SetActive(false);
            GameObject.DestroyImmediate(friendUIList[i].gameObject, true);
            friendUIList[i] = null;
        }
        friendUIList.RemoveRange(totalNum, friendUIList.Count - totalNum);
        kuanggongList.RemoveRange(totalNum, friendUIList.Count - totalNum);
    }

    public void hide()
    {
        stopTimer();
        showKuangGong(false);
    }
    public void stopTimer()
    {
        if (timer != null)
        {
            timer.stop();
        }
        timer = null;
    }
    
    public void Destroy()
    {
        stopTimer();
        GameObject.DestroyImmediate(UI.gameObject, true);
        UI = null;
    }

    private class KuangGong
    {
        public long uuid;
        public string Name;
        //public int level;
        public int petTplId;
    }

}

