
using UnityEngine;
using UnityEngine.UI;



public class BangPaiFuLiItemUI : MonoBehaviour
{
    public MoneyItemUI moneyItemUI;
    public GameUUButton buttonReward;
    public Text textContent;

    public void Init()
    {
        Transform tfyinpiao = transform.Find("yinpiao");
        if (tfyinpiao)
        {
            moneyItemUI = tfyinpiao.gameObject.AddComponent<MoneyItemUI>();
            moneyItemUI.Init();
        }
        buttonReward = transform.Find("Button0").GetComponent<GameUUButton>();

        Transform tftxt = transform.Find("Text_content");
        if (tftxt != null)
        {
            textContent = tftxt.GetComponent<Text>();
        }
    }
}
