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

public class ClassicVoiceKeyboardRefactor : GameEntity
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
    public GameObject pressMic;
    public CirclePress pressMic2;
    public GameObject letterObj;
    public GameObject letterParent;
    public CanvasGroup keyboardBtnGroup;
    public GameObject waveObj;

    private const int kWaitSeconds = 60;
    private int seconds = kWaitSeconds;
    private List<string> kFakeInputs = new List<string> {"CALLER"};
    private bool matched = false;
    public BaseWord baseWord;
    public static string reconition = "";
    public static int consumeTime = 0;
    public static bool rightAnswer = false;
    public static string answer = "";
    public static string question = "";
    public const int GuideLevel = 2;

    /// <summary>
    /// 第二关没有出的在第6关
    /// </summary>
    public const int GuideLevel2 = 9;

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
    private Tweener keyboardBtnTweener;
    public bool disableInput = false;
    public GameObject errorTips;
    public GameObject voiceNotice;
    public GameObject noticeParent;
    public GameObject currentNotice;
    public static VoicePermission voicePermission = VoicePermission.unknown;
    private bool canActive = true;
    public static bool netStatuOk = true;
    private bool isOn;
    public ClassicVoiceComponent voiceComponent;

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
                        //Debug.LogError("答对了 " + voiceMatchNumber.Value.mainNumber + " 总共 " + words);
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

    public void Init(int levelIndex)
    {
        voiceComponent = new ClassicVoiceData();
        voiceComponent.coordinator = this;
        var c2 = new ClassicVoiceUserGuide();
        c2.coordinator = this;
        var c3 = new ClassicVoiceCore();
        c3.coordinator = this;
        var c4 = new ClassicVoiceDataReport();
        c4.coordinator = this;
        voiceComponent.next = c2;
        c2.next = c3;
        c3.next = c4;

        voiceComponent.Init();
    }

    private void CroppInput()
    {
        userInput.didntInputForCROPPED_INTERVAL = true;
        userInput.cropped = true;
        userInput.croppedString = userInput.originalInput;
        Text_Fury_Red.text = Text_Fury_White.text;
        Text_Fury_Red.gameObject.SetActive(true);
        Text_Fury_Red.transform.parent.GetComponent<Animator>().SetTrigger("on");
        //AppEngine.SSoundManager.PlaySFX(ViewConst.wav_voicefail);
        Text_Fury_White.gameObject.SetActive(false);
        waveObj.GetComponent<Animator>().SetTrigger("low");
        TimersManager.SetTimer(0.2f, () =>
        {
            if (userInput.didntInputForCROPPED_INTERVAL)
            {
                //Debug.LogError("fury active false1");
                Fury.SetActive(false);
            }
        });
    }

    public void PressMic()
    {
        isOn = !isOn;
		if (isOn) {
            voiceComponent.BeforeInput();
		} else {
            voiceComponent.BeforeFinish();
            TimersManager.SetTimer(3, ReleaseReceiveFinished);
        }
    }

    public void PressDownMicUI() {
        if (currentNotice != null) {
            Destroy(currentNotice);
        }

        currentNotice = Instantiate(voiceNotice, noticeParent.transform);
        currentNotice.GetComponentInChildren<Animator>().SetTrigger("down");
        //Debug.LogError("PressMic");
        //Handheld.Vibrate();
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_voicewakeup);
        keyboardBtnTweener = keyboardBtnGroup.DOFade(0, 0.4f);
        pressMic.SetActive(true);
        pressMic2.gameObject.SetActive(true);
        pressMic2.bg.SetActive(true);
        waveObj.SetActive(true);
        waveObj.GetComponent<Animator>().SetTrigger("low");
        Text_Second.gameObject.SetActive(true);
        this.InvokeRepeating("CountDown", 0.0f, 1.0f);
    }

    private void InitData()
    {
        //Debug.LogError("InitData");
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
        //Debug.LogError("fury active false");
        Fury.SetActive(false);
        pressMic.SetActive(false);
        InitPressMic2();
        waveObj.SetActive(false);
        TimersManager.ClearTimer(CroppInput);
        if (keyboardBtnTweener != null && !keyboardBtnTweener.IsComplete())
        {
            keyboardBtnTweener.Complete();
        }
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
        //Debug.LogError("release receive mode " + userInput.inReleaseReceiveMode);
        if (!userInput.inReleaseReceiveMode)
        {
            //Debug.LogError("InitPressMic2");
            pressMic2.gameObject.SetActive(false);
            pressMic2.bg.SetActive(true);
        }
    }

    private void ReleaseReceiveFinished()
    {
        voiceComponent.Finish();
        //userInput.inReleaseReceiveMode = false;
        //InitPressMic2();
        //if (string.IsNullOrEmpty(userInput.originalInput))
        //{
        //    ShowErrorTip();
        //}
    }


    private void OnEnable()
    {
        InitUI();
        if (guideSystem.GuideShown_GuideVoice2Step.Value == 0)
        {
            //Debug.LogError("申请权限");
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
                //HandlePermission("false");
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
            //ReleaseMic();
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

        //ReleaseMic();
    }

    public void HandlePermission(string flag)
    {
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
            //if (!guideSystem.ShowSetting_GuideVoice3.Value) {
            //guideSystem.ShowSetting_GuideVoice3.Value = true;
            guideSystem.GuideShown_GuideVoice2Step.Value = 4;
            Action act = new Action(() => { Active(); });
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
            Text_Second.text = string.Format("{0}s", seconds);
            seconds--;
            if (seconds == 0)
            {
                InitUI();
                StopUpdate();
            }

            if (kDebug)
            {
                //if (kFakeIndex < kFakeInputs.Count) {
                int r = UnityEngine.Random.Range(5, 8);
                TimersManager.SetTimer(2.5f / (float) r, () => { ReceiveMsg(baseWord.Answer); });
                //}
                //kFakeIndex++;
            }
        }
    }

    internal void Active()
    {
        if (!canActive)
        {
            //Debug.LogError("屏蔽点击");
            return;
        }

        //Debug.LogError("屏蔽点击失败");
        gameObject.SetActive(!gameObject.activeSelf);
        enableVoice.Value = gameObject.activeSelf;
        canActive = false;
        TimersManager.SetTimer(0.2f, () => { canActive = true; });
    }

    private void StopUpdate()
    {
        PlatformUtil.StopListen();
        this.CancelInvoke();
    }

    private void OnDestroy()
    {
        StopUpdate();
        TimersManager.ClearTimer(CroppInput);
        TimersManager.ClearTimer(ReleaseReceiveFinished);
    }

    public void AvailableChange(string available)
    {
        bool enable = available.Equals("true") && Application.internetReachability != NetworkReachability.NotReachable;
        HandleAvailable(enable);
    }

    public void ReceiveMsg(string str)
    {
        voiceComponent.Input(str);
    }

    Vector2 sizeDELTA = Vector2.zero;

    IEnumerator RightAni()
    {
        if (disableInput) yield break;
        disableInput = true;
        //Debug.LogError("RightAni1");
        GameManager.GameAnimationStart();
        //      TimersManager.SetTimer(0.5f, () => {
        //          GameManager.GameAnimationEnd();
        //});
        //AppEngine.SSoundManager.PlaySFX(ViewConst.wav_voicefly0);
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
            //clones[i].transform.parent = null;
            //clones[i].GetComponent<RectTransform>().position = letterParent.transform.position;
            //pools.Add(clones[i].GetComponent<ClassicVoiceKeyboardCell>());
        }

        disableInput = false;
        GameManager.GameAnimationEnd();
    }

    private void TipRelease()
    {
        //UIManager.ShowMessage("release now");
    }

    private void RightWord()
    {
        //guideSystem.FinishWord_GuideVoice3.Value = true;
        //guideSystem.GuideShown_GuideVoice2Step.Value = 2;
    }

    private void OnDisable()
    {
        StopUpdate();
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
