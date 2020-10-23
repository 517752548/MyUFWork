using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using app.item;
using app.pet;
using app.relation;
using app.team;
using app.zone;
using app.human;
using app.net;
using app.system;
using UnityEngine;
using UnityEngine.UI;

namespace app.chat
{

    public class ChatModel : AbsModel
    {
        public const string APPEND_ONE_MSG = "APPEND_ONE_MSG";
        public const string ADD_ZUIJINLIANXIREN = "ADD_ZUIJINLIANXIREN";
        public const string DEL_ZUIJINLIANXIREN = "DEL_ZUIJINLIANXIREN";
        public const string UPDATE_ZUIJINLIANXIREN = "UPDATE_ZUIJINLIANXIREN";
        public string biaoqingPath;
        /**
        * 每个频道能显示的最大条数
        */
        public const int MAX_LEN_PERSCOPE = 30;
        /// <summary>
        /// 最近联系人的最大数
        /// </summary>
        public const int MAX_LIANXIREN_LEN = 20;

        ///** 当前收到的聊天信息 */
        //private ChatMsgData _chatData;

        /** 当前所有聊天列表信息的字典,除私聊外的频道 */
        private Dictionary<int, List<ChatMsgData>> _chatDictionary;
        /// <summary>
        /// 系统的通知信息
        /// </summary>
        private List<SysNoticeInfoData> _sysNoticeList;
        /// <summary>
        /// 系统的提示信息
        /// </summary>
        private List<SysMsgInfoData> _sysMessageList;
        /// <summary>
        /// 跟其他玩家的私聊信息，key为其他玩家的uuid，内容为聊天内容列表，按照时间排序，新的在后面
        /// </summary>
        private Dictionary<string, List<ChatMsgData>> siliaoDic;
        /// <summary>
        /// 当前语音选择的频道
        /// </summary>
        private int currentRecordingChannel;

        private PlayerDataList zuijinlianxirenList;
        /// <summary>
        /// 表情sprite 字典
        /// </summary>
        private Dictionary<string, Sprite> biaoqingDic = new Dictionary<string, Sprite>();
        /// <summary>
        /// 表情帧 数 字典
        /// </summary>
        private Dictionary<string, int> biaoqingFrameDic = new Dictionary<string, int>();
        /// <summary>
        /// 主界面聊天框显示哪个频道的
        /// </summary>
        private Dictionary<int,bool> scopeMsgShow=new Dictionary<int, bool>();

        private RelationView relationView = null;

        private RTimer mPlayVoiceTimer = null;
        
        /// <summary>
        /// 收到chatList后放到该列表中，一个一个添加
        /// </summary>
        private List<ChatInfoData> waitingAddChatList;
        private RTimer addChatTimer;
        /// <summary>
        /// 添加一条聊天的时间间隔,毫秒
        /// </summary>
        private int addOneChatMinInterval = 500;
        private int addOneChatMaxInterval = 1000;

        private bool mIsBianqingLoaded = false;

        public ChatModel()
        {
            init();
        }
        private static ChatModel _ins;
        public static ChatModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ChatModel();
                }
                return _ins;
            }
        }
        /// <summary>
        /// 系统的通知信息
        /// </summary>
        public List<SysNoticeInfoData> SysNoticeList
        {
            get { return _sysNoticeList; }
        }

        /// <summary>
        /// 系统的提示消息
        /// </summary>
        public List<SysMsgInfoData> SysMessageList
        {
            get { return _sysMessageList; }
        }

        /// <summary>
        /// 当前语音选择的频道
        /// </summary>
        public int CurrentRecordingChannel
        {
            get { return currentRecordingChannel; }
            set { currentRecordingChannel = value; }
        }

        public PlayerDataList ZuijinlianxirenList
        {
            get
            {
                if (zuijinlianxirenList == null)
                {
                    zuijinlianxirenList = PlayerDataManager.Ins.GetPlayerDataList(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA);
                }
                return zuijinlianxirenList;
            }
        }

        private void init()
        {
            _chatDictionary = new Dictionary<int, List<ChatMsgData>>();
            siliaoDic = new Dictionary<string, List<ChatMsgData>>();
            _sysNoticeList = new List<SysNoticeInfoData>();
            biaoqingPath = PathUtil.Ins.GetUIPath("UIbiaoqing");
        }

        public void receiveChatData(GCChatMsg msg)
        {
            receiveChatData(new ChatMsgData(msg));
        }

        private void receiveChatData(ChatMsgData chatData)
        {
            updateList(chatData);
        }

        /**
        * 更新聊天list 
        * @param list
        */
        private void updateList(ChatMsgData chatdata)
        {
            int msgScope = chatdata.getScope();

            if (msgScope == ChatScopeType.CHAT_SCOPE_PRIVATE)
            {//私聊频道 数据添加
                AddChatInfoToSiLiao(chatdata);
            }
            else
            {
                if (msgScope == ChatScopeType.CHAT_SCOPE_DEFAULT)
                {
                    //综合频道 数据添加
                    AddChatInfoToScopeList(ChatScopeType.CHAT_SCOPE_DEFAULT, chatdata);
                }
                else
                {
                    //具体频道 数据添加
                    AddChatInfoToScopeList(msgScope, chatdata);
                    chatdata.setHasReaden(true);
                }
            }
            dispatchChangeEvent(APPEND_ONE_MSG, chatdata);

            if (chatdata.getChatType() == 1)
            {
                switch (msgScope)
                {
                    case ChatScopeType.CHAT_SCOPE_WORLD:
                        if (SystemSettings.ins.isAutoPlayShijieYuyin)
                        {
                            PlayVoice(chatdata);
                        }
                        break;
                    case ChatScopeType.CHAT_SCOPE_DEFAULT:
                        if (SystemSettings.ins.isAutoPlayDangqianYuyin)
                        {
                            PlayVoice(chatdata);
                        }
                        break;
                    case ChatScopeType.CHAT_SCOPE_TEAM:
                        if (SystemSettings.ins.isAutoPlayDuiwuYuyin)
                        {
                            PlayVoice(chatdata);
                        }
                        break;
                    case ChatScopeType.CHAT_SCOPE_CORPS:
                        if (SystemSettings.ins.isAutoPlayBangpaiYuyin)
                        {
                            PlayVoice(chatdata);
                        }
                        break;
                }
            }
        }

        private void AddChatInfoToSiLiao(ChatMsgData chatdata)
        {
            chatdata.setHasReaden(false);
            string roleuuidkey;
            if (chatdata.getFromRoleUUID() == Human.Instance.Id.ToString())
            {//我发送的
                roleuuidkey = chatdata.getToRoleUUID();
            }
            else
            {//发送给我的
                roleuuidkey = chatdata.getFromRoleUUID();
            }
            List<ChatMsgData> siliaoMsglist = getSiLiaoChatList(roleuuidkey);
            if (siliaoMsglist != null)
            {
                siliaoMsglist.Add(chatdata);
                //按照聊天时间排序
                siliaoMsglist.Sort((a, b) => b.getChatTime().CompareTo(a.getChatTime()));
            }
            else
            {
                siliaoMsglist = new List<ChatMsgData>();
                siliaoMsglist.Add(chatdata);
                siliaoDic.Add(roleuuidkey, siliaoMsglist);
            }

            GameUUButton friendBtn = ZoneUI.ins.GetFriendBtn();
            if (friendBtn != null)
            {
                friendBtn.redDotVisible = true;
            }

            //更新最近联系人信息
            SaveZuiJinLianXiRen(chatdata);
            //更新最近联系人的聊天信息
            SaveLianXiRenChatMsg(chatdata);
        }

        /// <summary>
        /// 保存一个最近联系人。
        /// </summary>
        private void SaveZuiJinLianXiRen(ChatMsgData chatData)
        {
            string uuid = "";
            string name = "";
            string level = "0";
            string tplId = "0";

            if (chatData.getFromRoleUUID() == Human.Instance.Id.ToString())
            {
                uuid = chatData.getToRoleUUID();
                name = chatData.getToRoleName();
                tplId = chatData.getToRoleTplId().ToString();
            }
            else
            {
                uuid = chatData.getFromRoleUUID();
                name = chatData.getFromRoleName();
                level = chatData.getFromRoleLevel().ToString();
                tplId = chatData.getFromRoleTplId().ToString();
            }

            SaveZuiJinLianXiRen(uuid, name, level, tplId);
        }

        /// <summary>
        /// 保存一个最近联系人。
        /// </summary>
        public void SaveZuiJinLianXiRen(string uuid, string name, string level, string tplId)
        {
            int currenLen = ZuijinlianxirenList.List != null ? ZuijinlianxirenList.List.Count : 0;
            int thisPlayerIndex = -1;
            bool hasOldData = false;
            for (int i = 0; i < currenLen; i++)
            {
                PlayerData playerdata = ZuijinlianxirenList.List[i];
                string tmpuuid = playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID);
                if (uuid == tmpuuid)
                {
                    thisPlayerIndex = i;
                    hasOldData = true;
                    // /playerdata.addData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID, uuid);
                    playerdata.addData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_NAME, name);
                    playerdata.addData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_LV, level);
                    playerdata.addData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_PHOTO, tplId);
                    dispatchChangeEvent(UPDATE_ZUIJINLIANXIREN, playerdata);
                    break;
                }
            }

            if (!hasOldData)
            {
                if (ZuijinlianxirenList != null && ZuijinlianxirenList.List != null && ZuijinlianxirenList.List.Count >= MAX_LIANXIREN_LEN)
                {
                    string tmpuuid = ZuijinlianxirenList.List[0].getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID);
                    ZuijinlianxirenList.List.RemoveAt(0);
                    dispatchChangeEvent(DEL_ZUIJINLIANXIREN, tmpuuid);
                }
                
                PlayerData playerdata = new PlayerData();
                playerdata.addData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_UUID, uuid);
                playerdata.addData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_NAME, name);
                playerdata.addData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_LV, level);
                playerdata.addData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_PHOTO, tplId);
                ZuijinlianxirenList.addData(playerdata);
                dispatchChangeEvent(ADD_ZUIJINLIANXIREN, playerdata);
            }
            PlayerDataManager.Ins.SaveDataList(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA, ZuijinlianxirenList);
        }

        private void SaveLianXiRenChatMsg(ChatMsgData chatData)
        {
            
        }

        /// <summary>
        /// 往频道里加消息
        /// </summary>
        /// <param name="chatScope"></param>
        private void AddChatInfoToScopeList(int chatScope, ChatMsgData chatdata)
        {
            List<ChatMsgData> list = null;
            if (_chatDictionary.ContainsKey(chatScope))
            {
                _chatDictionary.TryGetValue(chatScope, out list);
                if (list != null)
                {
                    if (list.Count >= MAX_LEN_PERSCOPE)
                    {
                        _chatDictionary[chatScope].RemoveAt(0);
                    }
                    _chatDictionary[chatScope].Add(chatdata);
                }
            }
            else
            {
                list = new List<ChatMsgData>();
                list.Add(chatdata);
                _chatDictionary.Add(chatScope, list);
            }
        }

        /**
        * 获得跟某个玩家的私聊信息
        * @param scope
        * @return 
        */
        public List<ChatMsgData> getSiLiaoChatList(string toRoleUUid)
        {
            List<ChatMsgData> siliaoMsglist = null;
            if (siliaoDic.ContainsKey(toRoleUUid))
            {
                siliaoDic.TryGetValue(toRoleUUid, out siliaoMsglist);
                if (siliaoMsglist != null)
                {
                    return siliaoMsglist;
                }
                else
                {
                    ClientLog.LogError("私聊消息字典中有key,但值为空！对象名称：UUid" + toRoleUUid);
                }
            }
            return siliaoMsglist;
        }

        /**
            * 获得某个频道的列表
            * @param scope
            * @return 
            */
        public List<ChatMsgData> getChatList(int scope)
        {
            if (_chatDictionary.ContainsKey(scope))
            {
                return _chatDictionary[scope];
            }
            else
            {
                return null;
            }
        }

        /**获得相应频道的颜色*/
        public string getChannelColor(int scope)
        {
            if (scope == ChatScopeType.CHAT_SCOPE_CORPS) return "#66cc00";
            if (scope == ChatScopeType.CHAT_SCOPE_COUNTRY) return "#00ccff";
            if (scope == ChatScopeType.CHAT_SCOPE_PRIVATE) return "#ff33cc";
            if (scope == ChatScopeType.CHAT_SCOPE_TEAM) return "#ff33cc";
            if (scope == ChatScopeType.CHAT_SCOPE_COMMON_TEAM) return "#ff33cc";
            if (scope == ChatScopeType.CHAT_SCOPE_WORLD) return "#ffffff";

            return "#ffffff";
        }

        /**获得相应频道的前缀*/
        public string getChannelName(int scope)
        {
            if (scope == ChatScopeType.CHAT_SCOPE_CORPS) return "【" + LangConstant.JUNTUAN + "】";
            if (scope == ChatScopeType.CHAT_SCOPE_COUNTRY) return "【" + LangConstant.GUOJIA + "】";
            if (scope == ChatScopeType.CHAT_SCOPE_PRIVATE) return "【" + LangConstant.SILIAO + "】";
            if (scope == ChatScopeType.CHAT_SCOPE_WORLD) return "【" + LangConstant.SHIJIE + "】";
            if (scope == ChatScopeType.CHAT_SCOPE_TEAM) return "【" + LangConstant.DUIWU + "】";
            if (scope == ChatScopeType.CHAT_SCOPE_COMMON_TEAM) return "【" + LangConstant.ZUDUI + "】";
            return "";
        }

        public void setSysNoticeList(NoticeTipsInfoData[] noticeList)
        {
            if (_sysNoticeList == null)
            {
                _sysNoticeList = new List<SysNoticeInfoData>();
            }
            else
            {
                _sysNoticeList.Clear();
            }

            int len = noticeList.Length;
            for (int i = 0; i < len; i++)
            {
                NoticeTipsInfoData data = noticeList[i];
                if (data.fromRoleLevel > 0)
                {
                    //好友或陌生人的离线消息。
                    ChatMsgData chatData = new ChatMsgData();
                    chatData.setScope(ChatScopeType.CHAT_SCOPE_PRIVATE);
                    chatData.setChatType(0);
                    chatData.setFromRoleUUID(data.fromRoleId.ToString());
                    chatData.setFromRoleName(data.fromRoleName);
                    chatData.setFromRoleLevel(data.fromRoleLevel);
                    chatData.setFromRoleTplId(data.fromRoleTplId);
                    chatData.setContent(data.content);
                    chatData.setChatTime(data.chatTime);
                    chatData.setToRoleUUID(Human.Instance.Id.ToString());
                    chatData.setToRoleName(Human.Instance.getName());
                    chatData.setToRoleTplId(Human.Instance.PetModel.getLeader().getTplId());
                    receiveChatData(chatData);
                }
                else
                {
                    addSysNotice(data);
                }
            }

            if (len > 0)
            {
                GameUUButton friendBtn = ZoneUI.ins.GetFriendBtn();
                if (friendBtn != null)
                {
                    friendBtn.redDotVisible = true;
                }
            }
        }

        public void addSysNotice(NoticeTipsInfoData noticeinfo)
        {
            if (_sysNoticeList == null)
            {
                _sysNoticeList = new List<SysNoticeInfoData>();
            }
            if (_sysNoticeList.Count >= MAX_LEN_PERSCOPE)
            {
                _sysNoticeList.RemoveAt(0);
            }
            _sysNoticeList.Add(new SysNoticeInfoData(noticeinfo));

            GameUUButton friendBtn = ZoneUI.ins.GetFriendBtn();
            if (friendBtn != null)
            {
                friendBtn.redDotVisible = true;
            }

            dispatchChangeEvent(APPEND_ONE_MSG, noticeinfo);
        }

        public void addSysMessage(SysMsgInfoData sysMsgInfo)
        {
            if (_sysMessageList == null)
            {
                _sysMessageList = new List<SysMsgInfoData>();
            }
            if (_sysMessageList.Count >= MAX_LEN_PERSCOPE)
            {
                _sysMessageList.RemoveAt(0);
            }
            _sysMessageList.Add(sysMsgInfo);
            dispatchChangeEvent(APPEND_ONE_MSG, sysMsgInfo);
        }

        public bool HasUnreadSysNotice()
        {
            if (_sysNoticeList != null)
            {
                int len = _sysNoticeList.Count;
                for (int i = 0; i < len; i++)
                {
                    if (!_sysNoticeList[i].getHasReaden())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasUnreadPrivateChatMsg()
        {
            foreach (List<ChatMsgData> list in siliaoDic.Values)
            {
                int len = list.Count;
                for (int i = 0; i < len; i++)
                {
                    if (!list[i].getHasReaden())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasUnreadPrivateChatMsg(long playerUUID)
        {
            List<ChatMsgData> list;
            siliaoDic.TryGetValue(playerUUID.ToString(), out list);
            if (list != null)
            {
                int len = list.Count;
                for (int i = 0; i < len; i++)
                {
                    if (!list[i].getHasReaden())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 打开聊天窗口并开始和某人聊天。
        /// </summary>
        /// <param name="uuid">对方唯一id。</param>
        /// <param name="name">对方名字。</param>
        /// <param name="level">对方等级。</param>
        /// <param name="tplId">对方模版id。</param>
        public void OpenRelationViewAndChat(string uuid, string name, string level, string tplId)
        {
            SaveZuiJinLianXiRen(uuid, name, level, tplId);
            WndManager.open(GlobalConstDefine.RelationView_Name, WndParam.CreateWndParam(WndParam.RelationViewSelectZuijinLianxiren, 1));
        }

        public List<Dictionary<string, string>> GetChatTextList(string chatContent,int fontSize,Color baseColor)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            ////解析展示信息
            Dictionary<string, string> exhibition = null;
            if (chatContent.Contains(ChatContentBase.SPLIT_MAIN + ""))
            {
                if (chatContent.LastIndexOf(ChatContentBase.SPLIT_MAIN) == chatContent.Length - 1)
                {
                    int startIndex = chatContent.Substring(0, chatContent.Length - 1).LastIndexOf(ChatContentBase.SPLIT_MAIN);
                    if (startIndex >= 0)
                    {
                        string prestr = chatContent.Substring(0,startIndex);
                        string endstr = chatContent.Substring(startIndex);
                        //有物品或者宠物,只能在结尾处有一个物品或者宠物
                        string[] arr = endstr.Split(ChatContentBase.SPLIT_MAIN);
                        if (arr != null && chatContent.Length > 1)
                        {
                            string exhibitionStr = arr[1];
                            if (ChatContentAnalysis.Parse(exhibitionStr))
                            {
                                //解析成功
                                chatContent = prestr;
                                string[] exhiArr = exhibitionStr.Split(ChatContentBase.SPLIT_SUB);
                                if (ChatContentAnalysis.Parse(exhibitionStr))
                                {
                                    switch (int.Parse(exhiArr[0]))
                                    {
                                        case ChatContentType.PET:
                                            exhibition = UGUIRichTextOptimized.CreateTextElement(
                                                "【" + exhiArr[exhiArr.Length - 1] + "】", fontSize, Color.green, false, false,
                                                exhibitionStr);
                                            break;
                                        case ChatContentType.ITEM:
                                            exhibition = UGUIRichTextOptimized.CreateTextElement(
                                                "【" + exhiArr[exhiArr.Length - 1] + "】", fontSize, Color.green, false, false,
                                                exhibitionStr);
                                            break;
                                        case ChatContentType.FUNC:
                                            exhibition = UGUIRichTextOptimized.CreateTextElement(
                                                "【" + exhiArr[exhiArr.Length - 1] + "】", fontSize, Color.green, false, false,
                                                exhibitionStr);
                                            break;
                                        case ChatContentType.SHENQING_RUDUI:
                                            exhibition = UGUIRichTextOptimized.CreateTextElement(
                                                "【" + exhiArr[exhiArr.Length - 1] + "】", fontSize, Color.green, false, false,
                                                exhibitionStr);
                                            break;
                                        case ChatContentType.JIAWEI_HAOYOU:
                                            exhibition = UGUIRichTextOptimized.CreateTextElement(
                                                "【" + exhiArr[exhiArr.Length - 1] + "】", fontSize, Color.green, false, false,
                                                exhibitionStr);
                                            break;
                                        case ChatContentType.ROLE:
                                            exhibition = UGUIRichTextOptimized.CreateTextElement(
                                                "【" + exhiArr[exhiArr.Length - 1] + "】", fontSize, Color.green, false, false,
                                                exhibitionStr);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //解析表情，正则匹配表情
            MatchCollection matchCollection = Regex.Matches(chatContent, "#0[0-9]{2}");
            int biaoqingCount = matchCollection.Count;
            if (biaoqingCount > 0)
            {
                int counter = 0;
                foreach (Match match in matchCollection)
                {
                    //添加表情
                    string[] bqArr = match.Value.Split(ChatContentBase.FACE_PREFIX);
                    if (int.Parse(bqArr[1]) >= ChatBiaoQingView.minBiaoQingNum&&
                        int.Parse(bqArr[1]) <= ChatBiaoQingView.maxBiaoQingNum)
                    {
                        //是合法表情
                        int index = chatContent.IndexOf(match.Value);
                        if (index > 0)
                        {
                            //添加表情前面的字符串内容
                            string str = chatContent.Substring(0, index);
                            Dictionary<string, string> txt = UGUIRichTextOptimized.CreateTextElement(str, fontSize, baseColor,
                                false, false);
                            list.Add(txt);
                        }

                        Dictionary<string, string> biaoqing = UGUIRichTextOptimized.CreateSpriteAnimClipElement(
                        biaoqingPath, GetBiaoQingFrameNameList(bqArr[1])
                        , (int)(19 * 1.5f), (int)(19 * 1.5f), ChatContentBase.FACE_FRAME_RATE);
                        list.Add(biaoqing);
                        //从字符串中删除表情
                        chatContent = chatContent.Substring(index + ChatContentBase.FACE_CHAT_NUM,
                                chatContent.Length - (index + ChatContentBase.FACE_CHAT_NUM));
                    }

                    counter++;
                    if (counter >= biaoqingCount)
                    {
                        //最后一个表情,后面的内容
                        if (chatContent.Length > 0)
                        {
                            Dictionary<string, string> txt = UGUIRichTextOptimized.CreateTextElement(chatContent, fontSize,
                                baseColor,
                                false, false);
                            chatContent = "";
                            list.Add(txt);
                        }
                    }
                }
            }
            else
            {
                //添加整个字符串内容
                Dictionary<string, string> txt = UGUIRichTextOptimized.CreateTextElement(chatContent, fontSize, baseColor,
                    false, false);
                list.Add(txt);
            }

            //添加 展示信息
            if (exhibition != null)
            {
                list.Add(exhibition);
            }
            return list;
        }

        /// <summary>
        /// 设置聊天文本内容
        /// </summary>
        /// <param name="richText">富文本组件</param>
        /// <param name="chatContent">字符串内容，包含表情、展示的物品、宠物等</param>
        public void setChatText(UGUIRichTextOptimized richText, string chatContent, int fontsize,int textWidth, Color txtColor)
        {
            //注释：字符串内容，最后为 展示的物品、宠物（如果有），格式见 ChatContentItem.toString、ChatContentPet.toString
            //注释：表情在字符串内容中，以#开头后面跟着数字，为表情的名
            if (textWidth==0)
            {
                LayoutElement layout = richText.transform.parent.GetComponent<LayoutElement>();
                if (layout != null)
                {
                    textWidth = (int)layout.preferredWidth;
                }
            }
            ClientLog.Log("设置文本内容： " + richText.name + "   宽度：" + textWidth);
            List<Dictionary<string, string>> list = GetChatTextList(chatContent,fontsize,txtColor);
            richText.SetContent(list, SourceManager.Ins.defaultFont, fontsize, txtColor, false, null, true, textWidth, null, onClickHref);
        }

        public void onClickHref(string href)
        {
            ClientLog.Log("点击超链接 "+href);
            string[] exhiArr = href.Split(ChatContentBase.SPLIT_SUB);
            switch (int.Parse(exhiArr[0]))
            {
                case ChatContentType.ITEM:
                    ItemCGHandler.sendCGShowItem(exhiArr[2]);
                    break;
                case ChatContentType.PET:
                    PopPetInfoWnd.Ins.ShowInfo(long.Parse(exhiArr[1]), long.Parse(exhiArr[2]));
                    break;
                case ChatContentType.FUNC:
                    LinkParse.Ins.linkToFunc(int.Parse(exhiArr[1]));
                    break;
                case ChatContentType.SHENQING_RUDUI:
                    if (TeamModel.ins.hasTeam())
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("您已有队伍，不能重复加入！");
                    }
                    else
                    {
                        TeamCGHandler.sendCGTeamApply(int.Parse(exhiArr[1]));
                    }
                    break;
                case ChatContentType.JIAWEI_HAOYOU:
                    RelationCGHandler.sendCGAddRelationByIdStr(RelationType.HAOYOU,exhiArr[1]);
                    break;
                case ChatContentType.ROLE:
                    long roleuuid=0;
                    long.TryParse(exhiArr[1], out roleuuid);
                    if (roleuuid!=0)
                    {
                        PopRoleInfoWnd.Ins.ShowInfo(roleuuid);
                    }
                    break;
            }
        }

        public void onResized(UGUIRichTextOptimized txt)
        {
        }

        public void AddBiaoQing(string biaoqing)
        {
            if (WndManager.Ins.IsWndShowing(GlobalConstDefine.RelationView_Name))
            {
                if (relationView==null)
                {
                    relationView = Singleton.GetObj(typeof(RelationView)) as RelationView;
                }
                relationView.AddBiaoQing(biaoqing);
            }
            else
            {
                ZoneUI.ins.ChatView.AddBiaoQing(biaoqing);   
            }
        }

        public void ExhibitionItem(ItemDetailData item)
        {
            if (item == null)
            {
                return;
            }
            ChatContentItem chatitem = new ChatContentItem();
            chatitem.roleId = Human.Instance.Id.ToString();
            chatitem.itemUUID = item.commonItemData.uuid;
            chatitem.itemTplID = item.itemTemplate.Id;
            chatitem.itemQuality = item.GetItemColorInt();
            chatitem.itemName = item.itemTemplate.name;

            if (WndManager.Ins.IsWndShowing(GlobalConstDefine.RelationView_Name))
            {
                if (relationView == null)
                {
                    relationView = Singleton.GetObj(typeof (RelationView)) as RelationView;
                }
                relationView.ExhibitionItem(chatitem.toString());
            }
            else
            {
                ZoneUI.ins.ChatView.ExhibitionItem(chatitem.toString());
            }
            if (WndManager.Ins.IsWndShowing(GlobalConstDefine.ChatBiaoQingView))
            {
                WndManager.Ins.close(GlobalConstDefine.ChatBiaoQingView);
            }
        }

        public void ExhibitionPet(Pet pet)
        {
            if (pet == null)
            {
                return;
            }
            ChatContentPet chatpet = new ChatContentPet();
            chatpet.roleId = Human.Instance.Id.ToString();
            chatpet.petUUID = pet.PetInfo.petId.ToString();
            chatpet.petTplID = pet.getTplId();
            chatpet.petName = pet.getName();
            if (WndManager.Ins.IsWndShowing(GlobalConstDefine.RelationView_Name))
            {
                if (relationView == null)
                {
                    relationView = Singleton.GetObj(typeof (RelationView)) as RelationView;
                }
                relationView.ExhibitionPet(chatpet.toString());
            }
            else
            {
                ZoneUI.ins.ChatView.ExhibitionPet(chatpet.toString());
            }
            if (WndManager.Ins.IsWndShowing(GlobalConstDefine.ChatBiaoQingView))
            {
                WndManager.Ins.close(GlobalConstDefine.ChatBiaoQingView);
            }
        }

        #region 表情相关

        /// <summary>
        /// 主界面聊天框显示哪个频道的
        /// </summary>
        public Dictionary<int, bool> ScopeMsgShow
        {
            get { return scopeMsgShow; }
            set { scopeMsgShow = value; }
        }

        public bool CanShowScopeMsg(int scopeType)
        {
            if (scopeMsgShow != null && scopeMsgShow.ContainsKey(scopeType))
            {
                return scopeMsgShow[scopeType];
            }
            return true;
        }

        /// <summary>
        /// 打开表情
        /// </summary>
        public void OpenBiaoqing()
        {
            if (WndManager.Ins.IsWndShowing(GlobalConstDefine.ChatBiaoQingView))
            {
                WndManager.Ins.close(GlobalConstDefine.ChatBiaoQingView);
            }
            else
            {
                WndManager.open(GlobalConstDefine.ChatBiaoQingView);
            }
        }

        /// <summary>
        /// 表情初始化
        /// </summary>
        public void InitBiaoqing()
        {
            if (!mIsBianqingLoaded)
            {
                mIsBianqingLoaded = true;
                bool hasAssets = SourceManager.Ins.hasAssetBundle(biaoqingPath);
                if (hasAssets)
                {
                    loadBiaoQingComplete();
                }
                else
                {
                    SourceLoader.Ins.load(biaoqingPath, loadBiaoQingComplete);
                }
            }
        }

        private void loadBiaoQingComplete(RMetaEvent e = null)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                AssetBundleContainer abc = SourceManager.Ins.GetBundleConainer(biaoqingPath);
                object[] objList = abc.assetBundle.LoadAllAssets();

                for (int i = 0; i < objList.Length; i++)
                {
                    Sprite sp = (Sprite)objList[i];
                    biaoqingDic.Add(sp.name, sp);
                    string[] strarr = sp.name.Split(new char[1] { '_' });
                    if (!biaoqingFrameDic.ContainsKey(strarr[1]))
                    {
                        biaoqingFrameDic.Add(strarr[1], 1);
                    }
                    else
                    {
                        biaoqingFrameDic[strarr[1]]++;
                    }
                }
            }
            else
            {
                mIsBianqingLoaded = false;
            }
        }
        /// <summary>
        /// 获得表情的帧数
        /// </summary>
        /// <param name="biaoqingname"></param>
        /// <returns></returns>
        public int GetBiaoQingFrameLen(string biaoqingname)
        {
            if (biaoqingFrameDic.ContainsKey(biaoqingname))
            {
                return biaoqingFrameDic[biaoqingname];
            }
            return 0;
        }
        /// <summary>
        /// 获得表情的帧数组
        /// </summary>
        /// <param name="biaoqingname"></param>
        /// <returns></returns>
        public Sprite[] GetBiaoQingFrameList(string biaoqingname)
        {
            int len = GetBiaoQingFrameLen(biaoqingname);
            Sprite[] frameList = new Sprite[len];
            for (int i = 0; i < len; i++)
            {
                string framename = "face_" + biaoqingname + "_" + (i);
                if (biaoqingDic.ContainsKey(framename))
                {
                    frameList[i] = (biaoqingDic[framename]);
                }
            }
            return frameList;
        }
        /// <summary>
        /// 获得表情的帧 名 数组
        /// </summary>
        /// <param name="biaoqingname"></param>
        /// <returns></returns>
        public string[] GetBiaoQingFrameNameList(string biaoqingname)
        {
            int len = GetBiaoQingFrameLen(biaoqingname);
            string[] frameList = new string[len];
            for (int i = 0; i < len; i++)
            {
                string framename = "face_" + biaoqingname + "_" + (i);
                if (biaoqingDic.ContainsKey(framename))
                {
                    frameList[i] = framename;
                }
            }
            return frameList;
        }
        #endregion

        public void PlayVoice(ChatMsgData chatMsg)
        {
            PlatForm.Instance.PlayChat(GetVoiceURL(chatMsg));
            ClientLog.LogWarning("开始播放" + GetVoiceURL(chatMsg));
            string timestr = GetVoiceTime(chatMsg);
            float timeint = 0f;
            float.TryParse(timestr, out timeint);
            if (timeint > 0)
            {
                if (mPlayVoiceTimer != null)
                {
                    mPlayVoiceTimer.stop();
                }
                mPlayVoiceTimer = TimerManager.Ins.createTimer(100, (int)(timeint * 1000), null, onTimerEnd);
                mPlayVoiceTimer.start();
                AudioManager.Ins.SetAllMuteTmp(true);
            }
        }

        private void onTimerEnd(RTimer r)
        {
            AudioManager.Ins.SetAllMuteTmp(false);
        }

        private string GetVoiceURL(ChatMsgData chatMsgv)
        {
            if (chatMsgv==null) return"";
            string str = chatMsgv.getContent();
            string[] messageArr = str.Split(new char[] { '|' });
            string url = messageArr[0];
            return url;
        }

        public string GetVoiceTime(ChatMsgData chatMsgv)
        {
            if (chatMsgv == null) return "";
            string str = chatMsgv.getContent();
            string[] messageArr = str.Split(new char[] { '|' });
            string timelen = "0";
            if (messageArr.Length > 2)
            {
                timelen = messageArr[2];
            }
            return timelen;
        }

        /// <summary>
        /// 添加聊天列表
        /// </summary>
        /// <param name="chatlist"></param>
        public void AddChatList(ChatInfoData[] chatlist)
        {
            if (waitingAddChatList==null)
            {
                waitingAddChatList = chatlist.ToList();
            }
            else
            {
                waitingAddChatList = waitingAddChatList.Concat(chatlist).ToList();
            }
            if (waitingAddChatList.Count > MAX_LEN_PERSCOPE)
            {
                //当前等待消息太多，把最老的删去
                waitingAddChatList.RemoveRange(0, waitingAddChatList.Count - MAX_LEN_PERSCOPE);
            }
            if (addChatTimer==null)
            {
                addChatTimer = TimerManager.Ins.createTimer(Random.Range(addOneChatMinInterval, addOneChatMaxInterval), -1, addOneChat, null);
                addChatTimer.start();
            }
            else
            {
                if (!addChatTimer.IsRunning)
                {//重新开始
                    addChatTimer.Reset(Random.Range(addOneChatMinInterval, addOneChatMaxInterval), -1);
                    addChatTimer.Restart();
                }
            }
        }

        private void addOneChat(RTimer r)
        {
            
            if (waitingAddChatList != null && waitingAddChatList.Count>0)
            {
                receiveChatData(new ChatMsgData(waitingAddChatList[0]));
                waitingAddChatList.RemoveAt(0);
            }
            else
            {
                if (addChatTimer != null)
                {
                    addChatTimer.stop();
                }
            }
        }

        
        public override void Destroy()
        {
            if (_chatDictionary != null)
            {
                foreach (KeyValuePair<int, List<ChatMsgData>> pair in _chatDictionary)
                {
                    for (int i = 0; i < pair.Value.Count; i++)
                    {
                        pair.Value[i] = null;
                    }
                    pair.Value.Clear();
                }
            }
            if (_sysNoticeList != null)
            {
                for (int i = 0; i < _sysNoticeList.Count; i++)
                {
                    _sysNoticeList[i] = null;
                }
                _sysNoticeList.Clear();
            }
            if (_sysMessageList != null)
            {
                for (int i = 0; i < _sysMessageList.Count; i++)
                {
                    _sysMessageList[i] = null;
                }
                _sysMessageList.Clear();
            }
            if (siliaoDic != null)
            {
                foreach (KeyValuePair<string, List<ChatMsgData>> pair in siliaoDic)
                {
                    for (int i = 0; i < pair.Value.Count; i++)
                    {
                        pair.Value[i] = null;
                    }
                    pair.Value.Clear();
                }
            }
            if (zuijinlianxirenList != null){zuijinlianxirenList.Destroy();}
            zuijinlianxirenList = null;

            foreach (KeyValuePair<string, Sprite> pair in biaoqingDic)
            {
                GameObject.DestroyImmediate(pair.Value,true);
            }
            if(biaoqingDic!=null)biaoqingDic.Clear();
            biaoqingDic = null;
            if(biaoqingFrameDic!=null)biaoqingFrameDic.Clear();
            biaoqingFrameDic = null;
            if(scopeMsgShow!=null)scopeMsgShow.Clear();
            scopeMsgShow = null;

            relationView = null;
            if (mPlayVoiceTimer!=null)
            {
                mPlayVoiceTimer.stop();
            }
            mPlayVoiceTimer = null;
            if (addChatTimer != null)
            {
                addChatTimer.stop();
            }
            addChatTimer = null;
            if (waitingAddChatList!=null)
            {
                waitingAddChatList.Clear();
            }
            waitingAddChatList = null;
            currentRecordingChannel = 0;

            _ins = null;
        }

    }

}