using Data.Request;
using Newtonsoft.Json;
using UnityEngine;

public class WebConfig
{
    public virtual ServerCode mId { get; set; }
    public bool online = false;
    public int loadedCount = 0;

    public virtual void LoadLocalData()
    {
    }
    public virtual void SaveLocalData()
    {
    }
    public virtual object GetRequest { get; }
    public virtual WebConfig DeserializeResponse(string json)
    {
        return this;
    }

    public virtual void OnLoadComplete()
    {

    }
}
public abstract class WebConfig<T> : WebConfig
{
    class VersionData
    {
        public int version;
        public T data;
    }

    VersionData versionData;
    string prefKey => "WebConfig." + mId;
    protected virtual bool hasVersion { get; }

    public T data => versionData != null ? versionData.data : default;

    public override void LoadLocalData()
    {
        if (PlayerPrefs.HasKey(prefKey))
        {
            var json = PlayerPrefs.GetString(prefKey);
            versionData = JsonConvert.DeserializeObject<VersionData>(json);
            OnLoadComplete();
        }
    }
    public override void SaveLocalData()
    {
        var json = JsonConvert.SerializeObject(versionData);
        PlayerPrefs.SetString(prefKey, json);
        PlayerPrefs.Save();
    }

    public override object GetRequest => new BaseRequestParam(mId, versionData != null ? versionData.version : 0);

    public override WebConfig DeserializeResponse(string json)
    {
        online = true;
        var vData = JsonConvert.DeserializeObject<VersionData>(json);
        if (versionData == null || vData.version == 0 || vData.version != versionData.version)
        {
            versionData = vData;
            SaveLocalData();
        }
        loadedCount++;
        OnLoadComplete();
        return this;
    }
}
