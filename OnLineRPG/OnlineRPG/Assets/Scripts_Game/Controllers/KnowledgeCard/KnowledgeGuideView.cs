using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class KnowledgeGuideView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TimersManager.SetTimer(2, RemoveSelf);
    }

    private void RemoveSelf()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        TimersManager.ClearTimer(RemoveSelf);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}