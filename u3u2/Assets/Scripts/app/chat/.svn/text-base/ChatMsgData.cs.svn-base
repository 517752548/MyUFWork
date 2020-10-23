using app.net;

namespace app.chat
{
    public class ChatMsgData
    {
        /** 聊天范围 */
        private int scope;
        /** 类型，0默认，1语音 */
        private int chatType;
        /** 聊天消息发送者角色UUID */
        private string fromRoleUUID;
        /** 聊天消息发送者角色名称 */
        private string fromRoleName;
        /** 聊天消息发送者等级 */
        private int fromRoleLevel;
        /** 聊天消息发送者国家 */
        private int fromRoleCountry;
        /** 聊天消息发送者模板Id */
        private int fromRoleTplId;
        /** 经过过滤后的聊天消息 */
        private string content;
        /** 聊天时间 */
        private long chatTime;
        /** 聊天消息接收者角色UUID */
        private string toRoleUUID;
        /** 聊天消息接收者角色名 */
        private string toRoleName;
        /** 聊天消息接收者模板Id */
        private int toRoleTplId;
        /** 发送者的vip等级 */
        private int fromRoleVipLevel;
        /** 接受者的vip等级 */
        private int toRoleVipLevel;
        /** 发送者是否接受者的好友 */
        private int IsFriendOfToRole;
        /** 发送者qq信息vip等数据 */
        private QQInfoData fromQQInfo;
        /** 接受者qq信息vip等数据 */
        private QQInfoData toQQInfo;
        
        private bool hasReaden;
        
        public ChatMsgData(){}

        public ChatMsgData(GCChatMsg msg)
        {
            this.scope = msg.getChatInfo().scope;
            this.chatType = msg.getChatInfo().chatType;
            this.fromRoleUUID = msg.getChatInfo().fromRoleUUID;
            this.fromRoleName = msg.getChatInfo().fromRoleName;
            this.fromRoleLevel = msg.getChatInfo().fromRoleLevel;
            this.fromRoleCountry = msg.getChatInfo().fromRoleCountry;
            this.fromRoleTplId = msg.getChatInfo().fromRoleTplId;
            this.content = msg.getChatInfo().content;
            this.chatTime = msg.getChatInfo().chatTime;
            this.toRoleUUID = msg.getChatInfo().toRoleUUID;
            this.toRoleName = msg.getChatInfo().toRoleName;
            this.toRoleTplId = msg.getChatInfo().toRoleTplId;
            this.fromRoleVipLevel = msg.getChatInfo().fromRoleVipLevel;
            this.toRoleVipLevel = msg.getChatInfo().toRoleVipLevel;
            this.IsFriendOfToRole = msg.getChatInfo().IsFriendOfToRole;
            this.fromQQInfo = new QQInfoData();
            this.fromQQInfo.isYellowHighVip = msg.getChatInfo().fromQQInfo.isYellowHighVip;
            this.fromQQInfo.isYellowVip = msg.getChatInfo().fromQQInfo.isYellowVip;
            this.fromQQInfo.isYellowYearVip = msg.getChatInfo().fromQQInfo.isYellowYearVip;
            this.fromQQInfo.yellowVipLevel = msg.getChatInfo().fromQQInfo.yellowVipLevel;
            this.toQQInfo = new QQInfoData();
            this.toQQInfo.isYellowHighVip = msg.getChatInfo().toQQInfo.isYellowHighVip;
            this.toQQInfo.isYellowVip = msg.getChatInfo().toQQInfo.isYellowVip;
            this.toQQInfo.isYellowYearVip = msg.getChatInfo().toQQInfo.isYellowYearVip;
            this.toQQInfo.yellowVipLevel = msg.getChatInfo().toQQInfo.yellowVipLevel;
        }

        public ChatMsgData(ChatInfoData msg)
        {
            this.scope = msg.scope;
            this.chatType = msg.chatType;
            this.fromRoleUUID = msg.fromRoleUUID;
            this.fromRoleName = msg.fromRoleName;
            this.fromRoleLevel = msg.fromRoleLevel;
            this.fromRoleCountry = msg.fromRoleCountry;
            this.fromRoleTplId = msg.fromRoleTplId;
            this.content = msg.content;
            this.chatTime = msg.chatTime;
            this.toRoleUUID = msg.toRoleUUID;
            this.toRoleName = msg.toRoleName;
            this.toRoleTplId = msg.toRoleTplId;
            this.fromRoleVipLevel = msg.fromRoleVipLevel;
            this.toRoleVipLevel = msg.toRoleVipLevel;
            this.IsFriendOfToRole = msg.IsFriendOfToRole;
            this.fromQQInfo = new QQInfoData();
            this.fromQQInfo.isYellowHighVip = msg.fromQQInfo.isYellowHighVip;
            this.fromQQInfo.isYellowVip = msg.fromQQInfo.isYellowVip;
            this.fromQQInfo.isYellowYearVip = msg.fromQQInfo.isYellowYearVip;
            this.fromQQInfo.yellowVipLevel = msg.fromQQInfo.yellowVipLevel;
            this.toQQInfo = new QQInfoData();
            this.toQQInfo.isYellowHighVip = msg.toQQInfo.isYellowHighVip;
            this.toQQInfo.isYellowVip = msg.toQQInfo.isYellowVip;
            this.toQQInfo.isYellowYearVip = msg.toQQInfo.isYellowYearVip;
            this.toQQInfo.yellowVipLevel = msg.toQQInfo.yellowVipLevel;
        }

        public int getScope()
        {
            return scope;
        }
        
        public void setScope(int value)
        {
            this.scope = value;
        }


        public int getChatType()
        {
            return chatType;
        }
        
        public void setChatType(int value)
        {
            this.chatType = value;
        }


        public string getFromRoleUUID()
        {
            return fromRoleUUID;
        }
        
        public void setFromRoleUUID(string value)
        {
            this.fromRoleUUID = value;
        }


        public string getFromRoleName()
        {
            return fromRoleName;
        }
        
        public void setFromRoleName(string value)
        {
            this.fromRoleName = value;
        }


        public int getFromRoleLevel()
        {
            return fromRoleLevel;
        }
        
        public void setFromRoleLevel(int value)
        {
            this.fromRoleLevel = value;
        }

        public int getFromRoleCountry()
        {
            return fromRoleCountry;
        }
        
        public void setFromRoleCountry(int value)
        {
            this.fromRoleCountry = value;
        }


        public int getFromRoleTplId()
        {
            return fromRoleTplId;
        }
        
        public void setFromRoleTplId(int value)
        {
            this.fromRoleTplId = value;
        }

        public string getContent()
        {
            return content;
        }
        
        public void setContent(string value)
        {
            this.content = value;
        }

        public long getChatTime()
        {
            return chatTime;
        }
        
        public void setChatTime(long value)
        {
            this.chatTime = value;
        }


        public string getToRoleUUID()
        {
            return toRoleUUID;
        }

        public void setToRoleUUID(string value)
        {
            this.toRoleUUID = value;
        }

        public string getToRoleName()
        {
            return toRoleName;
        }
        
        public void setToRoleName(string value)
        {
            this.toRoleName = value;
        }


        public int getToRoleTplId()
        {
            return toRoleTplId;
        }
        
        public void setToRoleTplId(int value)
        {
            this.toRoleTplId = value;
        }


        public int getFromRoleVipLevel()
        {
            return fromRoleVipLevel;
        }
        
        public void setFromRoleVipLevel(int value)
        {
            this.fromRoleVipLevel = value;
        }


        public int getToRoleVipLevel()
        {
            return toRoleVipLevel;
        }
        
        public void setToRoleVipLevel(int value)
        {
            this.toRoleVipLevel = value;
        }


        public int getIsFriendOfToRole()
        {
            return IsFriendOfToRole;
        }
        
        public void setIsFriendOfToRole(int value)
        {
            this.IsFriendOfToRole = value;
        }


        public QQInfoData getFromQQInfo()
        {
            return fromQQInfo;
        }
        
        public void setFromQQInfo(QQInfoData value)
        {
            this.fromQQInfo = value;
        }


        public QQInfoData getToQQInfo()
        {
            return toQQInfo;
        }
        
        public void setToQQInfo(QQInfoData value)
        {
            this.toQQInfo = value;
        }
        
        public bool getHasReaden()
        {
            return hasReaden;
        }
        
        public void setHasReaden(bool value)
        {
            this.hasReaden = value;
        }
    }
}