using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PetRightViwerUI : MonoBehaviour
{


    public GameObject infoObj;
    public GameObject skillObj;

    public Text chengzhanglvName;
    public Text chengzhanglvValue;

    public Text wuxingLevel;
    public Text wuxingValue;

    public ProgressBar shoumingPG;

    public GridLayoutGroup petPropGrid;

    public GridLayoutGroup zizhiPgGrid;

    public GridLayoutGroup skillGrid;
    public CommonItemUI defaultSkillItem;


    public void Init()
    {
        infoObj = transform.Find("midinfo").GetComponent<UnityEngine.GameObject>();
        skillObj = transform.Find("zizhi").GetComponent<UnityEngine.GameObject>();
        chengzhanglvName = transform.Find("midinfo/label 1").GetComponent<UnityEngine.UI.Text>();
        chengzhanglvValue = transform.Find("midinfo/label 2").GetComponent<UnityEngine.UI.Text>();
        wuxingLevel = transform.Find("midinfo/label 4").GetComponent<UnityEngine.UI.Text>();
        wuxingValue = transform.Find("midinfo/label 3").GetComponent<UnityEngine.UI.Text>();
        shoumingPG = transform.Find("midinfo/shoumingchi/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        shoumingPG.Init(
            shoumingPG.transform.Find("background").GetComponent<Image>(),
            shoumingPG.transform.Find("background/foreground").GetComponent<Image>(),
            shoumingPG.transform.Find("Text").GetComponent<Text>(),
            313.12f
            );
        petPropGrid = transform.Find("prop/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        zizhiPgGrid = transform.Find("zizhi/pgGrid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        for (int i = 0; i < zizhiPgGrid.transform.childCount; i++)
        {
            Transform tfChild = zizhiPgGrid.transform.GetChild(i);
            if (tfChild)
            {
                ProgressBar bar = tfChild.gameObject.AddComponent<ProgressBar>();
                bar.Init(
                            bar.transform.Find("background").GetComponent<Image>(),
                            bar.transform.Find("background/foreground").GetComponent<Image>(),
                            bar.transform.Find("Text").GetComponent<Text>(),
                            201.6f
                    );

            }
        }

        skillGrid = transform.parent.Find("leftInfo/petList 1/Image/scrollRect/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        defaultSkillItem = transform.parent.Find("leftInfo/petList 1/Image/scrollRect/grid/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        defaultSkillItem.Init();
    }

}
