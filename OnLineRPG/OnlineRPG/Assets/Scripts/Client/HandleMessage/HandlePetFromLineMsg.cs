using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

public class HandlePetFromLineMsg : IPacketHandler
{
    public short OpCode { get; set; }
    /// <summary>
    /// </summary>
    public void Handle(IIncommingMessage message)
    {
        Debug.LogError(message.ToString());
        var data = message.Deserialize<RepPetFromLinePacket>();
        if (data.code == (int)RepCodes.SUCCESSED)
        {
            Debug.LogError(message.ToString());
            //DataManager.CollectPetThemesDataList.AnsyFromLine(data.data.PetSystem);

        }
        else if (data.code == (int)RepCodes.ERROR_PLAYER)
        {
        }
        else
        {
            LoggerHelper.ErrorFormat("OpCode {0} response error, error code {1}", OpCode, data.code);
        }
    }

    
}