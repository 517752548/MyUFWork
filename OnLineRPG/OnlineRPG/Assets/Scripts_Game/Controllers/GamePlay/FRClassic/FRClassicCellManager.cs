using UnityEngine;
using System.Collections;
using BetaFramework;
using System.Text;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class FRClassicCellManager : ClassicCellManager
{
    //09a751aec7e6e6543a3f1b4d20a012f9
    //7f3abec7ed519b041a5c9ef32dc4287a
    public FastRaceHead _FastRaceHead;
    private GameObject FRStar;
    public override void Init()
    {
        base.Init();
        GameManager.GameTempData.isFRClassic = true;
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_FRStar, op =>
        {
            FRStar = op;
        });
    }

    protected override IEnumerator OnAnswerCorrectAniOver(List<BaseWord> words)
    {
        Debug.LogError("OnAnswerCorrectAniOver" + words.Count);
        if (AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().activityEnable)
        {
            for (int i = 0; i < words.Count; i++)
            {
                GameObject star = Instantiate(FRStar, transform, false);
                star.transform.position = words[i].GetLastCellPos();
                star.GetComponent<FRStar>().FlyToTarget(_FastRaceHead.star.position, _FastRaceHead);
            }
        }
        yield return new WaitForSeconds(1.2f);
    }



    protected override void OnWordCompleted(List<BaseWord> words)
    {
        base.OnWordCompleted(words);
    }

    protected override IEnumerator OnAnswerAniOver(List<BaseWord> words)
    {
        yield return base.OnAnswerAniOver(words);
    }
}