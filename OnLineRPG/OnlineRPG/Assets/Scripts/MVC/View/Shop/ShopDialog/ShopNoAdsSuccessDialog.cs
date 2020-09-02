using UnityEngine.UI;

public class ShopNoAdsSuccessDialog : UIWindowBase
{
    public override void OnOpen()
    {
        base.OnOpen();
        GetComponentInChildren<Button>().onClick.AddListener(Close);
    }

    public override void OnClose()
    {
        GetComponentInChildren<Button>().onClick.RemoveListener(Close);
        base.OnClose();
    }
}