using BetaFramework;
using System.Collections.Generic;

public static class LanguageManager
{
    private static string m_LanguageTextAsset = "EN_Google Sheets";

    private static Dictionary<string, string> m_CurrentEntryData = new Dictionary<string, string>();

    public static void Init()
    {
        LanguageConfig config = PreLoadManager.GetPreLoad<LanguageConfig>(PreLoadConst.preload_Asset, ViewConst.asset_LanguageConfig_EnConfig);

        for (int i = 0; i < config.dataList.Count; i++)
        {
            LanguageConfig_Data entity = config.dataList[i];
            if (!m_CurrentEntryData.ContainsKey(entity.LanguageKey))
                m_CurrentEntryData.Add(entity.LanguageKey, entity.Content);
        }
    }

    public static string Get(string key)
    {
        if (m_CurrentEntryData.ContainsKey(key))
        {
            string str = m_CurrentEntryData[key];
            if (str is string)
            {
                str = str.Replace("\\n", "\n");
            }
            return str;
        }

        return key;
    }
}