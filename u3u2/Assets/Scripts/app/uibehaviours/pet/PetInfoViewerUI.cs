using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PetInfoViewerUI : UIMonoBehaviour
{

    public Text title;
    public GameObject petInfoLeft;
    public GameObject petInfoRight;
    public GameUUButton closeBtn;

    public override void Init()
    {
        base.Init();
        title = transform.Find("Image/Text").GetComponent<Text>();
        petInfoLeft = transform.Find("leftInfo").gameObject;
        petInfoRight = transform.Find("rightinfo").gameObject;
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
    }

}
