using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.db;
using app.guide;
using app.story;
using app.zone;

namespace app.npc
{
    public class JuQingManager
    {
        private static JuQingManager _ins;
        private bool _isPlayingJuQing;
        private List<StoryTemplate> _curStoryList;
        public const string PLAY_JUQING_EVENT = "PLAY_JUQING_EVENT";
        public const string END_JUQING_EVENT = "END_JUQING_EVENT";
        
        /// <summary>
        /// 等待播放的动画剧情id
        /// </summary>
        public int waitingVedioId = 0;

        public static JuQingManager Ins
        {
            get
            {
                if (_ins==null)
                {
                    _ins = new JuQingManager();
                }
                return _ins;
            }
        }

        /// <summary>
        /// 是否正在播放剧情
        /// </summary>
        public bool IsPlayingJuQing
        {
            get { return (_isPlayingJuQing||StoryManager.ins.GetIsPlay()); }
        }

        /// <summary>
        /// 开始播放剧情
        /// </summary>
        /// <param name="juqingId"></param>
        public void StartJuQing(int juqingId,int waitVedioId=0)
        {
            waitingVedioId = waitVedioId;
            List<StoryTemplate> storyList = StoryTemplateDB.Instance.GetStoryListById(juqingId);
            if (storyList.Count==0)
            {
                _isPlayingJuQing = false;
                if (waitingVedioId!=0)
                {
                    StoryManager.ins.EnterStory(waitingVedioId);
                }
                return;
            }
            _curStoryList = storyList;
            PlayNextJuQing();
        }

        public void PlayNextJuQing()
        {
            if (_curStoryList!=null&&_curStoryList.Count > 0)
            {
                StoryTemplate storyTpl = _curStoryList[0];
                _curStoryList.RemoveAt(0);
                if(_isPlayingJuQing==false)
                {
                    //开始播放剧情，当前如果有正在做的引导，直接冲掉
                    if (GuideManager.Ins.isShowingGuide()&&GuideMaskWnd.Ins.isShown)
                    {
                        GuideManager.Ins.RemoveGuide();
                    }
                    NpcChatView.Ins.StartPlayJuQing(storyTpl);
                }
                else
                {
                    //继续播放剧情
                    EventCore.dispathRMetaEventByParms(PLAY_JUQING_EVENT, storyTpl);
                }
                _isPlayingJuQing = true;
            }
            else
            {
                _isPlayingJuQing = false;
                //停止播放剧情
                EventCore.dispathRMetaEventByParms(END_JUQING_EVENT,null);
                //检查是否有引导显示
                ZoneUI.ins.checkNewFuncAndGuide();
                //播放动画剧情
                if (waitingVedioId != 0)
                {
                    StoryManager.ins.EnterStory(waitingVedioId);
                }
				waitingVedioId=0;
            }
        }

        public void StopJuQing()
        {
            _curStoryList.Clear();
            PlayNextJuQing();
        }
        
        public void Destroy()
        {
            _isPlayingJuQing = false;
            _curStoryList = null;
            _ins = null;
            waitingVedioId = 0;
        }
    }

}
