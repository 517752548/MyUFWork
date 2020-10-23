using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QianDaoUI : UIMonoBehaviour
{
    public QianDaoItemUI defaultQianDaoItem;
    public GridLayoutGroup itemGrid;
    public Text leijiTianshu;
    public Text buqiancishu;
    public GameUUButton buqian;
    public GameUUMask itemsMask;

    public override void Init()
    {
        base.Init();
        defaultQianDaoItem = transform.Find("ImageMask/scrollRect/itemGrid/dayItem").gameObject.AddComponent<QianDaoItemUI>();
        defaultQianDaoItem.Init();
        itemGrid = transform.Find("ImageMask/scrollRect/itemGrid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        leijiTianshu = transform.Find("leijiTianshu").GetComponent<UnityEngine.UI.Text>();
        buqiancishu = transform.Find("buqianCishu").GetComponent<UnityEngine.UI.Text>();
        buqian = transform.Find("buqian").GetComponent<GameUUButton>();
        itemsMask = transform.Find("ImageMask").GetComponent<GameUUMask>();
        defaultQianDaoItem.gameObject.SetActive(false);

    }
}
