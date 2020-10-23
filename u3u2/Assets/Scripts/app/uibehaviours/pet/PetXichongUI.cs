using UnityEngine;

public class PetXichongUI : UIMonoBehaviour
{
    public TabButtonGroup tabButtonGroup;
    public override void Init()
    {
        base.Init();
        tabButtonGroup = transform.Find("xichongTabGroup").gameObject.AddComponent<TabButtonGroup>();
        tabButtonGroup.Init();
        tabButtonGroup.AddToggle(tabButtonGroup.transform.Find("huantong").GetComponent<GameUUToggle>());
        tabButtonGroup.AddToggle(tabButtonGroup.transform.Find("bianyi").GetComponent<GameUUToggle>());
        tabButtonGroup.AddToggle(tabButtonGroup.transform.Find("liahua").GetComponent<GameUUToggle>());
        tabButtonGroup.AddToggle(tabButtonGroup.transform.Find("wuxing").GetComponent<GameUUToggle>());

    }

}


