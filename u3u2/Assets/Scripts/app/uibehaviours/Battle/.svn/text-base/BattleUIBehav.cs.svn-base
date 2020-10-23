using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleUIBehav : UIMonoBehaviour
{
	public GameObject manualBtns;
    public Image manualBtnsBg;
	//public GameUUButton leaderActivedSkillBtn;
	//public Image leaderActivedSkillBtnIcon;
	//public GameUUButton petActivedSkillBtn;
	//public Image petActivedSkillBtnIcon;
    public GameUUToggle autoBtn;
	public GameUUToggle manualAtkBtn;
	public GameUUToggle manualSkillBtn;
	public GameUUToggle manualDefBtn;
	public GameUUToggle manualItemsBtn;
	public GameUUToggle manualEscapeBtn;
	public GameUUToggle manualCallBtn;
	public GameUUToggle manualCatchBtn;
    
	public GameUUButton manualCancelBtn;
    
    public TabButtonGroup manualBtnsTbg;
	public GameObject autoBtns;
	public GameUUButton manualBtn;
	public GameUUButton autoLeaderSkillBtn;
	public GameUUButton autoLeaderAtkBtn;
	public GameUUButton autoLeaderDefBtn;
	public GameUUButton autoPetSkillBtn;
	public GameUUButton autoPetAtkBtn;
	public GameUUButton autoPetDefBtn;
	public Image autoLeaderSkillSign;
	public Image autoPetSkillSign;

	public Image autoLeaderSkillIcon;
	public Image autoPetSkillIcon;
	public GameObject roundNumContainer;
	public GameObject waitTimeContainer;

	public BattleSkillListUIBehav skillListUIBehav;

    public GameUUToggle JiaSuBtn;
    public GameObject JiaSuBtnDisabled;
    public GameObject JiaSuBtnDisabledX;

	public GameObject maskImage;
	
	public BattleItemListUIBehav itemListUIBehav;
	
	public GameObject selectedItemTips;
	
	public Text selectedItemName;
	
	public BattlePetListUIBehav petListUIBehav;

    public BattleFrontSkillListUIBehav leaderFrontSkills;
    public BattleFrontSkillListUIBehav petFrontSkills;

    public RectTransform tiao;
	
	//temp
	/*
	public GameObject tempContainer;
	
	public GameUUButton dL;
	public GameUUButton dR;
	public GameUUButton dT;
	public GameUUButton dB;
	
	public GameUUButton aL;
	public GameUUButton aR;
	public GameUUButton aT;
	public GameUUButton aB;
	public Text offsetValue;
	public GameUUButton start;
	*/

    public override void Init()
    {
        base.Init();
        manualBtns = transform.Find("manualButtons").gameObject;
        manualBtnsBg = manualBtns.GetComponent<Image>();
        manualBtnsTbg = manualBtns.AddComponent<TabButtonGroup>();
        autoBtn = transform.Find("manualButtons/zidong").GetComponent<GameUUToggle>();
        manualSkillBtn = transform.Find("manualButtons/jineng").GetComponent<GameUUToggle>();
        manualItemsBtn = transform.Find("manualButtons/daoju").GetComponent<GameUUToggle>();
        manualAtkBtn = transform.Find("manualButtons/gongji").GetComponent<GameUUToggle>();
        manualDefBtn = transform.Find("manualButtons/fangyu").GetComponent<GameUUToggle>();
        manualCallBtn = transform.Find("manualButtons/zhaohuan").GetComponent<GameUUToggle>();
        manualCatchBtn = transform.Find("manualButtons/buzhuo").GetComponent<GameUUToggle>();
        manualEscapeBtn = transform.Find("manualButtons/taopao").GetComponent<GameUUToggle>();

        manualBtnsTbg.AddToggle(autoBtn);
        manualBtnsTbg.AddToggle(manualSkillBtn);
        manualBtnsTbg.AddToggle(manualItemsBtn);
        manualBtnsTbg.AddToggle(manualAtkBtn);
        manualBtnsTbg.AddToggle(manualDefBtn);
        manualBtnsTbg.AddToggle(manualCallBtn);
        manualBtnsTbg.AddToggle(manualCatchBtn);
        manualBtnsTbg.AddToggle(manualEscapeBtn);
        manualBtnsTbg.UnSelectAll();
        
        //leaderActivedSkillBtn = transform.Find("manualButtons/leaderActivedSkillBtn").GetComponent<GameUUButton>();
        //leaderActivedSkillBtnIcon = transform.Find("manualButtons/leaderActivedSkillBtn/icon").GetComponent<Image>();
        //petActivedSkillBtn = transform.Find("manualButtons/petActivedSkillBtn").GetComponent<GameUUButton>();
        //petActivedSkillBtnIcon = transform.Find("manualButtons/petActivedSkillBtn/icon").GetComponent<Image>();
        /*
        autoBtn = transform.Find("manualButtons/autoBtn").GetComponent<GameUUButton>();
        manualAtkBtn = transform.Find("manualButtons/atkBtn").GetComponent<GameUUButton>();
        manualSkillBtn = transform.Find("manualButtons/manualSkillBtn").GetComponent<GameUUButton>();
        manualDefBtn = transform.Find("manualButtons/defBtn").GetComponent<GameUUButton>();
        manualItemsBtn = transform.Find("manualButtons/itemsBtn").GetComponent<GameUUButton>();
        manualEscapeBtn = transform.Find("manualButtons/escapeBtn").GetComponent<GameUUButton>();
        manualCallBtn = transform.Find("manualButtons/callBtn").GetComponent<GameUUButton>();
        manualCatchBtn = transform.Find("manualButtons/catchBtn").GetComponent<GameUUButton>();
        */

        tiao = transform.Find("tiao").GetComponent<RectTransform>();
        manualCancelBtn = transform.Find("manualCancelBtn").GetComponent<GameUUButton>();
        autoBtns = transform.Find("autoButtons").gameObject;
        manualBtn = transform.Find("autoButtons/manualBtn").GetComponent<GameUUButton>();
        autoLeaderSkillBtn = transform.Find("autoButtons/leaderAutoSkillBtn").GetComponent<GameUUButton>();
        autoLeaderAtkBtn = transform.Find("autoButtons/leaderAutoAtkBtn").GetComponent<GameUUButton>();
        autoLeaderDefBtn = transform.Find("autoButtons/leaderAutoDefBtn").GetComponent<GameUUButton>();
        autoPetSkillBtn = transform.Find("autoButtons/petAutoSkillBtn").GetComponent<GameUUButton>();
        autoPetAtkBtn = transform.Find("autoButtons/petAutoAtkBtn").GetComponent<GameUUButton>();
        autoPetDefBtn = transform.Find("autoButtons/petAutoDefBtn").GetComponent<GameUUButton>();
        autoLeaderSkillSign = transform.Find("autoButtons/leaderSign").GetComponent<Image>();
        autoPetSkillSign = transform.Find("autoButtons/petSign").GetComponent<Image>();
        autoLeaderSkillIcon = transform.Find("autoButtons/leaderAutoSkillBtn/RawImage").GetComponent<Image>();
        autoPetSkillIcon = transform.Find("autoButtons/petAutoSkillBtn/RawImage").GetComponent<Image>();
        roundNumContainer = transform.Find("roundNumContainer").gameObject;
        waitTimeContainer = transform.Find("waitTimeContainer").gameObject;
        skillListUIBehav = transform.Find("battleSkillListUI").gameObject.AddComponent<BattleSkillListUIBehav>();
        skillListUIBehav.Init();
        JiaSuBtn = transform.Find("jiasu").GetComponent<GameUUToggle>();
        JiaSuBtnDisabled = transform.Find("jiasuDisabled").gameObject;
        JiaSuBtnDisabledX = transform.Find("jiasuDisabledX").gameObject;
        maskImage = transform.Find("mskImage").gameObject;
        itemListUIBehav = transform.Find("battleItemListUI").gameObject.AddComponent<BattleItemListUIBehav>();
        itemListUIBehav.Init();
        selectedItemTips = transform.Find("selectedItemTIps").gameObject;
        selectedItemName = transform.Find("selectedItemTIps/Text (1)").GetComponent<Text>();
        petListUIBehav = transform.Find("battlePetListUI").gameObject.AddComponent<BattlePetListUIBehav>();
        petListUIBehav.Init();
        leaderFrontSkills = transform.Find("leaderFrontSkills").gameObject.AddComponent<BattleFrontSkillListUIBehav>();
        leaderFrontSkills.Init();
        petFrontSkills = transform.Find("petFrontSkills").gameObject.AddComponent<BattleFrontSkillListUIBehav>();
        petFrontSkills.Init();
        petListUIBehav.gameObject.SetActive(false);
        manualBtns.gameObject.SetActive(false);
        //roundNumContainer.gameObject.SetActive(false);
        waitTimeContainer.gameObject.SetActive(false);
        skillListUIBehav.gameObject.SetActive(false);
        //JiaSuBtn.gameObject.SetActive(false);
        maskImage.gameObject.SetActive(false);
        itemListUIBehav.gameObject.SetActive(false);
        selectedItemTips.gameObject.SetActive(false);
        tiao.gameObject.SetActive(false);
        //leaderFrontSkills.SetActive(false);
        //petFrontSkills.SetActive(false);
    }
}
