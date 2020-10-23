using app.db;
using UnityEngine;
using UnityEngine.UI;

public class TeamPurposeButtonUI : MonoBehaviour
{
	public int teamPurposeId;
	public string teamPurposeName;
	public int typeId;
	public string typeName;

	public Text mainLabel;
	public Text multLabelMain;
	public Text multLabelSub;

	public TeamPurposeButtonUI parent;
	public TeamPurposeButtonDropDownListUI childList;

	public GameObject checkMark;

	public GameObject deng;

    public void Init(Text mainLabel, Text multLabelMain, Text multLabelSub, GameObject checkMark, GameObject deng)
    {
		this.mainLabel = mainLabel;
		this.multLabelMain = multLabelMain;
		this.multLabelSub = multLabelSub;
		this.checkMark = checkMark;
		this.deng =deng;
        //mainLabel = transform.Find("SingleText").GetComponent<Text>();
        //multLabelMain = transform.Find("DoubleTextMain").GetComponent<Text>();
        //multLabelSub = transform.Find("DoubleTextSub").GetComponent<Text>();
        //deng = transform.Find("Image").gameObject;
    }
}
