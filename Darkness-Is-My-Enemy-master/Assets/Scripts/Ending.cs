using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject GameEnd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("GameOver", 5f);
        }

        
    }

    public void GameOver()
    {
        GameEnd.SetActive(true);
    }
}
