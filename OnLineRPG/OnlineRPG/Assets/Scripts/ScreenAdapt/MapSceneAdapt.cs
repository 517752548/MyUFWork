using UnityEngine;

public class MapSceneAdapt : MonoBehaviour
{
    public Transform settingTransform;
    public Transform MapButtonList;

    private int YDirectionDistance = -50;

    private void Start()
    {
        if (XUtils.IsIphoneX())
        {
            if (settingTransform)
                settingTransform.localPosition += new Vector3(0, YDirectionDistance, 0);
            if (MapButtonList)
                MapButtonList.localPosition += new Vector3(0, YDirectionDistance, 0);
        }
    }
}