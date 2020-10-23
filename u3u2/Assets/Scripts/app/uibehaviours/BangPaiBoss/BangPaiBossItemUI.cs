using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BangPaiBossItemUI : MonoBehaviour {

    public Image img_level;
    public Text text_name;
    public Transform tfTongguo;
    public Transform tfBenzhoujisha;
    public Transform tfModelContainer;
    public Transform tfMask;
    public Text text_tiaozhancishu;
    public GameUUButton Button_item;

    public void Init()
    {
        img_level = transform.Find("Item/Image_level").GetComponent<Image>();
        text_name = transform.Find("Item/Text_name").GetComponent<Text>();
        tfTongguo = transform.Find("Item/Image_tongguo");
        tfModelContainer = transform.Find("Item/modelContainer");
        tfMask = transform.Find("Image");
        text_tiaozhancishu = transform.Find("Item/Text_cengshu_num").GetComponent<Text>();
        Button_item = transform.Find("Item").GetComponent<GameUUButton>();
        tfBenzhoujisha = transform.Find("Item/Image_benzhoujisha");

    }
}
