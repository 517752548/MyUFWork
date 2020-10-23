using app.fuben;
using UnityEngine;
using app.zone;
using app.net;
using System.Collections.Generic;
using app.db;
using app.npc;
using UnityEngine.UI;
using app.xinfa;
using app.tips;
using app.human;
using app.pet;

namespace app.worldmap
{
    public class WorldMapView : BaseWnd
    {
        //[Inject(ui = "WorldMapUI")]
        //public GameObject ui;
        //总UI
        public WorldMapUI UI;
        private int m_mapid = -1;
        private List<NpcTemplate> m_npclist = new List<NpcTemplate>();
        private List<LifeSkillMapTemplate> m_reslist = new List<LifeSkillMapTemplate>();

        private RTimer m_HideTimer;

        public WorldMapView()
        {
            uiName = "WorldMapUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<WorldMapUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(Close);
            int len = UI.btns.Count;
            for (int i = 0; i < len; i++)
            {
                EventTriggerListener.Get(UI.btns[i]).onClick = OnBtnClick;
            }

            UI.m_NPCDropdown.onValueChanged.AddListener(ClickDropdown);
            UI.m_RESDropdown.onValueChanged.AddListener(ResClickDropdown);

            Pet mainRole = Human.Instance.PetModel.getLeader();
            PathUtil.Ins.SetHeadIcon(UI.m_touimage, mainRole.getTpl().modelId);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            app.main.GameClient.ins.OnBigWndShown();
            ShowMapNPC();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
        }

        private void Close()
        {
            if (null == m_HideTimer)
            {
                m_HideTimer = TimerManager.Ins.createTimer(100, 200, null, timerEnd);
                m_HideTimer.start();
            }
            else
            {
                m_HideTimer.Reset(100, 200);
                m_HideTimer.Restart();
            }
            
        }

        private void timerEnd(RTimer r)
        {
            hide();
        }

        private void OnBtnClick(GameObject target)
        {
            string str = target.name;
            string[] strArr = str.Split(new char[] { '_' });
            if (strArr.Length > 1)
            {
                int mapId = int.Parse(strArr[strArr.Length - 1]);
                MapTips.ins.ShowTips(mapId,OkChuanSong);
            }
        }

        private void OkChuanSong(int mapId)
        {
            if (mapId != ZoneModel.ins.mapTpl.Id)
            {
                MapCGHandler.sendCGMapPlayerEnter(mapId);
                //停止自动寻路
                AutoMaticManager.Ins.StopAutoMatic();
                Close();
            }
            
        }

        /// <summary>
        /// 大地图显示NPC列表
        /// </summary>
        private void ShowMapNPC()
        {
            ///地图没有变化///
            if (m_mapid == ZoneModel.ins.mapTpl.Id)
            {
                if (m_npclist.Count > 0)
                {
                    ///默认选择第一个///
                    UI.m_NPCDropdown.value = 0;
                }
                if (m_reslist.Count > 0)
                {
                    UI.m_RESDropdown.value = 0;
                }
                return;
            }

            m_mapid = ZoneModel.ins.mapTpl.Id;

            if (m_mapid > UI.btns.Count)
            {
                UI.m_touxiang.gameObject.SetActive(false);
            }
            else
            {
                UI.m_touxiang.gameObject.SetActive(true);
                UI.m_touxiang.SetParent(UI.btns[m_mapid - 1].transform);
                UI.m_touxiang.localPosition = new Vector3(UI.btnrects[m_mapid - 1].sizeDelta.x / 2 - 80, UI.btnrects[m_mapid - 1].sizeDelta.y / 2 - 20, 0);
            }
            m_npclist.Clear();
            if ((int)MapType.NORMAL == ZoneModel.ins.mapTpl.mapTypeId)
            {
                UI.m_NPCDropdown.gameObject.SetActive(true);
                Dictionary<int, MapNpcTemplate> mapNpcs = MapNpcTemplateDB.Instance.GetMapNpcDicByMapId(ZoneModel.ins.mapTpl.Id);
                if (mapNpcs != null)
                {
                    foreach (KeyValuePair<int, MapNpcTemplate> pair in mapNpcs)
                    {
                        NpcTemplate npctpl = NpcTemplateDB.Instance.getTemplate(pair.Value.npcId);
                        if ((int)NPCType.NORMAL == npctpl.type)
                        {
                            m_npclist.Add(npctpl);
                        }
                    }
                    if (m_npclist.Count > 0)
                    {
                        UpdateNPCList();
                        UI.m_NPCDropdown.value = 0;
                    }
                    else
                    {
                        UI.m_NPCDropdown.gameObject.SetActive(false);
                    }
                }
                else
                {
                    UI.m_NPCDropdown.gameObject.SetActive(false);
                }
            }
            else
            {
                UI.m_NPCDropdown.gameObject.SetActive(false);
            }

            m_reslist.Clear();
            Dictionary<int, LifeSkillMapTemplate> mapRes = LifeSkillMapTemplateDB.Instance.GetMapResDicByMapId(ZoneModel.ins.mapTpl.Id);
            if (mapRes != null)
            {
                foreach (KeyValuePair<int, LifeSkillMapTemplate> pair in mapRes)
                {
                    if (1 == pair.Value.showFlag)
                    {
                        m_reslist.Add(pair.Value);
                    }
                }
                if (m_reslist.Count > 0)
                {
                    UI.m_RESDropdown.gameObject.SetActive(true);
                    UpdateResList();
                    UI.m_RESDropdown.value = 0;
                }
                else
                {
                    UI.m_RESDropdown.gameObject.SetActive(false);
                }
            }
            else
            {
                UI.m_RESDropdown.gameObject.SetActive(false);
            }

            if (UI.m_NPCDropdown.gameObject.activeSelf)
            {
                UI.m_res_rect.localPosition = new Vector3(UI.m_res_rect.localPosition.x,230,0);
                UI.m_res_show_rect.sizeDelta = new Vector2(0, 515);
            }
            else
            {
                UI.m_res_rect.localPosition = new Vector3(UI.m_res_rect.localPosition.x,275,0);
                UI.m_res_show_rect.sizeDelta = new Vector2(0,550);
            }
            
            
        }

        /// <summary>
        /// 更新NPC列表
        /// </summary>
        private void UpdateNPCList()
        {
            UI.m_NPCDropdown.options.Clear();

            ///第一个一直显示请选择NPC///
            Dropdown.OptionData nullData = new Dropdown.OptionData();
            nullData.text = LangConstant.XUANZE_NPC;
            UI.m_NPCDropdown.options.Add(nullData);
            for (int i = 0; i < m_npclist.Count; ++i)
            {
                Dropdown.OptionData optionData = new Dropdown.OptionData();
                optionData.text = m_npclist[i].name;
                UI.m_NPCDropdown.options.Add(optionData);
            }
        }

        /// <summary>
        /// 更新资源列表
        /// </summary>
        private void UpdateResList()
        {
            UI.m_RESDropdown.options.Clear();

            ///第一个一直显示请选择NPC///
            Dropdown.OptionData nullData = new Dropdown.OptionData();
            nullData.text = LangConstant.XUANZE_RES;
            UI.m_RESDropdown.options.Add(nullData);
            for (int i = 0; i < m_reslist.Count; ++i)
            {
                Dropdown.OptionData optionData = new Dropdown.OptionData();
                optionData.text = m_reslist[i].resourceName;
                UI.m_RESDropdown.options.Add(optionData);
            }
        }

        /// <summary>
        /// 选择NPC
        /// </summary>
        /// <param name="index"></param>
        private void ClickDropdown(int index)
        {
            ///第一个不做处理///
            if (0 == index)
            {
                return;
            }
            //ZoneNPCManager.Ins.gotoNpc(m_mapid, m_npclist[index-1].Id,null,true);
            LinkParse.Ins.doLink(LinkTypeDef.FindNPC + "-" + m_mapid + "-" + m_npclist[index - 1].Id);
            Close();
        }

        /// <summary>
        /// 选择资源点
        /// </summary>
        /// <param name="index"></param>
        private void ResClickDropdown(int index)
        {
            ///第一个不做处理///
            if (0 == index)
            {
                return;
            }
            //ZoneNPCManager.Ins.gotoNpc(m_mapid, m_reslist[index - 1].resourceId,null,true);
            LinkParse.Ins.doLink(LinkTypeDef.FindNPC + "-" + m_mapid + "-" + m_reslist[index - 1].resourceId);
            XinFaModel.instance.AutoNpcid = m_reslist[index - 1].resourceId;
            AutoMaticManager.Ins.CurAutoMaticType = AutoMaticManager.AutoMaticType.AutoFindResPoint;
            Close();
        }

        public override void Destroy()
        {
            base.Destroy();
            if (null != m_HideTimer)
            {
                m_HideTimer.stop();
                m_HideTimer = null;
            }
        }
    }
}

