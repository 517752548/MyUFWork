using UnityEngine;

public class AdjusUIForSpecialResolution : MonoBehaviour
{
    public int YDirectionDistance = -50;

    // Use this for initialization
    private void Start()
    {
        if (XUtils.IsIphoneX())
        {
            if (transform != null)
            {
                transform.localPosition += new Vector3(0, YDirectionDistance, 0);
            }
        }
    }
}