using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CupWeeklyDialog : UIWindowBase
{
    public TextMeshProUGUI TextTime;
    public TextMeshProUGUI rankText;
    public GameObject loadingObj;
    public ScrollRect scrollView;
    public Transform content;
    public Transform fadeTopContent;
    public Transform fadeBottomContent;
    public Transform centPos;
    private Action closeCallback;
    private CanvasGroup topGroup;
    private CanvasGroup bottonGroup;
    private Transform playerTransform;
    private bool panelInited = false;
    private int currentRank;

    public override void OnOpen()
    {
        base.OnOpen();
        if (objs.Length > 0)
        {
            closeCallback = objs[0] as Action;
        }

        loadingObj.SetActive(true);
        rankText.text = "";
        AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().TimeAction += ShowTime;
        AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().GetRankList(GetRankList);
        scrollView.onValueChanged.AddListener(OnVChanged);
    }

    private void OnVChanged(Vector2 ve2)
    {
        if (!panelInited)
        {
            return;
        }

        if (playerTransform == null)
        {
            return;
        }
        if (playerTransform.position.y > bottonGroup.transform.position.y &&
            playerTransform.position.y < topGroup.transform.position.y)
        {
            topGroup.alpha = 0;
            bottonGroup.alpha = 0;
        }

        if (playerTransform.position.y > topGroup.transform.position.y)
        {
            topGroup.alpha = 1;
            bottonGroup.alpha = 0;
        }

        if (playerTransform.position.y < bottonGroup.transform.position.y)
        {
            topGroup.alpha = 0;
            bottonGroup.alpha = 1;
        }
    }

    private void ShowTime(string time)
    {
        TextTime.text = time;
    }

    private void GetRankList(RanListInfo ranklistinfo)
    {
        SetPlayers(ranklistinfo);
        AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().RefreshEnterButton();
    }

    private async void SetPlayers(RanListInfo ranklistinfo)
    {
        var my = await ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_FloatWeekendRankItem);
        var other = await ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_WeekendRankItem);
        GameObject item = null;
        for (int i = 0; i < ranklistinfo.rankingList.Count; i++)
        {
            if (ranklistinfo.rankingList[i].passportId ==
                AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value)
            {
                item = Instantiate(my, content, false);
                playerTransform = item.transform;
                item.GetComponent<FastRaceItem>().SetPlayerInfo(ranklistinfo.rankingList[i]);
                rankText.text = ranklistinfo.rankingList[i].rank.ToString();
                AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().playerRank =
                    ranklistinfo.rankingList[i].rank;

                currentRank = ranklistinfo.rankingList[i].rank;
                item = Instantiate(my, fadeTopContent, false);
                topGroup = item.AddComponent<CanvasGroup>();
                topGroup.alpha = 0;
                item.GetComponent<FastRaceItem>().SetPlayerInfo(ranklistinfo.rankingList[i]);
                item = Instantiate(my, fadeBottomContent, false);
                bottonGroup = item.AddComponent<CanvasGroup>();
                bottonGroup.alpha = 0;
                item.GetComponent<FastRaceItem>().SetPlayerInfo(ranklistinfo.rankingList[i]);
            }
            else
            {
                item = Instantiate(other, content, false);
                item.GetComponent<FastRaceItem>().SetPlayerInfo(ranklistinfo.rankingList[i]);
            }
        }

        Debug.LogError("超越动画" + DataManager.ProcessData.oldRank + "-" + currentRank);
        if (DataManager.ProcessData.oldRank != -1 && DataManager.ProcessData.oldRank > currentRank)
        {
            playerTransform.SetSiblingIndex(DataManager.ProcessData.oldRank - 1);

            //需要播放超越动画
            StartCoroutine(DoUpAnimator());
        }
        else
        {
            TimersManager.SetTimer(0.1f, () => { SetPlayerFocus(); });
            panelInited = true;
        }
    }

    /// <summary>
    /// 设置玩家居中
    /// </summary>
    private void SetPlayerFocus()
    {
        if (playerTransform != null && centPos != null)
        {
            if (playerTransform.position.y < centPos.position.y)
            {
                float distance = centPos.position.y - playerTransform.position.y;
                float targetPosY = content.transform.position.y + distance;
                Debug.LogError("目标中心点:" + targetPosY);
                content.DOMoveY(targetPosY, 0);
            }
        }
        TimersManager.SetTimer(0.1f, () =>
        {
            if (loadingObj != null)
            {
                loadingObj.SetActive(false);
            }
        });
    }

    private IEnumerator DoMovePlayer(Transform trans, float distancey, float localY, float druation)
    {
        content.DOMoveY(content.position.y - distancey, druation).SetEase(Ease.Linear);
        trans.DOLocalMoveY(trans.localPosition.y - localY, druation).SetEase(Ease.Linear);
        yield return new WaitForSeconds(druation);
    }

    private IEnumerator DoUpAnimator()
    {
        FastRaceItem playerItem = playerTransform.GetComponent<FastRaceItem>();
        playerItem.SetFadeRank(DataManager.ProcessData.oldRank - 1);
        yield return new WaitForSeconds(0.1f);
        SetPlayerFocus();
        yield return new WaitForSeconds(0.12f);
        float twoDistance = content.GetChild(0).transform.position.y -
                            content.GetChild(1).transform.position.y;
        float twoLocalDistance = content.GetChild(0).transform.localPosition.y -
                                 content.GetChild(1).transform.localPosition.y;
        scrollView.enabled = false;
        int targetIndex = currentRank - 1;
        int current = playerTransform.GetSiblingIndex();
        content.GetComponent<ContentSizeFitter>().enabled = false;
        content.GetComponent<VerticalLayoutGroup>().enabled = false;
        playerTransform.SetParent(content.parent, true);
        yield return new WaitForSeconds(0.5f);
        while (current > targetIndex)
        {
            if (current > targetIndex)
            {
                current--;
                yield return DoMovePlayer(content.GetChild(current), twoDistance, twoLocalDistance, 0.5f);
                playerItem.SetFadeRank(current + 1);
            }
        }
        playerTransform.SetParent(content, true);
        playerTransform.SetSiblingIndex(targetIndex);
        content.GetComponent<ContentSizeFitter>().enabled = true;
        content.GetComponent<VerticalLayoutGroup>().enabled = true;
        scrollView.enabled = true;
        panelInited = true;
    }

    public override void Close()
    {
        AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().TimeAction -= ShowTime;
        DataManager.ProcessData.oldRank = currentRank;
        closeCallback?.Invoke();
        base.Close();
    }

    public void ClickHelp()
    {
        //UIManager.OpenUIAsync(ViewConst.prefab_FastRaceHelpDialog, OpenType.Stack);
    }
}