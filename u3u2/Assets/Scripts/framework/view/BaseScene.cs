using UnityEngine;

public abstract class BaseScene : AbsMonoBehaviour
{
    public GameObject camera = null;

    public BaseScene()
    {
        
    }

    public virtual void show()
    {
        
    }

    public virtual void hide()
    {
        
    }

    /// <summary>
    /// GlobalConstDefine中定义的SceneName。
    /// </summary>
    /// <returns></returns>
    public abstract string GetName();

}