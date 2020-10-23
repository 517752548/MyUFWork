using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TongTianTaUI : MonoBehaviour {

    //public BattleSkillListUIBehav battleSkillListUI;
    //public GameUUButton playerSkillBtn;
    //public Text textPlayerSkill;
    //public Image imagePlayerSkill;
    //public GameUUButton petSkillBtn;
    //public Text textPetSkill;
    //public Image imagePetSkill;
    //public GameObject skillMaskImage;
    public GameUUButton closeBtn;

    //public Text textDoubleReward;
    //public GameUUButton kaiqiBtn;
    //public Text doubleText;
    public GameUUButton shuomingBtn;
    public GameUUButton chakanjiangliBtn;
    //public GameUUButton yuandiguajiBtn;

    public FloorItemUI[] floorItemUIs = new FloorItemUI[4];
    public GameUUButton btn_leftArrow;
    public GameUUButton btn_rightArrow;

    public GameObject objJiangLi;


    public void Init()
    {
        //battleSkillListUI = transform.Find("battleSkillListUI").gameObject.AddComponent<BattleSkillListUIBehav>();
        //battleSkillListUI.Init();
        //playerSkillBtn = transform.Find("battleSkillBtns/playerSkillItem/playerSkillBtn").GetComponent<GameUUButton>();
        //imagePlayerSkill = transform.Find("battleSkillBtns/playerSkillItem/icon").GetComponent<Image>();
        //textPlayerSkill = transform.Find("battleSkillBtns/playerSkillItem/playerSkillBtn/Text_skillName").GetComponent<Text>();
        //petSkillBtn = transform.Find("battleSkillBtns/petSkillItem/petSkillBtn").GetComponent<GameUUButton>();
        //imagePetSkill = transform.Find("battleSkillBtns/petSkillItem/icon").GetComponent<Image>();
        //textPetSkill = transform.Find("battleSkillBtns/petSkillItem/petSkillBtn/Text_skillName").GetComponent<Text>();
        //skillMaskImage = transform.Find("mskImage").gameObject;
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        //textDoubleReward = transform.Find("InputTextUI/shuangbeiDianshu").GetComponent<Text>();
        //kaiqiBtn = transform.Find("Button_shuangbei").GetComponent<GameUUButton>();
        //doubleText = kaiqiBtn.transform.Find("name").GetComponent<Text>();
        shuomingBtn = transform.Find("Button_shuoming").GetComponent<GameUUButton>();
        chakanjiangliBtn = transform.Find("Button_chakanjiangli").GetComponent<GameUUButton>();
        //yuandiguajiBtn = transform.Find("Button_yuandiguaji").GetComponent<GameUUButton>();

        string itemName = "grid/tongtiantaItem_";
        for (int i = 0; i < 4; i++)
        {
            FloorItemUI item = transform.Find(itemName + (i+1)).gameObject.AddComponent<FloorItemUI>();
            item.Init();
            floorItemUIs[i] = item;
        }

        btn_leftArrow = transform.Find("btn_leftArrow").GetComponent<GameUUButton>();
        btn_rightArrow = transform.Find("btn_rightArrow").GetComponent<GameUUButton>();
    }
}
