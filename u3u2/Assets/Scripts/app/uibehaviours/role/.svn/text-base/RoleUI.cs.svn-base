using UnityEngine;
using UnityEngine.UI;

public class RoleUI : MonoBehaviour
{
    public TabButtonGroup tabButtonGroup;
    public GameUUButton closeBtn;
    public Text panelTitle;
    public GameObject roleInfoUI;
    public GameObject roleJiaDianUI;
    public GameObject chibangUI;

    public void Init()
    {
        tabButtonGroup = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
        GameUUToggle toggle1 = transform.Find("tabGroup/toggles/xinxi").GetComponent<GameUUToggle>();
        tabButtonGroup.AddToggle(toggle1);
        GameUUToggle toggle2 = transform.Find("tabGroup/toggles/jiadian").GetComponent<GameUUToggle>();
        tabButtonGroup.AddToggle(toggle2);
        //GameUUToggle toggle3 = transform.Find("tabGroup/toggles/chibang").GetComponent<GameUUToggle>();
        //tabButtonGroup.AddToggle(toggle3);

        closeBtn = transform.Find("closeBtn").gameObject.GetComponent<GameUUButton>();
        panelTitle = transform.Find("title").GetComponent<Text>();
        /*
        roleInfoUI = transform.Find("roleInfo").gameObject.AddComponent<RoleInfoUI>();
        roleInfoUI.Init();
        roleInfoUI.gameObject.SetActive(false);
        roleJiaDianUI = transform.Find("jiadian").gameObject.AddComponent<RoleJiaDianUI>();
        roleJiaDianUI.Init();
        roleJiaDianUI.gameObject.SetActive(false);
        chibangUI = transform.Find("chibang").gameObject.AddComponent<ChiBangInfoUI>();
        chibangUI.Init();
        chibangUI.gameObject.SetActive(false);
         */

    }
}
