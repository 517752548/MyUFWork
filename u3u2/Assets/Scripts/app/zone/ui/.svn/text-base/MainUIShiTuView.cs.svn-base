using System;
using System.Collections.Generic;
using app.human;
using app.net;
using UnityEngine;
using app.utils;

namespace app.zone
{
    public class MainUIShiTuView
    {
        public ShiTuUI UI;

        public ShiTuModel shituModel;

        public List<GameObject> tudiHeadList;

        public MainUIShiTuView(ShiTuUI ui)
        {
            UI = ui;
            shituModel = ShiTuModel.Ins;
            shituModel.addChangeEvent(ShiTuModel.UPDATE_SHITU_INFO, UpdateShiTuInfo);
            shituModel.addChangeEvent(ShiTuModel.UPDATE_HONGDIAN_INFO, UpdateShiTuInfo);
            tudiHeadList = new List<GameObject>();
            for (int i = 0; i < UI.tudiList.Count; i++)
            {
                tudiHeadList.Add(UI.tudiList[i].headBtn.gameObject);
            }
        }

        public void UpdateShiTuInfo(RMetaEvent e = null)
        {
            if (shituModel.MyShiTuInfo.getOverman() != 0)
            {
                UI.gameObject.SetActive(true);
                //有师傅，我就是徒弟
                UI.shifuGo.SetActive(true);
                UI.tudiGo.SetActive(false);
                //师傅头像
                //PathUtil.Ins.SetPetIconSource(UI.shifuUI.headIcon,shituModel.MyShiTuInfo.getOvermanTemplateId());
                PathUtil.Ins.SetHeadIcon(UI.shifuUI.headIcon, shituModel.MyShiTuInfo.getOvermanTemplateId());
                //奖励 红点
                UI.shifuUI.headBtn.redDotVisible = shituModel.HasHongDian(Human.Instance.Id);
                //师傅按钮响应
                UI.shifuUI.headBtn.SetClickCallBack(clickShifuHead);

                if (shituModel.MyShiTuInfo.isOvermanOnline)
                {
                    ColorUtil.DeGray(UI.shifuUI.headIcon);
                }
                else
                {
                    ColorUtil.Gray(UI.shifuUI.headIcon);
                }
               
            }
            else if (shituModel.MyShiTuInfo.getLowerList() != null && shituModel.MyShiTuInfo.getLowerList().Length > 0)
            {
                UI.gameObject.SetActive(true);
                //有徒弟，我就是师傅
                UI.shifuGo.SetActive(false);
                UI.tudiGo.SetActive(true);
                if (shituModel.MyShiTuInfo.getLowerList().Length == 1)
                {
                    //只有一个徒弟
                    UI.tudiDefaultUI.gameObject.SetActive(true);
                    UI.tudiMultiGo.SetActive(false);

                    //徒弟头像
                    //PathUtil.Ins.SetPetIconSource(UI.tudiDefaultUI.headIcon,shituModel.MyShiTuInfo.getLowerList()[0].templateId);
                    PathUtil.Ins.SetHeadIcon(UI.tudiDefaultUI.headIcon, shituModel.MyShiTuInfo.getLowerList()[0].templateId);
                    //奖励 红点
                    UI.tudiDefaultUI.headBtn.redDotVisible = shituModel.HasHongDian(shituModel.MyShiTuInfo.getLowerList()[0].uuid);
                    //徒弟按钮响应
                    UI.tudiDefaultUI.headBtn.SetClickCallBack(clickTudiHead);
                    if (shituModel.MyShiTuInfo.getLowerList()[0].isOnline)
                    {
                        ColorUtil.DeGray(UI.tudiDefaultUI .headIcon);
                    }
                    else
                    {
                        ColorUtil.Gray(UI.tudiDefaultUI.headIcon);
                    }
                }
                else
                {
                    //有多个徒弟
                    UI.tudiDefaultUI.gameObject.SetActive(false);
                    UI.tudiMultiGo.SetActive(true);

                    UI.tudiListBtn.SetClickCallBack(clickTudiListBtn);
                    bool hashongdian = false;
                    for (int i = 0; i < shituModel.MyShiTuInfo.getLowerList().Length&&i<UI.tudiList.Count; i++)
                    {
                        UI.tudiList[i].gameObject.SetActive(true);
                        //徒弟头像
                        //PathUtil.Ins.SetPetIconSource(UI.tudiList[i].headIcon,shituModel.MyShiTuInfo.getLowerList()[i].templateId);
                        PathUtil.Ins.SetHeadIcon(UI.tudiList[i].headIcon, shituModel.MyShiTuInfo.getLowerList()[i].templateId);
                        //奖励 红点
                        bool hongdianvis = shituModel.HasHongDian(shituModel.MyShiTuInfo.getLowerList()[i].uuid);
                        UI.tudiList[i].headBtn.redDotVisible = hongdianvis;
                        if (hongdianvis)
                        {
                            hashongdian = true;
                        }
                        //徒弟按钮响应
                        UI.tudiList[i].headBtn.SetClickCallBack(clickTudiHead);

                        if (shituModel.MyShiTuInfo.getLowerList()[i].isOnline)
                        {
                            ColorUtil.DeGray(UI.tudiList[i].headIcon);
                        }
                        else
                        {
                            ColorUtil.Gray(UI.tudiList[i].headIcon);
                        }
                    }
                    UI.tudiListBtn.redDotVisible = hashongdian;
                    for (int i = shituModel.MyShiTuInfo.getLowerList().Length; i < UI.tudiList.Count; i++)
                    {
                        UI.tudiList[i].gameObject.SetActive(false);
                    }
                    showList = true;
                }
            }
            else
            {
                //没有徒弟也没有师傅
                UI.gameObject.SetActive(false);
            }

        }

        private bool showList = false;
        private void clickTudiListBtn()
        {
            ClientLog.LogWarning("clickTudiListBtn：" + showList + "   " + DateTime.Now.ToString());
            showList = !showList;
            UI.tudiListGo.SetActive(showList);
        }

        private void clickShifuHead(GameObject go)
        {
            OvermanCGHandler.sendCGGetLowermanReward();
        }

        private void clickTudiHead(GameObject go)
        {
            if (UI.tudiDefaultUI.headBtn.gameObject == go)
            {
                //就一个徒弟
                OvermanCGHandler.sendCGGetOvermanReward(shituModel.MyShiTuInfo.getLowerList()[0].uuid);
            }
            else
            {
                int index = tudiHeadList.IndexOf(go);
                if (index != -1)
                {
                    OvermanCGHandler.sendCGGetOvermanReward(shituModel.MyShiTuInfo.getLowerList()[index].uuid);
                }
            }
        }

        public void Destroy()
        {
            shituModel.removeChangeEvent(ShiTuModel.UPDATE_SHITU_INFO, UpdateShiTuInfo);
            shituModel.removeChangeEvent(ShiTuModel.UPDATE_HONGDIAN_INFO, UpdateShiTuInfo);
            if (UI != null)
            {
                GameObject.DestroyImmediate(UI.gameObject, true);
                UI = null;
            }
        }
    }
}