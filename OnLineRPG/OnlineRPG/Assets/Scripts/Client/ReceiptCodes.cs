#region Documentation

/// <summary>   内购校验状态码. </summary>
/// <remarks>   Administrator, 2019/4/9. </remarks>

#endregion Documentation

public enum ReceiptCodes
{
    ERROR_UNKNOWN = -5, //未知错误
    Fail = 0,
    SUCCESSED = 1,
    ERROR_CODE1 = 21000,//21000 App Store不能读取你提供的JSON对象
    ERROR_CODE2 = 21002,//receipt-data域的数据有问题
    ERROR_CODE3 = 21003,//receipt无法通过验证
    ERROR_CODE4 = 21004,//提供的shared secret不匹配你账号中的shared secret
    ERROR_CODE5 = 21005,//receipt服务器当前不可用
    ERROR_CODE6 = 21006,//receipt合法，但是订阅已过期。服务器接收到这个状态码时，receipt数据仍然会解码并一起发送
    ERROR_CODE7 = 21007,//receipt是Sandbox receipt，但却发送至生产系统的验证服务
    ERROR_CODE8 = 21008,//receipt是生产receipt，但却发送至Sandbox环境的验证服务,
}