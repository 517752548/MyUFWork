using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SdkConst
{

    #if UNITY_ANDROID
        public const string FtdAppId = "100083";

    public const string FtdIosKey = "9ffdff14eda27e4f3c2ca4239b3a8332";

    public const string FtdsignWay = "avst";
#elif UNITY_IOS
    public const string FtdAppId = "100084";

    public const string FtdIosKey = "1ef2a4feb297b52bb86356c4fc89124a";

    public const string FtdsignWay = "avst";
    #endif

}
