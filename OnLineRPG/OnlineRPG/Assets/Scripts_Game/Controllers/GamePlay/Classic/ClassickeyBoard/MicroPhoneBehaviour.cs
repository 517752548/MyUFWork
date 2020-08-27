using UnityEngine;
using BetaFramework;

public class MicroPhoneBehaviour:MonoBehaviour {
	public GameObject reddot;
	public static RecordExtra.PrefData<int> voiceRedDotstartLevel;
	private const int kInvalidValue = -1;
	private const int kClickedRedot = -2;

	private void Awake()
	{
		voiceRedDotstartLevel = new RecordExtra.PrefData<int>("voiceRedDotstartLevel", kInvalidValue);
		if (voiceRedDotstartLevel.Value != kInvalidValue && voiceRedDotstartLevel.Value != kClickedRedot) {
			int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
			if (level - voiceRedDotstartLevel.Value >= 5) {
				reddot.SetActive(true);
			}
		}
	}

	public static void RefusePermission()
	{
		if (voiceRedDotstartLevel.Value == kInvalidValue) {
			int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
			voiceRedDotstartLevel.Value = level;
		}
	}

	public static void ClickRedDot()
	{
		if (voiceRedDotstartLevel.Value != kInvalidValue && voiceRedDotstartLevel.Value != kClickedRedot) {
			int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
			if (level - voiceRedDotstartLevel.Value >= 5) {
				voiceRedDotstartLevel.Value = kClickedRedot;
			}
		}
	}

	private void Update()
	{
		if (reddot.activeSelf && voiceRedDotstartLevel.Value == kClickedRedot) {
			reddot.SetActive(false);
		}
	}
}