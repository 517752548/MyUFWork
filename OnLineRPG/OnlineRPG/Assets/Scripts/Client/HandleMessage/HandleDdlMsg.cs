using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

public class HandleDdlMsg : IPacketHandler
{
    public short OpCode { get; set; }
    /// <summary>
    /// 动态关卡的配置存档，当请求线上配置成功或者失败之后才能生效，如果为null则代表还没有生效
    /// </summary>
    public static RepDdlData localdata = null;
    public void Handle(IIncommingMessage message)
    {
        var data = message.Deserialize<RepDdlPacket>();
        LoggerHelper.Log("DDL:线上配置:" + JsonConvert.SerializeObject(data) );
        if (data.code == (int)RepCodes.SUCCESSED)
        {
//            DataManager.HasAdsData = true;
//            DataManager.AdsData = data.data;
//            DataManager.BusinessData.PlayerTag = data.data.Belong;
//            AppEngine.SAdManager.OnPlayerTagChanged();
                HandleDDLData(data.data);
        }
        else if (data.code == (int)RepCodes.ERROR_PLAYER)
        {
            DataManager.HasAdsData = false;
            HandleDDLData(null);
        }
        else
        {
            HandleDDLData(null);
            LoggerHelper.ErrorFormat("OpCode {0} response error, error code {1}", OpCode, data.code);
        }
    }

    public void HandleDDLData(RepDdlData data)
    {
        string localdataString = Record.GetString(PrefKeys.DDL_OnlineConfig, "");
        if (!string.IsNullOrEmpty(localdataString))
        {
            //先获取本地数据跟线上数据做对比
            localdata = JsonConvert.DeserializeObject<RepDdlData>(localdataString);
        }
        else
        {
            //本地不存在就保存这份数据到本地
            localdata = new RepDdlData();
        }
        //这里保证了localdata一定不为空了,除非线上的数据有问题
        if (data != null)
        {
            if (data.DDL_V > localdata.DDL_V || data.Belong != localdata.Belong)
            {
                //如果版本变了就更新本地配置
                Record.SetString(PrefKeys.DDL_OnlineConfig, JsonConvert.SerializeObject(data));
                localdata = data;
                localdata.ClearTurn();
                LoggerHelper.Log("DDL:配置变化本地当天当前轮数清零");
            }
        }
//        Record.SetString(PrefKeys.DDL_StoreId,localdata.StoreId);
        LoggerHelper.Log("DDL:本地ddl配置:" + localdataString);
        LoggerHelper.Log("DDL:线上ddl配置:" + JsonConvert.SerializeObject(data));
        LoggerHelper.Log("DDL:最终ddl配置:" + JsonConvert.SerializeObject(localdata));
    }
}