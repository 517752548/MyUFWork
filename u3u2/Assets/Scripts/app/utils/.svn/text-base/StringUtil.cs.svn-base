using System;
using System.Text;

namespace app.utils
{
    public class StringUtil
    {
        public static bool IsLegalString(string id)
        {
            return id != null && id != "";
        }

        /// <summary>
        /// 组合字符串。
        /// </summary>
        /// <param name="template">Template.</param>
        /// <param name="args">Arguments.</param>
        public static string Assemble(string template, params string[] args)
        {
            return new StringBuilder().AppendFormat(template, args).ToString();
            /*
            string res = template;
            int len = args.Length;
            for (int i = 0; i < len; i++)
            {
                try
                {
                    res = res.Replace("{" + i + "}", args[i]);
                }
                catch (Exception)
                {
                    return res;
                }
            }
            return res;
            */
        }

        public static string GetCapstureNumberStr(int num)
        {
            string str = null;
            switch (num)
            {
                case 0:
                    str = "零";
                    break;
                case 1:
                    str = "一";
                    break;
                case 2:
                    str = "二";
                    break;
                case 3:
                    str = "三";
                    break;
                case 4:
                    str = "四";
                    break;
                case 5:
                    str = "五";
                    break;
                case 6:
                    str = "六";
                    break;
                case 7:
                    str = "七";
                    break;
                case 8:
                    str = "八";
                    break;
                case 9:
                    str = "九";
                    break;
                case 10:
                    str = "十";
                    break;
                default:
                    str = num.ToString();
                    break;
            }
            return str;
        }

        public static string Join(params string[] args)
        {
            int len = args.Length;
            if (len == 0)
            {
                return "";
            }

            if (len == 1)
            {
                return args[0];
            }

            switch (len)
            {
                case 0:
                    return "";
                case 1:
                    return args[0];
                case 2:
                    return new StringBuilder(args[0]).Append(args[1]).ToString();
                case 3:
                    return new StringBuilder(args[0]).Append(args[1]).Append(args[2]).ToString();
                case 4:
                    return new StringBuilder(args[0]).Append(args[1]).Append(args[2]).Append(args[3]).ToString();
                case 5:
                    return new StringBuilder(args[0]).Append(args[1]).Append(args[2]).Append(args[3]).Append(args[4]).ToString();
                case 6:
                    return new StringBuilder(args[0]).Append(args[1]).Append(args[2]).Append(args[3]).Append(args[4]).Append(args[5]).ToString();
                case 7:
                    return new StringBuilder(args[0]).Append(args[1]).Append(args[2]).Append(args[3]).Append(args[4]).Append(args[5]).Append(args[6]).ToString();
                case 8:
                    return new StringBuilder(args[0]).Append(args[1]).Append(args[2]).Append(args[3]).Append(args[4]).Append(args[5]).Append(args[6]).Append(args[7]).ToString();
                case 9:
                    return new StringBuilder(args[0]).Append(args[1]).Append(args[2]).Append(args[3]).Append(args[4]).Append(args[5]).Append(args[6]).Append(args[7]).Append(args[8]).ToString();
                case 10:
                    return new StringBuilder(args[0]).Append(args[1]).Append(args[2]).Append(args[3]).Append(args[4]).Append(args[5]).Append(args[6]).Append(args[7]).Append(args[8]).Append(args[9]).ToString();
                default:
                    StringBuilder res = new StringBuilder(args[0]);
                    for (int i = 1; i < len; i++)
                    {
                        res = res.Append(args[i]);
                    }
                    return args.ToString();
            }
        }
    }
}

