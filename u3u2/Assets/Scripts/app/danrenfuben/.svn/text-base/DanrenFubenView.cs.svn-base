using UnityEngine;
using System.Collections;
using app.main;
using System.Collections.Generic;
using app.db;
using app.net;

namespace app.danrenfuben
{
    public enum DungeonType
    {
        NORMAL = 0,
        HARDER = 1
    }

    public class DanrenFubenView : BaseWnd
    {
        public const int LEVELS_PER_LEVEL = 5;
        private const int ITEMS_LAST_INDEX = LEVELS_PER_LEVEL - 1;
        private static Vector3 sLargeScale = new Vector3(1.05f, 1.05f, 1);
        List<PlotDungeonTemplate> normalTpls = new List<PlotDungeonTemplate>();
        List<PlotDungeonTemplate> harderTpls = new List<PlotDungeonTemplate>();
        DanrenFubenUI UI;
        GCPlotDungeonInfo info;
        List<PlotDungeonTemplate> currentTpls;

        private DungeonType dungeonType;
        private List<DanrenFubenItemScript> itemScripts = new List<DanrenFubenItemScript>();

        private DanrenFubenItemScript currentItemScript;

        private int currentChapter;
        private int CurrentChapter
        {
            set 
            {
                currentChapter = value;
                SetDungeonData(value);
            }
            get 
            {
                return currentChapter;
            }
        }
         
        

        public DanrenFubenView()
        {
            uiName = "DanrenfubenUI";
          
        }
        public override void initWnd()
        {
            base.initWnd();
            UI = ui.gameObject.AddComponent<DanrenFubenUI>();
            UI.Init();
            for (int i = 0; i < UI.fubenItemUIs.Count; i++)
            {
                DanrenFubenItemScript itemScript = new DanrenFubenItemScript(UI.fubenItemUIs[i], this);
                itemScripts.Add(itemScript);
            }
            InitTpls();
            UI.btnClose.SetClickCallBack(OnClickClose);
            UI.btnEnter.SetClickCallBack(OnClickEnterGame);
            UI.btnLeftArrow.SetClickCallBack(OnClickLeftArrow);
            UI.btnRightArrow.SetClickCallBack(OnClickRightArrow);
            DanrenFubenModel.Instance.addChangeEvent(DanrenFubenModel.GET_DUNGEONINFO,GetDungeonInfo);
            UI.tabButtonGroup.TabChangeHandler = ChageTab;
        }

        private void InitTpls()
        {
            Dictionary<int, PlotDungeonTemplate> tpls = PlotDungeonTemplateDB.Instance.getIdKeyDic();
            foreach (var item in tpls)
            {
                if (item.Value.hardFlag == 0)
                {
                    normalTpls.Add(item.Value);
                }
                else
                {
                    harderTpls.Add(item.Value);
                }
            }
            normalTpls.Sort(delegate(PlotDungeonTemplate x, PlotDungeonTemplate y)
            {
                return x.plotDungeonLevel.CompareTo(y.plotDungeonLevel);
            });
            harderTpls.Sort(delegate(PlotDungeonTemplate x, PlotDungeonTemplate y)
            {
                return x.plotDungeonLevel.CompareTo(y.plotDungeonLevel);
            });
        }

        private void OnClickClose()
        {
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            GameClient.ins.OnBigWndShown();
            UI.tabButtonGroup.SetIndexWithCallBack(UI.tabButtonGroup.index);
            SetModelVisible(true);
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            GameClient.ins.OnBigWndHidden();
            SetModelVisible(false);
        }

        private void ChageTab(int index)
        {
            PlotdungeonCGHandler.sendCGPlotDungeonInfo(UI.tabButtonGroup.index);
        }

        private void GetDungeonInfo(RMetaEvent e = null)
        {
            if (UI.tabButtonGroup.index == 0)
            {
                dungeonType = DungeonType.NORMAL;
                currentTpls = normalTpls;
            }
            else if(UI.tabButtonGroup.index == 1)
            {
                dungeonType = DungeonType.HARDER;
                currentTpls = harderTpls;
            }
            info = DanrenFubenModel.Instance.GetDungeonInfoByType(dungeonType);  
            int currentLevel = info.getCurPlotDungeonLevel();
            CurrentChapter = currentLevel / LEVELS_PER_LEVEL;
            
        }

        private void SetDungeonData(int chapter)
        {
            List<PlotDungeonTemplate> tpls = GetTpls(chapter);
                   
            for (int i = 0; i < itemScripts.Count; i++)
            {
                itemScripts[i].SetData(tpls[i],info);
            }
            UI.textTitle.text = itemScripts[0].template.chapterName;
            CheckArrowState();
            DanrenFubenItemScript selectScript = null;
            for (int i = 0; i < itemScripts.Count; i++)
            {
                if (itemScripts[i].template.plotDungeonLevel == (info.getCurPlotDungeonLevel() + 1))
                {
                    selectScript = itemScripts[i];
                }
            }
            if (selectScript == null)
            {
                OnClickItem(null);
            }
            else 
            {
                if (info.getPlotDungeonChapter() * LEVELS_PER_LEVEL >= selectScript.template.plotDungeonLevel)
                {
                    OnClickItem(selectScript);
                }
                else
                {
                    OnClickItem(null);
                }
            }
     
        }

        private List<PlotDungeonTemplate> GetTpls(int currentChapter)
        {
            List<PlotDungeonTemplate>  tpls = new List<PlotDungeonTemplate>();        
            List<PlotDungeonTemplate> allTpls;
            if (dungeonType == DungeonType.NORMAL)
            {
                allTpls = normalTpls;
            }
            else
            {
                allTpls = harderTpls;
            }

            while (currentChapter * LEVELS_PER_LEVEL >= allTpls.Count)
            {
                currentChapter--;
            }

            for (int i = currentChapter * LEVELS_PER_LEVEL; i < (currentChapter + 1) * LEVELS_PER_LEVEL; i++)
            {
                tpls.Add(allTpls[i]);
            }

            return tpls;
        }

        private void SetModelVisible(bool visible)
        {
            for (int i = 0; i < itemScripts.Count; i++)
            {
                if (visible)
                {
                    itemScripts[i].ShowAvatarModel();
                }
                else
                {
                    itemScripts[i].HideAvatarModel();
                }
            }
        }

        private void OnClickLeftArrow()
        {
            CurrentChapter--;
        }
        private void OnClickRightArrow()
        {
            CurrentChapter++;
        }

        private void CheckArrowState()
        {
            UI.btnLeftArrow.gameObject.SetActive(currentChapter > 0);
            UI.btnRightArrow.gameObject.SetActive(currentTpls[currentTpls.Count - 1].plotDungeonLevel > itemScripts[ITEMS_LAST_INDEX].template.plotDungeonLevel);
        }

        public void OnClickItem(DanrenFubenItemScript itemScript)
        {
            if (itemScript == null)
            {
                SetScale(null);
                UI.btnEnter.gameObject.SetActive(false);
            }
            else
            {
                currentItemScript = itemScript;
                SetScale(currentItemScript);
                bool showButton = info!=null?(itemScript.template.plotDungeonLevel == (info.getCurPlotDungeonLevel() + 1)):false;
                UI.btnEnter.gameObject.SetActive(showButton);
            }
        }


        public void SetScale(DanrenFubenItemScript itemScript)
        {
            for (int i = 0; i < itemScripts.Count; i++)
            {
                if (itemScripts[i] == itemScript)
                {
                    itemScripts[i].SetScale(sLargeScale);
                }
                else
                {
                    itemScripts[i].SetScale(Vector3.one);
                }
            }
        }

        private void OnClickEnterGame()
        {
            if (currentItemScript != null)
            {
                PlotdungeonCGHandler.sendCGPlotDungeonStart((int)dungeonType, currentItemScript.template.plotDungeonLevel);
            }
        }

        public override void Destroy()
        {
            if (normalTpls != null)
            {
                normalTpls.Clear();
                normalTpls = null;
            }
            if (harderTpls != null)
            {
                harderTpls.Clear();
                harderTpls = null;
            }
            if (currentTpls != null)
            {
                currentTpls.Clear();
                currentTpls = null;
            }
            info = null;
            DanrenFubenModel.Instance.removeChangeEvent(DanrenFubenModel.GET_DUNGEONINFO, GetDungeonInfo);
            for (int i = 0; i < itemScripts.Count; i++)
            {
                itemScripts[i].Destroy();
            }
            if (itemScripts != null)
            {
                itemScripts.Clear();
                itemScripts = null;
            }

            if (currentItemScript != null)
            {
                currentItemScript = null;
            }
            base.Destroy();
            UI = null;
        }
    }
}
