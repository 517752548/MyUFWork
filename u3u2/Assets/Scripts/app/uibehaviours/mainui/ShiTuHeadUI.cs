using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShiTuHeadUI : MonoBehaviour
{

    public Image headIcon;
    public GameUUButton headBtn;
    public void Init(Image headIcon, GameUUButton headBtn)
    {
        this.headIcon = headIcon;
        this.headBtn = headBtn;
        //headIcon = transform.Find("tudiIcon").GetComponent<RawImage>();
        //headBtn = transform.Find("tudiBtn").GetComponent<GameUUButton>();
    }

}
