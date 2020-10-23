using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MoZuFubenUI:MonoBehaviour
{
    public Text wndTitle;
    public GameUUButton closeBtn;

    public Text putongName;
    public Image putongImage;
    public Text putongLevel;
    public Text putongDesc;
    public GameUUButton enterputongFuben;

    public Text kunnanName;
    public Image kunnanImage;
    public Text kunnanLevel;
    public Text kunnanDesc;
    public GameUUButton enterkunnanFuben;

    public void Init()
    {

        wndTitle = transform.Find("titleBg/title").GetComponent<Text>();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();

        putongName = transform.Find("mozu/putong/Imagename/Text").GetComponent<Text>();
        putongImage = transform.Find("mozu/putong/Image").GetComponent<Image>();
        putongLevel = transform.Find("mozu/putong/level/Text").GetComponent<Text>();
        putongDesc = transform.Find("mozu/putong/desc/Text").GetComponent<Text>();
        enterputongFuben = transform.Find("mozu/putong/enterFuben").GetComponent<GameUUButton>();

        kunnanName = transform.Find("mozu/kunnan/Imagename/Text").GetComponent<Text>();
        kunnanImage = transform.Find("mozu/kunnan/Image").GetComponent<Image>();
        kunnanLevel = transform.Find("mozu/kunnan/level/Text").GetComponent<Text>();
        kunnanDesc = transform.Find("mozu/kunnan/desc/Text").GetComponent<Text>();
        enterkunnanFuben = transform.Find("mozu/kunnan/enterFuben").GetComponent<GameUUButton>();

        putongImage.gameObject.SetActive(false);
        kunnanImage.gameObject.SetActive(false);
    }

}
