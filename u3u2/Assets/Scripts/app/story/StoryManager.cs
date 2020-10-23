using app.battle;
using app.human;
using UnityEngine;
using app.model;
using app.state;
using System.Collections.Generic;
using app.avatar;
using System;
using app.db;
using app.zone;

namespace app.story
{
    /// <summary>
    /// 剧情管理类，管理剧情动画（StoryVideo）、剧情战斗（StoryBattle） 
    /// </summary>
    public class StoryManager
    {
        /// <summary>
        /// 是否已经播放开场战斗剧情
        /// </summary>
        private bool hasPlayVideo = false;

        /// <summary>
        /// 是否剧情战斗
        /// </summary>
        private bool m_isStoryBattle;
        /// <summary>
        /// 是否剧情战斗
        /// </summary>
        public bool IsStoryBattle
        {
            get { return m_isStoryBattle; }
            set { m_isStoryBattle = value; }
        }

        public static float ModelMaxHeight = 2.1f;

        /// <summary>
        /// 是否正在播放
        /// </summary>
        private bool m_IsPlay = false;
        public bool GetIsPlay()
        {
            return m_IsPlay;
        }

        /// <summary>
        /// 等待播放动画id;
        /// </summary>
        private int m_waite_storyid = -1;
        /// <summary>
        /// 等待动画是否剧情战斗
        /// </summary>
        private bool m_waite_IsStoryBattle = false;

        /// <summary>
        /// 当前播放动画id
        /// </summary>
        private int m_storyid = -1;
        /// <summary>
        /// 当前的回合数
        /// </summary>
        public int curRoundNum = 0;
        /// <summary>
        /// 剧情动画列表
        /// </summary>
        private SortedDictionary<int, List<StoryCell>> m_showvideos = new SortedDictionary<int, List<StoryCell>>();

        /// <summary>
        /// 剧情战斗列表
        /// </summary>
        private SortedDictionary<int, List<StoryBattleCell>> m_battlevideos = new SortedDictionary<int, List<StoryBattleCell>>();
        
        /// <summary>
        /// 创建的模型列表
        /// </summary>
        private Dictionary<string, StoryBattleAvatar> m_battlemodels = new Dictionary<string, StoryBattleAvatar>();
        /// <summary>
        /// 创建的模型列表
        /// </summary>
        private Dictionary<string, StoryAvatar> m_models = new Dictionary<string, StoryAvatar>();

        /// <summary>
        /// 创建的特效列表
        /// </summary>
        private Dictionary<string, StoryEffect> m_effects = new Dictionary<string, StoryEffect>();

        /// <summary>
        /// 当前播放时间点
        /// </summary>
        private int m_showtime = -1;

        /// <summary>
        /// 开始播放动画过去的时间
        /// </summary>
        private DateTime m_StartTime;

        /// <summary>
        /// 播放速度
        /// </summary>
        private float m_Speed = 1f;

        private GameObject _modelCam = null;
        private GameObject mModelsContainer = null;
        public GameObject storyBattleMask = null;
        //震屏相关
        private float mShakeStartTime = 0.0f;
        private float mShakeTime = 0.0f;
        private bool mIsShaking = false;
        private int mLastShakeStamp = 0;
        
        private static StoryManager mIns = null;
        public static StoryManager ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new StoryManager();
                }
                return mIns;
            }
        }

        public GameObject ModelCam
        {
            get { return _modelCam; }
        }

        /// <summary>
        /// 是否已经播放开场战斗剧情
        /// </summary>
        public bool HasPlayVideo
        {
            get { return hasPlayVideo; }
            set { hasPlayVideo = value; }
        }

        public StoryManager()
        {
            init();
        }

        private void init()
        {
        }

        public void OnEnter()
        {
            if (mModelsContainer == null)
            {
                mModelsContainer = new GameObject("StoryModels");
                mModelsContainer.transform.SetParent(SceneModel.ins.zoneContainer.transform);
                mModelsContainer.transform.localPosition = Vector3.zero;
                mModelsContainer.layer = LayerConfig.Layer_StoryModel;
            }
            if (ModelCam == null)
            {
                _modelCam = GameObject.Instantiate(SceneModel.ins.zone3DModelCam);
                ModelCam.name = "StoryModelCam";
                ModelCam.transform.SetParent(SceneModel.ins.zoneCamsContainer.transform);
                ModelCam.transform.localPosition = Vector3.zero;
                ModelCam.layer = LayerConfig.Layer_StoryModel;
                Camera cam = ModelCam.GetComponent<Camera>();
                cam.cullingMask = 1 << LayerConfig.Layer_StoryModel;
            }
            if (IsStoryBattle)
            {
                if (storyBattleMask == null)
                {
                    storyBattleMask = SourceManager.Ins.createObjectFromAssetBundle("battleGroundMask.abl");
                    storyBattleMask.transform.SetParent(ModelCam.transform);
                    storyBattleMask.transform.localPosition = new Vector3(0, 0, 10);
                    storyBattleMask.transform.localEulerAngles = new Vector3(0, 180f, 0);
                    storyBattleMask.transform.localScale = new Vector3(1.5f, 1, 1);
                    storyBattleMask.layer = LayerConfig.Layer_StoryModel;
                }
                storyBattleMask.gameObject.SetActive(true);
            }
            else
            {
                if (storyBattleMask != null)
                {
                    storyBattleMask.gameObject.SetActive(false);
                }
            }
            mModelsContainer.SetActive(true);
            ModelCam.SetActive(true);
            SceneModel.ins.zone3DModelCam.SetActive(false);
            AvatarTextManager.Ins.SetActive(true);
            ZoneUI.ins.hideAll();
            UGUIConfig.HideSanCamers();
            //AudioManager.Ins.SetMuteTmp(AudioEnumType.BackGround,true);
            InitStoryData();
        }

        public void OnLeave()
        {
            mModelsContainer.SetActive(false);
            ModelCam.gameObject.SetActive(false);
            SceneModel.ins.zone3DModelCam.SetActive(true);
            UGUIConfig.ShowSanCamers();

            Destroy();
            //AudioManager.Ins.SetMuteTmp(AudioEnumType.BackGround, false);
        }

        private void InitStoryData()
        {
            //初始化剧情。
            m_IsPlay = false;
            m_showvideos.Clear();
            m_battlevideos.Clear();
            m_models.Clear();
            m_battlemodels.Clear();
            m_effects.Clear();

            m_showtime = -1;
            m_StartTime = System.DateTime.Now;
            if (!IsStoryBattle)
            {
                ///初始化所有显示的剧情动画///
                List<VideoTemplate> getdata = VideoTemplateDB.Instance.GetVideoData(m_storyid);
                for (int i = 0; i < getdata.Count; ++i)
                {
                    StoryCell temp = new StoryCell(getdata[i]);
                    if (!m_showvideos.ContainsKey(temp.m_data.timePoint))
                    {
                        m_showvideos.Add(temp.m_data.timePoint, new List<StoryCell>());
                    }
                    m_showvideos[temp.m_data.timePoint].Add(temp);
                }
                bool isget = SetNext();
                if (!isget)
                {
                    m_storyid = -1;
                    return;
                }
                LinkParse.Ins.linkToFunc(FunctionIdDef.STORY_VIDEO);
            }
            else
            {
                ///初始化所有显示的剧情动画///
                List<StoryBattleTemplate> getdata = StoryBattleTemplateDB.Instance.GetTplByStoryId(m_storyid);
                    StoryDef.GetStoryBattleList();

                for (int i = 0; i < getdata.Count; ++i)
                {
                    StoryBattleCell temp = new StoryBattleCell(getdata[i]);
                    if (!m_battlevideos.ContainsKey(temp.m_data.time))
                    {
                        m_battlevideos.Add(temp.m_data.time, new List<StoryBattleCell>());
                    }
                    m_battlevideos[temp.m_data.time].Add(temp);
                }
                bool isget = SetNext();
                if (!isget)
                {
                    m_storyid = -1;
                    return;
                }
                LinkParse.Ins.linkToFunc(FunctionIdDef.STORY_VIDEO);
            }
            m_IsPlay = true;
        }

        private void Destroy()
        {
            //退出剧情时销毁，释放内存。
            m_storyid = -1;
            curRoundNum = 0;
            DestoryAllModel();
            DestoryAllEffect();
            m_showvideos.Clear();
            m_battlevideos.Clear();
            StoryModel.Ins.ExitStory();
            m_IsPlay = false;
        }

        public void FixedUpdate()
        {
            foreach (StoryBattleAvatar storyavatar in m_battlemodels.Values)
            {
                if (null != storyavatar)
                {
                    storyavatar.FixedUpdate();
                }
            }
        }

        public void LateUpdate()
        {
            foreach (StoryAvatar storyavatar in m_models.Values)
            {
                if (null != storyavatar)
                {
                    storyavatar.LateUpdate();
                }
            }
        }

        public void Update()
        {
            if (m_IsPlay)
            {
                foreach (StoryAvatar storyavatar in m_models.Values)
                {
                    if (null != storyavatar)
                    {
                        storyavatar.Update();
                    }
                }

                foreach (StoryBattleAvatar storyavatar in m_battlemodels.Values)
                {
                    if (null != storyavatar)
                    {
                        storyavatar.Update();
                    }
                }
                System.TimeSpan ts = System.DateTime.Now - m_StartTime;
                int passTime = (int)(Math.Floor(ts.TotalMilliseconds) * m_Speed);
                if (passTime >= m_showtime)
                {
                    PlayCurrent();
                }
                //m_PassTime += (int)(Time.deltaTime*1000 * m_Speed);

                //震屏相关
                if (mIsShaking)
                {
                    if (Time.time - mShakeStartTime >= mShakeTime)
                    {
                        SceneModel.ins.zoneGroundCam.transform.localPosition = Vector3.zero;
                        SceneModel.ins.zone3DModelCam.transform.localPosition = Vector3.zero;
                        ModelCam.transform.localPosition = Vector3.zero;
                        mIsShaking = false;
                    }
                    else
                    {
                        if (mLastShakeStamp >= 2)
                        {
                            float x = UnityEngine.Random.Range(-0.06f, 0.06f);
                            float z = UnityEngine.Random.Range(-0.06f, 0.06f);
                            Vector3 v = new Vector3(x, 0, z);
                            SceneModel.ins.zoneGroundCam.transform.localPosition = v;
                            SceneModel.ins.zone3DModelCam.transform.localPosition = v;
                            ModelCam.transform.localPosition = v;
                            mLastShakeStamp = 0;
                        }
                        mLastShakeStamp++;
                    }
                }
            }
        }

        /// <summary>
        /// 震屏
        /// </summary>
        /// <param name="seconds">震屏时间秒</param>
        public void ShakeCamera(float seconds)
        {
            mShakeTime = seconds;
            mShakeStartTime = Time.time;
            mIsShaking = true;
        }

        /// <summary>
        /// 播放当前时间点动画
        /// </summary>
        private void PlayCurrent()
        {
            if (!IsStoryBattle)
            {
                bool isget = false;
                List<StoryCell> showvideos;
                isget = m_showvideos.TryGetValue(m_showtime, out showvideos);
                if (isget)
                {
                    for (int i = 0; i < showvideos.Count; ++i)
                    {
                        showvideos[i].PlayVideo(m_Speed);
                    }
                    ///设置下一个动画///
                    SetNext();
                }
                else
                {
                    ///出问题了///
                    ExitStory();
                }
            }
            else
            {
                bool isget = false;
                List<StoryBattleCell> showvideos;
                isget = m_battlevideos.TryGetValue(m_showtime, out showvideos);
                if (isget)
                {
                    bool hasChangeRound = false;
                    for (int i = 0; i < showvideos.Count; ++i)
                    {
                        if (showvideos[i].m_data.round>0&&showvideos[i].m_data.round != curRoundNum)
                        {
                            curRoundNum = showvideos[i].m_data.round;
                            //更新回合数
                            (Singleton.GetObj(typeof(StoryView)) as StoryView).UpdateRoundNum(showvideos[i].m_data.round);
                            (Singleton.GetObj(typeof(StoryView)) as StoryView).StartWaitTime();
                            hasChangeRound = true;
                        }
                    }
                    if (!hasChangeRound)
                    {
                        for (int i = 0; i < showvideos.Count; ++i)
                        {
                            showvideos[i].PlayVideo(m_Speed);
                        }
                        ///设置下一个动画///
                        SetNext();
                    }
                }
                else
                {
                    ///出问题了///
                    ExitStory();
                }
            }
        }

        /// <summary>
        /// 设置下一时间点
        /// </summary>
        /// <returns></returns>
        private bool SetNext()
        {
            bool isexisted = false;
            if (!IsStoryBattle)
            {
                foreach (int value in m_showvideos.Keys)
                {
                    if (value > m_showtime)
                    {
                        m_showtime = value;
                        isexisted = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (int value in m_battlevideos.Keys)
                {
                    if (value > m_showtime)
                    {
                        m_showtime = value;
                        isexisted = true;
                        break;
                    }
                }
            }

            if (isexisted)
            {
                return true;
            }
            else
            {
                ///没有下一时间点，结束播放///
                ExitStory();
                return false;
            }

        }

        /// <summary>
        /// 进入剧情动画
        /// </summary>
        /// <param name="storyid"></param>
        public void EnterStory(int storyid,bool isBattle=false)
        {
            if (GuideManager.Ins.isShowingGuide())
            {
                m_waite_storyid = storyid;
                m_waite_IsStoryBattle = isBattle;
                return;
            }
            if (m_storyid == storyid || m_IsPlay)
            {
                return;
            }
            IsStoryBattle = isBattle;
            m_storyid = storyid;
            StateManager.Ins.changeState(StateDef.storyState);
        }

        /// <summary>
        /// 退出剧情动画
        /// </summary>
        public void ExitStory()
        {
            StateManager.Ins.changeState(StateDef.zoneState);
        }

        public void EnterWaiteStory()
        {
            if (-1 != m_waite_storyid)
            {
                int storyid = m_waite_storyid;
                bool IsStoryBattle = m_waite_IsStoryBattle;
                m_waite_storyid = -1;
                m_waite_IsStoryBattle = false;
                EnterStory(storyid, IsStoryBattle);
            }
        }

        /// <summary>
        /// 增加模型到列表中
        /// </summary>
        /// <param name="modelname"></param>
        /// <param name="addavatar"></param>
        public void AddAvatar(string modelname, StoryAvatar addavatar)
        {
            if (!m_models.ContainsKey(modelname))
            {
                m_models.Add(modelname, addavatar);
            }
            else
            {
                m_models[modelname] = addavatar;
            }
        }

        /// <summary>
        /// 增加模型到列表中
        /// </summary>
        /// <param name="modelname"></param>
        /// <param name="addavatar"></param>
        public void AddBattleAvatar(string modelname, StoryBattleAvatar addavatar)
        {
            if (!m_battlemodels.ContainsKey(modelname))
            {
                m_battlemodels.Add(modelname, addavatar);
            }
            else
            {
                m_battlemodels[modelname] = addavatar;
            }
        }

        /// <summary>
        /// 增加特效到列表中
        /// </summary>
        /// <param name="modelname"></param>
        /// <param name="addavatar"></param>
        public void AddEffect(string modelname, StoryEffect addeffect)
        {
            if (!m_effects.ContainsKey(modelname))
            {
                m_effects.Add(modelname, addeffect);
            }
            else
            {
                m_effects[modelname] = addeffect;
            }
        }
        /// <summary>
        /// 在列表中获取某一模型
        /// </summary>
        /// <param name="modelname"></param>
        /// <returns></returns>
        public StoryAvatar GetAvatar(string modelname)
        {
            if (m_models.ContainsKey(modelname))
            {
                return m_models[modelname];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 在列表中获取某一模型
        /// </summary>
        /// <param name="modelname"></param>
        /// <returns></returns>
        public StoryBattleAvatar GetBattleAvatar(string modelname)
        {
            if (m_battlemodels.ContainsKey(modelname))
            {
                return m_battlemodels[modelname];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 删除莫一模型
        /// </summary>
        /// <param name="modelname"></param>
        public void DestroyOneModel(string modelname)
        {
            if (m_models.ContainsKey(modelname))
            {
                m_models[modelname].Destroy();
                m_models[modelname] = null;
                m_models.Remove(modelname);
            }
            if (m_battlemodels.ContainsKey(modelname))
            {
                m_battlemodels[modelname].Destroy();
                m_battlemodels[modelname] = null;
                m_battlemodels.Remove(modelname);
            }
            if (m_effects.ContainsKey(modelname))
            {
                //m_effects[modelname].Destroy();
                m_effects[modelname] = null;
                m_effects.Remove(modelname);
            }
        }

        /// <summary>
        /// 删除所有模型
        /// </summary>
        public void DestoryAllModel()
        {
            foreach (StoryAvatar valeu in m_models.Values)
            {
                valeu.Destroy();
            }
            m_models.Clear();

            foreach (StoryBattleAvatar valeu in m_battlemodels.Values)
            {
                valeu.Destroy();
            }
            m_battlemodels.Clear();
        }

        /// <summary>
        /// 删除所有特效
        /// </summary>
        public void DestoryAllEffect()
        {
            foreach (StoryEffect valeu in m_effects.Values)
            {
                valeu.Destroy();
            }
            m_effects.Clear();
        }

        public VideoTemplate GetNextData(VideoTemplate curdata)
        {
            List<StoryCell> result = new List<StoryCell>();
            foreach (int time in m_showvideos.Keys)
            {
                if (time > curdata.timePoint)
                {
                    result = m_showvideos[time];
                    for (int i = 0; i < result.Count; ++i)
                    {
                        if (result[i].m_data.targetId == curdata.targetId)
                        {
                            return result[i].m_data;
                        }
                    }
                }
            }

            return null;
        }

        public StoryBattleTemplate GetNextData(StoryBattleTemplate curdata)
        {
            List<StoryBattleCell> result = new List<StoryBattleCell>();
            foreach (int time in m_battlevideos.Keys)
            {
                if (time > curdata.time)
                {
                    result = m_battlevideos[time];
                    for (int i = 0; i < result.Count; ++i)
                    {
                        if (result[i].m_data.targetId == curdata.targetId)
                        {
                            return result[i].m_data;
                        }
                    }
                }
            }

            return null;
        }

        public GameObject GetModelsContainer()
        {
            return mModelsContainer;
        }
    }
}