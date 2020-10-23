using app.human;
using app.model;
using app.chat;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using minijson;

/// <summary>
/// 客户端缓存数据管理
/// </summary>
public class PlayerDataManager
{
    private static PlayerDataManager _ins;

    public PlayerDataManager()
    {
        Init();
    }

    public static PlayerDataManager Ins
    {
        get
        {
            if (_ins == null)
            {
                //_ins = Singleton.getObj(typeof(PlayerDataManager)) as PlayerDataManager;
                _ins = new PlayerDataManager();
            }
            return _ins;
        }
    }
    /// <summary>
    /// 数据字典
    /// </summary>
    private Dictionary<string, PlayerData> playerDataDic;
    public Dictionary<string, PlayerData> PlayerDataDic
    {
        get { return playerDataDic; }
        set { playerDataDic = value; }
    }
    /// <summary>
    /// 列表数据字典
    /// </summary>
    private Dictionary<string, PlayerDataList> playerDataListDic;
    public Dictionary<string, PlayerDataList> PlayerDataListDic
    {
        get { return playerDataListDic; }
        set { playerDataListDic = value; }
    }
    
    private LoginModel loginModel = null;

    /// <summary>
    /// 检查是否更换用户,更换了用户，清空所有缓存数据
    /// </summary>
    public bool CheckRoleChange()
    {
        PlayerData accountData = GetPlayerData(PlayerDataKeyDef.ACCOUNT_DATA);
        string storedroleuuid = accountData.getData(PlayerDataKeyDef.ACCOUNT_DATA_UUID);
        string currentroleuuid = Human.Instance.Id.ToString();
        if (storedroleuuid != currentroleuuid)
        {
            //换了账号
			string GameDoAccount = PlayerPrefs.GetString("GameDoAccount");
			string GameDopwd = PlayerPrefs.GetString("GameDopwd");

            PlayerPrefs.DeleteAll();
            if(!string.IsNullOrEmpty(GameDoAccount)){
				PlayerPrefs.SetString("GameDoAccount",GameDoAccount);
				PlayerPrefs.SetString("GameDopwd",GameDopwd);
			}
			if (loginModel == null)
            {
                //loginModel = Singleton.getObj(typeof(LoginModel)) as LoginModel;
                loginModel = LoginModel.Ins;
            }
            accountData.addData(PlayerDataKeyDef.ACCOUNT_DATA_NAME, loginModel.LoginName);
            accountData.addData(PlayerDataKeyDef.ACCOUNT_DATA_PWD, loginModel.LoginPwd);
            accountData.addData(PlayerDataKeyDef.ACCOUNT_DATA_UUID, currentroleuuid);
            SaveData(PlayerDataKeyDef.ACCOUNT_DATA, accountData);
            //PlayerPrefs.SetString(PlayerDataKeyDef.ACCOUNT_DATA_NAME, loginModel.LoginName);
            //PlayerPrefs.SetString(PlayerDataKeyDef.ACCOUNT_DATA_PWD, loginModel.LoginPwd);
            //PlayerPrefs.SetString(PlayerDataKeyDef.ACCOUNT_DATA_UUID, Human.Instance.Id.ToString());
            return true;
        }
        return false;
    }

    public void Init()
    {
        //单数据字典
        playerDataDic = new Dictionary<string, PlayerData>();
        playerDataDic.Add(PlayerDataKeyDef.ACCOUNT_DATA,new PlayerData());
        playerDataDic.Add(PlayerDataKeyDef.CUSTOM_DATA,new PlayerData());

        //列表数据字典
        playerDataListDic = new Dictionary<string, PlayerDataList>();
        playerDataListDic.Add(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA, new PlayerDataList(ChatModel.MAX_LIANXIREN_LEN));
        playerDataListDic.Add(PlayerDataKeyDef.KUANGDIAN_DATA, new PlayerDataList(ShengChanModel.MAX_KUANG_DIAN_NUM));
    }

    /// <summary>
    /// 读取缓存的 列表数据
    /// </summary>
    public PlayerDataList GetPlayerDataList(string playerdatakey)
    {
        PlayerDataList dataList = null;
        if (playerDataListDic.ContainsKey(playerdatakey))
        {
            playerDataListDic.TryGetValue(playerdatakey, out dataList);
        }
        if (dataList != null && dataList.List == null)
        {
            //取出数据
            string dataJson = PlayerPrefs.GetString(playerdatakey);
            if (!string.IsNullOrEmpty(dataJson))
            {
                IList list = (IList)Json.Deserialize(dataJson);
                for (int i = 0; list != null && i < list.Count; i++)
                {
                    if (list[i] is IDictionary)
                    {
                        PlayerData playerdata = new PlayerData();
                        playerdata.setData((IDictionary)list[i]);
                        dataList.addData(playerdata);
                    }
                }
            }
        }
        
        return dataList;
    }

    /// <summary>
    /// 读取缓存的 数据
    /// </summary>
    public PlayerData GetPlayerData(string playerdatakey)
    {
        PlayerData playerdata = null;
        if (playerDataDic.ContainsKey(playerdatakey))
        {
            playerDataDic.TryGetValue(playerdatakey, out playerdata);
        }
        if (playerdata != null && playerdata.Dic == null)
        {
            //取出数据
            string dataJson = PlayerPrefs.GetString(playerdatakey);
            if (!string.IsNullOrEmpty(dataJson))
            {
                IDictionary datadic = (IDictionary)Json.Deserialize(dataJson);
                if (datadic != null)
                {
                    playerdata.setData((IDictionary)datadic);
                }
            }
        }
        return playerdata;
    }

    /// <summary>
    /// 存储 数据
    /// </summary>
    public void SaveData(string playerdatakey, PlayerData playerdata)
    {
        if (playerDataDic.ContainsKey(playerdatakey))
        {
            playerDataDic[playerdatakey] = playerdata;
            PlayerPrefs.SetString(playerdatakey, Json.Serialize(playerdata.Dic));
        }
        else if (PlayerDataListDic.ContainsKey(playerdatakey))
        {
            PlayerDataList list = GetPlayerDataList(playerdatakey);
            if (list.List != null && list.List.Contains(playerdata))
            {
                list.List.Remove(playerdata);
            }
            list.addData(playerdata);
            string str = Json.Serialize(list.ListDic());
            PlayerPrefs.SetString(playerdatakey, str);
        }
    }
    /// <summary>
    /// 保存整个数据列表
    /// </summary>
    /// <param name="playerdatakey"></param>
    /// <param name="playerdatalist"></param>
    public void SaveDataList(string playerdatakey, PlayerDataList playerdatalist)
    {
        if (PlayerDataListDic.ContainsKey(playerdatakey))
        {
            PlayerDataListDic[playerdatakey] = playerdatalist;
            string str = Json.Serialize(playerdatalist.ListDic());
            PlayerPrefs.SetString(playerdatakey, str);
        }
    }

}
