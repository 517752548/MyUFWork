using BetaFramework;

public class DeviceData : IData
{
    public void Initilize()
    {
        if (Record.HasKey(PrefKeys.DeviceId))
        {
            m_DeviceId = Record.GetString(PrefKeys.DeviceId);
        }
        else
        {
            DeviceId = PlatformUtil.GetDeviceId();
        }
    }

    private string m_DeviceId = "TestFBUser003";

    public string DeviceId
    {
        get
        {
            return m_DeviceId;
        }
        set
        {
            m_DeviceId = value;
            Record.SetString(PrefKeys.DeviceId, value);
        }
    }
}