using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingPanelUI : MonoBehaviour
{
    public RawImage loadingbg;
    public Text loadingText;
    public ProgressBar loadingPG;
    
    public void Init(){
        loadingbg = transform.Find("Image").GetComponent<RawImage>();
        loadingText=transform.Find("progressbar/Text").GetComponent<Text>();
        
        loadingPG=transform.Find("progressbar").gameObject.AddComponent<ProgressBar>();
        loadingPG.Init
        (
            loadingPG.transform.Find("background").GetComponent<Image>(), 
            loadingPG.transform.Find("background/foreground").GetComponent<Image>(), 
            loadingPG.transform.Find("Text").GetComponent<Text>(), 776
        );
        loadingPG.LabelType = ProgressBarLabelType.NoModify;
    }

}
