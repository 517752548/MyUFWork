using UnityEngine;
using app.net;
using app.db;
using app.npc;
using System.Collections.Generic;
using app.human;
using app.state;

namespace app.zone
{
    /// <summary>
    /// 地图上的NPC。
    /// </summary>
    public class ZoneNPC : ZoneCharacterBase
    {
        public int NpcTplId { get; private set; }
        public NpcTemplate NpcTpl { get; private set; }
        public MapNpcTemplate MapNpcTpl { get; private set; }
        private NpcInfoData npcInfoData;
        /// <summary>
        /// npc身上所有的任务id列表
        /// </summary>
        public List<int> questIdList;
        /// <summary>
        /// 
        /// npc身上叹号
        /// </summary>
        private GameObject tanhaoEffect = null;
        /// <summary>
        /// npc身上问号
        /// </summary>
        private GameObject wenhaoEffect = null;
        /// <summary>
        /// npc显示的任务限制，玩家身上有如下任务时才显示此npc，没有则不显示
        /// </summary>
        public List<int> limitQuestIdList;

        //冒泡相关
        private int bubbleIndex = 0;
        private RTimer bubbleTimer;
        private const int MAX_LOOP_TIME = 6;
        private const int BUBBLE_LOOP_TIME = 5000;
        bool m_IsNeedDependence = true;

        public ZoneNPC(bool needdependence=true)
        {
            m_IsNeedDependence = needdependence;
            mCharacterNameColor = new Color(1f, 234 / 255f, 160 / 255f, 1f);
        }

        public void InitNpc(NpcInfoData npcInfodata, NpcTemplate npcTpl, MapNpcTemplate mapNpcTpl, Vector3 pos, bool showShadow = true)
        {
            NpcTplId = npcInfodata.npcId;
            NpcTpl = npcTpl;
            MapNpcTpl = mapNpcTpl;
            //解析 任务限制
            limitQuestIdList = initLimitQuestList(NpcTplId);
            Vector3 angle = new Vector3(0, NPCDefine.GetNpcDirectionById(NpcTpl.direction), 0);
            this.Init(0, NpcTpl.model3DId, NpcTpl.name, pos, angle, showShadow, false, false, true, (NPCType)npcTpl.type != NPCType.RESOURCE_POINT);
            NpcInfoData = npcInfodata;
            if (NpcTpl.loopStrList.Count > 0 && LoopStrHaveContent(NpcTpl.loopStrList))
            {
                bubbleTimer = TimerManager.Ins.createTimer(BUBBLE_LOOP_TIME,-1,OnBubbleTimer,null);
                bubbleTimer.start();
            }

        }

        /// <summary>
        /// 解析 任务限制
        /// </summary>
        public static List<int> initLimitQuestList(int npcTplId)
        {
            NpcTemplate npcTpl = NpcTemplateDB.Instance.getTemplate(npcTplId);
            //测试代码
            //if (npcTplId == 1012)
            //{
            //    npcTpl.questLimit = "10001;10003;10005;10007";
            //}
            if (npcTpl == null || (npcTpl != null && string.IsNullOrEmpty(npcTpl.questLimit)))
            {
                return null;
            }
            string[] str;
            npcTpl.questLimit = npcTpl.questLimit.Trim();
            List<int> questIdList = new List<int>(); ;
            if (npcTpl.questLimit.Contains(";"))
            {
                //多个 任务限制
                str = npcTpl.questLimit.Split(';');
            }
            else
            {
                //一个任务限制
                str = new string[1];
                str[0] = npcTpl.questLimit;
            }
            for (int i = 0; i < str.Length; i++)
            {
				if(!string.IsNullOrEmpty(str[i])){
					questIdList.Add(int.Parse(str[i]));
				}
            }
            return questIdList;
        }
        /// <summary>
        /// 无任务限制的npc 直接显示，有任务限制的 判断当前玩家是否有这个任务
        /// </summary>
        /// <returns></returns>
        public static bool CanNpcVisibleByLimitQuest(List<int> limitquestlist)
        {
            int limitquestLen = limitquestlist != null ? limitquestlist.Count : 0;
            for (int j = 0; j < limitquestLen; j++)
            {
                QuestInfoData questinfo = Human.Instance.QuestModel.GetQuestInfoById(limitquestlist[j]);
                if ( questinfo!= null && questinfo.questStatus != (int)QuestDefine.QuestStatus.CAN_FINISH)
                {
                    return true;
                }
            }
            return limitquestLen == 0 ? true : false;
        }

        public override void InitDisplayModel(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }
            base.InitDisplayModel(e);
            if (NpcTpl.type != (int)NPCType.TRANSFER_POINT && NpcTpl.type != (int)NPCType.MAP_EFFECT)
            {
                PlayAnimation(ANIM_NAME_IDLE);
            }
            //localEulerAngles = new Vector3(0, NPCDefine.GetNpcDirectionById(NpcTpl.direction), 0);
            UpdateMark();
        }

        public override string GetGameObjectName()
        {
            return NpcTpl.name;
        }

        protected override void CheckOpaque()
        {
            
        }

        public NpcInfoData NpcInfoData
        {
            set
            {
                npcInfoData = value;
                //if (npcInfoData.isInBattle == 1)
                //{
                //   // PlayAnimation(ANIM_NAME_MOVE);
                //    //ShowBattleSign();
                //}
                //else
                //{
                //    HideBattleSign();
                //    if (mAnim != null) PlayAnimation(ANIM_NAME_IDLE);
                //}
                isInBattle = npcInfoData.isInBattle == 1 ? HeadFlag.ZHAN_DOU : HeadFlag.NONE;
            }
            get { return npcInfoData; }
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="quest"></param>
        public void AddQuest(int questId)
        {
            if (questIdList == null)
            {
                questIdList = new List<int>();
            }
            questIdList.Add(questId);
            ClientLog.Log("npcid:" + NpcTplId + "   添加任务：" + questId);
            UpdateMark();
        }
        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="quest"></param>
        public void RemoveQuest(QuestInfoData quest)
        {
            if (questIdList != null)
            {
                questIdList.Remove(quest.questId);
                ClientLog.Log("npcid:" + NpcTplId + "   删除任务：" + quest.questId);
                UpdateMark();
            }
        }
        /// <summary>
        /// 清空任务
        /// </summary>
        public void ClearQuest()
        {
            if (questIdList != null)
            {
                questIdList.Clear();
                ClientLog.Log("清空任务列表:");
                UpdateMark();
            }
        }

        #region 更新叹号问号

        public void UpdateMark()
        {
            if (mAvatarText == null || questIdList == null)
            {
                return;
            }
            //可接：叹号
            //  可交：问号
            if (tanhaoEffect != null) tanhaoEffect.SetActive(false);
            if (wenhaoEffect != null) wenhaoEffect.SetActive(false);
            if (questIdList.Count > 0)
            {
                bool flat = false;
                for (int i = 0; i < questIdList.Count; i++)
                {
                    QuestInfoData questData = Human.Instance.QuestModel.GetQuestInfoById(questIdList[i]);
                    if (questData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
                    {

                    }
                    if (questData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED)
                    {
                        flat = true;
                        break;
                    }
                }
                if (flat)
                {
                    if (tanhaoEffect == null && mAvatarText!=null)
                    {
                        string effectPath = PathUtil.Ins.GetEffectPath("common_tanhao");
                        tanhaoEffect = SourceManager.Ins.createObjectFromAssetBundle(effectPath);
                        tanhaoEffect.transform.SetParent(mAvatarText.transform);
                        tanhaoEffect.transform.localScale = Vector3.one * 100f;
                        tanhaoEffect.transform.localEulerAngles = Vector3.zero;
                        tanhaoEffect.transform.localPosition = new Vector3(0, 300f, 0);
                        GameObjectUtil.SetLayer(tanhaoEffect, LayerConfig.Layer_ZoneModel);
                    }
                    tanhaoEffect.SetActive(true);
                }
                else
                {
                    if (wenhaoEffect == null && mAvatarText != null)
                    {
                        string effectPath = PathUtil.Ins.GetEffectPath("common_wenhao");
                        wenhaoEffect = SourceManager.Ins.createObjectFromAssetBundle(effectPath);
                        wenhaoEffect.transform.SetParent(mAvatarText.transform);
                        wenhaoEffect.transform.localScale = Vector3.one * 100f;
                        wenhaoEffect.transform.localEulerAngles = Vector3.zero;
                        wenhaoEffect.transform.localPosition = new Vector3(0, 300f, 0);
                        GameObjectUtil.SetLayer(wenhaoEffect, LayerConfig.Layer_ZoneModel);
                    }
                    wenhaoEffect.SetActive(true);
                }
            }

        }

        #endregion

        public override bool Update()
        {
            if (base.Update())
            {
                FixNpcSignPosition(mBattleSign);
                if (ZoneModel.ins.selectedEffect != null && 
                    ZoneModel.ins.selectedEffect.transform.parent == mDisplayModelContainer.transform &&
                    ZoneModel.ins.selectedEffect.activeSelf)
                {
                    ZoneModel.ins.selectedEffect.transform.localPosition = ZoneUtil.GetFixedPosition(mDisplayModelContainer.transform);
                }
                return true;
            }
            return false;
           
        }

        private void FixNpcSignPosition(GameObject sign)
        {
            if (sign != null && sign.activeSelf)
            {
                Vector3 pos = Vector3.zero;
                if (displayModelForLoc != null && displayModelForLoc.avatar != null)
                {
                    pos = displayModelForLoc.avatar.transform.localPosition;
                    pos.y = displayModelForLoc.totalHeight + 0.5f;
                }
                sign.transform.localPosition = pos;
            }
        }

        #region npc 自动循环冒泡

        public void OnBubbleTimer(RTimer timer)
        {
            if (StateManager.Ins.getCurState().state != StateDef.zoneState)
            {
                return;
            }
            string content = GetNextContent(NpcTpl.loopStrList, bubbleIndex);

            if (!string.IsNullOrEmpty(content))
            {
                ShowChatBubble(content);
            }

            bubbleIndex++;
        }

        private bool LoopStrHaveContent(List<npcGetLoopStrTemplate> strs)
        {

            for (int i = 0; i < strs.Count; i++)
            {
                if (!string.IsNullOrEmpty(strs[i].content1) || !string.IsNullOrEmpty(strs[i].content2))
                {
                    return true;
                }
            }
            
            return false;
        }

        private string GetNextContent(List<npcGetLoopStrTemplate> strs , int index)
        {
            int loopTime = 0;
            while (true)
            {
                if (loopTime > MAX_LOOP_TIME)
                {
                    break;
                }
                int currentIndex = index / 2;
                int currentContent = index % 2;
                string content = null;

                if (currentIndex >= strs.Count)
                {
                    index = 0;
                    currentIndex = 0;
                    currentContent = 0;
                    bubbleIndex = 0;
                }

                content = currentContent == 0 ? NpcTpl.loopStrList[currentIndex].content1 : NpcTpl.loopStrList[currentIndex].content2;
                if (!string.IsNullOrEmpty(content))
                {
                    bubbleIndex = 2 * currentIndex + currentContent;
                    return content;
                }
               index++;
               loopTime++;
                
            }

            return "";
        }

        #endregion

        public void ShowSelectedEffect()
        {
            if (ZoneModel.ins.selectedEffect == null)
            {
                ZoneModel.ins.selectedEffect = SourceManager.Ins.createObjectFromAssetBundle(PathUtil.Ins.GetEffectPath("common_SelectedEffect"));
                ZoneModel.ins.selectedEffect.layer = mDisplayModelContainer.layer;
            }

            if (ZoneModel.ins.selectedEffect.activeSelf)
            {
                ZoneModel.ins.selectedEffect.SetActive(false);
            }

            if (ZoneModel.ins.selectedEffect.transform.parent != mDisplayModelContainer.transform)
            {
                ZoneModel.ins.selectedEffect.transform.SetParent(mDisplayModelContainer.transform);
                ZoneModel.ins.selectedEffect.transform.localPosition = Vector3.zero;
            }

            ZoneModel.ins.selectedEffect.SetActive(true);
        }

        public override string[] GetDisplayModelPath()
        {
            return PathUtil.Ins.GetCharacterDisplayModelPath(this.displayModelId, m_IsNeedDependence);
        }

        public override void Destroy()
        {
            if (ZoneModel.ins.selectedEffect != null && 
                ZoneModel.ins.selectedEffect.transform.parent == mDisplayModelContainer.transform)
            {
                ZoneModel.ins.selectedEffect.transform.SetParent(app.main.GameClient.ins.cachedDisplayModels.transform);
                ZoneModel.ins.selectedEffect.SetActive(false);
            }
            base.Destroy();
            if (bubbleTimer != null)
            {
                bubbleTimer.stop();
                bubbleTimer = null;
            }

        }
    }
}

