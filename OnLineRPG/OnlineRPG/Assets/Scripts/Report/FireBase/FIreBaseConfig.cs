public class FireBaseConfig
{
    public const string WeekRank_GetList_Test = "https://us-central1-wordcrossytwo.cloudfunctions.net/activeGetListsSandbox ";//测试服
    public const string WeekRank_GetList = "https://us-central1-wordcrossytwo.cloudfunctions.net/activeGetLists ";//正式服
    public const string WeekRank_Upload_Test = "https://us-central1-wordcrossytwo.cloudfunctions.net/activeUploadSandbox ";//测试服
    public const string WeekRank_Upload = "https://us-central1-wordcrossytwo.cloudfunctions.net/activeUpload";//正式服
#if UNITY_ANDROID
    public const string UserInfo = "androidUserInfo";
    public const string Message = "androidGift";
    public const string UserData = "UserData";//用户的本地存档节点
    public static string ShareURL = "http://dl.xyz.akamaized.net/mypage/WordPuzzleFbShare/index_crossy_share.php?imageUrl={0}";
    public const string SyncDataNode = "SyncDataAndroid";//同步数据节点
#if WordCrossyDE
    public const string DataURL = "https://wordcrossyde-android.firebaseio.com/";
    public const string StorageURL = "gs://wordcrossyde-android.appspot.com";
    public const string GiftURL = "https://us-central1-wordcrossyde-android.cloudfunctions.net/sendGift?";
    public const string NpcURL = "https://us-central1-wordcrossyde-android.cloudfunctions.net/checkFriends";
    public const string SyncDataFunction = "https://us-central1-wordcrossyde-android.cloudfunctions.net/updateAndroidSyncData";//正式服
    public const string UploadDataFuntion = "https://us-central1-wordcrossyde-android.cloudfunctions.net/writeAndroidSyncData";//正式服
    //public const string SyncDataFunction = "https://us-central1-windtest-e96a8.cloudfunctions.net/updateAndroidSyncData";//测试服
    //public const string UploadDataFuntion = "https://us-central1-windtest-e96a8.cloudfunctions.net/writeAndroidSyncData";//测试服
#else
    public const string DataURL = "https://wordcrossytwo.firebaseio.com/";
    public const string StorageURL = "gs://wordcrossytwo.appspot.com";
    public const string GiftURL = "https://us-central1-wordcrossytwo.cloudfunctions.net/sendGift?";
    public const string NpcURL = "https://us-central1-wordcrossytwo.cloudfunctions.net/checkFriends";
    public const string SyncDataFunction = "https://us-central1-wordcrossytwo.cloudfunctions.net/updateAndroidSyncData";//正式服
    public const string UploadDataFuntion = "https://us-central1-wordcrossytwo.cloudfunctions.net/writeAndroidSyncData";//正式服
    //public const string SyncDataFunction = "https://us-central1-windtest-e96a8.cloudfunctions.net/updateAndroidSyncData";//测试服
    //public const string UploadDataFuntion = "https://us-central1-windtest-e96a8.cloudfunctions.net/writeAndroidSyncData";//测试服
#endif
#else
    public const string DataURL = "https://wordcrossytwo.firebaseio.com/";
    public const string StorageURL = "gs://wordcrossytwo.appspot.com";
    public const string GiftURL = "https://us-central1-wordcrossytwo.cloudfunctions.net/sendGift?";
    public const string NpcURL = "https://us-central1-wordcrossytwo.cloudfunctions.net/checkFriends";
    public const string UserInfo = "androidUserInfo";
    public const string Message = "androidGift";
    public const string UserData = "UserData";//用户的本地存档节点
    public static string ShareURL = "http://dl.xyz.akamaized.net/mypage/WordPuzzleFbShare/index_crossy_share.php?imageUrl={0}";
    public const string SyncDataNode = "SyncDataIos";//同步数据节点
    public const string SyncDataFunction = "https://us-central1-wordcrossytwo.cloudfunctions.net/updateIosSyncData";//正式服
    public const string UploadDataFuntion = "https://us-central1-wordcrossytwo.cloudfunctions.net/writeIosSyncData";//正式服
    //public const string SyncDataFunction = "https://us-central1-windtest-e96a8.cloudfunctions.net/updateIosSyncData";//测试服
    //public const string UploadDataFuntion = "https://us-central1-windtest-e96a8.cloudfunctions.net/writeIosSyncData";//测试服
#endif

    public const string InternetCelebrityShareUrl = "http://dl.xyz.akamaized.net/mypage/WordPuzzleFbShare/fb_Internet_celebrity_share.php?";
    public const string Score = "score";
    public const string World = "world";
    public const string SubWorld = "subWorld";
    public const string Level = "level";
    public const string UserId = "id";
    public const string UserName = "name";
    public const string PhotoUrl = "photoUrl";
    public const string Friends = "Friends";
}