using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = System.Random;

public class BaseKeyBoard : GameEntity
{
    public KeyboardOneKey[] _KeyboardOneKeys;
    public GameObject[] micKey;
    public Action<string> keyboardAction;

    protected List<KeyboardOneKey> allKeys = new List<KeyboardOneKey>();
    private bool showHintAnim = false;

    public virtual void LoadKeyBoard()
    {
        foreach (KeyboardOneKey oneKey in _KeyboardOneKeys)
        {
            allKeys.Add(oneKey);
            oneKey.Init();
            oneKey.keyAction += OneKey_KeyAction;
        }
    }

    public KeyboardOneKey GetOneKey(string key)
    {
        KeyBoard keyBoard;
        if (Enum.TryParse<KeyBoard>(key, out keyBoard))
        {
            return allKeys.Find(k => k._key == keyBoard);
        }
        return null;
    }

    protected void OneKey_KeyAction(string obj)
    {
        PlaySound(obj);
        keyboardAction?.Invoke(obj);
        m_baseGameManager.PlayerInput(obj);
    }

    public virtual void Init()
    {
        LoadKeyBoard();
    }

    public virtual void Appear()
    {
    }


    public virtual void OnWordChangeFocus(string word, bool usedHint2)
    {
        if (usedHint2)
        {
            List<KeyBoard> keyBoardKey = new List<KeyBoard>();
            for (int i = 0; i < word.Length; i++)
            {
                string key = word[i].ToString().ToUpper();
                KeyBoard keyBoard;
                if (Enum.TryParse<KeyBoard>(key, out keyBoard))
                {
                    keyBoardKey.Add(keyBoard);
                }
            }

            for (int i = 0; i < _KeyboardOneKeys.Length; i++)
            {
                if (keyBoardKey.Contains(_KeyboardOneKeys[i]._key))
                {
                    _KeyboardOneKeys[i].SetStatus(KeyStatus.Normal);
                }
                else
                {
                    if (showHintAnim)
                        _KeyboardOneKeys[i].SetBanDelay(UnityEngine.Random.Range(3, 12));
                    _KeyboardOneKeys[i].SetStatus(KeyStatus.Ban);
                }
            }

            showHintAnim = false;
        }
        else
        {
            for (int i = 0; i < _KeyboardOneKeys.Length; i++)
            {
                _KeyboardOneKeys[i].SetStatus(KeyStatus.Normal);
            }
        }
    }

    public virtual void UseHint2(BaseWord word)
    {
        showHintAnim = true;
        GameManager.GameAnimationStart();
        GameObject hint2Effect = null;
        Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_FX_Hint_2).Completed += op =>
        {
            hint2Effect = op.Result;
            hint2Effect = Instantiate(hint2Effect);
            hint2Effect.transform.SetParent(transform, false);
            TimersManager.SetTimer(2.5f, () =>
            {
                word.UseHint2();
                word = null;
            });
            Destroy(hint2Effect, 3);
        };
        Timer.Schedule(this, 3f, () => { GameManager.GameAnimationEnd(); });
    }

    public virtual void DisAppear()
    {
    }

    private void PlaySound(string keycode)
    {
        string fileName = keycode;
        if (string.IsNullOrEmpty(fileName))
        {
            fileName = "0_calcel";
        }
        if (fileName.Equals(KeyBoard.Speech.ToString())) {
            fileName = "0_calcel";
        }
        AppEngine.SSoundManager.PlaySFX(string.Format("{0}.wav",fileName.ToLower()));
    }
}