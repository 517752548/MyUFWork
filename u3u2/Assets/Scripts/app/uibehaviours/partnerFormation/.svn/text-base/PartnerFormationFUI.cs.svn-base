using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PartnerFormationFUI : MonoBehaviour
{
	public List<FormationListItemUI> formationListItemUIs;
	public TabButtonGroup formationListItemUIGroup;

    public void Init()
     {
        formationListItemUIs=new List<FormationListItemUI>();
        FormationListItemUI f1 = transform.Find("FormationList/FormationItem 0").gameObject.AddComponent<FormationListItemUI>();
        f1.Init();
        formationListItemUIs.Add(f1);
        FormationListItemUI f2 = transform.Find("FormationList/FormationItem 1").gameObject.AddComponent<FormationListItemUI>();
        f2.Init();
        formationListItemUIs.Add(f2);
        FormationListItemUI f3  = transform.Find("FormationList/FormationItem 2").gameObject.AddComponent<FormationListItemUI>();
        f3.Init();
        formationListItemUIs.Add(f3);
        formationListItemUIGroup = transform.Find("FormationList").gameObject.AddComponent<TabButtonGroup>();
        GameUUToggle t1 = transform.Find("FormationList/FormationItem 0/checkMark").GetComponent<GameUUToggle>();
        formationListItemUIGroup.AddToggle(t1);
        GameUUToggle t2 = transform.Find("FormationList/FormationItem 1/checkMark").GetComponent<GameUUToggle>();
        formationListItemUIGroup.AddToggle(t2);
        GameUUToggle t3 = transform.Find("FormationList/FormationItem 2/checkMark").GetComponent<GameUUToggle>();
        formationListItemUIGroup.AddToggle(t3);
    }
}
