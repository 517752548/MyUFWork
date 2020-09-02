using System;

public enum RepCodes
{
    SUCCESSED = 200,                // 操作成功
    REPEAT_LOGIN = 201,             // 分组已经存在

    ERROR_NET = 500,                // 网络异常
    ERROR_TIMEOUT = 501,            // 网络超时
    ERROR_FIELD = 0,                // 传入字段错误
    ERROR_DB_FAILED = -1,           // DB操作失败
    ERROR_BELONG = -2,              // 分层错乱
    ERROR_CONFIG = -3,              // 配置文件错误
    ERROR_PLAYER = -4,              // 玩家数据不存在

    ERROR_RINK_ID = -5,             // 活动ID不是当前活动
    ERROR_NO_END = -6,              // 活动未结束
}