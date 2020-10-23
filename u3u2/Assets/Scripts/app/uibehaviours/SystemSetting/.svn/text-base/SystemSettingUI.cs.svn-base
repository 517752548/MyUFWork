using UnityEngine;
using UnityEngine.UI;

public class SystemSettingUI : MonoBehaviour
{
	public TabButtonGroup displayQualityTG;
	public GameUUButton okBtn;
	public GameUUButton cancelBtn;
	public GameObject infoTips;
	
	public GameUUToggle hideOthers;
    public GameUUToggle openEffects;
    public GameUUToggle playBackgroundSound;
    public GameUUToggle playEffectSound;

    public GameUUToggle shijieyuyin;
    public GameUUToggle dangqianyuyin;
    public GameUUToggle bangpaiyuyin;
    public GameUUToggle duiwuyuyin;

    public GameUUToggle battleFastForward;

    public Text banbenhao;

    public void Init()
    {
        displayQualityTG = transform.Find("displaySettingTG").gameObject.AddComponent<TabButtonGroup>();
        okBtn = transform.Find("btns/okBtn").GetComponent<GameUUButton>();
        cancelBtn = transform.Find("btns/cancelBtn").GetComponent<GameUUButton>();
        infoTips = transform.Find("infoText").gameObject;
        hideOthers = transform.Find("hideOthers").GetComponent<GameUUToggle>();
        openEffects = transform.Find("openEffects").GetComponent<GameUUToggle>();
        playBackgroundSound = transform.Find("playBackgorundSound").GetComponent<GameUUToggle>();
        playEffectSound = transform.Find("playEffectSound").GetComponent<GameUUToggle>();

        GameUUToggle toggle1 = transform.Find("displaySettingTG/Toggle").GetComponent<GameUUToggle>();
        displayQualityTG.AddToggle(toggle1);
        GameUUToggle toggle2 = transform.Find("displaySettingTG/Toggle (1)").GetComponent<GameUUToggle>();
        displayQualityTG.AddToggle(toggle2);
        GameUUToggle toggle3 = transform.Find("displaySettingTG/Toggle (2)").GetComponent<GameUUToggle>();
        displayQualityTG.AddToggle(toggle3);
        banbenhao = transform.Find("banbenhao").GetComponent<Text>();

        shijieyuyin = transform.Find("shijieyuyin").GetComponent<GameUUToggle>();
        dangqianyuyin = transform.Find("dangqianyuyin").GetComponent<GameUUToggle>();
        bangpaiyuyin = transform.Find("bangpaiyuyin").GetComponent<GameUUToggle>();
        duiwuyuyin = transform.Find("duiwuyuyin").GetComponent<GameUUToggle>();

        battleFastForward = transform.Find("battleFastForward").GetComponent<GameUUToggle>();
    }
}
