using app.utils;
using UnityEngine;

namespace app.chat
{
    public class ChatScopeType
    {
        /* 聊天范围 */
        /** 私聊，一对一 */
        public const int CHAT_SCOPE_PRIVATE = 0x00000001;
        /** 帮派，同一军团下的玩家 */
        public const int CHAT_SCOPE_CORPS = 0x00000002;
        /** 世界 */
        public const int CHAT_SCOPE_WORLD = 0x00000004;
        /** 国家，相同地图内的玩家 */
        public const int CHAT_SCOPE_COUNTRY = 0x00000008;
        /** 队伍，同一队伍内的玩家 */
        public const int CHAT_SCOPE_TEAM = 0x00000010;
        /** 组队，公共组队频道 */
        public const int CHAT_SCOPE_COMMON_TEAM = 0x00000020;
        /** 综合，默认接收所有频道 */
        public const int CHAT_SCOPE_DEFAULT = 0x000000FF;

        public static string GetChatScopeName(int chatScope)
        {
            string str = "";
            if (chatScope == ChatScopeType.CHAT_SCOPE_PRIVATE)
            { str = LangConstant.SILIAO; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_CORPS)
            { str = LangConstant.BANGPAI; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_WORLD)
            { str = LangConstant.SHIJIE; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_COUNTRY)
            { str = LangConstant.DANGQIAN; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_TEAM)
            { str = LangConstant.DUIWU; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_COMMON_TEAM)
            { str = LangConstant.ZUDUI; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_DEFAULT)
            { str = LangConstant.ZONGHE; }
            return str;
        }

        public static string GetChatScopeColor(int chatScope)
        {
            string color = ColorUtil.GREEN;
            if (chatScope == ChatScopeType.CHAT_SCOPE_PRIVATE)
            { color = ColorUtil.RED; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_CORPS)
            { color = ColorUtil.GREEN; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_WORLD)
            { color = ColorUtil.WHITE; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_COUNTRY)
            { color = ColorUtil.BLUE; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_TEAM)
            { color = ColorUtil.RED; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_COMMON_TEAM)
            { color = ColorUtil.RED; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_DEFAULT)
            { color = ColorUtil.WHITE; }
            return color;
        }

        public static Color GetScopeColor(int chatScope)
        {
            Color color = Color.green;
            if (chatScope == ChatScopeType.CHAT_SCOPE_PRIVATE)
            { color = Color.red; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_CORPS)
            { color = Color.green; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_WORLD)
            { color = Color.white; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_COUNTRY)
            { color = Color.blue; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_TEAM)
            { color = Color.red; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_COMMON_TEAM)
            { color = Color.red; }
            if (chatScope == ChatScopeType.CHAT_SCOPE_DEFAULT)
            { color = Color.white; }
            return color;
        }

        public static string GetChatScopeNameWithColor(int chatScope)
        {
            string color = GetChatScopeColor(chatScope);
            string scopeName = GetChatScopeName(chatScope);
            return ColorUtil.getColorText(color,"[" +scopeName+ "]");
        }

    }
}