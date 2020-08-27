using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyText : MonoBehaviour
{
    public GameObject circleEffect;
    public GameObject textcell;
    public Transform content;
    public Image BackgroundImage;
    public CanvasGroup BackgroundCanvasgroup;
    private List<GameObject> textlist = new List<GameObject>();

    public void SetWord(string str, float weight)
    {
        content.GetComponent<HorizontalLayoutGroup>().enabled = true;

        GameObject textcellone = null;
        for (int i = 0; i < str.Length; i++)
        {
            textcellone = Instantiate(textcell);
            textcellone.transform.SetParent(content, false);
            textcellone.GetComponent<Text>().text = str[i].ToString();
            textlist.Add(textcellone);
        }
        BackgroundImage.GetComponent<RectTransform>().sizeDelta = new Vector2(weight * 0.8f, BackgroundImage.GetComponent<RectTransform>().sizeDelta.y * 0.8f);
    }

    public void DoGoCenter(Action act, Action compelete)
    {
        //bool effect = false;

        int myVector = 0;
        DOTween.To(() => myVector, x => myVector = x, 100, 1.15f).OnComplete(() =>
         {
             act.Invoke();
         });
        float posx = content.GetComponent<RectTransform>().sizeDelta.x * 0.5f;
        BackgroundCanvasgroup.DOFade(0, 0.15f).SetDelay(1.0f);
        bool times = true;
        for (int i = 0; i < textlist.Count; i++)
        {
            textlist[i].transform.DOLocalMoveX(0, 0.15f).SetDelay(1.0f).OnStart(() =>
            {
                DisAbleText();
                content.GetComponent<HorizontalLayoutGroup>().enabled = false;
            }).OnComplete(() =>
            {
                if (times)
                {
                    compelete.Invoke();
                    times = false;
                }
            });
        }
    }

    public void ShowEffects()
    {
        circleEffect.SetActive(true);
    }

    public void DisAbleText()
    {
        for (int i = 0; i < textlist.Count; i++)
        {
            textlist[i].GetComponent<Text>().DOFade(0, 0.15f).SetDelay(0.15f);
        }
    }

    public GameObject[] EffectsObjects;

    public void EffectDoRotate()
    {
        circleEffect.transform.DORotate(new Vector3(0, 0, 180), 1f);
    }

    public void EffectDoScaleZero()
    {
        Destroy(gameObject);
    }
}