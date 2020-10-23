using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QichongShuxingUI : UIMonoBehaviour {

    public GridLayoutGroup grid;
    public Text defaultText;
    public GameUUButton buttonFasheng;
    public GameUUButton buttonQicheng;
    public Text textQicheng;


    public override void Init()
    {
        base.Init();
        grid = transform.Find("info/scroller/grid").GetComponent<GridLayoutGroup>();
        defaultText = grid.transform.Find("Text").GetComponent<Text>();
        buttonFasheng = transform.Find("Buttonfangsheng").GetComponent<GameUUButton>();
        buttonQicheng = transform.Find("Buttonqicheng").GetComponent<GameUUButton>();
        textQicheng = transform.Find("Buttonqicheng/Text").GetComponent<Text>();
    }

}
