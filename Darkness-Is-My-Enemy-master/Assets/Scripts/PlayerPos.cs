using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()    
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }
}
