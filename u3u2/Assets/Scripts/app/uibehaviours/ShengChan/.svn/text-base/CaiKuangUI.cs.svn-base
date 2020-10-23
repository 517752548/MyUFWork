using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaiKuangUI : MonoBehaviour
{
    public PageTurner pageTurner;
    public CaiKuangDianUI leftkuang ;
    public CaiKuangDianUI rightkuang ;

    public void Init()
    {
        pageTurner = gameObject.AddComponent<PageTurner>();
        pageTurner._leftImgBtn = transform.Find("leftbtn").GetComponent<GameUUButton>();
        pageTurner._rightImgBtn = transform.Find("rightbtn").GetComponent<GameUUButton>();
        leftkuang = transform.Find("kuangUILeft").gameObject.AddComponent<CaiKuangDianUI>();
        leftkuang.Init();
        rightkuang = transform.Find("kuangUIRight").gameObject.AddComponent<CaiKuangDianUI>();
        rightkuang.Init();
    }
}
