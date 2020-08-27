using UnityEngine;

public class InterceptKeyEvent : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        KeyEventManager.Instance.AddBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
    }

    private void OnDestroy()
    {
        KeyEventManager.Instance.RemoveBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
    }

    private bool onBackPressed()
    {
        return true;
    }

    //   // Update is called once per frame
    //   void Update () {
    //}
}