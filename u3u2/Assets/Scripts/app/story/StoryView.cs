using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace app.story
{
    public class StoryView : BaseWnd
    {
        private StoryUI UI;
        private float m_movetiem = 2f;

        private UGUIImageText roundNumTxt = null;
        private UGUIImageText waitTimeTxt = null;
        private RTimer rtimer;
        // 开场文字的文本
        private List<Text> textlist = new List<Text>();
        //等待显示的开场文字
        private List<string> waitingTextList = new List<string>();
        //正在等待显示回合开始倒计时
        private bool isWaitShowWait = false;

        public StoryView()
        {
            base.isShowBgMask = true;
            base.bgMaskAlpha = 0f;
            uiName = "StoryUI";

            roundNumTxt = new UGUIImageText();
            waitTimeTxt = new UGUIImageText();

        }

        public override void initWnd()
        {
            base.initWnd();

            UI = ui.AddComponent<StoryUI>();
            UI.Init();

            UI.m_SkipStoryBtn.SetClickCallBack(ClickSkipStory);

            StoryModel.Ins.addChangeEvent(StoryModel.EXIT_STORY, ExitStory);

            roundNumTxt.SetParent(UI.roundNumContainer.transform);
            roundNumTxt.gameObject.transform.localPosition = Vector3.zero;
            roundNumTxt.gameObject.transform.localScale = Vector3.one;

            waitTimeTxt.SetParent(UI.waitTimeContainer.transform);
            waitTimeTxt.gameObject.transform.localPosition = Vector3.zero;
            waitTimeTxt.gameObject.transform.localScale = Vector3.one;
            waitTimeTxt.gameObject.transform.SetAsFirstSibling();
            
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);

            if (StoryManager.ins.IsStoryBattle)
            {
                UI.roundNumContainer.gameObject.SetActive(false);
                UI.waitTimeContainer.gameObject.SetActive(false);
                UI.m_image_top.gameObject.SetActive(false);
                UI.m_image_bottom.gameObject.SetActive(false);
            }
            else
            {
                UI.roundNumContainer.gameObject.SetActive(false);
                UI.waitTimeContainer.gameObject.SetActive(false);
                UI.m_image_top.gameObject.SetActive(true);
                UI.m_image_bottom.gameObject.SetActive(true);
                ShowHeiTiao();
            }
            UpdateRoundNum(StoryManager.ins.curRoundNum);
            if (isWaitShowWait)
            {
                StartWaitTime();
            }
            if (waitingTextList.Count>0)
            {//把等待显示的添加上
                for (int i=0;i<waitingTextList.Count;i++)
                {
                    showEntryText(waitingTextList[i]);
                }
            }
        }

        public void ExitStory(RMetaEvent e)
        {
            hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide();

            hideEntryText();
        }

        private void ClickSkipStory()
        {
            StoryManager.ins.ExitStory();
        }

        public override void Destroy()
        {
            if (rtimer != null)
            {
                rtimer.stop();
            }
            rtimer = null;
            StoryModel.Ins.removeChangeEvent(StoryModel.EXIT_STORY, ExitStory);
            base.Destroy();
            UI = null;
        }

        protected override void clickSpaceArea(GameObject go)
        {
            //base.clickSpaceArea(go);
        }

        public void ShowHeiTiao()
        {
            RectTransform topRTF = UI.m_image_top.GetComponent<RectTransform>();
            topRTF.anchoredPosition = new Vector2(0, 50);
            topRTF.DOAnchorPos(new Vector2(0,0), m_movetiem);

            RectTransform bomRTF = UI.m_image_bottom.GetComponent<RectTransform>();
            bomRTF.anchoredPosition = new Vector2(0, -50);
            bomRTF.DOAnchorPos(new Vector2(0, 0), m_movetiem);
        }
        
        public void UpdateRoundNum(int roundNum)
        {
            if (UI != null && roundNum>0)
            {
                int curRoundNum = roundNum;
                if (curRoundNum >= 0)
                {
                    char[] chars = curRoundNum.ToString().ToCharArray();
                    int len = chars.Length;
                    string[] content = new string[len];
                    for (int i = 0; i < len; i++)
                    {
                        content[i] = chars[i].ToString() + "_4";
                    }
                    roundNumTxt.SetContent(PathUtil.Ins.uiDependenciesPath, content);
                }
                UI.roundNumContainer.gameObject.SetActive(true);
            }
        }

        public void StartWaitTime()
        {
            if (UI==null)
            {
                isWaitShowWait = true;
                return;
            }
            isWaitShowWait = false;
            if (rtimer==null)
            {
                rtimer = TimerManager.Ins.createTimer(1000,3000,UpdateRoundWaitTime,EndWaitTime);
                rtimer.start();
            }
            else
            {
                rtimer.stop();
                rtimer.Reset(1000,3000);
                rtimer.Restart();
            }
            string[] content = new string[1];
            content[0] = "3_5";
            waitTimeTxt.SetContent(PathUtil.Ins.uiDependenciesPath, content, -9.0f);
            UI.waitTimeContainer.SetActive(true);
        }

        private void UpdateRoundWaitTime(RTimer r)
        {
            int curRoundWaitTimeLeft = Mathf.CeilToInt(r.getLeftTime()/1000f);
            if (curRoundWaitTimeLeft > 0)
            {
                char[] chars = curRoundWaitTimeLeft.ToString().ToCharArray();
                int len = chars.Length;
                string[] content = new string[len];
                for (int i = 0; i < len; i++)
                {
                    content[i] = chars[i].ToString() + "_5";
                }
                waitTimeTxt.SetContent(PathUtil.Ins.uiDependenciesPath, content, -9.0f);
            }
        }

        private void EndWaitTime(RTimer r)
        {
            if (rtimer!=null) rtimer.stop();
            if (waitTimeTxt!=null) waitTimeTxt.Clear();
            UI.waitTimeContainer.SetActive(false);
        }

        public override void DoUpdate(float deltaTime)
        {
            base.DoUpdate(deltaTime);
            if (UI.blackbg.activeInHierarchy)
            {
                float y = UI.textRTF.anchoredPosition3D.y;
                UI.textRTF.anchoredPosition3D = new Vector3(0,y+3,0);
            }
        }

        /// <summary>
        /// 显示开场剧情字幕
        /// </summary>
        public void showEntryText(string str)
        {
            if (isShown&&UI!=null)
            {
                UI.blackbg.gameObject.SetActive(true);

                Text txt = GameObject.Instantiate(UI.defaultText);
                txt.gameObject.transform.SetParent(UI.textContainer.transform);
                txt.transform.localScale = Vector3.one;
                txt.gameObject.SetActive(true);
                txt.text = str;
                textlist.Add(txt);
            }
            else
            {
                waitingTextList.Add(str);
            }
        }

        public void hideEntryText()
        {
            if (UI!=null)
            {
                UI.blackbg.gameObject.SetActive(false);
                UI.textRTF.anchoredPosition3D = Vector3.zero;
            }
            for (int i=0;i<textlist.Count;i++)
            {
                GameObject.Destroy(textlist[i].gameObject);
            }
            textlist.Clear();
            waitingTextList.Clear();
        }

    }
}
