using UnityEngine;

public class QuitDialog : UIWindowBase
{
    public void OnQuit()
    {
        Application.Quit();
    }
}