using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using DG.Tweening;
using Random = UnityEngine.Random;

public class DestroyAfterTime : MonoBehaviour
{
    public float time;
    public Transform coin;
    public float offsetx = 0;
    
    private Vector3 rotrandom;

    public Transform content;

    private int rotSpeed = 0;

    private float rotAngle = 5;
    private bool rotate = true;

    
    private void Start()
    {
        rotrandom = new Vector3(Random.Range(-1.0f,1f),Random.Range(-1.0f,1f),Random.Range(-1.0f,1f));
        rotSpeed = Random.Range(15, 20);
        if (coin != null)
        {
            coin.localPosition += new Vector3(0,0,-300);
            coin.DOScale(Vector3.one*500, 0.3f).OnComplete(() =>
            {
                rotate = false;
                coin.localRotation = Quaternion.identity;
                coin.DOScale(Vector3.one * 300, 0.2f);
            });
            coin.localScale = new Vector3(450,450,450);
            RandomMove();
        }
        
        
        Destroy(gameObject, time);
    }
    

    void RandomMove()
    {
        coin.DOLocalMoveX(offsetx, 0.4f);
        coin.DOLocalMoveX(0, 0.3f).SetDelay(0.4f);
    }
    void Update () {
        if(rotate && coin)
        coin.Rotate( rotrandom* rotSpeed * Time.deltaTime, rotAngle);
    }
}
