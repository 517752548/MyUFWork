using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KejuUI : MonoBehaviour {

	public GameUUButton closeBtn;
	public Text datitotalvalue ;

	public Text nowdativalue;
	public Text leftTimevalue;

	public Text getExpvalue;
	public Text getSilverValue;

	public Text questionTitle;

	public GridLayoutGroup selectBtnList;
    public List<GameUUButton> btnList; 
	public GameUUButton useitem1;
	public CommonItemUI item1;
    public Text item1Desc;

	public GameUUButton useitem2;
	public CommonItemUI item2;
    public Text item2Desc;

    public Transform tfRightItem;
    public RectTransform rectTfBg;

    public Text textTitle;
    public Text textDescriptionTitle;
    public Text textDescription;

    Camera camera;

    
    public void Init(){
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        datitotalvalue=transform.Find("leftInfo/daiTotalValue").GetComponent<Text>();
        nowdativalue=transform.Find("rightInfo1/ContentText_22").GetComponent<Text>();
        leftTimevalue=transform.Find("leftInfo/leftTimeValue").GetComponent<Text>();
        getExpvalue=transform.Find("leftInfo/GameObject/Image/getExpvalue").GetComponent<Text>();
        getSilverValue=transform.Find("leftInfo/GameObject/Image/getSilvervalue").GetComponent<Text>();
        questionTitle=transform.Find("rightInfo1/questionTitle").GetComponent<Text>();
        selectBtnList=transform.Find("rightInfo1/GameObject").GetComponent<GridLayoutGroup>();
        btnList = new List<GameUUButton>();
        btnList.Add(transform.Find("rightInfo1/GameObject/BlackTextButton1").GetComponent<GameUUButton>());
        btnList.Add(transform.Find("rightInfo1/GameObject/BlackTextButton2").GetComponent<GameUUButton>());
        btnList.Add(transform.Find("rightInfo1/GameObject/BlackTextButton3").GetComponent<GameUUButton>());
        btnList.Add(transform.Find("rightInfo1/GameObject/BlackTextButton4").GetComponent<GameUUButton>());

        useitem1=transform.Find("rightInfo1/item1/useBtn").GetComponent<GameUUButton>();
        
        item1=transform.Find("rightInfo1/item1/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        item1.Init
        (
            item1.transform.Find("Image").GetComponent<Image>(),
            item1.transform.Find("Icon").GetComponent<Image>(),
            item1.transform.Find("BianKuang").GetComponent<Image>(),
            item1.transform.Find("Num").GetComponent<Text>(),
            transform.Find("rightInfo1/item1/Name").GetComponent<Text>(),
            null, null, null, null, null
        );

        item1Desc=transform.Find("rightInfo1/item1/Name 1").GetComponent<Text>();

        useitem2=transform.Find("rightInfo1/item2/useBtn").GetComponent<GameUUButton>();
        
        item2=transform.Find("rightInfo1/item2/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        item2.Init
        (
            item2.transform.Find("Image").GetComponent<Image>(),
            item2.transform.Find("Icon").GetComponent<Image>(),
            item2.transform.Find("BianKuang").GetComponent<Image>(),
            item2.transform.Find("Num").GetComponent<Text>(),
            transform.Find("rightInfo1/item2/Name").GetComponent<Text>(),
            null, null, null, null, null
        );

        item2Desc=transform.Find("rightInfo1/item2/Name 2").GetComponent<Text>();

        tfRightItem = transform.Find("rightInfo1/item2");
        rectTfBg = transform.Find("rightInfo1/Image (4) 2") as RectTransform;
        textTitle = transform.Find("title").GetComponent<Text>();
        textDescriptionTitle = transform.Find("leftInfo/Image/BiaoTiText_22").GetComponent<Text>();
        textDescription = transform.Find("leftInfo/title").GetComponent<Text>();
        
    }

}
