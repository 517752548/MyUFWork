using System.Collections;
using System.Collections.Generic;
using app.model;
using app.net;
using app.utils;
using UnityEngine;

namespace app.qiandao
{
    class QiandaoScript
    {
        public QianDaoUI UI;

        public List<QianDaoItemScript> itemList = new List<QianDaoItemScript>();

        private int mToday;

        private int[] marr = { 2, 7, 12, 17, 22, 27 };

        public QianDaoModel qiandaoModel;
        
        private Coroutine mUpdateQianDaoListCoroutine = null;

        public QiandaoScript(QianDaoUI qiandaoUI,WndType UILayer)
        {
            UI = qiandaoUI;
            UI.buqian.SetClickCallBack(clickBuqian);
            UI.itemsMask.Init(UGUIConfig.GetCanvasByWndType(UILayer), null, UGUIConfig.UISpaceWidth,
                UGUIConfig.UISpaceHeight);
                
            qiandaoModel = QianDaoModel.Ins;
            qiandaoModel.addChangeEvent(QianDaoModel.UPDATE_MEIRI_QIANDAO, updateQianDaoList);
        }
        private void clickBuqian()
        {
            OnlinegiftCGHandler.sendCGDaliyGiftRetroactive();
        }

        public void updateQianDaoList(RMetaEvent e = null)
        {
            if (mUpdateQianDaoListCoroutine != null)
            {
                UI.StopCoroutine(mUpdateQianDaoListCoroutine);
                mUpdateQianDaoListCoroutine = null;
            }
            if (UI.isActiveAndEnabled)
            {
                mUpdateQianDaoListCoroutine = UI.StartCoroutine(UpdateQianDaoListCoroutine());
            }
            else
            {
                UpdateQianDaoListCoroutine();
            }
        }
        
        private IEnumerator UpdateQianDaoListCoroutine()
        {
            //累计天数
            UI.leijiTianshu.text = "本月累计签到" + qiandaoModel.QiandaoInfo.getSignedNum() + "天";
            //补签次数
            UI.buqiancishu.text = "本月剩余补签次数" + qiandaoModel.QiandaoInfo.getRestRetroactiveNum() + "次";
            //是否可以补签
            UI.buqian.gameObject.SetActive(qiandaoModel.QiandaoInfo.getCanUseRetroacte() == 1);
            
            UI.defaultQianDaoItem.gameObject.SetActive(false);
            int hasQianDaoLen = qiandaoModel.QiandaoInfo.getSignedNum();
            int currentDay = (qiandaoModel.QiandaoInfo.getIsAlreadySign() == 1) ? (hasQianDaoLen) : (hasQianDaoLen + 1);

            for (int i = 0; i < currentDay; i++)
            {
                //已经签到的天
                if (i >= itemList.Count)
                {
                    QianDaoItemUI itemui = GameObject.Instantiate(UI.defaultQianDaoItem);
                    itemui.gameObject.SetActive(true);
                    itemui.transform.SetParent(UI.itemGrid.transform);
                    itemui.transform.localScale = Vector3.one;
                    QianDaoItemScript itemscript = new QianDaoItemScript(itemui);

                    checkDay(itemui.tianshu.transform.parent.gameObject, i);

                    itemList.Add(itemscript);
                }
                itemList[i].setData(i + 1, qiandaoModel.getDayReward(i));
                if (i == currentDay - 1)
                {
                    //今天
                    mToday = i;
                    if ((qiandaoModel.QiandaoInfo.getIsAlreadySign() == 1))
                    {
                        //今天 已签
                        itemList[i].Yijingqiandao();
                        itemList[i].UI.duihao.gameObject.SetActive(true);
                        if (itemList[i].UI.item.glowEffect != null)
                        {
                            itemList[i].UI.item.glowEffect.SetActive(false);
                            GameObject.DestroyImmediate(itemList[i].UI.item.glowEffect, true);
                            itemList[i].UI.item.glowEffect = null;
                        }
                    }
                    else
                    {
                        //今天 未签
                        itemList[i].AddListener();
                        itemList[i].UI.duihao.gameObject.SetActive(false);
                        if (itemList[i].UI.item.glowEffect == null)
                        {
                            GameObject glowEffect = SourceManager.Ins.createObjectFromAssetBundle(PathUtil.Ins.GetEffectPath("common_xuanzhong02"));
                            glowEffect.transform.SetParent(itemList[i].UI.item.transform);
                            glowEffect.transform.localScale = new Vector3(100, 100, 100);
                            glowEffect.transform.localPosition = new Vector3(0, 0, -10);
                            GameObjectUtil.SetLayer(glowEffect, itemList[i].UI.item.gameObject.layer);
                            glowEffect.SetActive(true);
                            itemList[i].UI.item.glowEffect = glowEffect;
                            UI.itemsMask.AddParticle(glowEffect.transform);
                        }
                        else
                        {
                            itemList[i].UI.item.glowEffect.SetActive(true);
                        }
                    }
                }
                else
                {
                    itemList[i].Yijingqiandao();
                    itemList[i].UI.duihao.gameObject.SetActive(true);
                    if (itemList[i].UI.item.glowEffect != null)
                    {
                        itemList[i].UI.item.glowEffect.SetActive(false);
                        GameObject.DestroyImmediate(itemList[i].UI.item.glowEffect, true);
                        itemList[i].UI.item.glowEffect = null;
                    }
                }
                
                if (i % 5 == 0)
                {
                    yield return 0;
                }
            }
            //今天以后的天
            for (int i = currentDay; i < qiandaoModel.QiandaoInfo.getDaysOfMonth(); i++)
            {
                if (i >= itemList.Count)
                {
                    QianDaoItemUI itemui = GameObject.Instantiate(UI.defaultQianDaoItem);
                    itemui.gameObject.SetActive(true);
                    itemui.transform.SetParent(UI.itemGrid.transform);
                    itemui.transform.localScale = Vector3.one;
                    QianDaoItemScript itemscript = new QianDaoItemScript(itemui);

                    checkDay(itemui.tianshu.transform.parent.gameObject, i);

                    itemList.Add(itemscript);
                }
                itemList[i].RemoveListener();
                itemList[i].setData(i + 1, qiandaoModel.getDayReward(i));
                itemList[i].UI.duihao.gameObject.SetActive(false);
                if (itemList[i].UI.item.glowEffect != null)
                {
                    GameObject.DestroyImmediate(itemList[i].UI.item.glowEffect, true);
                    itemList[i].UI.item.glowEffect = null;
                }
                
                if (i % 5 == 0)
                {
                    yield return 0;
                }
            }
            for (int i = qiandaoModel.QiandaoInfo.getDaysOfMonth(); i < itemList.Count; i++)
            {
                itemList[i].UI.gameObject.SetActive(false);
                if (itemList[i].UI.item.glowEffect != null)
                {
                    GameObject.DestroyImmediate(itemList[i].UI.item.glowEffect, true);
                    itemList[i].UI.item.glowEffect = null;
                }
            }
            
            updateScoll();
            showGuide();
            
            mUpdateQianDaoListCoroutine = null;
        }

        private void showGuide()
        {
            GuideManager.Ins.ShowGuide(GuideIdDef.QianDao, 2, itemList[mToday].UI.gameObject);
        }

        /// <summary>
        /// 更新scollview的位置到今天
        /// </summary>
        private void updateScoll()
        {
            if (mToday > 20)
            {
                UI.itemGrid.transform.localPosition = new Vector3(0, 169, 0);
            }
            else
            {
                UI.itemGrid.transform.localPosition = Vector3.zero;
            }
        }

        private void checkDay(GameObject obj, int i)
        {
            bool b = false;
            for (int j = 0; j < marr.Length; j++)
            {
                if (i == marr[j] - 1)
                {
                    b = true;
                    obj.SetActive(true);
                    break;
                }

            }
            if (!b)
            {
                obj.SetActive(false);
            }
        }
        
        public void HideGlowEffects()
        {
            int len = itemList.Count;
            for (int i = 0; i < len; i++)
            {
                if (itemList[i].UI.item.glowEffect != null)
                {
                    itemList[i].UI.item.glowEffect.SetActive(false);
                }
            }
        }

        public void ShowGlowEffects()
        {
            int len = itemList.Count;
            for (int i = 0; i < len; i++)
            {
                if (itemList[i].UI.item.glowEffect != null)
                {
                    itemList[i].UI.item.glowEffect.SetActive(true);
                }
            }
        }
        
        public void Destroy()
        {
            qiandaoModel.removeChangeEvent(QianDaoModel.UPDATE_MEIRI_QIANDAO, updateQianDaoList);
            
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }

    }
}
