using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LimitTimeEnter : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private int loopcount = 3;

    private bool buyall = false;

    // Start is called before the first frame update
    void Start()
    {
        AppEngine.SSystemManager.GetSystem<BusinessSystem>().timeLoop += ShowTime;
        gameObject.SetActive(false);
    }

    private void ShowTime(string time, int lastSeconds)
    {
        if (buyall)
            return;
        loopcount++;
        if (loopcount >= 3)
        {
            if (DataManager.businessGiftData.AllGiftBuyed())
            {
                buyall = true;
                gameObject.SetActive(false);
                return;
            }
        }

        if (!DataManager.businessGiftData.LevelEnough())
        {
            gameObject.SetActive(false);
            return;
        }

        timeText.text = time;
        if (time == "00:00:00")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        AppEngine.SSystemManager.GetSystem<BusinessSystem>().timeLoop -= ShowTime;
    }
}