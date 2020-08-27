using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftErrorDialog : UIWindowBase {


    public void ClickOk()
    {
        UIManager.CloseUIWindow(this);
    }
}
