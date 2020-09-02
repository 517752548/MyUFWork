using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using Object = UnityEngine.Object;

public class GamePlay : MonoBehaviour
{
    private GameObject _GamePlay;
    private Dictionary<string, GameObject> prefabObj = new Dictionary<string, GameObject>();

    public async void CreatGame(Action<bool> callback)
    {
        GameMode currentGameModel = DataManager.ProcessData._GameMode;
        switch (currentGameModel)
        {
            case GameMode.Classic:
                LoadPrefab(CommUtil.GetClassicResName(), op =>
                {
                    _GamePlay = Object.Instantiate(op);
                    _GamePlay.transform.SetParent(transform, false);
                    callback?.Invoke(true);
                    Timer.Schedule(this, 0.1f, () =>
                    {
                        _GamePlay.GetComponent<BaseGameManager>().Init();
                    });
                    TimersManager.SetTimer(0.3f, () =>
                    {
                        ClassicWorldEntity classicWorldEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>()
                            .GetClassicWorld(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel
                                .Value);
                        AppEngine.SSoundManager.PlayBGM(classicWorldEntity.BGMusic);
                    });
                });

                break;
            case GameMode.Elite:
                LoadPrefab(ViewConst.prefab_CrossGame, op =>
                {
                    _GamePlay = Object.Instantiate(op);
                    _GamePlay.transform.SetParent(transform, false);
                    callback?.Invoke(true);
                    Timer.Schedule(this, 0.1f, () =>
                    {
                        _GamePlay.GetComponent<BaseGameManager>().Init();
                    });
                    TimersManager.SetTimer(0.3f, () =>
                    {
                        ClassicWorldEntity classicWorldEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>()
                            .GetClassicWorld(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel
                                .Value);
                        AppEngine.SSoundManager.PlayBGM(classicWorldEntity.BGMusic);
                    });
                });

                break;
            case GameMode.Daily:
                LoadPrefab(ViewConst.prefab_DailyGame, op =>
                {
                    _GamePlay = Object.Instantiate(op);
                    _GamePlay.transform.SetParent(transform, false);
                    callback?.Invoke(true);
                    Timer.Schedule(this, 0.1f, () => { _GamePlay.GetComponent<BaseGameManager>().Init(); });
                    TimersManager.SetTimer(0.3f, () => { AppEngine.SSoundManager.PlayBGM(ViewConst.mp3_common_gm); });
                });

                break;
            case GameMode.OneWord:
                LoadPrefab(ViewConst.prefab_OneWordGame, op =>
                {
                    _GamePlay = Object.Instantiate(op);
                    _GamePlay.transform.SetParent(transform, false);
                    callback?.Invoke(true);
                    Timer.Schedule(this, 0.1f, () => { _GamePlay.GetComponent<BaseGameManager>().Init(); });
                    TimersManager.SetTimer(0.3f, () => { AppEngine.SSoundManager.PlayBGM(ViewConst.mp3_common_gm); });
                });

                break;
        }
    }

    private void LoadPrefab(string prefab, Action<GameObject> prefabcallback)
    {
        if (prefabObj.ContainsKey(prefab))
        {
            prefabcallback?.Invoke(prefabObj[prefab]);
            return;
        }
        ResourceManager.LoadAsync<GameObject>(prefab, op =>
        {
            if (!prefabObj.ContainsKey(prefab))
            {
                prefabObj.Add(prefab,op);
            }
            prefabcallback?.Invoke(op);
        });
    }

    public void DestroyGame()
    {
        Destroy(_GamePlay);
    }
}