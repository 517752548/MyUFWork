using UnityEngine;

public class PopUseUI : UIMonoBehaviour
{
    public GameUUButton useBtn;
    public GameUUButton close;
    public CommonItemUINoClick item;

    public override void Init()
    {
        base.Init();
        useBtn = transform.Find("layout/useBtn").GetComponent<GameUUButton>();
        close = transform.Find("layout/close").GetComponent<GameUUButton>();
        item = transform.Find("layout/CommonItemUI80_80").gameObject.AddComponent<CommonItemUINoClick>();
        item.Init();
        //item.num.gameObject.SetActive(false);
    }
}
