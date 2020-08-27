using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUIWithNumber : MonoBehaviour
{
    public Transform gift;
    public Text numberText;

    public void Init(GameObject giftObj, int count, Color textColor)
    {
        giftObj.transform.SetParent(gift, false);
        SetNumber(count, textColor);
    }

    public void SetNumber(int count, Color textColor)
    {
        numberText.text = "" + count;
        numberText.color = textColor;
    }
}
