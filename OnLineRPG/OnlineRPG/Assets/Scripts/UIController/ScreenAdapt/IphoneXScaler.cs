using UnityEngine;

public class IphoneXScaler : MonoBehaviour
{
    public Transform[] uptrans;
    public Transform[] downtrans;
    public Transform[] downtransmore;
    public Transform[] rightandleftbutton;
    public Transform[] TipsTransforms;
    public Transform hint;
    public Transform shuffe;
    public Transform setting;
    public Transform WordRegionTransform;
    public Transform HomeScoreTransform;
    public Transform DailyScoreTransform;
    public Transform RewordVideoTransform;
    public Transform ShopButtonLimitSaleTransform;
    public Transform RemoveAdsGuideTransform;

    // Use this for initialization
    private void Start()
    {
        // return;
        int weight = Screen.width;
        int hight = Screen.height;
        if (weight == 1125 && hight == 2436)
        {
            hint.localPosition += new Vector3(0, 120, 0);
            shuffe.localPosition += new Vector3(0, -120, 0);
            setting.localPosition += new Vector3(0, 50, 0);
            ShopButtonLimitSaleTransform.localPosition -= new Vector3(0, 50, 0);
            WordRegionTransform.localPosition += new Vector3(0, -108, 0);
            HomeScoreTransform.localPosition += new Vector3(0, 14, 0);
            RemoveAdsGuideTransform.localPosition += new Vector3(0, 140, 0);
            for (int i = 0; i < uptrans.Length; i++)
            {
                uptrans[i].localPosition += new Vector3(0, -50, 0);
            }
            for (int i = 0; i < downtrans.Length; i++)
            {
                downtrans[i].localPosition += new Vector3(0, 60, 0);
            }
            for (int i = 0; i < downtransmore.Length; i++)
            {
                downtransmore[i].localPosition += new Vector3(0, 110, 0);
            }
            for (int i = 0; i < rightandleftbutton.Length; i++)
            {
                rightandleftbutton[i].localPosition += new Vector3(0, 70, 0);
            }
            for (int i = 0; i < TipsTransforms.Length; i++)
            {
                TipsTransforms[i].localPosition += new Vector3(0, -80, 0);
            }
            DailyScoreTransform.localPosition += new Vector3(0, 60, 0);
            RewordVideoTransform.localPosition += new Vector3(0, 160, 0);
        }
    }
}