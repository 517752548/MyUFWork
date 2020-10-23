using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShiTuUI : MonoBehaviour
{
    public GameObject shifuGo;
    public GameObject tudiGo;
    public GameObject tudiMultiGo;
    public ShiTuHeadUI shifuUI;

    public ShiTuHeadUI tudiDefaultUI;
    public GameUUButton tudiListBtn;
    public GameObject tudiListGo;
    public List<ShiTuHeadUI> tudiList;
    
    public void Init()
{
    shifuGo=transform.Find("shifuGo").gameObject;
    tudiGo=transform.Find("tudiGo").gameObject;
    tudiMultiGo=transform.Find("tudiGo/tudiList").gameObject;
    shifuUI=transform.Find("shifuGo").gameObject.AddComponent<ShiTuHeadUI>();
    shifuUI.Init(shifuUI.transform.Find("shifuIcon").GetComponent<Image>(), shifuUI.transform.Find("shifuBtn").GetComponent<GameUUButton>());

    tudiDefaultUI=transform.Find("tudiGo/defaultTudi").gameObject.AddComponent<ShiTuHeadUI>();
    tudiDefaultUI.Init(tudiDefaultUI.transform.Find("tudiIcon").GetComponent<Image>(), tudiDefaultUI.transform.Find("tudiBtn").GetComponent<GameUUButton>());
    tudiListBtn=transform.Find("tudiGo/tudiList/tudizhankaiBtn").GetComponent<GameUUButton>();
    tudiListGo=transform.Find("tudiGo/tudiList/GameObject").gameObject;
    tudiList= new List<ShiTuHeadUI>();
    ShiTuHeadUI s1 = transform.Find("tudiGo/tudiList/GameObject/defaultTudi (1)").gameObject.AddComponent<ShiTuHeadUI>();
    s1.Init(s1.transform.Find("tudiIcon").GetComponent<Image>(), s1.transform.Find("tudiBtn").GetComponent<GameUUButton>());
    ShiTuHeadUI s2 = transform.Find("tudiGo/tudiList/GameObject/defaultTudi (2)").gameObject.AddComponent<ShiTuHeadUI>();
    s2.Init(s2.transform.Find("tudiIcon").GetComponent<Image>(), s2.transform.Find("tudiBtn").GetComponent<GameUUButton>());
    ShiTuHeadUI s3 = transform.Find("tudiGo/tudiList/GameObject/defaultTudi (3)").gameObject.AddComponent<ShiTuHeadUI>();
    s3.Init(s3.transform.Find("tudiIcon").GetComponent<Image>(), s3.transform.Find("tudiBtn").GetComponent<GameUUButton>());
    tudiList.Add(s1);
    tudiList.Add(s2);
    tudiList.Add(s3);
    
    shifuGo.gameObject.SetActive(false);
    tudiDefaultUI.gameObject.SetActive(false);

}
}
