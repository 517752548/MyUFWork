using System.Collections.Generic;
using System.Text;

namespace app.zone
{
    public class ZoneDef
    {
        /// <summary>
        /// 与服务器同步主角位置信息的时间间隔。
        /// </summary>
        public const float SYNC_POSITION_DELTA_SECONDS = 1.0f;

        /// <summary>
        /// 人物移动速度。
        /// </summary>
        public const float CHARACTER_MOVE_SPEED = 2.75f;

        /// <summary>
        /// 地图每单位像素数。
        /// </summary>
        public const int MAP_PIXEL_ONE_UNIT = 65;
        
        /// <summary>
        /// 地图块像素宽度。
        /// </summary>
        public const int MAP_TILE_PIXEL_WIDTH = 256;
        
        /// <summary>
        /// 地图块像素高度。
        /// </summary>
        public const int MAP_TILE_PIXEL_HEIGHT = 256;

        /// <summary>
        /// 地图上的角色创建间隔帧数。
        /// </summary>
        #if UNITY_EDITOR
        public const int MAP_CHARACTER_CREATE_CD_FRAME = 0;
        #else
        public const int MAP_CHARACTER_CREATE_CD_FRAME = 20;
        #endif
    }
    
    /// <summary>
    /// 角色行为类型。
    /// </summary>
    public enum ZoneCharacterBehavType
    {
        /// <summary>
        /// 角色行为类型：无(0)。
        /// </summary>
        NONE,
        /// <summary>
        /// 角色行为类型：待机(1)。
        /// </summary>
        IDLE,
        /// <summary>
        /// 角色行为类型：移动(2)。
        /// </summary>
        MOVE
    }
    
    public enum ZoneBubbleType
    {
        NONE,
        IMAGE,
        IMAGE_TEXT,
        RICH_TEXT
    }

    public enum ZoneBubbleContentType
    {
        DEFAULT
    }
    /// <summary>
    /// 地图类型定义
    /// </summary>
    public enum MapType
    {
        NONE,
        /** 普通地图 */
		NORMAL,//1
		/** 宠物岛 */
		PET_ISLAND,//2
		/** 军团主城 */
        CORPS_MAIN,//3
		/** 绿野仙踪 */
        WIZARD_RAID,//4
		/** 帮派竞赛 */
        CORPS_WAR,//5
		/** nvn联赛 */
        NVN_WAR,//6
        //通天塔  
        TOWER,//7
        //魔族副本
        MOZU//8
    }

    /// <summary>
    /// 表情符号解析
    /// </summary>
    public class ChatDef
    {
        //表情
        public static char expression = '#';
        public static string expression1 = "#1";


        //解析聊天内容的表情 转化为 富文本可用的字典
        public static List<SChatItem> GetChatList(string content) {
            List<SChatItem> list = new List<SChatItem>();
            if (!string.IsNullOrEmpty(content))
            {
                string[] strCont = content.Split(expression);
                if (strCont.Length == 1)
                {
                    //说明没有输入# 
                    string[] str = GetNum(strCont[0], false);
                    if (!string.IsNullOrEmpty(str[0]))
                    {
                        //防止只输了一个#号  这我暂时把#号去掉了
                        list.Add(GetBiaoqingOne(str[0]));
                    }
                    if (!string.IsNullOrEmpty(str[1])) {
                        list.Add(GetContentOne(str[1]));
                    }

                        
                }
                else {
                    string sTemp = "";  //临时存储用于储存连续的内容 有可能内容中有# 也被分割了~~
                    for (int i = 0; i < strCont.Length; i++)
                    {
                        string[] str = GetNum(strCont[i]);
                        if (str == null) continue;
                        if (!string.IsNullOrEmpty(str[0]))
                        {
                            //添加内容
                            list.Add(GetContentOne(str[1]));
                            sTemp = "";
                            //添加表情  防止只输了一个#号  这我暂时把#号去掉了 
                            list.Add(GetBiaoqingOne(str[0]));
                        }
                        if (!string.IsNullOrEmpty(str[1]))
                        {
                            sTemp += str[1];
                        }

                    }
                    if (!string.IsNullOrEmpty(sTemp))
                    {
                        list.Add(GetContentOne(sTemp));
                        sTemp = "";
                    }
                }
                
            }
            return list;
        }

        public static SChatItem GetBiaoqingOne(string id) {
            SChatItem item = new SChatItem();
            item.m_nFlat = 0;
            item.m_nId = id;
            return item;
        }

        public static SChatItem GetContentOne(string content)
        {
            SChatItem item = new SChatItem();
            item.m_nFlat = 1;
            item.content = content;
            return item;
        }


        /// <summary>
        /// 获得字符串中前面的数字 #123表示一个表情  就是为了获取这个数字~~~ 返回的数组 第一位是数字 第二位是其他内容
        /// bool b 为是否为一行
        /// </summary>
        private static string[] GetNum(string str,bool oneLine = true) {
            if (string.IsNullOrEmpty(str)) return null;
            bool flat = oneLine;  //只是为了判定 开始连续的数字
            List<char> listChar = new List<char>();  //数字字符列表
            List<char> listChar2 = new List<char>(); //其他字符列表
            char[] c = str.ToCharArray();
            string[] result = new string[2];
            if (c[0] < 49 ||c[0] > 57&& flat)
            {
                //如果第一位不是数字 说明只打了个#号需要加回来
                listChar2.Add(expression);
                flat = false;
            }
            for (int i=0;i< c.Length; i++) {
                if (c[i] >= 49 && c[i] <= 57&& flat)
                {
                    //ascii码表   如果是数字并且是连续的 添加到数字list里 
                    listChar.Add(c[i]);
                }
                else
                {
                    //添加到内容List里
                    flat = false;
                    listChar2.Add(c[i]);
                }
            }
            StringBuilder sb1 = new StringBuilder();
            //遍历 表情里数字的List
            for (int i =0;i< listChar.Count;i++) {
                sb1.Append(listChar[i]);
            }
            result[0] = sb1.ToString();
            StringBuilder sb2 = new StringBuilder();
            //遍历 其他内容的List
            for (int i = 0; i < listChar2.Count; i++)
            {
                sb2.Append(listChar2[i]);
            }
            result[1] = sb2.ToString();
            return result;
        }


    }
    /// <summary>
    /// 聊天内容中的某一小段  表情或者内容
    /// </summary>
    public struct SChatItem {
        public int m_nFlat;  //0为表情 1为内容
        public string m_nId;  //表情id
        public string content;    //表情内容
    }

}

