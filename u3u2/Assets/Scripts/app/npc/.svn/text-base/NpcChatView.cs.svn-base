using System.Collections.Generic;
using System.Linq;
using app.baotu;
using app.chubao;
using app.db;
using app.human;
using app.model;
using app.net;
using app.state;
using app.yunliang;
using app.zone;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using app.jiuguan;
using app.avatar;
using app.tongtianta;

namespace app.npc
{
    public class NpcChatView : BaseWnd
    {
        //[Inject(ui = "NpcChatUI")]
        //public GameObject ui;

        private static NpcChatView _ins;

        public NpcChatUI UI;

        public ZoneNPC npcdata;

        public List<GameUUButton> doThingsBtnList;

        private GameUUButton battleBtn;

        private List<int> openedFuncList;

        public FunctionModel functionModel;
        public QuestModel questModel;

        public GameObject npcAvatarModel;
        private Vector3 mNpcAvatarModelOrgScale;
        public GameObject roleAvatarModel;
        private Vector3 mRoleAvatarModelOrgScale;

        //当前的npc模板id
        private NpcInfoData currentNpcInfoData = null;
        private StoryTemplate currentStoryTpl = null;
        //true:left;;false:right
        private bool leftOrRightView = true;
        //是否为剧情
        private bool _isJuQing = false;

        private bool mIsLoading2dNpcAvatar = false;
        private bool mIsLoading2dRoleAvatar = false;

        private string m2dNpcAvatarPath = null;
        private string m2dRoleAvatarPath = null;
        private Dictionary<int, GameUUButton> funcButtonDic;
        //测试用
        private List<string> all2dNpcName;
        //测试用
        private int currentShow2dNpcIndex=0;

        public NpcChatView()
        {
            useTween = false;
            bgMaskAlpha = 0;
            uiName = "NpcChatUI";
            avatarRotatable = false;
            avatarPlayAnim = false;
            functionModel = FunctionModel.Ins;
            questModel = QuestModel.Ins;

            all2dNpcName = new List<string>() {
                "baihutang",
                "baiwuchang",
                "bingxuejuren",
                "cangkulaoban",
                "caoxue",
                "chongwuxianzi",
                "dianxiaoer",
                "dujiaoshou",
                "heiqianxie",
                "hetongwang",
                "hongniang",
                "huamei",
                "huangyifan",
                "huayao",
                "kongyishi",
                "laofuzi",
                "linyayi",
                "linyuanshan",
                "litianxiong",
                "liudabo",
                "lvyexianzong",
                "mantianxia",
                "mentu",
                "mihundeng",
                "mojundujun",
                "mojunzhanshi",
                "monv",
                "niren",
                "qiannanshan",
                "qinglongtang",
                "ruohua",
                "shuibinxie",
                "shuimei",
                "taohuaxianzi",
                "tujing",
                "xianguan",
                "xuanwutang",
                "yemao",
                "yuehaishuiyao",
                "zhongkui",
                "zhuquetang",
                };
            //all2dNpcName.Add("nvcike");
            //all2dNpcName.Add("nancike");
            //all2dNpcName.Add("nvxiake");
            //all2dNpcName.Add("nanxiake");
            //all2dNpcName.Add("nanshushi");
            //all2dNpcName.Add("nanxiuzhen");
            //all2dNpcName.Add("nvxiuzhen");
            //all2dNpcName.Add("nvshushi");
        }
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.POPTIPS);
        }
        */
        public static NpcChatView Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = Singleton.GetObj(typeof(NpcChatView)) as NpcChatView;
                }
                return _ins;
            }
        }

        public bool IsJuQing
        {
            get { return _isJuQing; }
            set
            {
                _isJuQing = value;
            }
        }

        public override void initUI()
        {
            base.initUI();
            UI = ui.AddComponent<NpcChatUI>();
            UI.Init();
            UI.defaultBtn.gameObject.SetActive(false);
            UI.doThings.gameObject.SetActive(false);
            UI.leftNpcBodyRTF.gameObject.SetActive(false);
            UI.rightNpcBodyRTF.gameObject.SetActive(false);

            UI.tiaoguoJuqing.SetClickCallBack(clickTiaoGuoJuQing);

            UI.tiaoguoJuqing.gameObject.SetActive(false);
            //EventTriggerListener.Get(UI.juqingContainer).onClick = clickJuQingContainer;
            EventCore.addRMetaEventListener(JuQingManager.PLAY_JUQING_EVENT, playJuQing);
            EventCore.addRMetaEventListener(JuQingManager.END_JUQING_EVENT, endJuQing);
        }

        /*
        private void ResetPartsPos()
        {
            UI.chatContainer.transform.localPosition = new Vector3(0, -260 - 320, 0);
            UI.leftNpcBodyRTF.localPosition = new Vector3(-380 - 480, -320, 0);
            UI.rightNpcBodyRTF.localPosition = new Vector3(380 + 480, -320, 0);
            UI.doThings.transform.localPosition = new Vector3(270 + 506 - 26, 213 - 320, 0);
        }
        */

        protected override void clickSpaceArea(GameObject go)
        {
            if (!IsJuQing)
            {
                base.clickSpaceArea(go);

                AutoMaticManager.Ins.StopAutoMatic();
            }
            else
            {
                //剧情下一步
                JuQingManager.Ins.PlayNextJuQing();
            }
        }

        public void showNpcChat(NpcInfoData npcInfodata)
        {
            IsJuQing = false;
            currentNpcInfoData = npcInfodata;
            npcdata = ZoneNPCManager.Ins.GetNpc(currentNpcInfoData.npcId, currentNpcInfoData.uuid);
            GenericFuncList();
            if (CheckAutoCommit())
            {
                /*
                if (npcdata != null && npcdata.displayModel != null && npcdata.displayModel.avatar != null)
                {
                    npcdata.displayModel.avatar.transform.DOLocalRotate(Vector3.zero, 0.2f).SetDelay(0.2f);
                }
                ZoneCharacter self = ZoneCharacterManager.ins.self;
                if (self != null && self.displayModelForLoc != null && self.displayModelForLoc.avatar != null)
                {
                    ZoneCharacterManager.ins.self.displayModelForLoc.avatar.transform.DOLocalRotate(Vector3.zero, 0.2f).SetDelay(0.2f);
                }
                */
                return;
            }
            WndManager.open(GlobalConstDefine.NpcChatView_Name);
        }

        /// <summary>
        /// 设置npc数据
        /// </summary>
        /// <param name="npcid"></param>
        private void SetData(NpcInfoData npcinfodata)
        {
            /*
            if (npcAvatarModel != null)
            {
                if (npcdata != null)
                {
                    //npcdata.NpcTpl.model2DId
                    SourceManager.Ins.removeReference(PathUtil.Ins.GetSpineNPCDisplayModelPath(npcdata.NpcTpl.model2DId), npcAvatarModel);
                }
                else
                {
                    GameObject.DestroyImmediate(npcAvatarModel, true);
                }
                npcAvatarModel = null;
            }
            */
            //设置数据
            //npcdata = ZoneNPCManager.Ins.GetNpc(npcinfodata.npcId, npcinfodata.uuid);
            //npc名字
            UI.NpcNameText.text = npcdata.NpcTpl.name;
            //控制显示
            UI.leftNpcChatText.gameObject.SetActive(leftOrRightView);
            UI.rightNpcChatText.gameObject.SetActive(!leftOrRightView);
            if (leftOrRightView)
            {
                //npc对话
                UI.leftNpcChatText.text = npcdata.NpcTpl.talk;
            }
            else
            {
                //npc对话
                UI.rightNpcChatText.text = npcdata.NpcTpl.talk;
            }
            if (!IsJuQing)
            {
                //npc动画
                //npcdata.NpcTpl.model2DId
                if (m2dNpcAvatarPath != null)
                {
                    SourceManager.Ins.removeReference(m2dNpcAvatarPath, npcAvatarModel);
                    npcAvatarModel = null;
                }

                if (m2dRoleAvatarPath != null)
                {
                    SourceManager.Ins.removeReference(m2dRoleAvatarPath);
                }
                if (roleAvatarModel!=null) GameObject.DestroyImmediate(roleAvatarModel, true);
                    roleAvatarModel = null;
                //3D模型
                List<string> pathArr = PathUtil.Ins.GetCharacterDisplayModelPath(npcdata.NpcTpl.model3DId).ToList();
                m2dNpcAvatarPath = pathArr[1];
                //2DSpine模型
                //m2dNpcAvatarPath = PathUtil.Ins.GetSpineNPCDisplayModelPath(npcdata.NpcTpl.model2DId);
                ////测试开始
                //List<string> pathArr = PathUtil.Ins.GetCharacterDisplayModelPath(all2dNpcName[currentShow2dNpcIndex].Trim()).ToList();
                //m2dNpcAvatarPath = pathArr[1];
                //currentShow2dNpcIndex = (currentShow2dNpcIndex + 1) % all2dNpcName.Count;
                ////测试结束
                if (m2dNpcAvatarPath != null)
                {
                    mIsLoading2dNpcAvatar = true;
                    //3D模型
                    int len = pathArr.Count;
                    List<object[]> kvList = new List<object[]>();
                    for (int i = 0; i < len; i++)
                    {
                        if (!SourceManager.Ins.hasAssetBundle(pathArr[i]))
                        {
                            kvList.Add(new object[] { pathArr[i], LoadArgs.SLIMABLE, LoadContentType.ABL });
                        }
                    }
                    if (kvList.Count > 0)
                    {
                        SourceLoader.Ins.loadList(kvList, load2dNpcAvatarComplete);
                    }
                    else
                    {
                        load2dNpcAvatarComplete();
                    }
                    //2DSpine模型
                    //SourceLoader.Ins.load(m2dNpcAvatarPath, load2dNpcAvatarComplete);
                }

                //RemoveAvatarModel();
                UpdateButtonList();
            }
            else
            {
                UI.doThings.gameObject.SetActive(false);
            }
            //UI.chatContainer.GetComponent<RectTransform>().DOLocalMove(UI.chatContainerTargetPos.localPosition, 0.2f);
            //UI.doThings.GetComponent<RectTransform>().DOLocalMove(UI.doThingsTargetPos.localPosition, 0.2f);
            //UI.chatContainer.transform.localPosition = UI.chatContainerTargetPos.localPosition;
            //UI.doThings.transform.localPosition = UI.doThingsTargetPos.localPosition;
        }

        /// <summary>
        /// 模型加载完毕
        /// </summary>
        /// <param name="e"></param>
        private void load2dNpcAvatarComplete(RMetaEvent e = null)
        {
            if (isHidden)
            {
                return;
            }

            mIsLoading2dNpcAvatar = false;
            /*
            if (npcdata == null)
            {
                return;
            }
            */
            if (e==null||(e!=null&&e.type == SourceLoader.LOAD_COMPLETE))
            {
                UI.leftNpcBodyRTF.gameObject.SetActive(leftOrRightView);
                UI.rightNpcBodyRTF.gameObject.SetActive(!leftOrRightView);

                //UI.leftNpcBodyRTF.gameObject.SetActive(true);
                //npcdata.NpcTpl.model2DId
                if (npcAvatarModel != null)
                {
                    //if (npcdata != null)
                    //{
                    //npcdata.NpcTpl.model2DId
                    //SourceManager.Ins.removeReference(m2dNpcAvatarPath, npcAvatarModel);
                    //}
                    //else
                    //{
                    GameObject.DestroyImmediate(npcAvatarModel, true);
                    npcAvatarModel = null;
                    //}
                }
                if (m2dNpcAvatarPath != null)
                {
                    npcAvatarModel = SourceManager.Ins.createObjectFromAssetBundle(m2dNpcAvatarPath);
                    mNpcAvatarModelOrgScale = npcAvatarModel.transform.localScale;
                    RectTransform rtf = npcAvatarModel.AddComponent<RectTransform>();
                    if (leftOrRightView)
                    {
                        npcAvatarModel.transform.SetParent(UI.leftNpcBodyRTF.transform);
                        //UI.leftNpcBodyRTF.GetComponent<RectTransform>().DOLocalMove(UI.leftNpcBodyTargetPos.localPosition, 0.2f);
                        //UI.leftNpcBodyRTF.transform.localPosition = UI.leftNpcBodyTargetPos.localPosition;
                        //npcAvatarModel.transform.localScale = npcAvatarModel.transform.localScale * 100;
                    }
                    else
                    {
                        npcAvatarModel.transform.SetParent(UI.rightNpcBodyRTF.transform);
                        //UI.rightNpcBodyRTF.GetComponent<RectTransform>().DOLocalMove(UI.rightNpcBodyTargetPos.localPosition, 0.2f);
                        //UI.rightNpcBodyRTF.transform.localPosition = UI.rightNpcBodyTargetPos.localPosition;
                    }
                    //3D模型
                    npcAvatarModel.transform.localScale = mNpcAvatarModelOrgScale * 150;
                    rtf.sizeDelta = Vector2.one;
                    rtf.anchorMax = Vector2.one * 0.5f;
                    rtf.anchorMin = Vector2.one * 0.5f;
                    rtf.pivot = Vector2.one * 0.5f;
                    rtf.anchoredPosition3D = new Vector3(0, -120, -300);
                    rtf.rotation = new Quaternion(0,180,0,0);
                    //2DSpine模型
                    //npcAvatarModel.transform.localScale = mNpcAvatarModelOrgScale * 100;
                    //rtf.sizeDelta = Vector2.one;
                    //rtf.anchorMax = Vector2.one * 0.5f;
                    //rtf.anchorMin = Vector2.one * 0.5f;
                    //rtf.pivot = Vector2.one * 0.5f;
                    //rtf.anchoredPosition3D = new Vector3(0, -170, -10);

                    changeChildLayer(npcAvatarModel, base.ui.layer);

                    npcAvatarModel.SetActive(true);
                }
            }
            else
            {
                //GameObject.DestroyImmediate(npcAvatarModel, true);
                SourceManager.Ins.removeReference(m2dNpcAvatarPath, npcAvatarModel);
                npcAvatarModel = null;
                //UI.leftNpcBodyRTF.gameObject.SetActive(false);
                //UI.rightNpcBodyRTF.gameObject.SetActive(false);
            }
        }

        private void load2dRoleAvatarComplete(RMetaEvent e = null)
        {
            if (isHidden)
            {
                return;
            }

            mIsLoading2dRoleAvatar = false;
            /*
            if (npcdata == null)
            {
                return;
            }
            */
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                UI.leftNpcBodyRTF.gameObject.SetActive(leftOrRightView);
                UI.rightNpcBodyRTF.gameObject.SetActive(!leftOrRightView);

                //UI.leftNpcBodyRTF.gameObject.SetActive(true);
                //npcdata.NpcTpl.model2DId
                if (roleAvatarModel != null)
                {
                    //if (npcdata != null)
                    //{
                    //npcdata.NpcTpl.model2DId
                    //SourceManager.Ins.removeReference(m2dNpcAvatarPath, npcAvatarModel);
                    //}
                    //else
                    //{
                    GameObject.DestroyImmediate(roleAvatarModel, true);
                    roleAvatarModel = null;
                    //}
                }
                if (m2dRoleAvatarPath != null)
                {
                    roleAvatarModel = SourceManager.Ins.createObjectFromAssetBundle(m2dRoleAvatarPath);
                    mRoleAvatarModelOrgScale = roleAvatarModel.transform.localScale;
                    RectTransform rtf = roleAvatarModel.AddComponent<RectTransform>();
                    if (leftOrRightView)
                    {
                        roleAvatarModel.transform.SetParent(UI.leftNpcBodyRTF.transform);
                        //UI.leftNpcBodyRTF.GetComponent<RectTransform>().DOLocalMove(UI.leftNpcBodyTargetPos.localPosition, 0.2f);
                        //UI.leftNpcBodyRTF.transform.localPosition = UI.leftNpcBodyTargetPos.localPosition;
                        //roleAvatarModel.transform.localScale = Vector3.one * 100;
                    }
                    else
                    {
                        roleAvatarModel.transform.SetParent(UI.rightNpcBodyRTF.transform);
                        //UI.rightNpcBodyRTF.GetComponent<RectTransform>().DOLocalMove(UI.rightNpcBodyTargetPos.localPosition, 0.2f);
                        //UI.rightNpcBodyRTF.transform.localPosition = UI.rightNpcBodyTargetPos.localPosition;
                        //roleAvatarModel.transform.localScale = Vector3.one;
                    }
                    roleAvatarModel.transform.localScale = mRoleAvatarModelOrgScale * 100;
                    rtf.sizeDelta = Vector2.one;
                    rtf.anchorMax = Vector2.one * 0.5f;
                    rtf.anchorMin = Vector2.one * 0.5f;
                    rtf.pivot = Vector2.one * 0.5f;
                    rtf.anchoredPosition3D = new Vector3(0, -170, -10);

                    changeChildLayer(roleAvatarModel, base.ui.layer);

                    roleAvatarModel.SetActive(true);
                }
            }
            else
            {
                //GameObject.DestroyImmediate(npcAvatarModel, true);
                SourceManager.Ins.removeReference(m2dRoleAvatarPath, roleAvatarModel);
                roleAvatarModel = null;
                //UI.leftNpcBodyRTF.gameObject.SetActive(false);
                //UI.rightNpcBodyRTF.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 刷新 npc上的操作列表（功能、任务列表、进入战斗等）
        /// </summary>
        private void UpdateButtonList()
        {
            #region 注释
            /*
            //是否 有正在做的酒馆任务
            bool isDoingJiuguanTask = IsDoingJiuGuanTask();
            //是否 有正在做的除暴任务
            bool isDoingChuBaoTask = IsDoingChuBaoTask();
            //是否 有正在做的宝图任务
            bool isDoingBaoTuTask = IsDoingBaoTuTask();
            //是否 有正在做的运粮任务
            bool isDoingYunLiangTask = IsDoingYunLiangTask();
            

            //组织 功能列表
            
            #region 组织 功能列表
            if (npcdata.NpcTpl.fuctionIdList != null && npcdata.NpcTpl.fuctionIdList.Count > 0)
            {
                if (openedFuncList == null)
                {
                    openedFuncList = new List<int>();
                }
                else
                {
                    openedFuncList.Clear();
                }
                for (int i = 0; i < npcdata.NpcTpl.fuctionIdList.Count; i++)
                {
                    int funcId = npcdata.NpcTpl.fuctionIdList[i];
                    if (functionModel.IsFuncOpen(funcId))
                    {
                        if (funcId == FunctionIdDef.JIUGUAN && isDoingJiuguanTask)
                        {
                            //有正在做的酒馆任务  时 ，不显示酒馆功能
                            continue;
                        }
                        if (funcId == FunctionIdDef.CHUBAOANLIANG && isDoingChuBaoTask)
                        {
                            //有正在做的除暴任务  时 ，不显示除暴功能
                            continue;
                        }
                        if (funcId == FunctionIdDef.BAOTU && isDoingBaoTuTask)
                        {
                            //有正在做的宝图任务  时 ，不显示宝图功能
                            continue;
                        }
                        if (funcId == FunctionIdDef.YUNLIANG && isDoingYunLiangTask)
                        {
                            //有正在做的运粮任务  时 ，不显示运粮功能
                            continue;
                        }
                        switch (funcId)
                        {
                            case FunctionIdDef.BPJS:
                                openedFuncList.Add(FunctionIdDef.BPJS_Enter);
                                openedFuncList.Add(FunctionIdDef.BPJS_Paihang);
                                break;
                            case FunctionIdDef.LVYEXIANZONG:
                                openedFuncList.Add(FunctionIdDef.LVYEXIANZONG_ZUDUI);
                                openedFuncList.Add(FunctionIdDef.LVYEXIANZONG_DANREN);
                                break;
                            case FunctionIdDef.SHITU:
                                openedFuncList.Add(FunctionIdDef.SHITU_JIECHU);
                                openedFuncList.Add(FunctionIdDef.SHITU_CHUSHI);
                                openedFuncList.Add(FunctionIdDef.SHITU_SHOUTU);
                                break;
                            case FunctionIdDef.HUNYIN:
                                openedFuncList.Add(FunctionIdDef.LIHUN_WE);
                                openedFuncList.Add(FunctionIdDef.JIEHUN_WE);
                                break;
                            case FunctionIdDef.CHONGWUDAO:
                                openedFuncList.Add(FunctionIdDef.CHONGWUDAO_YI);
                                openedFuncList.Add(FunctionIdDef.CHONGWUDAO_ER);
                                openedFuncList.Add(FunctionIdDef.CHONGWUDAO_SAN);
                                //openedFuncList.Add(FunctionIdDef.CHONGWUDAO_SI);
                                break;
                            default:
                                openedFuncList.Add(npcdata.NpcTpl.fuctionIdList[i]);
                                break;
                        }
                    }
                }
            }
            #endregion
            */
            #endregion

            #region 组织 按钮 列表

            if (doThingsBtnList == null)
            {
                doThingsBtnList = new List<GameUUButton>();
            }

            //功能列表 数量
            int funcCount = openedFuncList != null ? openedFuncList.Count : 0;

            if (funcCount > 0)
            {
                UI.doThings.gameObject.SetActive(true);
                if (funcButtonDic!=null)funcButtonDic.Clear();
                for (int i = 0; i < funcCount; i++)
                {
                    GameUUButton btn;
                    //GameObject btnContainer;
                    string functionName = FunctionIdDef.GetFuncNameById(openedFuncList[i]);
                    if (i < doThingsBtnList.Count)
                    {
                        btn = doThingsBtnList[i];
                        //btn = btnContainer.transform.FindChild("Button").GetComponent<GameUUButton>();
                    }
                    else
                    {
                        btn = GetOneNewButton(functionName);
                        //btn = btnContainer.transform.FindChild("Button").GetComponent<GameUUButton>();
                    }
                    btn.gameObject.SetActive(true);
                    Text txt = btn.GetComponentInChildren<Text>();
                    if (txt != null) txt.text = functionName;
                    btn.transform.SetParent(UI.doThings.transform);
                    btn.transform.localScale = Vector3.one;
                    btn.SetClickCallBack(ClickDoItButton);
                    if (funcButtonDic == null)
                    {
                        funcButtonDic = new Dictionary<int, GameUUButton>();
                    }
                    funcButtonDic.Add(openedFuncList[i], btn);
                }
            }

            //组织  任务列表
            bool hasBattleQuest = false;
            hasBattleQuest = npcdata.NpcTpl.type == (int)NPCType.FUBEN_BATTLE ? true : false;
            if (npcdata.questIdList != null && npcdata.questIdList.Count > 0)
            {
                UI.doThings.gameObject.SetActive(true);
                if (doThingsBtnList == null)
                {
                    doThingsBtnList = new List<GameUUButton>();
                }
                int index = funcCount;
                for (int i = 0; npcdata != null && npcdata.questIdList != null && i < npcdata.questIdList.Count; i++)
                {
                    QuestInfoData questData = Human.Instance.QuestModel.GetQuestInfoById(npcdata.questIdList[i]);
                    if (questData == null)
                    {
                        continue;
                    }
                    string str = "我该做点什么呢";
                    QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questData.questId);
                    NPCType npctype = (NPCType)(npcdata.NpcTpl.type);
                    if (QuestModel.IsQuestFightNpc(qt) &&
                        (npctype == NPCType.TASKTARGET_BATTLE && npcdata.NpcTpl.notShowPanelInt == 0))
                    {
                        hasBattleQuest = true;
                        //index--;
                        continue;
                    }
                    switch (questData.questStatus)
                    {
                        case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                            str = qt.title; // "接受任务" + npcdata.questIdList[i];
                            if (i == 0)
                            {
                                UI.leftNpcChatText.text = qt.desc;
                            }
                            break;
                        case (int)QuestDefine.QuestStatus.ACCEPTED:
                            str = qt.title; //"马上去做" + npcdata.questIdList[i];
                            if (i == 0)
                            {
                                UI.leftNpcChatText.text = qt.finishDesc;
                                if (IsDoingJiuGuanTask())
                                {
                                    UI.leftNpcChatText.text = "当前酒馆任务未完成且没有功能按钮";
                                }
                            }
                            break;
                        case (int)QuestDefine.QuestStatus.CAN_FINISH:
                            str = qt.title; //"去交付" + npcdata.questIdList[i];
                            if (i == 0)
                            {
                                UI.leftNpcChatText.text = qt.finishNpcTalkDesc;
                            }
                            break;
                        case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                            str = qt.title; //"不可接" + npcdata.questIdList[i].ToString();
                            if (i == 0)
                            {
                                UI.leftNpcChatText.text = qt.requireDesc;
                            }
                            break;
                    }
                    GameUUButton btn;
                    //GameObject btnContainer;
                    if (index < doThingsBtnList.Count)
                    {
                        btn = doThingsBtnList[index];
                        //btn = btnContainer.transform.FindChild("Button").GetComponent<GameUUButton>();
                    }
                    else
                    {
                        btn = GetOneNewButton(str);
                        //btn = btnContainer.transform.FindChild("Button").GetComponent<GameUUButton>();
                    }
                    btn.gameObject.SetActive(true);
                    Text txt = btn.GetComponentInChildren<Text>();
                    if (txt != null) txt.text = str;
                    btn.transform.SetParent(UI.doThings.transform);
                    btn.transform.localScale = Vector3.one;
                    btn.SetClickCallBack(ClickDoItButton);
                    index++;
                    /*
                    if (questModel.AutoQuestId != 0 &&
                        questModel.AutoQuestId == npcdata.questIdList[i]
                        && questData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
                    {
                        //qt.questType == (int)QuestDefine.QuestType.JIUGUAN ||
                        if ((qt.questType == (int)QuestDefine.QuestType.CHUBAOANLIANG || qt.questType == (int)QuestDefine.QuestType.BAOTU))
                        {
                            //正在自动做 酒馆、除暴、宝图 任务，帮玩家点击 交付任务 按钮
                            ClickDoItButton(btn.gameObject);
                            return;
                        }
                    }
                    if (qt.questType == (int)QuestDefine.QuestType.MAIN && questData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
                    {
                        //主线任务自动提交
                        ClickDoItButton(btn.gameObject);
                        return;
                    }
                    */
                }
            }
            #endregion 

            #region 销毁多余的按钮
            //任务列表 数量
            int questCount = npcdata.questIdList != null ? npcdata.questIdList.Count : 0;
            if (doThingsBtnList.Count > questCount + funcCount)
            {
                //销毁多余的按钮
                for (int i = questCount + funcCount; i < doThingsBtnList.Count; i++)
                {
                    GameObject.DestroyImmediate(doThingsBtnList[i].gameObject, true);
                    doThingsBtnList[i] = null;
                }
                doThingsBtnList.RemoveRange(questCount + funcCount, doThingsBtnList.Count - (questCount + funcCount));
            }
            #endregion

            #region 进入战斗按钮

            //添加进入战斗按钮
            if (hasBattleQuest && TongTianTaModel.ins.IsNpcShowBattle(npcdata.NpcInfoData.npcId))
            {//添加进入战斗按钮
                UI.doThings.gameObject.SetActive(true);
                if (battleBtn == null)
                {
                    battleBtn = GetOneNewButton("进入战斗");
                }
                battleBtn.gameObject.SetActive(true);
                //GameUUButton jinruzhandouBtn = jinrizhandouBtnContainer.transform.FindChild("Button").GetComponent<GameUUButton>();
                battleBtn.transform.SetParent(UI.doThings.transform);
                battleBtn.transform.localScale = Vector3.one;
                Text txt = battleBtn.GetComponentInChildren<Text>();
                if (txt != null) txt.text = "进入战斗";
                battleBtn.SetClickCallBack(ClickEnterBattle);
                /*
                if (questModel.AutoQuestId != 0)
                {
                    QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questModel.AutoQuestId);
                    QuestInfoData qdata = questModel.GetQuestInfoById(questModel.AutoQuestId);

                    if (qt != null && qdata != null &&
                        (qt.questType == (int)QuestDefine.QuestType.JIUGUAN || qt.questType == (int)QuestDefine.QuestType.CHUBAOANLIANG || qt.questType == (int)QuestDefine.QuestType.BAOTU || qt.questType == (int)QuestDefine.QuestType.YUNLIANG
                        ||qt.questType == (int)QuestDefine.QuestType.BANGPAI)
                        && qdata.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED)
                    {
                        //正在自动做酒馆、除暴、宝图 任务，帮玩家点击 进入战斗按钮
                        ClickEnterBattle(jinruzhandouBtn.gameObject);
                    }
                }
                */
            }
            else
            {
                if (battleBtn != null)
                {
                    battleBtn.gameObject.SetActive(false);
                    GameObject.DestroyImmediate(battleBtn.gameObject, true);
                    battleBtn = null;
                }
            }
            #endregion

        }

        private void ClickEnterBattle(GameObject go)
        {
            MapCGHandler.sendCGMapFightNpc(npcdata.NpcTplId, npcdata.NpcInfoData.uuid);
            hide();
        }

        private void ClickDoItButton(GameObject btnGo)
        {
            GameUUButton btn = btnGo.GetComponent<GameUUButton>();
            if (btn == null)
            {
                ClientLog.Log("点击的按钮为空！");
                return;
            }
            int index = doThingsBtnList.IndexOf(btn);
            if (index == -1)
            {
                ClientLog.Log("doThingsButtonList中无此按钮" + btn.name);
                return;
            }

            DoFunc(index);

            if (isShown)
            {
                hide();
            }
        }

        private void DoFunc(int index)
        {
            int funccount = openedFuncList != null ? openedFuncList.Count : 0;
            if (index < funccount)
            {
                //点击的功能按钮
                LinkParse.Ins.linkToFunc(openedFuncList[index]);
                switch (openedFuncList[index])
                {
                    case FunctionIdDef.LVYEXIANZONG:
                    case FunctionIdDef.LVYEXIANZONG_DANREN:
                    case FunctionIdDef.LVYEXIANZONG_ZUDUI:
                        GuideManager.Ins.RemoveGuide(GuideIdDef.LvYeXianZong);
                        break;
                    case FunctionIdDef.JIUGUAN:
                        GuideManager.Ins.RemoveGuide(GuideIdDef.JiuGuan);
                        break;
                    case FunctionIdDef.BAOTU:
                        GuideManager.Ins.RemoveGuide(GuideIdDef.CangBaoTu);
                        break;
                    case FunctionIdDef.YUNLIANG:
                        GuideManager.Ins.RemoveGuide(GuideIdDef.YunLiang);
                        break;
                    case FunctionIdDef.CHUBAOANLIANG:
                        GuideManager.Ins.RemoveGuide(GuideIdDef.ChuBao);
                        break;
                }
            }
            else if (index - funccount < npcdata.questIdList.Count)
            {
                //点击的任务
                int questId = npcdata.questIdList[index - funccount];

                QuestInfoData questData = Human.Instance.QuestModel.GetQuestInfoById(questId);
                QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questId);
                if (questData != null)
                {
                    switch (questData.questStatus)
                    {
                        case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                            //str = "接受任务" + npcdata.questIdList[i];
                            if (qt.questType == (int)QuestDefine.QuestType.JIUGUAN)
                            {
                                PubtaskCGHandler.sendCGPubtaskAccept(questId);
                            }
                            else if (qt.questType == (int)QuestDefine.QuestType.YUNLIANG)
                            {
                                ForagetaskCGHandler.sendCGForagetaskAccept(questId);
                            }
                            else if (qt.questType == (int)QuestDefine.QuestType.BANGPAI)
                            {
                                CorpstaskCGHandler.sendCGCorpstaskAccept();
                            }
                            else if (qt.questType == (int)QuestDefine.QuestType.HUAN)
                            {
                                //接受环任务
                                RingtaskCGHandler.sendCGRingtaskAccept();
                            }
                            else
                            {
                                QuestCGHandler.sendCGAcceptQuest(questId);
                            }
                            break;
                        case (int)QuestDefine.QuestStatus.ACCEPTED:
                            //str = "马上去做" + npcdata.questIdList[i];
                            questModel.StartAutoQuest(questData);
                            break;
                        case (int)QuestDefine.QuestStatus.CAN_FINISH:
                            //str = "去交付" + npcdata.questIdList[i];
                            if (qt.questType == (int)QuestDefine.QuestType.JIUGUAN)
                            {
                                PubtaskCGHandler.sendCGFinishPubtask();
                                //停止自动寻路
                                AutoMaticManager.Ins.StopAutoMatic();
                            }
                            else if (qt.questType == (int)QuestDefine.QuestType.YUNLIANG)
                            {
                                ForagetaskCGHandler.sendCGFinishForagetask();
                            }
                            else if (qt.questType == (int)QuestDefine.QuestType.CHUBAOANLIANG)
                            {
                                ThesweeneytaskCGHandler.sendCGFinishThesweeneytask();
                            }
                            else if (qt.questType == (int)QuestDefine.QuestType.BAOTU)
                            {
                                TreasuremapCGHandler.sendCGFinishTreasuremap();
                            }
                            else if (qt.questType == (int)QuestDefine.QuestType.BANGPAI)
                            {
                                CorpstaskCGHandler.sendCGFinishCorpstask();
                            }
                            else if(qt.questType == (int)QuestDefine.QuestType.XIANSHISHAGUAI)
                            {
                                TimelimitCGHandler.sendCGFinishTlMonster();
                            }
                            else if(qt.questType == (int)QuestDefine.QuestType.XIANSHINPC)
                            {
                                TimelimitCGHandler.sendCGFinishTlNpc();
                            }
                            else if (qt.questType == (int)QuestDefine.QuestType.QIRIMUBIAO)
                            {
                                HumanCGHandler.sendCGDay7TaskFinish(questId);
                            }
                            else if (qt.questType == (int)QuestDefine.QuestType.HUAN)
                            {
                                //完成环任务
                                RingtaskCGHandler.sendCGFinishRingtask();
                            }
                            else
                            {
                                QuestCGHandler.sendCGFinishQuest(questId);
                            }
                            break;
                        case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                            //str = "不可接" + npcdata.questIdList[i].ToString();
                            break;
                    }
                }
            }
        }

        private GameUUButton GetOneNewButton(string str)
        {
            GameUUButton btn = GameObject.Instantiate(UI.defaultBtn);
            doThingsBtnList.Add(btn);
            return btn;
        }

        public override void hide(RMetaEvent e = null)
        {
            if (UI != null && UI.doThings != null) UI.doThings.gameObject.SetActive(false);

            if (doThingsBtnList != null)
            {
                for (int i = 0; i < doThingsBtnList.Count; i++)
                {
                    //doThingsBtnList[i].gameObject.SetActive(false);
                    GameObject.DestroyImmediate(doThingsBtnList[i].gameObject, true);
                    doThingsBtnList[i] = null;
                }
                doThingsBtnList.Clear();
            }
            //npcdata.displayModel.avatar.transform.localEulerAngles = Vector3.zero;
            if (m2dNpcAvatarPath != null)
            {
                if (SourceManager.Ins != null) SourceManager.Ins.removeReference(m2dNpcAvatarPath, npcAvatarModel);
                m2dNpcAvatarPath = null;
            }
            else
            {
                GameObject.DestroyImmediate(npcAvatarModel, true);
            }

            npcAvatarModel = null;

            if (m2dRoleAvatarPath != null)
            {
                if (SourceManager.Ins != null) SourceManager.Ins.removeReference(m2dRoleAvatarPath);
                m2dRoleAvatarPath = null;
            }
            if (roleAvatarModel!=null) GameObject.DestroyImmediate(roleAvatarModel, true);
            roleAvatarModel = null;

            if (npcdata != null && npcdata.displayModel != null && npcdata.displayModel.avatar != null)
            {
                npcdata.displayModel.avatar.transform.DOLocalRotate(Vector3.zero, 0.2f);
            }

            ZoneCharacter self = ZoneCharacterManager.ins.self;
            /*
            if (self != null && self.displayModel != null && self.displayModel.avatar != null)
            {
                ZoneCharacterManager.ins.self.displayModel.avatar.transform.DOLocalRotate(Vector3.zero, 0.2f);
            }
            */
            if (self.displayModelForLoc != null && self.displayModelForLoc.avatar != null)
            {
                self.displayModelForLoc.avatar.transform.DOLocalRotate(Vector3.zero, 0.2f);
            }

            if (!IsJuQing)
            {
                ZoneUI.ins.UI.questUI.gameObject.SetActive(true);
                ZoneUI.ins.UI.mainuiButton.gameObject.SetActive(true);
                if (ZoneUI.ins.ChatView.isShowing)
                {
                    ZoneUI.ins.UI.chatPanelUI.gameObject.SetActive(true);
                }
                else
                {
                    ZoneUI.ins.UI.chatUI.gameObject.SetActive(true);
                }
                if (currentNpcInfoData != null)
                {
                    NpcTemplate npctpl = NpcTemplateDB.Instance.getTemplate(currentNpcInfoData.npcId);
                    AudioManager.Ins.StopAudio(npctpl.musicId, AudioEnumType.NPC);
                }
            }

            npcdata = null;
            mIsLoading2dNpcAvatar = false;
            currentNpcInfoData = null;
            currentStoryTpl = null;
            IsJuQing = false;
            base.hide(e);
            if (UI != null)
            {
                UI.Hide();
            }
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            NpcPlayerLookAtEachOther();

            //ResetPartsPos();

            if (IsJuQing)
            {
                UI.tiaoguoJuqing.gameObject.SetActive(true);
                UI.doThings.gameObject.SetActive(false);
                leftOrRightView = false;
                playJuQing(new RMetaEvent(JuQingManager.PLAY_JUQING_EVENT, currentStoryTpl));
            }
            else
            {
                UI.tiaoguoJuqing.gameObject.SetActive(false);
                //UI.doThings.gameObject.SetActive(true);
                leftOrRightView = true;

                if (currentNpcInfoData != null)
                {
                    SetData(currentNpcInfoData);
                    if (openedFuncList.Contains(FunctionIdDef.LVYEXIANZONG_DANREN))
                    {
                        GuideManager.Ins.ShowGuide(GuideIdDef.LvYeXianZong, 3, UI.doThings.transform.gameObject, Vector3.zero, new Vector3(18, -18, 0), Vector3.zero, Vector2.zero, false, 200);
                    }
                    if (openedFuncList.Contains(FunctionIdDef.JIUGUAN)&&funcButtonDic!=null&&funcButtonDic.ContainsKey(FunctionIdDef.JIUGUAN))
                    {
                        GuideManager.Ins.ShowGuide(GuideIdDef.JiuGuan, 3, funcButtonDic[FunctionIdDef.JIUGUAN].gameObject, Vector3.zero, Vector3.zero, Vector3.zero, Vector2.zero, false, 200);
                    }else if (GuideManager.Ins.CurrentGuideId==GuideIdDef.JiuGuan)
                    {//有引导但是没有对应的功能按钮，结束引导
                        GuideManager.Ins.RemoveGuide(GuideIdDef.JiuGuan);
                    }
                    if (openedFuncList.Contains(FunctionIdDef.BAOTU) && funcButtonDic != null && funcButtonDic.ContainsKey(FunctionIdDef.BAOTU))
                    {
                        GuideManager.Ins.ShowGuide(GuideIdDef.CangBaoTu, 3, funcButtonDic[FunctionIdDef.BAOTU].gameObject, Vector3.zero, Vector3.zero, Vector3.zero, Vector2.zero, false, 200);
                    }
                    else if (GuideManager.Ins.CurrentGuideId == GuideIdDef.CangBaoTu)
                    {//有引导但是没有对应的功能按钮，结束引导
                        GuideManager.Ins.RemoveGuide(GuideIdDef.CangBaoTu);
                    }
                    if (openedFuncList.Contains(FunctionIdDef.YUNLIANG) && funcButtonDic != null && funcButtonDic.ContainsKey(FunctionIdDef.YUNLIANG))
                    {
                        GuideManager.Ins.ShowGuide(GuideIdDef.YunLiang, 3, funcButtonDic[FunctionIdDef.YUNLIANG].gameObject, Vector3.zero, Vector3.zero, Vector3.zero, Vector2.zero, false, 200);
                    }
                    else if (GuideManager.Ins.CurrentGuideId == GuideIdDef.YunLiang)
                    {//有引导但是没有对应的功能按钮，结束引导
                        GuideManager.Ins.RemoveGuide(GuideIdDef.YunLiang);
                    }
                    if (openedFuncList.Contains(FunctionIdDef.CHUBAOANLIANG) && funcButtonDic != null && funcButtonDic.ContainsKey(FunctionIdDef.CHUBAOANLIANG))
                    {
                        GuideManager.Ins.ShowGuide(GuideIdDef.ChuBao, 3, funcButtonDic[FunctionIdDef.CHUBAOANLIANG].gameObject, Vector3.zero, Vector3.zero, Vector3.zero, Vector2.zero, false, 200);
                    }
                    else if (GuideManager.Ins.CurrentGuideId == GuideIdDef.ChuBao)
                    {//有引导但是没有对应的功能按钮，结束引导
                        GuideManager.Ins.RemoveGuide(GuideIdDef.ChuBao);
                    }
                    //播放npc的说话
                    NpcTemplate npctpl = NpcTemplateDB.Instance.getTemplate(currentNpcInfoData.npcId);
                    AudioManager.Ins.PlayAudio(npctpl.musicId, AudioEnumType.NPC);
                }

                ZoneUI.ins.UI.questUI.gameObject.SetActive(false);
                ZoneUI.ins.UI.mainuiButton.gameObject.SetActive(false);
                if (ZoneUI.ins.ChatView.isShowing)
                {
                    ZoneUI.ins.UI.chatPanelUI.gameObject.SetActive(false);
                }
                else
                {
                    ZoneUI.ins.UI.chatUI.gameObject.SetActive(false);
                }
            }
        }

        private void NpcPlayerLookAtEachOther()
        {
            if (npcdata!=null&&npcdata.displayModel != null && npcdata.displayModel.avatar != null)
            {
                Vector3 npcLoc = npcdata.displayModel.avatar.transform.position;
                ZoneCharacter self = ZoneCharacterManager.ins.self;
                if (self != null)
                {
                    AvatarDisplayCache selfDisplay = self.displayModelForLoc;
                    if (selfDisplay != null && selfDisplay.avatar != null)
                    {
                        Vector3 selfLoc = selfDisplay.avatar.transform.position;
                        if (selfLoc.x != npcLoc.x || selfLoc.z != npcLoc.z)
                        {
                            npcdata.displayModel.avatar.transform.DOLookAt(new Vector3(selfLoc.x, npcLoc.y, selfLoc.z), 0.2f);
                            selfDisplay.avatar.transform.DOLookAt(new Vector3(npcLoc.x, selfLoc.y, npcLoc.z), 0.2f);
                        }
                    }
                }
            }
        }

        #region 是否正在自动做任务

        private bool IsDoingJiuGuanTask()
        {
            bool isDoingJiuguanTask = false;
            QuestInfoData jiuguanQuestData = JiuGuanRenWuModel.Ins.currentQuestData;
            if (jiuguanQuestData != null &&
                ((jiuguanQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED) ||
                (jiuguanQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)))
            {
                //有正在做的酒馆任务
                isDoingJiuguanTask = true;
            }
            return isDoingJiuguanTask;
        }

        private bool IsDoingChuBaoTask()
        {
            bool isDoingChuBaoTask = false;
            QuestInfoData chubaoQuestData = ChuBaoModel.Ins.currentQuestData;
            if (chubaoQuestData != null &&
                ((chubaoQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED) ||
                (chubaoQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)))
            {
                //有正在做的酒馆任务
                isDoingChuBaoTask = true;
            }
            return isDoingChuBaoTask;
        }

        private bool IsDoingBaoTuTask()
        {
            bool isDoingBaoTuTask = false;
            QuestInfoData baotuQuestData = BaoTuModel.Ins.currentQuestData;
            if (baotuQuestData != null &&
                ((baotuQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED) ||
                (baotuQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)))
            {
                //有正在做的宝图任务
                isDoingBaoTuTask = true;
            }
            return isDoingBaoTuTask;
        }

        private bool IsDoingYunLiangTask()
        {
            bool isDoingYunLiangTask = false;
            QuestInfoData yunliangQuestData = YunLiangModel.Ins.currentQuestData;
            if (yunliangQuestData != null &&
                ((yunliangQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED) ||
                (yunliangQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)))
            {
                //有正在做的宝图任务
                isDoingYunLiangTask = true;
            }
            return isDoingYunLiangTask;
        }

        private bool IsDoingBangpaiTask()
        {
            bool isDoingBangPaiTask = false;
            QuestInfoData bangpaiQuestInfo = null;
            if (CorpsTaskModel.instance.corpsTaskUpdate != null)
            {
                bangpaiQuestInfo = CorpsTaskModel.instance.corpsTaskUpdate.getQuestInfo();
            }
            if (bangpaiQuestInfo != null &&
                ((bangpaiQuestInfo.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED) ||
                (bangpaiQuestInfo.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)))
            {
                //有正在做的宝图任务
                isDoingBangPaiTask = true;
            }
            return isDoingBangPaiTask;
        }

        #endregion


        #region 剧情部分
        private void playJuQing(RMetaEvent e)
        {
            currentStoryTpl = e.data as StoryTemplate;
            if (currentStoryTpl != null && npcdata != null)
            {
                leftOrRightView = (currentStoryTpl.isNpc == 1);
                //npc名字
                UI.NpcNameText.text = leftOrRightView ? npcdata.NpcTpl.name : Human.Instance.getName();

                //控制显示
                UI.leftNpcChatText.gameObject.SetActive(leftOrRightView);
                UI.rightNpcChatText.gameObject.SetActive(!leftOrRightView);
                UI.leftNpcBodyRTF.gameObject.SetActive(leftOrRightView);
                UI.rightNpcBodyRTF.gameObject.SetActive(!leftOrRightView);

                if (leftOrRightView)
                {
                    //对话
                    UI.leftNpcChatText.text = currentStoryTpl.content;
                }
                else
                {
                    //对话
                    UI.rightNpcChatText.text = currentStoryTpl.content;
                }
                //npc动画
                if (currentStoryTpl.isNpc == 1)
                {
                    if (m2dNpcAvatarPath == null && !mIsLoading2dNpcAvatar)
                    {
                        //2Dspine模型
                        //m2dNpcAvatarPath = PathUtil.Ins.GetSpineNPCDisplayModelPath(npcdata.NpcTpl.model2DId);

                        //3D模型
                        List<string> pathArr = PathUtil.Ins.GetCharacterDisplayModelPath(npcdata.NpcTpl.model3DId).ToList();
                        m2dNpcAvatarPath = pathArr[1];

                        if (m2dNpcAvatarPath != null)
                        {
                            mIsLoading2dNpcAvatar = true;
                            //3D模型
                            int len = pathArr.Count;
                            List<object[]> kvList = new List<object[]>();
                            for (int i = 0; i < len; i++)
                            {
                                if (!SourceManager.Ins.hasAssetBundle(pathArr[i]))
                                {
                                    kvList.Add(new object[] { pathArr[i], LoadArgs.SLIMABLE, LoadContentType.ABL });
                                }
                            }
                            if (kvList.Count > 0)
                            {
                                SourceLoader.Ins.loadList(kvList, load2dNpcAvatarComplete);
                            }
                            else
                            {
                                load2dNpcAvatarComplete();
                            }
                            //2DSpine模型
                            //SourceLoader.Ins.load(m2dNpcAvatarPath, load2dNpcAvatarComplete);
                        }
                    }
                    //RemoveAvatarModel();
                }
                else
                {
                    //UI.leftNpcBodyRTF.gameObject.SetActive(leftOrRightView);
                    //UI.rightNpcBodyRTF.gameObject.SetActive(!leftOrRightView);
                    /*
                    if (avatarBase == null)
                    {
                        AddAvatarModelToUI(new Vector3(-1, 0.1f, -2f), new Vector3(0, 180, 0), Vector3.one,
                            Human.Instance.PetModel.getLeader().getTpl().modelId, UI.rightNpcBodyRTF.gameObject);
                        Human.Instance.updateSelfWeapon(avatarBase);
                    }
                    */
                    if (m2dRoleAvatarPath == null && !mIsLoading2dRoleAvatar)
                    {
                        m2dRoleAvatarPath = PathUtil.Ins.GetSpineNPCDisplayModelPath(Human.Instance.PetModel.getLeader().getTpl().modelId);
                        if (m2dRoleAvatarPath != null)
                        {
                            mIsLoading2dRoleAvatar = true;
                            SourceLoader.Ins.load(m2dRoleAvatarPath, load2dRoleAvatarComplete);
                        }
                    }
                }
            }
            else
            {
                //剧情数据为空
                JuQingManager.Ins.PlayNextJuQing();
            }
        }

        private void endJuQing(RMetaEvent e)
        {
            hide();
            if (StateManager.Ins.getCurState() != null && StateManager.Ins.getCurState().state == StateDef.zoneState)
            {
                ZoneUI.ins.showAll();
            }
            //IsJuQing = false;
        }
        /*
        private void clickJuQingContainer(GameObject go)
        {
            //剧情下一步
            JuQingManager.Ins.PlayNextJuQing();
        }
        */

        public void StartPlayJuQing(StoryTemplate storyTpl)
        {
            IsJuQing = true;
            currentStoryTpl = storyTpl;
            ZoneUI.ins.hideAll();
            WndManager.open(GlobalConstDefine.NpcChatView_Name);
        }

        /// <summary>
        /// 跳过剧情
        /// </summary>
        private void clickTiaoGuoJuQing()
        {
            //跳过剧情
            JuQingManager.Ins.StopJuQing();
        }
        #endregion

        private void GenericFuncList()
        {
            //是否 有正在做的酒馆任务
            bool isDoingJiuguanTask = IsDoingJiuGuanTask();
            //是否 有正在做的除暴任务
            bool isDoingChuBaoTask = IsDoingChuBaoTask();
            //是否 有正在做的宝图任务
            bool isDoingBaoTuTask = IsDoingBaoTuTask();
            //是否 有正在做的运粮任务
            bool isDoingYunLiangTask = IsDoingYunLiangTask();

            bool isdoingBangPaiTask = IsDoingBangpaiTask();

            if (npcdata != null && npcdata.NpcTpl != null && npcdata.NpcTpl.fuctionIdList != null && npcdata.NpcTpl.fuctionIdList.Count > 0)
            {
                if (openedFuncList == null)
                {
                    openedFuncList = new List<int>();
                }
                else
                {
                    openedFuncList.Clear();
                }
                for (int i = 0; i < npcdata.NpcTpl.fuctionIdList.Count; i++)
                {
                    int funcId = npcdata.NpcTpl.fuctionIdList[i];
                    if (functionModel.IsFuncOpen(funcId))
                    {
                        if (funcId == FunctionIdDef.JIUGUAN && isDoingJiuguanTask)
                        {
                            //有正在做的酒馆任务  时 ，不显示酒馆功能
                            continue;
                        }
                        if (funcId == FunctionIdDef.CHUBAOANLIANG && isDoingChuBaoTask)
                        {
                            //有正在做的除暴任务  时 ，不显示除暴功能
                            continue;
                        }
                        if (funcId == FunctionIdDef.BAOTU && isDoingBaoTuTask)
                        {
                            //有正在做的宝图任务  时 ，不显示宝图功能
                            continue;
                        }
                        if (funcId == FunctionIdDef.YUNLIANG && isDoingYunLiangTask)
                        {
                            //有正在做的运粮任务  时 ，不显示运粮功能
                            continue;
                        }

                        if (funcId == FunctionIdDef.CORPSTASK && isdoingBangPaiTask)
                        {
                            continue;
                        }


                        switch (funcId)
                        {
                            case FunctionIdDef.BPJS:
                                openedFuncList.Add(FunctionIdDef.BPJS_Enter);
                                openedFuncList.Add(FunctionIdDef.BPJS_Paihang);
                                break;
                            case FunctionIdDef.LVYEXIANZONG:
                                openedFuncList.Add(FunctionIdDef.LVYEXIANZONG_ZUDUI);
                                openedFuncList.Add(FunctionIdDef.LVYEXIANZONG_DANREN);
                                break;
                            case FunctionIdDef.SHITU:
                                openedFuncList.Add(FunctionIdDef.SHITU_JIECHU);
                                openedFuncList.Add(FunctionIdDef.SHITU_CHUSHI);
                                openedFuncList.Add(FunctionIdDef.SHITU_SHOUTU);
                                break;
                            case FunctionIdDef.HUNYIN:
                                openedFuncList.Add(FunctionIdDef.LIHUN_WE);
                                openedFuncList.Add(FunctionIdDef.JIEHUN_WE);
                                break;
                            case FunctionIdDef.CHONGWUDAO:
                                openedFuncList.Add(FunctionIdDef.CHONGWUDAO_YI);
                                openedFuncList.Add(FunctionIdDef.CHONGWUDAO_ER);
                                openedFuncList.Add(FunctionIdDef.CHONGWUDAO_SAN);
                                //openedFuncList.Add(FunctionIdDef.CHONGWUDAO_SI);
                                break;
                            case FunctionIdDef.TOWER:
                                openedFuncList.Add(FunctionIdDef.TOWER_BEAST);
                                openedFuncList.Add(FunctionIdDef.TOWER_EARLIEST);
                                break;
                            case FunctionIdDef.CORPS_BOSS:
                                openedFuncList.Add(FunctionIdDef.CORPSBOSS_CHANLLGE);
                                openedFuncList.Add(FunctionIdDef.CORPSBOSS_BEAST);
                                break;
                            default:
                                openedFuncList.Add(npcdata.NpcTpl.fuctionIdList[i]);
                                break;
                        }
                    }
                }
            }
        }

        private bool CheckAutoCommit()
        {
            if (questModel.AutoQuestId != 0)
            {
                QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questModel.AutoQuestId);
                QuestInfoData qdata = questModel.GetQuestInfoById(questModel.AutoQuestId);

                if (qt != null && qdata != null &&
                    (qt.questType == (int)QuestDefine.QuestType.JIUGUAN 
                    || qt.questType == (int)QuestDefine.QuestType.CHUBAOANLIANG 
                    || qt.questType == (int)QuestDefine.QuestType.BAOTU 
                    || qt.questType == (int)QuestDefine.QuestType.YUNLIANG
                    || qt.questType == (int)QuestDefine.QuestType.HUAN)
                    && qdata.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED)
                {
                    //正在自动做酒馆、除暴、宝图 任务，帮玩家点击 进入战斗按钮
                    ClickEnterBattle(null);
                    return true;
                }
            }

            bool hasBattleQuest = false;
            hasBattleQuest = npcdata.NpcTpl.type == (int)NPCType.FUBEN_BATTLE ? true : false;

            if (npcdata.questIdList != null && npcdata.questIdList.Count > 0)
            {
                int index = openedFuncList != null ? openedFuncList.Count : 0;

                for (int i = 0; npcdata != null && npcdata.questIdList != null && i < npcdata.questIdList.Count; i++)
                {
                    QuestInfoData questData = Human.Instance.QuestModel.GetQuestInfoById(npcdata.questIdList[i]);
                    if (questData == null)
                    {
                        continue;
                    }
                    QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(questData.questId);
                    NPCType npctype = (NPCType)(npcdata.NpcTpl.type);
                    if (QuestModel.IsQuestFightNpc(qt) &&
                        (npctype == NPCType.TASKTARGET_BATTLE && npcdata.NpcTpl.notShowPanelInt == 0))
                    {
                        hasBattleQuest = true;
                        //index--;
                        continue;
                    }

                    if (questModel.AutoQuestId != 0 &&
                        questModel.AutoQuestId == npcdata.questIdList[i]
                        && questData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
                    {
                        if ((qt.questType == (int)QuestDefine.QuestType.JIUGUAN 
                            || qt.questType == (int)QuestDefine.QuestType.CHUBAOANLIANG 
                            || qt.questType == (int)QuestDefine.QuestType.BAOTU
                            || qt.questType == (int)QuestDefine.QuestType.HUAN))
                        {
                            //正在自动做 酒馆、除暴、宝图 任务，帮玩家点击 交付任务 按钮
                            DoFunc(index);
                            return true;
                        }
                    }
                    if (qt.questType == (int)QuestDefine.QuestType.MAIN && questData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
                    {
                        //主线任务自动提交
                        DoFunc(index);
                        return true;
                    }
                    index++;
                }
            }

            return false;
        }

        public override void Destroy()
        {
            _ins = null;
            EventCore.removeRMetaEventListener(JuQingManager.PLAY_JUQING_EVENT, playJuQing);
            EventCore.removeRMetaEventListener(JuQingManager.END_JUQING_EVENT, endJuQing);
            base.Destroy();
            UI = null;
        }
    }
}