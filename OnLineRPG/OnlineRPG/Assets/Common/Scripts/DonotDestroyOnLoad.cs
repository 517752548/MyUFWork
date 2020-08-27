using BetaFramework;
using UnityEngine;

public class DonotDestroyOnLoad : MonoBehaviour
{
    public static DonotDestroyOnLoad instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        AppEngine.AddDontGameObject(gameObject);
    }
}