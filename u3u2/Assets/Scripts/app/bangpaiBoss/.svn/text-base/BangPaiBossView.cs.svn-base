using UnityEngine;
using System.Collections;
using app.net;
using app.db;
using System.Collections.Generic;
using app.zone;


namespace app.bangpaiBoss
{
    public class BangPaiBossView : BaseWnd
    {
        private static Vector3 sLargeScale = new Vector3(1.05f,1.05f,1);
        private const int CHAPTER_MAX_NUMBER = 5;
        private const int ITEMS_LAST_INDEX = 4;

        BangPaiBossUI UI;
        private BangPaiBossItemScript[] itemScripts = new BangPaiBossItemScript[5];
        private BangPaiBossItemScript selectedItem;

        private List<CorpsBossTemplate> bossTpls;

        //当前是第几章
        private int mCurrentChapter = -1;
        public int currentChapter
        {
            get
            {
                return mCurrentChapter;
            }
            set
            {
                mCurrentChapter = value;
                InitChapter();
            }
        }

        public BangPaiBossView()
        {
            uiName = "BangpaiBossUI";
        }
        public override void initWnd()
        {
            base.initWnd();
            UI = ui.gameObject.AddComponent<BangPaiBossUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(Close);

            for (int i = 0; i < UI.bossItems.Length; i++)
            {
                itemScripts[i] = new BangPaiBossItemScript(UI.bossItems[i], this);
            }

            GetTpls();
            BangPaiBossModel.Ins.addChangeEvent(BangPaiBossModel.UPDATE_BOSS_INFO,OnBossInfoUpdate);
            UI.btn_leftArrow.SetClickCallBack(OnClickLeftArrow);
            UI.btn_rightArrow.SetClickCallBack(OnClickRightArrow);
            UI.btn_enterGame.SetClickCallBack(OnClickBattle);

        }

        private void Close()
        {
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            ShowAvatar(true);
            CorpsbossCGHandler.sendCGCorpsBossInfo();
        }


        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            ShowAvatar(false);
            
        }

        private void OnBossInfoUpdate(RMetaEvent e = null)
        {
            GetCurrentChapterIndex();
        }

        private void InitChapter()
        {
            if ((mCurrentChapter * CHAPTER_MAX_NUMBER + 5) > bossTpls.Count)
            {
                currentChapter -= 1;
                return;
            }
            for (int i = 0; i < itemScripts.Length; i++)
            {
                itemScripts[i].SetData(bossTpls[i + mCurrentChapter * CHAPTER_MAX_NUMBER]);            
            }   
            UI.text_title.text = string.Format("第{0}章 {1}",mCurrentChapter + 1,itemScripts[0].tpl.chapterName);
            SelectDefaultItem();
            CheckArrowState();
        }

        private void CheckArrowState()
        {
            UI.btn_leftArrow.gameObject.SetActive(currentChapter > 0);
            UI.btn_rightArrow.gameObject.SetActive(bossTpls[bossTpls.Count - 1].bossLevel > itemScripts[ITEMS_LAST_INDEX].tpl.bossLevel);
        }

        private void OnClickLeftArrow()
        {
            if (currentChapter == -1)
            {
                return;
            }
            currentChapter -= 1;
        }

        private void OnClickRightArrow()
        {
            if (currentChapter == -1)
            {
                return;
            }
            if (BangPaiBossModel.Ins.bossInfo.getCurCorpsBossLevel() < itemScripts[ITEMS_LAST_INDEX].tpl.bossLevel)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("本章节尚未通关,无法进入下一章节！");
            }
            else
            {
                currentChapter += 1;
            }
        }

        private void SelectDefaultItem()
        {
            BangPaiBossItemScript defaultItem = itemScripts[0];
            for (int i = 1; i < itemScripts.Length; i++)
            {
                if (itemScripts[i].tpl.bossLevel <= (BangPaiBossModel.Ins.bossInfo.getCurCorpsBossLevel() + 1)
                    && itemScripts[i].tpl.bossLevel > defaultItem.tpl.bossLevel)
                {
                    defaultItem = itemScripts[i];
                }
            }

            defaultItem.OnClick();
        }        
      
        public void OnItemClick(BangPaiBossItemScript itemScript)
        { 
            for (int i = 0; i < itemScripts.Length; i++)
			{
		        if(itemScript == itemScripts[i])
                {
                    selectedItem = itemScript;
                    itemScript.SetScale(sLargeScale);
                }
                else
                {
                    itemScripts[i].SetScale(Vector3.one);
                }
			}
        }

        public void CancleSelect()
        {
            selectedItem = null;
            for (int i = 0; i < itemScripts.Length; i++)
            {
                itemScripts[i].SetScale(Vector3.one);
            }
        }

        private void ShowAvatar(bool show)
        {
            for (int i = 0; i < itemScripts.Length; i++)
            {
                if (show)
                {
                    itemScripts[i].ShowAvatarModel();
                }
                else
                {
                    itemScripts[i].HideAvatarModel();
                }
            }
        }

        private void GetTpls()
        {
            bossTpls = new List<CorpsBossTemplate>();
            Dictionary<int, CorpsBossTemplate> tplDic = CorpsBossTemplateDB.Instance.getIdKeyDic();
            foreach (var item in tplDic)
            {
                bossTpls.Add(item.Value);
            }
            bossTpls.Sort(delegate(CorpsBossTemplate x, CorpsBossTemplate y)
            {
                return x.bossLevel.CompareTo(y.bossLevel);
            });
        }

        private void GetCurrentChapterIndex()
        {

            int level = BangPaiBossModel.Ins.bossInfo.getCurCorpsBossLevel();
            currentChapter = level / CHAPTER_MAX_NUMBER;
        }

        private void OnClickBattle()
        {
            if (selectedItem == null)
            {
                ClientLog.Log("corpsBoss view selectedItem is null.");
                return;
            }
            CorpsbossCGHandler.sendCGCorpsbossAskEnterTeam(selectedItem.tpl.bossLevel);
        }

        public override void Destroy()
        {
            bossTpls = null;
            if (itemScripts != null)
            {
                for (int i = 0; i < itemScripts.Length; i++)
                {
                    itemScripts[i].Destroy();
                }
            }
            selectedItem = null;
            BangPaiBossModel.Ins.removeChangeEvent(BangPaiBossModel.UPDATE_BOSS_INFO, OnBossInfoUpdate);
            base.Destroy();
        }


    }
}
