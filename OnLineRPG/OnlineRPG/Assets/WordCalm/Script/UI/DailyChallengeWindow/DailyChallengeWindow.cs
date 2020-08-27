using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using Newtonsoft.Json;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DailyChallengeWindow : UIWindowBase
{
    public Text todayDayText;
    public Animator[] wheel;

    public Transform runArrow;
    public GameObject PlayButton;
    public Transform[] content;
    private List<int> todaycategory = new List<int>(3);


    /// <summary>
    /// 转几圈之后转到这个目标上
    /// </summary>
    private int random1 = 0;

    private int random2 = 0;

    private int random3 = 0;

    private float timeDistance = 0.1f;

    private int CdTimes = 2;
    private int currentCDTimes = 0;
    private int currentIndex = -1;
    private List<int> rotedIndex = new List<int>();

    //UI的初始化请放在这里
    public override void OnOpen()
    {
        PlayButton.SetActive(false);
        todayDayText.text = string.Format("{0}", AppEngine.STimeHeart.RealTime.ToString("dd"));
        List<int> todayCategory = AppEngine.SSystemManager.GetSystem<DailySystem>().GetTodayLevelCategory();
        if (todayCategory.Count > 0 && false)
        {
            for (int i = 0; i < todayCategory.Count; i++)
            {
                wheel[todayCategory[i]].SetTrigger("finish");
            }

            StartCoroutine(FinishWheelLoop());
        }
        else
        {
            random1 = 3;
            random2 = 1;
            random3 = 1;
            AppEngine.SSystemManager.GetSystem<DailySystem>().CreateTodayLevelCategory((ok) =>
            {
                if (ok)
                {
                    todayCategory = AppEngine.SSystemManager.GetSystem<DailySystem>().GetTodayLevelCategory();
                    if (todayCategory.Count < 3)
                    {
                        LoggerHelper.Error("失败");
                        ConstDelegate.NetErrorCallBack error = NetErrorCallback;
                        //获取失败
                        UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, error);
                        return;
                    }
                    todayCategory = TransDailyIndex(todayCategory);
                    LoggerHelper.Log("今天的类型:" + JsonConvert.SerializeObject(todayCategory));
                    for (int i = 0; i < todayCategory.Count; i++)
                    {
                        todaycategory.Add((int) todayCategory[i] - 1);
                    }

                    try
                    {
                        //这里在用户打开后立马关闭 有可能出现报错，虽然不影响继续玩
                        StartAnimator();
                    }
                    catch (Exception e)
                    {
                    }
                    
                }
                else
                {
                    LoggerHelper.Error("失败");
                    ConstDelegate.NetErrorCallBack error = NetErrorCallback;
                    //获取失败
                    UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, error);
                }
            });
        }
    }

    private void NetErrorCallback(int back)
    {
        UIManager.CloseUIWindow(this);
    }

    private void Awake()
    {
    }

    private void StartRun(float delay, float rot, float duration, int currentTurn, Action callback)
    {
        runArrow.DORotate(new Vector3(0, 0, rot), duration * 0.6f, RotateMode.FastBeyond360).OnUpdate(() =>
            {
                if (currentCDTimes >= CdTimes)
                {
                    currentCDTimes = 0;
                    int index = FindIndex(runArrow.rotation.eulerAngles.z);
                    if (currentIndex != index)
                    {
                        if (!rotedIndex.Contains(index))
                        {
                            wheel[index].SetTrigger("flash");
                            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_wheel_run);
                        }

                        currentIndex = index;
                    }
                }
                else
                {
                    currentCDTimes++;
                }
            })
            .SetEase(Ease.InOutSine).OnComplete(() =>
            {
                wheel[todaycategory[currentTurn]].SetTrigger("finish");
                callback.Invoke();
            }).SetDelay(delay);
    }

    public override void OnCompleteEnterAnim()
    {
        base.OnCompleteEnterAnim();
    }

    //请在这里写UI的更新逻辑，当该UI监听的事件触发时，该函数会被调用
    public override void OnRefresh()
    {
    }

    private void StartAnimator()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_wheel_run);
        int[] circle1 = GetRandomRot(todaycategory[0], random1);
        StartRun(0.5f, circle1[0], (-circle1[0]) / (float) 360, 0, () =>
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_wheel_onepart);
            LoadItem(todaycategory[0], content[0]);
            rotedIndex.Add(todaycategory[0]);
            int[] circle2 = GetRandomRot(todaycategory[1], random2);
            StartRun(0.5f, circle2[0], -(circle2[0] - (360 + circle1[1])) / (float) 360, 1, () =>
            {
                AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_wheel_onepart);
                LoadItem(todaycategory[1], content[1]);
                rotedIndex.Add(todaycategory[1]);
                int[] circle3 = GetRandomRot(todaycategory[2], random3);
                StartRun(0.5f, circle3[0], -(circle3[0] - (360 + circle2[1])) / (float) 360, 2, () =>
                {
                    AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_wheel_onepart);
                    LoadItem(todaycategory[2], content[2]);
                    rotedIndex.Add(todaycategory[2]);
                    TimersManager.SetTimer(0.5f, () => { PlayButton.gameObject.SetActive(true); });
                });
            });
        });
    }

    private async void LoadItem(int index, Transform patent)
    {
        GameObject item = null;
        switch (index)
        {
            case 0:
                item = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_Block_History).Task;
                break;
            case 1:
                item = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_Block_Lifestyle).Task;
                break;
            case 2:
                item = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_Block_Language).Task;
                break;
            case 3:
                item = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_Block_Science).Task;
                break;
            case 4:
                item = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_Block_Entertainment).Task;
                break;
            case 5:
                item = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_Block_Geography).Task;
                break;
        }

        if (item != null)
        {
            Instantiate(item, patent, false);
        }
    }

    private IEnumerator FinishWheelLoop()
    {
        yield return new WaitForSeconds(1);
        PlayButton.gameObject.SetActive(true);
    }

    private bool clickHome = false;

    public void ClickPlay()
    {
        TimersManager.SetTimer(0.5f, () => { clickHome = false; });
        CloseWindow();
        AppEngine.SSystemManager.GetSystem<DailySystem>().PlayDailyGame();
    }

    public void CloseWindow()
    {
        UIManager.CloseUIWindow(this);
    }

    private int FindIndex(float rot)
    {
        float realRot = rot % 360;
        if (realRot >= -360 && realRot < -300)
        {
            return 0;
        }
        else if (realRot >= -300 && realRot < -240)
        {
            return 1;
        }
        else if (realRot >= -240 && realRot < -180)
        {
            return 2;
        }
        else if (realRot >= -180 && realRot < -120)
        {
            return 3;
        }
        else if (realRot >= -120 && realRot < -60)
        {
            return 4;
        }
        else if (realRot >= -60 && realRot < 0)
        {
            return 5;
        }
        else if (realRot >= 0 && realRot < 60)
        {
            return 0;
        }
        else if (realRot >= 60 && realRot < 120)
        {
            return 1;
        }
        else if (realRot >= 120 && realRot < 180)
        {
            return 2;
        }
        else if (realRot >= 180 && realRot < 240)
        {
            return 3;
        }
        else if (realRot >= 240 && realRot < 300)
        {
            return 4;
        }
        else if (realRot >= 300 && realRot < 360)
        {
            return 5;
        }

        return 0;
    }

    private int[] GetRandomRot(int index, int cricle)
    {
        int[] realRot = new[] {0, 0};
        if (index == 0)
        {
            realRot[0] = Random.Range(-350, -310);
        }
        else if (index == 1)
        {
            realRot[0] = Random.Range(-290, -250);
        }
        else if (index == 2)
        {
            realRot[0] = Random.Range(-230, -190);
        }
        else if (index == 3)
        {
            realRot[0] = Random.Range(-170, -130);
        }
        else if (index == 4)
        {
            realRot[0] = Random.Range(-110, -70);
        }
        else if (index == 5)
        {
            realRot[0] = Random.Range(-50, -10);
        }

        realRot[1] = realRot[0];
        realRot[0] -= cricle * 360;
        return realRot;
    }

    /// <summary>
    /// 线上daily的123456和图片不一致，转换一下
    /// </summary>
    /// <returns></returns>
    private List<int> TransDailyIndex(List<int> listIndex)
    {
        List<int> newListIndex = new List<int>();
        for (int i = 0; i < listIndex.Count; i++)
        {
            if (listIndex[i] == 1)
            {
                newListIndex.Add(5);
            }
            else if (listIndex[i] == 2)
            {
                newListIndex.Add(4);
            }
            else if (listIndex[i] == 3)
            {
                newListIndex.Add(6);
            }
            else if (listIndex[i] == 4)
            {
                newListIndex.Add(3);
            }
            else if (listIndex[i] == 5)
            {
                newListIndex.Add(1);
            }
            else if (listIndex[i] == 6)
            {
                newListIndex.Add(2);
            }
        }

        return newListIndex;
    }
}