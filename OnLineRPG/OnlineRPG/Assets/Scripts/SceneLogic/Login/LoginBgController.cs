using BetaFramework;
using EventUtil;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginBgController : MonoBehaviour
{
    public bool IsDontDestroy;

    //public GameObject panel;
    private void Awake()
    {
        if (IsDontDestroy)
        {
            AppEngine.AddDontGameObject(gameObject);
        }
    }
}