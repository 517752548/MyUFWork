using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateBangPaiUI : MonoBehaviour
{
    public GameUUButton closeBtn;
    public Image mingchengInputBg;
    public Image zongzhiInputBg;
    public MoneyItemUI moneyItem;
    public GameUUButton quxiao;
    public GameUUButton createBangPaiBtn;
    
    public void Init()
    {
        mingchengInputBg = transform.Find("mingcheng/Image").GetComponent<Image>();
        zongzhiInputBg = transform.Find("zongzhi/Image").GetComponent<Image>();
        moneyItem = transform.Find("feiyong/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        moneyItem.Init
        (
            moneyItem.transform.Find("MoneyIcon").GetComponent<Image>(),
            moneyItem.transform.Find("MoneyValue").GetComponent<Text>(),
            null
        );
        quxiao = transform.Find("quxiao").GetComponent<GameUUButton>();
        createBangPaiBtn = transform.Find("chuangjian").GetComponent<GameUUButton>();
    }
}
