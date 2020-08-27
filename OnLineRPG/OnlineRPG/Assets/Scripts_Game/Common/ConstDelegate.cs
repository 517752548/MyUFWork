using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstDelegate 
{

    public delegate void RewardCallBack();

    public delegate void NetErrorCallBack(int callback);
    
    public delegate void PlayerSelect(bool callback);
    
    public delegate void CloseUI();
}
