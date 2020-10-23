using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleSkillListUIBehav : MonoBehaviour
{
    public GameObject autoSkillsTitleContainer;
    public Text autoSkillTitle;
    public GameObject background;
    public GameObject item;
    public GameObject leaderSkillsListContainer;
    public LayoutElement leaderSkillsListLayoutElem;
    public ScrollRect leaderSkillsListScrollRect;
    public Mask leaderSkillsListMask;
    public Image leaderSkillsListMaskImg;
    public GameObject leaderSkillsList;
    public GameObject petSkillsListContainer;
    public LayoutElement petSkillsListLayoutElem;
    public ScrollRect petSkillsListScrollRect;
    public Mask petSkillsListMask;
    public Image petSkillsListMaskImg;
    public GameObject petSkillsList;
    public GameObject atkDefList;
    public GameUUButton atkBtn;
    public GameUUButton defBtn;
    public GameObject checkMark;
    public BattleSkillDetailInfoUIBehav skillDetailInfoUI;

    public void Init()
    {
        autoSkillsTitleContainer = transform.Find("totalList/autoSkillsTitleContainer").gameObject;
        autoSkillTitle = transform.Find("totalList/autoSkillsTitleContainer/title").GetComponent<Text>();
        background = transform.Find("background").gameObject;
        item = transform.Find("item").gameObject;
        BattleSkillListItemUI itemUI = item.AddComponent<BattleSkillListItemUI>();
        itemUI.Init(
            item.transform.Find("bg").GetComponent<Image>(),
            item.transform.Find("icon").GetComponent<Image>(),
            null, null, item.transform.Find("name").GetComponent<Text>(),
            null, null, null, null, null
        );
        leaderSkillsListContainer = transform.Find("totalList/leaderSkillsListContainer").gameObject;
        leaderSkillsListLayoutElem = leaderSkillsListContainer.GetComponent<LayoutElement>();
        leaderSkillsListScrollRect = leaderSkillsListContainer.GetComponent<ScrollRect>();
        leaderSkillsListMask = leaderSkillsListContainer.GetComponent<Mask>();
        leaderSkillsListMaskImg = leaderSkillsListContainer.GetComponent<Image>();
        leaderSkillsList = transform.Find("totalList/leaderSkillsListContainer/leaderSkillsList").gameObject;

        petSkillsListContainer = transform.Find("totalList/petSkillsListContainer").gameObject;
        petSkillsListLayoutElem = petSkillsListContainer.GetComponent<LayoutElement>();
        petSkillsListScrollRect = petSkillsListContainer.GetComponent<ScrollRect>();
        petSkillsListMask = petSkillsListContainer.GetComponent<Mask>();
        petSkillsListMaskImg = petSkillsListContainer.GetComponent<Image>();
        petSkillsList = transform.Find("totalList/petSkillsListContainer/petSkillsList").gameObject;

        atkDefList = transform.Find("totalList/atkDefList").gameObject;
        atkBtn = transform.Find("totalList/atkDefList/GameObject/atkBtn").GetComponent<GameUUButton>();
        defBtn = transform.Find("totalList/atkDefList/GameObject 1/defBtn").GetComponent<GameUUButton>();
        checkMark = transform.Find("checkMark").gameObject;

        skillDetailInfoUI = transform.parent.Find("battleSkillDetailInfoUI").gameObject.AddComponent<BattleSkillDetailInfoUIBehav>();
        skillDetailInfoUI.Init();
        skillDetailInfoUI.gameObject.SetActive(false);
        item.gameObject.SetActive(false);
        checkMark.gameObject.SetActive(false);
    }
}
