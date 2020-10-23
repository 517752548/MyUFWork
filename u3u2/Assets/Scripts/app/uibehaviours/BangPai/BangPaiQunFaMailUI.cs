using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BangPaiQunFaMailUI : MonoBehaviour
{
    public GameUUButton closeBtn;
    public Image zhutiBg;
    public InputField zhutiInput;
    public Image neirongBg;
    public InputField neirongInput;
    public GameUUButton fasongBtn;
    
    public void Init()
    {
        closeBtn = transform.Find("Button").GetComponent<GameUUButton>();
        zhutiBg = transform.Find("zhutiBg").GetComponent<Image>();
        neirongBg = transform.Find("neirongBg").GetComponent<Image>();
        fasongBtn = transform.Find("ZZButton0").GetComponent<GameUUButton>();
    }
}
