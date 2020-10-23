using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 单位：秒
/// </summary>
class TimeString
{
    private static int _tempMonth; //中间变量


    /**返回的格式为如:2天10小时22分 **/
    public static string getDayTimeString(int seconds)
    {
        int day = (int)(seconds / 86400);
        int hour = (int)(seconds % 86400 / 3600);
        int minute = (int)(seconds % 3600 / 60);
        int second = (int)(seconds % 3600 % 60);
        string str = "";

        if (day != 0)
        {
            str += day + "天";////"天"
        }

        if (hour != 0 || day != 0)
        {
            str += hour + "小时";////"小时"
        }

        if (minute != 0 || hour != 0 || day != 0)
        {
            str += minute + "分钟";////"分"
        }

        if (second!=0)
        {
            str += second+"秒";
        }
        return str;
    }

    /**返回的格式为如 10小时22分钟11秒 **/
    public static string getTimeString(int seconds)
    {
        int hour = (int)(seconds / 3600);
        int minute = (int)(seconds % 3600 / 60);
        int second = (int)(seconds % 3600 % 60);
        string str = "";

        /* if(day != 0)
			{
			str += day + LanguageManager.getInstance().getString("tian");
			} */

        if (hour != 0)
        {
            str += hour + "小时";////"小时"
        }

        if (minute != 0 || hour != 0)
        {
            str += minute + "分";////"分"
        }
        str += second + "秒";////"秒"
        return str;
    }

    /**返回的格式为如 10:22:11 **/
    public static string getTimeFormat(int left)
    {
        if (left <= 0)
            return "00:00:00";
        string str = "";
        str += (left / 3600 != 0) ?
            ((int)(left / 3600) >= 10 ? (int)(left / 3600) + ":" : "0" + (int)(left / 3600) + ":")
            : "00:";
        left = left % 3600;
        str += (left / 60 != 0) ? ((int)(left / 60) >= 10 ? (int)(left / 60) + ":" : "0" + (int)(left / 60) + ":") : "00:";
        left = left % 60;
        str += (((int)left) >= 10 ? left.ToString() : ("0" + left));
        return str;
    }
    public static string getTimeFormatMS(long left)
    {
        return TimeString.getTimeFormat((int)(left / 1000));
    }


    /**返回的格式为如 10:22:11 **/
    public static string getMinuteTimeFormat(int left)
    {
        if (left <= 0)
            return "00:00:00";
        string str = "";
        str += (left / 3600 != 0) ? ((left / 3600) >= 10 ? (left / 3600 != 0) + ":" : "0" + (left / 3600 != 0) + ":") : "00:";
        left = left % 3600;
        str += (left / 60 != 0) ? ((left / 60) >= 10 ? (left / 60 != 0) + ":" : "0" + (left / 60 != 0) + ":") : "00:";
        left = left % 60;
        str += (left >= 10 ? left.ToString() : "0" + left);
        return str;
    }

    private static int formatDay(int day, int month, int year)
    {
        _tempMonth = 0;

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                if (day == 31) //最后一天的时候，不用进位。
                    break;
                _tempMonth = day / 31;
                day %= 31;
                break;
            case 2:
                if (year % 4 == 0 && !(year % 100 == 0 && year % 400 != 0))
                {
                    if (day == 29)
                        break;
                    _tempMonth = day / 29;
                    day %= 29;
                }
                else
                {
                    if (day == 28)
                        break;
                    _tempMonth = day / 28;
                    day %= 28;
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                if (day == 30)
                    break;
                _tempMonth = day / 30;
                day %= 30;
                break;
        }
        return day;
    }

    /**
		* 显示时间的信息
		* 如果达到小时级别显示...小时
		* 如果只达到分钟级别显示...分钟
		* 如果只达到秒级别只显示...秒
		*/
    public static string getCertainTime(int time)
    {
        int secondTime = (int)Math.Ceiling(time * 0.001);
        int hour = (int)Math.Round((decimal)(secondTime / 3600));
        if (hour > 0)
        {
            return hour + "小时";//"小时";
        }
        else
        {
            int minute = (int)Math.Round((decimal)(secondTime / 60));
            if (minute > 0)
            {
                return minute + "分钟";//"分钟";
            }
            else
            {
                return secondTime + "秒";//"秒";
            }
        }
    }

}
