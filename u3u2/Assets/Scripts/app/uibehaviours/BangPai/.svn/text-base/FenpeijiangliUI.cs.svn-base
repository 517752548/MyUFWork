using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FenpeijiangliUI : MonoBehaviour 
{
    public GameUUButton btnClose;
    public ToggleGroup toggleGroup;
    public Toggle toggle_jin;
    public Toggle toggle_yin;
    public Toggle toggle_tie;
    public GameUUButton btnFenpei;
    public GameObject fenpeiquedingObj;
    public Text text_fenpei;
    public GameUUButton btn_fenpeiQueding;
    public GameUUButton btn_fenpeiquxiao;
    public Text text_jinRemin;
    public Text text_yinRemin;
    public Text text_tieRemin;
    public void Init()
    {
        btnClose = transform.Find("btnClose").GetComponent<GameUUButton>();
        toggleGroup = transform.Find("toggleGroup").GetComponent<ToggleGroup>();
        toggle_jin = transform.Find("toggleGroup/Toggle_jin").GetComponent<Toggle>();
        toggle_yin = transform.Find("toggleGroup/Toggle_yin").GetComponent<Toggle>();
        toggle_tie = transform.Find("toggleGroup/Toggle_tie").GetComponent<Toggle>();
        btnFenpei = transform.Find("Button0").GetComponent<GameUUButton>();
        fenpeiquedingObj = transform.Find("fenpeiqueding").gameObject;
        text_fenpei = transform.Find("fenpeiqueding/Text_content").GetComponent<Text>();
        btn_fenpeiQueding = transform.Find("fenpeiqueding/Button_queding").GetComponent<GameUUButton>();
        btn_fenpeiquxiao = transform.Find("fenpeiqueding/Button_quxiao").GetComponent<GameUUButton>();
        text_jinRemin = transform.Find("toggleGroup/Toggle_jin/Label").GetComponent<Text>();
        text_yinRemin = transform.Find("toggleGroup/Toggle_yin/Label").GetComponent<Text>();
        text_tieRemin = transform.Find("toggleGroup/Toggle_tie/Label").GetComponent<Text>();
    }

}
