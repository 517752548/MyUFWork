using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetSkillBooksUI : UIMonoBehaviour
{
	public PetSkillBookListItemUI listItem;
    public ScrollRect scrollrect;
	public GameUUButton closeBtn;
    public override void Init()
     {
        base.Init();
    listItem=transform.Find("scrollPanel/list/item").gameObject.AddComponent<PetSkillBookListItemUI>();
    listItem.Init
    (
        listItem.transform.Find("itemBg").GetComponent<Image>(),
        listItem.transform.Find("icon").GetComponent<Image>(),
        listItem.transform.Find("biankuang").GetComponent<Image>(),
        null,
        listItem.transform.Find("bg/name").GetComponent<Text>(),
        null,
        null,
        null,
        null,
        null
    );
        listItem.btn = transform.Find("scrollPanel/list/item/bg").gameObject.GetComponent<GameUUButton>();
    scrollrect = transform.Find("scrollPanel").GetComponent<ScrollRect>();
    closeBtn=transform.Find("closeBtn").GetComponent<GameUUButton>();
    }

}
