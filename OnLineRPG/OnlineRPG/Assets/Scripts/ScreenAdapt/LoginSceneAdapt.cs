using UnityEngine;

public class LoginSceneAdapt : MonoBehaviour
{
    public Transform settingButtonTransform;

    private int YDirectionDistance = -50;

    private void Start()
    {
        if (XUtils.IsIphoneX())
        {
            settingButtonTransform.localPosition += new Vector3(0, YDirectionDistance, 0);
        }
    }
}