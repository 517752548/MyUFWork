using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

public class ReqPetFromLineCommand : ICommand
{
    public object Data { get; set; }
    private ReqPetFromLineData m_ReqDdlData;
    private HandlePetFromLineMsg m_HandleDdlMsg;
    public void Initilize()
    {
        //Record.HasKey(PrefKeys.DDL_OnlineConfig)
        m_ReqDdlData = new ReqPetFromLineData
        {
            DeviceId = DataManager.DeviceData.DeviceId,
            Version = PlatformUtil.GetVersionCode(),
#if UNITY_ANDROID
            Platform = "android",
#elif UNITY_IOS
            Platform = "ios",
#endif
            GetType = 1,
           // StoreId = Record.GetString(PrefKeys.DDL_StoreId,""),
            PlayerTag = DataManager.BusinessData.PlayerTag
        };

        m_HandleDdlMsg = new HandlePetFromLineMsg()
        {
            OpCode = (short)OpCodes.PetFromLine
        };
        AppEngine.SNetworkManager.SetHandler(m_HandleDdlMsg);
    }

    public void Execute()
    {
        AppEngine.SNetworkManager.SetUrl(URLSetting.PetFromLine);
        AppEngine.SNetworkManager.SendMessage((short)OpCodes.PetFromLine, m_ReqDdlData);
    }

    public void Release()
    {
        AppEngine.SNetworkManager.RemoveHandler(m_HandleDdlMsg);
    }
}