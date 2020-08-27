using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
#if UNITY_IOS
using UnityEngine.iOS;
#endif
using System.Threading;
using System.Linq;

public enum VoicePermission
{
    unknown,
    denied,
    allow
}

public class ClassicVoiceKeyboard : GameEntity
{
    public TextMeshProUGUI Text_Fury_Red;
    public TextMeshProUGUI Text_Fury_Green;
    public TextMeshProUGUI Text_Fury_White;
    public TextMeshProUGUI Text_Second;
    public GameObject Fury;
    public GameObject Btn_Voice;
    public GameObject Text_Say_Answer;
    public GameObject Text_No_Internet;
    public GameObject Img_Right;
    public LongPressButton micBtn;
    public GameObject goSettingObj;
    public CirclePress pressMic2;
    public GameObject letterObj;
    public GameObject letterParent;
    //public CanvasGroup keyboardBtnGroup;
    public GameObject waveObj;

    private const int kWaitSeconds = 60;
    private int seconds = kWaitSeconds;
    private List<string> kFakeInputs = new List<string> {"CALLER"};
    private bool matched = false;
    private BaseWord baseWord {
        get {
            return GameManager.GetCurrentFoucesAnswer();
		}
	}
    public static string reconition = "";
    public static int consumeTime = 0;
    public static bool rightAnswer = false;
    public static string answer = "";
    public static string question = "";
    public const int GuideLevel = 19;

    /// <summary>
    /// 第二关没有出的在第6关
    /// </summary>
    public const int GuideLevel2 = Int16.MaxValue;

    private GuideSystem guideSystem;
    public List<ClassicVoiceKeyboardCell> pools;
    private int curLevel;
    private static RecordExtra.PrefData<VoiceAnalyseData> voiceMatchNumber;
    private RecordExtra.BoolPrefData enableVoice;
    private RecordExtra.BoolPrefData voicePermissionData;
    private bool kDebug = false;
    private static int words;
    private const int kInputCapacity = 18;
    private const int releaseReceiveSecods = 3;
    //private Tweener keyboardBtnTweener;
    public bool disableInput = false;
    public GameObject errorTips;
    public GameObject voiceNotice;
    public GameObject noticeParent;
    public GameObject currentNotice;
    public static VoicePermission voicePermission = VoicePermission.unknown;
    private bool canActive = true;
    public static bool netStatuOk = true;
    private bool isOn;
    protected VoiceMatchComponent matchComponent;

    struct SpeechInput
    {
        public bool cropped;
        public string croppedString;
        public string originalInput;
        public const int CROPPED_INTERVAL = 2; //1秒
        public bool didntInputForCROPPED_INTERVAL;
        public bool inReleaseReceiveMode;

        public string DisplayString()
        {
            string result = originalInput;
            if (cropped && originalInput.Length > croppedString.Length)
            {
                result = originalInput.Substring(croppedString.Length).TrimStart().TrimEnd();
            }

            return result;
        }
    };

    private SpeechInput userInput;

    public static int VoiceProportion
    {
        get
        {
            int result = 0;
            if (words > 0)
            {
                switch (DataManager.ProcessData._GameMode)
                {
                    case GameMode.Classic:
                        result = voiceMatchNumber.Value.mainNumber * 1000 / words;
                        break;
                    case GameMode.Daily:
                        result = voiceMatchNumber.Value.dailyNumber * 1000 / words;
                        break;
                    case GameMode.OneWord:
                        result = voiceMatchNumber.Value.flashNumber * 1000 / words;
                        break;
                }
            }

            return result;
        }
    }

    public static void ClearData()
    {
        reconition = "";
        consumeTime = 0;
        rightAnswer = false;
        answer = "";
        question = "";
    }

    public void Init()
    {
        matchComponent = new VoiceKeyboardMatch();
        matchComponent.next = new VoiceKeyboardMatchSupplement();

        guideSystem = AppEngine.SSystemManager.GetSystem<GuideSystem>();
        if (guideSystem.GuideShown_GuideVoice2Step.Value == 3)
        {
            guideSystem.GuideShown_GuideVoice2Step.Value = 1;
        }

        errorTips = transform.parent.Find("VoiceErrorTips").gameObject;
        voiceNotice = transform.parent.Find("VoiceNotice").gameObject;
        voicePermissionData = new RecordExtra.BoolPrefData("voicePermissionData", false);

        errorTips.SetActive(false);
        noticeParent = voiceNotice.transform.parent.gameObject;
        Destroy(voiceNotice);
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_VoiceNotice, (obj) => { voiceNotice = obj; });

        voiceNotice.SetActive(false);

        Version v2 = new Version("10.0");
#if UNITY_EDITOR
        kDebug = true;
#elif UNITY_IOS
		v2 = new Version(Device.systemVersion);
#endif
        Version v1 = new Version("10.0");
        InitUI();
        micBtn.press += PressMic;

        TimersManager.SetTimer(2f, () =>
        {
            if (baseWord != null)
                answer = baseWord.Answer;
        });

        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_ClassVoiceLetter, (obj) => { letterObj = obj; });
        pools = new List<ClassicVoiceKeyboardCell>();

        curLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
		var keyBoard = GameManager.GetEntity<BaseKeyBoard>();
		int len = keyBoard.micKey.Length;
		if (v2 < v1) {//|| !(guideSystem.GuideShown_GuideVoice2Step.Value > 0 || curLevel == GuideLevel || curLevel >= GuideLevel2)
			for (int i = 0; i < len; i++) {
				keyBoard.micKey[i].SetActive(false);
			}
		}

		voiceMatchNumber = new RecordExtra.PrefData<VoiceAnalyseData>("voiceMatchNumber", new VoiceAnalyseData());
        switch (DataManager.ProcessData._GameMode)
        {
            case GameMode.Classic:
                if (curLevel != voiceMatchNumber.Value.mainLevel)
                {
                    voiceMatchNumber.Value.mainNumber = 0;
                }

                voiceMatchNumber.Value.mainLevel = curLevel;
                break;
            case GameMode.Daily:
                if (curLevel != voiceMatchNumber.Value.dailyLevel)
                {
                    voiceMatchNumber.Value.dailyNumber = 0;
                }

                voiceMatchNumber.Value.dailyLevel = curLevel;
                break;
            case GameMode.OneWord:
                if (curLevel != voiceMatchNumber.Value.flashLevel)
                {
                    voiceMatchNumber.Value.flashNumber = 0;
                }

                voiceMatchNumber.Value.flashLevel = curLevel;
                break;
        }

        voiceMatchNumber.Save();
        words = GameManager.GetEntity<BaseCellManager>().Words.Count;
        enableVoice = new RecordExtra.BoolPrefData("enableVoice", false);
        if (enableVoice.Value)
        {
            gameObject.SetActive(true);
        }

        if (guideSystem.GuideShown_GuideVoice2Step.Value == 0)
        {
            canActive = false;
            TimersManager.SetTimer(2f, () =>
            {
                canActive = true;
            });
        }
#if UNITY_ANDROID
        for (int i = 0; i < keyBoard.micKey.Length; i++)
        {
            keyBoard.micKey[i].SetActive(false);
        }
#endif
    }

    private void CroppInput()
    {
        userInput.didntInputForCROPPED_INTERVAL = true;
        userInput.cropped = true;
        userInput.croppedString = userInput.originalInput;
        Text_Fury_Red.text = Text_Fury_White.text;
        Text_Fury_Red.gameObject.SetActive(true);
        Text_Fury_Red.transform.parent.GetComponent<Animator>().SetTrigger("on");
        Text_Fury_White.gameObject.SetActive(false);
        waveObj.GetComponent<Animator>().SetTrigger("low");
        TimersManager.SetTimer(0.2f, () =>
        {
            if (userInput.didntInputForCROPPED_INTERVAL)
            {
                Fury.SetActive(false);
            }
        });
    }

    public void PressMic()
    {
        isOn = !isOn;
        if (isOn) {
            if (disableInput) return;
            if (guideSystem.GuideShown_GuideVoice2Step.Value == 3) {
                return;
            }

            if (currentNotice != null) {
                Destroy(currentNotice);
            }

            currentNotice = Instantiate(voiceNotice, noticeParent.transform);
            currentNotice.GetComponentInChildren<Animator>().SetTrigger("down");
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_voicewakeup);
            InitUI();
            InitData();
			DataManager.ProcessData.voiceMicPressDown = true;
			ClearData();
            //keyboardBtnTweener = keyboardBtnGroup.DOFade(0, 0.4f);
            pressMic2.gameObject.SetActive(true);
            BtnAni(true);
            waveObj.SetActive(true);
            waveObj.GetComponent<Animator>().SetTrigger("low");
            Debug.LogError("second active true");
            this.InvokeRepeating("CountDown", 0.0f, 1.0f);
            PlatformUtil.StartListen();

            if (kDebug) {
                kFakeIndex = 0;
                kFakeInputs.Add(kFakeInputs[kFakeInputs.Count - 1] + " " + baseWord.Answer);
            }
        } else {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_voicewakeup);
            ReleaseMic();
		}
    }

    private void InitData()
    {
        userInput.originalInput = "";
        userInput.cropped = false;
        userInput.croppedString = "";
        userInput.didntInputForCROPPED_INTERVAL = false;
        userInput.inReleaseReceiveMode = false;

        matched = false;
        seconds = kWaitSeconds;
    }

    private void InitUI()
    {
        TimersManager.ClearTimer(InitUI);
        waveObj.SetActive(false);
        Text_Fury_Red.transform.parent.gameObject.SetActive(true);
        Text_Fury_Red.gameObject.SetActive(false);
        Text_Fury_Green.gameObject.SetActive(false);
        Text_Fury_White.gameObject.SetActive(true);
        Img_Right.SetActive(false);
        Text_Second.gameObject.SetActive(false);
        Text_Fury_White.text = "";
        Fury.SetActive(false);
        InitPressMic2();
        waveObj.SetActive(false);
        TimersManager.ClearTimer(CroppInput);
        //if (keyboardBtnTweener != null && !keyboardBtnTweener.IsComplete())
        //{
        //    keyboardBtnTweener.Complete();
        //}
    }

    private bool showingTip = false;

    private void ShowErrorTip()
    {
        if (showingTip) return;
        errorTips.SetActive(true);
        showingTip = true;
        TimersManager.SetTimer(1.2f, () =>
        {
            errorTips.SetActive(false);
            showingTip = false;
        });
    }

    private void InitPressMic2()
    {
        if (!userInput.inReleaseReceiveMode)
        {
            pressMic2.gameObject.SetActive(false);
        }
    }

    private void ReleaseReceiveFinished()
    {
        userInput.inReleaseReceiveMode = false;
        InitPressMic2();
        if (string.IsNullOrEmpty(userInput.originalInput))
        {
            ShowErrorTip();
        }
    }

    public void ReleaseMic()
    {
        if (currentNotice != null)
        {
            currentNotice.GetComponentInChildren<Animator>().SetTrigger("up");
            var tmpVoice = currentNotice;
            TimersManager.SetTimer(0.1f, () => { Destroy(tmpVoice); });
        }

        if (guideSystem.GuideShown_GuideVoice2Step.Value == 3)
        {
            return;
        }

        InitUI();
        BtnAni(false);
        //keyboardBtnTweener = keyboardBtnGroup.DOFade(1, 0.2f);
        var tmpPressDown = DataManager.ProcessData.voiceMicPressDown;
        DataManager.ProcessData.voiceMicPressDown = false;
        if (!tmpPressDown)
        {
            return;
        }

        if (!matched)
        {
            pressMic2.gameObject.SetActive(true);
            ReleaseReceiveFinished();
            Text_Fury_Red.text = Text_Fury_White.text;
            Text_Fury_Red.gameObject.SetActive(true);
            Text_Fury_Red.transform.parent.GetComponent<Animator>().SetTrigger("on");
            Text_Fury_Green.gameObject.SetActive(false);
            Text_Fury_White.gameObject.SetActive(false);
        }

        StopUpdate();
        if (!matched)
        {
            if (guideSystem.GuideShown_GuideVoice2Step.Value < 2)
            {
                GameManager.StateMachine.Next();
            }
        }

        #region UploadData

        consumeTime = kWaitSeconds - seconds;
        rightAnswer = matched;
        answer = baseWord.Answer;
        question = baseWord.GetWordQuestion();

        if (matched)
        {
            switch (DataManager.ProcessData._GameMode)
            {
                case GameMode.Classic:
                    voiceMatchNumber.Value.mainNumber += 1;
                    break;
                case GameMode.Daily:
                    voiceMatchNumber.Value.dailyNumber += 1;
                    break;
                case GameMode.OneWord:
                    voiceMatchNumber.Value.flashNumber += 1;
                    break;
            }

            voiceMatchNumber.Save();
        }

        if (!string.IsNullOrEmpty(reconition))
        {
            string levelId = "";
            int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
            var _classicLevelEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetClassicLevel(level);
            if (_classicLevelEntity == null)
            {
                levelId = level.ToString();
            }
            else
            {
                levelId = _classicLevelEntity.ID.ToString();
            }

            string question = ClassicVoiceKeyboard.question;
            string levelType = "";
            switch (DataManager.ProcessData._GameMode)
            {
                case GameMode.Classic:
                    levelType = "Classic";
                    break;
                case GameMode.Daily:
                    levelType = "Daily";
                    break;
                case GameMode.OneWord:
                    levelType = "Flash";
                    break;
            }

            BQReport.PostVoiceInput(new VoiceInputModel
            {
                levelId = levelId,
                levelType = levelType,
                type = "Normal",
                question = question,
                recognition = reconition,
                answer = answer,
                consumeTime = consumeTime.ToString(),
                right = rightAnswer ? "1" : "0",
                version = PlatformUtil.GetVersionName(),
            });
        }

        #endregion
    }

    private void OnEnable()
    {
        InitUI();
        if (guideSystem.GuideShown_GuideVoice2Step.Value == 0)
        {
            guideSystem.GuideShown_GuideVoice.Value = true;
            guideSystem.GuideShown_GuideVoice2Step.Value = 3;
            PlatformUtil.RequestVoicePermission();
        }
        else
        {
            if (guideSystem.GuideShown_GuideVoice2Step.Value != 0 && guideSystem.GuideShown_GuideVoice2Step.Value != 3)
            {
                PlatformUtil.RequestVoicePermission();
            }
        }

        if (guideSystem.GuideShown_GuideVoice2Step.Value < 2)
        {
            GameManager.StateMachine.Next();
        }

        if (kDebug)
        {
            TimersManager.SetTimer(5, () =>
            {
				//AvailableChange("false");
				HandlePermission("true");
			});
        }

        MicroPhoneBehaviour.ClickRedDot();

    }

    private void OnApplicationFocus(bool focus)
    {
        if (guideSystem != null && guideSystem.GuideShown_GuideVoice2Step.Value != 0 &&
            guideSystem.GuideShown_GuideVoice2Step.Value != 3)
        {
            PlatformUtil.RequestVoicePermission();
        }
    }

    private void HandleAvailable(bool enable)
    {
        netStatuOk = enable;
        if (!enable)
        {
            //无网
            if (UIManager.GetUI(ViewConst.prefab_VoiceWordGui2) != null)
            {
                UIManager.GetUI(ViewConst.prefab_VoiceWordGui2).GetComponent<UIWindowBase>().Close();
            }

            Btn_Voice.SetActive(false);
            Text_Say_Answer.SetActive(false);
            Text_No_Internet.SetActive(true);
            ReleaseMic();
        }
        else
        {
            Btn_Voice.SetActive(true);
            Text_Say_Answer.SetActive(true);
            Text_No_Internet.SetActive(false);
        }
    }

    public void HandleFinish()
    {
        if (!DataManager.ProcessData.voiceMicPressDown)
        {
            return;
        }

        ReleaseMic();
    }

    public void HandlePermission(string flag)
    {
        if (this == null) {
            return;
		}
        if (guideSystem.GuideShown_GuideVoice2Step.Value == 3)
        {
            guideSystem.GuideShown_GuideVoice2Step.Value = 1;
        }

        if (flag.Equals("true"))
        {
            if (guideSystem.GuideShown_GuideVoice2Step.Value == 1)
            {
                GameManager.StateMachine.Next();
            }

            if (voicePermissionData.Value == false)
            {
                voicePermissionData.Value = true;
                BQReport.PostVoicePermission(new voicePermissionModel
                {
                    userid = AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value,
                    permission = "1"
                });
            }
        }
        else
        {
            InitUI();
            guideSystem.GuideShown_GuideVoice2Step.Value = 4;
            Action act = new Action(() => {
                if (this != null) {
					Active();
				}
			});
            UIManager.OpenUIAsync(ViewConst.prefab_FBPermissionDialog, OpenType.Replace, null, act);

            if (!voicePermissionData.Value)
            {
                BQReport.PostVoicePermission(new voicePermissionModel
                {
                    userid = AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value,
                    permission = "0"
                });
            }

            MicroPhoneBehaviour.RefusePermission();
        }
    }

    private int kFakeIndex = 0;

    private void CountDown()
    {
        if (seconds > 0)
        {
			if (seconds <= 10) {
                Text_Second.gameObject.SetActive(true);
            }
            Text_Second.text = string.Format("{0}s", seconds);
            seconds--;
            if (seconds == 0)
            {
                Finish();
            }

            if (kDebug)
            {
                int r = UnityEngine.Random.Range(1, 5);
                Debug.LogError("time is " + r);
                TimersManager.SetTimer(r, () =>
                {
                    ReceiveMsg(baseWord.Answer);
                });
				//}
				//kFakeIndex++;
			}
        }
    }

    internal void DisActive() {
        if (DataManager.ProcessData.voiceMicPressDown) {
            Finish();
		}
        gameObject.SetActive(false);
    }

    internal void Active()
    {
#if UNITY_ANDROID
        return;
#endif
        if (!canActive)
        {
			Debug.LogError("屏蔽点击");
			return;
        }
        if (UIManager.GetUI(ViewConst.prefab_VoiceWordGui1) != null) {
			UIManager.CloseUIWindow(UIManager.GetUI(ViewConst.prefab_VoiceWordGui1));
		}
        gameObject.SetActive(!gameObject.activeSelf);
        enableVoice.Value = gameObject.activeSelf;
        canActive = false;
        TimersManager.SetTimer(0.5f, () => { canActive = true; });
    }

    private void StopUpdate()
    {
        isOn = false;
        PlatformUtil.StopListen();
        this.CancelInvoke();
    }

    private void OnDestroy()
    {
        StopUpdate();
        TimersManager.ClearTimer(CroppInput);
    }

    public void AvailableChange(string available)
    {
        bool enable = available.Equals("true") && Application.internetReachability != NetworkReachability.NotReachable;
        HandleAvailable(enable);
    }

    public void ReceiveMsg(string str)
    {
		Debug.LogError("receive " + str);
		if (baseWord.IsComplete) {
			//处理切换到已答对词的情况
            return;
		}
		TimersManager.ClearTimer(CroppInput);
        if (guideSystem.GuideShown_GuideVoice2Step.Value == 3)
        {
            HandlePermission("true");
            ReleaseMic();
            return;
        }

        if (matched)
        {
            //重复处理match的问题
            return;
        }

        if (!DataManager.ProcessData.voiceMicPressDown && !userInput.inReleaseReceiveMode)
        {
            return;
        }

        userInput.didntInputForCROPPED_INTERVAL = false;
        TimersManager.SetTimer(SpeechInput.CROPPED_INTERVAL, CroppInput);
        str = str.ToUpper();
        userInput.originalInput = str;
        reconition = str;
        string adjustedStr = userInput.DisplayString();
        if (adjustedStr.Length > kInputCapacity)
        {
            adjustedStr = adjustedStr.Substring(adjustedStr.Length - 15);
            adjustedStr = string.Format("...{0}", adjustedStr);
        }

        if (adjustedStr.Length > 0)
        {
            waveObj.GetComponent<Animator>().SetTrigger("high");
        }

        Text_Fury_White.gameObject.SetActive(true);
        Text_Fury_Red.gameObject.SetActive(false);
        Text_Fury_White.text = adjustedStr;
        Text_Fury_Green.text = adjustedStr;
        Text_Fury_Red.text = adjustedStr;
        Fury.SetActive(adjustedStr.Length > 0);
        if (adjustedStr.Length > 0)
        {
            guideSystem.FinishWord_GuideVoice3.Value = true;
            guideSystem.GuideShown_GuideVoice2Step.Value = 2;
        }

        matchComponent.recognition = userInput.originalInput;
        matchComponent.similars = baseWord.SimilarWords;
        matchComponent.answerWord = baseWord.Answer;
        bool match = matchComponent.Handle();
        if (match) {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_voiceright);
            TimersManager.ClearTimer(CroppInput);
            ReleaseReceiveFinished();
            matched = true;
            RectTransform letterParentTrans = letterParent.GetComponent<RectTransform>();
            letterParentTrans.sizeDelta =
                new Vector2(baseWord.Answer.Length * 140 - 69 * (baseWord.Answer.Length - 1), 100);
            GameManager.GameAnimationStart();
            StartCoroutine(RightAni());
            RightWord();
        } else {
            Text_Fury_White.gameObject.SetActive(false);
            Text_Fury_Red.gameObject.SetActive(true);
            Text_Fury_Red.transform.parent.GetComponent<Animator>().SetTrigger("on");
        }
    }

    Vector2 sizeDELTA = Vector2.zero;

    IEnumerator RightAni()
    {
        if (disableInput) yield break;
        disableInput = true;
        List<ClassicVoiceKeyboardCell> clones = new List<ClassicVoiceKeyboardCell>();
        for (int i = 0; i < baseWord.Answer.Length; i++)
        {
            ClassicVoiceKeyboardCell letter = null;
            if (pools.Count > 0)
            {
                letter = pools[pools.Count - 1];
                pools.RemoveAt(pools.Count - 1);
            }

            if (letter == null)
            {
                letter = Instantiate(letterObj, letterParent.transform, false).GetComponent<ClassicVoiceKeyboardCell>();
                letter.letterText.SetSize(((RectTransform) letter.letterText.transform).sizeDelta);
                sizeDELTA = ((RectTransform) letter.transform).sizeDelta;
            }
            else
            {
                letter.transform.SetParent(letterParent.transform, false);
            }

            ((RectTransform) letter.transform).sizeDelta = sizeDELTA;
            letter.gameObject.SetActive(true);
            letter.letterText.text = string.Format("{0}", baseWord.Answer[i]);
            clones.Add(letter);
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.3f);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_voicefly);
        for (int i = 0; i < baseWord.Answer.Length; i++)
        {
            var letterRect = clones[i].transform as RectTransform;
            var letterTrans = clones[i].letterText.transform as RectTransform;
            letterTrans.localPosition = (baseWord.Cells[i].letterText.transform as RectTransform).localPosition;
            letterRect.DOMove(
                new Vector3(baseWord.Cells[i].transform.position.x, baseWord.Cells[i].transform.position.y,
                    letterRect.position.z), 0.5f);
            ((RectTransform) clones[i].letterText.transform).DOSizeDelta(baseWord.Cells[i].letterText.Size, 0.5f);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.6f);
        InitUI();
        baseWord.OnVoiceRight();
        for (int i = 0; i < clones.Count; i++)
        {
            Destroy(clones[i].gameObject);
        }

        disableInput = false;
        GameManager.GameAnimationEnd();
    }

    private void TipRelease()
    {
    }

    private void RightWord()
    {
        Text_Fury_Red.transform.parent.gameObject.SetActive(false);
        pressMic2.gameObject.SetActive(false);
        Text_Fury_White.gameObject.SetActive(false);
        Text_Fury_Green.gameObject.SetActive(true);
        waveObj.SetActive(false);
        Text_Fury_Green.text = baseWord.Answer;
        Img_Right.SetActive(true);
        Text_Second.gameObject.SetActive(false);
        if (currentNotice) {
            Destroy(currentNotice);
        }
        StopUpdate();
        BtnAni(false);
        DataManager.ProcessData.voiceMicPressDown = false;
    }

	private void Finish()
	{
        InitUI();
        if (currentNotice) {
            Destroy(currentNotice);
        }
        StopUpdate();
        BtnAni(false);
        DataManager.ProcessData.voiceMicPressDown = false;
    }

    private int BtnAniCount = 0;
    private void BtnAni(bool press) {
        Debug.LogError("log press " + press);
        if (press) {
            if (BtnAniCount == 0) {
				Btn_Voice.GetComponentInChildren<Animator>().SetTrigger("click");
                BtnAniCount = 1;
			}
        } else {
            if (BtnAniCount == 1) {
				Btn_Voice.GetComponentInChildren<Animator>().SetTrigger("back");
                BtnAniCount = 0;
			}
        }
	}

    private void OnDisable()
    {
        DisActive();
    }

    public void ClickKeyBoard()
    {
        AppEngine.SSoundManager.PlaySFX("0_calcel.wav");
        Active();
    }

    public void ClickBeta()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_feedbackSendDialog);
    }

    public void GoSettingAction()
    {
        PlatformUtil.OpenSetting();
    }
}

public class VoiceAnalyseData
{
    public int mainLevel;
    public int mainNumber;
    public int flashLevel;
    public int flashNumber;
    public int dailyLevel;
    public int dailyNumber;
}
