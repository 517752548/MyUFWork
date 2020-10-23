using UnityEngine;
using UnityEngine.UI;

public class QianDaoItemUI : MonoBehaviour
{
    public CommonItemUINoClick item;
    public Image duihao;
    public Text tianshu;
    public GameUUToggle toggle;
    public GameUUButton btn;

    public void Init()
    {
        item = transform.Find("CommonItemUINoClick82_82").gameObject.AddComponent<CommonItemUINoClick>();
        item.Init
        (
            item.transform.Find("Image").GetComponent<Image>(),
            item.transform.Find("Icon").GetComponent<Image>(),
            item.transform.Find("BianKuang").GetComponent<Image>(),
            item.transform.Find("Num").GetComponent<Text>(),
            //item.transform.Find("Name").GetComponent<Text>(),
            null,
            null
        );
        duihao = transform.Find("duihao").GetComponent<UnityEngine.UI.Image>();
        tianshu = transform.Find("tianshu/Text").GetComponent<UnityEngine.UI.Text>();
        toggle = transform.Find("Toggle").GetComponent<GameUUToggle>();
        btn = transform.Find("Button").GetComponent<GameUUButton>();

    }
}
