using UnityEngine;

public class PlaySceneAdapt : MonoBehaviour
{
    public RectTransform adjustUI;
    public RectTransform userGuid;

    // Use this for initialization
    private void Start()
    {
        if (XUtils.IsIphoneX())
        {
            adjustUI.offsetMax = new Vector2(adjustUI.offsetMax.x, 0);
            userGuid.offsetMax = new Vector2(userGuid.offsetMax.x, 0);
        }
    }
}