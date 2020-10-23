using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using app.db;
using UnityEngine.UI;
using app.zone;

namespace app.tips
{
    public class MapTips : BaseTips
    {
        public MapTipsUI UI;
        private int m_mapid;
        protected UnityAction<int> m_clickItemHandler;

        private List<CommonItemUI> m_CommonitemUIs = new List<CommonItemUI>();

        private static MapTips mIns;

        public MapTips()
        {
            uiName = "MapTips";
        }

        public static MapTips ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = Singleton.GetObj(typeof(MapTips)) as MapTips;
                }
                return mIns;
            }
        }

        public void ShowTips(int mapid, UnityAction<int> clickItemHandler = null)
        {
            m_mapid = mapid;
            m_clickItemHandler = clickItemHandler;
            preLoadUI();
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<MapTipsUI>();
            UI.Init();
            UI.m_chuansongBtn.SetClickCallBack(chuansongclick);

        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            setData();
        }

        private void setData()
        {
            if (UI != null)
            {
                ///拿到地图遇怪方案，根据遇怪方案拿到所有怪物组，根据怪物组拿到怪物id(不能有重复怪)，(怪物id不同，但是怪物所用模型相同，则选择id小的怪物)
                MapTemplate mapdata = MapTemplateDB.Instance.getTemplate(m_mapid);
                List<EnemyTemplate> mapenemys = new List<EnemyTemplate>();
                if (null != mapdata)
                {
                    UI.m_map_name.text = mapdata.name;
                    UI.m_map_level.text = mapdata.openLevel + LangConstant.JI;
                    UI.m_map_desc.text = mapdata.desc;

                    List<int> enemyids = new List<int>();
                    List<MapMeetMonsterTemplate> mapmeetdata = MapMeetMonsterTemplateDB.Instance.GetTemplatesByPlanId(mapdata.meetMonsterPlanId);
                    for (int i = 0; i < mapmeetdata.Count; ++i)
                    {
                        EnemyArmyTemplate temp = EnemyArmyTemplateDB.Instance.getTemplate(mapmeetdata[i].enemyArmyId);
                        for (int j = 0; j < temp.enemyIdAndProbList.Count; ++j)
                        {
                            if (0 != temp.enemyIdAndProbList[j].enemyId && !enemyids.Contains(temp.enemyIdAndProbList[j].enemyId))
                            {
                                enemyids.Add(temp.enemyIdAndProbList[j].enemyId);
                            }
                        }
                    }
                    for (int i = 0; i < enemyids.Count; ++i)
                    {
                        EnemyTemplate etemp = EnemyTemplateDB.Instance.getTemplate(enemyids[i]);
                        if (null != etemp)
                        {
                            bool isexited = false;
                            int index = -1;
                            for (int j = 0; j < mapenemys.Count; ++j)
                            {
                                if (mapenemys[j].modelId == etemp.modelId)
                                {
                                    isexited = true;
                                    index = j;
                                    break;
                                }
                            }

                            if (isexited)
                            {
                                if (mapenemys[index].Id > etemp.Id)
                                {
                                    mapenemys[index] = etemp;
                                }
                            }
                            else
                            {
                                mapenemys.Add(etemp);
                            }
                            
                        }
                    }
                    for (int i = 0; i < mapenemys.Count; i++)
                    {
                        if (i >= m_CommonitemUIs.Count)
                        {
                            CommonItemUI go = GameObject.Instantiate(UI.m_defaultitem);
                            go.gameObject.SetActive(true);
                            go.ScrollRect = UI.m_defaultitem.transform.parent.parent.GetComponent<ScrollRect>();
                            go.transform.SetParent(UI.m_defaultitem.transform.parent);
                            go.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                            m_CommonitemUIs.Add(go);
                        }
                        m_CommonitemUIs[i].gameObject.SetActive(true);
                        m_CommonitemUIs[i].Name.text = mapenemys[i].name;
                        PathUtil.Ins.SetHeadIcon(m_CommonitemUIs[i].icon, mapenemys[i].modelId);
                            
                    }

                }

                if (0 == mapenemys.Count)
                {
                    UI.m_bg.sizeDelta = new Vector2(UI.m_bg.sizeDelta.x,185);
                }
                else if (mapenemys.Count<6)
                {
                    UI.m_bg.sizeDelta = new Vector2(UI.m_bg.sizeDelta.x, 275);
                }
                else
                {
                    UI.m_bg.sizeDelta = new Vector2(UI.m_bg.sizeDelta.x, 360);
                }

                ///隐藏剩下的///
                for (int i = mapenemys.Count; i < m_CommonitemUIs.Count; i++)
                {
                    m_CommonitemUIs[i].gameObject.SetActive(false);

                }

                if (m_mapid == ZoneModel.ins.mapTpl.Id)
                {
                    UI.m_chuansongBtn.gameObject.SetActive(false);
                }
                else
                {
                    UI.m_chuansongBtn.gameObject.SetActive(true);
                }
            }
        }

        private void chuansongclick(GameObject obj)
        {
            if (null != m_clickItemHandler)
            {
                m_clickItemHandler(m_mapid);
            }

            hide();
        }
    }
}
